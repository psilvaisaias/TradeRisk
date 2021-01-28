using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade
{
    public abstract class Trade : ITrade
    {
        public double value { get; set; }

        public string ClientSector { get; set; }

        public DateTime nextPaymentDate { get; set; }
    }
}
