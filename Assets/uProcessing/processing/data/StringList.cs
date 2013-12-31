using System;
using System.Collections.Generic;
using System.Text;

namespace processing.data
{
	// uncomment when available
	//using PApplet = processing.core.PApplet;

	/// <summary>
	/// Helper class for a list of Strings. Lists are designed to have some of the
	/// features of ArrayLists, but to maintain the simplicity and efficiency of
	/// working with arrays.
	/// 
	/// Functions like sort() and shuffle() always act on the list itself. To get
	/// a sorted copy, use list.copy().sort().
	/// 
	/// @webref data:composite </summary>
	/// <seealso cref= IntList </seealso>
	/// <seealso cref= FloatList </seealso>
	public class StringList : System.Collections.IEnumerable
	{
		internal int count;
		internal string[] data;

		public StringList () : this(10)
		{
		}

		/// <summary>
		/// @nowebref
		/// </summary>
		public StringList (int length)
		{
			data = new string[length];
		}

		/// <summary>
		/// @nowebref
		/// </summary>
		public StringList (string[] list)
		{
			count = list.Length;
			data = new string[count];
			Array.Copy (list, 0, data, 0, count);
		}


		/// <summary>
		/// Create from something iterable, for instance:
		/// StringList list = new StringList(hashMap.keySet());
		/// 
		/// @nowebref
		/// </summary>
		public StringList (IEnumerable<string> iter) : this(10)
		{
			foreach (string s in iter) {
				append (s);
			}
		}


		/// <summary>
		/// Improve efficiency by removing allocated but unused entries from the
		/// internal array used to store the data. Set to private, though it could
		/// be useful to have this public if lists are frequently making drastic
		/// size changes (from very large to very small).
		/// </summary>
		private void crop ()
		{
			if (count != data.Length) {
				//TODO: PApplet
//				data = PApplet.subset (data, 0, count);
			}
		}


		/// <summary>
		/// Get the length of the list.
		/// 
		/// @webref stringlist:method
		/// @brief Get the length of the list
		/// </summary>
		public virtual int size ()
		{
			return count;
		}

		public virtual void resize (int length)
		{
			if (length > data.Length) {
				string[] temp = new string[length];
				Array.Copy (data, 0, temp, 0, count);
				data = temp;

			} else if (length > count) {
				//TODO: Implement Fill
				//Arrays.Fill (data, count, length, 0);
			}
			count = length;
		}


		/// <summary>
		/// Remove all entries from the list.
		/// 
		/// @webref stringlist:method
		/// @brief Remove all entries from the list
		/// </summary>
		public virtual void clear ()
		{
			count = 0;
		}


		/// <summary>
		/// Get an entry at a particular index.
		/// 
		/// @webref stringlist:method
		/// @brief Get an entry at a particular index
		/// </summary>
		public virtual string get (int index)
		{
			return data [index];
		}


		/// <summary>
		/// Set the entry at a particular index. If the index is past the length of
		/// the list, it'll expand the list to accommodate, and fill the intermediate
		/// entries with 0s.
		/// 
		/// @webref stringlist:method
		/// @brief Set an entry at a particular index
		/// </summary>
		public virtual void set (int index, string what)
		{
			if (index >= count) {
				//TODO: PApplet
//				data = PApplet.expand (data, index + 1);
//				for (int i = count; i < index; i++) {
//					data [i] = null;
//				}
//				count = index + 1;
			}
			data [index] = what;
		}


		/// <summary>
		/// Remove an element from the specified index.
		/// 
		/// @webref stringlist:method
		/// @brief Remove an element from the specified index
		/// </summary>
		public virtual string remove (int index)
		{
			if (index < 0 || index >= count) {
				throw new System.IndexOutOfRangeException (index.ToString());
			}
			string entry = data [index];
			//    int[] outgoing = new int[count - 1];
			//    System.arraycopy(data, 0, outgoing, 0, index);
			//    count--;
			//    System.arraycopy(data, index + 1, outgoing, 0, count - index);
			//    data = outgoing;
			for (int i = index; i < count - 1; i++) {
				data [i] = data [i + 1];
			}
			count--;
			return entry;
		}


		// Remove the first instance of a particular value and return its index.
		public virtual int removeValue (string value)
		{
			if (value == null) {
				for (int i = 0; i < count; i++) {
					if (data [i] == null) {
						remove (i);
						return i;
					}
				}
			} else {
				int _index = index (value);
				if (_index != -1) {
					remove (_index);
					return _index;
				}
			}
			return -1;
		}


