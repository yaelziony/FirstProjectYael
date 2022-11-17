using MyProject.Repositories.Entities;
using MyProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tray.first.Interface;

namespace MyProject.Repository.Repositories
{
    public class ClaimRepository : IClaimReposirory
    {
        private readonly IContext _context;
        public ClaimRepository(IContext context)
        {
            _context = context;
        }
        public Claim Add(int id, int roleId, int permissionId, EPolicy policy)
        {
            

            
            _context.Claims.Add(new Claim() {Id=id , RoleId = roleId, PermissionId= permissionId, Policy=policy });
            return GetById(id);

        }

        public Claim Delete(int id)
        {
            Claim claim = GetById(id);
            _context.Claims.Remove(claim);
            return claim;
        }

        public List<Claim> GetAll()
        {
            return _context.Claims;
        }

        public Claim GetById(int id)
        {
            return _context.Claims.First(x=>x.Id==id);
        }

        public Claim Update(Claim claim)
        {
            _context.Claims[_context.Claims.IndexOf(_context.Claims.First( x => x.Id == claim.Id))] =claim;
            return claim;
        }
    }
}
