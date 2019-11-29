// <author>Stefán Örvar Sigmundsson</author>
// <copyright company="eMedia Intellect" file="NewWindow.xaml.cs">
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
	using System.Windows;

	/// <summary>Provides a window to create a new directory or file for the <see cref="FileSystemBrowserWindow"/> class.</summary>
	internal partial class NewWindow : Window
	{
		/// <summary>The file system item type to create.</summary>
		private FileSystemBrowserWindow.FileSystemItemType fileSystemItemType = FileSystemBrowserWindow.FileSystemItemType.Directory;

		/// <summary>The file system browser window in which to create the file system item.</summary>
		private FileSystemBrowserWindow fileSystemBrowserWindow = null;

		/// <summary>Initialises a new instance of the <see cref="NewWindow"/> class for the specified <see cref="FileSystemBrowserWindow"/>.</summary>
		/// <param name="fileSystemBrowserWindow">The instance of the <see cref="FileSystemBrowserWindow"/> class instantiating the <see cref="NewWindow"/> class.</param>
		internal NewWindow(FileSystemBrowserWindow fileSystemBrowserWindow)
		{
			this.InitializeComponent();

			this.fileSystemBrowserWindow = fileSystemBrowserWindow;

			this.nameTextBox.Focus();
		}
	}
}