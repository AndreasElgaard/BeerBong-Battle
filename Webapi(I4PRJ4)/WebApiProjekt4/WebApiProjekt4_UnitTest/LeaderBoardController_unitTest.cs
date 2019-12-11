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
            public async void Should_Return_OkObjectResult_with_list_of_Games()
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
        }

        public class ReadOneAsync : LeaderBoardController_unitTest
        {
            [Fact]
            public async void Should_Return_OkObjectResult_with_one_Game()
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
        }
    }
}
