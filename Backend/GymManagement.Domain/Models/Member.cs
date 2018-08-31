using System;
using System.ComponentModel.DataAnnotations;
using GymManagement.Domain.Models.Enums;

namespace GymManagement.Domain.Models
{
    public class Member : Person
    {
        [MaxLength(500)]
        public string ImageUrl { get; set; }
        public DateTime JoiningDate { get; set; }
        public DateTime? RessignDate { get; set; }
        public MemberStatus Status { get; set; }
    }
}