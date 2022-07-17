using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_Model.Context;
using Project_Model.Model;

namespace Hiexpert_Service.Service
{
    public class Appointment_Service : GenericService<Appointment>, IAppointment_Service
    {
        public Appointment_Service(Hiexpert_Context Context) : base(Context)
        {
        }
    }
}
