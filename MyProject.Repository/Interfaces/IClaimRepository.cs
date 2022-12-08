using MyProject.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyProject.Repositories.Interfaces
{
    public interface IClaimRepository

    {
        List<ClaimDTO> GetAll();

        ClaimDTO GetById(int id);

        Task<ClaimDTO> AddAsync(int id, int roleId, int permissionId, EPolicy policy);

        Task<ClaimDTO> UpdateAsync(ClaimDTO claim);

        Task DeleteAsync(int id);

    }
}
