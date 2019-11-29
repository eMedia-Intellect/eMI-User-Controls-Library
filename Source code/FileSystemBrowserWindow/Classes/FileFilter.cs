// <author>Stefán Örvar Sigmundsson</author>
// <copyright company="eMedia Intellect" file="FileFilter.cs">
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
	using System.IO;

	/// <summary>Provides a file filter for the <see cref="FileSystemBrowserWindow"/> class.</summary>
	public class FileFilter
	{
		/// <summary>The filtering mode of the browser filter.</summary>
		private FilteringMode filteringMode = FilteringMode.IncludeAll;

		/// <summary>The list of file name extensions to filter in or out.</summary>
		private List<string> extensionList = new List<string>();

		/// <summary>Initialises a new instance of the <see cref="FileFilter"/> class.</summary>
		public FileFilter()
		{
			this.filteringMode = FilteringMode.IncludeAll;

			this.extensionList.Add(string.Empty);
			this.extensionList.Add(".ini");
			this.extensionList.Add(".lnk");
			this.extensionList.Add(".sys");
		}

		/// <summary>Initialises a new instance of the <see cref="FileFilter"/> class with the specified <see cref="FilteringMode"/>.</summary>
		/// <param name="filteringMode">The filtering mode for the <see cref="filteringMode"/> field.</param>
		public FileFilter(FilteringMode filteringMode)
		{
			this.filteringMode = filteringMode;
		}

		/// <summary>Adds file name extension to filter in or out.</summary>
		/// <param name="extension">The file name extension to add to the <see cref="extensionList"/> field.</param>
		public void AddExtension(string extension)
		{
			this.extensionList.Add(extension);
		}

		/// <summary>Processes a file by filtering it in or out.</summary>
		/// <param name="fileSystemInfo">The file to process.</param>
		/// <returns>An indication of whether the file should be filtered in or out.</returns>
		internal bool Process(FileSystemInfo fileSystemInfo)
		{
			if (fileSystemInfo == null)
			{
				throw new ArgumentNullException("fileSystemInfo");
			}

			switch (this.filteringMode)
			{
				case FilteringMode.ExcludeAll:
					if (this.extensionList.Contains(fileSystemInfo.Extension))
					{
						return true;
					}
					else
					{
						return false;
					}

				case FilteringMode.IncludeAll:
					if (this.extensionList.Contains(fileSystemInfo.Extension))
					{
						return false;
					}
					else
					{
						return true;
					}
			}

			throw new InvalidEnumArgumentException(this.filteringMode.ToString());
		}
	}
}