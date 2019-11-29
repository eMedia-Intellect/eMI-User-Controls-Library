// <author>Stefán Örvar Sigmundsson</author>
// <copyright company="eMedia Intellect" file="ActionButton_Click.cs">
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
	using System.Collections;
	using System.IO;
	using System.Text;
	using System.Windows;

	/// <content>Contains the <see cref="ActionButton_Click"/> method.</content>
	public partial class FileSystemBrowserWindow
	{
		/// <summary>Closes the window and signals that the browsing was successful when the button is clicked.</summary>
		/// <param name="sender">The sender object of the event handler.</param>
		/// <param name="e">The state information of the event handler.</param>
		private void ActionButton_Click(object sender, RoutedEventArgs e)
		{
			if (this.browserSettings.BrowsingMode != BrowsingMode.Save)
			{
				IList selectedItemsIList = this.fileSystemListView.SelectedItems;

				foreach (object currentItem in selectedItemsIList)
				{
					FileSystemItem currentFileSystemItem = (FileSystemItem)currentItem;

					switch (currentFileSystemItem.FileSystemItemType)
					{
						case FileSystemItemType.Directory:
							if (string.IsNullOrEmpty(this.path))
							{
								this.selectedDirectories.Add(currentFileSystemItem.Name);
							}
							else
							{
								if (this.path.EndsWith("\\", System.StringComparison.Ordinal))
								{
									this.selectedDirectories.Add(this.path + currentFileSystemItem.Name);
								}
								else
								{
									this.selectedDirectories.Add(this.path + Path.DirectorySeparatorChar + currentFileSystemItem.Name);
								}
							}

							break;
						case FileSystemItemType.File:
							if (this.path.EndsWith("\\", System.StringComparison.Ordinal))
							{
								this.selectedFiles.Add(this.path + currentFileSystemItem.Name);
							}
							else
							{
								this.selectedFiles.Add(this.path + Path.DirectorySeparatorChar + currentFileSystemItem.Name);
							}

							break;
					}
				}
			}
			else
			{
				this.savingFileType = (FileTypeComboBoxItem)this.fileTypesComboBox.SelectedItem;

				this.fileNameTextBox.Text = this.fileNameTextBox.Text.Trim();

				this.savingFilePath = this.path + "\\" + this.fileNameTextBox.Text;

				if (!this.fileNameTextBox.Text.EndsWith(this.savingFileType.Key, StringComparison.OrdinalIgnoreCase))
				{
					this.savingFilePath += this.savingFileType.Key;
				}

				if (this.utf8RadioButton.IsChecked == true)
				{
					if (this.byteOrderMarkCheckBox.IsChecked == true)
					{
						this.savingFileEncoding = new UTF8Encoding(true);
					}
					else
					{
						this.savingFileEncoding = new UTF8Encoding(false);
					}
				}
				else if (this.utf16RadioButton.IsChecked == true)
				{
					if (this.bigEndianRadioButton.IsChecked == true)
					{
						this.savingFileEncoding = new UnicodeEncoding(true, true);
					}
					else if (this.littleEndianRadioButton.IsChecked == true)
					{
						this.savingFileEncoding = new UnicodeEncoding(false, true);
					}
				}
				else if (this.utf32RadioButton.IsChecked == true)
				{
					if (this.bigEndianRadioButton.IsChecked == true)
					{
						this.savingFileEncoding = new UTF32Encoding(true, true);
					}
					else if (this.littleEndianRadioButton.IsChecked == true)
					{
						this.savingFileEncoding = new UTF32Encoding(false, true);
					}
				}
			}

			this.DialogResult = true;
		}
	}
}