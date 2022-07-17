using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Project_Model.Model;

namespace Project_Model.Context
{
    public class Hiexpert_Context : DbContext
    {
        public Hiexpert_Context()
            : base("name=Hiexpert_Context")
        {
        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Payment> Payments { get; set; }
        public DbSet<Group> Groups { get; set; }


    }
}
