using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DKTFinal.Models
{
    public class Driver
    {
        public Driver()
        {
            this.DriverRaces = new HashSet<DriverRace>();
        }

        public int DriverID { get; set; }

        [DisplayName("Name")]
        public string DriverName { get; set; }

        [DisplayName("Number")]
        public string DriverNumber { get; set; }

        public virtual ICollection<DriverRace> DriverRaces { get; set; }
    }
}