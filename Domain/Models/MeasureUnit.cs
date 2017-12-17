using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {
	[Serializable]
	public class MeasureUnit {
		public int MeasureUnitId { get; set; }
		public string Name { get; set; }

		public MeasureUnit() { }
		public MeasureUnit(DataAccess.MeasureUnit measureUnit) {
			this.MeasureUnitId = measureUnit.MeasureUnitId;
			this.Name = measureUnit.Name;
		}
		public DataAccess.MeasureUnit ToRepo() {
			return new DataAccess.MeasureUnit {
				MeasureUnitId = this.MeasureUnitId,
				Name = this.Name
			};
		}
	}
}
