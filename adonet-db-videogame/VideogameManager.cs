using System.Data.SqlClient;

namespace adonet_db_videogame
{
    public static class VideogameManager
    {
        private static string connectionString = "Data Source = localhost; Initial Catalog = vg_database; Integrated Security = True; Pooling = False";

        public static bool AddVideogame(Videogame videogame)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "INSERT INTO videogames (name, overview, release_date, software_house_id) VALUES (@name, @overview, @releaseDate, @softwareHouseId);";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", videogame.Name);
                        command.Parameters.AddWithValue("@overview", videogame.Overview);
                        command.Parameters.AddWithValue("@releaseDate", videogame.ReleaseDate);
                        command.Parameters.AddWithValue("@softwareHouseId", videogame.SoftwareHouseId);

                        int row = command.ExecuteNonQuery();
                        if (row > 0)
                        {
                            return true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return false;
            }
        }







        //READ
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

    }
}