using System;
using System.Data;
using System.Data.SqlClient;

namespace ADOExampleProject
{
    class Program
    {
        string conString;
        SqlConnection con;
        SqlCommand cmd;
        public Program()
        {
            conString = "server=LAPTOP-H1V2TQC9;Integrated security = true;Initial catalog=pubs";
            con = new SqlConnection(conString);
        }

        void FetchMoviesFromDatabase()
        {
            string strCmd = "Select * from tblMovie";
            cmd = new SqlCommand(strCmd, con);
            try
            {
                con.Open();
                SqlDataReader drMovies = cmd.ExecuteReader();
                while (drMovies.Read())
                {
                    Console.WriteLine("Movie Id : " + drMovies[0]);
                    Console.WriteLine("Movie Name : " + drMovies[1]);
                    Console.WriteLine("Movie Duration : " + drMovies[2].ToString());
                    Console.WriteLine("-----------------------------------");

                }
            }
            catch (SqlException sqlExecution)
            {
                Console.WriteLine(sqlExecution.Message);
            }
            finally
            {
                con.Close();
            }
        }

        void FetchOneMovieFromDatabase()
        {
            string strCmd = "Select * from tblMovie where id=@mid";
            cmd = new SqlCommand(strCmd, con);
            try
            {
                con.Open();

                Console.WriteLine("Please enter the Movie Id : ");
                int id = Convert.ToInt32(Console.ReadLine());
                cmd.Parameters.Add("@mid", SqlDbType.Int);
                cmd.Parameters[0].Value = id;
                SqlDataReader drMovies = cmd.ExecuteReader();
                while (drMovies.Read())
                {
                    Console.WriteLine("Movie Id : " + drMovies[0]);
                    Console.WriteLine("Movie Name : " + drMovies[1]);
                    Console.WriteLine("Movie Duration : " + drMovies[2].ToString());
                    Console.WriteLine("----------------*****----------------");
                }
            }
            catch (SqlException sqlExecution)
            {
                Console.WriteLine(sqlExecution.Message);
            }
            finally
            {
                con.Close();
            }
        }
        void UpdateMovieDuration()
        {
            Console.WriteLine("Please enter the movie name : ");
            string mName = Console.ReadLine();
            Console.WriteLine("Please enter the movie duration : ");
            float mDuration = (float)Math.Round(float.Parse(Console.ReadLine()), 2);
            string strCmd = "Update tblMovie set duration = @mdur where id = @mid";
            cmd = new SqlCommand(strCmd, con);
            cmd.Parameters.AddWithValue("@mname", mName);
            cmd.Parameters.AddWithValue("@mdur", mDuration);

            try
            {
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                    Console.WriteLine("Movie updated");
                else
                    Console.WriteLine("Task not done");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
        }

        void AddMovie()
        {
            Console.WriteLine("Please enter the movie name : ");
            string mName = Console.ReadLine();
            Console.WriteLine("Please enter the movie duration : ");
            float mDuration = (float)Math.Round(float.Parse(Console.ReadLine()), 2);
            String strCmd = "insert into tblMovie(name,duration) values(@mname,@mdur)";
            cmd = new SqlCommand(strCmd, con);
            cmd.Parameters.AddWithValue("@mname", mName);
            cmd.Parameters.AddWithValue("@mdur", mDuration);

            try
            {
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                    Console.WriteLine("Movie inserted");
                else
                    Console.WriteLine("Task not done");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
        }


        void DeleteMovie()
        {
            Console.WriteLine("Please enter the Id");
            int id = Convert.ToInt32(Console.ReadLine());
            string strCmd = "delete from tblMovie where id=@mid";
            cmd = new SqlCommand(strCmd, con);
            cmd.Parameters.AddWithValue("@mid", id);
            try
            {
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                    Console.WriteLine("Movie deleted");
                else
                    Console.WriteLine("No not done");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
        }

        void PrintSelectionForAction()
        {
            int choice = 0;
            do
            {
                Console.WriteLine("Select the action to be performed:");
                Console.WriteLine("1. Add a movie");
                Console.WriteLine("2. Fetch one movie");
                Console.WriteLine("3. Fetch all movies");
                Console.WriteLine("4. Update the movie duration");
                Console.WriteLine("5. Delete a movie");
                Console.WriteLine("-**--------**--------**-");

                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddMovie();
                        break;
                    case 2:
                        FetchOneMovieFromDatabase();
                        break;
                    case 3:
                        FetchMoviesFromDatabase();
                        break;
                    case 4:
                        UpdateMovieDuration();
                        break;
                    case 5:
                        DeleteMovie();
                        break;

                    default:
                        Console.WriteLine("Invalid entry made");
                        break;
                }
            } while (choice != 6);
        }
        static void Main(string[] args)
        {
            //new Program().FetchMoviesFromDatabase();
            //new Program().FetchOneMovieFromDatabase();
            //new Program().AddMovie();
            //new Program().DeleteMovie();
            new Program().PrintSelectionForAction();
            Console.ReadKey();
        }
    }
}