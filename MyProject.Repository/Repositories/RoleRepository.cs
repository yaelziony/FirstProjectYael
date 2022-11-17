﻿using MyProject.Repositories.Entities;
using MyProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using tray.first.Interface;

namespace tray.first.Repositories
{
    
    public class RoleRepository : IRoleRepository
    {
        private readonly IContext _context;


        public RoleRepository(IContext context)
        {
            _context = context;
        }
      
        public Role Add(int id, string name, string description)
        {

            _context.Roles.Add(new Role { Id = id, Name = name, Description = description });
             return _context.Roles.First(p => p.Id == id);
        }

        public Role Delete(int id)
        {
            Role r = GetById( id);
            //_context.Roles= _context.Roles.Where(p1 => p1.Id != id).ToList();
            _context.Roles.Remove(r);
            return r;
        }
        

        public List<Role> GetAll()
        {
            return _context.Roles;
        }

        public Role GetById(int id)
        {
            return _context.Roles.First(p => p.Id == id);
        }

        public Role Update(Role role)
        {
        Role r = GetById(role.Id);
        r.Name= role.Name;
        r.Description = role.Description;
        return r;
        }

        
    }
}
