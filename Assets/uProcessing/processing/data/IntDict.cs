using System;
using System.Collections.Generic;
using System.Text;

namespace processing.data
{
	// uncomment when available
	//using PApplet = processing.core.PApplet;


	/// <summary>
	/// A simple class to use a String as a lookup for an int value.
	/// 
	/// @webref data:composite </summary>
	/// <seealso cref= FloatDict </seealso>
	/// <seealso cref= StringDict </seealso>
	public class IntDict
	{

		/// <summary>
		/// Number of elements in the table </summary>
		protected internal int count;
		protected internal string[] keys_Renamed;
		protected internal int[] values_Renamed;

		/// <summary>
		/// Internal implementation for faster lookups </summary>
		private Dictionary<string, int?> indices = new Dictionary<string, int?> ();


		//  /**
		//   * Create a new object by counting the number of times each unique entry
		//   * shows up in the specified String array.
		//   */
		//  static public IntHash fromTally(String[] list) {
		//    IntHash outgoing = new IntHash();
		//    for (String s : list) {
		//      outgoing.inc(s);
		//    }
		//    outgoing.crop();
		//    return outgoing;
		//  }
		//
		//
		//  static public IntHash fromOrder(String[] list) {
		//    IntHash outgoing = new IntHash();
		//    for (int i = 0; i < list.length; i++) {
		//      outgoing.set(list[i], i);
		//    }
		//    return outgoing;
		//  }


		public IntDict ()
		{
			count = 0;
			keys_Renamed = new string[10];
			values_Renamed = new int[10];
		}


		/// <summary>
		/// Create a new lookup with a specific size. This is more efficient than not
		/// specifying a size. Use it when you know the rough size of the thing you're creating.
		/// 
		/// @nowebref
		/// </summary>
		public IntDict (int length)
		{
			count = 0;
			keys_Renamed = new string[length];
			values_Renamed = new int[length];
		}


		/// <summary>
		/// Read a set of entries from a Reader that has each key/value pair on
		/// a single line, separated by a tab.
		/// 
		/// @nowebref
		/// </summary>

		// TODO: Rewrite with system.io
//		public IntDict (BufferedReader reader)
//		{
//			//  public IntHash(PApplet parent, String filename) {
//			string[] lines = PApplet.loadStrings (reader);
//			keys_Renamed = new string[lines.Length];
//			values_Renamed = new int[lines.Length];
//
//			//    boolean csv = (lines[0].indexOf('\t') == -1);
//			for (int i = 0; i < lines.Length; i++) {
//				//      String[] pieces = csv ? Table.splitLineCSV(lines[i]) : PApplet.split(lines[i], '\t');
//				string[] pieces = PApplet.Split (lines [i], '\t');
//				if (pieces.Length == 2) {
//					keys_Renamed [count] = pieces [0];
//					values_Renamed [count] = PApplet.parseInt (pieces [1]);
//					indices [pieces [0]] = count;
//					count++;
//				}
//			}
//		}

		/// <summary>
		/// @nowebref
		/// </summary>
		public IntDict (string[] keys, int[] values)
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
		/// Returns the number of key/value pairs
		/// 
		/// @webref intdict:method
		/// @brief Returns the number of key/value pairs
		/// </summary>
		public virtual int size ()
		{
			return count;
		}


		/// <summary>
		/// Remove all entries.
		/// 
		/// @webref intdict:method
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


		//  private void crop() {
		//    if (count != keys.length) {
		//      keys = PApplet.subset(keys, 0, count);
		//      values = PApplet.subset(values, 0, count);
		//    }
		//  }


		/// <summary>
		/// Return the internal array being used to store the keys. Allocated but
		/// unused entries will be removed. This array should not be modified.
		/// 
		/// @webref intdict:method
		/// @brief Return the internal array being used to store the keys
		/// </summary>
		//  public String[] keys() {
		//    crop();
		//    return keys;
		//  }


