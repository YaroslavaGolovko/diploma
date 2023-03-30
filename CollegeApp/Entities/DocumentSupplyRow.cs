using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeApp.Entities
{
    public class DocumentSupplyRow
    {
        public int SupplyTypeId { get; set; }
        public DateTime Date { get; set; }
        public int DocumentSupplyId { get; set; }
        public bool IsExist { get; set; }
    }
}
