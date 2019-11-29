// <author>Stefán Örvar Sigmundsson</author>
// <copyright company="eMedia Intellect" file="DeleteWindow.xaml.cs">
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
	using System.Collections;
	using System.Collections.Generic;
	using System.Windows;

	/// <summary>Provides a window to delete directories and files for the <see cref="FileSystemBrowserWindow"/> class.</summary>
	internal partial class DeleteWindow : Window
	{
		/// <summary>Indicates whether a single file system item has encountered an error during deletion.</summary>
		/// <remarks>Should an error occur during deletion, the <see cref="DeleteWindow"/> is not closed automatically.</remarks>
		private bool hasError = false;

		/// <summary>The file system browser window from which to delete the file system item.</summary>
		private FileSystemBrowserWindow fileSystemBrowserWindow = null;

		/// <summary>The directories to delete.</summary>
		private List<FileSystemItemDeletion> directoryList = new List<FileSystemItemDeletion>();

		/// <summary>The files to delete.</summary>
		private List<FileSystemItemDeletion> fileList = new List<FileSystemItemDeletion>();

		/// <summary>The name comparer for the collections of <see cref="FileSystemItemDeletion"/> instances.</summary>
		private NameComparer nameComparer = new NameComparer();

		/// <summary>Initialises a new instance of the <see cref="DeleteWindow"/> class for the specified <see cref="FileSystemBrowserWindow"/>.</summary>
		/// <param name="fileSystemBrowserWindow">The instance of the <see cref="FileSystemBrowserWindow"/> class instantiating the <see cref="DeleteWindow"/> class.</param>
		internal DeleteWindow(FileSystemBrowserWindow fileSystemBrowserWindow)
		{
			this.InitializeComponent();

			this.fileSystemBrowserWindow = fileSystemBrowserWindow;

			IList selectedItemsIList = this.fileSystemBrowserWindow.fileSystemListView.SelectedItems;

			foreach (object currentItem in selectedItemsIList)
			{
				FileSystemBrowserWindow.FileSystemItem currentFileSystemItem = (FileSystemBrowserWindow.FileSystemItem)currentItem;

				switch (currentFileSystemItem.FileSystemItemType)
				{
					case FileSystemBrowserWindow.FileSystemItemType.Directory:
						this.directoryList.Add(new FileSystemItemDeletion(currentFileSystemItem.Name, DeletionStatus.Pending));

						break;
					case FileSystemBrowserWindow.FileSystemItemType.File:
						this.fileList.Add(new FileSystemItemDeletion(currentFileSystemItem.Name, DeletionStatus.Pending));

						break;
				}
			}

			this.directoryList.Sort(this.nameComparer);

			this.fileList.Sort(this.nameComparer);

			this.ListFileSystemItems();
		}
	}
}