using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using System.Data.Entity;

namespace DataAccess.Repositories {
	/// <summary>
	/// Methods for CRUD operations of Recipes.
	/// </summary>
	public class RecipesRepo : RepoBase<Recipe> {
		/// <summary>
		/// Gets all Recipes from the DB.
		/// </summary>
		/// <returns>All Recipes from the DB.</returns>
		public override IEnumerable<Recipe> Get() {
			return _context.Recipes;
		}

		/// <summary>
		/// Gets a single Recipe from the DB by its PK Id.
		/// </summary>
		/// <param name="id">The Id of the Recipe to be fetched.</param>
		/// <returns>A single Recipe.</returns>
		public override Recipe Get(int id) {
			return _context.Recipes.SingleOrDefault(r => 
				r.RecipeId == id);
		}

		/// <summary>
		/// Gets the given number of Recipes from the DB, begining at the given seed.
		/// </summary>
		/// <param name="numToReturn">Number of Recipes to return.</param>
		/// <param name="seed">The starting point at which to fetch Recipes.</param>
		/// <returns>A collection of Recipes.</returns>
		public IEnumerable<Recipe> Get(int numToReturn, int seed) {
			return (
				from r in _context.Recipes
				where r.RecipeId >= seed
				orderby r.RecipeId
				select r
			).Take(numToReturn);
		}

		/// <summary>
		/// Saves the given Recipe to the DB.
		/// </summary>
		/// <param name="recipe">The Recipe to saved to the db.</param>
		/// <returns>The Recipe, with its PK DB Id populated.</returns>
		public override Recipe Save(Recipe recipe) {
			if(recipe.RecipeId > 0) {
				var entity = _context.Recipes.Find(recipe.RecipeId);
				_context.Entry(entity).CurrentValues.SetValues(recipe);
			}
			else {
				_context.Recipes.Add(recipe);
			}
			_context.SaveChanges();
			return recipe;
		}

		/// <summary>
		/// Deletes the given Recipe from the DB.
		/// </summary>
		/// <param name="id">The PK Id of the Recipe to be deleted.</param>
		public override void Delete(int id) {
			Recipe toBeDeleted = _context.Recipes.SingleOrDefault(x => x.RecipeId == id);
			if (toBeDeleted != null) {
				_context.Recipes.Remove(toBeDeleted);
				_context.SaveChanges();
			}
		}
	}
}