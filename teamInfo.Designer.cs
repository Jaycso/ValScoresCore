namespace ValScoresCore
{
    partial class teamInfo
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cboTeamSelection = new ComboBox();
            lblTeamSelection = new Label();
            txtTeamName = new TextBox();
            label1 = new Label();
            label3 = new Label();
            txtPlacement = new TextBox();
            btnUpdate = new Button();
            SuspendLayout();
            // 
            // cboTeamSelection
            // 
            cboTeamSelection.AutoCompleteMode = AutoCompleteMode.Append;
            cboTeamSelection.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboTeamSelection.BackColor = Color.FromArgb(255, 70, 84);
            cboTeamSelection.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTeamSelection.Font = new Font("Tahoma", 30F);
            cboTeamSelection.ForeColor = Color.FromArgb(44, 44, 44);
            cboTeamSelection.FormattingEnabled = true;
            cboTeamSelection.Location = new Point(65, 75);
            cboTeamSelection.Name = "cboTeamSelection";
            cboTeamSelection.Size = new Size(108, 56);
            cboTeamSelection.TabIndex = 0;
            cboTeamSelection.SelectedIndexChanged += cboTeamSelection_SelectedIndexChanged;
            // 
            // lblTeamSelection
            // 
            lblTeamSelection.AutoSize = true;
            lblTeamSelection.BackColor = Color.Transparent;
            lblTeamSelection.Font = new Font("Tahoma", 15F);
            lblTeamSelection.ForeColor = Color.FromArgb(255, 232, 233);
            lblTeamSelection.Location = new Point(65, 48);
            lblTeamSelection.Name = "lblTeamSelection";
            lblTeamSelection.Size = new Size(175, 24);
            lblTeamSelection.TabIndex = 1;
            lblTeamSelection.Text = "Team Select by ID";
            // 
            // txtTeamName
            // 
            txtTeamName.BackColor = Color.FromArgb(253, 253, 253);
            txtTeamName.BorderStyle = BorderStyle.FixedSingle;
            txtTeamName.Font = new Font("Tahoma", 30F);
            txtTeamName.ForeColor = Color.FromArgb(44, 44, 44);
            txtTeamName.Location = new Point(272, 76);
            txtTeamName.Name = "txtTeamName";
            txtTeamName.Size = new Size(276, 56);
            txtTeamName.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Tahoma", 15F);
            label1.ForeColor = Color.FromArgb(255, 232, 233);
            label1.Location = new Point(272, 48);
            label1.Name = "label1";
            label1.Size = new Size(119, 24);
            label1.TabIndex = 2;
            label1.Text = "Team Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("VALORANT", 58F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(255, 70, 84);
            label3.Location = new Point(43, 199);
            label3.Name = "label3";
            label3.Size = new Size(535, 79);
            label3.TabIndex = 4;
            label3.Text = "Placement";
            // 
            // txtPlacement
            // 
            txtPlacement.BackColor = Color.FromArgb(75, 97, 111);
            txtPlacement.BorderStyle = BorderStyle.FixedSingle;
            txtPlacement.Font = new Font("Tahoma", 50F);
            txtPlacement.ForeColor = Color.FromArgb(129, 150, 149);
            txtPlacement.Location = new Point(65, 281);
            txtPlacement.Name = "txtPlacement";
            txtPlacement.ReadOnly = true;
            txtPlacement.Size = new Size(175, 88);
            txtPlacement.TabIndex = 5;
            txtPlacement.TextAlign = HorizontalAlignment.Center;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(48, 66, 86);
            btnUpdate.Font = new Font("Tahoma", 10F);
            btnUpdate.ForeColor = Color.FromArgb(186, 58, 70);
            btnUpdate.Location = new Point(563, 91);
            btnUpdate.Margin = new Padding(2);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(115, 40);
            btnUpdate.TabIndex = 22;
            btnUpdate.Text = "Update Name";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // teamInfo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.teamInfoBgk;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(704, 473);
            Controls.Add(btnUpdate);
            Controls.Add(txtPlacement);
            Controls.Add(label3);
            Controls.Add(txtTeamName);
            Controls.Add(label1);
            Controls.Add(lblTeamSelection);
            Controls.Add(cboTeamSelection);
            DoubleBuffered = true;
            MaximizeBox = false;
            MaximumSize = new Size(720, 512);
            MinimumSize = new Size(720, 512);
            Name = "teamInfo";
            FormClosed += teamInfo_FormClosed;
            Load += teamInfo_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cboTeamSelection;
        private Label lblTeamSelection;
        private TextBox txtTeamName;
        private Label label1;
        private Label label3;
        private TextBox txtPlacement;
        private Button btnUpdate;
    }
}
