using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOfE_Ticaret.DataAccess.Entity
{
    public class IEntity
    {
        public int Id { get; set; }
        public DateTime CreateAtTime { get; set; } = DateTime.Now;
        public DateTime UpdateAtTime { get; set; } = DateTime.Now;
    }
}
