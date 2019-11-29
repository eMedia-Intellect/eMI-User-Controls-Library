// <author>Stefán Örvar Sigmundsson</author>
// <copyright company="eMedia Intellect" file="MainWindow.xaml.cs">
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
	using System.Globalization;
	using System.Text;
	using System.Threading;
	using System.Windows;
	using System.Windows.Media.Imaging;

	/// <summary>Represents the main window of the application.</summary>
	public partial class MainWindow : Window
	{
		/// <summary>Initialises a new instance of the <see cref="MainWindow"/> class.</summary>
		public MainWindow()
		{
			this.InitializeComponent();

			foreach (string browsingMode in Enum.GetNames(typeof(BrowsingMode)))
			{
				this.browsingModeComboBox.Items.Add(browsingMode);

				this.browsingModeComboBox.SelectedIndex = 0;
			}

			foreach (string byteMultiple in Enum.GetNames(typeof(ByteMultiple)))
			{
				this.byteMultipleComboBox.Items.Add(byteMultiple);

				this.byteMultipleComboBox.SelectedIndex = 0;
			}

			foreach (string filteringMode in Enum.GetNames(typeof(FilteringMode)))
			{
				this.filteringModeComboBox.Items.Add(filteringMode);

				this.filteringModeComboBox.SelectedIndex = 0;
			}

			this.ResetButton_Click(null, null);
		}

		/// <summary>Resets all controls to their default state when the button is clicked.</summary>
		/// <param name="sender">The sender object of the event handler.</param>
		/// <param name="e">The state information of the event handler.</param>
		private void ResetButton_Click(object sender, RoutedEventArgs e)
		{
			this.pathTextBox.Text = string.Empty;
			this.browsingModeComboBox.SelectedIndex = 0;
			this.byteMultipleComboBox.SelectedIndex = 0;
			this.iconTextBox.Text = string.Empty;
			this.hasAvailableFreeSpaceCheckBox.IsChecked = false;
			this.hasDriveFormatCheckBox.IsChecked = true;
			this.hasDriveTypeCheckBox.IsChecked = true;
			this.hasRootDirectoryCheckBox.IsChecked = false;
			this.hasTotalFreeSpaceCheckBox.IsChecked = true;
			this.hasTotalSizeCheckBox.IsChecked = true;
			this.hasVolumeLabelCheckBox.IsChecked = false;

			this.minimumFilesTextBox.Text = "1";
			this.maximumFilesTextBox.Text = "1";
			this.minimumDirectoriesTextBox.Text = "0";
			this.maximumDirectoriesTextBox.Text = "0";

			this.canSelectEncodingCheckBox.IsChecked = false;
			this.defaultEncodingComboBox.SelectedIndex = 0;
			this.defaultFileNameTextBox.Text = "new file";

			this.key1TextBox.Text = string.Empty;
			this.value1TextBox.Text = "None (*)";
			this.key2TextBox.Text = ".txt";
			this.value2TextBox.Text = "Text file (*.txt)";

			this.filteringModeComboBox.SelectedIndex = 0;
			this.extensionsTextBox.Text = ";.ini;.lnk;.sys";

			this.openOrSelectListView.Items.Clear();

			this.currentPathTextBox.Text = string.Empty;

			this.savingFileEncodingTextBox.Text = string.Empty;
			this.savingFilePathTextBox.Text = string.Empty;
			this.savingFileTypeTextBox.Text = string.Empty;
		}

		/// <summary>Shows a modal <see cref="FileSystemBrowserWindow"/> when the button is clicked.</summary>
		/// <param name="sender">The sender object of the event handler.</param>
		/// <param name="e">The state information of the event handler.</param>
		private void ShowDialogButton_Click(object sender, RoutedEventArgs e)
		{
			/*
			 * BrowserSettings
			 */

			BrowserSettings browserSettings = new BrowserSettings();

			/*
			 * BrowserSettings | Common
			 */

			browserSettings.BrowsingMode = (BrowsingMode)Enum.Parse(typeof(BrowsingMode), this.browsingModeComboBox.SelectedValue.ToString());
			browserSettings.ByteMultiple = (ByteMultiple)Enum.Parse(typeof(ByteMultiple), this.byteMultipleComboBox.SelectedValue.ToString());
			browserSettings.HasAvailableFreeSpace = (bool)this.hasAvailableFreeSpaceCheckBox.IsChecked;
			browserSettings.HasDriveFormat = (bool)this.hasDriveFormatCheckBox.IsChecked;
			browserSettings.HasDriveType = (bool)this.hasDriveTypeCheckBox.IsChecked;
			browserSettings.HasRootDirectory = (bool)this.hasRootDirectoryCheckBox.IsChecked;
			browserSettings.HasTotalFreeSpace = (bool)this.hasTotalFreeSpaceCheckBox.IsChecked;
			browserSettings.HasTotalSize = (bool)this.hasTotalSizeCheckBox.IsChecked;
			browserSettings.HasVolumeLabel = (bool)this.hasVolumeLabelCheckBox.IsChecked;

			if (!string.IsNullOrEmpty(this.iconTextBox.Text))
			{
				browserSettings.Icon = BitmapFrame.Create(new Uri(this.iconTextBox.Text));
			}

			browserSettings.Path = this.pathTextBox.Text;

			/*
			 * BrowserSettings | Directory/File Selection
			 */

			CultureInfo currentCultureInfo = Thread.CurrentThread.CurrentCulture;

			browserSettings.MaximumFiles = int.Parse(this.maximumFilesTextBox.Text, currentCultureInfo);
			browserSettings.MaximumDirectories = int.Parse(this.maximumDirectoriesTextBox.Text, currentCultureInfo);
			browserSettings.MinimumFiles = int.Parse(this.minimumFilesTextBox.Text, currentCultureInfo);
			browserSettings.MinimumDirectories = int.Parse(this.minimumDirectoriesTextBox.Text, currentCultureInfo);

			/*
			 * BrowserSettings | File Saving
			 */

			browserSettings.CanSelectEncoding = (bool)this.canSelectEncodingCheckBox.IsChecked;

			switch (this.defaultEncodingComboBox.Text)
			{
				case "UTF-8":
					browserSettings.DefaultEncoding = new UTF8Encoding(false);

					break;
				case "UTF-8 (BOM)":
					browserSettings.DefaultEncoding = new UTF8Encoding(true);

					break;
				case "UTF-16 (BOM, BE)":
					browserSettings.DefaultEncoding = new UnicodeEncoding(true, true);

					break;
				case "UTF-16 (BOM, LE)":
					browserSettings.DefaultEncoding = new UnicodeEncoding(false, true);

					break;
				case "UTF-32 (BOM, BE)":
					browserSettings.DefaultEncoding = new UTF32Encoding(true, true);

					break;
				case "UTF-32 (BOM, LE)":
					browserSettings.DefaultEncoding = new UTF32Encoding(false, true);

					break;
			}

			browserSettings.DefaultFileName = this.defaultFileNameTextBox.Text;

			/*
			 * BrowserSettings | File Saving | SupportedFileTypes
			 */

			browserSettings.SupportedFileTypes.Clear();

			if (!string.IsNullOrEmpty(this.value1TextBox.Text))
			{
				browserSettings.SupportedFileTypes.Add(new FileTypeComboBoxItem(this.key1TextBox.Text, this.value1TextBox.Text));
			}

			if (!string.IsNullOrEmpty(this.value2TextBox.Text))
			{
				browserSettings.SupportedFileTypes.Add(new FileTypeComboBoxItem(this.key2TextBox.Text, this.value2TextBox.Text));
			}

			if (!string.IsNullOrEmpty(this.value3TextBox.Text))
			{
				browserSettings.SupportedFileTypes.Add(new FileTypeComboBoxItem(this.key3TextBox.Text, this.value3TextBox.Text));
			}

			if (!string.IsNullOrEmpty(this.value4TextBox.Text))
			{
				browserSettings.SupportedFileTypes.Add(new FileTypeComboBoxItem(this.key4TextBox.Text, this.value4TextBox.Text));
			}

			if (!string.IsNullOrEmpty(this.value5TextBox.Text))
			{
				browserSettings.SupportedFileTypes.Add(new FileTypeComboBoxItem(this.key5TextBox.Text, this.value5TextBox.Text));
			}

			/*
			 * FileFilter
			 */

			FilteringMode filteringMode = (FilteringMode)Enum.Parse(typeof(FilteringMode), this.filteringModeComboBox.SelectedValue.ToString());

			FileFilter fileFilter = new FileFilter(filteringMode);

			foreach (string extension in this.extensionsTextBox.Text.Split(';'))
			{
				fileFilter.AddExtension(extension);
			}

			browserSettings.FileFilter = fileFilter;

			/*
			 * FileSystemBrowserWindow
			 */

			FileSystemBrowserWindow fileSystemBrowserWindow = new FileSystemBrowserWindow(browserSettings);

			fileSystemBrowserWindow.Owner = this;

			if (fileSystemBrowserWindow.ShowDialog() == true)
			{
				this.currentPathTextBox.Text = fileSystemBrowserWindow.CurrentPath;

				if (browserSettings.BrowsingMode != BrowsingMode.Save)
				{
					foreach (string directory in fileSystemBrowserWindow.SelectedDirectories)
					{
						this.openOrSelectListView.Items.Add(new { Type = "Directory", Path = directory });
					}

					foreach (string file in fileSystemBrowserWindow.SelectedFiles)
					{
						this.openOrSelectListView.Items.Add(new { Type = "File", Path = file });
					}
				}
				else
				{
				string preamble = string.Empty;

				switch (fileSystemBrowserWindow.SelectedSavingFileEncoding.GetPreamble().Length)
				{
					case 2:
						if (fileSystemBrowserWindow.SelectedSavingFileEncoding.GetPreamble()[0] == 254 && fileSystemBrowserWindow.SelectedSavingFileEncoding.GetPreamble()[1] == 255)
						{
							preamble = "BE";
						}
						else if (fileSystemBrowserWindow.SelectedSavingFileEncoding.GetPreamble()[0] == 255 && fileSystemBrowserWindow.SelectedSavingFileEncoding.GetPreamble()[1] == 254)
						{
							preamble = "LE";
						}

						break;
					case 3:
						if (fileSystemBrowserWindow.SelectedSavingFileEncoding.GetPreamble()[0] == 239 && fileSystemBrowserWindow.SelectedSavingFileEncoding.GetPreamble()[1] == 187 && fileSystemBrowserWindow.SelectedSavingFileEncoding.GetPreamble()[2] == 191)
						{
							preamble = "BOM";
						}

						break;
					case 4:
						if (fileSystemBrowserWindow.SelectedSavingFileEncoding.GetPreamble()[0] == 0 && fileSystemBrowserWindow.SelectedSavingFileEncoding.GetPreamble()[1] == 0 && fileSystemBrowserWindow.SelectedSavingFileEncoding.GetPreamble()[2] == 254 && fileSystemBrowserWindow.SelectedSavingFileEncoding.GetPreamble()[3] == 255)
						{
							preamble = "BE";
						}
						else if (fileSystemBrowserWindow.SelectedSavingFileEncoding.GetPreamble()[0] == 255 && fileSystemBrowserWindow.SelectedSavingFileEncoding.GetPreamble()[1] == 254 && fileSystemBrowserWindow.SelectedSavingFileEncoding.GetPreamble()[2] == 0 && fileSystemBrowserWindow.SelectedSavingFileEncoding.GetPreamble()[3] == 0)
						{
							preamble = "LE";
						}

						break;
				}

					this.savingFileEncodingTextBox.Text = fileSystemBrowserWindow.SelectedSavingFileEncoding.EncodingName + " (" + preamble + ")";

					this.savingFilePathTextBox.Text = fileSystemBrowserWindow.SelectedSavingFilePath;

					this.savingFileTypeTextBox.Text = fileSystemBrowserWindow.SelectedSavingFileType.Key;
				}
			}
		}
	}
}