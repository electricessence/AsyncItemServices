using System.Runtime.CompilerServices;

namespace AsyncItemServices
{
	public interface IValueTaskAwaitable<T>
	{
		/// <summary>
		/// Asynchronous infrastructure support. This method permits instances of <see cref="IValueTaskAwaitable&lt;T&gt;"/> to be await'ed.
		/// </summary>
		ValueTaskAwaiter<T> GetAwaiter();

		/// <summary>
		/// Asynchronous infrastructure support. This method permits instances of <see cref="IValueTaskAwaitable&lt;T&gt;"/> to be await'ed.
		/// </summary>
		ConfiguredValueTaskAwaitable<T> ConfigureAwait(bool continueOnCapturedContext);
	}

}
