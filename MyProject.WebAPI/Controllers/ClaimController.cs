using Microsoft.AspNetCore.Mvc;
using MyProject.Repositories.Entities;
using MyProject.Repositories.Interfaces;
using MyProject.Repository.Repositories;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimController : ControllerBase
    {
        private readonly IClaimRepository _claimrepository;
        public ClaimController(IClaimRepository Claimrepository)
        {
            _claimrepository = Claimrepository;
        }
        [HttpGet]
        public List<ClaimDTO> GetAll()
        {
            return _claimrepository.GetAll();
        }
        [HttpGet("{id}")]
        public ClaimDTO GetById(int id)
        {
            return _claimrepository.GetById(id);
        }
        [HttpPost]
        public async Task<ClaimDTO> Post(ClaimDTO claim)
        {
            return await _claimrepository.AddAsync(claim.Id, claim.PermissionId, claim.RoleId, claim.Policy);

        }
        [HttpPut]
        public async Task<ClaimDTO> Put(ClaimDTO claim)
        {
            return await _claimrepository.UpdateAsync(claim);
        }
        [HttpDelete]
        public async Task Delete(int id)
        {
            _claimrepository.DeleteAsync(id);
        }
    }
}
