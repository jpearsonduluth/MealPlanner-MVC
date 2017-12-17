using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using System.Data.Entity;

namespace DataAccess.Repositories {
	/// <summary>
	/// Methods for CRUD operations of MeasureUnits.
	/// </summary>
	public class MeasureUnitsRepo : RepoBase<MeasureUnit> {
		/// <summary>
		/// Gets all MeasureUnits from the DB.
		/// </summary>
		/// <returns>All MeasureUnits from the DB.</returns>
		public override IEnumerable<MeasureUnit> Get() {
			return _context.MeasureUnits;
		}

		/// <summary>
		/// Gets a single MeasureUnit from the DB by its PK Id.
		/// </summary>
		/// <param name="id">The Id of the MeasureUnit to be fetched.</param>
		/// <returns>A single MeasureUnit.</returns>
		public override MeasureUnit Get(int id) {
			return _context.MeasureUnits.SingleOrDefault(r => r.MeasureUnitId == id);
		}

		/// <summary>
		/// Saves the given MeasureUnit to the DB.
		/// </summary>
		/// <param name="MeasureUnit">The MeasureUnit to saved to the db.</param>
		/// <returns>The MeasureUnit, with its PK DB Id populated.</returns>
		public override MeasureUnit Save(MeasureUnit MeasureUnit) {
			if (MeasureUnit.MeasureUnitId > 0) {
				_context.Entry(MeasureUnit).State = EntityState.Modified;
			}
			else {
				_context.MeasureUnits.Add(MeasureUnit);
			}
			_context.SaveChanges();
			return MeasureUnit;
		}

		/// <summary>
		/// Deletes the given MeasureUnit from the DB.
		/// </summary>
		/// <param name="id">The PK Id of the MeasureUnit to be deleted.</param>
		public override void Delete(int id) {
			MeasureUnit toBeDeleted = _context.MeasureUnits.SingleOrDefault(x => x.MeasureUnitId == id);
			if (toBeDeleted != null) {
				_context.MeasureUnits.Remove(toBeDeleted);
				_context.SaveChanges();
			}
		}
	}
}