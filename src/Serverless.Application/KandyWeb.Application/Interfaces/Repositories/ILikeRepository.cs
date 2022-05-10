using KandyWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KandyWeb.Application.Interfaces.Repositories
{
    public interface ILikeRepository
    {
        Task<IEnumerable<Like>> GetMultiplelikesAsync(string queryString);
        Task<Like> GetlikeAsync(string id);
        Task AddlikeAsync(Like like);
        Task UpdatelikeAsync(string id, Like like);
        Task DeletelikeAsync(string id);
    }
}
