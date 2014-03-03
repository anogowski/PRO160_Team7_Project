using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical_System.Medical
{
    class Prescriptions
    {
        ObservableCollection<string> Name = new ObservableCollection<string>();
        Dictionary<string, string> Info = new Dictionary<string, string>();
        public Prescriptions()
        {

        }
        
        public void Populate()
        {
            Name.Add("");
        }

    }
}
