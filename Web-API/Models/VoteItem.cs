using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_API.Models
{
    public class VoteItem
    {
        public int ItemId { get; set; }
        public string Title { get; set; }
        public int Statue { get; set; }
        public string[] Items { get; set; }
        public int[] ItemsNum { get; set; }
        public int ItemCountNum { get;  set; }
        public string UserName { get; set; }
        public string StopTime { get; set; }
    }
}