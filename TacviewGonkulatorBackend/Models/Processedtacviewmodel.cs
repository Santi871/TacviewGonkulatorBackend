using System;
using System.Collections.Generic;

#nullable disable

namespace TacviewGonkulatorBackend
{
    public partial class Processedtacviewmodel
    {
        public int Id { get; set; }
        public string Filename { get; set; }
        public DateTime UploadedDate { get; set; }
        public DateTime? AnalyzedDate { get; set; }
        public bool Completed { get; set; }
        public string Exception { get; set; }
        public string Filehash { get; set; }
        public Guid TacviewGuid { get; set; }
        public string Status { get; set; }
    }
}
