using System.Configuration;
using System.Data;
using WebAppDevasena.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace WebAppDevasena.BusinessLogic
{
    public class BookLogics
    {
        public static bool Insertdata(BOOKDETAILSModel obj)
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


                    SqlCommand cmd = new SqlCommand("SP_BOOKDETAILS", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BID", obj.BID);
                    cmd.Parameters.AddWithValue("@BNAME", obj.BNAME);
                    cmd.Parameters.AddWithValue("@BAUTHOR", obj.BAUTHOR);
                    cmd.Parameters.AddWithValue("@BPUBLICATION", obj.BPUBLICATION);
                    cmd.Parameters.AddWithValue("@BPRICE", obj.BPRICE);
                    cmd.Parameters.AddWithValue("@BPURCHASEDATE", Convert.ToDateTime(obj.BPURCHASEDATE));
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


        public static List<BOOKDETAILSModel> GetAllData()
        {
            List<BOOKDETAILSModel> obj = new List<BOOKDETAILSModel>();
            var dbconfig = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                SqlDataAdapter da = new SqlDataAdapter("SP_DISPLAYBOOK", con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    obj.Add(new BOOKDETAILSModel
                    {
                        BID = Convert.ToInt32(dr["BID"].ToString()),
                        BNAME = Convert.ToString(dr["BNAME"].ToString()),
                        BAUTHOR = Convert.ToString(dr["BAUTHOR"].ToString()),
                        BPUBLICATION = Convert.ToString(dr["BPUBLICATION"].ToString()),
                        BPRICE = Convert.ToInt32(dr["BPRICE"].ToString()),
                        BPURCHASEDATE = Convert.ToDateTime(dr["BPURCHASEDATE"].ToString())
                        
                    }
                        );
                }
                return obj;
            }

        }


        public static bool UpdateData(BOOKDETAILSModel obj)
        {
            bool res = false;
            var DBconfig = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = DBconfig["ConnectionStrings:DataBaseConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_BOOKDETAILS_UPDATE", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BID", obj.BID);
                    cmd.Parameters.AddWithValue("@BNAME", obj.BNAME);
                    cmd.Parameters.AddWithValue("@BAUTHOR", obj.BAUTHOR);
                    cmd.Parameters.AddWithValue("@BPUBLICATION", obj.BPUBLICATION);
                    cmd.Parameters.AddWithValue("@BPRICE", obj.BPRICE);
                    cmd.Parameters.AddWithValue("@BPURCHASEDATE", Convert.ToDateTime(obj.BPURCHASEDATE));
                    int x = cmd.ExecuteNonQuery();
                    if (x > 0)
                    {
                        res = true;
                    }
                    else
                    {
                        res = false;
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


        public static bool DeleteData(int BID)
        {
            bool res = false;
            var DBconfig = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = DBconfig["ConnectionStrings:DataBaseConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_BOOKDETAILS_DELETE", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BID", BID);

                    int x = cmd.ExecuteNonQuery();
                    if (x > 0)
                    {
                        res = true;
                    }
                    else
                    {
                        res = false;
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

    


    

        
    





