using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Calculator.Automation.Framework.Util
{
        public static class ResourceManager
        {
                public static string CalculatorApplicationPath { get; private set; } = null;
                public static string CalculatorMainWindowName { get; private set; } = null;

                public static string CalculatorMainWindowButtonAddId { get; private set; } = null;
                public static string CalculatorMainWindowButtonSubtractId { get; private set; } = null;
                public static string CalculatorMainWindowButtonMultiplyId { get; private set; } = null;
                public static string CalculatorMainWindowButtonDivideId { get; private set; } = null;
                public static string CalculatorMainWindowButtonGetResultId { get; private set; } = null;
                public static string CalculatorMainWindowLabelResultId { get; private set; } = null;

                public static string CalculatorKeypadMemoryButtonStoreId { get; private set; } = null;
                public static string CalculatorKeypadMemoryButtonAddId { get; private set; } = null;
                public static string CalculatorKeypadMemoryButtonSubtractId { get; private set; } = null;
                public static string CalculatorKeypadMemoryButtonRecallId { get; private set; } = null;
                public static string CalculatorKeypadMemoryButtonClearId { get; private set; } = null;

                public static List<string> CalculatorKeypadNumericButtonsId { get; private set; } = null;

                public static void Load(string jsonFilepath)
                {
 
                        string fileContents = File.ReadAllText(jsonFilepath);
                        Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(fileContents);
                        CalculatorApplicationPath = values["CalculatorApplicationPath"];
                        CalculatorMainWindowName = values["CalculatorMainWindowName"];
                        CalculatorMainWindowButtonAddId = values["CalculatorMainWindowButtonAddId"];
                        CalculatorMainWindowButtonSubtractId = values["CalculatorMainWindowButtonSubtractId"];
                        CalculatorMainWindowButtonMultiplyId = values["CalculatorMainWindowButtonMultiplyId"];
                        CalculatorMainWindowButtonDivideId = values["CalculatorMainWindowButtonDivideId"];
                        CalculatorMainWindowButtonGetResultId = values["CalculatorMainWindowButtonGetResultId"];
                        CalculatorMainWindowLabelResultId = values["CalculatorMainWindowLabelResultId"];
                        CalculatorKeypadMemoryButtonStoreId = values["CalculatorKeypadMemoryButtonStoreId"];
                        CalculatorKeypadMemoryButtonAddId = values["CalculatorKeypadMemoryButtonAddId"];
                        CalculatorKeypadMemoryButtonSubtractId = values["CalculatorKeypadMemoryButtonSubtractId"];
                        CalculatorKeypadMemoryButtonRecallId = values["CalculatorKeypadMemoryButtonRecallId"];
                        CalculatorKeypadMemoryButtonClearId = values["CalculatorKeypadMemoryButtonClearId"];

                        CalculatorKeypadNumericButtonsId = new List<string>();
                        for (int i = 0; i < 10; i++)
                                CalculatorKeypadNumericButtonsId.Add(values[string.Format("CalculatorKeypadNumericButtonId{0}", i)]);
                }

        }
}
