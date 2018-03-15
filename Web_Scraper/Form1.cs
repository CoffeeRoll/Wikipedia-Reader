using HtmlAgilityPack;
using System;
using System.Collections;
using System.Speech.Synthesis;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Web_Scraper
{
    public partial class Form1 : Form
    {
        private SpeechSynthesizer syn; //Used to read text

        public Form1()
        {
            InitializeComponent();

            syn = new SpeechSynthesizer();
            syn.SetOutputToDefaultAudioDevice(); //Read to system default audio output
            SetupVoiceList();
            
        }

        /// <summary>
        /// Calls SetupArticle()
        /// </summary>
        /// <param name="sender">Not used</param>
        /// <param name="e">Not used</param>
        private void bScrape_Click(object sender, EventArgs e)
        {
            SetupArticle();
			
        }

        /// <summary>
        /// Gets text from a random wikipedia article using the WikipediaScraper class and displays the text in rtbContent
        /// </summary>
        public void SetupArticle()
        {
            var web = new HtmlWeb();
            web.Load("https://en.wikipedia.org/wiki/Special:Random");
            string articleURL = web.ResponseUri.AbsoluteUri;
            Clipboard.SetText(articleURL);
            rtbURL.Text = articleURL;
            rtbContent.Text = WikipediaScraper.GetArticleContent(articleURL, true, true, true, true);
        }

        /// <summary>
        /// Utilizes the SpeechSynthesizer class to read the contents of rtbContent utilizing the voice selected in cbTTSVoices.
        /// </summary>
        public void ReadArticle()
        {
            syn.SelectVoice(cbTTSVoices.GetItemText(cbTTSVoices.SelectedItem));
            syn.SpeakAsync(rtbContent.Text);
        }

        /// <summary>
        /// Gets a list of compatible TTS voices installed on the system and lists them in cbTTSVoices
        /// </summary>
        private void SetupVoiceList()
        {
            var voiceList = syn.GetInstalledVoices(); //Gets a list of installed/supported TTS voices
            for(int t = 0; t < voiceList.Count; t++) //Adds all supported voices to cbTTSVoices
            {
                cbTTSVoices.Items.Add(voiceList[t].VoiceInfo.Name);
            }
            cbTTSVoices.SelectedIndex = 0; //Default to the first entry

        }

		//Unreliable -- please ignore
        private void rtbURL_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Console.WriteLine(e.LinkText);
        }

        private void bRead_Click(object sender, EventArgs e)
        {
            ReadArticle();
        }

        private void bStop_Click(object sender, EventArgs e)
        {
            syn.SpeakAsyncCancelAll();
        }
    }
}
