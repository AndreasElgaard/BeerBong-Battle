//using System;
//using System.Collections.Generic;
//using System.Text;
//using projekt4.Data;
//using projekt4.Controllers;
//using Xunit;
//using projekt4.Model;
//using System.Threading.Tasks;
//using System.Collections.ObjectModel;
//using Moq;

//namespace XUnitTestProjekt4
//{
//    public class RegisterServiceTest
//    {
//        protected RegisterService ServiceUnderTest { get; }
//        protected Mock<IRegisterRepository> RegisterRepositoryMock { get; }

//        public RegisterServiceTest()
//        {
//            RegisterRepositoryMock = new Mock<IRegisterRepository>();
//            ServiceUnderTest = new RegisterService(RegisterRepositoryMock.Object);
//        }

//        public class GetRegisterAsync : RegisterServiceTest
//        {
//            [Fact]
//            public async Task Should_return_all_Registers()
//            {
//                //arrange
//                var expectedRegister = new ReadOnlyCollection<Register>(new List<Register>
//                {
//                    new Register{Id = 1},
//                    new Register{Id = 2},
//                    new Register{Id = 3}
//                });
//                RegisterRepositoryMock
//                    .Setup(x => x.GetRegisterAsync())
//                    .ReturnsAsync(expectedRegister);
//                //Act
//                var result = await ServiceUnderTest.GetRegisterAsync();


//                //Assert
//                Assert.Same(expectedRegister, result);
  
//            }
//        }

//        public class GetOneRegisterAsync : RegisterServiceTest
//        {
//            [Fact]
//            public async Task Should_return_One_Register()
//            {
//                //arrange
//                var RegisterId = 1;
//                var expectedRegister = new Register { Id = RegisterId };
//                RegisterRepositoryMock
//                    .Setup(x => x.GetOneRegisterAsync(RegisterId))
//                    .ReturnsAsync(expectedRegister);
//                //Act
//                var result = await ServiceUnderTest.GetOneRegisterAsync(RegisterId);


//                //Assert
//                Assert.Same(expectedRegister, result);

//            }

//            [Fact]
//            public async Task Should_return_Null_if_the_register_does_not_exist()
//            {
//                //arrange
//                var RegisterId = 1;
//                RegisterRepositoryMock
//                    .Setup(x => x.GetOneRegisterAsync(RegisterId))
//                    .ReturnsAsync(default(Register));
//                //Act
//                var result = await ServiceUnderTest.GetOneRegisterAsync(RegisterId);

//                //Assert
//                Assert.Null(result);

//            }
//        }

//        public class IsRegisterExistsAsync : RegisterServiceTest
//        {
//            [Fact]
//            public async Task Should_return_True_if_register_exist()
//            {
//                //arrange
//                var RegisterId = 1;
//                RegisterRepositoryMock
//                    .Setup(x => x.GetOneRegisterAsync(RegisterId))
//                    .ReturnsAsync(new Register());
//                //Act
//                var result = await ServiceUnderTest.IsRegisterExitsAsync(RegisterId);


//                //Assert
//                Assert.True(result);
//            }

//            [Fact]
//            public async Task Should_return_False_if_register_dose_not_exist()
//            {
//                //arrange
//                var RegisterId = 5;
//                RegisterRepositoryMock
//                    .Setup(x => x.GetOneRegisterAsync(RegisterId))
//                    .ReturnsAsync(default(Register));
//                //Act
//                var result = await ServiceUnderTest.IsRegisterExitsAsync(RegisterId);


//                //Assert
//                Assert.False(result);
//            }
//        }

//        public class CreateAsync : RegisterServiceTest
//        {
//            [Fact]
//            public async Task Should_create_and_return_the_specified_Register()
//            {
//                // Arrange, Act, Assert
//                var exception = await Assert.ThrowsAsync<NotSupportedException>(() => ServiceUnderTest.CreateAsync(null));
//            }
//        }

//        public class UpdateAsync : RegisterServiceTest
//        {
//            [Fact]
//            public async Task Should_update_and_return_the_specified_Register()
//            {
//                // Arrange, Act, Assert
//                var exception = await Assert.ThrowsAsync<NotSupportedException>(() => ServiceUnderTest.UpdateAsync(null));
//            }
//        }

//        public class DeleteAsync : RegisterServiceTest
//        {
//            [Fact]
//            public async Task Should_delete_and_return_the_specified_Register()
//            {
//                // Arrange, Act, Assert
//                var exception = await Assert.ThrowsAsync<NotSupportedException>(() => ServiceUnderTest.DeleteAsync(100));
//            }
//        }

//    }
//}
