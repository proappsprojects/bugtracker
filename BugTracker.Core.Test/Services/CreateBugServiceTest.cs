using BugTracker.Common.Enums;
using BugTracker.Core.Domain;
using BugTracker.Core.Services;
using BugTracker.Data.Interfaces;
using Moq;
using System;
using Xunit;

namespace BugTracker.Core.Test.Services
{
    public class CreateBugServiceTest
    {
        private readonly Bug _newBug;
        private readonly Mock<IBugRepository> _mockBugRepository;
        private readonly BugTrackerService _service;

        public CreateBugServiceTest()
        {
            _newBug = new Domain.Bug
            {
                Title = "Invice Issue",
                Description = "Cant create invoice with current address",
                StatusId = (long)Status.Open,
                DateCreated = System.DateTime.Now
            };

            _mockBugRepository = new Mock<IBugRepository>();

            _service = new BugTrackerService(_mockBugRepository.Object);
        }

        [Fact]
        public async void Should_Return_A_Valid_Bug_When_Successfully_Created()
        {
            //Arrange
            var newBug = new Bug
            {
                Title = "Invice Issue",
                Description = "Cant create invoice with current address",
                StatusId = (long)Status.Open,
                DateCreated = System.DateTime.Now
            };


            //Act
            Bug newBugResult = await _service.CreateAsync(newBug);

            //Assert
            Assert.NotNull(newBugResult);
            Assert.Equal(newBugResult.Title, newBug.Title);
            Assert.Equal(newBugResult.Description, newBug.Description);
            Assert.Equal(newBugResult.DateCreated, newBug.DateCreated);
            Assert.Equal(newBugResult.StatusId, newBug.StatusId);


        }
        [Fact]
        public async System.Threading.Tasks.Task An_Exception_Should_Be_Thrown_If_Bub_Request_Is_Null()
        {
            //Assign
            //Act
            //Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _service.CreateAsync(null));

        }

        [Fact]
        public async void Should_Created_A_Bug_Entry()
        {
            //Arrange
            BugTracker.Data.Entities.Bug bug = null;

            _mockBugRepository.Setup(x => x.CreateAsync(It.IsAny<BugTracker.Data.Entities.Bug>()))
                .Callback<BugTracker.Data.Entities.Bug>(result =>
                {
                    bug = result;
                });

            //Act
            Bug newBugResult = await _service.CreateAsync(_newBug);

            //Assert
            _mockBugRepository.Verify(x => x.CreateAsync(It.IsAny<BugTracker.Data.Entities.Bug>()), Times.Once);

            Assert.NotNull(bug);
            Assert.Equal(_newBug.Title, bug.Title);
            Assert.Equal(_newBug.Description, bug.Description);
            Assert.Equal(_newBug.DateCreated, bug.DateCreated);
            Assert.Equal(_newBug.StatusId, bug.StatusId);
        }

    }
}
