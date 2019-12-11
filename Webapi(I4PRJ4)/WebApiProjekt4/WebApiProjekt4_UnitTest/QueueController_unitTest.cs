using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class QueueController_unitTest
    {
        protected QueueController _uut { get; }
        protected Mock<IUnitOfWork> UnitofWorkMock { get; }
        protected Mock<IQueueRepository> QueueRepositoryMock { get; }
        protected Mock<IMapper> MapperMock { get; }

        public QueueController_unitTest()
        {
            QueueRepositoryMock = new Mock<IQueueRepository>();
            UnitofWorkMock = new Mock<IUnitOfWork>();
            MapperMock = new Mock<IMapper>();
            _uut = new QueueController(UnitofWorkMock.Object, MapperMock.Object);
        }

        public class ReadAllAsync : QueueController_unitTest
        {
            [Fact]
            public async void Should_Return_OkObjectResult_with_list_of_Games()
            {
                //Arrange
                var expectedResult = new List<Queue>()
                {
                    new Queue {QueueId = 1},
                    new Queue {QueueId = 1}
                };

                var finalResult = new List<QueueResponse>()
                {
                    new QueueResponse() {QueueId = 1},
                    new QueueResponse() {QueueId = 2}
                };

                QueueRepositoryMock
                    .Setup(r => r.GetAll())
                    .ReturnsAsync(expectedResult).Verifiable();

                UnitofWorkMock
                    .Setup(x => x.Queue)
                    .Returns(QueueRepositoryMock.Object);

                MapperMock
                    .Setup(m => m.Map<List<QueueResponse>>(expectedResult))
                    .Returns(finalResult).Verifiable();

                //Act
                var result = await _uut.GetAll();

                //Assert
                QueueRepositoryMock.Verify();
                MapperMock.Verify();

                var okResult = Assert.IsType<OkObjectResult>(result);
                Assert.Same(finalResult, okResult.Value);
            }
        }

        public class ReadOneAsync : QueueController_unitTest
        {
            [Fact]
            public async void Should_Return_OkObjectResult_with_one_Game()
            {
                //Arrange
                var expectedResult = new Queue() { QueueId = 1 };

                var finalResult = new QueueResponse() { QueueId = 1 };

                QueueRepositoryMock
                    .Setup(x => x.Get(expectedResult.QueueId))
                    .ReturnsAsync(expectedResult).Verifiable();

                UnitofWorkMock
                    .Setup(m => m.Queue)
                    .Returns(QueueRepositoryMock.Object);

                MapperMock
                    .Setup(m => m.Map<QueueResponse>(expectedResult))
                    .Returns(finalResult);

                //Act
                var result = await _uut.Get(expectedResult.QueueId);

                //Assert
                QueueRepositoryMock.Verify();

                var okResult = Assert.IsType<OkObjectResult>(result);
                Assert.Same(finalResult, okResult.Value);
            }
        }
    }
}

