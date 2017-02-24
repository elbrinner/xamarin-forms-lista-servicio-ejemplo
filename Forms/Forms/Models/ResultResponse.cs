using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forms.Models
{
    public class ResultResponse : Base
    {
        public int Page { get; set; }
        public List<Result> Results { get; set; }
        public int Total_results { get; set; }
        public int? Total_pages { get; set; }
    }
}
