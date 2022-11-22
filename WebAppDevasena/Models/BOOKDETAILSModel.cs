using Microsoft.AspNetCore.Mvc;
using WebAppDevasena.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.ComponentModel.DataAnnotations;

namespace WebAppDevasena.Models
{
    public class BOOKDETAILSModel
    {
        public int BID { get; set; }
        public string BNAME { get; set; }
        public string BAUTHOR { get; set; }
        public string BPUBLICATION { get; set; }
        public int BPRICE { get; set; }
        public DateTime BPURCHASEDATE { get; set; }


    }
}
  