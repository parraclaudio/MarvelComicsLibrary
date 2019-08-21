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
    public class ComicControllerTest
    {
        
        private readonly Mock<IComicService> _service;
        private readonly Mock<ILogger<ComicController>> _logger;
        private readonly ComicController _controller;

        public ComicControllerTest()
        {
            _service = new Mock<IComicService>();
            _logger = new Mock<ILogger<ComicController>>();
            _controller = new ComicController( _logger.Object, AutoMapperConfigTest.GetInstance(),_service.Object);
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
