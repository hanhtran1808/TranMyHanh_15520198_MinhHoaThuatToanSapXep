using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHTTSX
{
    public enum MoveType
    {
        UpDown, RightLeft, DownUp, Stop
    }
    public class Status
    {
        public MoveType Type { get; set; }
        public int P1 { get; set; }
        public int P2 { get; set; }
    }
}
