using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AsyncItemServices
{
	/**
	 * Based upon Stephen Cleary's Nito.AsyncEx.Coordination.AsyncLazy and Microsoft.VisualStudio.Threading.AsyncLazy.
	 */

	/// <summary>
	/// A container for a syncrhonized and lazily acquired Task.
	/// </summary>
	/// <typeparam name="T">The value type of the task.</typeparam>
	public sealed class AsyncLazy<T> : AsyncResultContainer<T>
	{
		private readonly object _sync = new object();
		private Func<Task<T>>? _factory;
		private Task<T>? _task;

		public AsyncLazy(Func<Task<T>> factory)
			: base(default!) // Task is fully overridden here.
		{
			_factory = factory ?? throw new ArgumentNullException(nameof(factory));
		}

		/// <summary>
		/// Gets a value indicating whether the value factory has been invoked.
		/// </summary>
		public bool IsValueCreated => _factory is null;

		/// <summary>
		/// Gets a value indicating whether the value factory has been invoked and has run to completion.
		/// </summary>
		public bool IsValueFactoryCompleted => _task?.IsCompleted ?? false;

		/// <inheritdoc />
		public override Task<T> Task
		{
			get
			{
				var task = _task;
				if (task != null) return task;
				lock (_sync)
				{
					task = _task;
					if (task != null) return task;

					var factory = _factory;
					Debug.Assert(factory != null);
					_factory = null; // Setting this to null indicates that it has been invoked.
					_task = task = factory();
				}
				return task;
			}
		}
	}

	public static class AsyncLazy
	{
		/// <summary>
		/// Creates an AsyncLazy that ensures the factory function is only executed once.
		/// </summary>
		/// <typeparam name="T">The type of the value returned from the Task.</typeparam>
		/// <param name="factory">The factory function that generates the task.</param>
		/// <returns>The AsyncLazy requested.</returns>
		public static AsyncLazy<T> Create<T>(Func<Task<T>> factory)
			=> new AsyncLazy<T>(factory);

		/// <summary>
		/// Creates an AsyncLazy that ensures the ValueTask factory function is only executed once and guarantees that execution is deffered.
		/// </summary>
		/// <typeparam name="T">The type of the value returned from the Task.</typeparam>
		/// <param name="factory">The factory function that generates the task.</param>
		/// <returns>The AsyncLazy requested.</returns>
		public static AsyncLazy<T> CreateDeferred<T>(Func<ValueTask<T>> factory)
			=> Create(async () =>
			{
				await Task.Yield();
				return await factory();
			});

		/// <summary>
		/// Creates an AsyncLazy that ensures the Task factory function is only executed once and guarantees that execution is deffered.
		/// </summary>
		/// <typeparam name="T">The type of the value returned from the Task.</typeparam>
		/// <param name="factory">The factory function that generates the task.</param>
		/// <returns>The AsyncLazy requested.</returns>
		public static AsyncLazy<T> CreateDeferredTask<T>(Func<Task<T>> factory)
			=> Create(async () =>
			{
				await Task.Yield();
				return await factory();
			});
	}
}
