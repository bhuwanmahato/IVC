using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace IVC.Model
{
    public class Company
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string CompanyName { get; set; }
        //public string StockSymbol { get; set; }
        //public decimal SharePrice { get; set; }
        //public decimal MarketCap { get; set; }
        //public int Multiplier { get; set; }
        //public decimal IntrinsicValue { get; set; }
        //public decimal PercentageUpDown { get; set; }
        //public decimal TotalShares { get; set; }
    }
}
