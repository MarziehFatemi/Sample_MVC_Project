using Project_Model.Context;
using Project_Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hiexpert_Service.Service
{
    public class Payment_Service : GenericService<Payment>, IPayment_Service
    {
        public Payment_Service(Hiexpert_Context Context) : base(Context)
        {
        }
    }
}
