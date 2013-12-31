using System;
using System.Collections.Generic;
using System.Text;

namespace processing.data
{
	//uncomment when available
	//using PApplet = processing.core.PApplet;


	/// <summary>
	/// A simple table class to use a String as a lookup for another String value.
	/// 
	/// @webref data:composite </summary>
	/// <seealso cref= IntDict </seealso>
	/// <seealso cref= FloatDict </seealso>
	public class StringDict
	{

		/// <summary>
		/// Number of elements in the table </summary>
		protected internal int count;
		protected internal string[] keys_Renamed;
		protected internal string[] values_Renamed;

		/// <summary>
		/// Internal implementation for faster lookups </summary>
		private Dictionary<string, int?> indices = new Dictionary<string, int?> ();

		public StringDict ()
		{
			count = 0;
			keys_Renamed = new string[10];
			values_Renamed = new string[10];
		}


		/// <summary>
		/// Create a new lookup pre-allocated to a specific length. This will not
		/// change the size(), but is more efficient than not specifying a length.
		/// Use it when you know the rough size of the thing you're creating.
		/// 
		/// @nowebref
		/// </summary>
		public StringDict (int length)
		{
			count = 0;
			keys_Renamed = new string[length];
			values_Renamed = new string[length];
		}


		/// <summary>
		/// Read a set of entries from a Reader that has each key/value pair on
		/// a single line, separated by a tab.
		/// 
		/// @nowebref
		/// </summary>
		/// 
		// TODO: reinplement with SYstem.IO
//		public StringDict (BufferedReader reader)
//		{
//			string[] lines = PApplet.loadStrings (reader);
//			keys_Renamed = new string[lines.Length];
//			values_Renamed = new string[lines.Length];
//
//			for (int i = 0; i < lines.Length; i++) {
//				string[] pieces = PApplet.Split (lines [i], '\t');
//				if (pieces.Length == 2) {
//					keys_Renamed [count] = pieces [0];
//					values_Renamed [count] = pieces [1];
//					count++;
//				}
//			}
//		}

		/// <summary>
		/// @nowebref
		/// </summary>
		public StringDict (string[] keys, string[] values)
		{
			if (keys.Length != values.Length) {
				throw new System.ArgumentException ("key and value arrays must be the same length");
			}
			this.keys_Renamed = keys;
			this.values_Renamed = values;
			count = keys.Length;
			for (int i = 0; i < count; i++) {
				indices [keys [i]] = i;
			}
		}

		/// <summary>
		/// @webref stringdict:method
		/// @brief Returns the number of key/value pairs
		/// </summary>
		public virtual int size ()
		{
			return count;
		}


		/// <summary>
		/// Remove all entries.
		/// 
		/// @webref stringdict:method
		/// @brief Remove all entries
		/// </summary>
		public virtual void clear ()
		{
			count = 0;
			indices = new Dictionary<string, int?> ();
		}

		public virtual string key (int index)
		{
			return keys_Renamed [index];
		}

		protected internal virtual void crop ()
		{
			if (count != keys_Renamed.Length) {
				//TODO: PApplet
//				keys_Renamed = PApplet.subset (keys_Renamed, 0, count);
//				values_Renamed = PApplet.subset (values_Renamed, 0, count);
			}
		}


		//  /**
		//   * Return the internal array being used to store the keys. Allocated but
		//   * unused entries will be removed. This array should not be modified.
		//   */
		//  public String[] keys() {
		//    crop();
		//    return keys;
		//  }

		/// <summary>
		/// @webref stringdict:method
		/// @brief Return the internal array being used to store the keys
		/// </summary>
		public virtual System.Collections.IEnumerable keys ()
		{
			return new IterableAnonymousInnerClassHelper (this);
		}

		private class IterableAnonymousInnerClassHelper : System.Collections.IEnumerable
		{
			private readonly StringDict outerInstance;

			public IterableAnonymousInnerClassHelper (StringDict outerInstance)
			{
				this.outerInstance = outerInstance;
			}

			public virtual System.Collections.IEnumerator GetEnumerator ()
			{
				return new IteratorAnonymousInnerClassHelper (this);
			}

			private class IteratorAnonymousInnerClassHelper : System.Collections.IEnumerator
			{
				private readonly IterableAnonymousInnerClassHelper outerInstance;

				public IteratorAnonymousInnerClassHelper (IterableAnonymousInnerClassHelper outerInstance)
				{
					this.outerInstance = outerInstance;
					index = -1;
				}

				internal int index;

				public object Current {
					get {
						return outerInstance.outerInstance.key(index);
					}
				}
				
				public void Reset()
				{
					index = -1;
				}
				
				public bool MoveNext() {
					++index;
					return hasNext();
				}


				public virtual void remove ()
				{
					outerInstance.outerInstance.removeIndex (index);
				}

				public virtual string next ()
				{
					return outerInstance.outerInstance.key (++index);
				}

