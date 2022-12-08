using MyProject.Common.DTOs;
using MyProject.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Services.Interfaces
{
    internal interface IPermissionService
    {
        List<PermissionDTO> GetAll();

        PermissionDTO GetById(int id);

        Task<PermissionDTO> AddAsync(int id, string name, string description);

        Task<PermissionDTO> UpdateAsync(Permission permission);

        Task DeleteAsync(int id);
    }
}
