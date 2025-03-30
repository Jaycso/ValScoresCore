namespace ValScoresCore
{
    partial class mainForm
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
            lblRoundSelection = new Label();
            cboRoundSelection = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            cboSideAMatch1 = new ComboBox();
            label3 = new Label();
            txtSideAMatch1 = new TextBox();
            txtSideBMatch1 = new TextBox();
            label4 = new Label();
            cboSideBMatch1 = new ComboBox();
            txtSideBMatch2 = new TextBox();
            label5 = new Label();
            cboSideBMatch2 = new ComboBox();
            txtSideAMatch2 = new TextBox();
            label6 = new Label();
            cboSideAMatch2 = new ComboBox();
            listView = new ListView();
            team = new ColumnHeader();
            round1 = new ColumnHeader();
            round2 = new ColumnHeader();
            round3 = new ColumnHeader();
            round4 = new ColumnHeader();
            round5 = new ColumnHeader();
            points = new ColumnHeader();
            ranking = new ColumnHeader();
            btnInput = new Button();
            btnWrite = new Button();
            btnRead = new Button();
            btnClear = new Button();
            btnClearDB = new Button();
            btnGoToTeamInfo = new Button();
            SuspendLayout();
            // 
            // lblRoundSelection
            // 
            lblRoundSelection.AutoSize = true;
            lblRoundSelection.BackColor = Color.Transparent;
            lblRoundSelection.Font = new Font("Tahoma", 11F);
            lblRoundSelection.ForeColor = Color.WhiteSmoke;
            lblRoundSelection.Location = new Point(60, 120);
            lblRoundSelection.Name = "lblRoundSelection";
            lblRoundSelection.Size = new Size(110, 18);
            lblRoundSelection.TabIndex = 0;
            lblRoundSelection.Text = "Round Selection";
            // 
            // cboRoundSelection
            // 
            cboRoundSelection.AutoCompleteMode = AutoCompleteMode.Append;
            cboRoundSelection.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboRoundSelection.BackColor = Color.FromArgb(255, 70, 84);
            cboRoundSelection.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRoundSelection.Font = new Font("Tahoma", 12F);
            cboRoundSelection.ForeColor = Color.FromArgb(44, 44, 44);
            cboRoundSelection.FormattingEnabled = true;
            cboRoundSelection.Location = new Point(60, 140);
            cboRoundSelection.Name = "cboRoundSelection";
            cboRoundSelection.Size = new Size(121, 27);
            cboRoundSelection.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Tahoma", 10F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(255, 70, 84);
            label1.Location = new Point(60, 193);
            label1.Name = "label1";
            label1.Size = new Size(51, 17);
            label1.TabIndex = 2;
            label1.Text = "Side A";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Tahoma", 10F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(255, 70, 84);
            label2.Location = new Point(280, 193);
            label2.Name = "label2";
            label2.Size = new Size(51, 17);
            label2.TabIndex = 3;
            label2.Text = "Side B";
            // 
            // cboSideAMatch1
            // 
            cboSideAMatch1.AutoCompleteMode = AutoCompleteMode.Append;
            cboSideAMatch1.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboSideAMatch1.BackColor = Color.FromArgb(255, 70, 84);
            cboSideAMatch1.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSideAMatch1.Font = new Font("Tahoma", 11F);
            cboSideAMatch1.ForeColor = Color.FromArgb(44, 44, 44);
            cboSideAMatch1.FormattingEnabled = true;
            cboSideAMatch1.Location = new Point(60, 240);
            cboSideAMatch1.Name = "cboSideAMatch1";
            cboSideAMatch1.Size = new Size(121, 26);
            cboSideAMatch1.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Tahoma", 8F);
            label3.ForeColor = Color.LightGray;
            label3.Location = new Point(60, 220);
            label3.Name = "label3";
            label3.Size = new Size(45, 13);
            label3.TabIndex = 5;
            label3.Text = "Match 1";
            // 
            // txtSideAMatch1
            // 
            txtSideAMatch1.BackColor = Color.FromArgb(44, 44, 44);
            txtSideAMatch1.Font = new Font("Tahoma", 11F);
            txtSideAMatch1.ForeColor = Color.WhiteSmoke;
            txtSideAMatch1.Location = new Point(189, 240);
            txtSideAMatch1.Name = "txtSideAMatch1";
            txtSideAMatch1.Size = new Size(60, 25);
            txtSideAMatch1.TabIndex = 6;
            // 
            // txtSideBMatch1
            // 
            txtSideBMatch1.BackColor = Color.FromArgb(44, 44, 44);
            txtSideBMatch1.Font = new Font("Tahoma", 11F);
            txtSideBMatch1.ForeColor = Color.WhiteSmoke;
            txtSideBMatch1.Location = new Point(410, 240);
            txtSideBMatch1.Name = "txtSideBMatch1";
            txtSideBMatch1.Size = new Size(60, 25);
            txtSideBMatch1.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Tahoma", 8F);
            label4.ForeColor = Color.LightGray;
            label4.Location = new Point(280, 220);
            label4.Name = "label4";
            label4.Size = new Size(45, 13);
            label4.TabIndex = 8;
            label4.Text = "Match 1";
            // 
            // cboSideBMatch1
            // 
            cboSideBMatch1.AutoCompleteMode = AutoCompleteMode.Append;
            cboSideBMatch1.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboSideBMatch1.BackColor = Color.FromArgb(255, 70, 84);
            cboSideBMatch1.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSideBMatch1.Font = new Font("Tahoma", 11F);
            cboSideBMatch1.ForeColor = Color.FromArgb(44, 44, 44);
            cboSideBMatch1.FormattingEnabled = true;
            cboSideBMatch1.Location = new Point(280, 240);
            cboSideBMatch1.Name = "cboSideBMatch1";
            cboSideBMatch1.Size = new Size(121, 26);
            cboSideBMatch1.TabIndex = 7;
            // 
            // txtSideBMatch2
            // 
            txtSideBMatch2.BackColor = Color.FromArgb(44, 44, 44);
            txtSideBMatch2.Font = new Font("Tahoma", 11F);
            txtSideBMatch2.ForeColor = Color.WhiteSmoke;
            txtSideBMatch2.Location = new Point(410, 293);
            txtSideBMatch2.Name = "txtSideBMatch2";
            txtSideBMatch2.Size = new Size(60, 25);
            txtSideBMatch2.TabIndex = 15;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Tahoma", 8F);
            label5.ForeColor = Color.LightGray;
            label5.Location = new Point(280, 273);
            label5.Name = "label5";
            label5.Size = new Size(45, 13);
            label5.TabIndex = 14;
            label5.Text = "Match 2";
            // 
            // cboSideBMatch2
            // 
            cboSideBMatch2.AutoCompleteMode = AutoCompleteMode.Append;
            cboSideBMatch2.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboSideBMatch2.BackColor = Color.FromArgb(255, 70, 84);
            cboSideBMatch2.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSideBMatch2.Font = new Font("Tahoma", 11F);
            cboSideBMatch2.ForeColor = Color.FromArgb(44, 44, 44);
            cboSideBMatch2.FormattingEnabled = true;
            cboSideBMatch2.Location = new Point(280, 293);
            cboSideBMatch2.Name = "cboSideBMatch2";
            cboSideBMatch2.Size = new Size(121, 26);
            cboSideBMatch2.TabIndex = 13;
            // 
            // txtSideAMatch2
            // 
            txtSideAMatch2.BackColor = Color.FromArgb(44, 44, 44);
            txtSideAMatch2.Font = new Font("Tahoma", 11F);
            txtSideAMatch2.ForeColor = Color.WhiteSmoke;
            txtSideAMatch2.Location = new Point(189, 293);
            txtSideAMatch2.Name = "txtSideAMatch2";
            txtSideAMatch2.Size = new Size(60, 25);
            txtSideAMatch2.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Tahoma", 8F);
            label6.ForeColor = Color.LightGray;
            label6.Location = new Point(60, 273);
            label6.Name = "label6";
            label6.Size = new Size(45, 13);
            label6.TabIndex = 11;
            label6.Text = "Match 2";
            // 
            // cboSideAMatch2
            // 
            cboSideAMatch2.AutoCompleteMode = AutoCompleteMode.Append;
            cboSideAMatch2.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboSideAMatch2.BackColor = Color.FromArgb(255, 70, 84);
            cboSideAMatch2.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSideAMatch2.Font = new Font("Tahoma", 11F);
            cboSideAMatch2.ForeColor = Color.FromArgb(44, 44, 44);
            cboSideAMatch2.FormattingEnabled = true;
            cboSideAMatch2.Location = new Point(60, 293);
            cboSideAMatch2.Name = "cboSideAMatch2";
            cboSideAMatch2.Size = new Size(121, 26);
            cboSideAMatch2.TabIndex = 10;
            // 
            // listView
            // 
            listView.Columns.AddRange(new ColumnHeader[] { team, round1, round2, round3, round4, round5, points, ranking });
            listView.Location = new Point(60, 340);
            listView.Name = "listView";
            listView.Size = new Size(722, 180);
            listView.TabIndex = 16;
            listView.UseCompatibleStateImageBehavior = false;
            listView.View = View.Details;
            // 
            // team
            // 
            team.Text = "Team";
            team.Width = 80;
            // 
            // round1
            // 
            round1.Text = "Round 1";
            round1.Width = 100;
            // 
            // round2
            // 
            round2.Text = "Round 2";
            round2.Width = 100;
            // 
            // round3
            // 
            round3.Text = "Round 3";
            round3.Width = 100;
            // 
            // round4
            // 
            round4.Text = "Round 4";
            round4.Width = 100;
            // 
            // round5
            // 
            round5.Text = "Round 5";
            round5.Width = 100;
            // 
            // points
            // 
            points.Text = "Total Points";
            points.Width = 80;
            // 
            // ranking
            // 
            ranking.Text = "Rank";
            // 
            // btnInput
            // 
            btnInput.BackColor = Color.FromArgb(48, 66, 86);
            btnInput.Font = new Font("Tahoma", 10F);
            btnInput.ForeColor = Color.FromArgb(186, 58, 70);
            btnInput.Location = new Point(546, 240);
            btnInput.Margin = new Padding(2);
            btnInput.Name = "btnInput";
            btnInput.Size = new Size(98, 40);
            btnInput.TabIndex = 17;
            btnInput.Text = "Input Scores";
            btnInput.UseVisualStyleBackColor = false;
            btnInput.Click += btnInput_Click;
            // 
            // btnWrite
            // 
            btnWrite.BackColor = Color.FromArgb(48, 66, 86);
            btnWrite.Font = new Font("Tahoma", 10F);
            btnWrite.ForeColor = Color.FromArgb(186, 58, 70);
            btnWrite.Location = new Point(667, 193);
            btnWrite.Margin = new Padding(2);
            btnWrite.Name = "btnWrite";
            btnWrite.Size = new Size(115, 40);
            btnWrite.TabIndex = 18;
            btnWrite.Text = "Write to DB";
            btnWrite.UseVisualStyleBackColor = false;
            btnWrite.Click += btnWrite_Click;
            // 
            // btnRead
            // 
            btnRead.BackColor = Color.FromArgb(48, 66, 86);
            btnRead.Font = new Font("Tahoma", 10F);
            btnRead.ForeColor = Color.FromArgb(186, 58, 70);
            btnRead.Location = new Point(667, 240);
            btnRead.Margin = new Padding(2);
            btnRead.Name = "btnRead";
            btnRead.Size = new Size(115, 40);
            btnRead.TabIndex = 19;
            btnRead.Text = "Read from DB";
            btnRead.UseVisualStyleBackColor = false;
            btnRead.Click += btnRead_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(48, 66, 86);
            btnClear.Font = new Font("Tahoma", 10F);
            btnClear.ForeColor = Color.FromArgb(186, 58, 70);
            btnClear.Location = new Point(546, 286);
            btnClear.Margin = new Padding(2);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(98, 40);
            btnClear.TabIndex = 20;
            btnClear.Text = "Clear Table";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // btnClearDB
            // 
            btnClearDB.BackColor = Color.FromArgb(48, 66, 86);
            btnClearDB.Font = new Font("Tahoma", 10F);
            btnClearDB.ForeColor = Color.FromArgb(186, 58, 70);
            btnClearDB.Location = new Point(667, 284);
            btnClearDB.Margin = new Padding(2);
            btnClearDB.Name = "btnClearDB";
            btnClearDB.Size = new Size(115, 40);
            btnClearDB.TabIndex = 21;
            btnClearDB.Text = "Clear DB";
            btnClearDB.UseVisualStyleBackColor = false;
            btnClearDB.Click += btnClearDB_Click;
            // 
            // btnGoToTeamInfo
            // 
            btnGoToTeamInfo.BackColor = Color.FromArgb(48, 66, 86);
            btnGoToTeamInfo.Font = new Font("Tahoma", 10F);
            btnGoToTeamInfo.ForeColor = Color.FromArgb(186, 58, 70);
            btnGoToTeamInfo.Location = new Point(787, 340);
            btnGoToTeamInfo.Margin = new Padding(2);
            btnGoToTeamInfo.Name = "btnGoToTeamInfo";
            btnGoToTeamInfo.Size = new Size(95, 95);
            btnGoToTeamInfo.TabIndex = 22;
            btnGoToTeamInfo.Text = "Open Team Info";
            btnGoToTeamInfo.UseVisualStyleBackColor = false;
            btnGoToTeamInfo.Click += btnGoToTeamInfo_Click;
            // 
            // mainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackgroundImage = Properties.Resources.mainBackground;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(993, 593);
            Controls.Add(btnGoToTeamInfo);
            Controls.Add(btnClearDB);
            Controls.Add(btnClear);
            Controls.Add(btnRead);
            Controls.Add(btnWrite);
            Controls.Add(btnInput);
            Controls.Add(listView);
            Controls.Add(txtSideBMatch2);
            Controls.Add(label5);
            Controls.Add(cboSideBMatch2);
            Controls.Add(txtSideAMatch2);
            Controls.Add(label6);
            Controls.Add(cboSideAMatch2);
            Controls.Add(txtSideBMatch1);
            Controls.Add(label4);
            Controls.Add(cboSideBMatch1);
            Controls.Add(txtSideAMatch1);
            Controls.Add(label3);
            Controls.Add(cboSideAMatch1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cboRoundSelection);
            Controls.Add(lblRoundSelection);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(2);
            Name = "mainForm";
            Text = "Valorant Tournament";
            Load += mainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblRoundSelection;
        private ComboBox cboRoundSelection;
        private Label label1;
        private Label label2;
        private ComboBox cboSideAMatch1;
        private Label label3;
        private TextBox txtSideAMatch1;
        private TextBox txtSideBMatch1;
        private Label label4;
        private ComboBox cboSideBMatch1;
        private TextBox txtSideBMatch2;
        private Label label5;
        private ComboBox cboSideBMatch2;
        private TextBox txtSideAMatch2;
        private Label label6;
        private ComboBox cboSideAMatch2;
        private ListView listView;
        private ColumnHeader team;
        private ColumnHeader round1;
        private ColumnHeader round2;
        private ColumnHeader round3;
        private ColumnHeader round4;
        private ColumnHeader round5;
        private ColumnHeader points;
        private Button btnInput;
        private Button btnWrite;
        private Button btnRead;
        private Button btnClear;
        private Button btnClearDB;
        private Button btnGoToTeamInfo;
        private ColumnHeader ranking;
    }
}