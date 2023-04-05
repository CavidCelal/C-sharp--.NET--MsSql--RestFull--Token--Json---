using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PYS.Application.Data
{
    public class TResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public List<object> Data { get; set; }
        public TResult()
        {
            Data = new List<object>();
        }
    }
}
