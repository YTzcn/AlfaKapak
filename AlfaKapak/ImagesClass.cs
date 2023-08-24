using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaKapak
{
    public class ImagesClass
    {
        public string? LittleTitle { get; set; }
        public string? Title { get; set; }
        public string BgPath { get; set; } = string.Empty;
        public string SmallPath1 { get; set; } = string.Empty;
        public string SmallPath2 { get; set; } = string.Empty;
        public List<string> Features { get; set; } = new List<string>();
    }

}
