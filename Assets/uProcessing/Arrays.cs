//---------------------------------------------------------------------------------------------------------
//	Copyright © 2007 - 2013 Tangible Software Solutions Inc.
//	This class can be used by anyone provided that the copyright notice remains intact.
//
//	This class is used to replace calls to Java's java.util.Arrays.fill methods with the C# equivalent.
//---------------------------------------------------------------------------------------------------------
internal static class Arrays
{
	internal static void Fill<T> (T[] array, T value)
	{
		for (int i = 0; i < array.Length; i++) {
			array [i] = value;
		}
	}

	internal static void Fill<T> (T[] array, int fromIndex, int toIndex, T value)
	{
		for (int i = fromIndex; i < toIndex; i++) {
			array [i] = value;
		}
	}
}