using System;
using System.Collections.Generic;
using HotChocolate;

#nullable disable

namespace TacviewGonkulatorBackend
{
    public partial class Aircraftmodel
    {
        public Aircraftmodel()
        {
            MissileshotmodelShooterTypes = new HashSet<Missileshotmodel>();
            MissileshotmodelVictimTypes = new HashSet<Missileshotmodel>();
        }

        [GraphQLIgnore]
        public int Id { get; set; }
        public string AircraftType { get; set; }

        public virtual ICollection<Missileshotmodel> MissileshotmodelShooterTypes { get; set; }
        public virtual ICollection<Missileshotmodel> MissileshotmodelVictimTypes { get; set; }
    }
}
