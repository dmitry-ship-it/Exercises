using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalStream
{
    internal class ReadPercentEventArgs : EventArgs
    {
        public ReadPercentEventArgs(int percent)
        {
            if (percent < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(percent), "The percentage cannot be less than zero.");
            }

            Percent = percent;
        }

        public int Percent { get; init; }
    }
}
