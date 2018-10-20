using System.Collections.Generic;
using GymManagement.Domain.Models;
using GymManagement.Domain.Models.Presistance;
using GymManagement.Domain.Models.Resources;

namespace GymManagement.Domain.Repositories
{
    public interface IMemberRepository
    {
        IEnumerable<MemberResources> Get();
        MemberResources Get(int id);
        void Add(MemberResourceForSave member);
        void Update(MemberResourceForUpdate member);
        void Delete(int id);
        void Delete(Member member);
        void Unsubscribe(int id);
        void AddBill(int memberId, Bill bill);
        Member GetDeatils(int id);
        List<Bill> GetBills(int memberId);
        IList<MemberResourceForUnpaidBill> GetUnPaidBills();
    }
}