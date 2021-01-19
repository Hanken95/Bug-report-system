using System;
using Xunit;
using BackEnd.Data;
using System.Threading.Tasks;

namespace UnitTesting
{
    public class BugReportUnitTests
    {
        [Fact]
        public async Task GetBugReport_ReportGetsRead()
        {
            using (var db = new AppDbContext(Utilities.TestDbContextOptions()))
            {
                // Arrange
                var expectedMessages = AppDbContext.GetSeedingMessages();
                await db.AddRangeAsync(expectedMessages);
                await db.SaveChangesAsync();

                // Act
                var result = await db.GetMessagesAsync();

                // Assert
                var actualMessages = Assert.IsAssignableFrom<List<Message>>(result);
                Assert.Equal(
                    expectedMessages.OrderBy(m => m.Id).Select(m => m.Text),
                    actualMessages.OrderBy(m => m.Id).Select(m => m.Text));
            }
        }

        [Fact]
        public async Task AddBugReport_BugReportGetsAdded()
        {
            using (var db = new AppDbContext(Utilities.TestDbContextOptions()))
            {
                // Arrange
                var recId = 10;
                var expectedMessage = new Message() { Id = recId, Text = "Message" };

                // Act
                await db.AddMessageAsync(expectedMessage);

                // Assert
                var actualMessage = await db.FindAsync<Message>(recId);
                Assert.Equal(expectedMessage, actualMessage);
            }
        }

        [Fact]
        public async Task DeleteAllMessagesAsync_MessagesAreDeleted()
        {
            using (var db = new AppDbContext(Utilities.TestDbContextOptions()))
            {
                // Arrange
                var seedMessages = AppDbContext.GetSeedingMessages();
                await db.AddRangeAsync(seedMessages);
                await db.SaveChangesAsync();

                // Act
                await db.DeleteAllMessagesAsync();

                // Assert
                Assert.Empty(await db.Messages.AsNoTracking().ToListAsync());
            }
        }

        [Fact]
        public async Task DeleteMessageAsync_MessageIsDeleted_WhenMessageIsFound()
        {
            using (var db = new AppDbContext(Utilities.TestDbContextOptions()))
            {
                // Arrange
                var seedMessages = AppDbContext.GetSeedingMessages();
                await db.AddRangeAsync(seedMessages);
                await db.SaveChangesAsync();
                var recId = 1;
                var expectedMessages =
                    seedMessages.Where(message => message.Id != recId).ToList();

                // Act
                await db.DeleteMessageAsync(recId);

                // Assert
                var actualMessages = await db.Messages.AsNoTracking().ToListAsync();
                Assert.Equal(
                    expectedMessages.OrderBy(m => m.Id).Select(m => m.Text),
                    actualMessages.OrderBy(m => m.Id).Select(m => m.Text));
            }
        }

        [Fact]
        public async Task DeleteMessageAsync_NoMessageIsDeleted_WhenMessageIsNotFound()
        {
            using (var db = new AppDbContext(Utilities.TestDbContextOptions()))
            {
                // Arrange
                var expectedMessages = AppDbContext.GetSeedingMessages();
                await db.AddRangeAsync(expectedMessages);
                await db.SaveChangesAsync();
                var recId = 4;

                // Act
                try
                {
                    await db.DeleteMessageAsync(recId);
                }
                catch
                {
                    // recId doesn't exist
                }

                // Assert
                var actualMessages = await db.Messages.AsNoTracking().ToListAsync();
                Assert.Equal(
                    expectedMessages.OrderBy(m => m.Id).Select(m => m.Text),
                    actualMessages.OrderBy(m => m.Id).Select(m => m.Text));
            }
        }
    }
}
