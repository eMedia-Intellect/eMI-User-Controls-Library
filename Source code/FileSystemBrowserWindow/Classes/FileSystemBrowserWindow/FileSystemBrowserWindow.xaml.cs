// <author>Stefán Örvar Sigmundsson</author>
// <copyright company="eMedia Intellect" file="FileSystemBrowserWindow.xaml.cs">
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
	using System.Collections.ObjectModel;
	using System.Text;
	using System.Windows;
	using System.Windows.Controls;
	using System.Windows.Media.Imaging;

	/// <summary>Provides a file system browser window.</summary>
	public partial class FileSystemBrowserWindow : Window
	{
		/// <summary>Indicates whether navigation has been performed at least once since the instantiation of the <see cref="FileSystemBrowserWindow"/> class.</summary>
		/// <remarks>Should an error occur during navigation the <see cref="ErrorWindow"/> is shown except on initial navigation.</remarks>
		private bool isInitialNavigation = true;

		/// <summary>The settings of the browser.</summary>
		private BrowserSettings browserSettings = null;

		/// <summary>The "Available free space" button in the column header.</summary>
		private Button availableFreeSpaceButton = new Button();

		/// <summary>The "Created" button in the column header.</summary>
		private Button creationTimeButton = new Button();

		/// <summary>The "Format" button in the column header.</summary>
		private Button driveFormatButton = new Button();

		/// <summary>The "Type" button in the column header.</summary>
		private Button driveTypeButton = new Button();

		/// <summary>The "Accessed" button in the column header.</summary>
		private Button lastAccessTimeButton = new Button();

		/// <summary>The "Modified" button in the column header.</summary>
		private Button lastWriteTimeButton = new Button();

		/// <summary>The "Name" button in the column header.</summary>
		private Button nameButton = new Button();

		/// <summary>The "Root directory" button in the column header.</summary>
		private Button rootDirectoryButton = new Button();

		/// <summary>The "Size" button in the column header.</summary>
		private Button sizeButton = new Button();

		/// <summary>The "Total free space" button in the column header.</summary>
		private Button totalFreeSpaceButton = new Button();

		/// <summary>The "Total size" button in the column header.</summary>
		private Button totalSizeButton = new Button();

		/// <summary>The "Volume label" button in the column header.</summary>
		private Button volumeButton = new Button();

		/// <summary>The selected directories in the browser.</summary>
		/// <remarks>The store for the <see cref="SelectedDirectories"/> property.</remarks>
		private Collection<string> selectedDirectories = new Collection<string>();

		/// <summary>The selected files in the browser.</summary>
		/// <remarks>The store for the <see cref="SelectedFiles"/> property.</remarks>
		private Collection<string> selectedFiles = new Collection<string>();

		/// <summary>The file encoding selected for the file to be saved.</summary>
		/// <remarks>The store for the <see cref="SelectedSavingFileEncoding"/> property.</remarks>
		private Encoding savingFileEncoding = null;

		/// <summary>The file type selected for the file to be saved.</summary>
		/// <remarks>The store for the <see cref="SelectedSavingFileType"/> property.</remarks>
		private FileTypeComboBoxItem savingFileType = null;

		/// <summary>The sorter of file system items of the browser.</summary>
		private FileSystemItemSorter fileSystemItemSorter = new FileSystemItemSorter();

		/// <summary>The available free space grid in the column header.</summary>
		private Grid availableFreeSpaceGrid = new Grid();

		/// <summary>The "Created" grid in the column header.</summary>
		private Grid creationTimeGrid = new Grid();

		/// <summary>The "Format" grid in the column header.</summary>
		private Grid driveFormatGrid = new Grid();

		/// <summary>The "Type" grid in the column header.</summary>
		private Grid driveTypeGrid = new Grid();

		/// <summary>The "Accessed" grid in the column header.</summary>
		private Grid lastAccessTimeGrid = new Grid();

		/// <summary>The "Modified" grid in the column header.</summary>
		private Grid lastWriteTimeGrid = new Grid();

		/// <summary>The "Name" grid in the column header.</summary>
		private Grid nameGrid = new Grid();

		/// <summary>The "Root directory" grid in the column header.</summary>
		private Grid rootDirectoryGrid = new Grid();

		/// <summary>The "Size" grid in the column header.</summary>
		private Grid sizeGrid = new Grid();

		/// <summary>The "Total free space" grid in the column header.</summary>
		private Grid totalFreeSpaceGrid = new Grid();

		/// <summary>The "Total size" grid in the column header.</summary>
		private Grid totalSizeGrid = new Grid();

		/// <summary>The "Volume label" grid in the column header.</summary>
		private Grid volumeGrid = new Grid();

		/// <summary>The "Available free space" column in the browser.</summary>
		private GridViewColumn availableFreeSpaceGridViewColumn = null;

		/// <summary>The "Created" column in the browser.</summary>
		private GridViewColumn creationTimeGridViewColumn = null;

		/// <summary>The "Format" column in the browser.</summary>
		private GridViewColumn driveFormatGridViewColumn = null;

		/// <summary>The "Type" column in the browser.</summary>
		private GridViewColumn driveTypeGridViewColumn = null;

		/// <summary>The "Accessed" column in the browser.</summary>
		private GridViewColumn lastAccessTimeGridViewColumn = null;

		/// <summary>The "Modified" column in the browser.</summary>
		private GridViewColumn lastWriteTimeGridViewColumn = null;

		/// <summary>The "Name" column in the browser.</summary>
		private GridViewColumn nameGridViewColumn = null;

		/// <summary>The "Root directory" column in the browser.</summary>
		private GridViewColumn rootDirectoryGridViewColumn = null;

		/// <summary>The "Size" column in the browser.</summary>
		private GridViewColumn sizeGridViewColumn = null;

		/// <summary>The "Total free space" column in the browser.</summary>
		private GridViewColumn totalFreeSpaceGridViewColumn = null;

		/// <summary>The "Total size" column in the browser.</summary>
		private GridViewColumn totalSizeGridViewColumn = null;

		/// <summary>The "Volume label" column in the browser.</summary>
		private GridViewColumn volumeLabelGridViewColumn = null;

		/// <summary>The arrow indicating ascending sorting in the browser.</summary>
		private Image arrowAscendingImage = new Image();

		/// <summary>The arrow indicating descending sorting in the browser.</summary>
		private Image arrowDescendingImage = new Image();

		/// <summary>The file path selected for the file to be saved.</summary>
		/// <remarks>The store for the <see cref="SelectedSavingFilePath"/> property.</remarks>
		private string savingFilePath = string.Empty;

		/// <summary>The file system path of the browser.</summary>
		/// <remarks>The store for the <see cref="CurrentPath"/> property.</remarks>
		private string path = string.Empty;

		/// <summary>Initialises a new instance of the <see cref="FileSystemBrowserWindow"/> class.</summary>
		public FileSystemBrowserWindow()
			: this(new BrowserSettings())
		{
		}

		/// <summary>Initialises a new instance of the <see cref="FileSystemBrowserWindow"/> class with the specified <see cref="BrowserSettings"/>.</summary>
		/// <param name="browserSettings">The settings for the browser.</param>
		public FileSystemBrowserWindow(BrowserSettings browserSettings)
		{
			this.browserSettings = browserSettings;

			if (browserSettings == null)
			{
				throw new ArgumentNullException("browserSettings");
			}

			if (this.browserSettings.MinimumFiles > this.browserSettings.MaximumFiles)
			{
				throw new MinimumGreaterThanMaximumException("The minimum number of files is greater than the maximum number of files.");
			}

			if (this.browserSettings.MinimumDirectories > this.browserSettings.MaximumDirectories)
			{
				throw new MinimumGreaterThanMaximumException("The minimum number of folders is greater than the maximum number of folders.");
			}

			this.Icon = this.browserSettings.Icon;

			this.InitializeComponent();

			/*
			 * Get grid view column references.
			 */

			GridView fileSystemGridView = (GridView)this.fileSystemListView.View;

			this.nameGridViewColumn = fileSystemGridView.Columns[0];
			this.sizeGridViewColumn = fileSystemGridView.Columns[1];
			this.lastAccessTimeGridViewColumn = fileSystemGridView.Columns[2];
			this.lastWriteTimeGridViewColumn = fileSystemGridView.Columns[3];
			this.creationTimeGridViewColumn = fileSystemGridView.Columns[4];
			this.volumeLabelGridViewColumn = fileSystemGridView.Columns[5];
			this.rootDirectoryGridViewColumn = fileSystemGridView.Columns[6];
			this.driveTypeGridViewColumn = fileSystemGridView.Columns[7];
			this.driveFormatGridViewColumn = fileSystemGridView.Columns[8];
			this.availableFreeSpaceGridViewColumn = fileSystemGridView.Columns[9];
			this.totalFreeSpaceGridViewColumn = fileSystemGridView.Columns[10];
			this.totalSizeGridViewColumn = fileSystemGridView.Columns[11];

			/*
			 * Set window title.
			 */

			switch (this.browserSettings.BrowsingMode)
			{
				case BrowsingMode.Open:
					if (this.browserSettings.MaximumFiles == 1 && this.browserSettings.MaximumDirectories == 0)
					{
						this.Title = UserControls.Resources.FileSystemBrowserWindow.WindowTitles.OpenFile;
					}
					else if (this.browserSettings.MaximumFiles > 1 && this.browserSettings.MaximumDirectories == 0)
					{
						this.Title = UserControls.Resources.FileSystemBrowserWindow.WindowTitles.OpenFiles;
					}
					else if (this.browserSettings.MaximumFiles == 0 && this.browserSettings.MaximumDirectories == 1)
					{
						this.Title = UserControls.Resources.FileSystemBrowserWindow.WindowTitles.OpenFolder;
					}
					else if (this.browserSettings.MinimumFiles == 0 && this.browserSettings.MaximumDirectories > 1)
					{
						this.Title = UserControls.Resources.FileSystemBrowserWindow.WindowTitles.OpenFolders;
					}
					else if (this.browserSettings.MaximumFiles == 1 && this.browserSettings.MaximumDirectories == 1)
					{
						this.Title = UserControls.Resources.FileSystemBrowserWindow.WindowTitles.OpenFolderAndFile;
					}
					else if (this.browserSettings.MaximumFiles > 1 && this.browserSettings.MaximumDirectories == 1)
					{
						this.Title = UserControls.Resources.FileSystemBrowserWindow.WindowTitles.OpenFolderAndFiles;
					}
					else if (this.browserSettings.MaximumFiles == 1 && this.browserSettings.MaximumDirectories > 1)
					{
						this.Title = UserControls.Resources.FileSystemBrowserWindow.WindowTitles.OpenFoldersAndFile;
					}
					else if (this.browserSettings.MaximumFiles > 1 && this.browserSettings.MaximumDirectories > 1)
					{
						this.Title = UserControls.Resources.FileSystemBrowserWindow.WindowTitles.OpenFoldersAndFiles;
					}

					break;
				case BrowsingMode.Save:
					this.Title = UserControls.Resources.FileSystemBrowserWindow.WindowTitles.SaveAs;

					break;
				case BrowsingMode.Select:
					if (this.browserSettings.MaximumFiles == 1 && this.browserSettings.MaximumDirectories == 0)
					{
						this.Title = UserControls.Resources.FileSystemBrowserWindow.WindowTitles.SelectFile;
					}
					else if (this.browserSettings.MaximumFiles > 1 && this.browserSettings.MaximumDirectories == 0)
					{
						this.Title = UserControls.Resources.FileSystemBrowserWindow.WindowTitles.SelectFiles;
					}
					else if (this.browserSettings.MaximumFiles == 0 && this.browserSettings.MaximumDirectories == 1)
					{
						this.Title = UserControls.Resources.FileSystemBrowserWindow.WindowTitles.SelectFolder;
					}
					else if (this.browserSettings.MinimumFiles == 0 && this.browserSettings.MaximumDirectories > 1)
					{
						this.Title = UserControls.Resources.FileSystemBrowserWindow.WindowTitles.SelectFolders;
					}
					else if (this.browserSettings.MaximumFiles == 1 && this.browserSettings.MaximumDirectories == 1)
					{
						this.Title = UserControls.Resources.FileSystemBrowserWindow.WindowTitles.SelectFolderAndFile;
					}
					else if (this.browserSettings.MaximumFiles > 1 && this.browserSettings.MaximumDirectories == 1)
					{
						this.Title = UserControls.Resources.FileSystemBrowserWindow.WindowTitles.SelectFolderAndFiles;
					}
					else if (this.browserSettings.MaximumFiles == 1 && this.browserSettings.MaximumDirectories > 1)
					{
						this.Title = UserControls.Resources.FileSystemBrowserWindow.WindowTitles.SelectFoldersAndFile;
					}
					else if (this.browserSettings.MaximumFiles > 1 && this.browserSettings.MaximumDirectories > 1)
					{
						this.Title = UserControls.Resources.FileSystemBrowserWindow.WindowTitles.SelectFoldersAndFiles;
					}

					break;
			}

			/*
			 * Create navigation stack panel.
			 */

			PathButton desktopNavigationButton = new PathButton(UserControls.Resources.FileSystemBrowserWindow.NavigationButtons.Desktop, Environment.GetFolderPath(Environment.SpecialFolder.Desktop), new RoutedEventHandler(this.PathButton_Click));
			PathButton recentNavigationButton = new PathButton(UserControls.Resources.FileSystemBrowserWindow.NavigationButtons.Recent, Environment.GetFolderPath(Environment.SpecialFolder.Recent), new RoutedEventHandler(this.PathButton_Click));
			PathButton documentsNavigationButton = new PathButton(UserControls.Resources.FileSystemBrowserWindow.NavigationButtons.Documents, Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), new RoutedEventHandler(this.PathButton_Click));
			PathButton musicNavigationButton = new PathButton(UserControls.Resources.FileSystemBrowserWindow.NavigationButtons.Music, Environment.GetFolderPath(Environment.SpecialFolder.MyMusic), new RoutedEventHandler(this.PathButton_Click));
			PathButton picturesNavigationButton = new PathButton(UserControls.Resources.FileSystemBrowserWindow.NavigationButtons.Pictures, Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), new RoutedEventHandler(this.PathButton_Click));
			PathButton videosNavigationButton = new PathButton(UserControls.Resources.FileSystemBrowserWindow.NavigationButtons.Videos, Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), new RoutedEventHandler(this.PathButton_Click));

			this.navigationStackPanel.Children.Add(desktopNavigationButton);
			this.navigationStackPanel.Children.Add(recentNavigationButton);
			this.navigationStackPanel.Children.Add(documentsNavigationButton);
			this.navigationStackPanel.Children.Add(musicNavigationButton);
			this.navigationStackPanel.Children.Add(picturesNavigationButton);
			this.navigationStackPanel.Children.Add(videosNavigationButton);

			/*
			 * Put column header buttons and column header images into column header grids.
			 */

			this.InitialiseColumnHeaderGrid(this.availableFreeSpaceGrid, this.availableFreeSpaceButton, SortingColumn.AvailableFreeSpace);
			this.InitialiseColumnHeaderGrid(this.creationTimeGrid, this.creationTimeButton, SortingColumn.CreationTime);
			this.InitialiseColumnHeaderGrid(this.driveFormatGrid, this.driveFormatButton, SortingColumn.DriveFormat);
			this.InitialiseColumnHeaderGrid(this.driveTypeGrid, this.driveTypeButton, SortingColumn.DriveType);
			this.InitialiseColumnHeaderGrid(this.lastAccessTimeGrid, this.lastAccessTimeButton, SortingColumn.LastAccessTime);
			this.InitialiseColumnHeaderGrid(this.lastWriteTimeGrid, this.lastWriteTimeButton, SortingColumn.LastWriteTime);
			this.InitialiseColumnHeaderGrid(this.nameGrid, this.nameButton, SortingColumn.Name);
			this.InitialiseColumnHeaderGrid(this.rootDirectoryGrid, this.rootDirectoryButton, SortingColumn.RootDirectory);
			this.InitialiseColumnHeaderGrid(this.sizeGrid, this.sizeButton, SortingColumn.Size);
			this.InitialiseColumnHeaderGrid(this.totalFreeSpaceGrid, this.totalFreeSpaceButton, SortingColumn.TotalFreeSpace);
			this.InitialiseColumnHeaderGrid(this.totalSizeGrid, this.totalSizeButton, SortingColumn.TotalSize);
			this.InitialiseColumnHeaderGrid(this.volumeGrid, this.volumeButton, SortingColumn.VolumeLabel);

			/*
			 * Put column header grids into column headers.
			 */

			this.availableFreeSpaceGridViewColumn.Header = this.availableFreeSpaceGrid;
			this.creationTimeGridViewColumn.Header = this.creationTimeGrid;
			this.driveFormatGridViewColumn.Header = this.driveFormatGrid;
			this.driveTypeGridViewColumn.Header = this.driveTypeGrid;
			this.lastAccessTimeGridViewColumn.Header = this.lastAccessTimeGrid;
			this.lastWriteTimeGridViewColumn.Header = this.lastWriteTimeGrid;
			this.nameGridViewColumn.Header = this.nameGrid;
			this.rootDirectoryGridViewColumn.Header = this.rootDirectoryGrid;
			this.sizeGridViewColumn.Header = this.sizeGrid;
			this.totalFreeSpaceGridViewColumn.Header = this.totalFreeSpaceGrid;
			this.totalSizeGridViewColumn.Header = this.totalSizeGrid;
			this.volumeLabelGridViewColumn.Header = this.volumeGrid;

			/*
			 * Translate column header buttons.
			 */

			this.availableFreeSpaceButton.Content = UserControls.Resources.FileSystemBrowserWindow.Columns.AvailableFreeSpace;
			this.creationTimeButton.Content = UserControls.Resources.FileSystemBrowserWindow.Columns.CreationTime;
			this.driveFormatButton.Content = UserControls.Resources.FileSystemBrowserWindow.Columns.DriveFormat;
			this.driveTypeButton.Content = UserControls.Resources.FileSystemBrowserWindow.Columns.DriveType;
			this.lastAccessTimeButton.Content = UserControls.Resources.FileSystemBrowserWindow.Columns.LastAccessTime;
			this.lastWriteTimeButton.Content = UserControls.Resources.FileSystemBrowserWindow.Columns.LastWriteTime;
			this.nameButton.Content = UserControls.Resources.FileSystemBrowserWindow.Columns.Name;
			this.rootDirectoryButton.Content = UserControls.Resources.FileSystemBrowserWindow.Columns.RootDirectory;
			this.sizeButton.Content = UserControls.Resources.FileSystemBrowserWindow.Columns.Size;
			this.totalFreeSpaceButton.Content = UserControls.Resources.FileSystemBrowserWindow.Columns.TotalFreeSpace;
			this.totalSizeButton.Content = UserControls.Resources.FileSystemBrowserWindow.Columns.TotalSize;
			this.volumeButton.Content = UserControls.Resources.FileSystemBrowserWindow.Columns.VolumeLabel;

			/*
			 * Initialise column header images.
			 */

			BitmapImage arrowBitmapImage = null;

			arrowBitmapImage = new BitmapImage();

			arrowBitmapImage.BeginInit();
			arrowBitmapImage.UriSource = new Uri("pack://application:,,,/Emi.UserControls.FileSystemBrowserWindow;component/Images/ArrowAscending.png");
			arrowBitmapImage.EndInit();

			this.arrowAscendingImage.Source = arrowBitmapImage;

			arrowBitmapImage = new BitmapImage();

			arrowBitmapImage.BeginInit();
			arrowBitmapImage.UriSource = new Uri("pack://application:,,,/Emi.UserControls.FileSystemBrowserWindow;component/Images/ArrowDescending.png");
			arrowBitmapImage.EndInit();

			this.arrowDescendingImage.Source = arrowBitmapImage;

			/*
			 * Translate context menu.
			 */

			this.newMenuItem.Header = UserControls.Resources.FileSystemBrowserWindow.Buttons.New;

			ContextMenu listViewContextMenu = (ContextMenu)this.fileSystemListView.Resources["ListViewContextMenu"];

			MenuItem renameMenuItem = (MenuItem)listViewContextMenu.Items[0];
			MenuItem deleteMenuItem = (MenuItem)listViewContextMenu.Items[1];

			deleteMenuItem.Header = UserControls.Resources.FileSystemBrowserWindow.Buttons.Delete;
			renameMenuItem.Header = UserControls.Resources.FileSystemBrowserWindow.Buttons.Rename;

			/*
			 * Translate window buttons.
			 */

			this.deleteButton.Content = UserControls.Resources.FileSystemBrowserWindow.Buttons.Delete;
			this.newButton.Content = UserControls.Resources.FileSystemBrowserWindow.Buttons.New;
			this.renameButton.Content = UserControls.Resources.FileSystemBrowserWindow.Buttons.Rename;

			switch (this.browserSettings.BrowsingMode)
			{
				case BrowsingMode.Open:
					this.actionButton.Content = UserControls.Resources.FileSystemBrowserWindow.Buttons.Open;

					break;
				case BrowsingMode.Save:
					this.actionButton.Content = UserControls.Resources.FileSystemBrowserWindow.Buttons.Save;

					break;
				case BrowsingMode.Select:
					this.actionButton.Content = UserControls.Resources.FileSystemBrowserWindow.Buttons.Select;

					break;
			}

			this.cancelButton.Content = UserControls.Resources.FileSystemBrowserWindow.Buttons.Cancel;

			/*
			 * Configure file saving controls.
			 */

			if (this.browserSettings.BrowsingMode == BrowsingMode.Save)
			{
				this.fileNameTextBox.Text = this.browserSettings.DefaultFileName;

				this.fileNameTextBox.Focus();
				this.fileNameTextBox.Select(0, fileNameTextBox.Text.Length);

				if (this.browserSettings.CanSelectEncoding)
				{
					this.unicodeLabel.Visibility = Visibility.Visible;
					this.unicodeStackPanel.Visibility = Visibility.Visible;

					switch (this.browserSettings.DefaultEncoding.GetPreamble().Length)
					{
						case 0:
							this.utf8RadioButton.IsChecked = true;

							this.bigEndianRadioButton.IsChecked = false;
							this.bigEndianRadioButton.IsEnabled = false;

							this.byteOrderMarkCheckBox.IsChecked = false;

							this.littleEndianRadioButton.IsChecked = false;
							this.littleEndianRadioButton.IsEnabled = false;

							break;
						case 2:
							if (this.browserSettings.DefaultEncoding.GetPreamble()[0] == 254 && this.browserSettings.DefaultEncoding.GetPreamble()[1] == 255)
							{
								this.utf16RadioButton.IsChecked = true;

								this.bigEndianRadioButton.IsChecked = true;

								this.byteOrderMarkCheckBox.IsChecked = true;
								this.byteOrderMarkCheckBox.IsEnabled = false;
							}
							else if (this.browserSettings.DefaultEncoding.GetPreamble()[0] == 255 && this.browserSettings.DefaultEncoding.GetPreamble()[1] == 254)
							{
								this.utf16RadioButton.IsChecked = true;

								this.byteOrderMarkCheckBox.IsChecked = true;
								this.byteOrderMarkCheckBox.IsEnabled = false;

								this.littleEndianRadioButton.IsChecked = true;
							}

							break;
						case 3:
							if (this.browserSettings.DefaultEncoding.GetPreamble()[0] == 239 && this.browserSettings.DefaultEncoding.GetPreamble()[1] == 187 && this.browserSettings.DefaultEncoding.GetPreamble()[2] == 191)
							{
								this.utf8RadioButton.IsChecked = true;

								this.bigEndianRadioButton.IsChecked = false;
								this.bigEndianRadioButton.IsEnabled = false;

								this.byteOrderMarkCheckBox.IsChecked = true;

								this.littleEndianRadioButton.IsChecked = false;
								this.littleEndianRadioButton.IsEnabled = false;
							}

							break;
						case 4:
							if (this.browserSettings.DefaultEncoding.GetPreamble()[0] == 0 && this.browserSettings.DefaultEncoding.GetPreamble()[1] == 0 && this.browserSettings.DefaultEncoding.GetPreamble()[2] == 254 && this.browserSettings.DefaultEncoding.GetPreamble()[3] == 255)
							{
								this.utf32RadioButton.IsChecked = true;

								this.bigEndianRadioButton.IsChecked = true;

								this.byteOrderMarkCheckBox.IsChecked = true;
								this.byteOrderMarkCheckBox.IsEnabled = false;
							}
							else if (this.browserSettings.DefaultEncoding.GetPreamble()[0] == 255 && this.browserSettings.DefaultEncoding.GetPreamble()[1] == 254 && this.browserSettings.DefaultEncoding.GetPreamble()[2] == 0 && this.browserSettings.DefaultEncoding.GetPreamble()[3] == 0)
							{
								this.utf32RadioButton.IsChecked = true;

								this.byteOrderMarkCheckBox.IsChecked = true;

								this.littleEndianRadioButton.IsChecked = true;
								this.byteOrderMarkCheckBox.IsEnabled = false;
							}

							break;
					}
				}

				this.fileTypesComboBox.DisplayMemberPath = "Value";
				this.fileTypesComboBox.ItemsSource = this.browserSettings.SupportedFileTypes;
				this.fileTypesComboBox.SelectedValue = this.browserSettings.DefaultFileType.Key;
				this.fileTypesComboBox.SelectedValuePath = "Key";

				this.SaveScrollViewer.Visibility = Visibility.Visible;
			}

			/*
			 * Navigate file system.
			 */

			this.path = PathManipulator.Sanitise(this.browserSettings.Path);

			this.NavigateFileSystem(this.path);
		}
	}
}