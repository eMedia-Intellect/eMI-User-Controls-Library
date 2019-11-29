// <author>Stefán Örvar Sigmundsson</author>
// <copyright company="eMedia Intellect" file="InitialiseColumnHeaderGrid.cs">
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
	using System.Windows.Controls;
	using System.Windows.Media;

	/// <content>Contains the <see cref="InitialiseColumnHeaderGrid"/> method.</content>
	public partial class FileSystemBrowserWindow
	{
		/// <summary>Initialises a column header gird with its respective button and name.</summary>
		/// <param name="columnHeaderGrid">The column header grid to initialise.</param>
		/// <param name="columnHeaderButton">The column header button to add to the column header grid.</param>
		/// <param name="columnName">The name of the column.</param>
		private void InitialiseColumnHeaderGrid(Grid columnHeaderGrid, Button columnHeaderButton, Enum columnName)
		{
			ColumnDefinition buttonColumnDefinition = new ColumnDefinition();
			ColumnDefinition imageColumnDefinition = new ColumnDefinition();

			columnHeaderGrid.ColumnDefinitions.Add(buttonColumnDefinition);

			buttonColumnDefinition.Width = new GridLength(1, GridUnitType.Star);

			columnHeaderGrid.ColumnDefinitions.Add(imageColumnDefinition);

			imageColumnDefinition.Width = GridLength.Auto;

			RowDefinition columnHeaderRowDefinition = new RowDefinition();

			columnHeaderGrid.RowDefinitions.Add(columnHeaderRowDefinition);

			columnHeaderButton.Background = Brushes.Transparent;
			columnHeaderButton.BorderBrush = Brushes.Transparent;
			columnHeaderButton.BorderThickness = new Thickness(0);
			columnHeaderButton.CommandParameter = columnName;
			columnHeaderButton.MinWidth = 100;
			columnHeaderButton.PreviewMouseUp += this.ColumnHeaderDescending_PreviewMouseUp;

			Grid.SetColumn(columnHeaderButton, 0);
			Grid.SetColumn(this.arrowDescendingImage, 1);
			Grid.SetColumn(this.arrowAscendingImage, 1);

			columnHeaderGrid.Children.Add(columnHeaderButton);
		}
	}
}