using Calculator.Automation.Framework.Util;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace Calculator.Automation.Framework.Mappings
{
	public class MemoryKeypad : BaseWindow
	{
		public Button ButtonMemoryStore { get => GetElement<Button>(SearchCriteria.ByAutomationId(ResourceManager.CalculatorKeypadMemoryButtonStoreId)); }
		public Button ButtonMemoryAdd { get => GetElement<Button>(SearchCriteria.ByAutomationId(ResourceManager.CalculatorKeypadMemoryButtonAddId)); }
		public Button ButtonMemorySub { get => GetElement<Button>(SearchCriteria.ByAutomationId(ResourceManager.CalculatorKeypadMemoryButtonSubtractId)); }
		public Button ButtonMemoryRecall { get => GetElement<Button>(SearchCriteria.ByAutomationId(ResourceManager.CalculatorKeypadMemoryButtonRecallId)); }
		public Button ButtonMemoryClear { get => GetElement<Button>(SearchCriteria.ByAutomationId(ResourceManager.CalculatorKeypadMemoryButtonClearId)); }

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="window">Window.</param>
		public MemoryKeypad(Window window) : base(window)
		{ }
	}
}
