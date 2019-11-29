// <author>Stefán Örvar Sigmundsson</author>
// <copyright company="eMedia Intellect" file="PathButton_Click.cs">
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
	using System.Windows;

	/// <content>Contains the <see cref="PathButton_Click"/> method.</content>
	public partial class FileSystemBrowserWindow
	{
		/// <summary>Browses to the relevant directory when the button is clicked.</summary>
		/// <param name="sender">The sender object of the event handler.</param>
		/// <param name="e">The state information of the event handler.</param>
		private void PathButton_Click(object sender, RoutedEventArgs e)
		{
			PathButton senderPathButton = (PathButton)sender;

			this.NavigateFileSystem(senderPathButton.Path);

			this.RemoveGridImageChildren();

			this.fileSystemItemSorter.SortName();

			this.nameButton.PreviewMouseUp -= this.ColumnHeaderAscending_PreviewMouseUp;
			this.nameButton.PreviewMouseUp += this.ColumnHeaderDescending_PreviewMouseUp;

			this.nameGrid.Children.Add(this.arrowAscendingImage);
		}
	}
}