using System;
using AutoMapper;
using DataServiceLib.IDataService;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ProjectPortfolio2_Group11.Controller;
using DataServiceLib.IDataService;
using Xunit;


namespace WebServiceTests
{
   
    public class BookmarkControllerTest
    {
        private Mock<IBookmarkingDataService> _BookmarkingDataServiceMock;
        private Mock<IMapper> _mapperMock;
        private Mock<IUrlHelper> _urlMock;


        public BookmarkControllerTest()
        {

             _BookmarkingDataServiceMock = new Mock<IBookmarkingDataService>();
             _mapperMock = new Mock<IMapper>();
             _urlMock = new Mock<IUrlHelper>();

        }

        [Fact]
        public void GetProductWithValidIdShouldReturnOk()
        {


            _BookmarkingDataServiceMock.Setup(x => x.GetBookMark(1)).Returns(new BookMark { nconst = new nconst() });
            _mapperMock.Setup(x => x.Map<BookmarkPerson>(It.IsAny<BookMark>())).Returns(new BookMarkPerson());


            var ctrl = new BookmarkController(_BookmarkingDataServiceMock.Object, _mapperMock.Object);
            ctrl.Url = _urlMock.Object;

            var response = ctrl.GetBookMark(1);

            response.Should().BeOfType<OkObjectResult>();

        }

        [Fact]
        public void GetProductWithInvalidIdShouldReturnNotFound()
        {

            var ctrl = new BookmarkController(_BookmarkingDataServiceMock.Object, null);

            var response = ctrl.GetBookMark(10);

            response.Should().BeOfType<NotFoundResult>();
        }
    }
}