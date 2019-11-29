// <author>Stefán Örvar Sigmundsson</author>
// <copyright company="eMedia Intellect" file="SortingColumn.cs">
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
	/// <content>Contains the <see cref="SortingColumn"/> enumeration.</content>
	public partial class FileSystemBrowserWindow
	{
		/// <summary>The column sorting to perform by the <see cref="fileSystemItemSorter"/> method.</summary>
		internal enum SortingColumn
		{
			/// <summary>Represents the "Available free space" column of the <see cref="fileSystemListView"/> field.</summary>
			AvailableFreeSpace,

			/// <summary>Represents the "Created" column of the <see cref="fileSystemListView"/> field.</summary>
			CreationTime,

			/// <summary>Represents the "Format" column of the <see cref="fileSystemListView"/> field.</summary>
			DriveFormat,

			/// <summary>Represents the "Type" column of the <see cref="fileSystemListView"/> field.</summary>
			DriveType,

			/// <summary>Represents the "Accessed" column of the <see cref="fileSystemListView"/> field.</summary>
			LastAccessTime,

			/// <summary>Represents the "Modified" column of the <see cref="fileSystemListView"/> field.</summary>
			LastWriteTime,

			/// <summary>Represents the "Name" column of the <see cref="fileSystemListView"/> field.</summary>
			Name,

			/// <summary>Represents the "Root directory" column of the <see cref="fileSystemListView"/> field.</summary>
			RootDirectory,

			/// <summary>Represents the "Size" column of the <see cref="fileSystemListView"/> field.</summary>
			Size,

			/// <summary>Represents the "Total free space" column of the <see cref="fileSystemListView"/> field.</summary>
			TotalFreeSpace,

			/// <summary>Represents the "Total size" column of the <see cref="fileSystemListView"/> field.</summary>
			TotalSize,

			/// <summary>Represents the "Volume label" column of the <see cref="fileSystemListView"/> field.</summary>
			VolumeLabel
		}
	}
}