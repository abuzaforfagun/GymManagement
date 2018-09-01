using System;
using GymManagement.Domain.Models.Enums;

namespace GymManagement.Domain.Models
{
    public interface IMember
    {
        string ImageUrl { get; set; }
        DateTime JoiningDate { get; set; }
        DateTime? RessignDate { get; set; }
        MemberStatus Status { get; set; }
        int Id { get; set; }
        string Name { get; set; }
        string Mobile { get; set; }
        string Address { get; set; }
    }
}