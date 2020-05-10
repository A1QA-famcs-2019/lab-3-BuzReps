using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace Calculator.Automation.Framework.Mappings
{
	public abstract class BaseWindow
	{

		/// <summary>
		/// Window object.
		/// </summary>
		protected Window Window { get; }

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="window">Window.</param>
		protected BaseWindow(Window window)
		{
			Window = window;
		}

		/// <summary>
		/// Get element from window.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="searchCriteria"></param>
		/// <returns></returns>
		protected T GetElement<T>(SearchCriteria searchCriteria) where T : IUIItem
		{
			return Window.Get<T>(searchCriteria);
		}

	}
}
