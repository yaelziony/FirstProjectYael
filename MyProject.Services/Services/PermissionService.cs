using MyProject.Common.DTOs;
using MyProject.Repositories.Entities;
using MyProject.Repositories.Interfaces;
using MyProject.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Services.Services
{
    public class PermissionService:IPermissionService
    {
        private readonly IPermissionRepository _permissionRepository;
        private readonly IMapper _mapper;
        public PermissionService(IPermissionRepository permissionRepository, IMapper mapper)
        {
            _permissionRepository = permissionRepository;
            _mapper = mapper;
        }
        public async Task<PermissionDTO> AddAsync(int id, string name, string description)
        {
            return _mapper.Map<PermissionDTO>(await _permissionRepository.AddAsync(id,name,description));

        }

        public async Task DeleteAsync(int id)
        {
            await _permissionRepository.DeleteAsync(id);

        }

        public List<PermissionDTO> GetAll()
        {
            return _mapper.Map<List<PermissionDTO>>(_permissionRepository.GetAll());
        }

        public PermissionDTO GetById(int id)
        {
            return _permissionRepository.GetById(id);
        }

        public async Task<PermissionDTO> UpdateAsync(PermissionDTO permission)
        {
        
            return await _permissionRepository.UpdateAsync(permission);
        }

       
    }
}
