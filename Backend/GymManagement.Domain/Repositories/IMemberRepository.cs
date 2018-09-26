using System.Collections.Generic;
using GymManagement.Domain.Models;
using GymManagement.Domain.Models.Presistance;

namespace GymManagement.Domain.Repositories
{
    public interface IMemberRepository
    {
        IEnumerable<Member> Get();
        Member Get(int id);
        void Add(MemberResourceForSave member);
        void Update(MemberResourceForUpdate member);
        void Delete(int id);
        void Delete(Member member);
        void AddBill(int memberId, Bill bill);
        Member GetDeatils(int id);
        List<Bill> GetBills(int memberId);
    }
}