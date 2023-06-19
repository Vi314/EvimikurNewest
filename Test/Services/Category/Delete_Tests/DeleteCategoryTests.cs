using Entity.Entity;
using Logic.Abstract_Repository;
using Logic.Concrete_Service;
using Moq;
using System.Net;
using FluentAssertions;

namespace Test.Services.Category.Delete_Tests;

public class DeleteCategoryTests
{
    [Fact]
    public void Delete_ExistingId_DeletesEntity()
    {
        // Arrange
        int categoryId = 1;
        var existingEntity = new CategoryModel { Id = categoryId, Name = "Existing Category" };

        var mockRepository = new Mock<ICategoryRepository>();
        mockRepository.Setup(r => r.GetById(categoryId)).Returns(existingEntity);
        mockRepository.Setup(r => r.Delete(categoryId)).Returns(HttpStatusCode.OK);

        var categoryService = new CategoryService(mockRepository.Object);

        // Act
        var result = categoryService.Delete(categoryId);

        // Assert
        result.Should().Be(HttpStatusCode.OK);

        // Verify that the entity was deleted
        mockRepository.Verify(r => r.GetById(categoryId), Times.Once);
        mockRepository.Verify(r => r.Delete(categoryId), Times.Once);
    }
}
