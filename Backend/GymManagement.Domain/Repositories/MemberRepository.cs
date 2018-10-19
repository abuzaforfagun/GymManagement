using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using GenericServices;
using GymManagement.Domain.Models;
using GymManagement.Domain.Models.Enums;
using GymManagement.Domain.Models.Presistance;
using GymManagement.Domain.Models.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var member = service.ReadSingle<Member>(m => m.Id == id);
            member.Status = MemberStatus.Resigned;
            service.UpdateAndSave(member);
        }

        public void AddBill(int memberId, Bill bill)
        {
            bill.UpdateDate = DateTime.Now;
            var member = Get(memberId);
            member.Bills.Add(bill);
            service.UpdateAndSave(member);
        }

        public List<Bill> GetBills(int memberId)
        {
            return GetDeatils(memberId).Bills;
        }
    }
}
