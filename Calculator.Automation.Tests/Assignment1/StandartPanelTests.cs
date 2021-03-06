﻿using System;
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
	class StandartPanelTests
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
			KillAllCalculators();
		}

		[TearDown]
		public static void TearDownTest()
		{
			Calculator.Instance.CloseApplication();
			KillAllCalculators();
		}

		[Test(ExpectedResult = 1030)]
		public static int MemoryButtonsTest()
		{
			Assert.DoesNotThrow(Calculator.Instance.Launch, "Could not successfully start calculator instance");
			StandardWindow window = new StandardWindow(Calculator.Instance.GetWindow());
			
			window.KeypadNumeric.EnterNumber("12");
			window.DefaultOperations.ButtonAdd.Click();
			window.KeypadNumeric.EnterNumber("999");
			window.DefaultOperations.ButtonGetResult.Click();
			window.KeypadMemory.ButtonMemoryStore.Click();

			window.KeypadNumeric.EnterNumber("19");
			window.DefaultOperations.ButtonSub.Click();
			window.DefaultOperations.ButtonAdd.Click();
			window.DefaultOperations.ButtonAdd.Click();
			
			window.KeypadMemory.ButtonMemoryRecall.Click();
			window.DefaultOperations.ButtonGetResult.Click();

			string resultValue = window.LabelResult.Text;
			return Convert.ToInt32(resultValue);
		}
		
		[Test(ExpectedResult = 278845595)]
		public static int DefaultOperationsTest()
		{
			Assert.DoesNotThrow(Calculator.Instance.Launch, "Could not successfully start calculator instance");
			StandardWindow window = new StandardWindow(Calculator.Instance.GetWindow());

			window.KeypadNumeric.EnterNumber("123456");
			window.DefaultOperations.ButtonAdd.Click();
			window.KeypadNumeric.EnterNumber("987654");
			window.DefaultOperations.ButtonSub.Click();
			window.KeypadNumeric.EnterNumber("2380");

			window.DefaultOperations.ButtonGetResult.Click();
			Assert.AreEqual(1108730, Convert.ToInt32(window.LabelResult.Text));
			
			window.DefaultOperations.ButtonMul.Click();
			window.KeypadNumeric.EnterNumber("503");
			window.DefaultOperations.ButtonDiv.Click();
			window.KeypadNumeric.EnterNumber("2");

			window.DefaultOperations.ButtonGetResult.Click();

			string resultValue = window.LabelResult.Text;
			return Convert.ToInt32(resultValue);
		}

	}
}
