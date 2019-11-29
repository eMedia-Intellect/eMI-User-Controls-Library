// <author>Stefán Örvar Sigmundsson</author>
// <copyright company="eMedia Intellect" file="CheckExistence.cs">
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
	using System.IO;
	using System.Windows;

	/// <content>Contains the <see cref="CheckExistence"/> method.</content>
	internal partial class NewWindow
	{
		/// <summary>Checks whether a file system item exists in the current path of the <see cref="NewWindow.fileSystemBrowserWindow"/> field.</summary>
		private void CheckExistence()
		{
			if (string.IsNullOrEmpty(this.nameTextBox.Text))
			{
				if (this.createButton != null)
				{
					this.createButton.IsEnabled = false;
				}

				return;
			}

			switch (this.fileSystemItemType)
			{
				case FileSystemBrowserWindow.FileSystemItemType.Directory:
					if (Directory.Exists(this.fileSystemBrowserWindow.CurrentPath + this.nameTextBox.Text))
					{
						this.errorTextBlock.Text = UserControls.Resources.NewWindow.DirectoryExistsMessage;
						this.errorTextBlock.Visibility = Visibility.Visible;

						this.createButton.IsEnabled = false;

						return;
					}
					else if (File.Exists(this.fileSystemBrowserWindow.CurrentPath + this.nameTextBox.Text))
					{
						this.errorTextBlock.Text = UserControls.Resources.NewWindow.FileClashMessage;
						this.errorTextBlock.Visibility = Visibility.Visible;

						this.createButton.IsEnabled = false;

						return;
					}

					break;
				case FileSystemBrowserWindow.FileSystemItemType.File:
					if (File.Exists(this.fileSystemBrowserWindow.CurrentPath + this.nameTextBox.Text))
					{
						this.errorTextBlock.Text = UserControls.Resources.NewWindow.FileExistsMessage;
						this.errorTextBlock.Visibility = Visibility.Visible;

						this.createButton.IsEnabled = false;
					}
					else if (Directory.Exists(this.fileSystemBrowserWindow.CurrentPath + this.nameTextBox.Text))
					{
						this.errorTextBlock.Text = UserControls.Resources.NewWindow.DirectoryClashMessage;
						this.errorTextBlock.Visibility = Visibility.Visible;

						this.createButton.IsEnabled = false;

						return;
					}

					break;
			}

			this.errorTextBlock.Visibility = Visibility.Collapsed;

			this.createButton.IsEnabled = true;
		}
	}
}