using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace AsyncItemServices
{
	public interface IAsyncResultContainer<T>
	{
		/// <summary>
		/// The resultant task created by the factory.
		/// </summary>
		Task<T> Task { get; }

		/// <summary>
		/// Asynchronous infrastructure support. This method permits instances of <see cref="IAsyncResultContainer&lt;T&gt;"/> to be await'ed.
		/// </summary>
		public TaskAwaiter<T> GetAwaiter() => Task.GetAwaiter();

		/// <summary>
		/// Asynchronous infrastructure support. This method permits instances of <see cref="IAsyncResultContainer&lt;T&gt;"/> to be await'ed.
		/// </summary>
		public ConfiguredTaskAwaitable<T> ConfigureAwait(bool continueOnCapturedContext) => Task.ConfigureAwait(continueOnCapturedContext);
	}
}
