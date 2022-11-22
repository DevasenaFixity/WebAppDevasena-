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
    public class ddl_blcs
    {
        public static List<DdlModel> PopulateData()
        {
            var dbconfig = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            List<DdlModel> obj = new List<DdlModel>();
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                string query = "sp_getdistcust";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            obj.Add(new DdlModel
                            {
                                CustomerID = Convert.ToString(sdr["CustomerID"])
                            });
                        }
                    }
                }
                con.Close();

            }
            return obj;
        }


        public static List<OrdersModel> GetOrdersByCust(string? CustomerID)
        {
            var dbconfig = new ConfigurationBuilder()
                         .SetBasePath(Directory.GetCurrentDirectory())
                         .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                SqlCommand cmd = new SqlCommand("select * from orders where CustomerID=@CustomerID", con);
                cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
                con.Open();
                SqlDataReader idr = cmd.ExecuteReader();
                List<OrdersModel> customers = new List<OrdersModel>();
                if (idr.HasRows)
                {
                    while (idr.Read())
                    {
                        customers.Add(new OrdersModel
                        {
                            OrderID = Convert.ToInt32(idr["OrderID"]),
                            CustomerID = Convert.ToString(idr["CustomerID"]),
                            EmployeeID = Convert.ToInt32(idr["EmployeeID"]),
                            OrderDate = Convert.ToDateTime(idr["OrderDate"]),
                            RequiredDate = Convert.ToDateTime(idr["RequiredDate"]),
                            ShippedDate = Convert.ToDateTime(idr["ShippedDate"]),
                        });
                    }
                }
                return customers;
            }
        }

        public static List<DdlModel> GetOrderDate()
        {

            var dbconfig = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            List<DdlModel> obj = new List<DdlModel>();
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                string query = "sp_GetOrderDate";
                using (SqlCommand cmd = new SqlCommand(query))

                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())

                    {
                        while (sdr.Read())
                        {
                            obj.Add(new DdlModel
                            {
                                OrderDate = Convert.ToDateTime(sdr["OrderDate"])
                            });

                        }

                    }

                }
                con.Close();
            }


            return obj;
        }


        public static List<OrdersModel> GetOrdersByorderdate(string? OrderDate)
        {
            var dbconfig = new ConfigurationBuilder()
                         .SetBasePath(Directory.GetCurrentDirectory())
                         .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                SqlCommand cmd = new SqlCommand("select * from orders where OrderDate=@OrderDate", con);
                cmd.Parameters.AddWithValue("@OrderDate", OrderDate);
                con.Open();
                SqlDataReader idr = cmd.ExecuteReader();
                List<OrdersModel> Orders = new List<OrdersModel>();
                if (idr.HasRows)
                {
                    while (idr.Read())
                    {
                        Orders.Add(new OrdersModel
                        {
                            OrderID = Convert.ToInt32(idr["OrderID"]),
                            CustomerID = Convert.ToString(idr["CustomerID"]),
                            EmployeeID = Convert.ToInt32(idr["EmployeeID"]),
                            OrderDate = Convert.ToDateTime(idr["OrderDate"]),
                            RequiredDate = Convert.ToDateTime(idr["RequiredDate"]),
                            ShippedDate = Convert.ToDateTime(idr["ShippedDate"]),
                            ShipVia = Convert.ToInt32(idr["ShipVia"]),
                            Freight = Convert.ToSingle(idr["Freight"]),
                            ShipName = Convert.ToString(idr["ShipName"]),
                            ShipAddress = Convert.ToString(idr["ShipAddress"]),
                            ShipCity = Convert.ToString(idr["ShipCity"]),
                            ShipRegion = Convert.ToString(idr["ShipRegion"]),
                            ShipPostalCode = Convert.ToString(idr["ShipPostalCode"]),
                            ShipCountry = Convert.ToString(idr["ShipCountry"])
                        });
                    }
                }

                con.Close();
                return Orders;

            }

        }
        public static List<DdlModel> GetOrdersByShpdDate()
        {

            var dbconfig = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            List<DdlModel> obj = new List<DdlModel>();
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                string query = "sp_GetShippedDate";
                using (SqlCommand cmd = new SqlCommand(query))

                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())

                    {
                        while (sdr.Read())
                        {
                            obj.Add(new DdlModel
                            {
                                OrderDate = Convert.ToDateTime(sdr["ShippedDate"])
                            });

                        }

                    }

                }
                con.Close();
            }


            return obj;
        }
        public static List<OrdersModel> GetOrdersByShpdDate(string? ShippedDate)
        {
            var dbconfig = new ConfigurationBuilder()
                         .SetBasePath(Directory.GetCurrentDirectory())
                         .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                SqlCommand cmd = new SqlCommand("select * from orders where ShippedDate=@ShippedDate", con);
                cmd.Parameters.AddWithValue("@ShippedDate", ShippedDate);
                con.Open();
                SqlDataReader idr = cmd.ExecuteReader();
                List<OrdersModel> Orders = new List<OrdersModel>();
                if (idr.HasRows)
                {
                    while (idr.Read())
                    {
                        Orders.Add(new OrdersModel
                        {
                            OrderID = Convert.ToInt32(idr["OrderID"]),
                            CustomerID = Convert.ToString(idr["CustomerID"]),
                            EmployeeID = Convert.ToInt32(idr["EmployeeID"]),
                            OrderDate = Convert.ToDateTime(idr["OrderDate"]),
                            RequiredDate = Convert.ToDateTime(idr["RequiredDate"]),
                            ShippedDate = Convert.ToDateTime(idr["ShippedDate"]),
                            ShipVia = Convert.ToInt32(idr["ShipVia"]),
                            Freight = Convert.ToSingle(idr["Freight"]),
                            ShipName = Convert.ToString(idr["ShipName"]),
                            ShipAddress = Convert.ToString(idr["ShipAddress"]),
                            ShipCity = Convert.ToString(idr["ShipCity"]),
                            ShipRegion = Convert.ToString(idr["ShipRegion"]),
                            ShipPostalCode = Convert.ToString(idr["ShipPostalCode"]),
                            ShipCountry = Convert.ToString(idr["ShipCountry"])
                        });
                    }
                }

                con.Close();
                return Orders;

            }

        }
        public static List<DdlModel> GetDdlCntry()
        {

            var dbconfig = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            List<DdlModel> obj = new List<DdlModel>();
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                string query = "sp_GetShipCountry";
                using (SqlCommand cmd = new SqlCommand(query))

                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())

                    {
                        while (sdr.Read())
                        {
                            obj.Add(new DdlModel
                            {
                                OrderDate = Convert.ToDateTime(sdr["ShippedDate"])
                            });

                        }

                    }

                }
                con.Close();
            }


            return obj;
        }
        public static List<OrdersModel> GetDdlCntry(string? ShipCountry)
        {
            var dbconfig = new ConfigurationBuilder()
                         .SetBasePath(Directory.GetCurrentDirectory())
                         .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                SqlCommand cmd = new SqlCommand("select * from orders where ShipCountry=@ShipCountry", con);
                cmd.Parameters.AddWithValue("@ShipCountry", ShipCountry);
                con.Open();
                SqlDataReader idr = cmd.ExecuteReader();
                List<OrdersModel> Orders = new List<OrdersModel>();
                if (idr.HasRows)
                {
                    while (idr.Read())
                    {
                        Orders.Add(new OrdersModel
                        {
                            OrderID = Convert.ToInt32(idr["OrderID"]),
                            CustomerID = Convert.ToString(idr["CustomerID"]),
                            EmployeeID = Convert.ToInt32(idr["EmployeeID"]),
                            OrderDate = Convert.ToDateTime(idr["OrderDate"]),
                            RequiredDate = Convert.ToDateTime(idr["RequiredDate"]),
                            ShippedDate = Convert.ToDateTime(idr["ShippedDate"]),
                            ShipVia = Convert.ToInt32(idr["ShipVia"]),
                            Freight = Convert.ToSingle(idr["Freight"]),
                            ShipName = Convert.ToString(idr["ShipName"]),
                            ShipAddress = Convert.ToString(idr["ShipAddress"]),
                            ShipCity = Convert.ToString(idr["ShipCity"]),
                            ShipRegion = Convert.ToString(idr["ShipRegion"]),
                            ShipPostalCode = Convert.ToString(idr["ShipPostalCode"]),
                            ShipCountry = Convert.ToString(idr["ShipCountry"])
                        });
                    }
                }

                con.Close();
                return Orders;

            }

        }
    }
}
    

    

