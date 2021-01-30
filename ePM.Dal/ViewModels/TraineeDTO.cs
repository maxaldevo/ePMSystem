using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePM_Dal.ViewModels
{
   public  class TraineeDTO
    {
        public int PersonnelId { get; set; }
        public string  Position  { get; set; }
        public string  Department { get; set; }
        public string  FullName { get; set; }
        public string Display { get; set; }
    }
}
