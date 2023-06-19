using Entity.Entity;
using Logic.Abstract_Repository;
using Logic.Concrete_Service;
using Moq;
using FluentAssertions;

namespace Test.Services.Category.Read_Tests;

public class GetAllCategoriesTests
{
    [Fact]
    public void GetAll_ReturnsAllCategories()
    {
        // Arrange
        var categories = new List<CategoryModel>
            {
                new CategoryModel { Id = 1, Name = "Category 1" },
                new CategoryModel { Id = 2, Name = "Category 2" }
            };

        var mockRepository = new Mock<ICategoryRepository>();
        mockRepository.Setup(r => r.GetAll()).Returns(categories);

        var categoryService = new CategoryService(mockRepository.Object);

        // Act
        var result = categoryService.GetAll();

        // Assert
        result.Should().NotBeNullOrEmpty();
        result.Should().HaveCount(2);
        result.Should().Contain(categories);
    }
}
