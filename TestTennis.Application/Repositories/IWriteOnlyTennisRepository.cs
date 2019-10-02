using System;
using System.Threading.Tasks;
using TestTennis.Application.DTOs;

namespace TestTennis.Application.Repositories
{
    public interface IWriteOnlyTennisRepository
    {
        Task<Player> Delete(int id);
    }
}