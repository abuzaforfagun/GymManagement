using GenericServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagement.Domain.Models.Presistance
{
    public class MemberResourceForSave : ILinkToEntity<Member>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string ImageUrl { get; set; }
        public DateTime JoiningDate { get; set; }
    }
}