				public virtual bool hasNext ()
				{
					return index + 1 < outerInstance.outerInstance.size ();
				}
			}
		}


		/// <summary>
		/// Return a copy of the internal keys array. This array can be modified.
		/// 
		/// @webref stringdict:method
		/// @brief Return a copy of the internal keys array
		/// </summary>
		public virtual string[] keyArray ()
		{
			return keyArray (null);
		}

		public virtual string[] keyArray (string[] outgoing)
		{
			if (outgoing == null || outgoing.Length != count) {
				outgoing = new string[count];
			}
			Array.Copy (keys_Renamed, 0, outgoing, 0, count);
			return outgoing;
		}

		public virtual string value (int index)
		{
			return values_Renamed [index];
		}

		/// <summary>
		/// @webref stringdict:method
		/// @brief Return the internal array being used to store the values
		/// </summary>
		public virtual System.Collections.IEnumerable values ()
		{
			return new IterableAnonymousInnerClassHelper2 (this);
		}

		private class IterableAnonymousInnerClassHelper2 : System.Collections.IEnumerable
		{
			private readonly StringDict outerInstance;

			public IterableAnonymousInnerClassHelper2 (StringDict outerInstance)
			{
				this.outerInstance = outerInstance;
			}

			public virtual System.Collections.IEnumerator GetEnumerator ()
			{
				return new IteratorAnonymousInnerClassHelper2 (this);
			}

			private class IteratorAnonymousInnerClassHelper2 : System.Collections.IEnumerator
			{
				private readonly IterableAnonymousInnerClassHelper2 outerInstance;

				public IteratorAnonymousInnerClassHelper2 (IterableAnonymousInnerClassHelper2 outerInstance)
				{
					this.outerInstance = outerInstance;
					index = -1;
				}

				internal int index;

				public object Current {
					get {
						return outerInstance.outerInstance.value(index);
					}
				}
				
				public void Reset()
				{
					index = -1;
				}
				
				public bool MoveNext() {
					++index;
					return hasNext();
				}


				public virtual void remove ()
				{
					outerInstance.outerInstance.removeIndex (index);
				}

				public virtual string next ()
				{
					return outerInstance.outerInstance.value (++index);
				}

				public virtual bool hasNext ()
				{
					return index + 1 < outerInstance.outerInstance.size ();
				}
			}
		}


		/// <summary>
		/// Create a new array and copy each of the values into it.
		/// 
		/// @webref stringdict:method
		/// @brief Create a new array and copy each of the values into it
		/// </summary>
		public virtual string[] valueArray ()
		{
			return valueArray (null);
		}


		/// <summary>
		/// Fill an already-allocated array with the values (more efficient than
		/// creating a new array each time). If 'array' is null, or not the same
		/// size as the number of values, a new array will be allocated and returned.
		/// </summary>
		public virtual string[] valueArray (string[] array)
		{
			if (array == null || array.Length != size ()) {
				array = new string[count];
			}
			Array.Copy (values_Renamed, 0, array, 0, count);
			return array;
		}


		/// <summary>
		/// Return a value for the specified key.
		/// 
		/// @webref stringdict:method
		/// @brief Return a value for the specified key
		/// </summary>
		public virtual string get (string key)
		{
			int _index = index (key);
			if (_index == -1) {
				return null;
			}
			return values_Renamed [_index];
		}

		/// <summary>
		/// @webref stringdict:method
		/// @brief Create a new key/value pair or change the value of one
		/// </summary>
		public virtual void set (string key, string amount)
		{
			int _index = index (key);
			if (_index == -1) {
				create (key, amount);
			} else {
				values_Renamed [_index] = amount;
			}
		}

		public virtual int index (string what)
		{
			int? found = indices [what];
			return (found == null) ? - 1 : (int)found;
		}

		/// <summary>
		/// @webref stringdict:method
		/// @brief Check if a key is a part of the data structure
		/// </summary>
		public virtual bool hasKey (string key)
		{
			return index (key) != -1;
		}

		protected internal virtual void create (string key, string value)
		{
			if (count == keys_Renamed.Length) {
				//TODO: PApplet
//				keys_Renamed = PApplet.expand (keys_Renamed);
//				values_Renamed = PApplet.expand (values_Renamed);
			}
			indices [key] = new int? (count);
			keys_Renamed [count] = key;
			values_Renamed [count] = value;
			count++;
		}

		/// <summary>
		/// @webref stringdict:method
		/// @brief Remove a key/value pair
		/// </summary>
		public virtual int remove (string key)
		{
			int _index = index (key);
			if (_index != -1) {
				removeIndex (_index);
			}
			return _index;
		}

