using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using we.Controllers;
using WebApiProjekt4.Controllers;
using WebApiProjekt4.Controllers.Requests;
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
            public async void Should_Return_OkObjectResult_with_list_of_Stats()
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

            [Fact]
            public async void Should_Return_Badrequest_when_wrong_input_is_given()
            {
                //Arrange
                var expectedResult = new List<Stats>()
                {
                    new Stats {StatsId = 1, Time = 10},
                    new Stats {StatsId = 2, Time = 10}
                };

                StatsRepository
                    .Setup(x => x.GetAll())
                    .ReturnsAsync((List<Stats>)null).Verifiable();

                UnitofWorkMock
                    .Setup(m => m.Stats)
                    .Returns(StatsRepository.Object);

                //Act
                var result = await _uut.GetAll();

                //Assert
                StatsRepository.Verify();

                var ErrorResult = Assert.IsType<NotFoundResult>(result);
                Assert.Equal(404, ErrorResult.StatusCode);
            }
        }

        public class ReadOneAsync : StatsController_unitTest
        {
            [Fact]
            public async void Should_Return_OkObjectResult_with_one_Stat()
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
                MapperMock.VerifyAll();

                var okResult = Assert.IsType<OkObjectResult>(result);
                Assert.Same(finalResult, okResult.Value);
            }

            [Fact]
            public async void Should_Return_Badrequest_when_wrong_input_is_given()
            {
                //Arrange
                var expectedResult = new Stats() { StatsId = 1, Time = 20 };

                StatsRepository
                    .Setup(x => x.Get(expectedResult.StatsId))
                    .ReturnsAsync((Stats)null).Verifiable();

                UnitofWorkMock
                    .Setup(m => m.Stats)
                    .Returns(StatsRepository.Object);

                //Act
                var result = await _uut.Get(expectedResult.StatsId);

                //Assert
                StatsRepository.Verify();

                var ErrorResult = Assert.IsType<BadRequestObjectResult>(result);
                Assert.Equal(400, ErrorResult.StatusCode);
            }
        }

        public class CreateAsync : StatsController_unitTest
        {
            [Fact]
            public async void Should_return_CreatedAtActionResult_with_created_Stats()
            {
                //Arrange
                var expectedResult = new Stats() { Time = 30};

                var finalResult = new StatsRequest() { Time = 30 };

                StatsRepository
                    .Setup(l => l.Add(expectedResult)).Verifiable();


                UnitofWorkMock
                    .Setup(m => m.Stats)
                    .Returns(StatsRepository.Object);

                MapperMock
                    .Setup(m => m.Map<Stats>(finalResult))
                    .Returns(expectedResult);

                //Act
                var result = await _uut.Post(finalResult);

                //Assert
                StatsRepository.VerifyAll();
                MapperMock.VerifyAll();

                var response = Assert.IsType<OkObjectResult>(result);
                Assert.Same(finalResult, response.Value);
            }

            [Fact]
            public async void Should_return_Throw_and_return_BadRequest_with_created_Stats()
            {
                //Arrange
                var expectedResult = new Stats() { Time = 30};

                var finalResult = new StatsRequest() { Time = 30 };

                StatsRepository
                    .Setup(l => l.Add(expectedResult)).Throws(new Exception());


                UnitofWorkMock
                    .Setup(m => m.Stats)
                    .Returns(StatsRepository.Object);

                MapperMock
                    .Setup(m => m.Map<Stats>(finalResult))
                    .Returns(expectedResult);

                //Act
                var result = await _uut.Post(finalResult);
                //Assert
                StatsRepository.VerifyAll();
                MapperMock.Verify();

                var ErrorResult = Assert.IsType<BadRequestObjectResult>(result);
                Assert.Equal(400, ErrorResult.StatusCode);
            }
        }

        public class RemoveOneAsync : StatsController_unitTest
        {
            [Fact]
            public void Remove_Given_Stats_by_id()
            {
                //Arrange
                var expectedResult = new Stats() { StatsId = 1, Time = 20 };

                StatsRepository
                    .Setup(g => g.Remove(expectedResult.StatsId));

                UnitofWorkMock
                    .Setup(u => u.Stats)
                    .Returns(StatsRepository.Object);

                //Act
                var result = _uut.Delete(expectedResult.StatsId);

                //Assert
                StatsRepository.Verify();

                var response = Assert.IsType<OkResult>(result);
                Assert.Equal(200, response.StatusCode);
            }

            [Fact]
            public void Remove_Given_Stats_by_id_fails()
            {
                //Arrange
                var expectedResult = new Stats() { StatsId = 1, Time = 20 };

                StatsRepository
                    .Setup(g => g.Remove(expectedResult.StatsId)).Throws(new Exception());

                UnitofWorkMock
                    .Setup(u => u.Stats)
                    .Returns(StatsRepository.Object);

                //Act
                var result = _uut.Delete(expectedResult.StatsId);

                //Assert
                StatsRepository.Verify();

                var response = Assert.IsType<BadRequestObjectResult>(result);
                Assert.Equal(400, response.StatusCode);
            }
        }
    }
}
