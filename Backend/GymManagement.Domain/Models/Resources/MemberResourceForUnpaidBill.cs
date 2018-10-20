using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GenericServices;

namespace GymManagement.Domain.Models.Resources
{
    public class MemberResourceForUnpaidBill : Person
    {
        public DateTime JoiningDate { get; set; }
        public List<DateTime> UnpaidBills { get; set; }
        public string ImageUrl { get; set; }
        public Bill LastPayment { get; set; }

        public MemberResourceForUnpaidBill()
        {
            UnpaidBills = new List<DateTime>();
        }
    }
}
