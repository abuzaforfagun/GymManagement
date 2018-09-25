using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagement.Domain.Models
{
    public class Bill
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime BillingDate { get; set; }
    }
}
