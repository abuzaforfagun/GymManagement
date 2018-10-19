namespace GymManagement.Domain.Repositories
{
    public interface IUnitOfWork1
    {
        IMemberRepository MemberRepository { get; }
        IUserRepository UserRepository { get; set; }
    }
}