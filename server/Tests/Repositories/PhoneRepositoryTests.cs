using System.Linq;
using System.Threading.Tasks;
using TTMStest.Server.DTOs.PhoneDTOs;
using TTMStest.Server.Models;
using TTMStest.Server.Repositories;
using Xunit;

namespace TTMStest.Tests.Repositories
{
    public class PhoneRepositoryTests
    {
        [Fact]
        public async Task AddPhoneAsync_ShouldAddPhone()
        {
            // Arrange
            var repo = new PhoneRepository();
            var dto = new CreatePhoneRequestDto { Name = "Test Name", Number = "123456789" };

            // Act
            var result = await repo.AddPhoneAsync(dto);
            var phones = await repo.GetAllPhonesAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Single(phones);
            Assert.Equal("Test Name", result.Name);
            Assert.Equal("123456789", result.Number);
        }

        [Fact]
        public async Task GetAllPhonesAsync_ShouldReturnAllPhones()
        {
            var repo = new PhoneRepository();
            await repo.AddPhoneAsync(new CreatePhoneRequestDto { Name = "Phone1", Number = "111" });
            await repo.AddPhoneAsync(new CreatePhoneRequestDto { Name = "Phone2", Number = "222" });

            var phones = await repo.GetAllPhonesAsync();

            Assert.Equal(2, phones.Count());
        }

        [Fact]
        public async Task GetPhoneByIdAsync_ShouldReturnCorrectPhone()
        {
            var repo = new PhoneRepository();
            await repo.AddPhoneAsync(new CreatePhoneRequestDto { Name = "Phone1", Number = "111" });
            var phone2 = await repo.AddPhoneAsync(new CreatePhoneRequestDto { Name = "Phone2", Number = "222" });

            var result = await repo.GetPhoneByIdAsync(phone2.Id);

            Assert.NotNull(result);
            Assert.Equal("Phone2", result!.Name);
        }

        [Fact]
        public async Task GetPhoneByIdAsync_ShouldReturnNull_WhenNotFound()
        {
            var repo = new PhoneRepository();

            var result = await repo.GetPhoneByIdAsync(999);

            Assert.Null(result);
        }

        [Fact]
        public async Task UpdatePhoneAsync_ShouldUpdatePhone_WhenExists()
        {
            var repo = new PhoneRepository();
            var added = await repo.AddPhoneAsync(new CreatePhoneRequestDto { Name = "Old", Number = "000" });

            var updated = await repo.UpdatePhoneAsync(added.Id, new UpdatePhoneRequestDto { Name = "New", Number = "999" });

            Assert.NotNull(updated);
            Assert.Equal("New", updated!.Name);
            Assert.Equal("999", updated.Number);
        }

        [Fact]
        public async Task UpdatePhoneAsync_ShouldReturnNull_WhenPhoneNotFound()
        {
            var repo = new PhoneRepository();

            var updated = await repo.UpdatePhoneAsync(123, new UpdatePhoneRequestDto { Name = "New", Number = "999" });

            Assert.Null(updated);
        }

        [Fact]
        public async Task DeletePhoneAsync_ShouldDeletePhone_WhenExists()
        {
            var repo = new PhoneRepository();
            var added = await repo.AddPhoneAsync(new CreatePhoneRequestDto { Name = "ToDelete", Number = "000" });

            var deleted = await repo.DeletePhoneAsync(added.Id);
            var phones = await repo.GetAllPhonesAsync();

            Assert.NotNull(deleted);
            Assert.Empty(phones);
        }

        [Fact]
        public async Task DeletePhoneAsync_ShouldReturnNull_WhenPhoneNotFound()
        {
            var repo = new PhoneRepository();

            var deleted = await repo.DeletePhoneAsync(999);

            Assert.Null(deleted);
        }
    }
}
