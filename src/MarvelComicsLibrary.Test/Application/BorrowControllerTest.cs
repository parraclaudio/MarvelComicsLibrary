using MarvelComicsLibrary.Application.Controllers;
using MarvelComicsLibrary.Service.Interface;
using Moq;
using Xunit;

namespace MarvelComicsLibrary.Test.Application
{
    public class BorrowControllerTest
    {
        /*
        private readonly Mock<IBorrowService> _creditCardService;
        private readonly BorrowController _controller;
        private readonly CreditCardViewModel _creditCardViewModel;

        public BorrowControllerTest()
        {
            _creditCardService = new Mock<ICreditCardService>();
            _logger = new Mock<ILogger<CreditCardController>>();
            _controller = new CreditCardController(_creditCardService.Object, _logger.Object);
        }

        [Fact(DisplayName = "Insert Sucess")]   
        public void InsertSuccess()
        {
            var services = new Mock<IClientServices>();
            var logger = new Mock<ILogger<ClientController>>();
            var controller = new ClientController(services.Object, AutoMapperConfigTest.GetInstance(), logger.Object);

            var clientViewModel = A.New<ClientViewModel>();
            var clientEntity = A.New<Client>();

            services.Setup(x => x.Insert(It.IsAny<Client>())).Returns(clientEntity);

            var result = controller.Post(clientViewModel);

            Assert.NotNull(result);

            Assert.IsType<OkObjectResult>(result.Result);
        }*/
    }
}
