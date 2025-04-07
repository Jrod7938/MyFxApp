using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFxApp.Models {
    public class OpenTradesResponse {
        public bool error { get; set; }
        public string message { get; set; }
        public List<OpenTrade> openTrades { get; set; }
    }
}
