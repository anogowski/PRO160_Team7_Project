using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical_System.Medical
{
    class Disorders
    {
        ObservableCollection<string> Name = new ObservableCollection<string>();
        Dictionary<string, string> Info = new Dictionary<string, string>();
    }
}
