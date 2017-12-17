using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {
	[Serializable]
	public class Recipe {
		public int RecipeId { get; set; }
		public string Name { get; set; }
		public int Rating { get; set; }
		public string Description { get; set; }
		public string Directions { get; set; }
		public string ImageUrl { get; set; }

		public Recipe() { }
		public Recipe(DataAccess.Recipe recipe) {
			this.RecipeId = recipe.RecipeId;
			this.Name = recipe.Name;
			this.Rating = recipe.Rating.Value;
			this.Description = recipe.Description;
			this.Directions = recipe.Directions;
			this.ImageUrl = recipe.ImageUrl;
		}
		public DataAccess.Recipe ToRepo() {
			return new DataAccess.Recipe {
				RecipeId = this.RecipeId,
				Name = this.Name,
				Rating = this.Rating,
				Description = this.Description,
				Directions = this.Directions,
				ImageUrl = this.ImageUrl
			};
		}

		public IEnumerable<RecipeIngredient> RecipeIngredients {
			get {
				return null; //new Services.RecipeIngredientServices().ge
			}
		}
	}
}
