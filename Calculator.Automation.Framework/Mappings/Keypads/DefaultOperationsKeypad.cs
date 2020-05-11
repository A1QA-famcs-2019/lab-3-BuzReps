using Calculator.Automation.Framework.Util;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace Calculator.Automation.Framework.Mappings
{
	public class DefaultOperationsKeypad : BaseWindow
	{
		public Button ButtonAdd { get => GetElement<Button>(SearchCriteria.ByAutomationId(ResourceManager.CalculatorMainWindowButtonAddId)); }
		public Button ButtonSub { get => GetElement<Button>(SearchCriteria.ByAutomationId(ResourceManager.CalculatorMainWindowButtonSubtractId)); }
		public Button ButtonMul { get => GetElement<Button>(SearchCriteria.ByAutomationId(ResourceManager.CalculatorMainWindowButtonMultiplyId)); }
		public Button ButtonDiv { get => GetElement<Button>(SearchCriteria.ByAutomationId(ResourceManager.CalculatorMainWindowButtonDivideId)); }
		public Button ButtonGetResult { get => GetElement<Button>(SearchCriteria.ByAutomationId(ResourceManager.CalculatorMainWindowButtonGetResultId)); }

		public DefaultOperationsKeypad(Window window) : base(window)
		{}
	}
}
