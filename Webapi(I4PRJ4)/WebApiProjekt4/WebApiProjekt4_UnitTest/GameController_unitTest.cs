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
using WebApiProjekt4.Data.Dto;
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
                    .ReturnsAsync((List<Game>) null).Verifiable();

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
                var expectedResult = new Game() {GameId = 1};

                var finalResult = new GameResponse() {GameId = 1};

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
                MapperMock.Verify();

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
                    .ReturnsAsync((Game) null).Verifiable();

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

        public class CreateAsync : GameController_unitTest
        {
            [Fact]
            public async void Should_return_CreatedAtActionResult_with_created_Game()
            {
                //Arrange
                //var expectedGame = new Game { GameId = 1 };

                UnitofWorkMock
                    .Setup(m => m.Game)
                    .Returns(GameRepositoryMock.Object);

                //Act
                var result = await _uut.Post();

                //Assert
                GameRepositoryMock.VerifyAll();
            }
        }

        public class AddPlayerToGameAsync : GameController_unitTest
        {
            [Fact]
            public async void Should_Add_user_to_chosen_Game()
            {
                //Arrange
                var expectedgameId = 1;
                var expectedplayer1Id = 1;
                var expectedplayer2Id = 2;


                var expectedgame = new Game
                {
                    GameId = expectedgameId,
                    Players = new List<Player>
                    {
                        new Player
                        {
                            PlayerId = expectedplayer1Id
                        },
                        new Player
                        {
                            PlayerId = expectedplayer2Id
                        }
                    }
                };

                var expectedgameresponse = new GameResponse
                {
                    GameId = expectedgameId,
                    Players = new List<PlayerResponse>
                    {
                        new PlayerResponse
                        {
                            PlayerId = expectedplayer1Id
                        },
                        new PlayerResponse
                        {
                            PlayerId = expectedplayer2Id
                        }
                    }
                };

                GameRepositoryMock
                    .Setup(x => x.AddUserToGame(expectedgameId, expectedplayer1Id, expectedplayer2Id))
                    .ReturnsAsync(expectedgame);

                UnitofWorkMock
                    .Setup(m => m.Game)
                    .Returns(GameRepositoryMock.Object);

                MapperMock
                    .Setup(s => s.Map<GameResponse>(expectedgame))
                    .Returns(expectedgameresponse);

                //Act
                var result = await _uut.AddUsersToGame(expectedgameId, expectedplayer1Id, expectedplayer2Id);

                //Assert
                GameRepositoryMock.Verify();
                MapperMock.Verify();

                var response = Assert.IsType<OkObjectResult>(result);
                Assert.Same(expectedgameresponse, response.Value);
            }

            [Fact]
            public async void AddUserToGame_returns_badrequest()
            {
                //Arrange
                var expectedgameId = 1;
                var expectedplayer1Id = 1;
                var expectedplayer2Id = 2;


                var expectedgame = new Game
                {
                    GameId = expectedgameId,
                    Players = new List<Player>
                    {
                        new Player
                        {
                            PlayerId = expectedplayer1Id
                        },
                        new Player
                        {
                            PlayerId = expectedplayer2Id
                        }
                    }
                };

                GameRepositoryMock
                    .Setup(x => x.AddUserToGame(expectedgameId, expectedplayer1Id, expectedplayer2Id))
                    .ReturnsAsync((Game) null);

                UnitofWorkMock
                    .Setup(m => m.Game)
                    .Returns(GameRepositoryMock.Object);

                //Act
                var result = await _uut.AddUsersToGame(expectedgameId, expectedplayer1Id, expectedplayer2Id);

                //Assert
                GameRepositoryMock.Verify();

                var ErrorResult = Assert.IsType<BadRequestObjectResult>(result);
                Assert.Equal(400, ErrorResult.StatusCode);
            }
        }

        public class GetResult : GameController_unitTest
        {
            [Fact]
            public async void Should_Get_Game_Result()
            {
                //Arrange
                var expectedGame = new Game
                {
                    GameId = 1
                };

                var expectedWinnerResult = new List<GameWinnerResult>
                {
                    new GameWinnerResult
                    {
                        Playerid = 1,
                        Time = 10
                    },
                    new GameWinnerResult
                    {
                        Playerid = 2,
                        Time = 1
                    }
                };


                GameRepositoryMock
                    .Setup(g => g.Winner(expectedGame.GameId))
                    .ReturnsAsync(expectedWinnerResult);

                UnitofWorkMock
                    .Setup(u => u.Game)
                    .Returns(GameRepositoryMock.Object);

                //Act
                var result = await _uut.GetResult(expectedGame.GameId);

                //Assert
                GameRepositoryMock.Verify();

                var response = Assert.IsType<OkObjectResult>(result);
                Assert.Same(expectedWinnerResult, response.Value);
            }

            [Fact]
            public async void Should_return_badrequest_on_getwinnerresult()
            {
                //Arrange
                var expectedGame = new Game
                {
                    GameId = 1
                };

                GameRepositoryMock
                    .Setup(g => g.Winner(expectedGame.GameId))
                    .ReturnsAsync((List<GameWinnerResult>) null);

                UnitofWorkMock
                    .Setup(u => u.Game)
                    .Returns(GameRepositoryMock.Object);

                //Act
                var result = await _uut.Get(expectedGame.GameId);

                //Assert
                GameRepositoryMock.Verify();

                var ErrorResult = Assert.IsType<BadRequestObjectResult>(result);
                Assert.Equal(400, ErrorResult.StatusCode);
            }
        }
         public class RemoveOneAsync : GameController_unitTest
         {
             [Fact]
             public void Remove_Given_game_by_id()
             {
                 //Arrange
                 var expectedGame = new Game
                 {
                     GameId = 1
                 };

                 GameRepositoryMock
                     .Setup(g => g.Remove(expectedGame.GameId));

                 UnitofWorkMock
                     .Setup(u => u.Game)
                     .Returns(GameRepositoryMock.Object);

                 //Act
                 var result = _uut.Delete(expectedGame.GameId);

                 //Assert
                 GameRepositoryMock.Verify();

                 var response = Assert.IsType<OkResult>(result);
                 Assert.Equal(200, response.StatusCode);
            }

             [Fact]
             public void Remove_Given_game_by_id_fails()
             {
                 //Arrange
                 var expectedGame = new Game
                 {
                     GameId = 1
                 };

                 GameRepositoryMock
                     .Setup(g => g.Remove(expectedGame.GameId)).Throws(new Exception());

                 UnitofWorkMock
                     .Setup(u => u.Game)
                     .Returns(GameRepositoryMock.Object);

                 //Act
                 var result = _uut.Delete(expectedGame.GameId);

                 //Assert
                 GameRepositoryMock.Verify();

                 var response = Assert.IsType<BadRequestObjectResult>(result);
                 Assert.Equal(400, response.StatusCode);
             }
        }
    }
}
