using DataAccess;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services {
	/// <summary>
	/// Applies business logic to CRUD operations on RecipeIngredients.
	/// </summary>
	public class RecipeIngredientServices {
		/// <summary>
		/// Gets all RecipeIngredients.
		/// </summary>
		/// <returns>All RecipeIngredients.</returns>
		public IEnumerable<RecipeIngredient> Get() {
			return new RecipeIngredientsRepo().Get();
		}

		/// <summary>
		/// Gets a single RecipeIngredient by its PK Id.
		/// </summary>
		/// <param name="id">The Id of the RecipeIngredient to be fetched.</param>
		/// <returns>A RecipeIngredient typed service response.</returns>
		public ServiceResponse<RecipeIngredient> Get(int id) {
			ServiceResponse<RecipeIngredient> resp = new ServiceResponse<RecipeIngredient>();
			RecipeIngredient r = new RecipeIngredientsRepo().Get(id);

			if (r != null) {
				resp.Data = r;
				resp.Success = true;
			}
			else {
				resp.Message = "The given Id appears to be invalid.";
			}

			return resp;
		}


		public IEnumerable<Models.RecipeIngredient> GetForRecipe(int recipeId) {
			return new RecipeIngredientsRepo().GetForRecipe(recipeId).Select(ri => new Models.RecipeIngredient(ri));
		}

		/// <summary>
		/// Saves the given RecipeIngredient.
		/// </summary>
		/// <param name="RecipeIngredient">The RecipeIngredient to saved.</param>
		/// <returns>A typed service response, containing the RecipeIngredient, with its PK Id populated.</returns>
		public ServiceResponse Save(int recipeId, List<Models.RecipeIngredient> recipeIngredients) {
			ServiceResponse resp = new ServiceResponse();

			var ingrIds = recipeIngredients.Select(ri => ri.IngredientId);
			var existing = GetForRecipe(recipeId);
			var deleteList = existing.Where(x => !ingrIds.Contains(x.IngredientId)).Select(d => d.RecipeIngredientId);

			Models.RecipeIngredient match;
			for (int i = 0; i < recipeIngredients.Count(); i++) {
				match = existing.SingleOrDefault(x => x.IngredientId == recipeIngredients[i].IngredientId);
				if(match != null) {
					recipeIngredients[i].RecipeIngredientId = match.RecipeIngredientId;
				}
			}

			RecipeIngredientsRepo r = new RecipeIngredientsRepo();
			
			r.DeleteUnits(deleteList);
			r.SaveUnits(recipeIngredients.Select(ri => ri.ToRepo()));
			r.SaveContext();

			resp.Success = true;
			return resp;
		}


		/// <summary>
		/// Deletes the given RecipeIngredient.
		/// </summary>
		/// <param name="id">The PK Id of the RecipeIngredient to be deleted.</param>
		public void Delete(int id) {
			new RecipeIngredientsRepo().Delete(id);
		}
	}
}