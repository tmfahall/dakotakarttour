using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DKTFinal.Models
{
    public class Race
    {
        public Race()
        {
            this.DriverRaces = new HashSet<DriverRace>();
        }

        public int RaceID { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public System.DateTime RaceDate { get; set; }

        [DisplayName("Name")]
        public string RaceName { get; set; }

        [DisplayName("Class")]
        public Classes RaceClass { get; set; }
        
        public virtual ICollection<DriverRace> DriverRaces { get; set; }
    }
}