using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ReqAddSlot
    {
        public int DoctorId { get; set; }
        public DateTime SlotDate { get; set; }
    }
}
