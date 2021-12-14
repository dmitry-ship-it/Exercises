using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalStream
{
    internal class ReadPercentEventArgs : EventArgs
    {
        public int Percent { get; set; }
    }
}
