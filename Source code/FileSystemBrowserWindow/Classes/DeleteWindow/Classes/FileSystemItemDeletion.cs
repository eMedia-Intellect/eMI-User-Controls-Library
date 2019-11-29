// <author>Stefán Örvar Sigmundsson</author>
// <copyright company="eMedia Intellect" file="FileSystemItemDeletion.cs">
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
	/// <content>Contains the <see cref="FileSystemItemDeletion"/> structure.</content>
	internal partial class DeleteWindow
	{
		/// <summary>Provides a file system item abstraction for the <see cref="DeleteWindow"/> class.</summary>
		internal class FileSystemItemDeletion
		{
			/// <summary>Initialises a new instance of the <see cref="FileSystemItemDeletion"/> class with the specified file system item name and deletion status.</summary>
			/// <param name="name">The name of the file system item.</param>
			/// <param name="deletionStatus">The status of the deletion of the file system item.</param>
			internal FileSystemItemDeletion(string name, DeletionStatus deletionStatus)
			{
				this.Name = name;
				this.DeletionStatus = deletionStatus;
			}

			/// <summary>Gets or sets a value indicating the deletion status of the file system item.</summary>
			internal DeletionStatus DeletionStatus
			{
				get;
				set;
			}

			/// <summary>Gets or sets a value indicating the name of the file system item.</summary>
			internal string Name
			{
				get;
				set;
			}
		}
	}
}