using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using WebAppDevasena.Models;
using WebAppDevasena.encrypteddata;


namespace WebAppDevasena.BusinessLogic
{
    public class Encrypted_bl
    {
        public static bool Insertdata(EncryptedModel obj)
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
                    SqlCommand cmd = new SqlCommand("SP_TBL_EncryptedData", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("EMAILID", EncryptionLibrary.EncryptText(obj.EMAILID));
                    cmd.Parameters.AddWithValue("PASSWORD", EncryptionLibrary.EncryptText(obj.PASSWORD));
                    int X = cmd.ExecuteNonQuery();
                    if (X > 0)
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

        public static DataTable ReadData(EncryptedModel obj)
        {
            var dbconfig = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                SqlCommand cmd = new SqlCommand("sp_Read_TBL_EncryptedData", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EMAILID", EncryptionLibrary.EncryptText(obj.EMAILID));
                cmd.Parameters.AddWithValue("@PASSWORD", EncryptionLibrary.EncryptText(obj.PASSWORD));
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}

