
using Entity.Entity;
using FluentAssertions;
using Logic.Abstract_Repository;
using Logic.Abstract_Service;
using Logic.Concrete_Repository;
using Logic.Concrete_Service;
using Moq;
using System.Net;
using Xunit;

namespace UnitTest;

/// <summary>
/// These tests have been written completely by gpt to have as a ground for learning the basics
/// </summary>
public class Category_Test
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

    [Fact]
    public void Update_ValidCategory_UpdatesEntityWithSpecifiedProperties()
    {
        // Arrange
        var category = new CategoryModel { Id = 1, Name = "Updated Category" };
        var existingEntity = new CategoryModel { Id = 1, Name = "Existing Category" };

        var mockRepository = new Mock<ICategoryRepository>();
        mockRepository.Setup(r => r.GetById(1)).Returns(existingEntity);
        mockRepository.Setup(r => r.Update(existingEntity)).Returns(HttpStatusCode.OK);

        var categoryService = new CategoryService(mockRepository.Object);

        // Act
        var result = categoryService.Update(category);

        // Assert
        result.Should().Be(HttpStatusCode.OK);

        // Verify that the entity was updated with the specified properties
        mockRepository.Verify(r => r.GetById(1), Times.Once);
        mockRepository.Verify(r => r.Update(existingEntity), Times.Once);
        existingEntity.Name.Should().Be(category.Name);
    }

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