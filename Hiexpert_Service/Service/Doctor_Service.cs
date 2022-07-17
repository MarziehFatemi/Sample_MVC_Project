using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_Model.Context;
using Project_Model.Model;

namespace Hiexpert_Service.Service
{
    public class Doctor_Service : GenericService<Doctor>, IDcotor_Service
    {
        public Doctor_Service(Hiexpert_Context Context) : base(Context)
        {
        }

        public void AddValuesToDoctor(Doctor ThisDoctor, int Payment)
        {
            ThisDoctor.TotalSale += Payment;
            ThisDoctor.TotalIncome += (ThisDoctor.CommissionPercent * Payment)/100;
            ThisDoctor.Credit = ThisDoctor.TotalIncome - ThisDoctor.TotalCheckedOut; 
        

        }

        public void AddCheckOutToDoctor (Doctor ThisDoctor, int PayedMoney)
        {
            ThisDoctor.TotalCheckedOut += PayedMoney;
            ThisDoctor.Credit = ThisDoctor.TotalIncome - ThisDoctor.TotalCheckedOut;


        }
    }
}
