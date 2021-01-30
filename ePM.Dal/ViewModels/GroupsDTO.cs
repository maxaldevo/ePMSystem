using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePM_Dal.ViewModels
{
    public class GroupsDTO
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public string ParentGroup { get; set; }
        public int ParentId { get; set; }
    }
}
