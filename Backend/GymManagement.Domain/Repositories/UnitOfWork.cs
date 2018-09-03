using System;
using System.Collections.Generic;
using System.Text;
using GenericServices;
using GymManagement.Domain.Models.Presistance;

namespace GymManagement.Domain.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IMemberRepository MemberRepository { get; }

        public UnitOfWork(ICrudServices services)
        {
            this.MemberRepository = new MemberRepository(services);
        }
        
    }
}
