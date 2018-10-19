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
        public IUserRepository UserRepository { get; }

        public UnitOfWork(ICrudServices services)
        {
            this.MemberRepository = new MemberRepository(services);
            this.UserRepository = new UserRepository(services);
        }
        
    }
}
