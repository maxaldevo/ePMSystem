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
        public int getMaxContractUniqueID(int ContractTypeID)
        {
            using (var db = new ePMEntities())
            {
                int maxID = 0;
                switch (ContractTypeID)
                {
                    case 1:
                        maxID = db.Contract_L01A.Max(x => x.UniqueID).Value;
                        break;
                    case 2:
                        maxID = db.Contract_L01B.Max(x => x.UniqueID).Value;
                        break;
                    case 3:
                        maxID = db.Contract_L02A.Max(x => x.UniqueID).Value;
                        break;
                    case 4:
                        maxID = db.Contract_L02B.Max(x => x.UniqueID).Value;
                        break;
                    case 5:
                        maxID = db.Contract_L01D.Max(x => x.UniqueID).Value;
                        break;
                    case 6:
                        maxID = db.Contract_03_15.Max(x => x.UniqueID).Value;
                        break;
                    case 7:
                        maxID = db.Contract_03_16.Max(x => x.UniqueID).Value;
                        break;
                    case 8:
                        maxID = db.Contract_04_05.Max(x => x.UniqueID).Value;
                        break;
                    case 9:
                        maxID = db.Contract_01_09.Max(x => x.UniqueID).Value;
                        break;
                    case 10:
                        maxID = db.Contract_01_10.Max(x => x.UniqueID).Value;
                        break;
                    case 11:
                        maxID = db.Contract_01_11.Max(x => x.UniqueID).Value;
                        break;
                    case 12:
                        maxID = db.Contract_01_12.Max(x => x.UniqueID).Value;
                        break;
                    case 13:
                        maxID = db.Contract_01_L12.Max(x => x.UniqueID).Value;
                        break;
                    case 14:
                        maxID = db.Contract_01_L01C.Max(x => x.UniqueID).Value;
                        break;
                    case 15:
                        maxID = db.Contract_QDP510_QF11.Max(x => x.UniqueID).Value;
                        break;
                    case 16:
                        maxID = db.Contract_QDP510_QF17.Max(x => x.UniqueID).Value;
                        break;
                    case 17:
                        maxID = db.Contract_01_L09.Max(x => x.UniqueID).Value;
                        break;
                    case 18:
                        maxID = db.Contract_01_E15.Max(x => x.UniqueID).Value;
                        break;
                    case 19:
                        maxID = db.Contract_01_L03A.Max(x => x.UniqueID).Value;
                        break;
                    case 20:
                        maxID = db.Contract_01_L03B.Max(x => x.UniqueID).Value;
                        break;
                    case 21:
                        maxID = db.Contract_01_L10.Max(x => x.UniqueID).Value;
                        break;
                    case 22:
                        maxID = db.Contract_01L15.Max(x => x.UniqueID).Value;
                        break;
                    case 23:
                        maxID = db.Contract_01_L15.Max(x => x.UniqueID).Value;
                        break;
                    case 24:
                        maxID = db.Contract_RA257_L01A.Max(x => x.UniqueID).Value;
                        break;
                    case 25:
                        maxID = db.Contract_01L15.Max(x => x.UniqueID).Value;
                        break;
                    case 26:
                        maxID = db.Contract_01L15.Max(x => x.UniqueID).Value;
                        break;
                    case 27:
                        maxID = db.Contract_01L15.Max(x => x.UniqueID).Value;
                        break;
                    case 28:
                        maxID = db.Contract_01L15.Max(x => x.UniqueID).Value;
                        break;
                    case 29:
                        maxID = db.Contract_01L15.Max(x => x.UniqueID).Value;
                        break;

                }
                return maxID;
            }
        }
        public string getContractNameByTypeID(int ContractTypeID)
        {
            using (var db = new ePMEntities())
            {
                string contractName = db.Contracttypes.Where(x => x.ID == ContractTypeID).FirstOrDefault().Contname;
                return contractName;
            }
        }
    }
}