		// Remove all instances of a particular value and return the count removed.
		public virtual int removeValues (string value)
		{
			int ii = 0;
			if (value == null) {
				for (int i = 0; i < count; i++) {
					if (data [i] != null) {
						data [ii++] = data [i];
					}
				}
			} else {
				for (int i = 0; i < count; i++) {
					if (!value.Equals (data [i])) {
						data [ii++] = data [i];
					}
				}
			}
			int removed = count - ii;
			count = ii;
			return removed;
		}


		// replace the first value that matches, return the index that was replaced
		public virtual int replaceValue (string value, string newValue)
		{
			if (value == null) {
				for (int i = 0; i < count; i++) {
					if (data [i] == null) {
						data [i] = newValue;
						return i;
					}
				}
			} else {
				for (int i = 0; i < count; i++) {
					if (value.Equals (data [i])) {
						data [i] = newValue;
						return i;
					}
				}
			}
			return -1;
		}


		// replace all values that match, return the count of those replaced
		public virtual int replaceValues (string value, string newValue)
		{
			int changed = 0;
			if (value == null) {
				for (int i = 0; i < count; i++) {
					if (data [i] == null) {
						data [i] = newValue;
						changed++;
					}
				}
			} else {
				for (int i = 0; i < count; i++) {
					if (value.Equals (data [i])) {
						data [i] = newValue;
						changed++;
					}
				}
			}
			return changed;
		}


		/// <summary>
		/// Add a new entry to the list.
		/// 
		/// @webref stringlist:method
		/// @brief Add a new entry to the list
		/// </summary>
		public virtual void append (string value)
		{
			if (count == data.Length) {
				//TODO: implement this
//				data = PApplet.expand (data);
			}
			data [count++] = value;
		}

		public virtual void append (string[] values)
		{
			foreach (string v in values) {
				append (v);
			}
		}

		public virtual void append (StringList list)
		{
			foreach (string v in list.values()) { // will concat the list...
				append (v);
			}
		}


		//  public void insert(int index, int value) {
		//    if (index+1 > count) {
		//      if (index+1 < data.length) {
		//    }
		//  }
		//    if (index >= data.length) {
		//      data = PApplet.expand(data, index+1);
		//      data[index] = value;
		//      count = index+1;
		//
		//    } else if (count == data.length) {
		//    if (index >= count) {
		//      //int[] temp = new int[count << 1];
		//      System.arraycopy(data, 0, temp, 0, index);
		//      temp[index] = value;
		//      System.arraycopy(data, index, temp, index+1, count - index);
		//      data = temp;
		//
		//    } else {
		//      // data[] has room to grow
		//      // for() loop believed to be faster than System.arraycopy over itself
		//      for (int i = count; i > index; --i) {
		//        data[i] = data[i-1];
		//      }
		//      data[index] = value;
		//      count++;
		//    }
		//  }


		// same as splice
		public virtual void insert (int index, string[] values)
		{
			if (index < 0) {
				throw new System.ArgumentException ("insert() index cannot be negative: it was " + index);
			}
			if (index >= values.Length) {
				throw new System.ArgumentException ("insert() index " + index + " is past the end of this list");
			}

			string[] temp = new string[count + values.Length];

			// Copy the old values, but not more than already exist
			Array.Copy (data, 0, temp, 0, Math.Min (count, index));

			// Copy the new values into the proper place
			Array.Copy (values, 0, temp, index, values.Length);

			//    if (index < count) {
			// The index was inside count, so it's a true splice/insert
			Array.Copy (data, index, temp, index + values.Length, count - index);
			count = count + values.Length;
			//    } else {
			//      // The index was past 'count', so the new count is weirder
			//      count = index + values.length;
			//    }
			data = temp;
		}

		public virtual void insert (int index, StringList list)
		{
			insert (index, list.values ());
		}


		// below are aborted attempts at more optimized versions of the code
		// that are harder to read and debug...

		//    if (index + values.length >= count) {
		//      // We're past the current 'count', check to see if we're still allocated
		//      // index 9, data.length = 10, values.length = 1
		//      if (index + values.length < data.length) {
		//        // There's still room for these entries, even though it's past 'count'.
		//        // First clear out the entries leading up to it, however.
		//        for (int i = count; i < index; i++) {
		//          data[i] = 0;
		//        }
		//        data[index] =
		//      }
		//      if (index >= data.length) {
		//        int length = index + values.length;
		//        int[] temp = new int[length];
		//        System.arraycopy(data, 0, temp, 0, count);
		//        System.arraycopy(values, 0, temp, index, values.length);
		//        data = temp;
		//        count = data.length;
		//      } else {
		//
		//      }
		//
		//    } else if (count == data.length) {
		//      int[] temp = new int[count << 1];
		//      System.arraycopy(data, 0, temp, 0, index);
		//      temp[index] = value;
		//      System.arraycopy(data, index, temp, index+1, count - index);
		//      data = temp;
		//
		//    } else {
		//      // data[] has room to grow
		//      // for() loop believed to be faster than System.arraycopy over itself
		//      for (int i = count; i > index; --i) {
		//        data[i] = data[i-1];
		//      }
		//      data[index] = value;
		//      count++;
		//    }


