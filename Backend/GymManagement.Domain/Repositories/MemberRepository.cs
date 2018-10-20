using GenericServices;
using GymManagement.Domain.Models;
using GymManagement.Domain.Models.Enums;
using GymManagement.Domain.Models.Presistance;
using GymManagement.Domain.Models.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GymManagement.Domain.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly ICrudServices service;

        public MemberRepository([FromServices]ICrudServices service)
        {
            this.service = service;
        }


        public IEnumerable<MemberResources> Get()
        {
            return service.ReadManyNoTracked<MemberResources>().Include(m => m.Bills)
                .Where(m => m.Status == MemberStatus.Registered);
        }

        public MemberResources Get(int id)
        {
            return service.ReadSingle<MemberResources>(id);

        }

        public Member GetDeatils(int id)
        {
            return service.ReadManyNoTracked<Member>().Include(m => m.Bills)
                .SingleOrDefault(m => m.Id == id);
        }
        public void Add(MemberResourceForSave member)
        {
            service.CreateAndSave(member);
        }

        public void Update(MemberResourceForUpdate member)
        {
            service.UpdateAndSave(member);
        }

        public void Delete(int id)
        {
            service.DeleteAndSave<Member>(id);
        }

        public void Delete(Member member)
        {
            service.DeleteAndSave<Member>(member.Id);
        }

        public void Unsubscribe(int id)
        {
            Member member = service.ReadSingle<Member>(m => m.Id == id);
            member.Status = MemberStatus.Resigned;
            service.UpdateAndSave(member);
        }

        public void AddBill(int memberId, Bill bill)
        {
            bill.UpdateDate = DateTime.Now;
            MemberResources member = Get(memberId);
            member.Bills.Add(bill);
            service.UpdateAndSave(member);
        }

        public List<Bill> GetBills(int memberId)
        {
            return GetDeatils(memberId).Bills;
        }

        public IList<MemberResourceForUnpaidBill> GetUnPaidBills()
        {
            var members = service.ReadManyNoTracked<Member>().Where(m => m.Status == MemberStatus.Registered).Include(m => m.Bills);
            List<MemberResourceForUnpaidBill> unpaidBills = new List<MemberResourceForUnpaidBill>();
            foreach (Member member in members)
            {
                MemberResourceForUnpaidBill _bills = checkUnpaidBill(member);
                if (_bills.UnpaidBills.Count > 0)
                {
                    unpaidBills.Add(_bills);
                }
            }

            return unpaidBills;
        }

        private MemberResourceForUnpaidBill checkUnpaidBill(Member member)
        {
            MemberResourceForUnpaidBill _memberResourceForUnpaidBill = createMemberResourceForUnpaidBill(member);

            for (DateTime date = member.JoiningDate; date < DateTime.Now; date = date.AddMonths(1))
            {
                List<Bill> _unpaid = member.Bills.Where(b => b.Date.Month == date.Month).ToList();

                if (_unpaid.Count == 0)
                {
                    _memberResourceForUnpaidBill.UnpaidBills.Add(date);
                }
            }

            return _memberResourceForUnpaidBill;
        }


        private MemberResourceForUnpaidBill createMemberResourceForUnpaidBill(Member member)
        {
            MemberResourceForUnpaidBill _bill = new MemberResourceForUnpaidBill();
            _bill.Name = member.Name;
            _bill.Address = member.Address;
            _bill.Id = member.Id;
            _bill.Mobile = member.Mobile;
            _bill.JoiningDate = member.JoiningDate;
            _bill.ImageUrl = member.ImageUrl;
            _bill.LastPayment = member.Bills.OrderByDescending(b => b.Date).Take(1).FirstOrDefault();
            
            return _bill;
        }
    }
}
