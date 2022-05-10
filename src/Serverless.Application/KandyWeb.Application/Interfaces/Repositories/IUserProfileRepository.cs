using KandyWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KandyWeb.Application.Interfaces.Repositories
{
    public interface IUserProfileRepository
    {
        Task<IEnumerable<UserProfile>> GetMultipleUserProfilesAsync(string queryString);
        Task<UserProfile> GetUserProfileAsync(string id);
        Task AddUserProfileAsync(UserProfile userProfile);
        Task UpdateUserProfileAsync(string id, UserProfile userProfile);
        Task DeleteUserProfileAsync(string id);
    }
}
