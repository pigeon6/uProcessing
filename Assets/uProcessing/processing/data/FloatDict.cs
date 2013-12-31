using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace processing.data
{
	// uncomment when availalbe
	//using PApplet = processing.core.PApplet;


	/// <summary>
	/// A simple table class to use a String as a lookup for an float value.
	/// 
	/// @webref data:composite </summary>
	/// <seealso cref= IntDict </seealso>
	/// <seealso cref= StringDict </seealso>
	public class FloatDict
	{

		/// <summary>
		/// Number of elements in the table </summary>
		protected internal int count;
		protected internal string[] keys_Renamed;
		protected internal float[] values_Renamed;

		/// <summary>
		/// Internal implementation for faster lookups </summary>
		private Dictionary<string, int?> indices = new Dictionary<string, int?> ();

		public FloatDict ()
		{
			count = 0;
			keys_Renamed = new string[10];
			values_Renamed = new float[10];
		}


		/// <summary>
		/// Create a new lookup with a specific size. This is more efficient than not
		/// specifying a size. Use it when you know the rough size of the thing you're creating.
		/// 
		/// @nowebref
		/// </summary>
		public FloatDict (int length)
		{
			count = 0;
			keys_Renamed = new string[length];
			values_Renamed = new float[length];
		}


		/// <summary>
		/// Read a set of entries from a Reader that has each key/value pair on
		/// a single line, separated by a tab.
		/// 
		/// @nowebref
		/// </summary>

	
		// TODO: rewrite code with System.IO.Reader
//		public FloatDict (BufferedReader reader)
//		{
//			//  public FloatHash(PApplet parent, String filename) {
//			string[] lines = PApplet.loadStrings (reader);
//			keys_Renamed = new string[lines.Length];
//			values_Renamed = new float[lines.Length];
//
//			//    boolean csv = (lines[0].indexOf('\t') == -1);
//			for (int i = 0; i < lines.Length; i++) {
//				//      String[] pieces = csv ? Table.splitLineCSV(lines[i]) : PApplet.split(lines[i], '\t');
//				string[] pieces = PApplet.Split (lines [i], '\t');
//				if (pieces.Length == 2) {
//					keys_Renamed [count] = pieces [0];
//					values_Renamed [count] = PApplet.parseFloat (pieces [1]);
//					count++;
//				}
//			}
//		}

		/// <summary>
		/// @nowebref
		/// </summary>
		public FloatDict (string[] keys, float[] values)
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
		/// @webref floatdict:method
		/// @brief Returns the number of key/value pairs
		/// </summary>
		public virtual int size ()
		{
			return count;
		}


		/// <summary>
		/// Remove all entries.
		/// 
		/// @webref floatdict:method
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
				// TODO:uncomment when PApplet
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
		/// @webref floatdict:method
		/// @brief Return the internal array being used to store the keys
		/// </summary>
		public virtual System.Collections.IEnumerable keys ()
		{
			return new IterableAnonymousInnerClassHelper (this);
		}

		private class IterableAnonymousInnerClassHelper : System.Collections.IEnumerable
		{
			private readonly FloatDict outerInstance;

			public IterableAnonymousInnerClassHelper (FloatDict outerInstance)
			{
				this.outerInstance = outerInstance;
			}

//			public virtual System.Collections.Generic.IEnumerator<string> GetEnumerator ()
//			{
//				return new IteratorAnonymousInnerClassHelper (this);
//			}

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


		/*
	  static class KeyIterator implements Iterator<String> {
	    FloatHash parent;
	    int index;
	
	    public KeyIterator(FloatHash parent) {
	      this.parent = parent;
	      index = -1;
	    }
	
	    public void remove() {
	      parent.removeIndex(index);
	    }
	
	    public String next() {
	      return parent.key(++index);
	    }
	
	    public boolean hasNext() {
	      return index+1 < parent.size();
	    }
	
	    public void reset() {
	      index = -1;
	    }
	  }
	  */


		/// <summary>
		/// Return a copy of the internal keys array. This array can be modified.
		/// 
		/// @webref floatdict:method
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

		public virtual float value (int index)
		{
			return values_Renamed [index];
		}


		//  public float[] values() {
		//    crop();
		//    return values;
		//  }

		/// <summary>
		/// @webref floatdict:method
		/// @brief Return the internal array being used to store the values
		/// </summary>
		public virtual System.Collections.IEnumerable values ()
		{
			return new IterableAnonymousInnerClassHelper2 (this);
		}

		private class IterableAnonymousInnerClassHelper2 : System.Collections.IEnumerable
		{
			private readonly FloatDict outerInstance;

			public IterableAnonymousInnerClassHelper2 (FloatDict outerInstance)
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


				internal int index;

				public virtual void remove ()
				{
					outerInstance.outerInstance.removeIndex (index);
				}

				public virtual float? next ()
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
		/// @webref floatdict:method
		/// @brief Create a new array and copy each of the values into it
		/// </summary>
		public virtual float[] valueArray ()
		{
			return valueArray (null);
		}


		/// <summary>
		/// Fill an already-allocated array with the values (more efficient than
		/// creating a new array each time). If 'array' is null, or not the same
		/// size as the number of values, a new array will be allocated and returned.
		/// </summary>
		public virtual float[] valueArray (float[] array)
		{
			if (array == null || array.Length != size ()) {
				array = new float[count];
			}
			Array.Copy (values_Renamed, 0, array, 0, count);
			return array;
		}


		/// <summary>
		/// Return a value for the specified key.
		/// 
		/// @webref floatdict:method
		/// @brief Return a value for the specified key
		/// </summary>
		public virtual float get (string key)
		{
			int _index = index (key);
			if (_index == -1) {
				return 0;
			}
			return values_Renamed [_index];
		}


		/// <summary>
		/// @webref floatdict:method
		/// @brief Create a new key/value pair or change the value of one
		/// </summary>
		public virtual void set (string key, float amount)
		{
			int _index = index (key);
			if (_index == -1) {
				create (key, amount);
			} else {
				values_Renamed [_index] = amount;
			}
		}


		/// <summary>
		/// @webref floatdict:method
		/// @brief Check if a key is a part of the data structure
		/// </summary>
		public virtual bool hasKey (string key)
		{
			return index (key) != -1;
		}


		//  /** Increase the value of a specific key by 1. */
		//  public void inc(String key) {
		//    inc(key, 1);
		////    int index = index(key);
		////    if (index == -1) {
		////      create(key, 1);
		////    } else {
		////      values[index]++;
		////    }
		//  }


		/// <summary>
		/// @webref floatdict:method
		/// @brief Add to a value
		/// </summary>
		public virtual void add (string key, float amount)
		{
			int _index = index (key);
			if (_index == -1) {
				create (key, amount);
			} else {
				values_Renamed [_index] += amount;
			}
		}


		//  /** Decrease the value of a key by 1. */
		//  public void dec(String key) {
		//    inc(key, -1);
		//  }


		/// <summary>
		/// @webref floatdict:method
		/// @brief Subtract from a value
		/// </summary>
		public virtual void sub (string key, float amount)
		{
			add (key, -amount);
		}


		/// <summary>
		/// @webref floatdict:method
		/// @brief Multiply a value
		/// </summary>
		public virtual void mult (string key, float amount)
		{
			int _index = index (key);
			if (_index != -1) {
				values_Renamed [_index] *= amount;
			}
		}


		/// <summary>
		/// @webref floatdict:method
		/// @brief Divide a value
		/// </summary>
		public virtual void div (string key, float amount)
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


		/// <summary>
		/// @webref floatlist:method
		/// @brief Return the smallest value
		/// </summary>
		public virtual int minIndex ()
		{
			checkMinMax ("minIndex");
			// Will still return NaN if there is 1 or more entries, and they're all NaN
			float m = float.NaN;
			int mi = -1;
			for (int i = 0; i < count; i++) {
				// find one good value to start
				if (values_Renamed [i] == values_Renamed [i]) {
					m = values_Renamed [i];
					mi = i;

					// calculate the rest
					for (int j = i + 1; j < count; j++) {
						float d = values_Renamed [j];
						if (!float.IsNaN (d) && (d < m)) {
							m = values_Renamed [j];
							mi = j;
						}
					}
					break;
				}
			}
			return mi;
		}

		public virtual string minKey ()
		{
			checkMinMax ("minKey");
			return keys_Renamed [minIndex ()];
		}

		public virtual float minValue ()
		{
			checkMinMax ("minValue");
			return values_Renamed [minIndex ()];
		}


		/// <summary>
		/// @webref floatlist:method
		/// @brief Return the largest value
		/// </summary>
		// The index of the entry that has the max value. Reference above is incorrect.
		public virtual int maxIndex ()
		{
			checkMinMax ("maxIndex");
			// Will still return NaN if there is 1 or more entries, and they're all NaN
			float m = float.NaN;
			int mi = -1;
			for (int i = 0; i < count; i++) {
				// find one good value to start
				if (values_Renamed [i] == values_Renamed [i]) {
					m = values_Renamed [i];
					mi = i;

					// calculate the rest
					for (int j = i + 1; j < count; j++) {
						float d = values_Renamed [j];
						if (!float.IsNaN (d) && (d > m)) {
							m = values_Renamed [j];
							mi = j;
						}
					}
					break;
				}
			}
			return mi;
		}


		/// <summary>
		/// The key for a max value. </summary>
		public virtual string maxKey ()
		{
			checkMinMax ("maxKey");
			return keys_Renamed [maxIndex ()];
		}


		/// <summary>
		/// The max value. </summary>
		public virtual float maxValue ()
		{
			checkMinMax ("maxValue");
			return values_Renamed [maxIndex ()];
		}

		public virtual int index (string what)
		{
			int? found = indices [what];
			return (found == null) ? - 1 : (int)found;
		}

		protected internal virtual void create (string what, float much)
		{
			if (count == keys_Renamed.Length) {
				// TODO: uncomment when PApplet
//				keys_Renamed = PApplet.expand (keys_Renamed);
//				values_Renamed = PApplet.expand (values_Renamed);
			}
			indices [what] = new int? (count);
			keys_Renamed [count] = what;
			values_Renamed [count] = much;
			count++;
		}


		/// <summary>
		/// @webref floatdict:method
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
			string key = keys_Renamed [index];
			//System.out.println("index is " + which + " and " + keys[which]);
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
			float tvalue = values_Renamed [a];
			keys_Renamed [a] = keys_Renamed [b];
			values_Renamed [a] = values_Renamed [b];
			keys_Renamed [b] = tkey;
			values_Renamed [b] = tvalue;

			indices [keys_Renamed [a]] = new int? (a);
			indices [keys_Renamed [b]] = new int? (b);
		}


		//  abstract class InternalSort extends Sort {
		//    @Override
		//    public int size() {
		//      return count;
		//    }
		//
		//    @Override
		//    public void swap(int a, int b) {
		//      FloatHash.this.swap(a, b);
		//    }
		//  }


		/// <summary>
		/// Sort the keys alphabetically (ignoring case). Uses the value as a
		/// tie-breaker (only really possible with a key that has a case change).
		/// 
		/// @webref floatdict:method
		/// @brief Sort the keys alphabetically
		/// </summary>
		public virtual void sortKeys ()
		{
			sortImpl (true, false);
			//    new InternalSort() {
			//      @Override
			//      public float compare(int a, int b) {
			//        int result = keys[a].compareToIgnoreCase(keys[b]);
			//        if (result != 0) {
			//          return result;
			//        }
			//        return values[b] - values[a];
			//      }
			//    }.run();
		}


		/// <summary>
		/// @webref floatdict:method
		/// @brief Sort the keys alphabetially in reverse
		/// </summary>
		public virtual void sortKeysReverse ()
		{
			sortImpl (true, true);
			//    new InternalSort() {
			//      @Override
			//      public float compare(int a, int b) {
			//        int result = keys[b].compareToIgnoreCase(keys[a]);
			//        if (result != 0) {
			//          return result;
			//        }
			//        return values[a] - values[b];
			//      }
			//    }.run();
		}


		/// <summary>
		/// Sort by values in descending order (largest value will be at [0]).
		/// 
		/// @webref floatdict:method
		/// @brief Sort by values in ascending order
		/// </summary>
		public virtual void sortValues ()
		{
			sortImpl (false, false);
			//    new InternalSort() {
			//      @Override
			//      public float compare(int a, int b) {
			//
			//      }
			//    }.run();
		}


		/// <summary>
		/// @webref floatdict:method
		/// @brief Sort by values in descending order
		/// </summary>
		public virtual void sortValuesReverse ()
		{
			sortImpl (false, true);
			//    new InternalSort() {
			//      @Override
			//      public float compare(int a, int b) {
			//        float diff = values[b] - values[a];
			//        if (diff == 0 && keys[a] != null && keys[b] != null) {
			//          diff = keys[a].compareToIgnoreCase(keys[b]);
			//        }
			//        return descending ? diff : -diff;
			//      }
			//    }.run();
		}


		//  // ascending puts the largest value at the end
		//  // descending puts the largest value at 0
		//  public void sortValues(final boolean descending, final boolean tiebreaker) {
		//    Sort s = new Sort() {
		//      @Override
		//      public int size() {
		//        return count;
		//      }
		//
		//      @Override
		//      public float compare(int a, int b) {
		//        float diff = values[b] - values[a];
		//        if (tiebreaker) {
		//          if (diff == 0) {
		//            diff = keys[a].compareToIgnoreCase(keys[b]);
		//          }
		//        }
		//        return descending ? diff : -diff;
		//      }
		//
		//      @Override
		//      public void swap(int a, int b) {
		//        FloatHash.this.swap(a, b);
		//      }
		//    };
		//    s.run();
		//  }


//JAVA TO C# CONVERTER WARNING: 'final' parameters are not allowed in .NET:
//ORIGINAL LINE: protected void sortImpl(final boolean useKeys, final boolean reverse)
		protected internal virtual void sortImpl (bool useKeys, bool reverse)
		{
			Sort s = new SortAnonymousInnerClassHelper (this, useKeys, reverse);
			s.run ();
		}

		private class SortAnonymousInnerClassHelper : Sort
		{
			private readonly FloatDict outerInstance;
			private bool useKeys;
			private bool reverse;

			public SortAnonymousInnerClassHelper (FloatDict outerInstance, bool useKeys, bool reverse)
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
				float diff = 0;
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
				foreach (float value in valueArray()) {
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
		public virtual FloatDict copy ()
		{
			FloatDict outgoing = new FloatDict (count);
			Array.Copy (keys_Renamed, 0, outgoing.keys_Renamed, 0, count);
			Array.Copy (values_Renamed, 0, outgoing.values_Renamed, 0, count);
			for (int i = 0; i < count; i++) {
				outgoing.indices [keys_Renamed [i]] = i;
			}
			outgoing.count = count;
			return outgoing;
		}


		//  /**
		//   * Write tab-delimited entries out to the console.
		//   */
		//  public void print() {
		//    write(new PrintWriter(System.out));
		//  }


		/// <summary>
		/// Write tab-delimited entries out to </summary>
		/// <param name="writer"> </param>

		// TODO: rewrite with System.io.writer
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