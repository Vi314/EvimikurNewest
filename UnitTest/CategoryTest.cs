
using Entity.Entity;
using FluentAssertions;
using Logic.Abstract_Service;
using Logic.Concrete_Repository;
using Logic.Concrete_Service;

namespace UnitTest;

public class CategoryTest
{
    private readonly CategoryService _service = new CategoryService(new CategoryRepository(new DataAccess.Context(default)));
    
    [Fact]
    public void Get_All_Method_Must_Return_ListCategory()
    {
        var productList = _service.GetAll().ToList();
        
        productList.Should().AllBeOfType<CategoryModel>();
        productList.Should().NotBeNull();
        productList.Should().BeOfType<List<CategoryModel>>();

    }
}