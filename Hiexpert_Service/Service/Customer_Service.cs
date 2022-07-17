using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_Model.Context;
using Project_Model.Model;

namespace Hiexpert_Service.Service
{
    public class Customer_Service : GenericService<Customer>, ICustomer_Service
    {
        public Customer_Service(Hiexpert_Context Context) : base(Context)
        {
        }

        public void AddValuesToCustomer (Customer ThisUser, int ThisPayment, int ThisSessionsNumber)
        {
            ThisUser.TotalPayment += ThisPayment;
            ThisUser.NumberOfTotalSessions += ThisSessionsNumber; 



        }
    }
}
