using Calculator.Automation.Framework.Util;
using TestStack.White;
using TestStack.White.UIItems.WindowItems;

namespace Calculator.Automation.Framework
{
        public class Calculator
        {
                /// <summary>
                /// Singleton claculator instance.
                /// </summary>
                private static Calculator _instance = null;

                /// <summary>
                /// Get calculator singleton instance.
                /// </summary>
                public static Calculator Instance
                {
                        get { return _instance ?? (_instance = new Calculator()); }
                }

                /// <summary>
                /// Calculator process.
                /// </summary>
                private Application _application = null;

                /// <summary>
                /// Empty constructor.
                /// </summary>
                private Calculator()
                {
                }

                /// <summary>
                /// Launch calculator process.
                /// </summary>
                /// <returns><code>true</code> if process is launched, <code>false</code> otherwise</returns>
                public void Launch()
                {
                        _application = _application ?? Application.Launch(ResourceManager.CalculatorApplicationPath);
                }

                public void Close()
                {
                        if (_application == null)
                                return;

                        _application.Close();
                        _application.Dispose();
                        _application = null;
                        _instance = null;
                }

                /// <summary>
                /// Get application visible window
                /// </summary>
                /// <returns>Window object if found. null otherwise</returns>
                public Window GetWindow()
                {
                        return _application.GetWindow(ResourceManager.CalculatorMainWindowName);
                }

                /// <summary>
                /// Destructor. Terminates calculator process.
                /// </summary>
                ~Calculator()
                {
                        Close();
                }
        }
}
