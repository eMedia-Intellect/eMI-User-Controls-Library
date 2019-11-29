// <author>Stefán Örvar Sigmundsson</author>
// <copyright company="eMedia Intellect" file="ErrorWindow.Designer.cs">
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

[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Resource management is handled by the platform.")]
[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:FileHeaderFileNameDocumentationMustMatchTypeName", Justification = "Resource management is handled by the platform.")]

namespace Emi.UserControls.Resources
{
	[global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
	[global::System.Diagnostics.DebuggerNonUserCode]
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	internal class ErrorWindow
	{
		private static global::System.Resources.ResourceManager resourceMan;

		private static global::System.Globalization.CultureInfo resourceCulture;

		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Resource management is handled by the platform.")]
		internal ErrorWindow()
		{
		}

		[global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
		internal static global::System.Resources.ResourceManager ResourceManager
		{
			get
			{
				if (object.ReferenceEquals(resourceMan, null))
				{
					global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Emi.UserControls.Resources.ErrorWindow", typeof(ErrorWindow).Assembly);

					resourceMan = temp;
				}

				return resourceMan;
			}
		}

		[global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
		internal static global::System.Globalization.CultureInfo Culture
		{
			get
			{
				return resourceCulture;
			}

			set
			{
				resourceCulture = value;
			}
		}

		internal static string DirectoryNotFoundException
		{
			get
			{
				return ResourceManager.GetString("DirectoryNotFoundException", resourceCulture);
			}
		}

		internal static string IOException
		{
			get
			{
				return ResourceManager.GetString("IOException", resourceCulture);
			}
		}

		internal static string OkButton
		{
			get
			{
				return ResourceManager.GetString("OkButton", resourceCulture);
			}
		}

		internal static string PathTooLongException
		{
			get
			{
				return ResourceManager.GetString("PathTooLongException", resourceCulture);
			}
		}

		internal static string SecurityException
		{
			get
			{
				return ResourceManager.GetString("SecurityException", resourceCulture);
			}
		}

		internal static string UnauthorizedAccessException
		{
			get
			{
				return ResourceManager.GetString("UnauthorizedAccessException", resourceCulture);
			}
		}

		internal static string WindowTitle
		{
			get
			{
				return ResourceManager.GetString("WindowTitle", resourceCulture);
			}
		}
	}
}