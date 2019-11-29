// <author>Stefán Örvar Sigmundsson</author>
// <copyright company="eMedia Intellect" file="RenameFile.cs">
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
	using System.Windows;

	/// <content>Contains the <see cref="RenameFile"/> method.</content>
	internal partial class RenameWindow
	{
		/// <summary>Renames a file in the current path of the <see cref="RenameWindow.fileSystemBrowserWindow"/> field.</summary>
		private void RenameFile()
		{
			try
			{
				File.Move(FileSystemBrowserWindow.PathManipulator.ConcatenatePath(this.fileSystemBrowserWindow.CurrentPath, this.currentNameTextBox.Text), FileSystemBrowserWindow.PathManipulator.ConcatenatePath(this.fileSystemBrowserWindow.CurrentPath, this.newNameTextBox.Text));

				this.fileSystemBrowserWindow.NavigateFileSystem(this.fileSystemBrowserWindow.CurrentPath);

				this.Close();
			}
			catch (ArgumentException)
			{
				this.errorTextBlock.Text = UserControls.Resources.NewWindow.ArgumentException;
				this.errorTextBlock.Visibility = Visibility.Visible;
			}
			catch (DirectoryNotFoundException)
			{
				this.errorTextBlock.Text = UserControls.Resources.ErrorWindow.DirectoryNotFoundException;
				this.errorTextBlock.Visibility = Visibility.Visible;
			}
			catch (PathTooLongException)
			{
				this.errorTextBlock.Text = UserControls.Resources.ErrorWindow.PathTooLongException;
				this.errorTextBlock.Visibility = Visibility.Visible;
			}
			catch (IOException)
			{
				if (File.Exists(FileSystemBrowserWindow.PathManipulator.ConcatenatePath(this.fileSystemBrowserWindow.CurrentPath, this.newNameTextBox.Text)))
				{
					this.errorTextBlock.Text = UserControls.Resources.NewWindow.FileExistsMessage;
					this.errorTextBlock.Visibility = Visibility.Visible;
				}
				else
				{
					this.errorTextBlock.Text = UserControls.Resources.ErrorWindow.IOException;
					this.errorTextBlock.Visibility = Visibility.Visible;
				}
			}
			catch (NotSupportedException)
			{
				this.errorTextBlock.Text = UserControls.Resources.NewWindow.ArgumentException;
				this.errorTextBlock.Visibility = Visibility.Visible;
			}
			catch (UnauthorizedAccessException)
			{
				if (Directory.Exists(FileSystemBrowserWindow.PathManipulator.ConcatenatePath(this.fileSystemBrowserWindow.CurrentPath, this.newNameTextBox.Text)))
				{
					this.errorTextBlock.Text = UserControls.Resources.NewWindow.DirectoryClashMessage;
					this.errorTextBlock.Visibility = Visibility.Visible;
				}
				else
				{
					this.errorTextBlock.Text = UserControls.Resources.ErrorWindow.UnauthorizedAccessException;
					this.errorTextBlock.Visibility = Visibility.Visible;
				}
			}
		}
	}
}