
using DataPuller;
using DataPuller.Parsers.Drivers;
using Drivers;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleDataToDB
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string url23 = "http://ergast.com/api/f1/2023/drivers.json";
            string connStr = "Data Source=DESKTOP-C4TIFQC\\SQLEXPRESS;Initial Catalog=FormulaDB;Integrated Security=True;Connect Timeout=60;";


            DriversBySeasonData dbsd = new DriversBySeasonData(url23);
            Driver[] drivers = await dbsd.GetDriversAsync();

            SqlConnection connection = new SqlConnection(connStr);

            try
            {
                connection.Open();

                foreach (var driver in drivers)
                {
                    using (SqlCommand command = new SqlCommand("spDrivers_Insert", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Dodaj parametry dla procedury składowanej
                        command.Parameters.Add("@DriverId", SqlDbType.NVarChar).Value = driver.driverId;
                        command.Parameters.Add("@url", SqlDbType.NVarChar).Value = driver.url;
                        command.Parameters.Add("@givenName", SqlDbType.NVarChar).Value = driver.givenName;
                        command.Parameters.Add("@familyName", SqlDbType.NVarChar).Value = driver.familyName;
                        command.Parameters.Add("@dateOfBirth", SqlDbType.NVarChar).Value = driver.dateOfBirth;
                        command.Parameters.Add("@nationality", SqlDbType.NVarChar).Value = driver.nationality;
                        command.Parameters.Add("@permanentNumber", SqlDbType.NVarChar).Value = driver.permanentNumber;
                        command.Parameters.Add("@code", SqlDbType.NVarChar).Value = driver.code;


                        command.ExecuteNonQuery();
                    }
                }

                Console.WriteLine("Dane kierowców zostały dodane do bazy danych za pomocą procedury składowanej.");
            
            }
            catch (Exception ex)
            {
                Console.WriteLine("Wystąpił błąd: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

        }

        
    }
}