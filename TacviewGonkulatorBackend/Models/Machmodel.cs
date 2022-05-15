using System;
using System.Collections.Generic;

#nullable disable

namespace TacviewGonkulatorBackend
{
    public partial class Machmodel
    {
        public Machmodel()
        {
            Missileshotmodels = new HashSet<Missileshotmodel>();
        }

        public int Id { get; set; }
        public double Mach { get; set; }

        public virtual ICollection<Missileshotmodel> Missileshotmodels { get; set; }
    }
}
