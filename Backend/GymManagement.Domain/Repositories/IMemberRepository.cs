using System.Collections.Generic;
using GymManagement.Domain.Models;

namespace GymManagement.Domain.Repositories
{
    public interface IMemberRepository
    {
        IEnumerable<IMember> Get();
        IMember Get(int id);
        void Add(Member member);
        void Update(IMember member);
        void Delete(int id);
        void Delete(Member member);
    }
}