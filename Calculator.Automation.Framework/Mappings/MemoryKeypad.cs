using Calculator.Automation.Framework.Util;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace Calculator.Automation.Framework.Mappings
{
        public class MemoryKeypad : BaseWindow
        {
                public Button ButtonMemoryStore { get; }
                public Button ButtonMemoryAdd { get; }
                public Button ButtonMemorySub { get; }
                public Button ButtonMemoryRecall { get; }
                public Button ButtonMemoryClear { get; }

                /// <summary>
                /// Constructor.
                /// </summary>
                /// <param name="window">Window.</param>
                public MemoryKeypad(Window window) : base(window)
                {
                        ButtonMemoryStore = GetElement<Button>(SearchCriteria.ByAutomationId(ResourceManager.CalculatorKeypadMemoryButtonStoreId));
                        ButtonMemoryAdd = GetElement<Button>(SearchCriteria.ByAutomationId(ResourceManager.CalculatorKeypadMemoryButtonAddId));
                        ButtonMemorySub = GetElement<Button>(SearchCriteria.ByAutomationId(ResourceManager.CalculatorKeypadMemoryButtonSubtractId));
                        ButtonMemoryRecall = GetElement<Button>(SearchCriteria.ByAutomationId(ResourceManager.CalculatorKeypadMemoryButtonRecallId));
                        ButtonMemoryClear = GetElement<Button>(SearchCriteria.ByAutomationId(ResourceManager.CalculatorKeypadMemoryButtonClearId));
                }

        }
}
