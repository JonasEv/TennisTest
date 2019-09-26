using System.IO;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using TestTennis.Application.Repositories;
using TestTennis.Infrastructure.JsonDataAccess.Repositories;

namespace TestTennis.Infrastructure.Test
{
    public class JsonDataAccessRepositoryTest
    {
        private string path;
        private IReadOnlyTennisRepository readOnlyTennisRepository;
        private IWriteOnlyTennisRepository writeOnlyTennisRepository;

        [SetUp]
        public void Setup()
        {
            path = Path.GetDirectoryName(GetType().Assembly.Location) + "/Mock/HeadToHeadMock.json";
            var repository = new TennisRepository(path);
            readOnlyTennisRepository = repository;
            writeOnlyTennisRepository = repository;
        }

        [Test]
        public async Task GetAllPlayers()
        {
            var players = await readOnlyTennisRepository.FindAll();
            Assert.That(players.Count == 5);
        }

        [Test]
        public async Task GetDjokovicPlayer()
        {
            var player = await readOnlyTennisRepository.FindById(52);
            Assert.That(player.Id == 52);
            Assert.That(player.Lastname == "Djokovic");
        }

        [Test]
        public async Task NotFoundPlayer()
        {
            var player = await readOnlyTennisRepository.FindById(1);
            Assert.That(player == null);
        }

        [Test]
        public async Task DeletePlayer()
        {
            var result = await writeOnlyTennisRepository.Delete(52);
            Assert.That(result == true);
            Assert.That((await readOnlyTennisRepository.FindAll()).FirstOrDefault(p => p.Id == 52) == null);
        }

        [Test]
        public async Task DeletePlayerNotFound()
        {
            var result = await writeOnlyTennisRepository.Delete(1);
            Assert.That(result == false);
        }
    }
}
