using System;
using System.Collections.Generic;
using System.Text;
using TIEDPAG.Dispense.IBiz;
using TIEDPAG.Dispense.IDAL;
using TIEDPAG.Dispense.Model;

namespace TIEDPAG.Dispense.Biz
{
    public class BLL : IBaseBLL, IBLL
    {
        private IAreaDAL _Dal { get; set; }

        public BLL(IAreaDAL _dal)
        {
            _Dal = _dal;
        }


        public bool Add()
        {
            _Dal.Add(new Area
            {
                Name = "Test",
                Createby = -1,
                CreateTime = DateTime.Now,
            });
            return _Dal.SaveChange();
        }
    }
}
