using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFxApp.Models {
    /// <summary>
    /// Represents an account entity for SQLite database.
    /// </summary>
    public class AccountEntity {
        [PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AccountId { get; set; }
        public double Gain { get; set; }
        public double AbsGain { get; set; }
        public double Daily { get; set; }
        public double Monthly { get; set; }
        public double Withdrawals { get; set; }
        public double Deposits { get; set; }
        public double Interest { get; set; }
        public double Profit { get; set; }
        public double Balance { get; set; }
        public double Drawdown { get; set; }
        public double Equity { get; set; }
        public double EquityPercent { get; set; }
        public bool Demo { get; set; }
        public string LastUpdateDate { get; set; }
        public string CreationDate { get; set; }
        public string FirstTradeDate { get; set; }
        public int Tracking { get; set; }
        public int Views { get; set; }
        public long Commission { get; set; }
        public string Currency { get; set; }
        public double ProfitFactor { get; set; }
        public double Pips { get; set; }
        public string WidgetUrl { get; set; }
    }
}
