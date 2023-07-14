using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaviDataManager.Models
{
    public class RaviResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public bool Result { get; set; }
        public object Data { get; set; }
    }
}
