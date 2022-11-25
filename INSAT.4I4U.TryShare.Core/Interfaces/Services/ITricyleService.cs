using INSAT._4I4U.TryShare.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSAT._4I4U.TryShare.Core.Interfaces.Services
{
    public interface ITricyleService
    {
        Task<List<Tricycle>> GetAllAsync();
        Task<Tricycle?> GetByIdAsync(int id);
        Task CreateAsync(Tricycle tricycle);
        Task UpdateAsync(Tricycle tricycle);
        Task DeleteAsync(Tricycle tricycle);
    }
}
