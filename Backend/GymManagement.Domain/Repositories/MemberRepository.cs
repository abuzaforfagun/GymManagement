using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using GenericServices;
using GymManagement.Domain.Models;
using GymManagement.Domain.Models.Presistance;
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


        public IEnumerable<Member> Get()
        {
            return service.ReadManyNoTracked<Member>();
        }

        public Member Get(int id)
        {
            return service.ReadSingle<Member>(id);

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

        public void AddBill(int memberId, Bill bill)
        {
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
