// <author>Stefán Örvar Sigmundsson</author>
// <copyright company="eMedia Intellect" file="NameTextBox_TextChanged.cs">
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
	/// <content>Contains the <see cref="NameTextBox_TextChanged"/> method.</content>
	internal partial class NewWindow
	{
		/// <summary>Checks for the existence of a file system item by the specified name when the text is changed.</summary>
		/// <param name="sender">The sender object of the event handler.</param>
		/// <param name="e">The state information of the event handler.</param>
		private void NameTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
		{
			if (this.folderRadioButton.IsChecked ?? false)
			{
				this.fileSystemItemType = FileSystemBrowserWindow.FileSystemItemType.Directory;
			}
			else if (this.fileRadioButton.IsChecked ?? false)
			{
				this.fileSystemItemType = FileSystemBrowserWindow.FileSystemItemType.File;
			}

			this.CheckExistence();
		}
	}
}