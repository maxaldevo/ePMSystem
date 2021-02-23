using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePM.Dal.Logic
{
    public class ContractManager
    {
        public static List<Contracttype> getTypesList()
        {
            using (var db = new ePMEntities())
            {
                List<Contracttype> jumperVar  = db.Contracttypes.Where(x => x.Active == true).ToList();
                return jumperVar;
            }
        }
        //private static int getMaxContractUniqueID()
        //{
        //    using (var db = new ePMEntities())
        //    {
        //        int maxID = db.Contracttypes.Where(x => x.Active == true).ToList();
        //        return maxID;
        //    }
        //}
    }
}
