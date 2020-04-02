using System.Threading.Tasks;

namespace AsyncItemServices
{
	public interface IAsyncReadOnlyItem<T>
	{
		/// <summary>
		/// Retrieves the value of the item.
		/// </summary>
		/// <returns>The value task containing the asynchronus value.</returns>
		ValueTask<T> Get();
	}
}
