using GenFu;
using MarvelComicsLibrary.Application.Controllers;
using MarvelComicsLibrary.Application.ViewModel;
using MarvelComicsLibrary.Domain.Entity;
using MarvelComicsLibrary.Service.Interface;
using MarvelComicsLibrary.UnitTest.Config;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace MarvelComicsLibrary.UnitTest.Application
{
    public class BorrowControllerTest
    {
        /*
        private readonly Mock<IBorrowService> _service;
        private readonly Mock<ILogger<BorrowController>> _logger;
        private readonly BorrowController _controller;

        public BorrowControllerTest()
        {
            _service = new Mock<IBorrowService>();
            _logger = new Mock<ILogger<BorrowController>>();
            _controller = new BorrowController( _logger.Object, AutoMapperConfigTest.GetInstance(),_service.Object);
        }

        [Fact(DisplayName = "Post Success")]
        public void PostSuccess()
        {
            var borrowViewModel = A.New<BorrowViewModel>();
            var borrowEntity = A.New<Borrow>();

            _service.Setup(x => x.Add(It.IsAny<Borrow>())).Returns(borrowEntity);

            var result = _controller.Post(borrowViewModel);

            Assert.NotNull(result);

            Assert.IsType<OkObjectResult>(result.Result);
        }*/
    }
}
