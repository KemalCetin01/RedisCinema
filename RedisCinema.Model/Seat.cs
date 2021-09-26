using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisCinema.Model
{
   public class Seat
    {
        public int Id { get; set; }
        public  int DeskId { get; set; }
        public bool CheckSeat { get; set; }
    }
}
