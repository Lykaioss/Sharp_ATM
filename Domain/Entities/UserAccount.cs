using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMApp.Domain.Entities
{
    public  class UserAccount
    {
        public int id { get; set; }
        public long CardNumber { get; set; }
        public int CardPin { get; set; }
        public string FullName { get; set; }
        public long AccountNumber { get; set; }
        public decimal AccountBalance { get; set; }
        public long TotalLogin { get; set; }
        public bool IsLocked { get; set; }
   
    }
}
