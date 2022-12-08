using MyProject.Repository;
using MyProject.Repository.Repositories;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.Repositories.Interfaces;
using MyProject.Repositories.Entities;

namespace MyProject.Repository.Repositories
{
    public class ClaimRepository : IClaimRepository
    {
        private readonly IContext _context;
        public ClaimRepository(IContext context)
        {
            _context = context;
        }
        public async Task <ClaimDTO> AddAsync(int id, int roleId, int permissionId, EPolicy policy)
        {
            _context.Claims.Add(new ClaimDTO() {Id=id , RoleId = roleId, PermissionId= permissionId, Policy=policy });
            await _context.SaveChangesAsync();
            return GetById(id);

        }

        public async Task DeleteAsync(int id)
        {
            ClaimDTO claim = GetById(id);
            
            _context.Claims.Remove(claim);
            await _context.SaveChangesAsync();
            
        }

        public List<ClaimDTO> GetAll()
        {
            return _context.Claims;
        }

        public ClaimDTO GetById(int id)
        {
            return _context.Claims.First(x=>x.Id==id);
        }

        public async Task<ClaimDTO> UpdateAsync(ClaimDTO claim)
        {
            _context.Claims[_context.Claims.IndexOf(_context.Claims.First( x => x.Id == claim.Id))] =claim;
            await _context.SaveChangesAsync();
            return claim;
        }
    }
}
