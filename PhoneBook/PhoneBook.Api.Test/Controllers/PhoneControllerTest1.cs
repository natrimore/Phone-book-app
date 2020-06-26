using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using PhoneBook.Api.Controllers;
using PhoneBook.Api.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace PhoneBook.Api.Test
{
    public class PhoneControllerTest1
    {
        [Theory]
        [MemberData(nameof(AddPhoneData))]
        public void CreatePhoneResponseSuccess()
        {

        }
        
        public static IEnumerable<object[]> AddPhoneData()
        {
            yield return new object[] { 6, "+998946713693", "Jakhongir" };
            yield return new object[] { 8, "+998998785739", "Shaxzod" };
            yield return new object[] { 11, "+998946655630", "Yosinbek" };

        }

        [Fact]
        public void GetWhenCalledReturnsOkResult()
        {
            var okResult = _controller.GetAll();

            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        private readonly IPhoneRepository _phoneRepository;
        private readonly IMapper _mapper;
        private readonly PhoneController _controller;

        public PhoneControllerTest1()
        {
            _phoneRepository = Substitute.For<IPhoneRepository>();
            _mapper = Substitute.For<IMapper>();
            _controller = new PhoneController(_phoneRepository, _mapper);
        }
    }
}
