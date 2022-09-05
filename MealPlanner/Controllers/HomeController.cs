using Domain.Services;
using Domain.Models;
using MealPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MealPlanner.Controllers {
	public class HomeController : Controller {
		[HttpGet]
		public ActionResult Index() {
			var vm = new IndexVM();
			vm.MeasureUnits = new MeasureUnitServices().Get().Select(m => new MeasureUnitVM { MeasureUnitId = m.MeasureUnitId, Name = m.Name });
			vm.IngredientCategories = new IngredientCategoryServices().Get().Select(m => new IngredientCategoryVM { IngredientCategoryId = m.IngredientCategoryId, Name = m.Name });

			return View(vm);
		}

		[HttpGet]
		public JsonResult GetRecipes(int recipieCount, int seed) {
			return Json(new RecipeServices().Get(recipieCount, seed), JsonRequestBehavior.AllowGet);
		}

		[HttpGet]
		public JsonResult GetRecipeIngredients(int recipeId) {
			return Json(new RecipeIngredientServices().GetForRecipe(recipeId).Select(i => new Models.RecipeIngredientVM {
				Name = i.Ingredient.Name,
				IngredientId = i.IngredientId,
				Quantity = i.Quantity,
				MeasureUnitId = i.MeasureUnitId
			}), JsonRequestBehavior.AllowGet);
		}

		[HttpPost]
		public JsonResult SaveRecipe(RecipeVM recipe) {
			var rResp = new RecipeServices().Save(new Recipe {
				RecipeId = recipe.RecipeId,
				Name = recipe.Name,
				Rating = recipe.Rating,
				Description = recipe.Description,
				Directions = recipe.Directions,
				ImageUrl = recipe.ImageUrl
			});

			if(rResp.Success) {
				new RecipeIngredientServices().Save(
					rResp.Data.RecipeId, 
					recipe.Ingredients.Select(ri => new Domain.Models.RecipeIngredient {
						RecipeId = rResp.Data.RecipeId,
						IngredientId = ri.IngredientId,
						MeasureUnitId = ri.MeasureUnitId,
						Quantity = ri.Quantity
					}).ToList()
				);
			}
			else {
				return Json(new { Success = false, Message = rResp.Message });
			}

			return Json(new { Success = true, Data = rResp.Data.RecipeId });
		}

		[HttpGet]
		public JsonResult GetIngredients(int categoryId) {
			return Json(new IngredientServices().GetByCategory(categoryId), JsonRequestBehavior.AllowGet);
		}

		[HttpPost]
		public JsonResult SaveIngredient(IngredientVM ingredient) {
			var iResp = new IngredientServices().Save(new Ingredient { IngredientId = ingredient.IngredientId, Name = ingredient.Name,IngredientCategoryId = ingredient.CategoryId });

			if (!iResp.Success) {
				return Json(new { Success = false, Message = iResp.Message });
			}

			return Json(new { Success = true, Data = iResp.Data });
		}

		[HttpPost]
		public JsonResult SaveMeasureUnit(MeasureUnitVM measureUnit) {
			var mResp = new MeasureUnitServices().Save(new MeasureUnit { MeasureUnitId = measureUnit.MeasureUnitId, Name = measureUnit.Name });

			if (!mResp.Success) {
				return Json(new { Success = false, Message = mResp.Message });
			}

			return Json(new { Success = true, Data = mResp.Data.MeasureUnitId });
		}
	}
}