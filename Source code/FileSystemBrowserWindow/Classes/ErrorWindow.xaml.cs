// <author>Stefán Örvar Sigmundsson</author>
// <copyright company="eMedia Intellect" file="ErrorWindow.xaml.cs">
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
	using System.Windows;

	/// <summary>Provides an error window for the <see cref="FileSystemBrowserWindow"/> class.</summary>
	internal partial class ErrorWindow : Window
	{
		/// <summary>Initialises a new instance of the <see cref="ErrorWindow"/> class with the specified owner window, file system path and message.</summary>
		/// <param name="ownerWindow">The owner of the window.</param>
		/// <param name="path">The path causing the error.</param>
		/// <param name="message">The error message.</param>
		internal ErrorWindow(Window ownerWindow, string path, string message)
		{
			this.InitializeComponent();

			this.messageTextBlock.Text = path + Environment.NewLine + Environment.NewLine + message;

			try
			{
				this.Owner = ownerWindow;
			}
			catch (InvalidOperationException)
			{
			}
		}

		/// <summary>Closes the window when the button is clicked.</summary>
		/// <param name="sender">The sender object of the event handler.</param>
		/// <param name="e">The state information of the event handler.</param>
		private void OkButton_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
	}
}