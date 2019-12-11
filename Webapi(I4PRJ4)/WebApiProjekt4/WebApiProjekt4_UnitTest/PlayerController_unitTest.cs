using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using we.Controllers;
using WebApiProjekt4.Controllers;
using WebApiProjekt4.Controllers.Responses;
using WebApiProjekt4.Data;
using WebApiProjekt4.Data.EFCore;
using WebApiProjekt4.Extensions;
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
            _uut.ControllerContext = new ControllerContext();
            _uut.ControllerContext.HttpContext = new DefaultHttpContext();
            _uut.ControllerContext.HttpContext.Request.Headers["UserId"] = "1";
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

            [Fact]
            public async void Should_Return_Badrequest_when_no_Games_Exsist()
            {
                //Arrange
                var expectedResult = new List<Player>()
                {
                    new Player {PlayerId = 1},
                    new Player {PlayerId = 2}
                };

                PlayerRepository
                    .Setup(x => x.GetAll())
                    .ReturnsAsync((List<Player>)null).Verifiable();

                UnitofWorkMock
                    .Setup(m => m.Player)
                    .Returns(PlayerRepository.Object);

                //Act
                var result = await _uut.GetAll();

                //Assert
                PlayerRepository.Verify();

                var ErrorResult = Assert.IsType<NotFoundResult>(result);
                Assert.Equal(404, ErrorResult.StatusCode);
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
                MapperMock.Verify();

                var okResult = Assert.IsType<OkObjectResult>(result);
                Assert.Same(finalResult, okResult.Value);
            }

            [Fact]
            public async void Should_Return_Badrequest_when_wrong_input_is_given()
            {
                //Arrange
                var expectedResult = new Player() { PlayerId = 1 };

                PlayerRepository
                    .Setup(x => x.Get(expectedResult.PlayerId))
                    .ReturnsAsync((Player)null).Verifiable();

                UnitofWorkMock
                    .Setup(m => m.Player)
                    .Returns(PlayerRepository.Object);

                //Act
                var result = await _uut.Get(expectedResult.PlayerId);

                //Assert
                PlayerRepository.Verify();

                var ErrorResult = Assert.IsType<BadRequestObjectResult>(result);
                Assert.Equal(400, ErrorResult.StatusCode);
            }
        }

        //public class RemoveOneAsync : PlayerController_unitTest
        //{
        //    [Fact]
        //    public async void Remove_Given_game_by_id()
        //    {
        //        //Arrange
        //        var expectedResult = new Player() { PlayerId = 1 };

        //        PlayerRepository
        //            .Setup(g => g.Remove(expectedResult.PlayerId));

        //        UnitofWorkMock
        //            .Setup(u => u.Player)
        //            .Returns(PlayerRepository.Object);

        //        //Act
        //        var result = await _uut.Delete(expectedResult.PlayerId);

        //        //Assert
        //        PlayerRepository.Verify();

        //        var response = Assert.IsType<OkResult>(result);
        //        Assert.Equal(200, response.StatusCode);
        //    }

        //    [Fact]
        //    public void Remove_Given_game_by_id_fails()
        //    {
        //        //Arrange
        //        var expectedResult = new Player() { PlayerId = 1 };

        //        PlayerRepository
        //            .Setup(g => g.Remove(expectedResult.PlayerId)).Throws(new Exception());

        //        UnitofWorkMock
        //            .Setup(u => u.Player)
        //            .Returns(PlayerRepository.Object);

        //        //Act
        //        var result = _uut.Delete(expectedResult.PlayerId);

        //        //Assert
        //        PlayerRepository.Verify();

        //        var response = Assert.IsType<BadRequestObjectResult>(result);
        //        Assert.Equal(400, response.StatusCode);
        //    }
        //}
    }
}
