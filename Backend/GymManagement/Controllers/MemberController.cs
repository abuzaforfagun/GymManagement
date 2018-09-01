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

        public MemberController(IUnitOfWork repo, IMapper mapper)
        {
            _repo = repo;
            this.mapper = mapper;
        }

        [HttpPost]
        public IActionResult Post(MemberResourceForSave item)
        {
            var member = Mapper.Map<Member>(item);
            _repo.MemberRepository.Add(member);
            _repo.Done();
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
            if (item == null)
            {
                return NotFound("Item not found");
            }

            return Ok(item);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, MemberResourceForUpdate member)
        {
            var item = mapper.Map<MemberResourceForUpdate, Member>(member);
            item.Id = id;
            _repo.MemberRepository.Update(item);
            _repo.Done();
            return Ok(item);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repo.MemberRepository.Delete(id);
            _repo.Done();
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(Member member)
        {
            _repo.MemberRepository.Delete(member);
            _repo.Done();
            return Ok();
        }
    }
}