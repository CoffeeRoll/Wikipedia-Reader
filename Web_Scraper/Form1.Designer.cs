namespace Web_Scraper
{
	/// <summary>
	/// Auto-generated class that handles GUI variable declarations and component disposal
	/// </summary>
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.rtbContent = new System.Windows.Forms.RichTextBox();
			this.bScrape = new System.Windows.Forms.Button();
			this.rtbURL = new System.Windows.Forms.RichTextBox();
			this.cbTTSVoices = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.bRead = new System.Windows.Forms.Button();
			this.bStop = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// rtbContent
			// 
			this.rtbContent.Location = new System.Drawing.Point(12, 12);
			this.rtbContent.Name = "rtbContent";
			this.rtbContent.Size = new System.Drawing.Size(577, 576);
			this.rtbContent.TabIndex = 0;
			this.rtbContent.Text = "";
			// 
			// bScrape
			// 
			this.bScrape.Location = new System.Drawing.Point(683, 251);
			this.bScrape.Name = "bScrape";
			this.bScrape.Size = new System.Drawing.Size(104, 23);
			this.bScrape.TabIndex = 1;
			this.bScrape.Text = "Get New Page";
			this.bScrape.UseVisualStyleBackColor = true;
			this.bScrape.Click += new System.EventHandler(this.bScrape_Click);
			// 
			// rtbURL
			// 
			this.rtbURL.HideSelection = false;
			this.rtbURL.Location = new System.Drawing.Point(596, 12);
			this.rtbURL.Name = "rtbURL";
			this.rtbURL.Size = new System.Drawing.Size(265, 86);
			this.rtbURL.TabIndex = 2;
			this.rtbURL.Text = "";
			this.rtbURL.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.rtbURL_LinkClicked);
			// 
			// cbTTSVoices
			// 
			this.cbTTSVoices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbTTSVoices.FormattingEnabled = true;
			this.cbTTSVoices.Location = new System.Drawing.Point(619, 407);
			this.cbTTSVoices.Name = "cbTTSVoices";
			this.cbTTSVoices.Size = new System.Drawing.Size(121, 21);
			this.cbTTSVoices.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(616, 391);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(37, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Voice:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(690, 343);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(69, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "TTS Settings";
			// 
			// bRead
			// 
			this.bRead.Location = new System.Drawing.Point(683, 462);
			this.bRead.Name = "bRead";
			this.bRead.Size = new System.Drawing.Size(75, 23);
			this.bRead.TabIndex = 6;
			this.bRead.Text = "Read";
			this.bRead.UseVisualStyleBackColor = true;
			this.bRead.Click += new System.EventHandler(this.bRead_Click);
			// 
			// bStop
			// 
			this.bStop.Location = new System.Drawing.Point(683, 492);
			this.bStop.Name = "bStop";
			this.bStop.Size = new System.Drawing.Size(75, 23);
			this.bStop.TabIndex = 7;
			this.bStop.Text = "Stop";
			this.bStop.UseVisualStyleBackColor = true;
			this.bStop.Click += new System.EventHandler(this.bStop_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(873, 601);
			this.Controls.Add(this.bStop);
			this.Controls.Add(this.bRead);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cbTTSVoices);
			this.Controls.Add(this.rtbURL);
			this.Controls.Add(this.bScrape);
			this.Controls.Add(this.rtbContent);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		/// <summary>
		/// RichTextbox for displaying scraped content
		/// </summary>
        private System.Windows.Forms.RichTextBox rtbContent; 

		/// <summary>
		/// Button to scrape a Wikipedia article
		/// </summary>
        private System.Windows.Forms.Button bScrape;

		/// <summary>
		/// RichTextbox to show the URL of the Wikipedia article being scraped
		/// </summary>
        private System.Windows.Forms.RichTextBox rtbURL;

		/// <summary>
		/// ComboBox drop-down list of all installed and supported text-to-speech voices
		/// </summary>
        private System.Windows.Forms.ComboBox cbTTSVoices;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;

		/// <summary>
		/// Button to start reading the text contained in rtbContent utilizing the voice selected in cbTTSVoices
		/// </summary>
        private System.Windows.Forms.Button bRead;

		/// <summary>
		/// Button to stop reading 
		/// </summary>
        private System.Windows.Forms.Button bStop;
    }
}

