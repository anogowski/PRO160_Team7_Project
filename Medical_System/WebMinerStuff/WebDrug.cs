using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical_System.WebMinerStuff
{
    class WebDrug
    {
        public string name_type { get; set; }
        public string drug_name { get; set; }
        
        public override string ToString()
        {
            return "Name Type(Brand or Generic): " + name_type + 
                    "\nDrug Name: " + drug_name;
        }
    }
}
