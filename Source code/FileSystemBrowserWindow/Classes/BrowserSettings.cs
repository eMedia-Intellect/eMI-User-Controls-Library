// <author>Stefán Örvar Sigmundsson</author>
// <copyright company="eMedia Intellect" file="BrowserSettings.cs">
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
	using System.Collections.ObjectModel;
	using System.Text;
	using System.Windows.Media.Imaging;

	/// <summary>Provides settings for the <see cref="FileSystemBrowserWindow"/> class.</summary>
	public class BrowserSettings
	{
		/// <summary>The icon displayed in the title bar of the <see cref="FileSystemBrowserWindow"/> class and windows created by it.</summary>
		/// <remarks>The store for the <see cref="Icon"/> property.</remarks>
		private BitmapFrame icon = null;

		/// <summary>Indicates whether the file encoding can be selected for the file to be saved.</summary>
		/// <remarks>The store for the <see cref="CanSelectEncoding"/> property.</remarks>
		private bool canSelectEncoding = false;

		/// <summary>Indicates whether the computer list view has a column for the available free space.</summary>
		/// <remarks>The store for the <see cref="HasAvailableFreeSpace"/> property.</remarks>
		private bool hasAvailableFreeSpace = false;

		/// <summary>Indicates whether the computer list view has a column for the drive format.</summary>
		/// <remarks>The store for the <see cref="HasDriveFormat"/> property.</remarks>
		private bool hasDriveFormat = true;

		/// <summary>Indicates whether the computer list view has a column for the drive type.</summary>
		/// <remarks>The store for the <see cref="HasDriveType"/> property.</remarks>
		private bool hasDriveType = true;

		/// <summary>Indicates whether the computer list view has a column for the root directory.</summary>
		/// <remarks>The store for the <see cref="HasRootDirectory"/> property.</remarks>
		private bool hasRootDirectory = false;

		/// <summary>Indicates whether the computer list view has a column for the total free space.</summary>
		/// <remarks>The store for the <see cref="HasTotalFreeSpace"/> property.</remarks>
		private bool hasTotalFreeSpace = true;

		/// <summary>Indicates whether the computer list view has a column for the total size.</summary>
		/// <remarks>The store for the <see cref="HasTotalSize"/> property.</remarks>
		private bool hasTotalSize = true;

		/// <summary>Indicates whether the computer list view has a column for the volume label.</summary>
		/// <remarks>The store for the <see cref="HasVolumeLabel"/> property.</remarks>
		private bool hasVolumeLabel = false;

		/// <summary>The browsing mode of the <see cref="FileSystemBrowserWindow"/> class.</summary>
		/// <remarks>The store for the <see cref="BrowsingMode"/> property.</remarks>
		private BrowsingMode browsingMode = BrowsingMode.Select;

		/// <summary>The byte multiple of the <see cref="FileSystemBrowserWindow.ByteConverter"/> class.</summary>
		/// <remarks>The store for the <see cref="ByteMultiple"/> property.</remarks>
		private ByteMultiple byteMultiple = ByteMultiple.Decimal;

		/// <summary>The supported file types for the file to be saved.</summary>
		/// <remarks>The store for the <see cref="SupportedFileTypes"/> property.</remarks>
		private Collection<FileTypeComboBoxItem> supportedFileTypes = new Collection<FileTypeComboBoxItem>() { new FileTypeComboBoxItem(string.Empty, Resources.FileSystemBrowserWindow.SaveFile.NoFileType), new FileTypeComboBoxItem(".txt", Resources.FileSystemBrowserWindow.SaveFile.TextFileType) };

		/// <summary>The encoding of the file to be saved.</summary>
		/// <remarks>The store for the <see cref="DefaultEncoding"/> property.</remarks>
		private Encoding encoding = Encoding.UTF8;

		/// <summary>The file filter for the <see cref="FileSystemBrowserWindow"/> class.</summary>
		/// <remarks>The store for the <see cref="FileFilter"/> property.</remarks>
		private FileFilter fileFilter = new FileFilter();

		/// <summary>The default file type for the file to be saved.</summary>
		/// <remarks>The store for the <see cref="DefaultFileType"/> property.</remarks>
		private FileTypeComboBoxItem defaultFileType = new FileTypeComboBoxItem(".txt", Resources.FileSystemBrowserWindow.SaveFile.TextFileType);

		/// <summary>The maximum number of directories to return by the <see cref="FileSystemBrowserWindow"/> class.</summary>
		/// <remarks>The store for the <see cref="MaximumDirectories"/> property.</remarks>
		private int maximumDirectories = 0;

		/// <summary>The maximum number of files to return by the <see cref="FileSystemBrowserWindow"/> class.</summary>
		/// <remarks>The store for the <see cref="MaximumFiles"/> property.</remarks>
		private int maximumFiles = 1;

		/// <summary>The minimum number of directories to return by the <see cref="FileSystemBrowserWindow"/> class.</summary>
		/// <remarks>The store for the <see cref="MinimumDirectories"/> property.</remarks>
		private int minimumDirectories = 0;

		/// <summary>The minimum number of files to return by the <see cref="FileSystemBrowserWindow"/> class.</summary>
		/// <remarks>The store for the <see cref="MinimumFiles"/> property.</remarks>
		private int minimumFiles = 1;

		/// <summary>The default file name for the file to be saved.</summary>
		/// <remarks>The store for the <see cref="DefaultFileName"/> property.</remarks>
		private string defaultFileName = UserControls.Resources.FileSystemBrowserWindow.SaveFile.NewFile;

		/// <summary>The path of the <see cref="FileSystemBrowserWindow"/> class.</summary>
		/// <remarks>The store for the <see cref="Path"/> property.</remarks>
		private string path = string.Empty;

		/// <summary>Gets or sets a value indicating the icon displayed in the title bar of the <see cref="FileSystemBrowserWindow"/> and windows created by it.</summary>
		/// <value>Represents the <see cref="icon"/> field.</value>
		public BitmapFrame Icon
		{
			get
			{
				return this.icon;
			}

			set
			{
				this.icon = value;
			}
		}

		/// <summary>Gets or sets a value indicating whether the file encoding can be selected for the file to be saved.</summary>
		/// <value>Represents the <see cref="canSelectEncoding"/> field.</value>
		public bool CanSelectEncoding
		{
			get
			{
				return this.canSelectEncoding;
			}

			set
			{
				this.canSelectEncoding = value;
			}
		}

		/// <summary>Gets or sets a value indicating whether the computer list view of the <see cref="FileSystemBrowserWindow"/> has a column for the available free space.</summary>
		/// <value>Represents the <see cref="hasAvailableFreeSpace"/> field.</value>
		public bool HasAvailableFreeSpace
		{
			get
			{
				return this.hasAvailableFreeSpace;
			}

			set
			{
				this.hasAvailableFreeSpace = value;
			}
		}

		/// <summary>Gets or sets a value indicating whether the computer list view of the <see cref="FileSystemBrowserWindow"/> has a column for the drive format.</summary>
		/// <value>Represents the <see cref="hasDriveFormat"/> field.</value>
		public bool HasDriveFormat
		{
			get
			{
				return this.hasDriveFormat;
			}

			set
			{
				this.hasDriveFormat = value;
			}
		}

		/// <summary>Gets or sets a value indicating whether the computer list view of the <see cref="FileSystemBrowserWindow"/> has a column for the drive type.</summary>
		/// <value>Represents the <see cref="hasDriveType"/> field.</value>
		public bool HasDriveType
		{
			get
			{
				return this.hasDriveType;
			}

			set
			{
				this.hasDriveType = value;
			}
		}

		/// <summary>Gets or sets a value indicating whether the computer list view of the <see cref="FileSystemBrowserWindow"/> has a column for the root directory.</summary>
		/// <value>Represents the <see cref="hasRootDirectory"/> field.</value>
		public bool HasRootDirectory
		{
			get
			{
				return this.hasRootDirectory;
			}

			set
			{
				this.hasRootDirectory = value;
			}
		}

		/// <summary>Gets or sets a value indicating whether the computer list view of the <see cref="FileSystemBrowserWindow"/> has a column for the total free space.</summary>
		/// <value>Represents the <see cref="hasTotalFreeSpace"/> field.</value>
		public bool HasTotalFreeSpace
		{
			get
			{
				return this.hasTotalFreeSpace;
			}

			set
			{
				this.hasTotalFreeSpace = value;
			}
		}

		/// <summary>Gets or sets a value indicating whether the computer list view of the <see cref="FileSystemBrowserWindow"/> has a column for the total size.</summary>
		/// <value>Represents the <see cref="hasTotalSize"/> field.</value>
		public bool HasTotalSize
		{
			get
			{
				return this.hasTotalSize;
			}

			set
			{
				this.hasTotalSize = value;
			}
		}

		/// <summary>Gets or sets a value indicating whether the computer list view of the <see cref="FileSystemBrowserWindow"/> has a column for the volume label.</summary>
		/// <value>Represents the <see cref="hasVolumeLabel"/> field.</value>
		public bool HasVolumeLabel
		{
			get
			{
				return this.hasVolumeLabel;
			}

			set
			{
				this.hasVolumeLabel = value;
			}
		}

		/// <summary>Gets or sets a value indicating the browsing mode of the <see cref="FileSystemBrowserWindow"/> class.</summary>
		/// <value>Represents the <see cref="browsingMode"/> field.</value>
		public BrowsingMode BrowsingMode
		{
			get
			{
				return this.browsingMode;
			}

			set
			{
				this.browsingMode = value;
			}
		}

		/// <summary>Gets or sets a value indicating the byte multiple of the <see cref="FileSystemBrowserWindow"/> class.</summary>
		/// <remarks>Byte calculations are performed by the <see cref="FileSystemBrowserWindow.ByteConverter"/> class.</remarks>
		/// <value>Represents the <see cref="byteMultiple"/> field.</value>
		public ByteMultiple ByteMultiple
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

		/// <summary>Gets a value indicating the supported file types for the file to be saved.</summary>
		/// <value>Represents the <see cref="supportedFileTypes"/> field.</value>
		public Collection<FileTypeComboBoxItem> SupportedFileTypes
		{
			get
			{
				return this.supportedFileTypes;
			}
		}

		/// <summary>Gets or sets a value indicating the default encoding of the file to be saved.</summary>
		/// <value>Represents the <see cref="encoding"/> field.</value>
		public Encoding DefaultEncoding
		{
			get
			{
				return this.encoding;
			}

			set
			{
				this.encoding = value;
			}
		}

		/// <summary>Gets or sets a value indicating the file filter for the <see cref="FileSystemBrowserWindow"/> class.</summary>
		/// <value>Represents the <see cref="fileFilter"/> field.</value>
		public FileFilter FileFilter
		{
			get
			{
				return this.fileFilter;
			}

			set
			{
				this.fileFilter = value;
			}
		}

		/// <summary>Gets or sets a value indicating the default file type for the file to be saved.</summary>
		/// <value>Represents the <see cref="defaultFileType"/> field.</value>
		public FileTypeComboBoxItem DefaultFileType
		{
			get
			{
				return this.defaultFileType;
			}

			set
			{
				this.defaultFileType = value;
			}
		}

		/// <summary>Gets or sets a value indicating the maximum number of directories to return by the <see cref="FileSystemBrowserWindow"/> class.</summary>
		/// <value>Represents the <see cref="maximumDirectories"/> field.</value>
		public int MaximumDirectories
		{
			get
			{
				return this.maximumDirectories;
			}

			set
			{
				this.maximumDirectories = value;
			}
		}

		/// <summary>Gets or sets a value indicating the maximum number of files to return by the <see cref="FileSystemBrowserWindow"/> class.</summary>
		/// <value>Represents the <see cref="maximumFiles"/> field.</value>
		public int MaximumFiles
		{
			get
			{
				return this.maximumFiles;
			}

			set
			{
				this.maximumFiles = value;
			}
		}

		/// <summary>Gets or sets a value indicating the minimum number of directories to return by the <see cref="FileSystemBrowserWindow"/> class.</summary>
		/// <value>Represents the <see cref="minimumDirectories"/> field.</value>
		public int MinimumDirectories
		{
			get
			{
				return this.minimumDirectories;
			}

			set
			{
				this.minimumDirectories = value;
			}
		}

		/// <summary>Gets or sets a value indicating the minimum number of files to return by the <see cref="FileSystemBrowserWindow"/> class.</summary>
		/// <value>Represents the <see cref="minimumFiles"/> field.</value>
		public int MinimumFiles
		{
			get
			{
				return this.minimumFiles;
			}

			set
			{
				this.minimumFiles = value;
			}
		}

		/// <summary>Gets or sets a value indicating the default file name for the file to be saved.</summary>
		/// <remarks>If no value is provided then the default value is obtained from a resource.</remarks>
		/// <value>Represents the <see cref="defaultFileName"/> field.</value>
		public string DefaultFileName
		{
			get
			{
				return this.defaultFileName;
			}

			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}

				if (value.IndexOfAny(System.IO.Path.GetInvalidFileNameChars()) >= 0)
				{
					this.defaultFileName = value;
				}
			}
		}

		/// <summary>Gets or sets a value indicating the path of the <see cref="FileSystemBrowserWindow"/> class.</summary>
		/// <value>Represents the <see cref="path"/> field.</value>
		public string Path
		{
			get
			{
				return this.path;
			}

			set
			{
				this.path = value ?? throw new ArgumentNullException("value");
			}
		}

		/// <summary>Adds a supported file type for the file to be saved.</summary>
		/// <remarks>The supported file types can be obtained as a collection via the <see cref="SupportedFileTypes"/> property.</remarks>
		/// <param name="supportedFileType">The supported file type to add.</param>
		public void AddSupportedFileType(FileTypeComboBoxItem supportedFileType)
		{
			this.supportedFileTypes.Add(supportedFileType);
		}

		/// <summary>Clears the supported file types for the file to be saved.</summary>
		/// <remarks>The method clears the collection obtained via the <see cref="SupportedFileTypes"/> property.</remarks>
		public void ClearSupportedFileTypes()
		{
			this.supportedFileTypes.Clear();
		}
	}
}