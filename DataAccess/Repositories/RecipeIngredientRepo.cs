using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using System.Data.Entity;

namespace DataAccess.Repositories {
	/// <summary>
	/// Methods for CRUD operations of RecipeIngredients.
	/// </summary>
	public class RecipeIngredientsRepo : RepoBase<RecipeIngredient> {
		/// <summary>
		/// Gets all RecipeIngredients from the DB.
		/// </summary>
		/// <returns>All RecipeIngredients from the DB.</returns>
		public override IEnumerable<RecipeIngredient> Get() {
			return _context.RecipeIngredients;
		}

		/// <summary>
		/// Gets a single RecipeIngredient from the DB by its PK Id.
		/// </summary>
		/// <param name="id">The Id of the RecipeIngredient to be fetched.</param>
		/// <returns>A single RecipeIngredient.</returns>
		public override RecipeIngredient Get(int id) {
			return _context.RecipeIngredients.SingleOrDefault(r => r.RecipeIngredientId == id);
		}

		public IEnumerable<RecipeIngredient> GetForRecipe(int recipeId) {
			return _context.RecipeIngredients.Where(ri => ri.RecipeId == recipeId);
		}

		/// <summary>
		/// DOES NOT CALL SaveChanges()
		/// </summary>
		/// <param name="idsToDelete"></param>
		public void DeleteUnits(IEnumerable<int> idsToDelete) {
			var toBeDeleted = _context.RecipeIngredients.Where(ri => idsToDelete.Contains(ri.RecipeIngredientId));
			_context.RecipeIngredients.RemoveRange(toBeDeleted);
		}
		/// <summary>
		/// DOES NOT CALL SaveChanges()
		/// </summary>
		/// <param name="toSave"></param>
		public void SaveUnits(IEnumerable<RecipeIngredient> toSave) {
			foreach (var ts in toSave) {
				if (ts.RecipeIngredientId > 0) {
					var entity = _context.RecipeIngredients.Find(ts.RecipeIngredientId);
					_context.Entry(entity).CurrentValues.SetValues(ts);
				}
				else {
					_context.RecipeIngredients.Add(ts);
				}
			}
		}

		/// <summary>
		/// Saves the given RecipeIngredient to the DB.
		/// </summary>
		/// <param name="RecipeIngredient">The RecipeIngredient to saved to the db.</param>
		/// <returns>The RecipeIngredient, with its PK DB Id populated.</returns>
		public override RecipeIngredient Save(RecipeIngredient RecipeIngredient) {
			if (RecipeIngredient.RecipeIngredientId > 0) {
				_context.Entry(RecipeIngredient).State = EntityState.Modified;
			}
			else {
				_context.RecipeIngredients.Add(RecipeIngredient);
			}
			_context.SaveChanges();
			return RecipeIngredient;
		}

		/// <summary>
		/// Deletes the given RecipeIngredient from the DB.
		/// </summary>
		/// <param name="id">The PK Id of the RecipeIngredient to be deleted.</param>
		public override void Delete(int id) {
			RecipeIngredient toBeDeleted = _context.RecipeIngredients.SingleOrDefault(x => x.RecipeIngredientId == id);
			if (toBeDeleted != null) {
				_context.RecipeIngredients.Remove(toBeDeleted);
				_context.SaveChanges();
			}
		}
	}
}