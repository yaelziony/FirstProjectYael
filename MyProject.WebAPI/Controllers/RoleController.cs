using Microsoft.AspNetCore.Mvc;
using MyProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyProject.Repositories.Entities;
using Microsoft.AspNetCore.Http;
namespace MyProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository _rolerepository;
        public RoleController(IRoleRepository rolerepository)
        {
            _rolerepository = rolerepository;
        }
        [HttpGet]
        public List<Role> GetAll()
        {
            return _rolerepository.GetAll();
        }
        [HttpGet("{id}")]
        public Role GetById(int id)
        {
            return _rolerepository.GetById(id);
        }
        [HttpPost]
        public async Task<Role> Post(Role role)
        {
            return await _rolerepository.AddAsync(role.Id, role.Name, role.Description);
        }
        [HttpPut]
        public async Task<Role> Put(Role role)
        {
            return await _rolerepository.UpdateAsync(role);
        }
        [HttpDelete]
        public async Task Delete(int id)
        {
            await _rolerepository.DeleteAsync(id);
        }
    }
}
