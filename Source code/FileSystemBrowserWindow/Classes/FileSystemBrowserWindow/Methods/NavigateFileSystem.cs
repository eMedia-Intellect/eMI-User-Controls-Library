// <author>Stefán Örvar Sigmundsson</author>
// <copyright company="eMedia Intellect" file="NavigateFileSystem.cs">
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
	/// <content>Contains the <see cref="NavigateFileSystem"/> method.</content>
	public partial class FileSystemBrowserWindow
	{
		/// <summary>Navigates to the specified file system path.</summary>
		/// <param name="newPath">The file system path to which to navigate.</param>
		internal void NavigateFileSystem(string newPath)
		{
			this.path = newPath;

			this.fileSystemItemSorter.Clear();

			this.GeneratePathButtons();
			this.GenerateFileSystemItems();
			this.AdjustFileSystemListView();

			if (this.isInitialNavigation)
			{
				this.isInitialNavigation = false;
			}
		}
	}
}