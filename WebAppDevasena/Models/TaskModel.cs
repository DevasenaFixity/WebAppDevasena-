using System.Collections.Generic;
using System.IO;
namespace WebAppDevasena.Models
{
    public class TaskModel
    {

    }
   
        public class DEVAADDRESS
        {
            public int HOMEID { get; set; }
            public string STREET { get; set; }
            public string MANDAL { get; set; }
            public string DIST { get; set; }
            public string STATE { get; set; }
            public int PINCODE { get; set; }
        }
        public class DEVAFAMILY
        {
            public int HOMEID { get; set; }
            public string SURNAME { get; set; }
            public int MEMBERS { get; set; }

        }

    }


