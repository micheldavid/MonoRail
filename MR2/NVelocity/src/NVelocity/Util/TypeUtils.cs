using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace NVelocity.Util
{
	public static class TypeUtils
	{
		private static readonly Assembly myAssembly = typeof(TypeUtils).Assembly;
		private static readonly string myAssemblyName = myAssembly.GetName().Name;
		private static readonly bool isFromGac = RuntimeEnvironment.FromGlobalAccessCache(myAssembly);

		private static string PrepareTypeName(string typeName)
		{
			if (isFromGac)
			{
				string[] typeNameParts = typeName.Split(',');
				if (typeNameParts.Length == 2 && typeNameParts[1].Trim() == myAssemblyName)
					return typeNameParts[0] + ", " + myAssembly.FullName;
			}
			return typeName;
		}

		public static Type GetType(string typeName)
		{
			return Type.GetType(PrepareTypeName(typeName));
		}

		public static Type GetType(string typeName, bool throwOnError)
		{
			return Type.GetType(PrepareTypeName(typeName), throwOnError);
		}

		public static Type GetType(string typeName, bool throwOnError, bool ignoreCase)
		{
			return Type.GetType(PrepareTypeName(typeName), throwOnError, ignoreCase);
		}
	}
}
