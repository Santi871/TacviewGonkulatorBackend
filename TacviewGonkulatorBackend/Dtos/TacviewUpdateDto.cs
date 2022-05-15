using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TacviewGonkulatorBackend.Dtos
{
    public class MissileShotData
    {
    }
    
    public class TacviewUpdateDto
    {
        [Required]
        public string NewStatus { get; set; }
        
        [Required]
        public IEnumerable<MissileShotData> MissileShotData { get; set; }
    }
}