﻿namespace Domain.Exceptions
{
	internal class InputLowerThanZero : InvalidRenderPropertiesInputException
	{
		public InputLowerThanZero(string message) : base(message) { }
	}
}
