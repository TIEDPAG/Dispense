using System;
using System.Collections.Generic;
using System.Text;
using TIEDPAG.Dispense.DAL;
using TIEDPAG.Dispense.Model;

namespace TIEDPAG.Dispense.Biz
{
    public class BLL
    {
        private BaseDAL<Area> _Dal = new BaseDAL<Area>();


        public void Add()
        {
            _Dal.Add(new Area
            {
                Name = "Test",
                Createby = -1,
                CreateTime = DateTime.Now,
            });
            _Dal.SaveChange();
        }
    }
}
