using DataAccess;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services {
	/// <summary>
	/// Applies business logic to CRUD operations on IngredientCategories.
	/// </summary>
	public class IngredientCategoryServices {
		/// <summary>
		/// Gets all IngredientCategories.
		/// </summary>
		/// <returns>All IngredientCategories.</returns>
		public IEnumerable<IngredientCategory> Get() {
			return new IngredientCategoriesRepo().Get();
		}

		/// <summary>
		/// Gets a single IngredientCategory by its PK Id.
		/// </summary>
		/// <param name="id">The Id of the IngredientCategory to be fetched.</param>
		/// <returns>A IngredientCategory typed service response.</returns>
		public ServiceResponse<IngredientCategory> Get(int id) {
			ServiceResponse<IngredientCategory> resp = new ServiceResponse<IngredientCategory>();
			IngredientCategory r = new IngredientCategoriesRepo().Get(id);

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
		/// Saves the given IngredientCategory.
		/// </summary>
		/// <param name="IngredientCategory">The IngredientCategory to saved.</param>
		/// <returns>A typed service response, containing the IngredientCategory, with its PK Id populated.</returns>
		public ServiceResponse<IngredientCategory> Save(IngredientCategory IngredientCategory) {
			ServiceResponse<IngredientCategory> resp = new ServiceResponse<IngredientCategory>();
			IngredientCategory.Name = IngredientCategory.Name.Trim();

			IngredientCategoriesRepo r = new IngredientCategoriesRepo();
			if (!r.Get().Any(x => x.Name.ToLower() == IngredientCategory.Name.ToLower())) {
				resp.Data = r.Save(IngredientCategory);
				resp.Success = true;
			}
			else {
				resp.Message = "A IngredientCategory with this name already exists.";
			}

			return resp;
		}


		/// <summary>
		/// Deletes the given IngredientCategory.
		/// </summary>
		/// <param name="id">The PK Id of the IngredientCategory to be deleted.</param>
		public void Delete(int id) {
			new IngredientCategoriesRepo().Delete(id);
		}
	}
}