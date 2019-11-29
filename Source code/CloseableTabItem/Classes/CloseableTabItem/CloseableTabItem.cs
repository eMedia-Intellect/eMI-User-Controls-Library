// <author>Stefán Örvar Sigmundsson</author>
// <copyright company="eMedia Intellect" file="CloseableTabItem.cs">
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
	using System.Windows.Input;

	/// <summary>Provides a closeable tab item for the <see cref="System.Windows.Controls.TabControl"/> class.</summary>
	public partial class CloseableTabItem : TabItem
	{
		/// <summary>Indicates whether the tab item is closeable.</summary>
		/// <remarks>The store for the <see cref="IsCloseable"/> property.</remarks>
		private bool isCloseable = true;

		/// <summary>The closeable header of the tab item.</summary>
		private CloseableHeader closeableHeader = new CloseableHeader();

		/// <summary>The title to display in the header of the tab item.</summary>
		/// <remarks>The store for the <see cref="Title"/> property.</remarks>
		private string title = null;

		/// <summary>Initialises a new instance of the <see cref="CloseableTabItem"/> class.</summary>
		public CloseableTabItem()
		{
			this.closeableHeader.titleLabel.Content = this.title;

			if (!this.IsSelected)
			{
				this.closeableHeader.closeButton.Visibility = Visibility.Hidden;
			}

			if (this.isCloseable)
			{
				this.Header = this.closeableHeader;
			}
			else
			{
				this.Header = this.title;
			}

			this.closeableHeader.closeButton.Click += new RoutedEventHandler(this.CloseButton_Click);
			this.closeableHeader.closeButton.MouseEnter += new MouseEventHandler(this.CloseButton_MouseEnter);
			this.closeableHeader.closeButton.MouseLeave += new MouseEventHandler(this.CloseButton_MouseLeave);
			this.closeableHeader.titleLabel.SizeChanged += new SizeChangedEventHandler(this.TitleLabel_SizeChanged);
		}
	}
}