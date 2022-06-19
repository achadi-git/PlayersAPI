using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using PlayersWebAPI.Controllers;
using PlayersWebAPI.Core.Entities;
using PlayersWebAPI.Core.Exceptions;
using PlayersWebAPI.Core.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Tests
{
    public class PlayersControllerTest
    {

        [Test]
        public async Task GetAllPlayers_ShouldReturnAllPlayers()
        {
            //Arrange
            var testPlayers = GetTestPlayers();
            var mockplayersService = new Mock<IPlayerService>();
            mockplayersService.Setup(m => m.GetAllPlayers()).Returns(GetTestPlayers());
            var controller = new PlayersController(mockplayersService.Object);

            //Act
            var result = await controller.GetAllPlayers();

            //Assert
            Assert.AreEqual(testPlayers.Count, result.Count);
        }
        private List<Player> GetTestPlayers()
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "players.json");
            using (var reader = new StreamReader(filePath))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var serializer = JsonSerializer.CreateDefault();
                return serializer.Deserialize<List<Player>>(jsonReader);
            }

        }

        [Test]
        public async Task GetPlayer_ShouldReturnCorrectPlayer()
        {
            //Arrange
            var testPlayer = GetTestPlayers().SingleOrDefault(p => p.id.Equals(52));
            var mockplayersService = new Mock<IPlayerService>();
            mockplayersService.Setup(m => m.GetPlayerById(52)).Returns(testPlayer);
            var controller = new PlayersController(mockplayersService.Object);

            //Act
            var result = await controller.GetPlayer(52);

            //Assert
            Assert.AreEqual(testPlayer.firstname, result.firstname);
        }

        [Test]
        public void GetPlayer_ShouldNotFindPlayer()
        {
            //Arrange
            var mockplayersService = new Mock<IPlayerService>();
            mockplayersService.Setup(m => m.GetPlayerById(It.IsAny<int>()))
                .Throws(new NotFoundException(NotFoundExceptionCode.PlayerNotFound, "player not found"));
            var controller = new PlayersController(mockplayersService.Object);

            //Act + Assert
            Assert.ThrowsAsync<NotFoundException>(() => controller.GetPlayer(1));
        }
    }
}