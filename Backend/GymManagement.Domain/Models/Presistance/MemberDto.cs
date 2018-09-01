using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagement.Domain.Models.Presistance
{
    public class MemberDto
    {
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string ImageUrl { get; set; }
        public DateTime JoiningDate { get; set; }
        public DateTime? RessignDate { get; set; }
    }
}
