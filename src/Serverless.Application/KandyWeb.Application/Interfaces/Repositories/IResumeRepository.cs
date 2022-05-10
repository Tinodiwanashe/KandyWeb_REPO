using KandyWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KandyWeb.Application.Interfaces.Repositories
{
    public interface IResumeRepository
    {
        Task<IEnumerable<Resume>> GetMultipleResumesAsync(string queryString);
        Task<Resume> GetResumeAsync(string id);
        Task AddUserProfileAsync(Resume resume);
        Task UpdateResumeAsync(string id, Resume resume);
        Task DeleteResumeAsync(string id);
    }
}
