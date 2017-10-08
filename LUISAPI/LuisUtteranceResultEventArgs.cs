using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Cognitive.LUIS;

namespace LUISAPI
{
    public class LuisUtteranceResultEventArgs : EventArgs
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public bool RequiresReply { get; set; }
    }
}
