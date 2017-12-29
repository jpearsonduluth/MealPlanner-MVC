using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MealPlanner.Models {
	public class IndexVM {
		public IEnumerable<IngredientVM> Ingredients { get; set; }
		public IEnumerable<MeasureUnitVM> MeasureUnits { get; set; }
		public IEnumerable<IngredientCategoryVM> IngredientCategories { get; set; }
	}
	public class RecipeVM {
		public int RecipeId { get; set; }
		public string Name { get; set; }
		public int Rating { get; set; }
		public string Description { get; set; }
		public string Directions { get; set; }
		public string ImageUrl { get; set; }
		public IEnumerable<RecipeIngredientVM> Ingredients { get; set; }

		public RecipeVM() {
			Ingredients = new List<RecipeIngredientVM>();
		}
	}
	public class RecipeIngredientVM : IngredientVM {
		public int Quantity { get; set; }
		public int MeasureUnitId { get; set; }
	}
	public class IngredientVM {
		public int IngredientId { get; set; }
		public string Name { get; set; }
		public int CategoryId { get; set; }
	}

	public class MeasureUnitVM {
		public int MeasureUnitId { get; set; }
		public string Name { get; set; }
	}

	public class IngredientCategoryVM {
		public int IngredientCategoryId { get; set; }
		public string Name { get; set; }
	}
}