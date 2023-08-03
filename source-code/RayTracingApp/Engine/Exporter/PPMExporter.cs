﻿using Engine.Exceptions;
using System;
using System.Drawing;
using System.IO;

namespace Engine.Exporter
{
	public class PPMExporter : IExporter
	{
		private const string InvalidPathErrorMessage = "Invalid Path";

		public void Export(string path, Image img)
		{
			try
			{
				SaveImage(img, path);
			}
			catch (Exception)
			{
				throw new ExporterException(InvalidPathErrorMessage);
			}
		}

		private static void SaveImage(Image imagen, string path)
		{
			using (var stream = new FileStream(path, FileMode.Create))
			{
				using (var writer = new StreamWriter(stream))
				{
					writer.WriteLine("P3");
					writer.WriteLine($"{imagen.Width} {imagen.Height}");
					writer.WriteLine("255");

					int a = imagen.Height;
					int b = imagen.Width;
					using (var bitmap = new Bitmap(imagen))
					{
						for (int y = 0; y < a; y++)
						{
							for (int x = 0; x < b; x++)
							{
								Color color = bitmap.GetPixel(x, y);
								writer.WriteLine($"{color.R} {color.G} {color.B}");
							}
						}
					}
				}
			}
		}
	}
}

