using System;
using System.Collections.Generic;
using HotChocolate;

#nullable disable

namespace TacviewGonkulatorBackend
{
    public partial class Aspectmodel
    {
        public Aspectmodel()
        {
            Missileshotmodels = new HashSet<Missileshotmodel>();
        }
        
        [GraphQLIgnore]
        public int Id { get; set; }
        public string Aspect { get; set; }

        public virtual ICollection<Missileshotmodel> Missileshotmodels { get; set; }
    }
}
