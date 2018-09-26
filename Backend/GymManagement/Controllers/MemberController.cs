using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GymManagement.Domain.Models;
using GymManagement.Domain.Models.Presistance;
using GymManagement.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Remotion.Linq.Utilities;

namespace GymManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private IUnitOfWork _repo;
        private readonly IMapper mapper;

        public MemberController(IUnitOfWork repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public IActionResult Post(MemberResourceForSave item)
        {
            _repo.MemberRepository.Add(item);
            var member = _repo.MemberRepository.Get(item.Id);
            return Ok(member);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var list = Ok(_repo.MemberRepository.Get());
            return list;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var item = _repo.MemberRepository.Get(id);
            return Ok(item);
        }

        [HttpGet]
        [Route("{id}/details")]
        public IActionResult GetMemberDetails(int id)
        {
            var item = _repo.MemberRepository.GetDeatils(id);
            return Ok(item);
        }

        [HttpGet]
        [Route("{id}/bill")]
        public IActionResult GetMemberBills(int id)
        {
            var item = _repo.MemberRepository.GetBills(id);
            return Ok(item);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, MemberResourceForUpdate member)
        {
            _repo.MemberRepository.Update(member);
            var item = _repo.MemberRepository.Get(id);
            return Ok(item);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repo.MemberRepository.Delete(id);
            return Ok();
        }
        

        [HttpPost("{id}/Bill")]
        public IActionResult AddBill(int id, [FromBody] Bill bill)
        {
            _repo.MemberRepository.AddBill(id, bill);
            return Ok();
        }
    }

}