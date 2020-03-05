using BugTracker.Common.Enums;
using BugTracker.Core.Domain;
using BugTracker.Core.Services;
using BugTracker.Data.Interfaces;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace BugTracker.Core.Test.Services
{
    public class EditBugServiceTest
    {
        private readonly Bug _newBug;
        private readonly Mock<IBugRepository> _mockBugRepository;
        private readonly BugTrackerService _service;

        public EditBugServiceTest()
        {
          
            _mockBugRepository = new Mock<IBugRepository>();

            _service = new BugTrackerService(_mockBugRepository.Object);
        }

        [Fact]
        public async Task Throws_When_Bug_Id_Is_Null()
        {
            //Assign
            //Act
            //Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _service.EditAsync(null));
            _mockBugRepository.Verify(x => x.GetAsync(It.IsAny<long>()), Times.Never);
        }
    }
}
