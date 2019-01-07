using System;
using System.Collections.Generic;
using System.Text;
using TIEDPAG.Dispense.IDAL;
using TIEDPAG.Dispense.Model;

namespace TIEDPAG.Dispense.DAL
{
    public class AreaDAL : BaseDAL<Area>, IAreaDAL
    {
        public AreaDAL(tiedpag_dispenseContext context) : base(context) { }
    }
}
