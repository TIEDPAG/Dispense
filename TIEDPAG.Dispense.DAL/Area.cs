using System;
using System.Collections.Generic;

namespace TIEDPAG.Dispense.DAL
{
    public partial class Area
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Createby { get; set; }
        public DateTime CreateTime { get; set; }
        public int? Updateby { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string Remark { get; set; }
    }
}
