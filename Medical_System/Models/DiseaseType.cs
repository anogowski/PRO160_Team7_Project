using System;
using System.Collections.Generic;

namespace Medical_System.Models
{
    public partial class DiseaseType
    {
        public DiseaseType()
        {
            this.Diseases = new List<Disease>();
        }

        public int DTID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Disease> Diseases { get; set; }
    }
}
