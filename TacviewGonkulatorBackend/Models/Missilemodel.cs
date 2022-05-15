using System;
using System.Collections.Generic;
using HotChocolate;

#nullable disable

namespace TacviewGonkulatorBackend
{
    public partial class Missilemodel
    {
        public Missilemodel()
        {
            Missileshotmodels = new HashSet<Missileshotmodel>();
        }

        [GraphQLIgnore]
        public int Id { get; set; }
        public string MissileName { get; set; }
        public string MissileAliases { get; set; }

        [GraphQLIgnore]
        public virtual ICollection<Missileshotmodel> Missileshotmodels { get; set; }
    }
}
