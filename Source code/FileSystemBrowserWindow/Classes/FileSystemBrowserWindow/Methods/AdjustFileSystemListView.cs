// <author>Stefán Örvar Sigmundsson</author>
// <copyright company="eMedia Intellect" file="AdjustFileSystemListView.cs">
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
	using System.Windows.Controls;

	/// <content>Contains the <see cref="AdjustFileSystemListView"/> method.</content>
	public partial class FileSystemBrowserWindow
	{
		/// <summary>Adjusts the <see cref="fileSystemListView"/> field during every navigation.</summary>
		private void AdjustFileSystemListView()
		{
			/*
			 * Remove all columns.
			 */

			GridView fileSystemGridView = (GridView)this.fileSystemListView.View;

			fileSystemGridView.Columns.Clear();

			fileSystemGridView.Columns.Add(this.nameGridViewColumn);

			/*
			 * Remove all items.
			 */

			this.fileSystemListView.Items.Clear();

			/*
			 * Add relevant columns and items.
			 */

			if (this.path.Length == 0)
			{
				if (this.browserSettings.HasVolumeLabel)
				{
					fileSystemGridView.Columns.Add(this.volumeLabelGridViewColumn);
				}

				if (this.browserSettings.HasRootDirectory)
				{
					fileSystemGridView.Columns.Add(this.rootDirectoryGridViewColumn);
				}

				if (this.browserSettings.HasDriveType)
				{
					fileSystemGridView.Columns.Add(this.driveTypeGridViewColumn);
				}

				if (this.browserSettings.HasDriveFormat)
				{
					fileSystemGridView.Columns.Add(this.driveFormatGridViewColumn);
				}

				if (this.browserSettings.HasAvailableFreeSpace)
				{
					fileSystemGridView.Columns.Add(this.availableFreeSpaceGridViewColumn);
				}

				if (this.browserSettings.HasTotalFreeSpace)
				{
					fileSystemGridView.Columns.Add(this.totalFreeSpaceGridViewColumn);
				}

				if (this.browserSettings.HasTotalSize)
				{
					fileSystemGridView.Columns.Add(this.totalSizeGridViewColumn);
				}
			}
			else
			{
				fileSystemGridView.Columns.Add(this.sizeGridViewColumn);
				fileSystemGridView.Columns.Add(this.lastAccessTimeGridViewColumn);
				fileSystemGridView.Columns.Add(this.lastWriteTimeGridViewColumn);
				fileSystemGridView.Columns.Add(this.creationTimeGridViewColumn);
			}

			foreach (FileSystemItem currentFileSystemItem in this.fileSystemItemSorter.FileSystemItemList)
			{
				this.fileSystemListView.Items.Add(currentFileSystemItem);
			}

			/*
			 * Resize the columns to fit the data.
			 */

			foreach (GridViewColumn column in fileSystemGridView.Columns)
			{
				if (double.IsNaN(column.Width))
				{
					column.Width = column.ActualWidth;
				}

				column.Width = double.NaN;
			}

			/*
			 * Scroll to the top of the list view.
			 */

			if (this.fileSystemListView.HasItems)
			{
				this.fileSystemListView.ScrollIntoView(this.fileSystemListView.Items[0]);
			}

			/*
			 * Enable/Disable newButton and newMenuItem.
			 */

			this.newButton.IsEnabled = !PathManipulator.CheckIsComputer(this.path);

			this.newMenuItem.IsEnabled = !PathManipulator.CheckIsComputer(this.path);

			if (this.browserSettings.BrowsingMode == BrowsingMode.Save)
			{
				this.actionButton.IsEnabled = !PathManipulator.CheckIsComputer(this.path);
			}
		}
	}
}