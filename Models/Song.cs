using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarnivalBuddyApi.Models
{
    public class Song
    {
        public required string Name { get; set; }
        public required string Artist { get; set; }
    }
}