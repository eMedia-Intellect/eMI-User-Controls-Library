// <author>Stefán Örvar Sigmundsson</author>
// <copyright company="eMedia Intellect" file="FileTypeComboBoxItem.cs">
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
	/// <summary>Provides a file type combo box item for the <see cref="BrowserSettings.DefaultFileType"/> and <see cref="BrowserSettings.SupportedFileTypes"/> properties.</summary>
	/// <remarks>The key should be a file name extension and the value a description.</remarks>
	public class FileTypeComboBoxItem
	{
		/// <summary>Initialises a new instance of the <see cref="FileTypeComboBoxItem"/> class.</summary>
		/// <param name="key">The file name extension of the file type.</param>
		/// <param name="value">The description of the file type.</param>
		public FileTypeComboBoxItem(string key, string value)
		{
			this.Key = key;
			this.Value = value;
		}

		/// <summary>Gets a value indicating the file name extension of the file type.</summary>
		/// <value>Represents the key.</value>
		public string Key { get; } = string.Empty;

		/// <summary>Gets a value indicating the description of the file type.</summary>
		/// <value>Represents the value.</value>
		public string Value { get; } = string.Empty;
	}
}