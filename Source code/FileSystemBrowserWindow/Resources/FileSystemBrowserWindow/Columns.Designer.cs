// <author>Stefán Örvar Sigmundsson</author>
// <copyright company="eMedia Intellect" file="Columns.Designer.cs">
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
	using System;

	[global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
	[global::System.Diagnostics.DebuggerNonUserCode]
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	internal class Columns
	{
		private static global::System.Resources.ResourceManager resourceMan;

		private static global::System.Globalization.CultureInfo resourceCulture;

		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Resource management is handled by the platform.")]
		internal Columns()
		{
		}

		[global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
		internal static global::System.Resources.ResourceManager ResourceManager
		{
			get
			{
				if (object.ReferenceEquals(resourceMan, null))
				{
					global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Emi.UserControls.Resources.FileSystemBrowserWindow.Columns", typeof(Columns).Assembly);

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

		internal static string AvailableFreeSpace
		{
			get
			{
				return ResourceManager.GetString("AvailableFreeSpace", resourceCulture);
			}
		}

		internal static string CreationTime
		{
			get
			{
				return ResourceManager.GetString("CreationTime", resourceCulture);
			}
		}

		internal static string DriveFormat
		{
			get
			{
				return ResourceManager.GetString("DriveFormat", resourceCulture);
			}
		}

		internal static string DriveType
		{
			get
			{
				return ResourceManager.GetString("DriveType", resourceCulture);
			}
		}

		internal static string LastAccessTime
		{
			get
			{
				return ResourceManager.GetString("LastAccessTime", resourceCulture);
			}
		}

		internal static string LastWriteTime
		{
			get
			{
				return ResourceManager.GetString("LastWriteTime", resourceCulture);
			}
		}

		internal static string Name
		{
			get
			{
				return ResourceManager.GetString("Name", resourceCulture);
			}
		}

		internal static string RootDirectory
		{
			get
			{
				return ResourceManager.GetString("RootDirectory", resourceCulture);
			}
		}

		internal static string Size
		{
			get
			{
				return ResourceManager.GetString("Size", resourceCulture);
			}
		}

		internal static string TotalFreeSpace
		{
			get
			{
				return ResourceManager.GetString("TotalFreeSpace", resourceCulture);
			}
		}

		internal static string TotalSize
		{
			get
			{
				return ResourceManager.GetString("TotalSize", resourceCulture);
			}
		}

		internal static string VolumeLabel
		{
			get
			{
				return ResourceManager.GetString("VolumeLabel", resourceCulture);
			}
		}
	}
}