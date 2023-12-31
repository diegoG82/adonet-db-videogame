﻿using System.Data.SqlClient;

namespace adonet_db_videogame
{
    public static class VideogameManager
    {
        private static string connectionString = "Data Source = localhost; Initial Catalog = vg_database; Integrated Security = True; Pooling = False";

        //CREATE
        public static bool AddVideogame(Videogame videogame)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "INSERT INTO videogames (name, overview, release_date, software_house_id) VALUES (@name, @overview, @releaseDate, @softwareHouseId);";

                    SqlCommand cmd = new SqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@name", videogame.Name);
                    cmd.Parameters.AddWithValue("@overview", videogame.Overview);
                    cmd.Parameters.AddWithValue("@releaseDate", videogame.ReleaseDate);
                    cmd.Parameters.AddWithValue("@softwareHouseId", videogame.SoftwareHouseId);

                    int row = cmd.ExecuteNonQuery();
                    if (row > 0)
                    {
                        return true;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return false;
            }
        }


        //GET BY ID
        public static Videogame GetVideogameById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT id, name, overview, release_date, software_house_id FROM videogames WHERE id = @id;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                long Id = reader.GetInt64(0);
                                string name = reader.GetString(1);
                                string overview = reader.GetString(2);
                                DateTime releaseDate = reader.GetDateTime(3);
                                long softwareHouseId = reader.GetInt64(4);

                                Videogame videogame = new Videogame(Id, name, overview, releaseDate, softwareHouseId);

                                return videogame;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return null;
        }

        public static List<Videogame> GetVideogamesByString(string name)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT id, name, overview, release_date, software_house_id FROM videogames WHERE name LIKE @name";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", name);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            List<Videogame> videogames = new List<Videogame>();

                            while (reader.Read())
                            {
                                long Id = reader.GetInt64(0);
                                string gameName = reader.GetString(1);
                                string overview = reader.GetString(2);
                                DateTime releaseDate = reader.GetDateTime(3);
                                long softwareHouseId = reader.GetInt64(4);

                                Videogame videogame = new Videogame(Id, gameName, overview, releaseDate, softwareHouseId);
                                videogames.Add(videogame);
                            }

                            return videogames;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return null;
        }

        //DELETE
        public static bool DeleteVideogame(long idgametodelete)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                try
                {
                    connection.Open();

                    string query = "DELETE  FROM videogames WHERE id=@Id";

                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.Add(new SqlParameter("@Id", idgametodelete));


                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return true;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return false;

            }

        }


    }
}