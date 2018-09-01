using System;
using System.Collections.Generic;
using System.Text;
using GymManagement.Domain.Models.Presistance;

namespace GymManagement.Domain.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext context;
        public IMemberRepository MemberRepository { get; }

        public UnitOfWork(AppDbContext context)
        {
            this.context = context;
            this.MemberRepository = new MemberRepository(context);
        }

        public void Done()
        {
            context.SaveChanges();
        }
    }
}
