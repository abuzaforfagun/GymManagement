using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GymManagement.Domain.Models;
using GymManagement.Domain.Models.Presistance;

namespace GymManagement.Domain.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly AppDbContext context;

        public MemberRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<IMember> Get()
        {
            return context.Members.ToList();
        }
    }
}
