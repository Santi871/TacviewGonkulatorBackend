using System;
using System.Collections.Generic;

#nullable disable

namespace TacviewGonkulatorBackend
{
    public partial class Defeattypemodel
    {
        public Defeattypemodel()
        {
            Missileshotmodels = new HashSet<Missileshotmodel>();
        }

        public int Id { get; set; }
        public string DefeatType { get; set; }

        public virtual ICollection<Missileshotmodel> Missileshotmodels { get; set; }
    }
}
