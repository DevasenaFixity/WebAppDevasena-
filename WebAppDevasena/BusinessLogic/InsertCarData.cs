using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using System.Configuration;
using System.Reflection;
using System.Data;
using System.Data.SqlClient;
using WebAppDevasena.Models;


namespace WebAppDevasena.BusinessLogic
{
    public class InsertCarData
    {
        
        public static bool Insertdata(CarModelcs obj)
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


                    SqlCommand cmd = new SqlCommand("sp_car", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Equipment", obj.Equipment);
                    cmd.Parameters.AddWithValue("@cartype", obj.cartype);
                    cmd.Parameters.AddWithValue("@commodity", obj.commodity);
                    cmd.Parameters.AddWithValue("@arrived", Convert.ToDateTime(obj.arrived));
                    cmd.Parameters.AddWithValue("@modified", Convert.ToDateTime(obj.modified));
                    cmd.Parameters.AddWithValue("@orderid", Convert.ToDateTime(obj.orderid));
                    cmd.Parameters.AddWithValue("@placed", Convert.ToDateTime(obj.placed));
                    cmd.Parameters.AddWithValue("@released", Convert.ToDateTime(obj.released));
                    cmd.Parameters.AddWithValue("@credit", obj.credit);

                    cmd.Parameters.AddWithValue("@days", obj.days);
                    cmd.Parameters.AddWithValue("@missedswitch", obj.missedswitch);

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

        public static List<CarModelcs> GetAllData()
        {
            List<CarModelcs> obj = new List<CarModelcs>();
            var dbconfig = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_DisplayCar", con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    obj.Add(new CarModelcs
                    {
                        Equipment = Convert.ToString(dr["Equipment"].ToString()),
                        cartype = Convert.ToString(dr["cartype"].ToString()),
                        commodity = Convert.ToString(dr["commodity"].ToString()),
                        arrived = Convert.ToDateTime(dr["arrived"].ToString()),
                        modified = Convert.ToDateTime(dr["modified"].ToString()),
                        orderid = Convert.ToDateTime(dr["orderid"].ToString()),
                        placed = Convert.ToDateTime(dr["placed"].ToString()),
                        released = Convert.ToDateTime(dr["released"].ToString()),
                        credit = Convert.ToInt32(dr["credit"].ToString()),
                        days = Convert.ToInt32(dr["days"].ToString()),
                        missedswitch = Convert.ToInt32(dr["missedswitch"].ToString())
                    }
                        );
                }
                return obj;
            }

        }

    }
}

    

        
