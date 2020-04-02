using System.Threading.Tasks;

namespace AsyncItemServices
{
	public interface IAsyncReadOnlyTextItem
	{
		/// <summary>
		/// Retrieves the text of the item.
		/// </summary>
		/// <returns>The value task containing the asynchronus text value.</returns>
		ValueTask<string> GetText();
	}
}
