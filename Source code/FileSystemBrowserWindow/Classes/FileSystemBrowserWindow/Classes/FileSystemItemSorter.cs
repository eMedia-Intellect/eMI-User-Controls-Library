// <author>Stefán Örvar Sigmundsson</author>
// <copyright company="eMedia Intellect" file="FileSystemItemSorter.cs">
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
	using System.Collections.Generic;
	using System.ComponentModel;

	/// <content>Contains the <see cref="FileSystemItemSorter"/> class.</content>
	public partial class FileSystemBrowserWindow
	{
		/// <summary>Provides a file system item sorter for the <see cref="FileSystemBrowserWindow"/> class.</summary>
		internal class FileSystemItemSorter
		{
			/// <summary>The directories to sort.</summary>
			private List<FileSystemItem> directoryFileSystemItemList = new List<FileSystemItem>();

			/// <summary>The files to sort.</summary>
			private List<FileSystemItem> fileFileSystemItemList = new List<FileSystemItem>();

			/// <summary>The sorted directories and files.</summary>
			private List<FileSystemItem> sortedSystemItemList = new List<FileSystemItem>();

			/// <summary>The current order by which to sort.</summary>
			private ListSortDirection currentListSortDirection = ListSortDirection.Ascending;

			/// <summary>Gets a value indicating the processed list of instances of the <see cref="FileSystemItem"/> class.</summary>
			internal List<FileSystemItem> FileSystemItemList
			{
				get
				{
					return this.sortedSystemItemList;
				}
			}

			/// <summary>Sets a value indicating the current list sorting direction.</summary>
			internal ListSortDirection CurrentListSortDirection
			{
				set
				{
					this.currentListSortDirection = value;
				}
			}

			/// <summary>Adds a <see cref="FileSystemItem"/> to the <see cref="FileSystemItemSorter"/>.</summary>
			/// <param name="fileSystemItem">The instance to add.</param>
			internal void Add(FileSystemItem fileSystemItem)
			{
				switch (fileSystemItem.FileSystemItemType)
				{
					case FileSystemItemType.Directory:
						this.directoryFileSystemItemList.Add(fileSystemItem);

						break;
					case FileSystemItemType.File:
						this.fileFileSystemItemList.Add(fileSystemItem);

						break;
				}
			}

			/// <summary>Clears the <see cref="FileSystemItemSorter"/> of <see cref="FileSystemItem"/> instances.</summary>
			internal void Clear()
			{
				this.directoryFileSystemItemList.Clear();
				this.fileFileSystemItemList.Clear();

				this.sortedSystemItemList.Clear();
			}

			/// <summary>Sorts <see cref="FileSystemItem"/> instances neutrally. It is equivalent to sorting by the "Name" column ascendingly.</summary>
			/// <remarks>This method sorts the added instances alphabetically according to the current culture as the class library does not do so by default. This method must only be called after the <see cref="FileSystemItem"/> instances have been added to the <see cref="FileSystemItemSorter"/>.</remarks>
			internal void Sort()
			{
				this.directoryFileSystemItemList.Sort();
				this.fileFileSystemItemList.Sort();

				this.sortedSystemItemList.AddRange(this.directoryFileSystemItemList);
				this.sortedSystemItemList.AddRange(this.fileFileSystemItemList);
			}

			/// <summary>Sorts <see cref="FileSystemItem"/> instances by the "Available free space" column.</summary>
			internal void SortAvailableFreeSpace()
			{
				this.sortedSystemItemList.Clear();

				List<FileSystemItem> temporaryDirectoryFileSystemItemList = new List<FileSystemItem>();

				temporaryDirectoryFileSystemItemList.AddRange(this.directoryFileSystemItemList);

				AvailableFreeSpaceComparer availableFreeSpaceComparer = new AvailableFreeSpaceComparer(this.currentListSortDirection);

				temporaryDirectoryFileSystemItemList.Sort(availableFreeSpaceComparer);

				this.sortedSystemItemList.AddRange(temporaryDirectoryFileSystemItemList);
			}

			/// <summary>Sorts <see cref="FileSystemItem"/> instances by the "Created" column.</summary>
			internal void SortCreationTime()
			{
				this.sortedSystemItemList.Clear();

				List<FileSystemItem> temporaryDirectoryFileSystemItemList = new List<FileSystemItem>();
				List<FileSystemItem> temporaryFileFileSystemItemList = new List<FileSystemItem>();

				temporaryDirectoryFileSystemItemList.AddRange(this.directoryFileSystemItemList);
				temporaryFileFileSystemItemList.AddRange(this.fileFileSystemItemList);

				CreationTimeComparer creationTimeComparer = new CreationTimeComparer(this.currentListSortDirection);

				temporaryDirectoryFileSystemItemList.Sort(creationTimeComparer);
				temporaryFileFileSystemItemList.Sort(creationTimeComparer);

				switch (this.currentListSortDirection)
				{
					case ListSortDirection.Ascending:
						this.sortedSystemItemList.AddRange(temporaryDirectoryFileSystemItemList);
						this.sortedSystemItemList.AddRange(temporaryFileFileSystemItemList);

						break;
					case ListSortDirection.Descending:
						this.sortedSystemItemList.AddRange(temporaryFileFileSystemItemList);
						this.sortedSystemItemList.AddRange(temporaryDirectoryFileSystemItemList);

						break;
				}
			}

			/// <summary>Sorts <see cref="FileSystemItem"/> instances by the "Format" column.</summary>
			internal void SortDriveFormat()
			{
				this.sortedSystemItemList.Clear();

				List<FileSystemItem> temporaryDirectoryFileSystemItemList = new List<FileSystemItem>();

				temporaryDirectoryFileSystemItemList.AddRange(this.directoryFileSystemItemList);

				DriveFormatComparer driveFormatComparer = new DriveFormatComparer(this.currentListSortDirection);

				temporaryDirectoryFileSystemItemList.Sort(driveFormatComparer);

				this.sortedSystemItemList.AddRange(temporaryDirectoryFileSystemItemList);
			}

			/// <summary>Sorts <see cref="FileSystemItem"/> instances by the "Type" column.</summary>
			internal void SortDriveType()
			{
				this.sortedSystemItemList.Clear();

				List<FileSystemItem> temporaryDirectoryFileSystemItemList = new List<FileSystemItem>();

				temporaryDirectoryFileSystemItemList.AddRange(this.directoryFileSystemItemList);

				DriveTypeComparer driveTypeComparer = new DriveTypeComparer(this.currentListSortDirection);

				temporaryDirectoryFileSystemItemList.Sort(driveTypeComparer);

				this.sortedSystemItemList.AddRange(temporaryDirectoryFileSystemItemList);
			}

			/// <summary>Sorts <see cref="FileSystemItem"/> instances by the "Accessed" column.</summary>
			internal void SortLastAccessTime()
			{
				this.sortedSystemItemList.Clear();

				List<FileSystemItem> temporaryDirectoryFileSystemItemList = new List<FileSystemItem>();
				List<FileSystemItem> temporaryFileFileSystemItemList = new List<FileSystemItem>();

				temporaryDirectoryFileSystemItemList.AddRange(this.directoryFileSystemItemList);
				temporaryFileFileSystemItemList.AddRange(this.fileFileSystemItemList);

				LastAccessTimeComparer lastAccessTimeComparer = new LastAccessTimeComparer(this.currentListSortDirection);

				temporaryDirectoryFileSystemItemList.Sort(lastAccessTimeComparer);
				temporaryFileFileSystemItemList.Sort(lastAccessTimeComparer);

				switch (this.currentListSortDirection)
				{
					case ListSortDirection.Ascending:
						this.sortedSystemItemList.AddRange(temporaryDirectoryFileSystemItemList);
						this.sortedSystemItemList.AddRange(temporaryFileFileSystemItemList);

						break;
					case ListSortDirection.Descending:
						this.sortedSystemItemList.AddRange(temporaryFileFileSystemItemList);
						this.sortedSystemItemList.AddRange(temporaryDirectoryFileSystemItemList);

						break;
				}
			}

			/// <summary>Sorts <see cref="FileSystemItem"/> instances by the "Modified" column.</summary>
			internal void SortLastWriteTime()
			{
				this.sortedSystemItemList.Clear();

				List<FileSystemItem> temporaryDirectoryFileSystemItemList = new List<FileSystemItem>();
				List<FileSystemItem> temporaryFileFileSystemItemList = new List<FileSystemItem>();

				temporaryDirectoryFileSystemItemList.AddRange(this.directoryFileSystemItemList);
				temporaryFileFileSystemItemList.AddRange(this.fileFileSystemItemList);

				LastWriteTimeComparer lastWriteTimeComparer = new LastWriteTimeComparer(this.currentListSortDirection);

				temporaryDirectoryFileSystemItemList.Sort(lastWriteTimeComparer);
				temporaryFileFileSystemItemList.Sort(lastWriteTimeComparer);

				switch (this.currentListSortDirection)
				{
					case ListSortDirection.Ascending:
						this.sortedSystemItemList.AddRange(temporaryDirectoryFileSystemItemList);
						this.sortedSystemItemList.AddRange(temporaryFileFileSystemItemList);

						break;
					case ListSortDirection.Descending:
						this.sortedSystemItemList.AddRange(temporaryFileFileSystemItemList);
						this.sortedSystemItemList.AddRange(temporaryDirectoryFileSystemItemList);

						break;
				}
			}

			/// <summary>Sorts <see cref="FileSystemItem"/> instances by the "Name" column.</summary>
			internal void SortName()
			{
				this.sortedSystemItemList.Clear();

				switch (this.currentListSortDirection)
				{
					case ListSortDirection.Ascending:
						this.sortedSystemItemList.AddRange(this.directoryFileSystemItemList);
						this.sortedSystemItemList.AddRange(this.fileFileSystemItemList);

						break;
					case ListSortDirection.Descending:
						List<FileSystemItem> temporaryDirectoryFileSystemItemList = new List<FileSystemItem>();

						temporaryDirectoryFileSystemItemList.AddRange(this.directoryFileSystemItemList);

						temporaryDirectoryFileSystemItemList.Reverse();

						List<FileSystemItem> temporaryFileFileSystemItemList = new List<FileSystemItem>();

						temporaryFileFileSystemItemList.AddRange(this.fileFileSystemItemList);

						temporaryFileFileSystemItemList.Reverse();

						this.sortedSystemItemList.AddRange(temporaryFileFileSystemItemList);
						this.sortedSystemItemList.AddRange(temporaryDirectoryFileSystemItemList);

						break;
				}
			}

			/// <summary>Sorts <see cref="FileSystemItem"/> instances by the "Root directory" column.</summary>
			internal void SortRootDirectory()
			{
				this.sortedSystemItemList.Clear();

				List<FileSystemItem> temporaryDirectoryFileSystemItemList = new List<FileSystemItem>();

				temporaryDirectoryFileSystemItemList.AddRange(this.directoryFileSystemItemList);

				RootDirectoryComparer rootDirectoryComparer = new RootDirectoryComparer(this.currentListSortDirection);

				temporaryDirectoryFileSystemItemList.Sort(rootDirectoryComparer);

				this.sortedSystemItemList.AddRange(temporaryDirectoryFileSystemItemList);
			}

			/// <summary>Sorts <see cref="FileSystemItem"/> instances by the "Size" column.</summary>
			internal void SortSize()
			{
				this.sortedSystemItemList.Clear();

				List<FileSystemItem> temporaryFileFileSystemItemList = new List<FileSystemItem>();

				temporaryFileFileSystemItemList.AddRange(this.fileFileSystemItemList);

				SizeComparer sizeComparer = new SizeComparer(this.currentListSortDirection);

				temporaryFileFileSystemItemList.Sort(sizeComparer);

				switch (this.currentListSortDirection)
				{
					case ListSortDirection.Ascending:
						this.sortedSystemItemList.AddRange(temporaryFileFileSystemItemList);
						this.sortedSystemItemList.AddRange(this.directoryFileSystemItemList);

						break;
					case ListSortDirection.Descending:
						this.sortedSystemItemList.AddRange(this.directoryFileSystemItemList);
						this.sortedSystemItemList.AddRange(temporaryFileFileSystemItemList);

						break;
				}
			}

			/// <summary>Sorts <see cref="FileSystemItem"/> instances by the "Total free space" column.</summary>
			internal void SortTotalFreeSpace()
			{
				this.sortedSystemItemList.Clear();

				List<FileSystemItem> temporaryDirectoryFileSystemItemList = new List<FileSystemItem>();

				temporaryDirectoryFileSystemItemList.AddRange(this.directoryFileSystemItemList);

				TotalFreeSpaceComparer totalFreeSpaceComparer = new TotalFreeSpaceComparer(this.currentListSortDirection);

				temporaryDirectoryFileSystemItemList.Sort(totalFreeSpaceComparer);

				this.sortedSystemItemList.AddRange(temporaryDirectoryFileSystemItemList);
			}

			/// <summary>Sorts <see cref="FileSystemItem"/> instances by the "Total size" column.</summary>
			internal void SortTotalSize()
			{
				this.sortedSystemItemList.Clear();

				List<FileSystemItem> temporaryDirectoryFileSystemItemList = new List<FileSystemItem>();

				temporaryDirectoryFileSystemItemList.AddRange(this.directoryFileSystemItemList);

				TotalSizeComparer totalSizeComparer = new TotalSizeComparer(this.currentListSortDirection);

				temporaryDirectoryFileSystemItemList.Sort(totalSizeComparer);

				this.sortedSystemItemList.AddRange(temporaryDirectoryFileSystemItemList);
			}

			/// <summary>Sorts <see cref="FileSystemItem"/> instances by the "Volume label" column.</summary>
			internal void SortVolumeLabel()
			{
				this.sortedSystemItemList.Clear();

				List<FileSystemItem> temporaryDirectoryFileSystemItemList = new List<FileSystemItem>();

				temporaryDirectoryFileSystemItemList.AddRange(this.directoryFileSystemItemList);

				VolumeLabelComparer volumeLabelComparer = new VolumeLabelComparer(this.currentListSortDirection);

				temporaryDirectoryFileSystemItemList.Sort(volumeLabelComparer);

				this.sortedSystemItemList.AddRange(temporaryDirectoryFileSystemItemList);
			}
		}
	}
}