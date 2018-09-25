using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GymManagement.Domain.Models.Enums;

namespace GymManagement.Domain.Models
{
    public class Member : Person, IMember
    {
        [MaxLength(500)]
        public string ImageUrl { get; set; }
        public DateTime JoiningDate { get; set; }
        public DateTime? RessignDate { get; set; }
        public List<Bill> Bills { get; set; }
        public MemberStatus Status { get; set; }

        public Member()
        {
            Bills = new List<Bill>();
        }
    }
}