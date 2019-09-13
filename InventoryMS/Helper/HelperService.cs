using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryMS.Helper
{
    public class HelperService : IHelperService
    {
        public string key(int? maxId)
        {
            string key = string.Empty;
            var length = maxId.ToString().Length;

            if (length > 3)
            {
                key = maxId.ToString();
            }
            else if (length == 3)
            {
                key="0"+ maxId.ToString();
            }

            else if (length == 2)
            {
                key = "00" + maxId.ToString();
            }
            else
            {
                key = "000" + maxId.ToString();
            }
            return  key;
        }
    }
}
