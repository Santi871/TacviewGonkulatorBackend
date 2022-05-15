using System;
using System.Collections.Generic;
using HotChocolate;

#nullable disable

namespace TacviewGonkulatorBackend
{
    [GraphQLDescription("Represents a missile shot in a given Tacview.")]
    public partial class Missileshotmodel
    {
        public int Id { get; set; }
        public int TacviewId { get; set; }
        public int TimeId { get; set; }
        public int MissileId { get; set; }
        public int ShooterTypeId { get; set; }
        public int VictimTypeId { get; set; }
        public int ShooterMachId { get; set; }
        public int ShooterAltitudeId { get; set; }
        public int VictimAltitudeId { get; set; }
        public int RangeId { get; set; }
        public int ClosureId { get; set; }
        public int ShooterPlayerId { get; set; }
        public int VictimPlayerId { get; set; }
        public int TofId { get; set; }
        public int HitId { get; set; }
        public int DefeatTypeId { get; set; }
        public int? DefensiveManeuverId { get; set; }
        public int? AspectId { get; set; }

        public virtual Aspectmodel Aspect { get; set; }
        public virtual Closureratemodel Closure { get; set; }
        public virtual Defeattypemodel DefeatType { get; set; }
        public virtual Defensivemaneuvermodel DefensiveManeuver { get; set; }
        public virtual Hitmodel Hit { get; set; }
        public virtual Missilemodel Missile { get; set; }
        public virtual Rangemodel Range { get; set; }
        public virtual Altitudemodel ShooterAltitude { get; set; }
        public virtual Machmodel ShooterMach { get; set; }
        public virtual Playermodel ShooterPlayer { get; set; }
        public virtual Aircraftmodel ShooterType { get; set; }
        public virtual Tacviewmodel Tacview { get; set; }
        public virtual Relativetimemodel Time { get; set; }
        public virtual Timeofflightmodel Tof { get; set; }
        public virtual Altitudemodel VictimAltitude { get; set; }
        public virtual Playermodel VictimPlayer { get; set; }
        public virtual Aircraftmodel VictimType { get; set; }
    }
}
