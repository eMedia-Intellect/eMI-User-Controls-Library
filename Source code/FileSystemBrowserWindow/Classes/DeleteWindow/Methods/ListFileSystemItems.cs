// <author>Stefán Örvar Sigmundsson</author>
// <copyright company="eMedia Intellect" file="ListFileSystemItems.cs">
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
	using System.Windows.Media.Imaging;

	/// <content>Contains the <see cref="ListFileSystemItems"/> method.</content>
	internal partial class DeleteWindow
	{
		/// <summary>Lists all items in the <see cref="directoryList"/> and <see cref="fileList"/> fields of the <see cref="deleteStackPanel"/> instance.</summary>
		private void ListFileSystemItems()
		{
			foreach (FileSystemItemDeletion currentFileSystemItemDeletion in this.directoryList)
			{
				StackPanel currentStackPanel = new StackPanel();

				currentStackPanel.Orientation = Orientation.Horizontal;

				BitmapImage currentBitmapImage = new BitmapImage();

				currentBitmapImage.BeginInit();

				currentBitmapImage.UriSource = new Uri(@"..\Images\Directory.png", UriKind.Relative);

				currentBitmapImage.EndInit();

				Image currentImage = new Image();

				currentImage.Source = currentBitmapImage;

				Label currentFileSystemItemLabel = new Label();

				currentFileSystemItemLabel.Padding = new Thickness(5, 2, 0, 2);

				currentFileSystemItemLabel.Content = currentFileSystemItemDeletion.Name;

				Label currentStatusLabel = new Label();

				switch (currentFileSystemItemDeletion.DeletionStatus)
				{
					case DeletionStatus.Pending:
						currentStatusLabel.Content = UserControls.Resources.DeleteWindow.DeletionStatusPending;

						currentStatusLabel.Foreground = Brushes.Blue;

						break;
					case DeletionStatus.Deleted:
						currentStatusLabel.Content = UserControls.Resources.DeleteWindow.DeletionStatusDeleted;

						currentStatusLabel.Foreground = Brushes.Green;

						break;
					case DeletionStatus.Error:
						currentStatusLabel.Content = UserControls.Resources.DeleteWindow.DeletionStatusError;

						currentStatusLabel.Foreground = Brushes.Red;

						break;
				}

				currentStatusLabel.FontSize = 10;

				currentStatusLabel.Padding = new Thickness(5, 2, 0, 2);

				currentStatusLabel.VerticalAlignment = VerticalAlignment.Bottom;

				currentStackPanel.Children.Add(currentImage);
				currentStackPanel.Children.Add(currentFileSystemItemLabel);
				currentStackPanel.Children.Add(currentStatusLabel);

				this.deleteStackPanel.Children.Add(currentStackPanel);
			}

			foreach (FileSystemItemDeletion currentFileSystemItemDeletion in this.fileList)
			{
				StackPanel currentStackPanel = new StackPanel();

				currentStackPanel.Orientation = Orientation.Horizontal;

				BitmapImage currentBitmapImage = new BitmapImage();

				currentBitmapImage.BeginInit();

				currentBitmapImage.UriSource = new Uri(@"..\Images\File.png", UriKind.Relative);

				currentBitmapImage.EndInit();

				Image currentImage = new Image();

				currentImage.Source = currentBitmapImage;

				Label currentFileSystemItemLabel = new Label();

				currentFileSystemItemLabel.Padding = new Thickness(5, 2, 0, 2);

				currentFileSystemItemLabel.Content = currentFileSystemItemDeletion.Name;

				Label currentStatusLabel = new Label();

				switch (currentFileSystemItemDeletion.DeletionStatus)
				{
					case DeletionStatus.Pending:
						currentStatusLabel.Content = UserControls.Resources.DeleteWindow.DeletionStatusPending;

						currentStatusLabel.Foreground = Brushes.Blue;

						break;
					case DeletionStatus.Deleted:
						currentStatusLabel.Content = UserControls.Resources.DeleteWindow.DeletionStatusDeleted;

						currentStatusLabel.Foreground = Brushes.Green;

						break;
					case DeletionStatus.Error:
						currentStatusLabel.Content = UserControls.Resources.DeleteWindow.DeletionStatusError;

						currentStatusLabel.Foreground = Brushes.Red;

						break;
				}

				currentStatusLabel.FontSize = 10;

				currentStatusLabel.Padding = new Thickness(5, 2, 0, 2);

				currentStatusLabel.VerticalAlignment = VerticalAlignment.Bottom;

				currentStackPanel.Children.Add(currentImage);
				currentStackPanel.Children.Add(currentFileSystemItemLabel);
				currentStackPanel.Children.Add(currentStatusLabel);

				this.deleteStackPanel.Children.Add(currentStackPanel);
			}
		}
	}
}