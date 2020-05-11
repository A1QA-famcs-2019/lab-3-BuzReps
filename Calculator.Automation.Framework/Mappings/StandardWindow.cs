using Calculator.Automation.Framework.Util;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace Calculator.Automation.Framework.Mappings
{
	public class StandardWindow : BaseWindow
	{
		public NumericKeypad KeypadNumeric { get; }
		public MemoryKeypad KeypadMemory { get; }
		public DefaultOperationsKeypad DefaultOperations { get; }
		public Label LabelResult { get => GetElement<Label>(SearchCriteria.ByAutomationId(ResourceManager.CalculatorMainWindowLabelResultId)); }

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="window">Window.</param>
		public StandardWindow(Window window) : base(window)
		{
			KeypadNumeric = new NumericKeypad(window);
			KeypadMemory = new MemoryKeypad(window);
			DefaultOperations = new DefaultOperationsKeypad(window);
		}
	}
}
