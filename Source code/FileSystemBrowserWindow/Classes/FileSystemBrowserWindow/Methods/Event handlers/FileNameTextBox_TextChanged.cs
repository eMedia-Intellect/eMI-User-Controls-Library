// <author>Stefán Örvar Sigmundsson</author>
// <copyright company="eMedia Intellect" file="FileNameTextBox_TextChanged.cs">
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
	using System.Windows.Controls;
	using System.Windows.Media;

	/// <content>Contains the <see cref="FileNameTextBox_TextChanged"/> method.</content>
	public partial class FileSystemBrowserWindow
	{
		/// <summary>Validates the name of the file to be saved and enables the <see cref="actionButton"/> control.</summary>
		/// <param name="sender">The sender object of the event handler.</param>
		/// <param name="e">The state information of the event handler.</param>
		private void FileNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (string.IsNullOrEmpty(this.fileNameTextBox.Text))
			{
				this.actionButton.IsEnabled = false;
			}
			else
			{
				this.actionButton.IsEnabled = true;

				this.fileNameTextBox.Background = Brushes.White;
			}

			if (this.fileNameTextBox.Text.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
			{
				this.actionButton.IsEnabled = false;

				this.fileNameTextBox.Background = new SolidColorBrush(Color.FromArgb(255, (byte)255, (byte)153, (byte)153));
			}
		}
	}
}