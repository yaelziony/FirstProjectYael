using Microsoft.AspNetCore.Mvc;
using MyProject.Repositories.Entities;
using MyProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MyProject.Common.DTOs;
//change

namespace MyProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermisssionController : ControllerBase
    {
        private readonly IPermissionRepository _permissionrepository;
        public PermisssionController(IPermissionRepository permissionrepository)
        {
            _permissionrepository = permissionrepository;
        }
        [HttpGet]
        public List<PermissionDTO> GetAll()
        {
            return _permissionrepository.GetAll();
        }
        [HttpGet("{id}")]
        public Permission GetById(int id)
        {
            return _permissionrepository.GetById(id);
        }
        [HttpPost]
        public async Task<PermissionDTO> Post(Permission permission)
        {
            return await _permissionrepository.AddAsync(permission.Id, permission.Name, permission.Description);
        }
        [HttpPut]
        public async Task<Permission> Put(Permission permission)
        {
            return await _permissionrepository.UpdateAsync(permission);
        }
        [HttpDelete]
        public async Task Delete(int id)
        {
            await _permissionrepository.DeleteAsync(id);
        }


    }
}
