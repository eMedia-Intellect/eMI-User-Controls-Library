// <author>Stefán Örvar Sigmundsson</author>
// <copyright company="eMedia Intellect" file="RenameWindow.xaml.cs">
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
	using System.Collections;
	using System.Windows;

	/// <summary>Provides a window to rename a directory or file for the <see cref="FileSystemBrowserWindow"/> class.</summary>
	internal partial class RenameWindow : Window
	{
		/// <summary>The file system item type to rename.</summary>
		private FileSystemBrowserWindow.FileSystemItemType fileSystemItemType = FileSystemBrowserWindow.FileSystemItemType.Directory;

		/// <summary>The file system browser window in which to rename the file system item.</summary>
		private FileSystemBrowserWindow fileSystemBrowserWindow = null;

		/// <summary>Initialises a new instance of the <see cref="RenameWindow"/> class for the specified <see cref="FileSystemBrowserWindow"/>..</summary>
		/// <param name="fileSystemBrowserWindow">The instance of the <see cref="FileSystemBrowserWindow"/> class instantiating the <see cref="RenameWindow"/> class.</param>
		internal RenameWindow(FileSystemBrowserWindow fileSystemBrowserWindow)
		{
			this.InitializeComponent();

			this.fileSystemBrowserWindow = fileSystemBrowserWindow ?? throw new ArgumentNullException("fileSystemBrowserWindow");

			IList selectedItemsIList = this.fileSystemBrowserWindow.fileSystemListView.SelectedItems;

			FileSystemBrowserWindow.FileSystemItem fileSystemItem = (FileSystemBrowserWindow.FileSystemItem)selectedItemsIList[0];

			this.fileSystemItemType = fileSystemItem.FileSystemItemType;

			this.currentNameTextBox.Text = fileSystemItem.Name;

			this.newNameTextBox.Text = fileSystemItem.Name;

			this.newNameTextBox.Focus();

			this.newNameTextBox.CaretIndex = this.newNameTextBox.Text.Length;
		}
	}
}