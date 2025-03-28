using System;
using System.Data.SQLite;
using System.Reflection.Metadata;
using System.Runtime.Serialization.Formatters.Binary;
using MessagePack;
using static System.Net.Mime.MediaTypeNames;
using System.Xml;
using static ValScoresCore.mainForm;
using System.Text;
using System.Diagnostics;
using static System.Data.Entity.Infrastructure.Design.Executor;
using System.Collections.Generic;

namespace ValScoresCore
{

    public class Database
    {
        SQLiteConnection connection;

        internal Database()
        {
            connection = new SQLiteConnection("Data Source=val.db;Cache=Shared;Mode=ReadWrite");
            CreateUsersTableIfNeeded();
            CreateTeamsTableIfNeeded();
        }

        private void CreateUsersTableIfNeeded()
        {
            try
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                @"
                CREATE TABLE IF NOT EXISTS accounts (
	            UID	INTEGER NOT NULL UNIQUE,
	            username    TEXT NOT NULL UNIQUE,
	            password    INTEGER NOT NULL,
	            PRIMARY KEY(UID AUTOINCREMENT)
                )";
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error initializing database: {ex.Message}");
                throw;
            }
        }

        private void CreateTeamsTableIfNeeded()
        {
            try
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                @"
                CREATE TABLE IF NOT EXISTS teams (
                teamID    INTEGER NOT NULL UNIQUE,
                teamName  TEXT NOT NULL UNIQUE,
                round1    TEXT,
                round2    TEXT,
                round3    TEXT,
                round4    TEXT,
                round5    TEXT,
                PRIMARY KEY(teamID AUTOINCREMENT)
                )";
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error initializing database: {ex.Message}");
                throw;
            }
        }

        public Dictionary<int, string> GetTeamMap()
        {
            var teamMap = new Dictionary<int, string>();

            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "SELECT teamID, teamName FROM teams;";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                int teamID = reader.GetInt32(0);
                string teamName = reader.GetString(1);
                teamMap[teamID] = teamName;
            }

            reader.Close();
            connection.Close();

            return teamMap;
        }

        public string getPasswordFromUID(int uid)
        {
            var password = string.Empty;

            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText =
            @"
            SELECT password
            FROM accounts
            WHERE UID = $UID
            ";
            command.Parameters.AddWithValue("$UID", uid);

            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                password = reader.GetString(0);
            }
            reader.Close();
            connection.Close();

            return password;
        }

        public int getUidFromUsername(string username)
        {
            var uid = -1;

            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText =
            @"
            SELECT uid
            FROM accounts
            WHERE username = $username
            ";
            command.Parameters.AddWithValue("$username", username);

            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                uid = reader.GetInt32(0);
            }
            reader.Close();
            connection.Close();

            return uid;
        }

        public string[] GetAllTeamNames()
        {
            List<string> teamIDs = new List<string>();

            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText =
            @"
            SELECT teamName
            FROM teams
            ";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                teamIDs.Add(reader.GetString(0));
            }
            reader.Close();
            connection.Close();

            return teamIDs.ToArray();
        }

        public void StoreScores(tableItem[,] tableItems)
        {
            connection.Open();

            var transaction = connection.BeginTransaction();

            try
            {
                for (int i = 0; i < 4; i++)
                {

                    var command = connection.CreateCommand();
                    command.CommandText = @"
                    UPDATE teams
                    SET round1 = $round1,
                    round2 = $round2,
                    round3 = $round3,
                    round4 = $round4,
                    round5 = $round5
                    WHERE teamID = $teamID;
                    ";

                    for (var x = 0; x < 5; x++)
                    {
                        command.Parameters.AddWithValue($"$round{x + 1}", SerializeToString(tableItems[x, i]));
                    }
                    command.Parameters.AddWithValue("$teamID", i + 1);
                    Debug.WriteLine($"Executing SQL: {command.CommandText}");
                    command.ExecuteNonQuery();
                }

                transaction.Commit();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                transaction.Rollback();
                throw;
            }
            finally
            {
                connection.Close();
                Debug.WriteLine("Database connection closed.");
            }
        }


        private string SerializeToString(tableItem item)
        {
            return item.ToString();
        }

        public tableItem[,] GetScores()
        {
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = @"
                SELECT round1, round2, round3, round4, round5
                FROM teams
                ";

            var reader = command.ExecuteReader();

            var tableItems = new tableItem[5, 4];

            int row = 0;
            while (reader.Read())
            {
                for (int round = 0; round < 5; round++)
                {
                    if (reader.IsDBNull(round))
                    {
                        tableItems[round, row] = new tableItem();
                    }
                    else
                    {
                        string storedString = reader.GetString(round);
                        tableItems[round, row] = DeserializeFromString(storedString);
                    }
                }
                row++;
            }

            reader.Close();
            connection.Close();

            return tableItems;
        }

        private tableItem DeserializeFromString(string data)
        {
            return tableItem.FromString(data);
        }

        public void clearValues()
        {
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText =
            @"
            UPDATE teams
            SET round1 = NULL,
            round2 = NULL,
            round3 = NULL,
            round4 = NULL,
            round5 = NULL
            ";

            command.ExecuteNonQuery();

            connection.Close();
        }

        public void updateTeamName(int teamID,  string newName)
        {
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText =
                @"
                UPDATE teams
                SET teamName = $teamName
                WHERE teamID = $teamID
                ";

            command.Parameters.AddWithValue("$teamName", newName);
            command.Parameters.AddWithValue("$teamID", teamID);

            command.ExecuteNonQuery();

            connection.Close();
        }
    }
}
