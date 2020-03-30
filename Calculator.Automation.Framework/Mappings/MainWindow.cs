using Calculator.Automation.Framework.Util;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace Calculator.Automation.Framework.Mappings
{
        public class MainWindow : BaseWindow
        {
                public NumericKeypad KeypadNumeric { get; }
                public MemoryKeypad KeypadMemory { get; }
                public Button ButtonAdd { get; }
                public Button ButtonSub { get; }
                public Button ButtonMul { get; }
                public Button ButtonDiv { get; }
                public Button ButtonGetResult { get; }
                public Label LabelResult { get; }

                /// <summary>
                /// Constructor.
                /// </summary>
                /// <param name="window">Window.</param>
                public MainWindow(Window window) : base(window)
                {
                        KeypadNumeric = new NumericKeypad(window);
                        KeypadMemory = new MemoryKeypad(window);
                        ButtonAdd = GetElement<Button>(SearchCriteria.ByAutomationId(ResourceManager.CalculatorMainWindowButtonAddId));
                        ButtonSub = GetElement<Button>(SearchCriteria.ByAutomationId(ResourceManager.CalculatorMainWindowButtonSubtractId));
                        ButtonMul = GetElement<Button>(SearchCriteria.ByAutomationId(ResourceManager.CalculatorMainWindowButtonMultiplyId));
                        ButtonDiv = GetElement<Button>(SearchCriteria.ByAutomationId(ResourceManager.CalculatorMainWindowButtonDivideId));
                        ButtonGetResult = GetElement<Button>(SearchCriteria.ByAutomationId(ResourceManager.CalculatorMainWindowButtonGetResultId));
                        LabelResult = GetElement<Label>(SearchCriteria.ByAutomationId(ResourceManager.CalculatorMainWindowLabelResultId));
                }
        }
}
