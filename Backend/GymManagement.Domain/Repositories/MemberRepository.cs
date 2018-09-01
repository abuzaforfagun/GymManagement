using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GymManagement.Domain.Models;
using GymManagement.Domain.Models.Presistance;
using Microsoft.EntityFrameworkCore;

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

        public IMember Get(int id)
        {
            return context.Members.SingleOrDefault(m => m.Id == id);
        }

        public void Add(Member member)
        {
            context.Members.Add(member);
        }

        public void Update(IMember member)
        {
            var existingItem = context.Members.SingleOrDefault(m => m.Id == member.Id);
            context.Entry(member).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var item = context.Members.SingleOrDefault(m => m.Id == id);
            if (item != null)
            {
                context.Members.Remove(item);
            }
        }

        public void Delete(Member member)
        {
            context.Members.Remove(member);
        }
    }
}
