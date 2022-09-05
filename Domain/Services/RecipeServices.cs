using DataAccess;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services {
	/// <summary>
	/// Applies business logic to CRUD operations on Recipes.
	/// </summary>
	public class RecipeServices {
		/// <summary>
		/// Gets all Recipes.
		/// </summary>
		/// <returns>All Recipes.</returns>
		public IEnumerable<Recipe> Get() {
			return new RecipesRepo().Get();
		}

		/// <summary>
		/// Gets a single Recipe by its PK Id.
		/// </summary>
		/// <param name="id">The Id of the Recipe to be fetched.</param>
		/// <returns>A Recipe typed service response.</returns>
		public ServiceResponse<Recipe> Get(int id) {
			ServiceResponse<Recipe> resp = new ServiceResponse<Recipe>();
			Recipe r = new RecipesRepo().Get(id);

			if (r != null) {
				resp.Data = r;
				resp.Success = true;
			}
			else {
				resp.Message = "The given Id appears to be invalid.";
			}

			return resp;
		}

		/// <summary>
		/// Gets the given number of Recipes from, begining at the given seed.
		/// </summary>
		/// <param name="numToReturn">Number of Recipes to return.</param>
		/// <param name="seed">The starting point at which to fetch Recipes.</param>
		/// <returns>A collection of Recipes.</returns>
		public IEnumerable<Models.Recipe> Get(int numToReturn, int seed) {
			return new RecipesRepo().Get(numToReturn, seed).Select(r => new Models.Recipe(r));
		}


		/// <summary>
		/// Saves the given Recipe.
		/// </summary>
		/// <param name="Recipe">The Recipe to saved.</param>
		/// <returns>A typed service response, containing the Recipe, with its PK Id populated.</returns>
		public ServiceResponse<Models.Recipe> Save(Models.Recipe recipe) {
			ServiceResponse<Models.Recipe> resp = new ServiceResponse<Models.Recipe>();
			recipe.Name = recipe.Name.Trim();

			RecipesRepo r = new RecipesRepo();
			if (!r.Get().Any(x => x.RecipeId != recipe.RecipeId && x.Name.ToLower() == recipe.Name.ToLower())) {
				resp.Data = new Models.Recipe(r.Save(recipe.ToRepo()));
				resp.Success = true;
			}
			else {
				resp.Message = "A recipe with this name already exists.";
			}

			return resp;
		}


		/// <summary>
		/// Deletes the given Recipe.
		/// </summary>
		/// <param name="id">The PK Id of the Recipe to be deleted.</param>
		public void Delete(int id) {
			new RecipesRepo().Delete(id);
		}
	}
}