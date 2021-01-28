using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("reference date:");

            string []dt = Console.ReadLine().Split('/');
            int iDay,iYear,iMonth;

            int.TryParse(dt[0], out iMonth);
            int.TryParse(dt[1], out iDay);
            int.TryParse(dt[2], out iYear);

            DateTime dtRef = new DateTime(iYear, iMonth, iDay, 0,0,0);

            Console.WriteLine("number of trades:");

            string n = Console.ReadLine();
            int quant;

            int.TryParse(n,out quant);

            List<TradeRisk> lstTR = new List<TradeRisk>();

            for (int i =0; i < quant;i++)
            {
                Console.WriteLine("value ClientSector nextDayPayment:");
                string []rl = Console.ReadLine().Split(' ');
                string[] dt2 = rl[2].Split('/');

                TradeRisk tr = new TradeRisk(new DateTime(Convert.ToInt32(dt2[2]), Convert.ToInt32(dt2[0]), Convert.ToInt32(dt2[1]), 0,0,0),rl[1],Convert.ToDouble(rl[0]));
                VerifyRisk(tr, dtRef);
                lstTR.Add(tr);
            }

            foreach (TradeRisk tr in lstTR)
            {
                if(tr.DEFAULTED)
                Console.WriteLine("DEFAULTED");
                else if(tr.HIGHRISK)
                    Console.WriteLine("HIGHRISK");
                else if(tr.MEDIUMRISK)
                    Console.WriteLine("MEDIUMRISK");
            }

            Console.ReadLine();
        }
        static void VerifyRisk(TradeRisk parTradeRisk, DateTime dtReference)
        {
            parTradeRisk.DEFAULTED = false;
            parTradeRisk.HIGHRISK = false;
            parTradeRisk.MEDIUMRISK = false;

            if (parTradeRisk.nextPaymentDate.Date < dtReference)
            {
                parTradeRisk.DEFAULTED = true;
            }
            else if (parTradeRisk.value > 1000000)
            {
                if (parTradeRisk.ClientSector.ToLower().Equals("private"))
                {
                    parTradeRisk.HIGHRISK = true;
                }
                else
                {
                    parTradeRisk.MEDIUMRISK = true;
                }
            }
        }
    }
}
