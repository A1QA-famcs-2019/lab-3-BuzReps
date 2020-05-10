using Calculator.Automation.Framework.Util;
using System;
using System.Collections.Generic;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace Calculator.Automation.Framework.Mappings
{
	public class NumericKeypad : BaseWindow
	{

		/// <summary>
		/// Get numeric buttons
		/// </summary>
		/// <returns>List of buttons</returns>
		private List<Button> GetButtons()
		{

			List<Button> buttons = new List<Button>();
			foreach (string id in ResourceManager.CalculatorKeypadNumericButtonsId)
				buttons.Add(GetElement<Button>(SearchCriteria.ByAutomationId(id)));
			return buttons;
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="window">Window.</param>
		public NumericKeypad(Window window) : base(window)
		{
			List<Button> buttons = GetButtons();
			foreach (string id in ResourceManager.CalculatorKeypadNumericButtonsId)
				buttons.Add(GetElement<Button>(SearchCriteria.ByAutomationId(id)));
		}

		/// <summary>
		/// Click number button.
		/// </summary>
		/// <param name="value">Button to click: Value from 0 to 9.</param>
		public void EnterNumber(int value)
		{
			List<Button> buttons = GetButtons();
			if (!(value >= 0 && value <= 9))
				throw new ArgumentException("Value should be in closed range 0..9");
			buttons[value].Click();

		}

		/// <summary>
		/// Enter number.
		/// </summary>
		/// <param name="value">Number to enter.</param>
		public void EnterNumber(string value)
		{
			foreach (char c in value)
				EnterNumber(c - '0');
		}

	}
}
