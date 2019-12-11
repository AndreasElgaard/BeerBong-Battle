using System;
using System.Collections.Generic;

using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using we.Controllers;
using WebApiProjekt4.Controllers;
using WebApiProjekt4.Controllers.Responses;
using WebApiProjekt4.Data;
using WebApiProjekt4.Data.Dto;
using WebApiProjekt4.Data.EFCore;
using WebApiProjekt4.Repositories;
using Xunit;

namespace WebApiProjekt4_UnitTest
{
    public class LeaderBoardController_unitTest
    {
        protected LeaderBoardController _uut { get; }
        protected Mock<IUnitOfWork> UnitofWorkMock { get; }
        protected Mock<ILeaderBoardRepository> LeaderBoardRepository { get; }
        protected Mock<IMapper> MapperMock { get; }

        public LeaderBoardController_unitTest()
        {
            LeaderBoardRepository = new Mock<ILeaderBoardRepository>();
            UnitofWorkMock = new Mock<IUnitOfWork>();
            MapperMock = new Mock<IMapper>();
            _uut = new LeaderBoardController(UnitofWorkMock.Object, MapperMock.Object);
        }

        public class ReadAllAsync : LeaderBoardController_unitTest
        {
            [Fact]
            public async void Should_Return_OkObjectResult_with_list_of_leaderboards()
            {
                //Arrange
                var expectedResult = new List<LeaderBoard>()
                {
                    new LeaderBoard {LeaderBoardId = 1},
                    new LeaderBoard {LeaderBoardId = 2}
                };

                var finalResult = new List<LeaderBoardResponse>()
                {
                    new LeaderBoardResponse() {LeaderBoardId = 1},
                    new LeaderBoardResponse() {LeaderBoardId = 2}
                };

                LeaderBoardRepository
                    .Setup(r => r.GetAll())
                    .ReturnsAsync(expectedResult).Verifiable();

                UnitofWorkMock
                    .Setup(x => x.LeaderBoard)
                    .Returns(LeaderBoardRepository.Object);

                MapperMock
                    .Setup(m => m.Map<List<LeaderBoardResponse>>(expectedResult))
                    .Returns(finalResult).Verifiable();

                //Act
                var result = await _uut.GetAll();

                //Assert
                LeaderBoardRepository.Verify();
                MapperMock.Verify();

                var okResult = Assert.IsType<OkObjectResult>(result);
                Assert.Same(finalResult, okResult.Value);
            }

            [Fact]
            public async void Should_Return_Badrequest_when_no_leaderboards_Exsist()
            {
                //Arrange
                var expectedResult = new List<LeaderBoard>()
                {
                    new LeaderBoard {LeaderBoardId = 1},
                    new LeaderBoard {LeaderBoardId = 2}
                };

                LeaderBoardRepository
                    .Setup(x => x.GetAll())
                    .ReturnsAsync((List<LeaderBoard>)null).Verifiable();

                UnitofWorkMock
                    .Setup(m => m.LeaderBoard)
                    .Returns(LeaderBoardRepository.Object);

                //Act
                var result = await _uut.GetAll();

                //Assert
                LeaderBoardRepository.Verify();

                var ErrorResult = Assert.IsType<NotFoundResult>(result);
                Assert.Equal(404, ErrorResult.StatusCode);
            }
        }

        public class ReadOneAsync : LeaderBoardController_unitTest
        {
            [Fact]
            public async void Should_Return_OkObjectResult_with_one_leaderboard()
            {
                //Arrange
                var expectedResult = new LeaderBoard() { LeaderBoardId = 1 };

                var finalResult = new LeaderBoardResponse() { LeaderBoardId = 1 };

                LeaderBoardRepository
                    .Setup(x => x.Get(expectedResult.LeaderBoardId))
                    .ReturnsAsync(expectedResult).Verifiable();

                UnitofWorkMock
                    .Setup(m => m.LeaderBoard)
                    .Returns(LeaderBoardRepository.Object);

                MapperMock
                    .Setup(m => m.Map<LeaderBoardResponse>(expectedResult))
                    .Returns(finalResult);

                //Act
                var result = await _uut.Get(expectedResult.LeaderBoardId);

                //Assert
                LeaderBoardRepository.Verify();

                var okResult = Assert.IsType<OkObjectResult>(result);
                Assert.Same(finalResult, okResult.Value);
            }

            [Fact]
            public async void Should_Return_Badrequest_when_wrong_input_is_given()
            {
                //Arrange
                var expectedResult = new LeaderBoard() { LeaderBoardId = 1 };

                LeaderBoardRepository
                    .Setup(x => x.Get(expectedResult.LeaderBoardId))
                    .ReturnsAsync((LeaderBoard)null).Verifiable();

                UnitofWorkMock
                    .Setup(m => m.LeaderBoard)
                    .Returns(LeaderBoardRepository.Object);

                //Act
                var result = await _uut.Get(expectedResult.LeaderBoardId);

                //Assert
                LeaderBoardRepository.Verify();

                var ErrorResult = Assert.IsType<BadRequestObjectResult>(result);
                Assert.Equal(400, ErrorResult.StatusCode);
            }
        }

