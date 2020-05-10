using System;
using NUnit.Framework;
using Calculator.Automation.Framework.Mappings;
using Calculator.Automation.Framework.Util;


namespace Calculator.Automation.Tests.Assignment1
{
	using Calculator.Automation.Framework;
	using NLog;
	using System.Diagnostics;
	using System.IO;

	[TestFixture(Category = "A1QA assignment #1")]
	class MemoryButtonsTest
	{
		/// <summary>
		/// Logger
		/// </summary>
		private static readonly Logger logger = LogManager.GetCurrentClassLogger();

		/// <summary>
		/// Kill all calculator processes
		/// </summary>
		public static void KillAllCalculators()
		{
			// find all processes with matching name
			string calculatorExeFileName = Path.GetFileNameWithoutExtension(ResourceManager.CalculatorApplicationPath);
			Process[] processList = Process.GetProcessesByName(calculatorExeFileName);
			System.Console.Out.WriteLine();
			logger.Info(string.Format("Found {0} processes with matching name", processList.Length));

			// if [module image path] matches [calculator executable filepath] -> kill process
			foreach (Process process in processList)
			{
				foreach (ProcessModule module in process.Modules)
				{
					if (module.FileName.Equals(ResourceManager.CalculatorApplicationPath))
					{
						process.Kill();
						logger.Info(string.Format(string.Format("Killed process with id={0}", process.Id)));
						break;
					}
				}
			}
		}

		[SetUp]
		public static void SetUpTest()
		{
			string calculatorResourcesPath = TestContext.CurrentContext.TestDirectory + @"../../../../Calculator.Automation.Framework/Configs/Win7Locators.json";
			ResourceManager.Load(calculatorResourcesPath);
			KillAllCalculators();
		}

		[TearDown]
		public static void TearDownTest()
		{
			Calculator.Instance.Close();
			KillAllCalculators();
		}

		[Test(ExpectedResult = 1030)]
		public static int AssignmentTest()
		{
			Assert.DoesNotThrow(Calculator.Instance.Launch);
			MainWindow mainWindow = new MainWindow(Calculator.Instance.GetWindow());
			mainWindow.KeypadNumeric.EnterNumber("12");
			mainWindow.ButtonAdd.Click();
			mainWindow.KeypadNumeric.EnterNumber("999");
			mainWindow.ButtonGetResult.Click();
			mainWindow.KeypadMemory.ButtonMemoryAdd.Click();

			mainWindow.KeypadNumeric.EnterNumber("19");
			mainWindow.ButtonAdd.Click();
			mainWindow.KeypadMemory.ButtonMemoryRecall.Click();
			mainWindow.ButtonGetResult.Click();

			string resultValue = mainWindow.LabelResult.Text;
			return Convert.ToInt32(resultValue);
		}
	}
}
