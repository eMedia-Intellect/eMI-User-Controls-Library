// <author>Stefán Örvar Sigmundsson</author>
// <copyright company="eMedia Intellect" file="PathButton.cs">
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
	using System.Windows.Controls;

	/// <content>Contains the <see cref="PathButton"/> class.</content>
	public partial class FileSystemBrowserWindow
	{
		/// <summary>Provides path buttons for the <see cref="pathStackPanel"/> field.</summary>
		internal class PathButton : Button
		{
			/// <summary>The path to navigate to in the file system.</summary>
			private string path = string.Empty;

			/// <summary>Initialises a new instance of the <see cref="PathButton"/> class with the specified button text, file system item path and routed click event handler.</summary>
			/// <param name="text">The text of the <see cref="PathButton"/> class.</param>
			/// <param name="path">The path to which to navigate.</param>
			/// <param name="clickRoutedEventHandler">The event handler for the Click event of the Button class.</param>
			internal PathButton(string text, string path, RoutedEventHandler clickRoutedEventHandler)
			{
				this.Click += clickRoutedEventHandler;
				this.Content = text;

				this.path = path;
			}

			/// <summary>Gets a value indicating to which directory to navigate.</summary>
			/// <value>Represents the <see cref="path"/> field.</value>
			internal string Path
			{
				get
				{
					return this.path;
				}
			}
		}
	}
}