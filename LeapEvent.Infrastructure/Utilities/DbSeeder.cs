using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeapEvent.Infrastructure.Utilities
{
    public static class DbSeeder
    {
        public static void SeedIfNeeded(string dbPath, string seedScriptPath)
        {
            if (!File.Exists(dbPath))
                throw new FileNotFoundException("Database file not found.", dbPath);

            using var connection = new SqliteConnection($"Data Source={dbPath}");
            connection.Open();

            // Check if any data already exists
            var checkCmd = connection.CreateCommand();
            checkCmd.CommandText = "SELECT COUNT(*) FROM Events;";
            var existingCount = Convert.ToInt32(checkCmd.ExecuteScalar());

            if (existingCount > 0)
                return; 

            var script = File.ReadAllText(seedScriptPath);

            using var transaction = connection.BeginTransaction();
            var cmd = connection.CreateCommand();
            cmd.CommandText = script;
            cmd.ExecuteNonQuery();
            transaction.Commit();
        }
    }

}
