using System;
using System.Collections.Generic;

#nullable disable

namespace TacviewGonkulatorBackend
{
    public partial class Playermodel
    {
        public Playermodel()
        {
            MissileshotmodelShooterPlayers = new HashSet<Missileshotmodel>();
            MissileshotmodelVictimPlayers = new HashSet<Missileshotmodel>();
        }

        public int Id { get; set; }
        public string Username { get; set; }

        public virtual ICollection<Missileshotmodel> MissileshotmodelShooterPlayers { get; set; }
        public virtual ICollection<Missileshotmodel> MissileshotmodelVictimPlayers { get; set; }
    }
}
