// <author>Stefán Örvar Sigmundsson</author>
// <copyright company="eMedia Intellect" file="PathManipulator.cs">
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
	using System.IO;

	/// <content>Contains the <see cref="PathManipulator"/> class.</content>
	public partial class FileSystemBrowserWindow
	{
		/// <summary>Provides path manipulation for the <see cref="FileSystemBrowserWindow"/> class.</summary>
		internal static class PathManipulator
		{
			/// <summary>Concatenates a file system path consisting of a path and a file system item.</summary>
			/// <param name="path">The path to prefix to the file system item.</param>
			/// <param name="fileSystemItem">The file system item to add to the base path.</param>
			/// <returns>The concatenated file system path.</returns>
			internal static string ConcatenatePath(string path, string fileSystemItem)
			{
				if (path.EndsWith(":" + Path.DirectorySeparatorChar + Path.DirectorySeparatorChar, StringComparison.Ordinal))
				{
					return path + fileSystemItem;
				}
				else
				{
					return path + Path.DirectorySeparatorChar + fileSystemItem;
				}
			}

			/// <summary>Checks whether the computer is being displayed.</summary>
			/// <param name="path">The file system path to check.</param>
			/// <returns>The boolean indicating whether the computer is being displayed.</returns>
			internal static bool CheckIsComputer(string path)
			{
				if (string.IsNullOrEmpty(path))
				{
					return true;
				}
				else
				{
					return false;
				}
			}

			/// <summary>Gets the parent directory of the file system path.</summary>
			/// <param name="path">The file system path from which to start.</param>
			/// <returns>The parent directory of the file system path.</returns>
			internal static string GetParentDirectory(string path)
			{
				if (path.EndsWith(Path.DirectorySeparatorChar.ToString(), StringComparison.Ordinal))
				{
					return string.Empty;
				}

				int backslashCount = path.Split(Path.DirectorySeparatorChar).Length - 1;

				path = path.Substring(0, path.LastIndexOf(Path.DirectorySeparatorChar));

				if (backslashCount == 1)
				{
					path += Path.DirectorySeparatorChar;
				}

				return path;
			}

			/// <summary>Sanitises a file system path.</summary>
			/// <param name="path">The file system path to sanitise.</param>
			/// <returns>The sanitised file system path.</returns>
			internal static string Sanitise(string path)
			{
				path = path.Trim();

				if (path.EndsWith(Path.DirectorySeparatorChar.ToString(), StringComparison.Ordinal) && !path.EndsWith(":" + Path.DirectorySeparatorChar, StringComparison.Ordinal))
				{
					path = path.Remove(path.Length - 1);
				}

				return path;
			}
		}
	}
}