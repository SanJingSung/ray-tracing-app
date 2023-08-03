﻿using Domain;
using Domain.Exceptions;

namespace GUI
{
	public static class StringUtils
	{
		private const string InvalidFormatMessageError = "Vector input must be three integer values splited by coma format only: x,y,z";
        private const int ExpectedSize = 3;

        public static string[] DestructureVectorFromat(string input)
		{
			string[] ret = input.Trim().Split(',');

			if (ret.Length != ExpectedSize)
			{
				throw new InvalidSceneInputException(InvalidFormatMessageError);
			}

			return ret;
		}

		public static string ConstructVectorFormat(Vector input)
		{
			double x = input.X;
			double y = input.Y;
			double z = input.Z;

			return $"{x},{y},{z}";
		}
	}
}
