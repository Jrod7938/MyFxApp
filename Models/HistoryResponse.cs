using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFxApp.Models {
    public class HistoryResponse {
        public bool error { get; set; }
        public string message { get; set; }
        public List<HistoryEntry> history { get; set; }
    }
}
