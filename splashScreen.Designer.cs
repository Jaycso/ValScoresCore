namespace ValScoresCore
{
    partial class splashScreen
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            loadingBar = new ProgressBar();
            timer1 = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // loadingBar
            // 
            loadingBar.BackColor = Color.FromArgb(160, 227, 255);
            loadingBar.ForeColor = Color.FromArgb(248, 79, 146);
            loadingBar.Location = new Point(100, 500);
            loadingBar.Name = "loadingBar";
            loadingBar.Size = new Size(300, 25);
            loadingBar.TabIndex = 0;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // splashScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.splashScreenImg;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(484, 661);
            Controls.Add(loadingBar);
            DoubleBuffered = true;
            Name = "splashScreen";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private ProgressBar loadingBar;
        private System.Windows.Forms.Timer timer1;
    }
}
