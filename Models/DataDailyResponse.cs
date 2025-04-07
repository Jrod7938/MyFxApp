using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFxApp.Models {
    public class DataDailyResponse {
        public bool error { get; set; }
        public string message { get; set; }
        public List<List<DataDaily>> dataDaily { get; set; }
    }
}
