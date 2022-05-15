using System;
using System.Collections.Generic;

#nullable disable

namespace TacviewGonkulatorBackend
{
    public partial class Closureratemodel
    {
        public Closureratemodel()
        {
            Missileshotmodels = new HashSet<Missileshotmodel>();
        }

        public int Id { get; set; }
        public int ClosureRate { get; set; }

        public virtual ICollection<Missileshotmodel> Missileshotmodels { get; set; }
    }
}
