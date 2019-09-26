using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using TestTennis.Application.DTOs;
using TestTennis.Application.Repositories;
using TestTennis.WebAPI.Controllers;

namespace TestTennis.WebAPI.Test
{
    public class Tests
    {
        private TennisController tennisController;
        private Mock<IReadOnlyTennisRepository> readOnlyTennisRepositoryMock;
        private Mock<IWriteOnlyTennisRepository> writeOnlyTennisRepositoryMock;

        [SetUp]
        public void Setup()
        {
            readOnlyTennisRepositoryMock = new Mock<IReadOnlyTennisRepository>();
            writeOnlyTennisRepositoryMock = new Mock<IWriteOnlyTennisRepository>();
            tennisController = new TennisController(readOnlyTennisRepositoryMock.Object, writeOnlyTennisRepositoryMock.Object);
        }

        [Test]
        public async Task GetAllPlayers()
        {
            readOnlyTennisRepositoryMock.Setup(repo => repo.FindAll()).ReturnsAsync(GetTestPlayers());
            var result = await tennisController.Get();

            Assert.That(result.Value.ToList().Count == GetTestPlayers().Count);
        }

        [Test]
        public async Task GetOnePlayer()
        {
            readOnlyTennisRepositoryMock.Setup(repo => repo.FindById(1)).ReturnsAsync(GetTestPlayers()[0]);
            var result = await tennisController.Get(1);

            Assert.That(result.Value.Id == 1);
            Assert.That(result.Value.Firstname == "first name 1");
            Assert.That(result.Value.Lastname == "last name 1");
        }

        [Test]
        public async Task PlayerNotFound()
        {
            Player player = null;
            readOnlyTennisRepositoryMock.Setup(repo => repo.FindById(1)).ReturnsAsync(player);
            var result = await tennisController.Get(1);

            Assert.That(result.Result is NotFoundResult);
        }

        [Test]
        public async Task DeletPlayer()
        {
            writeOnlyTennisRepositoryMock.Setup(repo => repo.Delete(1)).ReturnsAsync(true);
            var result = await tennisController.Delete(1);

            Assert.That(result is OkResult);
        }

        [Test]
        public async Task DeletPlayerNotFound()
        {
            writeOnlyTennisRepositoryMock.Setup(repo => repo.Delete(1)).ReturnsAsync(false);
            var result = await tennisController.Delete(1);

            Assert.That(result is NotFoundResult);
        }

        private List<Player> GetTestPlayers()
        {
            return new List<Player>
            {
                new Player{
                    Id = 1,
                    Firstname = "first name 1",
                    Lastname = "last name 1"
                },
                new Player {
                    Id = 2,
                    Firstname = "first name 2",
                    Lastname = "last name 2"
                }
            };
        }
    }
}