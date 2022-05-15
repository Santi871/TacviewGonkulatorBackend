using System;
using System.Collections.Generic;

#nullable disable

namespace TacviewGonkulatorBackend
{
    public partial class Altitudemodel
    {
        public Altitudemodel()
        {
            MissileshotmodelShooterAltitudes = new HashSet<Missileshotmodel>();
            MissileshotmodelVictimAltitudes = new HashSet<Missileshotmodel>();
        }

        public int Id { get; set; }
        public int Altitude { get; set; }

        public virtual ICollection<Missileshotmodel> MissileshotmodelShooterAltitudes { get; set; }
        public virtual ICollection<Missileshotmodel> MissileshotmodelVictimAltitudes { get; set; }
    }
}
