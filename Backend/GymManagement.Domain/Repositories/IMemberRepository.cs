using System.Collections.Generic;
using GymManagement.Domain.Models;

namespace GymManagement.Domain.Repositories
{
    public interface IMemberRepository
    {
        IEnumerable<IMember> Get();
    }
}