using Entity.Entity;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperAbstract
{
	public interface IProductMapper
	{
		public Product ToProduct(ProductDTO productDTO, IEnumerable<Category> categories);
		public ProductDTO FromProduct(Product product, IEnumerable<Category> categories);

	}
}
