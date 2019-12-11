using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using we.Controllers;
using WebApiProjekt4.Controllers;
using WebApiProjekt4.Controllers.Responses;
using WebApiProjekt4.Data;
using WebApiProjekt4.Data.EFCore;
using WebApiProjekt4.Repositories;
using Xunit;

namespace WebApiProjekt4_UnitTest
{
    public class PlayerController_unitTest
    {
        protected PlayersController _uut { get; }
        protected Mock<IUnitOfWork> UnitofWorkMock { get; }
        protected Mock<IPlayerRepository> PlayerRepository { get; }
        protected Mock<IMapper> MapperMock { get; }

        public PlayerController_unitTest()
        {
            PlayerRepository = new Mock<IPlayerRepository>();
            UnitofWorkMock = new Mock<IUnitOfWork>();
            MapperMock = new Mock<IMapper>();
            _uut = new PlayersController(UnitofWorkMock.Object, MapperMock.Object);
        }

        public class ReadAllAsync : PlayerController_unitTest
        {
            [Fact]
            public async void Should_Return_OkObjectResult_with_list_of_Games()
            {
                //Arrange
                var expectedResult = new List<Player>()
                {
                    new Player {PlayerId = 1},
                    new Player {PlayerId = 2}
                };

                var finalResult = new List<PlayerResponse>()
                {
                    new PlayerResponse() {PlayerId = 1},
                    new PlayerResponse() {PlayerId = 2}
                };

                PlayerRepository
                    .Setup(r => r.GetAll())
                    .ReturnsAsync(expectedResult).Verifiable();

                UnitofWorkMock
                    .Setup(x => x.Player)
                    .Returns(PlayerRepository.Object);

                MapperMock
                    .Setup(m => m.Map<List<PlayerResponse>>(expectedResult))
                    .Returns(finalResult).Verifiable();

                //Act
                var result = await _uut.GetAll();

                //Assert
                PlayerRepository.Verify();
                MapperMock.Verify();

                var okResult = Assert.IsType<OkObjectResult>(result);
                Assert.Same(finalResult, okResult.Value);
            }
        }

        public class ReadOneAsync : PlayerController_unitTest
        {
            [Fact]
            public async void Should_Return_OkObjectResult_with_one_Game()
            {
                //Arrange
                var expectedResult = new Player() { PlayerId = 1 };

                var finalResult = new PlayerResponse() { PlayerId = 1 };

                PlayerRepository
                    .Setup(x => x.Get(expectedResult.PlayerId))
                    .ReturnsAsync(expectedResult).Verifiable();

                UnitofWorkMock
                    .Setup(m => m.Player)
                    .Returns(PlayerRepository.Object);

                MapperMock
                    .Setup(m => m.Map<PlayerResponse>(expectedResult))
                    .Returns(finalResult);

                //Act
                var result = await _uut.Get(expectedResult.PlayerId);

                //Assert
                PlayerRepository.Verify();

                var okResult = Assert.IsType<OkObjectResult>(result);
                Assert.Same(finalResult, okResult.Value);
            }
        }
    }
}
