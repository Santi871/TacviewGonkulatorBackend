using System;
using System.Collections.Generic;
using HotChocolate;
using HotChocolate.Data;

#nullable disable

namespace TacviewGonkulatorBackend
{
    [GraphQLDescription("Represents a processed Tacview file.")]
    public partial class Tacviewmodel
    {
        public Tacviewmodel()
        {
            Missileshotmodels = new HashSet<Missileshotmodel>();
        }

        [GraphQLIgnore]
        public int Id { get; set; }
        public string Filename { get; set; }

        [UseFiltering]
        [UseSorting]
        public virtual ICollection<Missileshotmodel> Missileshotmodels { get; set; }
    }
}
