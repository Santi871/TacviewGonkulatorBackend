using System;
using System.Collections.Generic;

#nullable disable

namespace TacviewGonkulatorBackend
{
    public partial class Rangemodel
    {
        public Rangemodel()
        {
            Missileshotmodels = new HashSet<Missileshotmodel>();
        }

        public int Id { get; set; }
        public int Range { get; set; }

        public virtual ICollection<Missileshotmodel> Missileshotmodels { get; set; }
    }
}
