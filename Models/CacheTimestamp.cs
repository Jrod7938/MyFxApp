using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFxApp.Models {
    /// <summary>
    /// Represents a timestamp for caching purposes.
    /// </summary>
    public class CacheTimestamp {
        [PrimaryKey]
        public int Id { get; set; }
        public DateTime Time { get; set; }
    }
}
