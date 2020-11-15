using System;
using AutoMapper;
using DataServiceLib.IDataService;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ProjectPortfolio2_Group11.Controller;
using DataServiceLib.IDataService;
using DataServiceLib.DBObjects;

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
        public void GetBookMarkWithValidIdShouldReturnOk()
        {


            _BookmarkingDataServiceMock.Setup(x => x.GetBookMark( userid, nconst)).Returns(new BookmarkPerson () );
            _mapperMock.Setup(x => x.Map<BookmarkPerson>(It.IsAny<BookmarkPerson>())).Returns(new BookmarkPerson());


            var ctrl = new BookmarkController(_BookmarkingDataServiceMock.Object, _mapperMock.Object);
            ctrl.Url = _urlMock.Object;

            var response = ctrl.GetBookMark();

            response.Should().BeOfType<OkObjectResult>();

        }

        [Fact]
        public void GetBookMarktWithInvalidIdShouldReturnNotFound()
        {

            var ctrl = new BookmarkController(_BookmarkingDataServiceMock.Object, null);

            var response = ctrl.GetBookMark(10);

            response.Should().BeOfType<NotFoundResult>();
        }
    }
}