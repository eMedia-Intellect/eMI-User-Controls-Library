// <author>Stefán Örvar Sigmundsson</author>
// <copyright company="eMedia Intellect" file="GeneratePathButtons.cs">
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
	using System.IO;
	using System.Windows;

	/// <content>Contains the <see cref="GeneratePathButtons"/> method.</content>
	public partial class FileSystemBrowserWindow
	{
		/// <summary>Generates the file system path as instances of the <see cref="PathButton"/> class.</summary>
		private void GeneratePathButtons()
		{
			this.pathStackPanel.Children.Clear();

			PathButton computerPathButton = new PathButton(UserControls.Resources.FileSystemBrowserWindow.PathButton.Computer, string.Empty, new RoutedEventHandler(this.PathButton_Click));

			this.pathStackPanel.Children.Add(computerPathButton);

			if (this.path.Length == 0)
			{
				return;
			}

			string[] pathDirectories = this.path.Split(Path.DirectorySeparatorChar);

			string pathConcatenation = string.Empty;

			for (int i = 0; i < pathDirectories.Length; ++i)
			{
				if (pathDirectories[i].Length == 0)
				{
					continue;
				}

				if (i != 0)
				{
					pathConcatenation += Path.DirectorySeparatorChar;
				}

				pathConcatenation += pathDirectories[i];

				PathButton currentPathButton = null;

				if (i == 0)
				{
					currentPathButton = new PathButton(pathDirectories[i], pathConcatenation + Path.DirectorySeparatorChar, new RoutedEventHandler(this.PathButton_Click));
				}
				else
				{
					currentPathButton = new PathButton(pathDirectories[i], pathConcatenation, new RoutedEventHandler(this.PathButton_Click));
				}

				this.pathStackPanel.Children.Add(currentPathButton);
			}
		}
	}
}