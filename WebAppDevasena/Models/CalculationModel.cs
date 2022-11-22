using Microsoft.AspNetCore.Mvc;
using WebAppDevasena.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.ComponentModel.DataAnnotations;
namespace WebAppDevasena.Models
{
    public class CalculationModel
    {
       // public int ID { get; set; }
       // [Required(ErrorMessage = "Enter first number")]
       // public long FIRSTNUMBER { get; set; }
        //[Required(ErrorMessage = "Enter second number")]
       // public long SECONDNUMBER { get; set; }
       // [Required(ErrorMessage = "Operation is required")]
       // public string OPERATION { get; set; }
        public string RESULT { get; set; }
    }
}
