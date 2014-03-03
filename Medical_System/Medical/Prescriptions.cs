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
            AutoFill();
        }

        private void AutoFill()
        {
            Name.Add("Medicine 1");
            Name.Add("Medicine 2");
            Name.Add("Medicine 3");
            Name.Add("Medicine 4");
            Name.Add("Medicine 5");
        }
        public void Populate(string name)
        {
            Name.Add(name);
        }

        public ObservableCollection<string> getName()
        {
            return Name;
        }
    }
}
