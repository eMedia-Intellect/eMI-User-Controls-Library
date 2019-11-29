// <author>Stefán Örvar Sigmundsson</author>
// <copyright company="eMedia Intellect" file="Title.cs">
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
	/// <content>Contains the <see cref="Title"/> property.</content>
	public partial class CloseableTabItem
	{
		/// <summary>Gets or sets a value indicating the title of the tab item.</summary>
		/// <remarks>If <see cref="isCloseable"/> is set to false then the header of the tab item is updated with the title. In any case, the <see cref="closeableHeader"/> field is updated with the title in case the <see cref="IsCloseable"/> property is changed to true.</remarks>
		/// <value>Represents the <see cref="title"/> field.</value>
		public string Title
		{
			get
			{
				return this.title;
			}

			set
			{
				this.title = value;

				this.closeableHeader.titleLabel.Content = this.title;

				if (!this.isCloseable)
				{
					this.Header = this.title;
				}
			}
		}
	}
}