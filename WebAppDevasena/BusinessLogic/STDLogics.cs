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
    public class STDLogics
    {
        public static bool Insertdata(STDModel obj)
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


                    SqlCommand cmd = new SqlCommand("sp_tbl_Devasena", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ROLLNO", obj.ROLLNO);
                    cmd.Parameters.AddWithValue("@NAME", obj.NAME);
                    cmd.Parameters.AddWithValue("@EMAILID", obj.EMAILID);
                    cmd.Parameters.AddWithValue("@PASSWORD", obj.PASSWORD);
                    cmd.Parameters.AddWithValue("@ROLE", obj.ROLE);
                    cmd.Parameters.AddWithValue("@DOB", Convert.ToDateTime(obj.DOB));
                    cmd.Parameters.AddWithValue("@ADDRESS", obj.ADDRESS);
                    cmd.Parameters.AddWithValue("@FEE", obj.FEE);
                    cmd.Parameters.AddWithValue("@QUALIFICATION", obj.QUALIFICATION);
                    cmd.Parameters.AddWithValue("@GENDER", obj.GENDER);
                    cmd.Parameters.AddWithValue("@BRANCH", obj.BRANCH);
                    cmd.Parameters.AddWithValue("@MOBILE", obj.MOBILE);
                    cmd.Parameters.AddWithValue("@STATUS", obj.STATUS);
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


        public static DataTable login(STDModellogin obj)
        {
            var dbconfig = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                SqlCommand cmd = new SqlCommand("sp_Login_Deva", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EMAILID", obj.EMAILID);
                cmd.Parameters.AddWithValue("@PASSWORD", obj.PASSWORD);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static List<STDModel> GetALlData()
        {
            List<STDModel> obj = new List<STDModel>();
            var DBconfig = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = DBconfig["ConnectionStrings:DataBaseConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_GetAllData", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    obj.Add(new STDModel
                    {
                        ROLLNO = dr["Rollno"].ToString(),
                        NAME = dr["Name"].ToString(),
                        EMAILID = dr["EmailID"].ToString(),
                        PASSWORD = dr["Password"].ToString(),
                        ROLE = dr["Role"].ToString(),
                        DOB = Convert.ToDateTime(dr["DOB"].ToString()),
                        ADDRESS = dr["Address"].ToString(),
                        FEE = Convert.ToInt32(dr["Fee"].ToString()),
                        QUALIFICATION = dr["Qualification"].ToString(),
                        GENDER = dr["Gender"].ToString(),
                        BRANCH = dr["Branch"].ToString(),
                        MOBILE = dr["Mobile"].ToString(),
                        STATUS = Convert.ToBoolean(dr["Status"].ToString())

                    }
                        );
                }
                return obj;
            }
        }

        public static STDModel GetDataByID(int REFID)
        {
            STDModel obj = null;
            var DBconfig = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = DBconfig["ConnectionStrings:DataBaseConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                SqlCommand cmd = new SqlCommand("SP_GETDATABY_ID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RefID", REFID);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    obj = new STDModel();
                    obj.ROLLNO = ds.Tables[0].Rows[i]["Rollno"].ToString();
                    obj.NAME = ds.Tables[0].Rows[i]["NAME"].ToString();
                    obj.EMAILID = ds.Tables[0].Rows[i]["EmailID"].ToString();
                    obj.PASSWORD = ds.Tables[0].Rows[i]["Password"].ToString();
                    obj.ROLE = ds.Tables[0].Rows[i]["Role"].ToString();
                    obj.DOB = Convert.ToDateTime(ds.Tables[0].Rows[i]["DOB"].ToString());
                    obj.ADDRESS = ds.Tables[0].Rows[i]["Address"].ToString();
                    obj.FEE = Convert.ToInt32(ds.Tables[0].Rows[i]["Fee"].ToString());
                    obj.QUALIFICATION = ds.Tables[0].Rows[i]["Qualification"].ToString();
                    obj.GENDER = ds.Tables[0].Rows[i]["Gender"].ToString();
                    obj.BRANCH = ds.Tables[0].Rows[i]["Branch"].ToString();
                    obj.MOBILE = ds.Tables[0].Rows[i]["Mobile"].ToString();
                    obj.STATUS = Convert.ToBoolean(ds.Tables[0].Rows[i]["Status"].ToString());
                }
                return obj;
            }
        }

        public static bool UpdateData(STDModel obj)
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
                    SqlCommand cmd = new SqlCommand("sp_Update_tbl_Devasena", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ROLLNO", obj.ROLLNO);
                    cmd.Parameters.AddWithValue("@NAME", obj.NAME);
                    cmd.Parameters.AddWithValue("@EMAILID", obj.EMAILID);
                    cmd.Parameters.AddWithValue("@PASSWORD", obj.PASSWORD);
                    cmd.Parameters.AddWithValue("@ROLE", obj.ROLE);
                    cmd.Parameters.AddWithValue("@DOB", Convert.ToDateTime(obj.DOB));
                    cmd.Parameters.AddWithValue("@ADDRESS", obj.ADDRESS);
                    cmd.Parameters.AddWithValue("@FEE", obj.FEE);
                    cmd.Parameters.AddWithValue("@QUALIFICATION", obj.QUALIFICATION);
                    cmd.Parameters.AddWithValue("@GENDER", obj.GENDER);
                    cmd.Parameters.AddWithValue("@BRANCH", obj.BRANCH);
                    cmd.Parameters.AddWithValue("@MOBILE", obj.MOBILE);
                    cmd.Parameters.AddWithValue("@STATUS", Convert.ToBoolean(obj.STATUS));
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

        public static bool DeleteData(int ROLLNO)
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
                    SqlCommand cmd = new SqlCommand("sp_DeleteDataBy_ID", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ROLLNO", ROLLNO);

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