		/// <summary>
		/// Return the first index of a particular value. </summary>
		public virtual int index (string what)
		{
			if (what == null) {
				for (int i = 0; i < count; i++) {
					if (data [i] == null) {
						return i;
					}
				}
			} else {
				for (int i = 0; i < count; i++) {
					if (what.Equals (data [i])) {
						return i;
					}
				}
			}
			return -1;
		}


		// !!! TODO this is not yet correct, because it's not being reset when
		// the rest of the entries are changed
		//  protected void cacheIndices() {
		//    indexCache = new HashMap<Integer, Integer>();
		//    for (int i = 0; i < count; i++) {
		//      indexCache.put(data[i], i);
		//    }
		//  }

		/// <summary>
		/// @webref stringlist:method
		/// @brief Check if a value is a part of the list
		/// </summary>
		public virtual bool hasValue (string value)
		{
			if (value == null) {
				for (int i = 0; i < count; i++) {
					if (data [i] == null) {
						return true;
					}
				}
			} else {
				for (int i = 0; i < count; i++) {
					if (value.Equals (data [i])) {
						return true;
					}
				}
			}
			return false;
		}


		/// <summary>
		/// Sorts the array in place.
		/// 
		/// @webref stringlist:method
		/// @brief Sorts the array in place
		/// </summary>
		public virtual void sort ()
		{
			sortImpl (false);
		}


		/// <summary>
		/// Reverse sort, orders values from highest to lowest.
		/// 
		/// @webref stringlist:method
		/// @brief Reverse sort, orders values from highest to lowest
		/// </summary>
		public virtual void sortReverse ()
		{
			sortImpl (true);
		}


//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: private void sortImpl(final boolean reverse)
		private void sortImpl (bool reverse)
		{
			new SortAnonymousInnerClassHelper (this, reverse)
		.run ();
		}

		private class SortAnonymousInnerClassHelper : Sort
		{
			private readonly StringList outerInstance;
			private bool reverse;

			public SortAnonymousInnerClassHelper (StringList outerInstance, bool reverse)
			{
				this.outerInstance = outerInstance;
				this.reverse = reverse;
			}

			public override int size ()
			{
				return outerInstance.count;
			}

			public override float compare (int a, int b)
			{
				float diff = outerInstance.data [a].ToLower().CompareTo (outerInstance.data [b].ToLower());
				return reverse ? - diff : diff;
			}

			public override void swap (int a, int b)
			{
				string temp = outerInstance.data [a];
				outerInstance.data [a] = outerInstance.data [b];
				outerInstance.data [b] = temp;
			}
		}


		// use insert()
		//  public void splice(int index, int value) {
		//  }


		//  public void subset(int start) {
		//    subset(start, count - start);
		//  }
		//
		//
		//  public void subset(int start, int num) {
		//    for (int i = 0; i < num; i++) {
		//      data[i] = data[i+start];
		//    }
		//    count = num;
		//  }

		/// <summary>
		/// @webref stringlist:method
		/// @brief To come...
		/// </summary>
		public virtual void reverse ()
		{
			int ii = count - 1;
			for (int i = 0; i < count / 2; i++) {
				string t = data [i];
				data [i] = data [ii];
				data [ii] = t;
				--ii;
			}
		}


		/// <summary>
		/// Randomize the order of the list elements. Note that this does not
		/// obey the randomSeed() function in PApplet.
		/// 
		/// @webref stringlist:method
		/// @brief Randomize the order of the list elements
		/// </summary>
		public virtual void shuffle ()
		{
			Random r = new Random ();
			int num = count;
			while (num > 1) {
				int value = r.Next (num);
				num--;
				string temp = data [num];
				data [num] = data [value];
				data [value] = temp;
			}
		}


		/// <summary>
		/// Randomize the list order using the random() function from the specified
		/// sketch, allowing shuffle() to use its current randomSeed() setting.
		/// </summary>
		// uncomment when available
//		public virtual void shuffle (PApplet sketch)
//		{
//			int num = count;
//			while (num > 1) {
//				int value = (int)sketch.random (num);
//				num--;
//				string temp = data [num];
//				data [num] = data [value];
//				data [value] = temp;
//			}
//		}