        public class CreateAsync : LeaderBoardController_unitTest
        {
            [Fact]
            public async void Should_return_CreatedAtActionResult_with_created_Leaderboard()
            {
                //Arrange
                var expectedResult = new LeaderBoard { LeaderBoardId = 1 };

                LeaderBoardRepository
                    .Setup(l => l.Add(expectedResult)).Verifiable();
                    

                UnitofWorkMock
                    .Setup(m => m.LeaderBoard)
                    .Returns(LeaderBoardRepository.Object);

                //Act
                var result = await _uut.Post(expectedResult);
                //Assert
                LeaderBoardRepository.VerifyAll();

                var response = Assert.IsType<OkObjectResult>(result);
                Assert.Same(expectedResult,response.Value);
            }

            [Fact]
            public async void Should_return_Throw_and_return_BadRequest_with_created_Leaderboard()
            {
                //Arrange
                var expectedResult = new LeaderBoard { LeaderBoardId = 1 };

                LeaderBoardRepository
                    .Setup(l => l.Add(expectedResult)).Throws(new Exception());


                UnitofWorkMock
                    .Setup(m => m.LeaderBoard)
                    .Returns(LeaderBoardRepository.Object);

                //Act
                var result = await _uut.Post(expectedResult);
                //Assert
                LeaderBoardRepository.VerifyAll();

                var ErrorResult = Assert.IsType<BadRequestObjectResult>(result);
                Assert.Equal(400, ErrorResult.StatusCode);
            }
        }

        public class RemoveOneAsync : LeaderBoardController_unitTest
        {
            [Fact]
            public void Remove_Given_game_by_id()
            {
                //Arrange
                var expectedLeaderBoard = new LeaderBoard
                {
                    LeaderBoardId = 1
                };

                LeaderBoardRepository
                    .Setup(g => g.Remove(expectedLeaderBoard.LeaderBoardId));

                UnitofWorkMock
                    .Setup(u => u.LeaderBoard)
                    .Returns(LeaderBoardRepository.Object);

                //Act
                var result = _uut.Delete(expectedLeaderBoard.LeaderBoardId);

                //Assert
                LeaderBoardRepository.Verify();

                var response = Assert.IsType<OkResult>(result);
                Assert.Equal(200, response.StatusCode);
            }

            [Fact]
            public void Remove_Given_game_by_id_fails()
            {
                //Arrange
                var expectedLeaderBoard = new LeaderBoard
                {
                    LeaderBoardId = 1
                };

                LeaderBoardRepository
                    .Setup(g => g.Remove(expectedLeaderBoard.LeaderBoardId)).Throws(new Exception());

                UnitofWorkMock
                    .Setup(u => u.LeaderBoard)
                    .Returns(LeaderBoardRepository.Object);

                //Act
                var result = _uut.Delete(expectedLeaderBoard.LeaderBoardId);

                //Assert
                LeaderBoardRepository.Verify();

                var response = Assert.IsType<BadRequestObjectResult>(result);
                Assert.Equal(400, response.StatusCode);
            }
        }

        public class GetToptimes : LeaderBoardController_unitTest
        {
            [Fact]
            public async void Get_Top_Times_Returns_OkObjectResult()
            {
                //Arrange

                var expectedResult = new List<TopTimes>
                {
                    new TopTimes
                    {
                        UserName = "Mads",
                        Time = 10
                    },
                    new TopTimes
                    {
                        UserName = "Mathias",
                        Time = 100
                    }
                };

                LeaderBoardRepository
                    .Setup(l => l.GetTopTimes())
                    .ReturnsAsync(expectedResult);

                UnitofWorkMock
                    .Setup(u => u.LeaderBoard)
                    .Returns(LeaderBoardRepository.Object);

                //Act
                var result = await _uut.GetTopTimes();

                var response = Assert.IsType<OkObjectResult>(result);
                Assert.Same(expectedResult, response.Value);
            }

            [Fact]
            public async void Get_Top_Times_Returns_BadObjektRequest()
            {
                //Arrange
                LeaderBoardRepository
                    .Setup(l => l.GetTopTimes())
                    .ReturnsAsync((List<TopTimes>)null);

                UnitofWorkMock
                    .Setup(u => u.LeaderBoard)
                    .Returns(LeaderBoardRepository.Object);

                //Act
                var result = await _uut.GetTopTimes();

                var response = Assert.IsType<BadRequestResult>(result);
                Assert.Equal(400, response.StatusCode);
            }
        }
    }
}
