using Entity.Entity;
using MVC.Areas.Entities.Models.MapperAbstract;
using MVC.Areas.Entities.Models.ViewModels;

namespace MVC.Areas.Entities.Models.MapperConcrete
{
	public class ProductMapper : IProductMapper
	{
		public ProductDTO FromProduct(Product product, IEnumerable<Category> categories)
		{
			ProductDTO productDTO = new ProductDTO
			{
				Id = product.Id,
				Name = product.ProductName,
				Description = product.Description,
				FunctionalityGrade = product.FunctionalityGrade,
				PotentialSalesGrade = product.PotentialSalesGrade,
				PriceAdvantageGrade = product.PriceAdvantageGrade,
				InnovativeGrade = product.InnovativeGrade,
				LooksGrade = product.LooksGrade,
				UsabilityGrade = product.UsabilityGrade,
			};

			if (product.CategoryId != null)
			{
				productDTO.Category = categories.Where(x => x.Id == product.CategoryId).Select(x => x.Name).FirstOrDefault();
			}
			return productDTO;
		}

		public Product ToProduct(ProductDTO productDTO, IEnumerable<Category> categories)
		{
			Product product = new Product
			{
				Id = productDTO.Id,
				ProductName = productDTO.Name,
				Description = productDTO.Description,
				PotentialSalesGrade = productDTO.PotentialSalesGrade,
				FunctionalityGrade = productDTO.FunctionalityGrade,
				LooksGrade = productDTO.LooksGrade,
				InnovativeGrade = productDTO.InnovativeGrade,
				PriceAdvantageGrade = productDTO.PriceAdvantageGrade,
				UsabilityGrade = productDTO.UsabilityGrade,
			};

			if (productDTO.Category != null)
			{
				product.CategoryId = categories.Where(x => x.Name == productDTO.Category).Select(x => x.Id).FirstOrDefault();
			}

			return product;
		}
	}
}
