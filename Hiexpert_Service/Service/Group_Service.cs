using Project_Model.Context;
using Project_Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hiexpert_Service.Service
{
    public class Group_Service : GenericService<Group>, IGroup_Service
    {
        public Group_Service(Hiexpert_Context Context) : base(Context)
        {
        }
    }
}
