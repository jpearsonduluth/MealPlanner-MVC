using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {
	[Serializable]
	public class RecipeIngredient {
		public int RecipeIngredientId { get; set; }
		public int RecipeId { get; set; }
		public int IngredientId { get; set; }
		public int MeasureUnitId { get; set; }
		public int Quantity { get; set; }

		public RecipeIngredient() { }
		public RecipeIngredient(DataAccess.RecipeIngredient recipeIngredient) {
			this.RecipeIngredientId = recipeIngredient.RecipeIngredientId;
			this.RecipeId = recipeIngredient.RecipeIngredientId;
			this.IngredientId = recipeIngredient.IngredientId;
			this.MeasureUnitId = recipeIngredient.MeasureUnitId;
			this.Quantity = recipeIngredient.Quantity;
		}
		public DataAccess.RecipeIngredient ToRepo() {
			return new DataAccess.RecipeIngredient {
				RecipeIngredientId = this.RecipeIngredientId,
				RecipeId = this.RecipeId,
				IngredientId = this.IngredientId,
				MeasureUnitId = this.MeasureUnitId,
				Quantity = this.Quantity
			};
		}

		public Models.Ingredient Ingredient {
			get {
				return new Services.IngredientServices().Get(this.IngredientId);
			}
		}
	}
}
