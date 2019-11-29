// <author>Stefán Örvar Sigmundsson</author>
// <copyright company="eMedia Intellect" file="FileOperation.cs">
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
	using Emi.UserControls.Interop;

	/// <content>Contains the <see cref="FileOperation"/> class.</content>
	internal partial class DeleteWindow
	{
		/// <summary>Provides a wrapper for the IFileOperation COM interface.</summary>
		internal class FileOperation
		{
			/// <summary>The system type of the IFileOperation interface.</summary>
			private static readonly Type FileOperationType = Type.GetTypeFromCLSID(new Guid("3AD05575-8857-4850-9277-11B85BDB8E09"));

			/// <summary>The instance of the IFileOperation interface.</summary>
			private readonly IFileOperation fileOperation;

			/// <summary>Initialises a new instance of the <see cref="FileOperation"/> class.</summary>
			internal FileOperation()
			{
				this.fileOperation = (IFileOperation)Activator.CreateInstance(FileOperationType);

				this.fileOperation.SetOperationFlags(0x4 | 0x40 | 0x80000);
			}

			/// <summary>Calls the IFileOperation.DeleteItem function.</summary>
			/// <param name="fileSystemItemIShellItem">The IShellItem to delete.</param>
			internal void DeleteItem(IShellItem fileSystemItemIShellItem)
			{
				this.fileOperation.DeleteItem(fileSystemItemIShellItem, null);
			}

			/// <summary>Calls the IFileOperation.PerformOperations function.</summary>
			/// <returns>The HRESULT returned by the IFileOperation.PerformOperations function.</returns>
			internal uint PerformOperations()
			{
				return this.fileOperation.PerformOperations();
			}
		}
	}
}