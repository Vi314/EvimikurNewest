using Entity.Entity;
using Logic.Abstract_Repository;
using Logic.Concrete_Service;
using Moq;
using FluentAssertions;

namespace Test.Services.Category.Read_Tests;

public class GetByIdTests
{
    [Fact]
    public void GetById_ExistingId_ReturnsExpectedCategory()
    {
        // Arrange
        int categoryId = 1;
        var expectedCategory = new CategoryModel { Id = categoryId, Name = "Category 1" };

        var mockRepository = new Mock<ICategoryRepository>();
        mockRepository.Setup(r => r.GetById(categoryId)).Returns(expectedCategory);

        var categoryService = new CategoryService(mockRepository.Object);

        // Act
        var result = categoryService.GetById(categoryId);

        // Assert
        result.Should().BeEquivalentTo(expectedCategory);
    }

    [Fact]
    public void GetById_NonExistingId_ReturnsNull()
    {
        // Arrange
        int categoryId = 100;

        var mockRepository = new Mock<ICategoryRepository>();
        mockRepository.Setup(r => r.GetById(categoryId)).Returns((CategoryModel)null);

        var categoryService = new CategoryService(mockRepository.Object);

        // Act
        var result = categoryService.GetById(categoryId);

        // Assert
        result.Should().BeNull();
    }
}
