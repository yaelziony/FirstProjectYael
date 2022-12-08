using MyProject.Repositories.Entities;
using MyProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyProject.Repository.Repositories
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly IContext _context;
        public async Task<Permission> AddAsync(int id, string name, string description)
        {

            _context.Permissions.Add(new Permission { Id = id, Name = name, Description = description });
            await _context.SaveChangesAsync();
            return _context.Permissions.First(p => p.Id == id);
        }

        public async Task DeleteAsync(int id)
        {
            Permission r = _context.Permissions.First(p1 => p1.Id == id);
            _context.Permissions = _context.Permissions.Where(p1 => p1.Id != id).ToList();
            _context.Permissions.Remove(r);
            await _context.SaveChangesAsync();

        }

        public List<Permission> GetAll()
        {
            return _context.Permissions;
        }

        public Permission GetById(int id)
        {
            return _context.Permissions.First(p => p.Id == id);
        }

        public async Task<Permission> UpdateAsync(Permission permission)
        {
            Permission r = _context.Permissions.First(p => p.Id == permission.Id);
            r.Name = permission.Name;
            r.Description = permission.Description;
            await _context.SaveChangesAsync();
            return r;
        }
    }
}
