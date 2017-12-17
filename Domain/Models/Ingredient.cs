using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {
	[Serializable]
	public class Ingredient {
		public int IngredientId { get; set; }
		public string Name { get; set; }
		public int IngredientCategoryId { get; set; }

		public Ingredient() { }
		public Ingredient(DataAccess.Ingredient ingredient) {
			this.IngredientId = ingredient.IngredientId;
			this.Name = ingredient.Name;
			this.IngredientCategoryId = ingredient.IngredientCategoryId;
		}
		public DataAccess.Ingredient ToRepo() {
			return new DataAccess.Ingredient {
				IngredientId = this.IngredientId,
				Name = this.Name,
				IngredientCategoryId = this.IngredientCategoryId
			};
		}
	}
}
