// <author>Stefán Örvar Sigmundsson</author>
// <copyright company="eMedia Intellect" file="RemoveGridImageChildren.cs">
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

	/// <content>Contains the <see cref="RemoveGridImageChildren"/> method.</content>
	public partial class FileSystemBrowserWindow
	{
		/// <summary>Removes all arrow images from column header girds.</summary>
		/// <remarks>The removal of arrow images from all column header grids ensures that only a single column header grid contains such an image at any given time.</remarks>
		private void RemoveGridImageChildren()
		{
			if (this.availableFreeSpaceGrid.Children.Contains(this.arrowAscendingImage))
			{
				this.availableFreeSpaceGrid.Children.Remove(this.arrowAscendingImage);
			}
			else if (this.availableFreeSpaceGrid.Children.Contains(this.arrowDescendingImage))
			{
				this.availableFreeSpaceGrid.Children.Remove(this.arrowDescendingImage);
			}

			if (this.creationTimeGrid.Children.Contains(this.arrowAscendingImage))
			{
				this.creationTimeGrid.Children.Remove(this.arrowAscendingImage);
			}
			else if (this.creationTimeGrid.Children.Contains(this.arrowDescendingImage))
			{
				this.creationTimeGrid.Children.Remove(this.arrowDescendingImage);
			}

			if (this.driveFormatGrid.Children.Contains(this.arrowAscendingImage))
			{
				this.driveFormatGrid.Children.Remove(this.arrowAscendingImage);
			}
			else if (this.driveFormatGrid.Children.Contains(this.arrowDescendingImage))
			{
				this.driveFormatGrid.Children.Remove(this.arrowDescendingImage);
			}

			if (this.driveTypeGrid.Children.Contains(this.arrowAscendingImage))
			{
				this.driveTypeGrid.Children.Remove(this.arrowAscendingImage);
			}
			else if (this.driveTypeGrid.Children.Contains(this.arrowDescendingImage))
			{
				this.driveTypeGrid.Children.Remove(this.arrowDescendingImage);
			}

			if (this.lastAccessTimeGrid.Children.Contains(this.arrowAscendingImage))
			{
				this.lastAccessTimeGrid.Children.Remove(this.arrowAscendingImage);
			}
			else if (this.lastAccessTimeGrid.Children.Contains(this.arrowDescendingImage))
			{
				this.lastAccessTimeGrid.Children.Remove(this.arrowDescendingImage);
			}

			if (this.lastWriteTimeGrid.Children.Contains(this.arrowAscendingImage))
			{
				this.lastWriteTimeGrid.Children.Remove(this.arrowAscendingImage);
			}
			else if (this.lastWriteTimeGrid.Children.Contains(this.arrowDescendingImage))
			{
				this.lastWriteTimeGrid.Children.Remove(this.arrowDescendingImage);
			}

			if (this.nameGrid.Children.Contains(this.arrowAscendingImage))
			{
				this.nameGrid.Children.Remove(this.arrowAscendingImage);
			}
			else if (this.nameGrid.Children.Contains(this.arrowDescendingImage))
			{
				this.nameGrid.Children.Remove(this.arrowDescendingImage);
			}

			if (this.rootDirectoryGrid.Children.Contains(this.arrowAscendingImage))
			{
				this.rootDirectoryGrid.Children.Remove(this.arrowAscendingImage);
			}
			else if (this.rootDirectoryGrid.Children.Contains(this.arrowDescendingImage))
			{
				this.rootDirectoryGrid.Children.Remove(this.arrowDescendingImage);
			}

			if (this.sizeGrid.Children.Contains(this.arrowAscendingImage))
			{
				this.sizeGrid.Children.Remove(this.arrowAscendingImage);
			}
			else if (this.sizeGrid.Children.Contains(this.arrowDescendingImage))
			{
				this.sizeGrid.Children.Remove(this.arrowDescendingImage);
			}

			if (this.totalFreeSpaceGrid.Children.Contains(this.arrowAscendingImage))
			{
				this.totalFreeSpaceGrid.Children.Remove(this.arrowAscendingImage);
			}
			else if (this.totalFreeSpaceGrid.Children.Contains(this.arrowDescendingImage))
			{
				this.totalFreeSpaceGrid.Children.Remove(this.arrowDescendingImage);
			}

			if (this.totalSizeGrid.Children.Contains(this.arrowAscendingImage))
			{
				this.totalSizeGrid.Children.Remove(this.arrowAscendingImage);
			}
			else if (this.totalSizeGrid.Children.Contains(this.arrowDescendingImage))
			{
				this.totalSizeGrid.Children.Remove(this.arrowDescendingImage);
			}

			if (this.volumeGrid.Children.Contains(this.arrowAscendingImage))
			{
				this.volumeGrid.Children.Remove(this.arrowAscendingImage);
			}
			else if (this.volumeGrid.Children.Contains(this.arrowDescendingImage))
			{
				this.volumeGrid.Children.Remove(this.arrowDescendingImage);
			}
		}
	}
}