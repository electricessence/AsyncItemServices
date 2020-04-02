using System.Runtime.CompilerServices;

namespace AsyncItemServices
{
	public interface ITaskAwaitable<T>
	{
		/// <summary>
		/// Asynchronous infrastructure support. This method permits instances of <see cref="ITaskAwaitable&lt;T&gt;"/> to be await'ed.
		/// </summary>
		TaskAwaiter<T> GetAwaiter();

		/// <summary>
		/// Asynchronous infrastructure support. This method permits instances of <see cref="ITaskAwaitable&lt;T&gt;"/> to be await'ed.
		/// </summary>
		ConfiguredTaskAwaitable<T> ConfigureAwait(bool continueOnCapturedContext);
	}
}
