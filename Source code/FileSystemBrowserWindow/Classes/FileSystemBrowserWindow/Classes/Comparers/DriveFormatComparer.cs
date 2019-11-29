﻿// <author>Stefán Örvar Sigmundsson</author>
// <copyright company="eMedia Intellect" file="DriveFormatComparer.cs">
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
	using System.Collections.Generic;
	using System.ComponentModel;

	/// <content>Contains the <see cref="DriveFormatComparer"/> class.</content>
	public partial class FileSystemBrowserWindow
	{
		/// <summary>Provides a drive format comparer for the <see cref="FileSystemItemSorter"/> class.</summary>
		internal class DriveFormatComparer : IComparer<FileSystemItem>
		{
			/// <summary>The direction by which to sort.</summary>
			private ListSortDirection listSortDirection;

			/// <summary>Initialises a new instance of the <see cref="DriveFormatComparer"/> class.</summary>
			/// <param name="listSortDirection">The direction by which to sort.</param>
			internal DriveFormatComparer(ListSortDirection listSortDirection)
			{
				this.listSortDirection = listSortDirection;
			}

			/// <summary>Compares two instances of the <see cref="FileSystemItem"/> class.</summary>
			/// <param name="x">The first instance to compare.</param>
			/// <param name="y">The second instance to compare.</param>
			/// <returns>An integer that indicates the position in the sorting order.</returns>
			public int Compare(FileSystemItem x, FileSystemItem y)
			{
				if (x == null)
				{
					throw new ArgumentNullException("x");
				}

				if (y == null)
				{
					throw new ArgumentNullException("y");
				}

				switch (this.listSortDirection)
				{
					case ListSortDirection.Ascending:
						return string.Compare(x.DriveFormat, y.DriveFormat, StringComparison.CurrentCulture);

					case ListSortDirection.Descending:
						return string.Compare(y.DriveFormat, x.DriveFormat, StringComparison.CurrentCulture);
				}

				return 0;
			}
		}
	}
}