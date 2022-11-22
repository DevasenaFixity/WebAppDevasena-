using Microsoft.AspNetCore.Mvc;
using WebAppDevasena.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.ComponentModel.DataAnnotations;

namespace WebAppDevasena.Models
{
    public class STDModel
    {
        [Required(ErrorMessage = "Rollno is Required")]
        public string ROLLNO { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        public string NAME { get; set; }
        public string EMAILID { get; set; }
        [Required(ErrorMessage = "Wrong/Required password")]
        public string PASSWORD { get; set; }
        public string ROLE { get; set; }
        public DateTime DOB { get; set; }
        public string ADDRESS { get; set; }
        public int FEE { get; set; }
        public string QUALIFICATION { get; set; }
        public string GENDER { get; set; }
        public string BRANCH { get; set; }
        public string MOBILE { get; set; }
        public bool STATUS { get; set; }

    }

    
    public class STDModellogin
    {
        [Required(ErrorMessage = "Email is required*")]
        public string EMAILID { get; set; }


        [Required(ErrorMessage = "Please enter password*")]
        
        public string PASSWORD { get; set; }
    }
}
 