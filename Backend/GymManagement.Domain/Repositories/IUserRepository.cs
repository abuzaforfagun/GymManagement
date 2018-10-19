using GymManagement.Domain.Models;

namespace GymManagement.Domain.Repositories
{
    public interface IUserRepository
    {
        User Get(string username, string password);
    }
}