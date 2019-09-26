using System;
using System.Threading.Tasks;

namespace TestTennis.Application.Repositories
{
    public interface IWriteOnlyTennisRepository
    {
        Task<bool> Delete(int id);
    }
}