using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsecticDatabaseApi.InsecticData;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Moq;
using Xunit;

namespace InsecticApiTests.UserControllerTests
{
    public class GetUserControllerApiTests
    {
        private readonly Mock<IUserData> repo = new Mock<IUserData>();

        [Fact]
        public void GetUsers_ReturnsListOfAllUsers()
        {

        }
    }
}
