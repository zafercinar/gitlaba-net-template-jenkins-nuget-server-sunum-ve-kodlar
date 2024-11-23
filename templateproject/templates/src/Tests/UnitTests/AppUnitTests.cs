using ZACx.Templates.WebApiProject.Core.Models.Request.Examples;

namespace ZACx.Templates.WebApiProject.UnitTests
{
    [TestClass]
    public class AppUnitTests
    {
        [TestMethod]
        public void Create_ExampleRequestModel_Should_Throw_Exception_When_Code_Is_Empty()
        {
            //todo@zafer.cinar: Method isimlendirmesi ve aşağıdaki işlem örneklendirme için yapılmıştır. Projenizi create ettikten sonra silmeniz gerekmektedir.

            //Arrange
            var exampleCode = string.Empty;

            //Act

            //Assert
            Assert.ThrowsException<Exception>(() => new ExampleRequestModel(exampleCode));
        }

        [TestMethod]
        public void Create_ExampleRequestModel_Should_Success()
        {
            //todo@zafer.cinar: Method isimlendirmesi ve aşağıdaki işlem örneklendirme için yapılmıştır. Projenizi create ettikten sonra silmeniz gerekmektedir.

            //Arrange
            var exampleCode = "D003";

            //Act

            //Assert
            Assert.ThrowsException<Exception>(() => new ExampleRequestModel(exampleCode));
        }
    }
}