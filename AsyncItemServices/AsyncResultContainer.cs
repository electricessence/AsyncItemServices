using System.Threading.Tasks;

namespace AsyncItemServices
{
	public class AsyncResultContainer<T> : IAsyncResultContainer<T>
	{
		public AsyncResultContainer(Task<T> task)
		{
			Task = task;
		}

		/// <inheritdoc />
		public virtual Task<T> Task { get; }
	}

	public static class AsyncResultContainer
	{
		/// <summary>
		/// Creates an AsyncResultContainer using a provided task.
		/// </summary>
		/// <typeparam name="T">The type of the value returned from the Task.</typeparam>
		/// <param name="task">The task to be stored by the container.</param>
		/// <returns>The AsyncResultContainer requested.</returns>
		public static AsyncResultContainer<T> From<T>(Task<T> task)
			=> new AsyncResultContainer<T>(task);
	}
}
