using Entity.Entity;
using FluentAssertions;
using Logic.Abstract_Repository;
using Logic.Concrete_Service;
using Moq;
using System.Net;

namespace Test.Services.Category.Create_Tests;

public class CreateCategoryTests
{
    [Fact]
    public void Create_ValidCategory_CreatesEntityWithSpecifiedProperties()
    {
        // Arrange
        var category = new CategoryModel { Name = "Category 1" };
        var createdEntity = new CategoryModel { Id = 1, Name = "Category 1" };

        var mockRepository = new Mock<ICategoryRepository>();
        mockRepository.Setup(r => r.Create(category)).Returns(HttpStatusCode.OK);
        mockRepository.Setup(r => r.GetById(1)).Returns(createdEntity);

        var categoryService = new CategoryService(mockRepository.Object);

        // Act
        var result = categoryService.Create(category);

        // Assert
        result.Should().Be(HttpStatusCode.Created);

        // Verify that the entity was created with the specified properties
        mockRepository.Verify(r => r.Create(category), Times.Once);
        mockRepository.Verify(r => r.GetById(1), Times.Once);
    }
}
