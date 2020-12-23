using System;
using API.DTOs.AppUser;
using API.Entities;
using Xunit;

namespace Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            ServiceResponse<GetUserDto> response = new ServiceResponse<GetUserDto>();
            Assert.NotNull(response);
        }
    }
}
