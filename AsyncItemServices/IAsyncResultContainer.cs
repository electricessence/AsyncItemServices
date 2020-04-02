using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace AsyncItemServices
{
	public interface IAsyncResultContainer<T> : ITaskAwaitable<T>, IAsyncReadOnlyItem<T>
	{
		/// <summary>
		/// The resultant task created by the factory.
		/// </summary>
		Task<T> Task { get; }

		/// <inheritdoc />
		ValueTask<T> IAsyncReadOnlyItem<T>.Get()
			=> new ValueTask<T>(Task);

		/// <inheritdoc />
		ConfiguredTaskAwaitable<T> ITaskAwaitable<T>.ConfigureAwait(bool continueOnCapturedContext)
			=> Task.ConfigureAwait(continueOnCapturedContext);

		/// <inheritdoc />
		TaskAwaiter<T> ITaskAwaitable<T>.GetAwaiter()
			=> Task.GetAwaiter();
	}
}

