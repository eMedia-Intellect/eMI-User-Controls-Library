// <author>Stefán Örvar Sigmundsson</author>
// <copyright company="eMedia Intellect" file="DriveTypeEnumerations.Designer.cs">
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

namespace Emi.UserControls.Resources.FileSystemBrowserWindow
{
	[global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
	[global::System.Diagnostics.DebuggerNonUserCode]
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	internal class DriveTypeEnumerations
	{
		private static global::System.Resources.ResourceManager resourceMan;

		private static global::System.Globalization.CultureInfo resourceCulture;

		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Resource management is handled by the platform.")]
		internal DriveTypeEnumerations()
		{
		}

		[global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
		internal static global::System.Resources.ResourceManager ResourceManager
		{
			get
			{
				if (object.ReferenceEquals(resourceMan, null))
				{
					global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Emi.UserControls.Resources.FileSystemBrowserWindow.DriveTypeEnumerations", typeof(DriveTypeEnumerations).Assembly);

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

		internal static string CDRom
		{
			get
			{
				return ResourceManager.GetString("CDRom", resourceCulture);
			}
		}

		internal static string Fixed
		{
			get
			{
				return ResourceManager.GetString("Fixed", resourceCulture);
			}
		}

		internal static string Network
		{
			get
			{
				return ResourceManager.GetString("Network", resourceCulture);
			}
		}

		internal static string NoRootDirectory
		{
			get
			{
				return ResourceManager.GetString("NoRootDirectory", resourceCulture);
			}
		}

		internal static string Ram
		{
			get
			{
				return ResourceManager.GetString("Ram", resourceCulture);
			}
		}

		internal static string Removable
		{
			get
			{
				return ResourceManager.GetString("Removable", resourceCulture);
			}
		}

		internal static string Unknown
		{
			get
			{
				return ResourceManager.GetString("Unknown", resourceCulture);
			}
		}
	}
}