using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AutoMapper;
using GymManagement.Domain.Helpers;
using GymManagement.Domain.Models;
using GymManagement.Domain.Models.Presistance;
using GymManagement.Domain.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Remotion.Linq.Utilities;

namespace GymManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private IUnitOfWork _repo;
        private readonly IConfiguration configuration;
        private readonly IPhotoUploader photoUploader;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IMapper mapper;
        private readonly string webRoot;
        private readonly string imageDirectory;
        private readonly string fileUploadDirectoryPath;
        public MemberController(IUnitOfWork repo, IConfiguration configuration, IPhotoUploader photoUploader, IHostingEnvironment hostingEnvironment)
        {
            _repo = repo;
            this.configuration = configuration;
            this.photoUploader = photoUploader;
            this.hostingEnvironment = hostingEnvironment;
            webRoot = configuration["WebRoot"].ToString();
            imageDirectory = configuration["ImageDirectory"].ToString();
            fileUploadDirectoryPath = Path.Combine(imageDirectory);
        }

        [HttpPost]
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
                var file = Request.Form.Files[0];
                var relativePath = photoUploader.UploadPhoto(file, fileUploadDirectoryPath);
                return Path.Combine(webRoot, relativePath);
            }

            return string.Empty;
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