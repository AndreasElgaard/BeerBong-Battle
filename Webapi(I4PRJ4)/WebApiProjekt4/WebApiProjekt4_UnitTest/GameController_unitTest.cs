using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebApiProjekt4.Controllers;
using WebApiProjekt4.Controllers.Responses;
using WebApiProjekt4.Data;
using WebApiProjekt4.Data.EFCore;
using WebApiProjekt4.Repositories;
using Xunit;

namespace WebApiProjekt4_UnitTest
{
    public class GameController_unitTest
    {
        protected GameController _uut { get; }
        protected Mock<IUnitOfWork> UnitofWorkMock { get; }
        protected Mock<IGameRepository> GameRepositoryMock { get; }
        protected Mock<IMapper> MapperMock { get; }

        public GameController_unitTest()
        {
            GameRepositoryMock = new Mock<IGameRepository>();
            UnitofWorkMock = new Mock<IUnitOfWork>();
            MapperMock = new Mock<IMapper>();
            _uut = new GameController(UnitofWorkMock.Object, MapperMock.Object);
        }

        public class ReadAllAsync : GameController_unitTest
        {
            [Fact]
            public async void Should_Return_OkObjectResult_with_list_of_Games()
            {
                //Arrange
                var expectedResult = new List<Game>()
                {
                    new Game {GameId = 1},
                    new Game {GameId = 2}
                };

                var finalResult = new List<GameResponse>()
                {
                    new GameResponse() {GameId = 1},
                    new GameResponse() {GameId = 2}
                };

                GameRepositoryMock
                    .Setup(r => r.GetAll())
                    .ReturnsAsync(expectedResult).Verifiable();

                UnitofWorkMock
                    .Setup(x => x.Game)
                    .Returns(GameRepositoryMock.Object);

                MapperMock
                    .Setup(m => m.Map<List<GameResponse>>(expectedResult))
                    .Returns(finalResult).Verifiable();

                //Act
                var result = await _uut.GetAll();

                //Assert
                GameRepositoryMock.Verify();
                MapperMock.Verify();

                var okResult = Assert.IsType<OkObjectResult>(result);
                Assert.Same(finalResult, okResult.Value);
            }

            [Fact]
            public async void Should_Return_Badrequest_when_no_Games_Exsist()
            {
                //Arrange
                var expectedResult = new List<Game>()
                {
                    new Game {GameId = 1},
                    new Game {GameId = 2}
                };

                GameRepositoryMock
                    .Setup(x => x.GetAll())
                    .ReturnsAsync((List<Game>)null).Verifiable();

                UnitofWorkMock
                    .Setup(m => m.Game)
                    .Returns(GameRepositoryMock.Object);

                //Act
                var result = await _uut.GetAll();

                //Assert
                GameRepositoryMock.Verify();

                var ErrorResult = Assert.IsType<NotFoundResult>(result);
                Assert.Equal(404, ErrorResult.StatusCode);
            }
        }

        public class ReadOneAsync : GameController_unitTest
        {
            [Fact]
            public async void Should_Return_OkObjectResult_with_one_Game()
            {
                //Arrange
                var expectedResult = new Game() { GameId = 1 };

                var finalResult = new GameResponse() { GameId = 1 };

                GameRepositoryMock
                    .Setup(x => x.Get(expectedResult.GameId))
                    .ReturnsAsync(expectedResult).Verifiable();

                UnitofWorkMock
                    .Setup(m => m.Game)
                    .Returns(GameRepositoryMock.Object);

                MapperMock
                    .Setup(m => m.Map<GameResponse>(expectedResult))
                    .Returns(finalResult);

                //Act
                var result = await _uut.Get(expectedResult.GameId);

                //Assert
                GameRepositoryMock.Verify();

                var okResult = Assert.IsType<OkObjectResult>(result);
                Assert.Same(finalResult, okResult.Value);
            }

            [Fact]
            public async void Should_Return_Badrequest_when_wrong_input_is_given()
            {
                //Arrange
                var expectedResult = new Game() {GameId = 1};

                GameRepositoryMock
                    .Setup(x => x.Get(expectedResult.GameId))
                    .ReturnsAsync((Game)null).Verifiable();

                UnitofWorkMock
                    .Setup(m => m.Game)
                    .Returns(GameRepositoryMock.Object);

                //Act
                var result = await _uut.Get(expectedResult.GameId);

                //Assert
                GameRepositoryMock.Verify();

                var ErrorResult = Assert.IsType<BadRequestObjectResult>(result);
                Assert.Equal(400, ErrorResult.StatusCode);
            }
        }
    }
}
