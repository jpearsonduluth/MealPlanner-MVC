using DataAccess;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services {
	/// <summary>
	/// Applies business logic to CRUD operations on MeasureUnits.
	/// </summary>
	public class MeasureUnitServices {
		/// <summary>
		/// Gets all MeasureUnits.
		/// </summary>
		/// <returns>All MeasureUnits.</returns>
		public IEnumerable<MeasureUnit> Get() {
			return new MeasureUnitsRepo().Get();
		}

		/// <summary>
		/// Gets a single MeasureUnit by its PK Id.
		/// </summary>
		/// <param name="id">The Id of the MeasureUnit to be fetched.</param>
		/// <returns>A MeasureUnit typed service response.</returns>
		public ServiceResponse<MeasureUnit> Get(int id) {
			ServiceResponse<MeasureUnit> resp = new ServiceResponse<MeasureUnit>();
			MeasureUnit r = new MeasureUnitsRepo().Get(id);

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
		/// Saves the given MeasureUnit.
		/// </summary>
		/// <param name="MeasureUnit">The MeasureUnit to saved.</param>
		/// <returns>A typed service response, containing the MeasureUnit, with its PK Id populated.</returns>
		public ServiceResponse<MeasureUnit> Save(MeasureUnit MeasureUnit) {
			ServiceResponse<MeasureUnit> resp = new ServiceResponse<MeasureUnit>();
			MeasureUnit.Name = MeasureUnit.Name.Trim();

			MeasureUnitsRepo r = new MeasureUnitsRepo();
			if (!r.Get().Any(x => x.Name.ToLower() == MeasureUnit.Name.ToLower())) {
				resp.Data = r.Save(MeasureUnit);
				resp.Success = true;
			}
			else {
				resp.Message = "A MeasureUnit with this name already exists.";
			}

			return resp;
		}


		/// <summary>
		/// Deletes the given MeasureUnit.
		/// </summary>
		/// <param name="id">The PK Id of the MeasureUnit to be deleted.</param>
		public void Delete(int id) {
			new MeasureUnitsRepo().Delete(id);
		}
	}
}