// <author>Stefán Örvar Sigmundsson</author>
// <copyright company="eMedia Intellect" file="ColumnHeaderDescending_PreviewMouseUp.cs">
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
	using System.Windows;
	using System.Windows.Controls;
	using System.Windows.Input;

	/// <content>Contains the <see cref="ColumnHeaderDescending_PreviewMouseUp"/> method.</content>
	public partial class FileSystemBrowserWindow
	{
		/// <summary>Triggers descending sorting and adds the relevant arrow image to a column header grid when its button is clicked.</summary>
		/// <param name="sender">The sender object of the event handler.</param>
		/// <param name="e">The state information of the event handler.</param>
		private void ColumnHeaderDescending_PreviewMouseUp(object sender, MouseButtonEventArgs e)
		{
			Button senderButton = (Button)sender;

			SortingColumn currentSortingColumn = (SortingColumn)Enum.Parse(typeof(SortingColumn), senderButton.CommandParameter.ToString());

			this.fileSystemListView.Items.Clear();

			this.RemoveGridImageChildren();

			this.fileSystemItemSorter.CurrentListSortDirection = ListSortDirection.Descending;

			switch (currentSortingColumn)
			{
				case SortingColumn.AvailableFreeSpace:
					this.fileSystemItemSorter.SortAvailableFreeSpace();

					this.availableFreeSpaceGrid.Children.Add(this.arrowDescendingImage);

					break;
				case SortingColumn.CreationTime:
					this.fileSystemItemSorter.SortCreationTime();

					this.creationTimeGrid.Children.Add(this.arrowDescendingImage);

					break;
				case SortingColumn.DriveFormat:
					this.fileSystemItemSorter.SortDriveFormat();

					this.driveFormatGrid.Children.Add(this.arrowDescendingImage);

					break;
				case SortingColumn.DriveType:
					this.fileSystemItemSorter.SortDriveType();

					this.driveTypeGrid.Children.Add(this.arrowDescendingImage);

					break;
				case SortingColumn.LastAccessTime:
					this.fileSystemItemSorter.SortLastAccessTime();

					this.lastAccessTimeGrid.Children.Add(this.arrowDescendingImage);

					break;
				case SortingColumn.LastWriteTime:
					this.fileSystemItemSorter.SortLastWriteTime();

					this.lastWriteTimeGrid.Children.Add(this.arrowDescendingImage);

					break;
				case SortingColumn.Name:
					this.fileSystemItemSorter.SortName();

					this.nameGrid.Children.Add(this.arrowDescendingImage);

					break;
				case SortingColumn.RootDirectory:
					this.fileSystemItemSorter.SortRootDirectory();

					this.rootDirectoryGrid.Children.Add(this.arrowDescendingImage);

					break;
				case SortingColumn.Size:
					this.fileSystemItemSorter.SortSize();

					this.sizeGrid.Children.Add(this.arrowDescendingImage);

					break;
				case SortingColumn.TotalFreeSpace:
					this.fileSystemItemSorter.SortTotalFreeSpace();

					this.totalFreeSpaceGrid.Children.Add(this.arrowDescendingImage);

					break;
				case SortingColumn.TotalSize:
					this.fileSystemItemSorter.SortTotalSize();

					this.totalSizeGrid.Children.Add(this.arrowDescendingImage);

					break;
				case SortingColumn.VolumeLabel:
					this.fileSystemItemSorter.SortVolumeLabel();

					this.volumeGrid.Children.Add(this.arrowDescendingImage);

					break;
			}

			this.availableFreeSpaceButton.PreviewMouseUp += this.ColumnHeaderAscending_PreviewMouseUp;
			this.availableFreeSpaceButton.PreviewMouseUp -= this.ColumnHeaderDescending_PreviewMouseUp;

			this.creationTimeButton.PreviewMouseUp += this.ColumnHeaderAscending_PreviewMouseUp;
			this.creationTimeButton.PreviewMouseUp -= this.ColumnHeaderDescending_PreviewMouseUp;

			this.driveFormatButton.PreviewMouseUp += this.ColumnHeaderAscending_PreviewMouseUp;
			this.driveFormatButton.PreviewMouseUp -= this.ColumnHeaderDescending_PreviewMouseUp;

			this.driveTypeButton.PreviewMouseUp += this.ColumnHeaderAscending_PreviewMouseUp;
			this.driveTypeButton.PreviewMouseUp -= this.ColumnHeaderDescending_PreviewMouseUp;

			this.lastAccessTimeButton.PreviewMouseUp += this.ColumnHeaderAscending_PreviewMouseUp;
			this.lastAccessTimeButton.PreviewMouseUp -= this.ColumnHeaderDescending_PreviewMouseUp;

			this.lastWriteTimeButton.PreviewMouseUp += this.ColumnHeaderAscending_PreviewMouseUp;
			this.lastWriteTimeButton.PreviewMouseUp -= this.ColumnHeaderDescending_PreviewMouseUp;

			this.nameButton.PreviewMouseUp += this.ColumnHeaderAscending_PreviewMouseUp;
			this.nameButton.PreviewMouseUp -= this.ColumnHeaderDescending_PreviewMouseUp;

			this.rootDirectoryButton.PreviewMouseUp += this.ColumnHeaderAscending_PreviewMouseUp;
			this.rootDirectoryButton.PreviewMouseUp -= this.ColumnHeaderDescending_PreviewMouseUp;

			this.sizeButton.PreviewMouseUp += this.ColumnHeaderAscending_PreviewMouseUp;
			this.sizeButton.PreviewMouseUp -= this.ColumnHeaderDescending_PreviewMouseUp;

			this.totalFreeSpaceButton.PreviewMouseUp += this.ColumnHeaderAscending_PreviewMouseUp;
			this.totalFreeSpaceButton.PreviewMouseUp -= this.ColumnHeaderDescending_PreviewMouseUp;

			this.totalSizeButton.PreviewMouseUp += this.ColumnHeaderAscending_PreviewMouseUp;
			this.totalSizeButton.PreviewMouseUp -= this.ColumnHeaderDescending_PreviewMouseUp;

			this.volumeButton.PreviewMouseUp += this.ColumnHeaderAscending_PreviewMouseUp;
			this.volumeButton.PreviewMouseUp -= this.ColumnHeaderDescending_PreviewMouseUp;

			foreach (FileSystemItem currentFileSystemItem in this.fileSystemItemSorter.FileSystemItemList)
			{
				this.fileSystemListView.Items.Add(currentFileSystemItem);
			}
		}
	}
}