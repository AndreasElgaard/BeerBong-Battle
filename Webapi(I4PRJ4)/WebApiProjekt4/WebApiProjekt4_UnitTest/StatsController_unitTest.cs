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
    public class StatsController_unitTest
    {
        protected StatsController _uut { get; }
        protected Mock<IUnitOfWork> UnitofWorkMock { get; }
        protected Mock<IStatsRepository> StatsRepository { get; }
        protected Mock<IMapper> MapperMock { get; }

        public StatsController_unitTest()
        {
            StatsRepository = new Mock<IStatsRepository>();
            UnitofWorkMock = new Mock<IUnitOfWork>();
            MapperMock = new Mock<IMapper>();
            _uut = new StatsController(UnitofWorkMock.Object, MapperMock.Object);
        }

        public class ReadAllAsync : StatsController_unitTest
        {
            [Fact]
            public async void Should_Return_OkObjectResult_with_list_of_Games()
            {
                //Arrange
                var expectedResult = new List<Stats>()
                {
                    new Stats {StatsId = 1, Time = 10},
                    new Stats {StatsId = 2, Time = 10}
                };

                var finalResult = new List<StatsResponse>()
                {
                    new StatsResponse() {StatsId = 1, Time = 10},
                    new StatsResponse() {StatsId = 2, Time = 10}
                };

                StatsRepository
                    .Setup(r => r.GetAll())
                    .ReturnsAsync(expectedResult).Verifiable();

                UnitofWorkMock
                    .Setup(x => x.Stats)
                    .Returns(StatsRepository.Object);

                MapperMock
                    .Setup(m => m.Map<List<StatsResponse>>(expectedResult))
                    .Returns(finalResult).Verifiable();

                //Act
                var result = await _uut.GetAll();

                //Assert
                StatsRepository.Verify();
                MapperMock.Verify();

                var okResult = Assert.IsType<OkObjectResult>(result);
                Assert.Same(finalResult, okResult.Value);
            }
        }

        public class ReadOneAsync : StatsController_unitTest
        {
            [Fact]
            public async void Should_Return_OkObjectResult_with_one_Game()
            {
                //Arrange
                var expectedResult = new Stats() { StatsId = 1, Time = 20};

                var finalResult = new StatsResponse() { StatsId = 1, Time = 30};

                StatsRepository
                    .Setup(x => x.Get(expectedResult.StatsId))
                    .ReturnsAsync(expectedResult).Verifiable();

                UnitofWorkMock
                    .Setup(m => m.Stats)
                    .Returns(StatsRepository.Object);

                MapperMock
                    .Setup(m => m.Map<StatsResponse>(expectedResult))
                    .Returns(finalResult);

                //Act
                var result = await _uut.Get(expectedResult.StatsId);

                //Assert
                StatsRepository.Verify();

                var okResult = Assert.IsType<OkObjectResult>(result);
                Assert.Same(finalResult, okResult.Value);
            }
        }
    }
}
