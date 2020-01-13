using Hospital_Microservice.Controllers;
using Hospital_Microservice.Models;
using Hospital_Microservice.Persistence.Contexts;
using Hospital_Microservice.Repositories;
using Hospital_Microservice.Services;
using Hospital_Microservice_Tests.ServicesFake;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Hospital_Microservice_Tests
{
    public class HospitalsControllerTests
    {
        HospitalsController _controller;
        private readonly Mock<IHospitalService> _service;
        private readonly List<Hospital> _hospitals;

        public HospitalsControllerTests()
        {
            //_service = new FakeHospitalService();
            //_controller = new HospitalsController(_service);
            _service = new Mock<IHospitalService>();
            _controller = new HospitalsController (_service.Object);
            _hospitals = new List<Hospital>()
            {
                new Hospital(){ Id= new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"), Name = "Spital1", City="Iasi",
                 County = "Iasi", Address = "Strada", Email="hospital@email.com", UserName="user" },
                new Hospital(){ Id= new Guid("815accac-fd5b-478a-a9d6-f171a2f6ae7f"), Name = "Spital2", City="Roman",
                 County = "Neamt", Address = "Strada2", Email="hospital2@email.com", UserName="user2" },
                new Hospital(){ Id= new Guid("33704c4a-5b87-464c-bfb6-51971b4d18ad"), Name = "Spital3", City="Horia",
                 County = "Neamt", Address = "Strada", Email="hospital3@email.com", UserName="user3" },
                new Hospital(){ Id= new Guid("33704c4a-5b87-464c-bfb6-51971b4d19da"), Name = "Spital3", City="Roman",
                 County = "Neamt", Address = "Strada", Email="hospital213@email.com", UserName="us3er3" }
            };
        }
        [Fact]
        public async void GetHospitalsByCity_RomanCity_ExactNumberOfHospitals()
        {
            //Arrange
            string city = "Roman";
            _service.Setup(service => service.GetHospitalsByCityOrCountyAsync(city))
                .ReturnsAsync(new List<Hospital>() { new Hospital(), new Hospital()});
            // Act
            var okResult = _controller.GetHospitalsByCity(city).Result;

            // Assert
            var items = Assert.IsType<List<Hospital>>(okResult.Value);
            Assert.Equal(2, items.Count);
        }

    }
}
