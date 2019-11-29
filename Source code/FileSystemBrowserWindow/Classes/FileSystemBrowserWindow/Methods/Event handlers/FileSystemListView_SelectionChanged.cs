// <author>Stefán Örvar Sigmundsson</author>
// <copyright company="eMedia Intellect" file="FileSystemListView_SelectionChanged.cs">
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
	using System.Windows.Controls;

	/// <content>Contains the <see cref="FileSystemListView_SelectionChanged"/> method.</content>
	public partial class FileSystemBrowserWindow
	{
		/// <summary>Validates the selection of <see cref="FileSystemItem"/> instances when it is changed.</summary>
		/// <param name="sender">The sender object of the event handler.</param>
		/// <param name="e">The state information of the event handler.</param>
		private void FileSystemListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			IList selectedItemsIList = this.fileSystemListView.SelectedItems;

			int selectedDirectoriesCount = 0;
			int selectedFilesCount = 0;

			foreach (object currentItem in selectedItemsIList)
			{
				FileSystemItem currentFileSystemItem = (FileSystemItem)currentItem;

				switch (currentFileSystemItem.FileSystemItemType)
				{
					case FileSystemItemType.Directory:
						++selectedDirectoriesCount;

						break;
					case FileSystemItemType.File:
						++selectedFilesCount;

						break;
				}
			}

			ContextMenu listViewContextMenu = (ContextMenu)this.fileSystemListView.Resources["ListViewContextMenu"];

			MenuItem renameMenuItem = (MenuItem)listViewContextMenu.Items[0];
			MenuItem deleteMenuItem = (MenuItem)listViewContextMenu.Items[1];

			if ((selectedDirectoriesCount == 1 && selectedFilesCount == 0) || (selectedDirectoriesCount == 0 && selectedFilesCount == 1))
			{
				if (!PathManipulator.CheckIsComputer(this.path))
				{
					this.renameButton.IsEnabled = true;

					renameMenuItem.IsEnabled = true;
				}
			}
			else
			{
				this.renameButton.IsEnabled = false;

				renameMenuItem.IsEnabled = false;
			}

			if (selectedDirectoriesCount > 0 || selectedFilesCount > 0)
			{
				if (!PathManipulator.CheckIsComputer(this.path))
				{
					this.deleteButton.IsEnabled = true;

					deleteMenuItem.IsEnabled = true;
				}
			}
			else
			{
				this.deleteButton.IsEnabled = false;

				deleteMenuItem.IsEnabled = false;
			}

			if (this.browserSettings.BrowsingMode != BrowsingMode.Save)
			{
				if (selectedDirectoriesCount >= this.browserSettings.MinimumDirectories && selectedDirectoriesCount <= this.browserSettings.MaximumDirectories && selectedFilesCount >= this.browserSettings.MinimumFiles && selectedFilesCount <= this.browserSettings.MaximumFiles)
				{
					this.actionButton.IsEnabled = true;
				}
				else
				{
					this.actionButton.IsEnabled = false;
				}
			}
			else
			{
				if (!PathManipulator.CheckIsComputer(this.path))
				{
					foreach (object currentItem in selectedItemsIList)
					{
						FileSystemItem currentFileSystemItem = (FileSystemItem)currentItem;

						if (currentFileSystemItem.FileSystemItemType == FileSystemItemType.File)
						{
							this.fileNameTextBox.Text = currentFileSystemItem.Name;
						}
					}
				}
			}
		}
	}
}