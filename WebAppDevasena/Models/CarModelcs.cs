namespace WebAppDevasena.Models
{
    public class CarModelcs
    {
        public string Equipment { get; set; }
        public string cartype { get; set; }
        public string commodity { get; set; }

        public DateTime arrived { get; set; }
        public DateTime modified { get; set; }
        public DateTime orderid { get; set; }
        public DateTime placed { get; set; }
        public DateTime released { get; set; }
        public int credit { get; set; }

        public int days { get; set; }
        public int missedswitch { get; set; }

    }
}
