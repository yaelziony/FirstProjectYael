using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using
using MyProject.Repositories.Entities;

namespace MyProject.Services.Interfaces
{
    internal interface IClaimService
    {
        List<ClaimDTO> GetAll();

        ClaimDTO GetById(int id);

        Task<ClaimDTO> AddAsync(int id, int roleId, int permissionId, EPolicy policy);

        Task<ClaimDTO> UpdateAsync(ClaimDTO claim);

        Task DeleteAsync(int id);
    }
}