		//  public Iterable<String> keys() {
		//    return new Iterable<String>() {
		//
		//      @Override
		//      public Iterator<String> iterator() {
		//        return new Iterator<String>() {
		//          int index = -1;
		//
		//          public void remove() {
		//            removeIndex(index);
		//          }
		//
		//          public String next() {
		//            return key(++index);
		//          }
		//
		//          public boolean hasNext() {
		//            return index+1 < size();
		//          }
		//        };
		//      }
		//    };
		//  }


		// Use this with 'for' loops
		public virtual System.Collections.IEnumerable keys ()
		{
			return new IterableAnonymousInnerClassHelper (this);
		}

		private class IterableAnonymousInnerClassHelper : System.Collections.IEnumerable
		{
			private readonly IntDict outerInstance;

			public IterableAnonymousInnerClassHelper (IntDict outerInstance)
			{
				this.outerInstance = outerInstance;
			}

			public virtual System.Collections.IEnumerator GetEnumerator ()
			{
				return outerInstance.keyIterator ();
				//        return new Iterator<String>() {
				//          int index = -1;
				//
				//          public void remove() {
				//            removeIndex(index);
				//          }
				//
				//          public String next() {
				//            return key(++index);
				//          }
				//
				//          public boolean hasNext() {
				//            return index+1 < size();
				//          }
				//        };
			}
		}


		// Use this to iterate when you want to be able to remove elements along the way
		public virtual System.Collections.IEnumerator keyIterator ()
		{
			return new IteratorAnonymousInnerClassHelper (this);
		}

		private class IteratorAnonymousInnerClassHelper : System.Collections.IEnumerator
		{
			private readonly IntDict outerInstance;

			public IteratorAnonymousInnerClassHelper (IntDict outerInstance)
			{
				this.outerInstance = outerInstance;
				index = -1;
			}

			internal int index;

			public object Current {
				get {
					return outerInstance.key(index);
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
				outerInstance.removeIndex (index);
			}

			public virtual string next ()
			{
				return outerInstance.key (++index);
			}

			public virtual bool hasNext ()
			{
				return index + 1 < outerInstance.size ();
			}
		}


		/// <summary>
		/// Return a copy of the internal keys array. This array can be modified.
		/// 
		/// @webref intdict:method
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

		public virtual int value (int index)
		{
			return values_Renamed [index];
		}


		/// <summary>
		/// @webref intdict:method
		/// @brief Return the internal array being used to store the keys
		/// </summary>
		public virtual System.Collections.IEnumerable values ()
		{
			return new IterableAnonymousInnerClassHelper2 (this);
		}

		private class IterableAnonymousInnerClassHelper2 : System.Collections.IEnumerable
		{
			private readonly IntDict outerInstance;

			public IterableAnonymousInnerClassHelper2 (IntDict outerInstance)
			{
				this.outerInstance = outerInstance;
			}

			public virtual System.Collections.IEnumerator GetEnumerator ()
			{
				return outerInstance.valueIterator ();
			}
		}


		public virtual System.Collections.IEnumerator valueIterator ()
		{
			return new IteratorAnonymousInnerClassHelper2 (this);
		}

		private class IteratorAnonymousInnerClassHelper2 : System.Collections.IEnumerator
		{
			private readonly IntDict outerInstance;

			public IteratorAnonymousInnerClassHelper2 (IntDict outerInstance)
			{
				this.outerInstance = outerInstance;
				index = -1;
			}

			internal int index;

			public object Current {
				get {
					return outerInstance.value(index);
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
				outerInstance.removeIndex (index);
			}

			public virtual int? next ()
			{
				return outerInstance.value (++index);
			}

			public virtual bool hasNext ()
			{
				return index + 1 < outerInstance.size ();
			}
		}


		/// <summary>
		/// Create a new array and copy each of the values into it.
		/// 
		/// @webref intdict:method
		/// @brief Create a new array and copy each of the values into it
		/// </summary>
		public virtual int[] valueArray ()
		{
			return valueArray (null);
		}


