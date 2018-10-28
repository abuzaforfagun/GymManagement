using AutoMapper;
using GymManagement.Domain.Helpers;
using GymManagement.Domain.Models;
using GymManagement.Domain.Models.Presistance;
using GymManagement.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;

namespace GymManagement.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private IUnitOfWork _repo;
        private readonly IConfiguration configuration;
        private readonly IPhotoUploader photoUploader;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IMapper mapper;
        private readonly string webRoot;
        private readonly string uploadDirectory;
        private readonly string fileUploadDirectoryPath;
        private readonly string imageDirectory;
        public MemberController(IUnitOfWork repo, IConfiguration configuration, IPhotoUploader photoUploader, IHostingEnvironment hostingEnvironment)
        {
            _repo = repo;
            this.configuration = configuration;
            this.photoUploader = photoUploader;
            this.hostingEnvironment = hostingEnvironment;
            webRoot = configuration["WebRoot"].ToString();
            uploadDirectory = configuration["UploadDirectory"].ToString();
            imageDirectory = configuration["ImageDirectory"].ToString();
            fileUploadDirectoryPath = Path.Combine(uploadDirectory);
        }

        [HttpPost, DisableRequestSizeLimit]
        public IActionResult Post([FromForm] MemberResourceForSave item)
        {
            item.ImageUrl = UploadPhoto();
            _repo.MemberRepository.Add(item);
            return Ok(item);
        }

        private string UploadPhoto()
        {
            if (Request.Form.Files.Count > 0)
            {
                IFormFile file = Request.Form.Files[0];
                string relativePath = photoUploader.UploadPhoto(file, fileUploadDirectoryPath, imageDirectory);
                return Path.Combine(webRoot, relativePath);
            }

            return string.Empty;
        }

        [HttpGet]
        public IActionResult Get()
        {
            OkObjectResult list = Ok(_repo.MemberRepository.Get());
            return list;
        }

        [HttpGet]
        [Route("archive")]
        public IActionResult GetArchive()
        {
            return Ok(_repo.MemberRepository.Get(isArchive: true));
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            Domain.Models.Resources.MemberResources item = _repo.MemberRepository.Get(id);
            return Ok(item);
        }

        [HttpGet]
        [Route("{id}/details")]
        public IActionResult GetMemberDetails(int id)
        {
            Member item = _repo.MemberRepository.GetDeatils(id);
            return Ok(item);
        }

        [HttpGet]
        [Route("{id}/bill")]
        public IActionResult GetMemberBills(int id)
        {
            List<Bill> item = _repo.MemberRepository.GetBills(id);
            return Ok(item);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromForm] MemberResourceForUpdate member)
        {
            if (_repo.MemberRepository.Get(id) == null)
            {
                return BadRequest();
            }
            if (Request.Form.Files.Count > 0)
            {
                member.ImageUrl = UploadPhoto();
            }
            _repo.MemberRepository.Update(member);
            Domain.Models.Resources.MemberResources item = _repo.MemberRepository.Get(id);
            return Ok(item);
        }

        [HttpPost("{id}/rejoin")]
        public IActionResult ReJoin(int id)
        {
            if (_repo.MemberRepository.Rejoin(id) == true)
            {
                return Ok();
            }
            return BadRequest();
        }

        private bool removeItem(Bill obj)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repo.MemberRepository.Delete(id);
            return Ok();
        }

        [HttpPost("{id}/unsubscribe")]
        public IActionResult Unsubscribe(int id)
        {
            _repo.MemberRepository.Unsubscribe(id);
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