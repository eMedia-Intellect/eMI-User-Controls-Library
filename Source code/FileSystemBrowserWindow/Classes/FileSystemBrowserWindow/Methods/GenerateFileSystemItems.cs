// <author>Stefán Örvar Sigmundsson</author>
// <copyright company="eMedia Intellect" file="GenerateFileSystemItems.cs">
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
	using System.IO;
	using System.Security;

	/// <content>Contains the <see cref="GenerateFileSystemItems"/> method.</content>
	public partial class FileSystemBrowserWindow
	{
		/// <summary>Generates instances of the <see cref="FileSystemItem"/> class.</summary>
		private void GenerateFileSystemItems()
		{
			if (this.path.Length == 0)
			{
				foreach (DriveInfo currentDriveInfo in DriveInfo.GetDrives())
				{
					FileSystemItem currentFileSystemItem = new FileSystemItem() { ByteMultiple = this.browserSettings.ByteMultiple };

					currentFileSystemItem.Name = currentDriveInfo.Name;

					if (this.browserSettings.HasVolumeLabel)
					{
						try
						{
							currentFileSystemItem.VolumeLabel = currentDriveInfo.VolumeLabel;
						}
						catch
						{
						}
					}

					if (this.browserSettings.HasRootDirectory)
					{
						DirectoryInfo currentDirectoryInfo = currentDriveInfo.RootDirectory;

						currentFileSystemItem.RootDirectory = currentDirectoryInfo.Name;
					}

					if (this.browserSettings.HasDriveType)
					{
						switch (currentDriveInfo.DriveType)
						{
							case DriveType.CDRom:
								currentFileSystemItem.DriveType = UserControls.Resources.FileSystemBrowserWindow.DriveTypeEnumerations.CDRom;

								break;
							case DriveType.Fixed:
								currentFileSystemItem.DriveType = UserControls.Resources.FileSystemBrowserWindow.DriveTypeEnumerations.Fixed;

								break;
							case DriveType.Network:
								currentFileSystemItem.DriveType = UserControls.Resources.FileSystemBrowserWindow.DriveTypeEnumerations.Network;

								break;
							case DriveType.NoRootDirectory:
								currentFileSystemItem.DriveType = UserControls.Resources.FileSystemBrowserWindow.DriveTypeEnumerations.NoRootDirectory;

								break;
							case DriveType.Ram:
								currentFileSystemItem.DriveType = UserControls.Resources.FileSystemBrowserWindow.DriveTypeEnumerations.Ram;

								break;
							case DriveType.Removable:
								currentFileSystemItem.DriveType = UserControls.Resources.FileSystemBrowserWindow.DriveTypeEnumerations.Removable;

								break;
							case DriveType.Unknown:
								currentFileSystemItem.DriveType = UserControls.Resources.FileSystemBrowserWindow.DriveTypeEnumerations.Unknown;

								break;
							default:
								currentFileSystemItem.DriveType = currentDriveInfo.DriveType.ToString();

								break;
						}
					}

					if (this.browserSettings.HasDriveFormat)
					{
						try
						{
							currentFileSystemItem.DriveFormat = currentDriveInfo.DriveFormat;
						}
						catch
						{
						}
					}

					if (this.browserSettings.HasAvailableFreeSpace)
					{
						try
						{
							currentFileSystemItem.AvailableFreeSpaceLong = currentDriveInfo.AvailableFreeSpace;
						}
						catch
						{
						}
					}

					if (this.browserSettings.HasTotalFreeSpace)
					{
						try
						{
							currentFileSystemItem.TotalFreeSpaceLong = currentDriveInfo.TotalFreeSpace;
						}
						catch
						{
						}
					}

					if (this.browserSettings.HasTotalSize)
					{
						try
						{
							currentFileSystemItem.TotalSizeLong = currentDriveInfo.TotalSize;
						}
						catch
						{
						}
					}

					this.fileSystemItemSorter.Add(currentFileSystemItem);
				}
			}
			else
			{
				DirectoryInfo listingDirectoryInfo = new DirectoryInfo(this.path);

				try
				{
					foreach (DirectoryInfo currentDirectoryInfo in listingDirectoryInfo.GetDirectories())
					{
						this.fileSystemItemSorter.Add(new FileSystemItem() { ByteMultiple = this.browserSettings.ByteMultiple, FileSystemItemType = FileSystemItemType.Directory, Name = currentDirectoryInfo.Name, Accessed = currentDirectoryInfo.LastAccessTime, Written = currentDirectoryInfo.LastWriteTime, Created = currentDirectoryInfo.CreationTime });
					}
				}
				catch (DirectoryNotFoundException)
				{
					if (this.isInitialNavigation)
					{
						this.NavigateFileSystem(string.Empty);

						return;
					}
					else
					{
						ErrorWindow exceptionErrorWindow = new ErrorWindow(this, this.path, UserControls.Resources.ErrorWindow.DirectoryNotFoundException);

						exceptionErrorWindow.Icon = this.browserSettings.Icon;

						exceptionErrorWindow.ShowDialog();

						this.NavigateFileSystem(PathManipulator.GetParentDirectory(this.path));
					}

					return;
				}
				catch (SecurityException)
				{
					if (this.isInitialNavigation)
					{
						this.NavigateFileSystem(string.Empty);

						return;
					}
					else
					{
						ErrorWindow exceptionErrorWindow = new ErrorWindow(this, this.path, UserControls.Resources.ErrorWindow.SecurityException);

						exceptionErrorWindow.Icon = this.browserSettings.Icon;

						exceptionErrorWindow.ShowDialog();

						this.NavigateFileSystem(PathManipulator.GetParentDirectory(this.path));
					}

					return;
				}
				catch (UnauthorizedAccessException)
				{
					if (this.isInitialNavigation)
					{
						this.NavigateFileSystem(string.Empty);

						return;
					}
					else
					{
						ErrorWindow exceptionErrorWindow = new ErrorWindow(this, this.path, UserControls.Resources.ErrorWindow.UnauthorizedAccessException);

						exceptionErrorWindow.Icon = this.browserSettings.Icon;

						exceptionErrorWindow.ShowDialog();

						this.NavigateFileSystem(PathManipulator.GetParentDirectory(this.path));
					}

					return;
				}

				try
				{
					foreach (FileInfo currentFileInfo in listingDirectoryInfo.GetFiles())
					{
						if (this.browserSettings.FileFilter.Process(currentFileInfo))
						{
							this.fileSystemItemSorter.Add(new FileSystemItem() { ByteMultiple = this.browserSettings.ByteMultiple, FileSystemItemType = FileSystemItemType.File, Name = currentFileInfo.Name, Length = currentFileInfo.Length, Accessed = currentFileInfo.LastAccessTime, Written = currentFileInfo.LastWriteTime, Created = currentFileInfo.CreationTime });
						}
					}
				}
				catch (DirectoryNotFoundException)
				{
					if (this.isInitialNavigation)
					{
						this.NavigateFileSystem(string.Empty);

						return;
					}
					else
					{
						ErrorWindow exceptionErrorWindow = new ErrorWindow(this, this.path, UserControls.Resources.ErrorWindow.DirectoryNotFoundException);

						exceptionErrorWindow.Icon = this.browserSettings.Icon;

						exceptionErrorWindow.ShowDialog();

						this.NavigateFileSystem(PathManipulator.GetParentDirectory(this.path));
					}

					return;
				}
			}

			this.fileSystemItemSorter.Sort();
		}
	}
}