		/// <summary>
		/// Fill an already-allocated array with the values (more efficient than
		/// creating a new array each time). If 'array' is null, or not the same
		/// size as the number of values, a new array will be allocated and returned.
		/// </summary>
		/// <param name="array"> values to copy into the array </param>
		public virtual int[] valueArray (int[] array)
		{
			if (array == null || array.Length != size ()) {
				array = new int[count];
			}
			Array.Copy (values_Renamed, 0, array, 0, count);
			return array;
		}


		/// <summary>
		/// Return a value for the specified key.
		/// 
		/// @webref intdict:method
		/// @brief Return a value for the specified key
		/// </summary>
		public virtual int get (string key)
		{
			int _index = index (key);
			if (_index == -1) {
				return 0;
			}
			return values_Renamed [_index];
		}

		/// <summary>
		/// Create a new key/value pair or change the value of one.
		/// 
		/// @webref intdict:method
		/// @brief Create a new key/value pair or change the value of one
		/// </summary>
		public virtual void set (string key, int amount)
		{
			int _index = index (key);
			if (_index == -1) {
				create (key, amount);
			} else {
				values_Renamed [_index] = amount;
			}
		}

		/// <summary>
		/// @webref intdict:method
		/// @brief Check if a key is a part of the data structure
		/// </summary>
		public virtual bool hasKey (string key)
		{
			return index (key) != -1;
		}


		/// <summary>
		/// Increase the value associated with a specific key by 1.
		/// 
		/// @webref intdict:method
		/// @brief Increase the value of a specific key value by 1
		/// </summary>
		public virtual void increment (string key)
		{
			add (key, 1);
		}


		/// <summary>
		/// @webref intdict:method
		/// @brief Add to a value
		/// </summary>
		public virtual void add (string key, int amount)
		{
			int _index = index (key);
			if (_index == -1) {
				create (key, amount);
			} else {
				values_Renamed [_index] += amount;
			}
		}


		/// <summary>
		/// @webref intdict:method
		/// @brief Subtract from a value
		/// </summary>
		public virtual void sub (string key, int amount)
		{
			add (key, -amount);
		}


		/// <summary>
		/// @webref intdict:method
		/// @brief Multiply a value
		/// </summary>
		public virtual void mult (string key, int amount)
		{
			int _index = index (key);
			if (_index != -1) {
				values_Renamed [_index] *= amount;
			}
		}


		/// <summary>
		/// @webref intdict:method
		/// @brief Divide a value
		/// </summary>
		public virtual void div (string key, int amount)
		{
			int _index = index (key);
			if (_index != -1) {
				values_Renamed [_index] /= amount;
			}
		}

		private void checkMinMax (string functionName)
		{
			if (count == 0) {
				string msg = string.Format ("Cannot use {0}() on an empty {1}.", functionName, this.GetType ().Name);
				throw new Exception (msg);
			}
		}


		// return the index of the minimum value
		public virtual int minIndex ()
		{
			checkMinMax ("minIndex");
			int index = 0;
			int value = values_Renamed [0];
			for (int i = 1; i < count; i++) {
				if (values_Renamed [i] < value) {
					index = i;
					value = values_Renamed [i];
				}
			}
			return index;
		}


		// return the minimum value
		public virtual int minValue ()
		{
			checkMinMax ("minValue");
			return values_Renamed [minIndex ()];
		}


		// return the key for the minimum value
		public virtual string minKey ()
		{
			checkMinMax ("minKey");
			return keys_Renamed [minIndex ()];
		}


		// return the index of the max value
		public virtual int maxIndex ()
		{
			checkMinMax ("maxIndex");
			int index = 0;
			int value = values_Renamed [0];
			for (int i = 1; i < count; i++) {
				if (values_Renamed [i] > value) {
					index = i;
					value = values_Renamed [i];
				}
			}
			return index;
		}


		// return the maximum value
		public virtual int maxValue ()
		{
			checkMinMax ("maxValue");
			return values_Renamed [maxIndex ()];
		}


