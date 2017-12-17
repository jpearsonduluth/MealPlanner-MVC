using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess {
	/// <summary>
	/// Base class with Virtual Methods for CRUD operations. Also defines and instantiates the EF context for inheriting repo's.
	/// </summary>
	/// <typeparam name="T">The type of the Entity for which CRUD is being performed.</typeparam>
	public class RepoBase<T> {
		/// <summary>
		/// The EF context.
		/// </summary>
		protected MealPlanEntities _context;

		/// <summary>
		/// Default constructor. Instantiates the EF context.
		/// </summary>
		public RepoBase() {
			_context = new MealPlanEntities();
		}

		/// <summary>
		/// When overridden, returns a single entity by it's PK Id.
		/// </summary>
		/// <param name="id">The PK of the entity to be fetched.</param>
		/// <returns>A single entity of the given type, for the given id.</returns>
		public virtual T Get(int id) {
			throw new NotImplementedException();
		}

		/// <summary>
		/// When overridden, returns all entities of the given type.
		/// </summary>
		/// <returns>All entities of the given type.</returns>
		public virtual IEnumerable<T> Get() {
			throw new NotImplementedException();
		}

		/// <summary>
		/// When overridden, Saves the given entity to the DB.
		/// </summary>
		/// <param name="entity">The entity to be saved.</param>
		/// <returns>The saved entity, with its PK DB id.</returns>
		public virtual T Save(T entity) {
			throw new NotImplementedException();
		}

		/// <summary>
		/// When overridden, Deletes the given entity from the DB.
		/// </summary>
		/// <param name="id">The pk id of the entity to be deleted.</param>
		public virtual void Delete(int id) {
			throw new NotImplementedException();
		}

		public int SaveContext() {
			return _context.SaveChanges();
		}
	}
}