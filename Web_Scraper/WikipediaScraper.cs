using System;
using System.Collections;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace Web_Scraper
{
	/// <summary>
	/// Manages the functions associated with scraping text from Wikipedia articles. 
	/// </summary>
	static class WikipediaScraper
	{
		/// <summary>
		/// Retrieves the HTML document from a given URL 
		/// </summary>
		/// <param name="url">String containing a valid URL</param>
		/// <returns>HtmlDocument object containing the HTML associated with the provided URL</returns>
		public static HtmlDocument GetHtml(string url)
		{
			var web = new HtmlWeb();
			return web.Load(url);
		}

		/// <summary>
		/// Converts a given HtmlNodeCollection into an HtmlDocument
		/// </summary>
		/// <param name="nodes">
		/// HtmlNodeCollection to be converted into an HtmlDocument
		/// </param>
		/// <returns>
		/// HtmlDocument composed of all HtmlNodes in nodes
		/// </returns>
		public static HtmlDocument NodeCollectionToDocument(HtmlNodeCollection nodes)
		{
			String html = "";
			foreach(HtmlNode node in nodes)
			{
				html += node.OuterHtml;
			}

			Console.WriteLine(html);

			var doc = new HtmlDocument();
			doc.LoadHtml(html);
			return doc;
			
		}

		/// <summary>
		/// Shaves down the HTML code from a Wikipedia article, such that only the main content remains.
		/// </summary>
		/// <param name="url">A valid URL to a Wikipedia article</param>
		/// <param name="removeSidebar">
		/// Type: Boolean <br>
		/// Description: Remove the sidebar on the right side of some articles that contains additional information not found in the main body <br>
		/// [true]:     Remove sidebar <br>
		/// [false]:    Keep sidebar <br>
		/// </param>
		/// <param name="removeReferenceSections">
		/// Type: Boolean<br>
		/// Description: Removes reference sections and other sections that contain no constructive information about the article.<br>
		/// Removed sections: References, Notes, See also, Further reading, Notes and references, External links<br>
		/// [true]:     Remove sections<br>
		/// [false]:    Keep  sections<br>
		/// </param>
		/// <param name="removeNotes">
		/// Type: Boolean<br>
		/// Description: Remove disambiguation notes the can be found at the top of some articles.<br>
		/// [true]:     Remove notes<br>
		/// [false]:    Keep notes<br>
		/// </param>
		/// <param name="removeWarnings">
		/// Type: Boolean<br>
		/// Description: Removes citation warning banners that pertain to some articles.<br>
		/// [true]:     Remove warning banners<br>
		/// [false]:    Keep warning banners<br>
		/// </param>
		/// <returns>
		/// String containing all text scraped from the provided URL after processing the flags
		/// </returns>
		public static string GetArticleContent(string url, bool removeSidebar, bool removeReferenceSections, bool removeNotes, bool removeWarnings)
		{
			//Get HTML
			var doc = GetHtml(url);

			//Isolates the content div
			var contentDivNodes = doc.DocumentNode.SelectNodes("//div[@id='content']");
			doc.LoadHtml(contentDivNodes[0].OuterHtml);

			//Isolate article title
			var heading = doc.DocumentNode.SelectNodes("//h1[@id='firstHeading']");

			//Isolate article body
			var bodyContent = doc.DocumentNode.SelectNodes("//div[@id='mw-content-text']");

			var bodyDoc = NodeCollectionToDocument(bodyContent);

			//Remove content issue warning banner if present (insufficient/no citations)
			if (removeWarnings)
			{
				try
				{
					foreach (var tag in bodyDoc.DocumentNode.Descendants("table")) //bodyContent.Descendants("table")
					{
						if (tag.GetAttributeValue("role", "") == "presentation")
				 		{
							tag.Remove();
						}
					}
				}
				catch (Exception err) { Console.WriteLine(err.InnerException); }
			}

			if (removeNotes)
			{
				try
				{
					foreach (var tag in bodyDoc.DocumentNode.Descendants("div"))
					{
						if (tag != null && tag.GetAttributeValue("role", "") == "note")
						{
							tag.Remove();
						}
					}
				}
				catch (Exception err) {}
			}

			//Remove sidebar if present
			if (removeSidebar)
			{
				try
				{
					//The first non-presentation table in bodyContent
					foreach (var tag in bodyDoc.DocumentNode.Descendants("table"))
					{
						if (tag.GetAttributeValue("role", "") != "presentation")
						{
							tag.Remove();
							break;
						}
					}
				}
				catch (Exception err) { Console.WriteLine("Sidebar Error: " + err.InnerException); }
			}

			//Remove ToC if present
			try
			{
				bodyDoc.DocumentNode.SelectSingleNode("//div[@id='toc']").Remove();

			}
			catch (Exception err) { Console.WriteLine("ToC Error: " + err.InnerException); }

			String data = heading[0].InnerText + '\n' + bodyDoc.DocumentNode.InnerText;

			//Remove citation numbers
			data = Regex.Replace(data, @"\[[0-9]+\]", "");

			//Remove reference sections from bottom of article
			if (removeReferenceSections)
			{
				string[] endings = { "References[edit]", "See also[edit]", "Notes[edit]", "Notes and references[edit]", "Further reading[edit]", "External links[edit]" };

				ArrayList tmpArr = new ArrayList();
				foreach (String s in endings)
				{
					int tmpInt = data.IndexOf(s);
					if (tmpInt != -1) //If found
					{
						tmpArr.Add(tmpInt);
					}
				}
				if (tmpArr.Count > 0)
				{
					tmpArr.Sort();
					data = data.Substring(0, (int)tmpArr[0]);
				}
				tmpArr = null;
			}

			//Formatting

			//Remove edits
			data = data.Replace("[edit]", "");

			//Remove non-breaking space chars
			data = data.Replace("&#160", " ");

			//Fix newlines (3+ goes to 2) to maintain paragraph spacing
			data = data.Replace("\r", "\n");
			string test = "\n\n";
			data = Regex.Replace(data, @"\n\n(\n)+", test);

			return data;
		}
	}
}
