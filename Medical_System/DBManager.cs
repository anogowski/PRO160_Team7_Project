using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medical_System.Models;

namespace Medical_System
{
    public class DBManager
    {
        public void test()
        {
            using (var context = new MedicalSystemContext())
            {
                context.Diseases.Add(
                    new Disease()
                    {
                        DiseaseType = new DiseaseType () { Name = "no function"},
                        Name = "cannot do things"
                    });

                context.SaveChanges();
            }
        }
    }
}