		/// <summary>
		/// Make the entire list lower case.
		/// 
		/// @webref stringlist:method
		/// @brief Make the entire list lower case
		/// </summary>
		public virtual void lower ()
		{
			for (int i = 0; i < count; i++) {
				if (data [i] != null) {
					data [i] = data [i].ToLower ();
				}
			}
		}


		/// <summary>
		/// Make the entire list upper case.
		/// 
		/// @webref stringlist:method
		/// @brief Make the entire list upper case
		/// </summary>
		public virtual void upper ()
		{
			for (int i = 0; i < count; i++) {
				if (data [i] != null) {
					data [i] = data [i].ToUpper ();
				}
			}
		}

		public virtual StringList copy ()
		{
			StringList outgoing = new StringList (data);
			outgoing.count = count;
			return outgoing;
		}


		/// <summary>
		/// Returns the actual array being used to store the data. Suitable for
		/// iterating with a for() loop, but modifying the list could cause terrible
		/// things to happen.
		/// </summary>
		public virtual string[] values ()
		{
			crop ();
			return data;
		}

		public virtual System.Collections.IEnumerator GetEnumerator ()
		{
			//    return valueIterator();
			//  }
			//
			//
			//  public Iterator<String> valueIterator() {
			return new IteratorAnonymousInnerClassHelper (this);
		}

		private class IteratorAnonymousInnerClassHelper : System.Collections.IEnumerator
		{
			private readonly StringList outerInstance;

			public IteratorAnonymousInnerClassHelper (StringList outerInstance)
			{
				this.outerInstance = outerInstance;
				index = -1;
			}

			internal int index;

			public object Current {
				get {
					return outerInstance.data [index];
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
				outerInstance.remove (index);
			}

			public virtual string next ()
			{
				return outerInstance.data [++index];
			}

			public virtual bool hasNext ()
			{
				return index + 1 < outerInstance.count;
			}
		}


		/// <summary>
		/// Create a new array with a copy of all the values.
		/// </summary>
		/// <returns> an array sized by the length of the list with each of the values.
		/// @webref stringlist:method
		/// @brief Create a new array with a copy of all the values </returns>
		public virtual string[] array ()
		{
			return array (null);
		}


		/// <summary>
		/// Copy as many values as possible into the specified array. </summary>
		/// <param name="array"> </param>
		public virtual string[] array (string[] array)
		{
			if (array == null || array.Length != count) {
				array = new string[count];
			}
			Array.Copy (data, 0, array, 0, count);
			return array;
		}

		public virtual StringList getSubset (int start)
		{
			return getSubset (start, count - start);
		}

		public virtual StringList getSubset (int start, int num)
		{
			string[] subset = new string[num];
			Array.Copy (data, start, subset, 0, num);
			return new StringList (subset);
		}


		/// <summary>
		/// Get a list of all unique entries. </summary>
		public virtual string[] Unique {
			get {
				return Tally.keyArray ();
			}
		}


		/// <summary>
		/// Count the number of times each String entry is found in this list. </summary>
		public virtual IntDict Tally {
			get {
				IntDict outgoing = new IntDict ();
				for (int i = 0; i < count; i++) {
					outgoing.increment (data [i]);
				}
				return outgoing;
			}
		}


		/// <summary>
		/// Create a dictionary associating each entry in this list to its index. </summary>
		public virtual IntDict Order {
			get {
				IntDict outgoing = new IntDict ();
				for (int i = 0; i < count; i++) {
					outgoing.set (data [i], i);
				}
				return outgoing;
			}
		}


		//  public void println() {
		//    for (int i = 0; i < count; i++) {
		//      System.out.println("[" + i + "] " + data[i]);
		//    }
		//    System.out.flush();
		//  }


		public virtual string join (string separator)
		{
			if (count == 0) {
				return "";
			}
			StringBuilder sb = new StringBuilder ();
			sb.Append (data [0]);
			for (int i = 1; i < count; i++) {
				sb.Append (separator);
				sb.Append (data [i]);
			}
			return sb.ToString ();
		}


		//  static public StringList split(String value, char delim) {
		//    String[] array = PApplet.split(value, delim);
		//    return new StringList(array);
		//  }


		public override string ToString ()
		{
			StringBuilder sb = new StringBuilder ();
			sb.Append (this.GetType ().Name + " size=" + size () + " [ ");
			for (int i = 0; i < size(); i++) {
				if (i != 0) {
					sb.Append (", ");
				}
				sb.Append (i + ": \"" + data [i] + "\"");
			}
			sb.Append (" ]");
			return sb.ToString ();
		}
	}
}