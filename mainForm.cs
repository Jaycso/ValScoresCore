using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using static ValScoresCore.Program;

namespace ValScoresCore
{
    public partial class mainForm : Form
    {
        private Database db = new Database();
        public mainForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            populateInputs();
        }

        public Dictionary<int, string> TeamMap => db.GetTeamMap();
        public List<string> SortedTeamNames => TeamMap
                                                    .OrderBy(pair => pair.Key)  // sort by teamID
                                                    .Select(pair => pair.Value) // select only teamName
                                                    .ToList();
        public int GetKeyFromValue(string value)
        {
            var keyValuePair = TeamMap.FirstOrDefault(kv => kv.Value == value);
            return keyValuePair.Equals(default(KeyValuePair<int, string>)) ? -1 : keyValuePair.Key;
        }

        public Dictionary<int, int> Rankings
        {
            get
            {
                var temp = new Dictionary<int, int>();

                var teamsWithPoints = new List<KeyValuePair<int, int>>();

                // Make sure we have unique teams with their points
                for (int i = 0; i < Points.Count(); i++)
                {
                    int teamId = GetKeyFromValue(SortedTeamNames[i]);
                    int points = Points[i];

                    // Debugging: Output each team and their points
                    Debug.WriteLine($"Team: {SortedTeamNames[i]}, Team ID: {teamId}, Points: {points}");

                    // Only add if the team is not already added to avoid duplicates
                    if (!teamsWithPoints.Any(t => t.Key == teamId))
                    {
                        teamsWithPoints.Add(new KeyValuePair<int, int>(teamId, points));
                    }
                }

                // Sort by points
                var sortedTeams = teamsWithPoints.OrderByDescending(tp => tp.Value).ToList();

                // Assign placements
                int placement = 1;
                foreach (var team in sortedTeams)
                {
                    temp.Add(team.Key, placement);

                    // Debugging: Output the rankings for each team
                    Debug.WriteLine($"Ranked Team ID: {team.Key}, Rank: {placement}");
                    placement++;
                }

                return temp;
            }
        }

        private int[] Points
        {
            get
            {
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

        private string formatAsTableEntry(tableItem item)
        {
            return $"{item.score}-{item.oppScore} vs. {item.opp}";
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            if (!validateInput())
            {
                return;
            }
            storeInProgram();
            writeToTable();
            enterPoints();
        }

        public void updateName()
        {
            populateInputs();
            writeToTable();
            enterPoints();
        }

        public void populateInputs()
        {
            populateRoundsSelector();
            populateTeamSelection();
        }

        private void populateRoundsSelector()
        {
            cboRoundSelection.Items.Clear();
            for (var i = 1; i < 6; i++)
            {
                cboRoundSelection.Items.Add(i);
            }
        }

        private void populateTeamSelection()
        {
            var teamNames = db.GetAllTeamNames();
            cboSideAMatch1.Items.Clear();
            cboSideBMatch1.Items.Clear();
            cboSideAMatch2.Items.Clear();
            cboSideBMatch2.Items.Clear();

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

        public void storeInProgram()
        {
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

        private bool validateInput()
        {
            string? validMsg = validEntry();
            if (validMsg != null)
            {
                MessageBox.Show(validMsg);
                return false;
            }
            return true;
        }

        public void writeToTable()
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

            if (!int.TryParse(txtSideAMatch1.Text, out int scoreA1) ||
                !int.TryParse(txtSideAMatch2.Text, out int scoreA2) ||
                !int.TryParse(txtSideBMatch1.Text, out int scoreB1) ||
                !int.TryParse(txtSideBMatch2.Text, out int scoreB2))
            {
                Debug.WriteLine("invalid input: one or more scores are not valid integers");
                return "Invalid score input. Please enter a valid number.";
            }

            if (scoreA1 > 100 || scoreA2 > 100 || scoreB1 > 100 || scoreB2 > 100)
            {
                return "Score cannot be greater than 100";
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
            db.StoreScores(tableItems);
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            tableItems = db.GetScores();
            writeToTable();
            enterPoints();
        }

        private void tableClear()
        {
            if (listView.Items.Count < 4) { MessageBox.Show("Cannot clear empty table"); return; };
            for (int i = 0; i < tableItems.GetLength(1); i++)
            {
                listView.Items[i].SubItems.Clear(); // clear listview
                tableItems = new tableItem[5, 4]; // clear array
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tableClear();
        }

        private void btnClearDB_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to clear the Database?", "Confirmation",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                db.clearValues();
            }
        }

        public void enterPoints()
        {
            var _Rankings = Rankings;
            for (int i = 0; i < 4; i++)
            {
                int teamID = GetKeyFromValue(SortedTeamNames[i]);
                listView.Items[i].SubItems.Add(Points[i].ToString());

                int rank = _Rankings.ContainsKey(teamID) ? _Rankings[teamID] : -1;  // Default to -1 if no ranking found
                listView.Items[i].SubItems.Add(rank.ToString());
            }

        }

        private void btnGoToTeamInfo_Click(object sender, EventArgs e)
        {
            teamInfo popup = new teamInfo(this);

            popup.updateName += () =>
            {
                updateName();
            };

            popup.Show();
        }
    }
}
