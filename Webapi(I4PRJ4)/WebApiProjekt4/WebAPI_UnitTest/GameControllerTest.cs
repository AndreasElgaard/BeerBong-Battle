using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using WebApiProjekt4.Controllers;
using WebApiProjekt4.Data.EFCore;
using WebApiProjekt4.Mapping;
using NSubstitute;
using WebApiProjekt4.Controllers.Responses;
using WebApiProjekt4.Repositories;
using Moq;
using WebApiProjekt4.Data;

namespace WebAPI_UnitTest
{
    public class GameControllerTest
    {

        private GameController _uut;
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private Mock<IMapper> _mapperMock;

        [SetUp]
        public void Setup()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _mapperMock = new Mock<IMapper>();
            _uut = new GameController(_unitOfWorkMock.Object, _mapperMock.Object);
        }

        [Test]
        public async Task GetAllAsync_Should_return_Ok()
        {
            //Arrange
            var expectedGames = new Game[]
            {
                new Game {GameId = 1},
                new Game {GameId = 2},
                new Game {GameId = 3}
            };

            _unitOfWorkMock
                .Setup(x => x.Game.GetAll())
                .ReturnsAsync(expectedGames);

            var ResponseResult = new GameResponse[]
            {
                new GameResponse {GameId = 1},
                new GameResponse {GameId = 2},
                new GameResponse {GameId = 3}
            };


            _mapperMock
                .Setup(x => x.Map<GameResponse[]>(expectedGames))
                .Returns(ResponseResult);

            //Act
            var result = await _uut.GetAll();


            //Assert

            Assert.That(result, Is.EqualTo());
        }

        [Test]
        public void Test2()
        {

        }
    }
}