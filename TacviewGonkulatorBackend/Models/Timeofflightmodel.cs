using System;
using System.Collections.Generic;

#nullable disable

namespace TacviewGonkulatorBackend
{
    public partial class Timeofflightmodel
    {
        public Timeofflightmodel()
        {
            Missileshotmodels = new HashSet<Missileshotmodel>();
        }

        public int Id { get; set; }
        public int TimeOfFlight { get; set; }

        public virtual ICollection<Missileshotmodel> Missileshotmodels { get; set; }
    }
}
