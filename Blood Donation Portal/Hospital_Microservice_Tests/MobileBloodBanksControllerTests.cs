using Hospital_Microservice.Controllers;
using Hospital_Microservice.Models;
using Hospital_Microservice.Services;
using System;
using System.Collections.Generic;
using Xunit;
using Moq;
using System.Linq;

namespace Hospital_Microservice_Tests
{
    public class MobileBloodBanksControllerTests
    {

        MobileBloodBanksController _controller;
        private readonly Mock<IMobileBloodBankService> _service;
        private readonly List<MobileBloodBank> _mobileBloodBanks;

        public MobileBloodBanksControllerTests()
        {
            _service = new Mock<IMobileBloodBankService>();
            _controller = new MobileBloodBanksController(_service.Object);
            _mobileBloodBanks = new List<MobileBloodBank>()
            {
                new MobileBloodBank(){Id= new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"),Name="Mb1", About="aboot"},
                new MobileBloodBank(){Id= new Guid("815accac-fd5b-478a-a9d6-f171a2f6ae7f"),Name="Mb2", About="aboot2"},
                new MobileBloodBank(){Id= new Guid("33704c4a-5b87-464c-bfb6-51971b4d18ad"),Name="Mb3", About="about"}
            };
        }

        [Fact]
        public async void AddMBB_ValidMBB_CreatedResponse()
        {
            //Arrange
            var mbb = new MobileBloodBank() { Name = "Name", About = "description" };
            //Act
            var response = _controller.PostMobileBloodBank(mbb);
            //Assert
            Assert.IsType<MobileBloodBank>(response);
        }
        
        [Fact]
        public async void GetAllMBBs_ExactNumberOfMBBs()
        {
            _service.Setup(service => service.GetMobileBloodBanksAsync())
                .ReturnsAsync(new List<MobileBloodBank>() 
                { new MobileBloodBank(), new MobileBloodBank(), new MobileBloodBank() });
            // Act
            var okResult = _controller.GetMobileBloodBanks().Result;

            // Assert
            var items = Assert.IsType<List<MobileBloodBank>>(okResult.Value);
            Assert.Equal(3, items.Count);
        }

        [Fact]
        public async void DeleteMBB_NotExistingGuidPassed_ReturnsNotFoundResponse()
        {
            // Arrange
            var randomGuid = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200");
            MobileBloodBank nullMbb = null;
            _service.Setup(service => service.DeleteMobileBloodBank(randomGuid))
                .ReturnsAsync(nullMbb);
            // Act
            var badResponse = _controller.DeleteMobileBloodBank(randomGuid);

            // Assert
            Assert.Null(badResponse.Result);
        }

        [Fact]
        public void Remove_ExistingGuidPassed_ReturnsOkResult()
        {
            // Arrange
            var existingGuid = new Guid("815accac-fd5b-478a-a9d6-f171a2f6ae7f");
            MobileBloodBank mbb = _mobileBloodBanks.Where(mbb => mbb.Id == existingGuid).Single();
            
            _service.Setup(service => service.DeleteMobileBloodBank(existingGuid))
                .ReturnsAsync(mbb);

            // Act
            var okResponse = _controller.DeleteMobileBloodBank(existingGuid).Result;

            // Assert
            Assert.Equal("815accac-fd5b-478a-a9d6-f171a2f6ae7f", okResponse.Value.Id.ToString());
        }
    
    
    }

}
