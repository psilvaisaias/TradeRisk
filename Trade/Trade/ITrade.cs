using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade
{
    interface ITrade
    {
        double value { get; }
        string ClientSector { get; }

        DateTime nextPaymentDate { get; }

    }
}
