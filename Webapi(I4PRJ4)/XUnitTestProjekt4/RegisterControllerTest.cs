using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using projekt4.Controllers;
using projekt4.Model;
using Xunit;
using Moq;
using projekt4.Data;

namespace XUnitTestProjekt4
{
    public class RegistercontrollerTest
    {
        protected RegistersController ControllerunderTest { get; }
        protected Mock<IRegisterService> RegisterServierMock { get; }
        public RegistercontrollerTest()
        {
            RegisterServierMock = new Mock<IRegisterService>();
            ControllerunderTest = new RegistersController(RegisterServierMock.Object);
        }

        
        public class ReadAllAsync : RegistercontrollerTest
        {
            [Fact]
            public async void Should_return_OKobjectResult_with_allregisters()
            {
                //arrange
                var expectedRegister = new Register[]
                {
                    new Register{Id = 1},
                    new Register{Id = 2},
                    new Register{Id = 3}
                };
                RegisterServierMock
                    .Setup(x => x.GetRegisterAsync())
                    .ReturnsAsync(expectedRegister);


                //act
                var result = await ControllerunderTest.GetRegisterAsync();


                //assert
                var okResult = Assert.IsType<OkObjectResult>(result);
                Assert.Same(expectedRegister, okResult.Value);
            }
        }
    }
}
