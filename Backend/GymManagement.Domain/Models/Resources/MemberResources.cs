using GymManagement.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GenericServices;

namespace GymManagement.Domain.Models.Resources
{
    public class MemberResources : Person, ILinkToEntity<Member>
    {
        public string ImageUrl { get; set; }
        public DateTime JoiningDate { get; set; }
        public DateTime? RessignDate { get; set; }
        public List<Bill> Bills { get; set; }

        public Bill LastPayment
        {
            get { return Bills.OrderByDescending(b => b.Date).Take(1).FirstOrDefault(); }
        }
        public MemberStatus Status { get; set; }
    }
}
