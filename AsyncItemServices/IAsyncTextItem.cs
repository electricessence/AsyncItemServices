using System.Threading.Tasks;

namespace AsyncItemServices
{
	public interface IAsyncTextItem
	{
		ValueTask UpdateText(string item);
	}
}
