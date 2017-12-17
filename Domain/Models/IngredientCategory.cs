using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {
	[Serializable]
	public class IngredientCategory {
		public int IngredientCategoryId { get; set; }
		public string Name { get; set; }

		public IngredientCategory() { }
		public IngredientCategory(DataAccess.IngredientCategory IngredientCategory) {
			this.IngredientCategoryId = IngredientCategory.IngredientCategoryId;
			this.Name = IngredientCategory.Name;
		}
		public DataAccess.IngredientCategory ToRepo() {
			return new DataAccess.IngredientCategory {
				IngredientCategoryId = this.IngredientCategoryId,
				Name = this.Name
			};
		}
	}
}
