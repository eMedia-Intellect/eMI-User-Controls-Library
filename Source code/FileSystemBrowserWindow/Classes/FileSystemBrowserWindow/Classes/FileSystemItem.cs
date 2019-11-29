// <author>Stefán Örvar Sigmundsson</author>
// <copyright company="eMedia Intellect" file="FileSystemItem.cs">
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
	using System.Globalization;
	using System.Threading;

	/// <content>Contains the <see cref="FileSystemItem"/> class.</content>
	public partial class FileSystemBrowserWindow
	{
		/// <summary>Provides a file system item for the <see cref="FileSystemBrowserWindow"/> class.</summary>
		internal class FileSystemItem : IComparable<FileSystemItem>
		{
			/// <summary>The current culture information.</summary>
			private CultureInfo currentCultureInfo = Thread.CurrentThread.CurrentCulture;

			/// <summary>The byte multiple of the <see cref="ByteConverter"/> class.</summary>
			/// <remarks>The store for the <see cref="ByteMultiple"/> property.</remarks>
			private ByteMultiple byteMultiple = ByteMultiple.Decimal;

			/// <summary>The time of the creation of the file system item.</summary>
			/// <remarks>The store for the <see cref="Created"/> property.</remarks>
			private DateTime creationTime;

			/// <summary>The time of the last access to the file system item.</summary>
			/// <remarks>The store for the <see cref="Accessed"/> property.</remarks>
			private DateTime lastAccessTime;

			/// <summary>The time of the last write to the file system item.</summary>
			/// <remarks>The store for the <see cref="Written"/> property.</remarks>
			private DateTime lastWriteTime;

			/// <summary>The type of the file system item.</summary>
			/// <remarks>The store for the <see cref="FileSystemItemType"/> property.</remarks>
			private FileSystemItemType fileSystemItemType;

			/// <summary>The available free space on the drive in bytes.</summary>
			/// <remarks>The store for the <see cref="AvailableFreeSpaceLong"/> property.</remarks>
			private long availableFreeSpaceLong;

			/// <summary>The total free space on the drive in bytes.</summary>
			/// <remarks>The store for the <see cref="TotalFreeSpaceLong"/> property.</remarks>
			private long totalFreeSpaceLong;

			/// <summary>The total size of the drive in bytes.</summary>
			/// <remarks>The store for the <see cref="TotalSizeLong"/> property.</remarks>
			private long totalSizeLong;

			/// <summary>The size of the file in bytes.</summary>
			/// <remarks>The store for the <see cref="Length"/> property.</remarks>
			private long length;

			/// <summary>Gets a value indicating the available free space on the drive.</summary>
			/// <remarks>This property is used by FileSystemBrowserWindow.xaml.</remarks>
			/// <value>Represents the <see cref="availableFreeSpaceLong"/> field after being processed by the <see cref="ByteConverter"/> class.</value>
			public string AvailableFreeSpace
			{
				get
				{
					return ByteConverter.Process(this.availableFreeSpaceLong, this.byteMultiple);
				}
			}

			/// <summary>Gets a value indicating the time of the creation of the file system item.</summary>
			/// <remarks>This property is used by FileSystemBrowserWindow.xaml.</remarks>
			/// <value>Represents the <see cref="creationTime"/> field after being converted to a string.</value>
			public string CreationTime
			{
				get
				{
					return this.creationTime.ToString(this.currentCultureInfo);
				}
			}

			/// <summary>Gets or sets a value indicating the format of the drive.</summary>
			/// <remarks>This property is used by FileSystemBrowserWindow.xaml.</remarks>
			public string DriveFormat
			{
				get;
				set;
			}

			/// <summary>Gets or sets a value indicating the type of the drive.</summary>
			/// <remarks>This property is used by FileSystemBrowserWindow.xaml.</remarks>
			public string DriveType
			{
				get;
				set;
			}

			/// <summary>Gets a value indicating the path to the icon representing the file system item.</summary>
			/// <remarks>This property is used by FileSystemBrowserWindow.xaml.</remarks>
			public string Icon
			{
				get
				{
					switch (this.fileSystemItemType)
					{
						case FileSystemItemType.Directory:
							return @"..\..\Images\Directory.png";

						case FileSystemItemType.File:
							return @"..\..\Images\File.png";

						default:
							return string.Empty;
					}
				}
			}

			/// <summary>Gets a value indicating the last access to the file system item.</summary>
			/// <remarks>This property is used by FileSystemBrowserWindow.xaml.</remarks>
			/// <value>Represents the <see cref="lastAccessTime"/> field after being converted to a string.</value>
			public string LastAccessTime
			{
				get
				{
					return this.lastAccessTime.ToString(this.currentCultureInfo);
				}
			}

			/// <summary>Gets a value indicating the last write to the file system item.</summary>
			/// <remarks>This property is used by FileSystemBrowserWindow.xaml.</remarks>
			/// <value>Represents the <see cref="lastWriteTime"/> field after being converted to a string.</value>
			public string LastWriteTime
			{
				get
				{
					return this.lastWriteTime.ToString(this.currentCultureInfo);
				}
			}

			/// <summary>Gets or sets a value indicating the name of the file system item.</summary>
			/// <remarks>This property is used by FileSystemBrowserWindow.xaml.</remarks>
			public string Name
			{
				get;
				set;
			}

			/// <summary>Gets or sets a value indicating the root directory of the drive.</summary>
			/// <remarks>This property is used by FileSystemBrowserWindow.xaml.</remarks>
			public string RootDirectory
			{
				get;
				set;
			}

			/// <summary>Gets a value indicating the size of the file.</summary>
			/// <remarks>This property is used by FileSystemBrowserWindow.xaml.</remarks>
			/// <value>Represents the <see cref="length"/> field after being processed by the <see cref="ByteConverter"/> class.</value>
			public string Size
			{
				get
				{
					if (this.fileSystemItemType == FileSystemItemType.File)
					{
						return ByteConverter.Process(this.length, this.byteMultiple);
					}
					else
					{
						return string.Empty;
					}
				}
			}

			/// <summary>Gets a value indicating the total free space on the drive.</summary>
			/// <remarks>This property is used by FileSystemBrowserWindow.xaml.</remarks>
			/// <value>Represents the <see cref="totalFreeSpaceLong"/> field after being processed by the <see cref="ByteConverter"/> class.</value>
			public string TotalFreeSpace
			{
				get
				{
					return ByteConverter.Process(this.totalFreeSpaceLong, this.byteMultiple);
				}
			}

			/// <summary>Gets a value indicating the total size of the drive.</summary>
			/// <remarks>This property is used by FileSystemBrowserWindow.xaml.</remarks>
			/// <value>Represents the <see cref="totalSizeLong"/> field after being processed by the <see cref="ByteConverter"/> class.</value>
			public string TotalSize
			{
				get
				{
					return ByteConverter.Process(this.totalSizeLong, this.byteMultiple);
				}
			}

			/// <summary>Gets or sets a value indicating the volume label of the drive.</summary>
			/// <remarks>This property is used by FileSystemBrowserWindow.xaml.</remarks>
			public string VolumeLabel
			{
				get;
				set;
			}

			/// <summary>Gets or sets a value indicating the byte multiple of the <see cref="ByteConverter"/> class.</summary>
			/// <value>Represents the <see cref="byteMultiple"/> field.</value>
			internal ByteMultiple ByteMultiple
			{
				get
				{
					return this.byteMultiple;
				}

				set
				{
					this.byteMultiple = value;
				}
			}

			/// <summary>Gets or sets a value indicating the type of the file system item.</summary>
			/// <value>Represents the <see cref="fileSystemItemType"/> field.</value>
			internal FileSystemItemType FileSystemItemType
			{
				get
				{
					return this.fileSystemItemType;
				}

				set
				{
					this.fileSystemItemType = value;
				}
			}

			/// <summary>Gets or sets a value indicating the last access to the file system item.</summary>
			/// <value>Represents the <see cref="lastAccessTime"/> field.</value>
			internal DateTime Accessed
			{
				get
				{
					return this.lastAccessTime;
				}

				set
				{
					this.lastAccessTime = value;
				}
			}

			/// <summary>Gets or sets a value indicating the time of the creation of the file system item.</summary>
			/// <value>Represents the <see cref="creationTime"/> field.</value>
			internal DateTime Created
			{
				get
				{
					return this.creationTime;
				}

				set
				{
					this.creationTime = value;
				}
			}

			/// <summary>Gets or sets a value indicating the last write to the file system item.</summary>
			/// <value>Represents the <see cref="lastWriteTime"/> field.</value>
			internal DateTime Written
			{
				get
				{
					return this.lastWriteTime;
				}

				set
				{
					this.lastWriteTime = value;
				}
			}

			/// <summary>Sets a value indicating the available free space on the drive.</summary>
			/// <value>Represents the <see cref="availableFreeSpaceLong"/> field.</value>
			internal long AvailableFreeSpaceLong
			{
				set
				{
					this.availableFreeSpaceLong = value;
				}
			}

			/// <summary>Sets a value indicating the size of the file.</summary>
			/// <value>Represents the <see cref="length"/> field.</value>
			internal long Length
			{
				set
				{
					this.length = value;
				}
			}

			/// <summary>Gets a value indicating the unformatted available free space on the drive.</summary>
			/// <value>Represents the <see cref="availableFreeSpaceLong"/> field.</value>
			internal long RawAvailableFreeSpace
			{
				get
				{
					return this.availableFreeSpaceLong;
				}
			}

			/// <summary>Gets a value indicating the unformatted size of the file.</summary>
			/// <value>Represents the <see cref="length"/> field.</value>
			internal long RawSize
			{
				get
				{
					return this.length;
				}
			}

			/// <summary>Gets a value indicating the unformatted total free space on the drive.</summary>
			/// <value>Represents the <see cref="totalFreeSpaceLong"/> field.</value>
			internal long RawTotalFreeSpace
			{
				get
				{
					return this.totalFreeSpaceLong;
				}
			}

			/// <summary>Gets a value indicating the unformatted total size of the drive.</summary>
			/// <value>Represents the <see cref="totalSizeLong"/> field.</value>
			internal long RawTotalSize
			{
				get
				{
					return this.totalSizeLong;
				}
			}

			/// <summary>Sets a value indicating the total free space on the drive.</summary>
			/// <value>Represents the <see cref="totalFreeSpaceLong"/> field.</value>
			internal long TotalFreeSpaceLong
			{
				set
				{
					this.totalFreeSpaceLong = value;
				}
			}

			/// <summary>Sets a value indicating the total size of the drive.</summary>
			/// <value>Represents the <see cref="totalSizeLong"/> field.</value>
			internal long TotalSizeLong
			{
				set
				{
					this.totalSizeLong = value;
				}
			}

			/// <summary>Compares an instance of the <see cref="FileSystemItem"/> class to another.</summary>
			/// <param name="that">The instance to which to compare.</param>
			/// <returns>An integer that indicates the position in the sort order.</returns>
			public int CompareTo(FileSystemItem that)
			{
				if (that == null)
				{
					return 1;
				}

				return string.Compare(this.Name, that.Name, StringComparison.CurrentCulture);
			}
		}
	}
}