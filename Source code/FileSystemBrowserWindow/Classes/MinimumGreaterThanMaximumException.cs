// <author>Stefán Örvar Sigmundsson</author>
// <copyright company="eMedia Intellect" file="MinimumGreaterThanMaximumException.cs">
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
	using System.Runtime.Serialization;

	/// <summary>The exception that is thrown when the minimum number of required directories/files is greater than the maximum number of possible directories/files as specified by an instance of the <see cref="BrowserSettings"/> class.</summary>
	[Serializable]
	public class MinimumGreaterThanMaximumException : Exception
	{
		/// <summary>Initialises a new instance of the <see cref="MinimumGreaterThanMaximumException"/> class.</summary>
		public MinimumGreaterThanMaximumException()
		{
		}

		/// <summary>Initialises a new instance of the <see cref="MinimumGreaterThanMaximumException"/> class with the specified message.</summary>
		/// <param name="message">The message for the exception.</param>
		public MinimumGreaterThanMaximumException(string message)
			: base(message)
		{
		}

		/// <summary>Initialises a new instance of the <see cref="MinimumGreaterThanMaximumException"/> class with the specified message and inner exception.</summary>
		/// <param name="message">The message for the exception.</param>
		/// <param name="innerException">The inner exception for the exception.</param>
		public MinimumGreaterThanMaximumException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		/// <summary>Initialises a new instance of the <see cref="MinimumGreaterThanMaximumException"/> class with the specified serialisation information and streaming context.</summary>
		/// <param name="info">The serialisation information for the exception.</param>
		/// <param name="context">The streaming context for the exception.</param>
		protected MinimumGreaterThanMaximumException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}