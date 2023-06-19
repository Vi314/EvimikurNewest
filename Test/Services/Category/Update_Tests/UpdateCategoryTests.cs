using Entity.Entity;
using FluentAssertions;
using Logic.Abstract_Repository;
using Logic.Abstract_Service;
using Logic.Concrete_Service;
using Moq;
using System.Net;

namespace Test.Services.Category.Update_Tests;

public class UpdateCategoryTests
{
    [Fact]
    public void Update_ValidCategory_UpdatesEntityWithSpecifiedProperties()
    {
        // Arrange
        var category = new CategoryModel { Id = 1, Name = "Updated Category", Description = "xxxxxxx", CreatedDate = DateTime.MaxValue, State = 0 };
        var existingEntity = new CategoryModel { Id = 1, Name = "Existing Category", Description = "yyyyyyy", CreatedDate = DateTime.MinValue, State = 0 };

        var mockRepository = new Mock<ICategoryRepository>();
        mockRepository.Setup(r => r.GetById(1))         .Returns(existingEntity);
        mockRepository.Setup(r => r.Update (category))  .Returns(HttpStatusCode.OK);
        
        var categoryService = new CategoryService(mockRepository.Object);
        // Act
        var result = categoryService.Update(category);

        // Assert
        result.Should().Be(HttpStatusCode.OK);
        categoryService.GetById(1).Should().Be(existingEntity);

        //Verify that the entity was updated with the specified properties
        mockRepository.Verify(r => r.GetById(1), Times.Once);
        mockRepository.Verify(r => r.Update(category), Times.Once);

        //var updatedCategory = categoryService.GetById(1);
        //    updatedCategory.Name        .Should().Be(category.Name);
        //    updatedCategory.CreatedDate .Should().Be(category.CreatedDate);
        //    updatedCategory.State       .Should().Be(category.State);
        //    updatedCategory.Description .Should().Be(category.Description);

    }

}
