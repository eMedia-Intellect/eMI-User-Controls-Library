// <author>Stefán Örvar Sigmundsson</author>
// <copyright company="eMedia Intellect" file="ByteConverter.cs">
//    Copyright © 2016–2017, 2019 eMedia Intellect.
// </copyright>
// <licence>
//    This file is part of eMI User Controls Library.
//
//    eMI User Controls Library is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    eMI User Controls Library is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with eMI User Controls Library. If not, see http://www.gnu.org/licenses/.
// </licence>

namespace Emi.UserControls
{
	using System;
	using System.ComponentModel;
	using System.Globalization;
	using System.Threading;

	/// <content>Contains the <see cref="ByteConverter"/> class.</content>
	public partial class FileSystemBrowserWindow
	{
		/// <summary>Provides a byte converter for the <see cref="FileSystemBrowserWindow"/> class.</summary>
		internal static class ByteConverter
		{
			/// <summary>The prefixes of the International System of Units.</summary>
			private static readonly string[] Prefixes = { string.Empty, "k", "M", "G", "T", "P", "E", "Z", "Y" };

			/// <summary>Processes a file size by converting it to the appropriate prefix.</summary>
			/// <remarks>This method is called by properties which are used by FileSystemBrowserWindow.xaml.</remarks>
			/// <param name="bytes">The file size in bytes.</param>
			/// <param name="byteMultiple">The multiple of bytes.</param>
			/// <returns>The converted and formatted file size.</returns>
			internal static string Process(long bytes, ByteMultiple byteMultiple)
			{
				decimal roundingBytes = bytes;

				int multiple = 0;

				switch (byteMultiple)
				{
					case ByteMultiple.Binary:
						multiple = 1024;

						break;
					case ByteMultiple.Decimal:
						multiple = 1000;

						break;
				}

				int prefixCounter = 0;

				while (Math.Round(roundingBytes / multiple) >= 1)
				{
					roundingBytes /= multiple;

					++prefixCounter;
				}

				roundingBytes = Math.Round(roundingBytes, 0);

				CultureInfo currentCultureInfo = Thread.CurrentThread.CurrentCulture;

				string prefix;

				switch (byteMultiple)
				{
					case ByteMultiple.Binary:
						if (prefixCounter == 0)
						{
							prefix = " B";
						}
						else if (prefixCounter == 1)
						{
							prefix = " KiB";
						}
						else
						{
							prefix = " " + Prefixes[prefixCounter] + "iB";
						}

						break;
					case ByteMultiple.Decimal:
						if (prefixCounter == 0)
						{
							prefix = " B";
						}
						else
						{
							prefix = " " + Prefixes[prefixCounter] + "B";
						}

						break;
					default:
						prefix = string.Empty;

						throw new InvalidEnumArgumentException(byteMultiple.ToString());
				}

				return roundingBytes.ToString(currentCultureInfo) + prefix;
			}
		}
	}
}