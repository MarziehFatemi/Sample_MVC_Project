using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Hiexpert.Repository;
using Hiexpert.Repository.Repository;
using Project_Model.Context;
using Project_Model.Model;

namespace Hiexpert_Service.Service
{
    public class GenericService<T> : GenericRepository<T> where T : BaseEntity
    {
        public GenericService(Hiexpert_Context Context) : base(Context)
        {
        }
    }
}
