using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain {
	/// <summary>
	/// A generically typed response object returned by service methods.
	/// </summary>
	/// <typeparam name="T">The type of the object the response is about.</typeparam>
	public class ServiceResponse<T> {
		/// <summary>
		/// A flag indicating if the operation succeeded.
		/// </summary>
		public bool Success { get; set; }

		/// <summary>
		/// Relevant information about the result of the action.
		/// </summary>
		public string Message { get; set; }

		/// <summary>
		/// The object being returned by the operation.
		/// </summary>
		public T Data { get; set; }
	}

	/// <summary>
	/// A response object returned by service methods.
	/// </summary>
	public class ServiceResponse {
		/// <summary>
		/// A flag indicating if the operation succeeded.
		/// </summary>
		public bool Success { get; set; }

		/// <summary>
		/// Relevant information about the result of the action.
		/// </summary>
		public string Message { get; set; }
	}
}