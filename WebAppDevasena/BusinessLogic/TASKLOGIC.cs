using System.Data;
using System.Data.SqlClient;
using System.Net.Sockets;
using WebAppDevasena.Models;
namespace WebAppDevasena.BusinessLogic
{
    public class TASKLOGIC
    {
        public static bool Insertdata(DEVAADDRESS obj)
        {
            bool res = false;
            var dbconfig = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))

            {
                try
                {
                    con.Open();


                    SqlCommand cmd = new SqlCommand("SP_DEVAADDRESS", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@HOMEID", obj.HOMEID);
                    cmd.Parameters.AddWithValue("@STREET", obj.STREET);
                    cmd.Parameters.AddWithValue("@MANDAL", obj.MANDAL);
                    cmd.Parameters.AddWithValue("@DIST", obj.DIST);
                    cmd.Parameters.AddWithValue("@STATE", obj.STATE);
                    cmd.Parameters.AddWithValue("@PINCODE", obj.PINCODE);
                    int x = cmd.ExecuteNonQuery();
                    if (x > 0)
                    {
                        return res = true;
                    }
                    else
                    {
                        return res = false;
                    }
                }
                catch (Exception)
                {

                }
                finally
                {
                    con.Close();
                }
                return res = true;
            }

        }
        public static bool Insertdata1(DEVAFAMILY obj)
        {
            bool res = false;
            var dbconfig = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))

            {
                try
                {
                    con.Open();


                    SqlCommand cmd = new SqlCommand("SP_DEVAFAMILY", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@homeid", obj.HOMEID);
                    cmd.Parameters.AddWithValue("@surname", obj.SURNAME);
                    cmd.Parameters.AddWithValue("@members", obj.MEMBERS);

                    int x = cmd.ExecuteNonQuery();
                    if (x > 0)
                    {
                        return res = true;
                    }
                    else
                    {
                        return res = false;
                    }
                }
                catch (Exception)
                {

                }
                finally
                {
                    con.Close();
                }
                return res = true;
            }

        }
    }
}





