﻿namespace GymManagement.Domain.Repositories
{
    public interface IUnitOfWork
    {
        IMemberRepository MemberRepository { get; }
        IUserRepository UserRepository { get; }
    }
}