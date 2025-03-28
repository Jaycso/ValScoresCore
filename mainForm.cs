using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static ValScoresCore.mainForm;

namespace ValScoresCore
{
    public partial class mainForm : Form
    {
        private Database database = new Database();
        public mainForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            populateInputs();
        }

        public Dictionary<int, string> TeamMap => database.GetTeamMap();
        public List<string> SortedTeamNames => TeamMap
                                                    .OrderBy(pair => pair.Key)  // sort by teamID
                                                    .Select(pair => pair.Value) // select only teamName
                                                    .ToList();

        private void loadTableFromDB()
        {

        }

        private string formatAsTableEntry(tableItem item)
        {
            return $"{item.score}-{item.oppScore} vs. {item.opp}";
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            storeInProgram();
            writeToTable();
            enterPoints();
        }

        private void populateInputs()
        {
            populateRoundsSelector();
            populateTeamSelection();
        }

        private void populateRoundsSelector()
        {
            for (var i = 1; i < 6; i++)
            {
                cboRoundSelection.Items.Add(i);
            }
        }

        private void populateTeamSelection()
        {
            var teamNames = database.GetAllTeamNames();

            foreach (string teamName in teamNames)
            {
                cboSideAMatch1.Items.Add(teamName);
                cboSideBMatch1.Items.Add(teamName);
                cboSideAMatch2.Items.Add(teamName);
                cboSideBMatch2.Items.Add(teamName);
            }
        }

        public struct tableItem
        {
            public int oppScore;
            public int score;
            public string opp;

            // convert to a string for db
            public override string ToString()
            {
                return $"{score},{oppScore},{opp}";
            }

            // convert back to item
            public static tableItem FromString(string data)
            {
                var parts = data.Split(',');
                return new tableItem
                {
                    score = int.Parse(parts[0]),
                    oppScore = int.Parse(parts[1]),
                    opp = parts[2]
                };
            }
        }

        public tableItem[,] tableItems = new tableItem[5, 4];

        private void storeInProgram()
        {
            string? validMsg = validEntry();
            if (validMsg != null) 
            {
                MessageBox.Show(validMsg);
                return;
            }

            var round = Convert.ToInt32(cboRoundSelection.Text);
            var entries = new List<(string Team, int Score, string Opponent, int OpponentScore)>
            {
                (cboSideAMatch1.Text, Convert.ToInt32(txtSideAMatch1.Text), cboSideBMatch1.Text, Convert.ToInt32(txtSideBMatch1.Text)),
                (cboSideBMatch1.Text, Convert.ToInt32(txtSideBMatch1.Text), cboSideAMatch1.Text, Convert.ToInt32(txtSideAMatch1.Text)),
                (cboSideAMatch2.Text, Convert.ToInt32(txtSideAMatch2.Text), cboSideBMatch2.Text, Convert.ToInt32(txtSideBMatch2.Text)),
                (cboSideBMatch2.Text, Convert.ToInt32(txtSideBMatch2.Text), cboSideAMatch2.Text, Convert.ToInt32(txtSideAMatch2.Text))
            };

            entries.Sort((a, b) => SortedTeamNames.IndexOf(a.Team).CompareTo(SortedTeamNames.IndexOf(b.Team)));
            for (int i = 0; i < 4; i++)
            {
                tableItems[round - 1, i] = new tableItem
                {
                    score = entries[i].Score,
                    oppScore = entries[i].OpponentScore,
                    opp = entries[i].Opponent
                };
            }
        }

        private void writeToTable()
        {
            listView.Items.Clear();
            foreach (string teamName in SortedTeamNames)
            {
                listView.Items.Add(teamName);
            }
            for (int a = 0; a < 4; a++)
            {
                string[] entry = new string[5];
                for (int i = 0; i < 5; i++)
                {
                    entry[i] = formatAsTableEntry(tableItems[i, a]);
                }
                listView.Items[a].SubItems.AddRange(entry);
            }
        }

        private string? validEntry()
        {
            if (cboRoundSelection.Text == "" || // check for empty fields
                cboSideAMatch1.Text == "" ||
                cboSideBMatch1.Text == "" ||
                cboSideAMatch2.Text == "" ||
                txtSideBMatch2.Text == "" ||
                txtSideBMatch2.Text == "" ||
                txtSideBMatch2.Text == "" ||
                txtSideBMatch2.Text == "")
            {
                return "Some fields are empty. Please try again.";
            }

            if (cboSideAMatch1.Text == cboSideAMatch2.Text ||
                cboSideAMatch1.Text == cboSideBMatch1.Text ||
                cboSideAMatch1.Text == cboSideBMatch2.Text ||
                cboSideAMatch2.Text == cboSideAMatch1.Text ||
                cboSideAMatch2.Text == cboSideBMatch1.Text ||
                cboSideAMatch2.Text == cboSideBMatch2.Text ||
                cboSideBMatch1.Text == cboSideAMatch1.Text ||
                cboSideBMatch1.Text == cboSideAMatch2.Text ||
                cboSideBMatch1.Text == cboSideBMatch2.Text ||
                cboSideBMatch2.Text == cboSideAMatch1.Text ||
                cboSideBMatch2.Text == cboSideAMatch2.Text ||
                cboSideBMatch2.Text == cboSideBMatch1.Text
                )
            {
                return "Ensure each team selected is unique.";
            }
            return null;
        }

        public int? GetTeamIDFromName(string teamName)
        {
            var result = TeamMap.FirstOrDefault(pair => pair.Value == teamName);

            // Check if a valid result was found
            return result.Equals(default(KeyValuePair<int, string>)) ? null : result.Key;
        }

        private void btnWriteToTable_Click(object sender, EventArgs e)
        {
            writeToTable();
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            database.StoreScores(tableItems);
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            tableItems = database.GetScores();
            writeToTable();
            enterPoints();
        }

        private void tableClear()
        {
            for (int i = 0; i < tableItems.GetLength(1); i++)
            {
                listView.Items[i].SubItems.Clear(); // clear listview
                tableItems = new tableItem[5, 4]; //clear array
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tableClear();
        }

        private void btnClearDB_Click(object sender, EventArgs e)
        {
            database.clearValues();
        }

        private int[] Points 
            { 
            get {
                    int[] temp = new int[4];
                    for (int a = 0; a < 4; a++)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            if (tableItems[i, a].score > tableItems[i, a].oppScore)
                            {
                                temp[a]++;
                            }
                        }
                    }
                    return temp;
                } 
            }

        private void enterPoints()
        {
            for (int i = 0; i < 4; i++)
            {
                listView.Items[i].SubItems.Add(Points[i].ToString());
            }
        }
    }
}
