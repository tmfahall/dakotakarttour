using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DKTFinal.Models
{
    public class DriverRace
    {
        public int DriverRaceID { get; set; }

        public int Points { get; set; }

        [DisplayName("Driver")]
        public Nullable<int> Driver_DriverID { get; set; }

        [DisplayName("Race")]
        public Nullable<int> Race_RaceID { get; set; }

        public virtual Driver Driver { get; set; }

        public virtual Race Race { get; set; }
    }
}