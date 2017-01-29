using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forms.Dtos
{
    public class ResultResponseDto : BaseDto
    {
        public int? page { get; set; }
        public List<ResultDto> results { get; set; }
        public int? total_results { get; set; }
        public int? total_pages { get; set; }
    }
}
