using Microsoft.AspNetCore.Mvc;
using MyProject.Repositories.Entities;
using MyProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MyProject.WebAPI.Controllers
{
    public class PermisssionController : Controller
    {
        private readonly IPermissionRepository _permissionrepository;
        public PermisssionController(IPermissionRepository permissionrepository)
        {
            _permissionrepository = permissionrepository;
         }
        [HttpGet]
        public List<Permission> GetAll()
        {
            return _permissionrepository.GetAll();
        }
        [HttpGet("{id}")]
        public List<Permission> GetById(int id)
        {
            return _permissionrepository.GetById(id);
        }
        public Permission Post(Permission permission)
        {
            _permissionrepository.Add(permission);
        }
        public 


    }
}
