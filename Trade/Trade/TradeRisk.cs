using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade
{
    public class TradeRisk : Trade
    {
        public TradeRisk(DateTime parNextPaymentDate, string parClientSector, double parValue)
        {
            nextPaymentDate = parNextPaymentDate;
            ClientSector = parClientSector;
            value = parValue;
        }
        public bool DEFAULTED { get; set; }
        public bool HIGHRISK { get; set; }
        public bool MEDIUMRISK { get; set; }          
    }
}
