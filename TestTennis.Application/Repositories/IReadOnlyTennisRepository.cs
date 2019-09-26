using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestTennis.Application.DTOs;

namespace TestTennis.Application.Repositories
{
    public interface IReadOnlyTennisRepository
    {
        Task<Player> FindById(int id);
        Task<List<Player>> FindAll();
    }
}