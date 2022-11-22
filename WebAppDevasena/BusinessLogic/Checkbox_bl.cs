using System.Data;
using System.Data.SqlClient;
using WebAppDevasena.Models;
namespace WebAppDevasena.BusinessLogic
{
    public class Checkbox_bl
    {
        public static bool Insertdata(CheckboxModel OBJ)
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
                    string msg = "";

                    // if (OBJ.QUALIFICATION == true)
                    {
                        msg = msg + "BTECH" + "";
                    }

                    //if (OBJ.QUALIFICATION1 == true)
                    {
                        msg = msg + "MTECH" + "";
                    }
                    // if (OBJ.QUALIFICATION2 == true)
                    {
                        msg = msg + "DEGREE" + "";
                    }
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_TB_CHECKBOX", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ROLLNO", OBJ.ROLLNO);
                    cmd.Parameters.AddWithValue("@NAME", OBJ.NAME);
                    cmd.Parameters.AddWithValue("@QUALIFICATION", msg);
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

    

    

