using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_Model.Context;
using Project_Model.Model; 

namespace Hiexpert.Repository.Repository
{
    public class Appointment_Rep : GenericRepository<Appointment>, IAppointment
    {
        public Appointment_Rep(Hiexpert_Context Context) : base(Context)
        {
        }
    }
}
