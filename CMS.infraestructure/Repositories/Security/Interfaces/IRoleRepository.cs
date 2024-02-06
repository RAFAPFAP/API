using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.infraestructure.Repositories.Security.Interfaces
{
    public interface IRoleRepository
    {
        public Task<IdentityRole<Guid>> Get(Guid Id);
        public Task<ICollection<IdentityRole<Guid>>> GetAll();
        public Task<IdentityRole<Guid>> Add(IdentityRole<Guid> role);
        public Task<IdentityRole<Guid>> Update(IdentityRole<Guid> role);
        public Task<bool> Delete(Guid id);
        Task<IList<string>> GetRolesByUser(string username);

        Task<ICollection<IdentityRole<Guid>>> GetRolesByUserId(Guid userId);

        Task<bool> AsignRoleToUser(Guid userId, Guid roleId);

        Task<bool> RemoveRoleToUser(Guid userId, Guid roleId);
    }
}
