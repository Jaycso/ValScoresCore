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
        private Database db = new Database(); // creates new database instance for accessing methods in db.cs
        public mainForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            populateInputs();
        }

        public Dictionary<int, string> TeamMap => db.GetTeamMap(); // maps teams to their ids, uses getter to update whenever TeamMap is used
        public List<string> SortedTeamNames => TeamMap // sorts the team names so index can be used for assignment
                                                    .OrderBy(pair => pair.Key)  // sort by teamID
                                                    .Select(pair => pair.Value) // select only teamName
                                                    .ToList();
        public int GetKeyFromValue(string value) // gets the teamID from a teamName, could be an issue with duplicate team names
        {
            var keyValuePair = TeamMap.FirstOrDefault(kv => kv.Value == value); 
            return keyValuePair.Equals(default(KeyValuePair<int, string>)) ? -1 : keyValuePair.Key;
        }

        public Dictionary<int, int> Rankings
        {
            get // getter updates value whenever accessed
            {
                var temp = new Dictionary<int, int>(); // this will be returned later to set value

                var teamsWithPoints = new List<KeyValuePair<int, int>>(); // contains teamIDs and points

                for (int i = 0; i < Points.Count(); i++)
                {
                    int teamId = GetKeyFromValue(SortedTeamNames[i]);
                    int points = Points[i];

                    // output each team and their points
                    Debug.WriteLine($"Team: {SortedTeamNames[i]}, Team ID: {teamId}, Points: {points}");

                    // only add if the team is not already added to avoid duplicates
                    if (!teamsWithPoints.Any(t => t.Key == teamId))
                    {
                        teamsWithPoints.Add(new KeyValuePair<int, int>(teamId, points));
                    }
                }

                // Sort by points
                var sortedTeams = teamsWithPoints.OrderByDescending(tp => tp.Value).ToList();

                // assign placements
                int placement = 1;
                foreach (var team in sortedTeams) // loop through all the teams in list
                {
                    temp.Add(team.Key, placement); // add values to temp

                    // output the rankings for each team
                    Debug.WriteLine($"Ranked Team ID: {team.Key}, Rank: {placement}");
                    placement++;
                }

                return temp;
            }
        }

        private int[] Points
        {
            get // getter updates value whenever accessed
            {
                int[] temp = new int[4];
                for (int a = 0; a < 4; a++) // loop through all the teams
                {
                    for (int i = 0; i < 5; i++) // loop through all matches. both loops idealy should be using indeterminate values for length instead, however this is not required for this application.
                    {
                        if (tableItems[i, a].score > tableItems[i, a].oppScore)
                        {
                            temp[a]++; // adds 1 to the score of the team at the current index if they win match
                        }
                    }
                }
                return temp;
            }
        }

        private string formatAsTableEntry(tableItem item)
        {
            return $"{item.score}-{item.oppScore} vs. {item.opp}"; // puts the elements into a string for the table to display
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            if (!validateInput()) // only run input sequence if inputs are valid
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
            cboSideAMatch1.Items.Clear(); // clear all values in list
            cboSideBMatch1.Items.Clear();
            cboSideAMatch2.Items.Clear();
            cboSideBMatch2.Items.Clear();

            foreach (string teamName in teamNames) // add new values back to list
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
            public override string ToString() // using overide for method as .ToString is a library method. using string encoding rather than binary blob for simplicity.
            {
                return $"{score},{oppScore},{opp}";
            }

            // convert back to tableItem
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

        public tableItem[,] tableItems = new tableItem[5, 4]; // used for global in memory score storage

        public void storeInProgram()
        {
            var round = Convert.ToInt32(cboRoundSelection.Text);
            var entries = new List<(string Team, int Score, string Opponent, int OpponentScore)> // add all values to a list so it can be itterated over for assignment
            {
                (cboSideAMatch1.Text, Convert.ToInt32(txtSideAMatch1.Text), cboSideBMatch1.Text, Convert.ToInt32(txtSideBMatch1.Text)),
                (cboSideBMatch1.Text, Convert.ToInt32(txtSideBMatch1.Text), cboSideAMatch1.Text, Convert.ToInt32(txtSideAMatch1.Text)),
                (cboSideAMatch2.Text, Convert.ToInt32(txtSideAMatch2.Text), cboSideBMatch2.Text, Convert.ToInt32(txtSideBMatch2.Text)),
                (cboSideBMatch2.Text, Convert.ToInt32(txtSideBMatch2.Text), cboSideAMatch2.Text, Convert.ToInt32(txtSideAMatch2.Text))
            };

            entries.Sort((a, b) => SortedTeamNames.IndexOf(a.Team).CompareTo(SortedTeamNames.IndexOf(b.Team))); // sort to match order of team names in the table.
            for (int i = 0; i < 4; i++)
            {
                tableItems[round - 1, i] = new tableItem // initialize tableItem with fetched values
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
            if (validMsg != null) // stop execution on invalid input
            {
                MessageBox.Show(validMsg);
                return false;
            }
            return true;
        }

        public void writeToTable()
        {
            listView.Items.Clear();
            foreach (string teamName in SortedTeamNames) // adds all teamNames as new listView items
            {
                listView.Items.Add(teamName);
            }
            for (int a = 0; a < 4; a++) // loop over teams
            {
                string[] entry = new string[5];
                for (int i = 0; i < 5; i++) // loop over rounds
                {
                    entry[i] = formatAsTableEntry(tableItems[i, a]); // add values to a table before adding to listView. this allows for a single operation on listView rather than 5 separate operations.
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

            if (cboSideAMatch1.Text == cboSideAMatch2.Text || // check that selected teams are unique
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

            if (!int.TryParse(txtSideAMatch1.Text, out int scoreA1) || // ensure all scores are valid int32
                !int.TryParse(txtSideAMatch2.Text, out int scoreA2) ||
                !int.TryParse(txtSideBMatch1.Text, out int scoreB1) ||
                !int.TryParse(txtSideBMatch2.Text, out int scoreB2))
            {
                Debug.WriteLine("invalid input: one or more scores are not valid integers");
                return "Invalid score input. Please enter a valid number.";
            }

            if (scoreA1 > 100 || scoreA2 > 100 || scoreB1 > 100 || scoreB2 > 100) // range check ensuring realistic values
            {
                return "Score cannot be greater than 100";
            }

            return null;
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            db.StoreScores(tableItems); // write to database
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            tableItems = db.GetScores();
            writeToTable();
            enterPoints();
        }

        private void tableClear()
        {
            if (listView.Items.Count < 4) { MessageBox.Show("Cannot clear empty table"); return; }; // dont run if table is already empty
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
            var result = MessageBox.Show("Are you sure you want to clear the Database?", "Confirmation", // get user confirmation
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                db.clearValues();
            }
        }

        public void enterPoints()
        {
            var _Rankings = Rankings; // local copy of Rankings otherwise getter would run on every reference
            for (int i = 0; i < 4; i++)
            {
                int teamID = GetKeyFromValue(SortedTeamNames[i]);
                listView.Items[i].SubItems.Add(Points[i].ToString());

                int rank = _Rankings.ContainsKey(teamID) ? _Rankings[teamID] : -1;  // default to -1 if no ranking found
                listView.Items[i].SubItems.Add(rank.ToString());
            }

        }

        private void btnGoToTeamInfo_Click(object sender, EventArgs e)
        {
            teamInfo popup = new teamInfo(this); // cant use helper method as the popup needs to access data within mainForm, therefore it must be passed directly

            popup.updateName += () =>
            {
                updateName();
            };

            popup.Show();
        }
    }
}
