using MyProject.Repositories.Entities;
using MyProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MyProject.Repository.Repositories
{
    
    public class RoleRepository : IRoleRepository
    {
        private readonly IContext _context;


        public RoleRepository(IContext context)
        {
            _context = context;
        }
      
        public async Task<Role> AddAsync(int id, string name, string description)
        {

            _context.Roles.Add(new Role { Id = id, Name = name, Description = description });
            await _context.SaveChangesAsync();
            return _context.Roles.First(p => p.Id == id);
        }

        public async Task DeleteAsync(int id)
        {
            Role r = GetById( id);
            _context.Roles= _context.Roles.Where(p1 => p1.Id != id).ToList();
            _context.Roles.Remove(r);
            await _context.SaveChangesAsync();
        }
        

        public List<Role> GetAll()
        {
            return _context.Roles;
        }

        public Role GetById(int id)
        {
            return _context.Roles.First(p => p.Id == id);
        }

        public async Task<Role> UpdateAsync(Role role)
        {
            Role r = GetById(role.Id);
            r.Name= role.Name;
            r.Description = role.Description;
            await _context.SaveChangesAsync();
            return r;
        }

        
    }
}
