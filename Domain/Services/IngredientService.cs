using DataAccess;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services {
	/// <summary>
	/// Applies business logic to CRUD operations on Ingredients.
	/// </summary>
	public class IngredientServices {
		/// <summary>
		/// Gets all Ingredients.
		/// </summary>
		/// <returns>All Ingredients.</returns>
		public IEnumerable<Models.Ingredient> Get() {
			return new IngredientsRepo().Get().Select(x => new Models.Ingredient(x));
		}

		/// <summary>
		/// Gets a single Ingredient by its PK Id.
		/// </summary>
		/// <param name="id">The Id of the Ingredient to be fetched.</param>
		/// <returns>A Ingredient typed service response.</returns>
		public Models.Ingredient Get(int id) {
			return Get().SingleOrDefault(i => i.IngredientId == id);
		}

		public IEnumerable<Models.Ingredient> GetByCategory(int categoryId) {
			return Get().Where(i => i.IngredientCategoryId == categoryId);
		}

		/// <summary>
		/// Saves the given Ingredient.
		/// </summary>
		/// <param name="Ingredient">The Ingredient to saved.</param>
		/// <returns>A typed service response, containing the Ingredient, with its PK Id populated.</returns>
		public ServiceResponse<Models.Ingredient> Save(Models.Ingredient Ingredient) {
			ServiceResponse<Models.Ingredient> resp = new ServiceResponse<Models.Ingredient>();
			Ingredient.Name = Ingredient.Name.Trim();

			IngredientsRepo r = new IngredientsRepo();
			if (!r.Get().Any(x => x.Name.ToLower() == Ingredient.Name.ToLower())) {
				resp.Data = new Models.Ingredient(r.Save(Ingredient.ToRepo()));
				resp.Success = true;
			}
			else {
				resp.Message = "A Ingredient with this name already exists.";
			}

			return resp;
		}


		/// <summary>
		/// Deletes the given Ingredient.
		/// </summary>
		/// <param name="id">The PK Id of the Ingredient to be deleted.</param>
		public void Delete(int id) {
			new IngredientsRepo().Delete(id);
		}
	}
}