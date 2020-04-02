using System.Threading.Tasks;

namespace AsyncItemServices
{
	public interface IAsyncItem<T> : IAsyncReadOnlyItem<T>
	{
		/// <summary>
		/// Updates the value of the item.
		/// </summary>
		/// <param name="item">The item value to update.</param>
		ValueTask Update(T item);
	}
}