		// return the key corresponding to the maximum value
		public virtual string maxKey ()
		{
			checkMinMax ("maxKey");
			return keys_Renamed [maxIndex ()];
		}

		public virtual int index (string what)
		{
			int? found = indices [what];
			return (found == null) ? - 1 : (int)found;
		}

		protected internal virtual void create (string what, int much)
		{
			if (count == keys_Renamed.Length) {
				// TODO: PApplet
//				keys_Renamed = PApplet.expand (keys_Renamed);
//				values_Renamed = PApplet.expand (values_Renamed);
			}
			indices [what] = new int? (count);
			keys_Renamed [count] = what;
			values_Renamed [count] = much;
			count++;
		}

		/// <summary>
		/// @webref intdict:method
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
			indices.Remove (keys_Renamed [index]);
			for (int i = index; i < count - 1; i++) {
				keys_Renamed [i] = keys_Renamed [i + 1];
				values_Renamed [i] = values_Renamed [i + 1];
				indices [keys_Renamed [i]] = i;
			}
			count--;
			keys_Renamed [count] = null;
			values_Renamed [count] = 0;
			return key;
		}

		public virtual void swap (int a, int b)
		{
			string tkey = keys_Renamed [a];
			int tvalue = values_Renamed [a];
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
		/// @webref intdict:method
		/// @brief Sort the keys alphabetically
		/// </summary>
		public virtual void sortKeys ()
		{
			sortImpl (true, false);
		}

		/// <summary>
		/// Sort the keys alphabetically in reverse (ignoring case). Uses the value as a
		/// tie-breaker (only really possible with a key that has a case change).
		/// 
		/// @webref intdict:method
		/// @brief Sort the keys alphabetially in reverse
		/// </summary>
		public virtual void sortKeysReverse ()
		{
			sortImpl (true, true);
		}


		/// <summary>
		/// <<<<<<< HEAD
		/// Sort by values in descending order (largest value will be at [0]).
		/// 
		/// =======
		/// Sort by values in ascending order. The smallest value will be at [0].
		/// 
		/// >>>>>>> cd467dc12a42d588638aaab06746bebdfb333cc4
		/// @webref intdict:method
		/// @brief Sort by values in ascending order
		/// </summary>
		public virtual void sortValues ()
		{
			sortImpl (false, false);
		}

		/// <summary>
		/// Sort by values in descending order. The largest value will be at [0].
		/// 
		/// @webref intdict:method
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
			private readonly IntDict outerInstance;
			private bool useKeys;
			private bool reverse;

			public SortAnonymousInnerClassHelper (IntDict outerInstance, bool useKeys, bool reverse)
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
						return outerInstance.values_Renamed [a] - outerInstance.values_Renamed [b];
					}
				} // sort values
			else {
					diff = outerInstance.values_Renamed [a] - outerInstance.values_Renamed [b];
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
		/// Sum all of the values in this dictionary, then return a new FloatDict of
		/// each key, divided by the total sum. The total for all values will be ~1.0. </summary>
		/// <returns> a Dict with the original keys, mapped to their pct of the total </returns>
		public virtual FloatDict Percent {
			get {
				double sum = 0;
				foreach (int value in valueArray()) {
					sum += value;
				}
				FloatDict outgoing = new FloatDict ();
				for (int i = 0; i < size(); i++) {
					double percent = value (i) / sum;
					outgoing.set (key (i), (float)percent);
				}
				return outgoing;
			}
		}


		/// <summary>
		/// Returns a duplicate copy of this object. </summary>
		public virtual IntDict copy ()
		{
			IntDict outgoing = new IntDict (count);
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
		/// 
	
		// TODO: rewrite with system.io
//		public virtual void write (PrintWriter writer)
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
				sb.Append ("\"" + keys_Renamed [i] + "\": " + values_Renamed [i]);
			}
			sb.Append (" }");
			return sb.ToString ();
		}
	}

}