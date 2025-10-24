using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

// Simple SQLite storage helper for beginners.
// Keeps the DB file local (labubu.db) and provides small helpers.
public static class SimpleStorage
{
    private static readonly string DbPath = "labubu.db";
    private static readonly object _initLock = new object();
    private static bool _initialized = false;

    // Ensure DB and table exist; seed with default codes if empty.
    public static void EnsureDatabase()
    {
        if (_initialized) return;
        lock (_initLock)
        {
            if (_initialized) return;

            var cs = new SqliteConnectionStringBuilder { DataSource = DbPath }.ToString();
            using (var conn = new SqliteConnection(cs))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    // Create table if it doesn't exist (with minimal columns)
                    cmd.CommandText = @"CREATE TABLE IF NOT EXISTS ValidCodes (
                                            Code TEXT PRIMARY KEY,
                                            Series TEXT
                                         );";
                    cmd.ExecuteNonQuery();

                    // Add FirstVerified column if it doesn't exist
                    cmd.CommandText = @"SELECT COUNT(*) FROM pragma_table_info('ValidCodes') WHERE name='FirstVerified';";
                    var hasFirstVerified = Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                    if (!hasFirstVerified)
                    {
                        cmd.CommandText = "ALTER TABLE ValidCodes ADD COLUMN FirstVerified TEXT;";
                        cmd.ExecuteNonQuery();
                    }

                    // Add VerificationCount column if it doesn't exist
                    cmd.CommandText = @"SELECT COUNT(*) FROM pragma_table_info('ValidCodes') WHERE name='VerificationCount';";
                    var hasVerificationCount = Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                    if (!hasVerificationCount)
                    {
                        cmd.CommandText = "ALTER TABLE ValidCodes ADD COLUMN VerificationCount INTEGER DEFAULT 0;";
                        cmd.ExecuteNonQuery();
                    }
                }

                // Seed defaults if table is empty
                using (var countCmd = conn.CreateCommand())
                {
                    countCmd.CommandText = "SELECT COUNT(1) FROM ValidCodes;";
                    var count = Convert.ToInt32(countCmd.ExecuteScalar());
                    if (count == 0)
                    {
                        using (var ins = conn.CreateCommand())
                        {
                            ins.CommandText = "INSERT INTO ValidCodes (Code, Series) VALUES (@c, @s);";
                            ins.Parameters.AddWithValue("@c", "ABC123");
                            ins.Parameters.AddWithValue("@s", "Big Into Energy");
                            ins.ExecuteNonQuery();

                            ins.Parameters.Clear();
                            ins.Parameters.AddWithValue("@c", "XYZ999");
                            ins.Parameters.AddWithValue("@s", "Exciting Macarons");
                            ins.ExecuteNonQuery();
                        }
                    }
                }

                conn.Close();
            }

            _initialized = true;
        }
    }

    // Check if a code exists in the DB
    public static bool CodeExists(string code)
    {
        if (string.IsNullOrEmpty(code)) return false;
        EnsureDatabase();
        var cs = new SqliteConnectionStringBuilder { DataSource = DbPath }.ToString();
        using (var conn = new SqliteConnection(cs))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT 1 FROM ValidCodes WHERE Code = @c LIMIT 1;";
                cmd.Parameters.AddWithValue("@c", code);
                using (var reader = cmd.ExecuteReader())
                {
                    return reader.Read();
                }
            }
        }
    }

    // Add a code (ignore if exists)
    public static void AddCode(string code, string series = "")
    {
        if (string.IsNullOrEmpty(code)) return;
        EnsureDatabase();
        var cs = new SqliteConnectionStringBuilder { DataSource = DbPath }.ToString();
        using (var conn = new SqliteConnection(cs))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "INSERT OR IGNORE INTO ValidCodes (Code, Series) VALUES (@c, @s);";
                cmd.Parameters.AddWithValue("@c", code);
                cmd.Parameters.AddWithValue("@s", series ?? string.Empty);
                cmd.ExecuteNonQuery();
            }
        }
    }

    // List all codes (simple helper)
    public static List<string> GetAllCodes()
    {
        EnsureDatabase();
        var result = new List<string>();
        var cs = new SqliteConnectionStringBuilder { DataSource = DbPath }.ToString();
        using (var conn = new SqliteConnection(cs))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT Code FROM ValidCodes ORDER BY Code;";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read()) result.Add(reader.GetString(0));
                }
            }
        }
        return result;
    }

    // Get the series name for a specific code
    public static string GetSeriesForCode(string code)
    {
        if (string.IsNullOrEmpty(code)) return string.Empty;
        EnsureDatabase();
        var cs = new SqliteConnectionStringBuilder { DataSource = DbPath }.ToString();
        using (var conn = new SqliteConnection(cs))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT Series FROM ValidCodes WHERE Code = @c;";
                cmd.Parameters.AddWithValue("@c", code);
                var result = cmd.ExecuteScalar();
                return result?.ToString() ?? string.Empty;
            }
        }
    }

    // Update or get first verification timestamp and increment verification count
    public static (string timestamp, int verificationCount) UpdateVerificationInfo(string code)
    {
        if (string.IsNullOrEmpty(code)) return (string.Empty, 0);
        EnsureDatabase();
        var cs = new SqliteConnectionStringBuilder { DataSource = DbPath }.ToString();
        using (var conn = new SqliteConnection(cs))
        {
            conn.Open();
            using (var trans = conn.BeginTransaction())
            {
                try
                {
                    string timestamp;
                    int count;

                    // First try to get existing info
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.Transaction = trans;
                        cmd.CommandText = "SELECT FirstVerified, VerificationCount FROM ValidCodes WHERE Code = @c;";
                        cmd.Parameters.AddWithValue("@c", code);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                timestamp = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                                count = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);
                            }
                            else
                            {
                                timestamp = string.Empty;
                                count = 0;
                            }
                        }
                    }

                    // Update verification info
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.Transaction = trans;
                        if (string.IsNullOrEmpty(timestamp))
                        {
                            timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            cmd.CommandText = "UPDATE ValidCodes SET FirstVerified = @t, VerificationCount = 1 WHERE Code = @c;";
                            cmd.Parameters.AddWithValue("@t", timestamp);
                        }
                        else
                        {
                            cmd.CommandText = "UPDATE ValidCodes SET VerificationCount = VerificationCount + 1 WHERE Code = @c;";
                        }
                        cmd.Parameters.AddWithValue("@c", code);
                        cmd.ExecuteNonQuery();
                    }

                    trans.Commit();
                    return (timestamp, count + 1);
                }
                catch
                {
                    trans.Rollback();
                    throw;
                }
            }
        }
    }
}
