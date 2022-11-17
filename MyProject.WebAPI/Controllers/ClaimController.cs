using Microsoft.AspNetCore.Mvc;
using MyProject.Repositories.Entities;
using MyProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.WebAPI.Controllers
{
    public class ClaimController : Controller
    {
        private readonly IClaimRepository _claimrepository;
        public ClaimController(IClaimRepository Claimrepository)
        {
            _claimrepository = Claimrepository;
        }
        [HttpGet]
        public List<Claim> GetAll()
        {
            return _claimrepository.GetAll();
        }
        [HttpGet("{id}")]
        public List<Claim> GetById(int id)
        {
            return _claimrepository.GetById(id);
        }
        public Claim Post(id ,roleId,permissionId,policy )
        {
            return _claimrepository.Add(id,roleId, permissionId, policy);
        }
        public Claim Put(Claim claim)
        {
            return _claimrepository.Update(claim);
        }
        public Claim Delete(int id)
        {
            return _claimrepository.Delete(id);
        }
    }
}
