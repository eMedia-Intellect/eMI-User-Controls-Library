// <author>Stefán Örvar Sigmundsson</author>
// <copyright company="eMedia Intellect" file="FileSystemBrowserWindow_Loaded.cs">
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

	/// <content>Contains the <see cref="FileSystemBrowserWindow_Loaded"/> method.</content>
	public partial class FileSystemBrowserWindow
	{
		/// <summary>Ensures that the "Name" column of the <see cref="fileSystemListView"/> field is always sorted by ascendingly when the <see cref="FileSystemBrowserWindow"/> is loaded.</summary>
		/// <param name="sender">The sender object of the event handler.</param>
		/// <param name="e">The state information of the event handler.</param>
		private void FileSystemBrowserWindow_Loaded(object sender, RoutedEventArgs e)
		{
			this.fileSystemItemSorter.SortName();

			this.nameGrid.Children.Add(this.arrowAscendingImage);
		}
	}
}