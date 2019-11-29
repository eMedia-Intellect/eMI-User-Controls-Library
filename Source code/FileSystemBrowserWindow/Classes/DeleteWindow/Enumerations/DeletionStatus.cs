// <author>Stefán Örvar Sigmundsson</author>
// <copyright company="eMedia Intellect" file="DeletionStatus.cs">
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
	/// <content>Contains the <see cref="DeletionStatus"/> enumeration.</content>
	internal partial class DeleteWindow
	{
		/// <summary>The status of a <see cref="FileSystemItemDeletion"/> instance after being processed by the <see cref="DeleteDirectories"/> or <see cref="DeleteFiles"/> methods.</summary>
		internal enum DeletionStatus
		{
			/// <summary>Represents that the file system item is pending deletion.</summary>
			Pending,

			/// <summary>Represents that the file system item was deleted.</summary>
			Deleted,

			/// <summary>Represents that the file system item could not be deleted.</summary>
			Error
		}
	}
}