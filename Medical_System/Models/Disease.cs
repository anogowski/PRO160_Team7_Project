using System;
using System.Collections.Generic;

namespace Medical_System.Models
{
    public partial class Disease
    {
        public int DEAID { get; set; }
        public string Name { get; set; }
        public Nullable<int> Disease_type { get; set; }
        public virtual DiseaseType DiseaseType { get; set; }
    }
}
