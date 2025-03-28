using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValScoresCore
{
    public partial class teamInfo : Form
    {
        private mainForm MainForm;
        private Database db = new Database();
        public event Action updateName;
        public teamInfo(mainForm mainForm)
        {
            InitializeComponent();
            MainForm = mainForm;
        }

        private int[] teamIDs => MainForm.TeamMap.Keys.OrderBy(key => key).ToArray();

        private void populateTeamID()
        {
            foreach (int id in teamIDs)
            {
                cboTeamSelection.Items.Add(id);
            }
        }

        private void teamInfo_Load(object sender, EventArgs e)
        {
            populateTeamID();
        }

        private void cboTeamSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            var _rankings = MainForm.Rankings;
            var _TeamMap = MainForm.TeamMap;
            string[] conversions = {"1st", "2nd", "3rd", "4th"};
            int selectedTeamId = Convert.ToInt32(cboTeamSelection.Text);
            int rank = _rankings.ContainsKey(selectedTeamId) ? _rankings[selectedTeamId] : -1;

            txtTeamName.Text = _TeamMap[selectedTeamId];
            txtPlacement.Text = conversions[rank - 1];
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            db.updateTeamName(Convert.ToInt32(cboTeamSelection.Text), txtTeamName.Text);
        }

        private void teamInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            updateName?.Invoke();
        }

    }
}
