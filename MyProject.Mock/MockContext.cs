﻿using MyProject.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.Repository;
using MyProject.Repositories.Interfaces;

namespace MyProject.Mock
{
    public class MockContext : IContext
    {
        public List<Role> Roles { get; set; }

        public List<ClaimDTO> Claims { get; set; }

        public List<Permission> Permissions { get; set; }
        
        private int saveIndex;

        public async Task<int> SaveChangesAsync()
        {
            return await Task.Run(() => GetSaveIndex());
        }

        private int GetSaveIndex()
        {
            return saveIndex++;
        }

        public MockContext()
        {
            saveIndex = 0;
            Roles.Add(new Role { Id = 1, Name = "admin", Description = "full access" });
            Roles.Add(new Role { Id = 2, Name = "student", Description = "student in seminary" });

            Permissions.Add(new Permission { Id = 1, Name = "ViewAllTests", Description = "" });

            Claims.Add(new ClaimDTO { Id = 1, RoleId = 1, PermissionId = 1, Policy = EPolicy.Allow });
            Claims.Add(new ClaimDTO { Id = 2, RoleId = 2, PermissionId = 1, Policy = EPolicy.Deny });

        }
    }
}
