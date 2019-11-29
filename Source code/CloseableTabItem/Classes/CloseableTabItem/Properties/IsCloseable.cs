// <author>Stefán Örvar Sigmundsson</author>
// <copyright company="eMedia Intellect" file="IsCloseable.cs">
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
	/// <content>Contains the <see cref="IsCloseable"/> property.</content>
	public partial class CloseableTabItem
	{
		/// <summary>Gets or sets a value indicating whether the tab item is closeable.</summary>
		/// <remarks>If the value is set to true then the header is a <see cref="CloseableHeader"/> containing the <see cref="title"/> and a close button. If the value is set to false then the header is the <see cref="title"/>.</remarks>
		/// <value>Represents the <see cref="isCloseable"/> field.</value>
		public bool IsCloseable
		{
			get
			{
				return this.isCloseable;
			}

			set
			{
				this.isCloseable = value;

				if (this.isCloseable)
				{
					this.Header = this.closeableHeader;
				}
				else
				{
					this.Header = this.title;
				}
			}
		}
	}
}