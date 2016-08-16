using System;

namespace Reining.BussinessLogic
{
    public class MCateogry
    {
        public int MCategoryID { get; set; }
        public int MemberTypeID { get; set; }
        public double Fee { get; set; }
        public string Category { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
    }

}