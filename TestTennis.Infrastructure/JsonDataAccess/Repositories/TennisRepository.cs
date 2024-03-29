﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TestTennis.Application.DTOs;
using TestTennis.Application.Repositories;

namespace TestTennis.Infrastructure.JsonDataAccess.Repositories
{
    public class TennisRepository : IReadOnlyTennisRepository, IWriteOnlyTennisRepository
    {
        private string _path;
        private bool isModfified;

        public TennisRepository(string path)
        {
            _path = path;
        }

        public async Task<List<Player>> FindAll()
        {
            return (await LoadPlayers()).ToList();
        }

        public async Task<Player> FindById(int id)
        {
            return (await LoadPlayers()).FirstOrDefault(p => p.Id == id);
        }

        public async Task<bool> Delete(int id)
        {
            var players = (await LoadPlayers()).ToList();
            if (!players.Remove(players.Where(p => p.Id == id).FirstOrDefault()))
                return false;

            if (!isModfified)
            {
                _path = _path.Split('.')[0] + "_modified.json";
                isModfified = true;
            }
            using (StreamWriter outputFile = new StreamWriter(_path))
            {
                await outputFile.WriteAsync(JsonConvert.SerializeObject(new Players { PlayerList = players }));
            }
            return true;
        }

        private async Task<IEnumerable<Player>> LoadPlayers()
        {
            using (var reader = File.OpenText(_path))
            {
                var json = await reader.ReadToEndAsync();
                return JsonConvert.DeserializeObject<Players>(json).PlayerList;
            }
        }
    }
}
