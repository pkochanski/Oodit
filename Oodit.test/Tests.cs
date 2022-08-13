using Microsoft.AspNetCore.Mvc;
using Moq;
using Oodit.Controllers;
using Oodit.Models;
using Oodit.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace Oodit.test
{
    public class Tests
    {
        private readonly Mock<ICheckService> _moqCheckService;
        public Tests()
        {
            _moqCheckService = new Mock<ICheckService>();
        }
        [Fact]
        public void ShouldReturnErrorOnInvalidInput()
        {
            var stringInput = "1,2,sadf";
            var checkService = new CheckService();

            ResultListViewModel<int> result = checkService.CheckArray(stringInput);

            Assert.Equal("Error", result.ErrorMessage);
        }

        [Fact]
        public void ShouldReturnFalseIsSuccesOnInvelidInput()
        {
            var stringInput = "112, he3,2,1,9,9,8";
            var checkService = new CheckService();

            ResultListViewModel<int> result = checkService.CheckArray(stringInput);

            Assert.False(result.IsSuccess);
        }

        [Fact]
        public void ShouldReturnNumbersThatAppeard3TimesOrMore()
        {
            var stringInput = "1,2,3,4,5,1,1";
            var checkService = new CheckService();

            ResultListViewModel<int> result = checkService.CheckArray(stringInput);

            Assert.Contains<int>(1, result.List);  
        }

        [Fact]
        public void ShouldReturnNumbersThatAppeard3TimesOrMoreInDescendingOrder()
        {
            var stringInput = "1,1,1,1,3,3,3,3,2,1,2,9,9,9";
            var checkService = new CheckService();

            ResultListViewModel<int> result = checkService.CheckArray(stringInput);

            Assert.Equal(new List<int> { 9, 3, 1 }, result.List);
        }

        [Fact]
        public void ShouldReturnEmptyListWhenNeitherNumberAppears3Times()
        {
            var stringInput = "1,2,3,2,1,9,9,8";
            var checkService = new CheckService();

            ResultListViewModel<int> result = checkService.CheckArray(stringInput);

            Assert.Empty(result.List);
        }

        [Fact]
        public void ShouldReturnOKWhenArrayCheckedSuccessfuly()
        {
            _moqCheckService.Setup(x => x.CheckArray(It.IsAny<string>())).Returns(new ResultListViewModel<int>());
            var controller = new HomeController(_moqCheckService.Object);
            var result = controller.CheckArray("1,2,3");

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void ShouldReturnBadRequestWhenArrayCheckedWithError()
        {
            _moqCheckService.Setup(x => x.CheckArray(It.IsAny<string>())).Returns(new ResultListViewModel<int> { ErrorMessage="Error"});
            var controller = new HomeController(_moqCheckService.Object);
            var result = controller.CheckArray("1,2,sd");

            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}
