namespace MakeThisWindowAlwaysOnTop
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lstWindows = new System.Windows.Forms.ListBox();
            this.helpText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstWindows
            // 
            this.lstWindows.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstWindows.FormattingEnabled = true;
            this.lstWindows.ItemHeight = 25;
            this.lstWindows.Location = new System.Drawing.Point(12, 12);
            this.lstWindows.Name = "lstWindows";
            this.lstWindows.Size = new System.Drawing.Size(966, 529);
            this.lstWindows.TabIndex = 0;
            this.lstWindows.DoubleClick += new System.EventHandler(this.lstWindows_DoubleClick);
            this.lstWindows.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lstWindows_MouseUp);
            // 
            // helpText
            // 
            this.helpText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.helpText.Location = new System.Drawing.Point(12, 548);
            this.helpText.Name = "helpText";
            this.helpText.Size = new System.Drawing.Size(966, 42);
            this.helpText.TabIndex = 1;
            this.helpText.Text = "Double-click to switch on/off Always On Top, Right-click to refresh the applicati" +
    "ons list";
            this.helpText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 599);
            this.Controls.Add(this.helpText);
            this.Controls.Add(this.lstWindows);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Make This Window Always On Top";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstWindows;
        private System.Windows.Forms.Label helpText;
    }
}