		public virtual string removeIndex (int index)
		{
			if (index < 0 || index >= count) {
				throw new System.IndexOutOfRangeException (index.ToString());
			}
			//System.out.println("index is " + which + " and " + keys[which]);
			string key = keys_Renamed [index];
			indices.Remove (key);
			for (int i = index; i < count - 1; i++) {
				keys_Renamed [i] = keys_Renamed [i + 1];
				values_Renamed [i] = values_Renamed [i + 1];
				indices [keys_Renamed [i]] = i;
			}
			count--;
			keys_Renamed [count] = null;
			values_Renamed [count] = null;
			return key;
		}

		public virtual void swap (int a, int b)
		{
			string tkey = keys_Renamed [a];
			string tvalue = values_Renamed [a];
			keys_Renamed [a] = keys_Renamed [b];
			values_Renamed [a] = values_Renamed [b];
			keys_Renamed [b] = tkey;
			values_Renamed [b] = tvalue;

			indices [keys_Renamed [a]] = new int? (a);
			indices [keys_Renamed [b]] = new int? (b);
		}


		/// <summary>
		/// Sort the keys alphabetically (ignoring case). Uses the value as a
		/// tie-breaker (only really possible with a key that has a case change).
		/// 
		/// @webref stringdict:method
		/// @brief Sort the keys alphabetically
		/// </summary>
		public virtual void sortKeys ()
		{
			sortImpl (true, false);
		}

		/// <summary>
		/// @webref stringdict:method
		/// @brief Sort the keys alphabetially in reverse
		/// </summary>
		public virtual void sortKeysReverse ()
		{
			sortImpl (true, true);
		}


		/// <summary>
		/// Sort by values in descending order (largest value will be at [0]).
		/// 
		/// @webref stringdict:method
		/// @brief Sort by values in ascending order
		/// </summary>
		public virtual void sortValues ()
		{
			sortImpl (false, false);
		}


		/// <summary>
		/// @webref stringdict:method
		/// @brief Sort by values in descending order
		/// </summary>
		public virtual void sortValuesReverse ()
		{
			sortImpl (false, true);
		}


//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: protected void sortImpl(final boolean useKeys, final boolean reverse)
		protected internal virtual void sortImpl (bool useKeys, bool reverse)
		{
			Sort s = new SortAnonymousInnerClassHelper (this, useKeys, reverse);
			s.run ();
		}

		private class SortAnonymousInnerClassHelper : Sort
		{
			private readonly StringDict outerInstance;
			private bool useKeys;
			private bool reverse;

			public SortAnonymousInnerClassHelper (StringDict outerInstance, bool useKeys, bool reverse)
			{
				this.outerInstance = outerInstance;
				this.useKeys = useKeys;
				this.reverse = reverse;
			}

			public override int size ()
			{
				return outerInstance.count;
			}

			public override float compare (int a, int b)
			{
				int diff = 0;
				if (useKeys) {
					diff = outerInstance.keys_Renamed [a].ToLower().CompareTo (outerInstance.keys_Renamed [b].ToLower());
					if (diff == 0) {
						diff = outerInstance.values_Renamed [a].ToLower().CompareTo (outerInstance.values_Renamed [b].ToLower());
					}
				} // sort values
			else {
					diff = outerInstance.values_Renamed [a].ToLower().CompareTo (outerInstance.values_Renamed [b].ToLower());
					if (diff == 0) {
						diff = outerInstance.keys_Renamed [a].ToLower().CompareTo (outerInstance.keys_Renamed [b].ToLower());
					}
				}
				return reverse ? - diff : diff;
			}

			public override void swap (int a, int b)
			{
				outerInstance.swap (a, b);
			}
		}


		/// <summary>
		/// Returns a duplicate copy of this object. </summary>
		public virtual StringDict copy ()
		{
			StringDict outgoing = new StringDict (count);
			Array.Copy (keys_Renamed, 0, outgoing.keys_Renamed, 0, count);
			Array.Copy (values_Renamed, 0, outgoing.values_Renamed, 0, count);
			for (int i = 0; i < count; i++) {
				outgoing.indices [keys_Renamed [i]] = i;
			}
			outgoing.count = count;
			return outgoing;
		}


		/// <summary>
		/// Write tab-delimited entries out to </summary>
		/// <param name="writer"> </param>
		//TODO: rewrite with System.IO
// 		public virtual void write (PrintWriter writer)
//		{
//			for (int i = 0; i < count; i++) {
//				writer.println (keys_Renamed [i] + "\t" + values_Renamed [i]);
//			}
//			writer.flush ();
//		}

		public override string ToString ()
		{
			StringBuilder sb = new StringBuilder ();
			sb.Append (this.GetType ().Name + " size=" + size () + " { ");
			for (int i = 0; i < size(); i++) {
				if (i != 0) {
					sb.Append (", ");
				}
				sb.Append ("\"" + keys_Renamed [i] + "\": \"" + values_Renamed [i] + "\"");
			}
			sb.Append (" }");
			return sb.ToString ();
		}
	}

}