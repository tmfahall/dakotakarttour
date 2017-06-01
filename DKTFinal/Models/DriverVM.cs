using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DKTFinal.Models
{
    public class DriverVM
    {
        public string DriverName { get; set; }
        public int TotalPoints { get; set; }
        public string Category { get; set; }
        public string DriverNumber { get; set; }
    }
}