// <author>Stefán Örvar Sigmundsson</author>
// <copyright company="eMedia Intellect" file="DeleteFiles.cs">
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
	using Emi.UserControls.Interop;

	/// <content>Contains the <see cref="DeleteFiles"/> method.</content>
	internal partial class DeleteWindow
	{
		/// <summary>Deletes the files contained in the <see cref="fileList"/> field.</summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.NamingRules", "SA1306:FieldNamesMustBeginWithLowerCaseLetter", Justification = "Named by Microsoft.")]
		private void DeleteFiles()
		{
			foreach (FileSystemItemDeletion currentFileSystemItemDeletion in this.fileList)
			{
				IShellItem fileSystemItemIShellItem;

				uint HRESULT = 0;

				HRESULT = NativeMethods.SHCreateItemFromParsingName(FileSystemBrowserWindow.PathManipulator.ConcatenatePath(this.fileSystemBrowserWindow.CurrentPath, currentFileSystemItemDeletion.Name), null, typeof(IShellItem).GUID, out fileSystemItemIShellItem);

				if (HRESULT == 0)
				{
					FileOperation deletionFileOperation = new FileOperation();

					deletionFileOperation.DeleteItem(fileSystemItemIShellItem);

					HRESULT = deletionFileOperation.PerformOperations();

					if (HRESULT == 0)
					{
						currentFileSystemItemDeletion.DeletionStatus = DeletionStatus.Deleted;
					}
					else
					{
						currentFileSystemItemDeletion.DeletionStatus = DeletionStatus.Error;
					}
				}
				else
				{
					currentFileSystemItemDeletion.DeletionStatus = DeletionStatus.Error;
				}
			}
		}
	}
}