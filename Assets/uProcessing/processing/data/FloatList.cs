using System;
using System.Collections.Generic;
using System.Text;

namespace processing.data
{
	//TODO: uncomment when PApplet available
	//using PApplet = processing.core.PApplet;


	/// <summary>
	/// Helper class for a list of floats. Lists are designed to have some of the
	/// features of ArrayLists, but to maintain the simplicity and efficiency of
	/// working with arrays.
	/// 
	/// Functions like sort() and shuffle() always act on the list itself. To get
	/// a sorted copy, use list.copy().sort().
	/// 
	/// @webref data:composite </summary>
	/// <seealso cref= IntList </seealso>
	/// <seealso cref= StringList </seealso>
	public class FloatList : System.Collections.IEnumerable
	{
		internal int count;
		internal float[] data;

		public FloatList ()
		{
			data = new float[10];
		}

		/// <summary>
		/// @nowebref
		/// </summary>
		public FloatList (int length)
		{
			data = new float[length];
		}

		/// <summary>
		/// @nowebref
		/// </summary>
		public FloatList (float[] list)
		{
			count = list.Length;
			data = new float[count];
			Array.Copy (list, 0, data, 0, count);
		}

		/// <summary>
		/// @nowebref
		/// </summary>
		public FloatList (IEnumerable<float?> iter) : this(10)
		{
			foreach (float v in iter) {
				append (v);
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
				// TODO: uncomment when PApplet
				//data = PApplet.subset (data, 0, count);
			}
		}


		/// <summary>
		/// Get the length of the list.
		/// 
		/// @webref floatlist:method
		/// @brief Get the length of the list
		/// </summary>
		public virtual int size ()
		{
			return count;
		}

		public virtual void resize (int length)
		{
			if (length > data.Length) {
				float[] temp = new float[length];
				Array.Copy (data, 0, temp, 0, count);
				data = temp;

			} else if (length > count) {
				Arrays.Fill (data, count, length, 0);
			}
			count = length;
		}


		/// <summary>
		/// Remove all entries from the list.
		/// 
		/// @webref floatlist:method
		/// @brief Remove all entries from the list
		/// </summary>
		public virtual void clear ()
		{
			count = 0;
		}


		/// <summary>
		/// Get an entry at a particular index.
		/// 
		/// @webref floatlist:method
		/// @brief Get an entry at a particular index
		/// </summary>
		public virtual float get (int index)
		{
			return data [index];
		}


		/// <summary>
		/// Set the entry at a particular index. If the index is past the length of
		/// the list, it'll expand the list to accommodate, and fill the intermediate
		/// entries with 0s.
		/// 
		/// @webref floatlist:method
		/// @brief Set the entry at a particular index
		/// </summary>
		public virtual void set (int index, float what)
		{
			if (index >= count) {
				// TODO: uncomment when PApplet
//				data = PApplet.expand (data, index + 1);
//				for (int i = count; i < index; i++) {
//					data [i] = 0;
//				}
//				count = index + 1;
			}
			data [index] = what;
		}


		/// <summary>
		/// Remove an element from the specified index.
		/// 
		/// @webref floatlist:method
		/// @brief Remove an element from the specified index
		/// </summary>
		public virtual float remove (int index)
		{
			if (index < 0 || index >= count) {
				throw new System.IndexOutOfRangeException (index.ToString());
			}
			float entry = data [index];
			//    int[] outgoing = new int[count - 1];
			//    System.arraycopy(data, 0, outgoing, 0, index);
			//    count--;
			//    System.arraycopy(data, index + 1, outgoing, 0, count - index);
			//    data = outgoing;
			// For most cases, this actually appears to be faster
			// than arraycopy() on an array copying into itself.
			for (int i = index; i < count - 1; i++) {
				data [i] = data [i + 1];
			}
			count--;
			return entry;
		}


		// Remove the first instance of a particular value,
		// and return the index at which it was found.
		public virtual int removeValue (int value)
		{
			int _index = index (value);
			if (_index != -1) {
				remove (_index);
				return _index;
			}
			return -1;
		}


		// Remove all instances of a particular value,
		// and return the number of values found and removed
		public virtual int removeValues (int value)
		{
			int ii = 0;
			if (float.IsNaN (value)) {
				for (int i = 0; i < count; i++) {
					if (!float.IsNaN (data [i])) {
						data [ii++] = data [i];
					}
				}
			} else {
				for (int i = 0; i < count; i++) {
					if (data [i] != value) {
						data [ii++] = data [i];
					}
				}
			}
			int removed = count - ii;
			count = ii;
			return removed;
		}


		/// <summary>
		/// Replace the first instance of a particular value </summary>
		public virtual bool replaceValue (float value, float newValue)
		{
			if (float.IsNaN (value)) {
				for (int i = 0; i < count; i++) {
					if (float.IsNaN (data [i])) {
						data [i] = newValue;
						return true;
					}
				}
			} else {
				int _index = index (value);
				if (_index != -1) {
					data [_index] = newValue;
					return true;
				}
			}
			return false;
		}


		/// <summary>
		/// Replace all instances of a particular value </summary>
		public virtual bool replaceValues (float value, float newValue)
		{
			bool changed = false;
			if (float.IsNaN (value)) {
				for (int i = 0; i < count; i++) {
					if (float.IsNaN (data [i])) {
						data [i] = newValue;
						changed = true;
					}
				}
			} else {
				for (int i = 0; i < count; i++) {
					if (data [i] == value) {
						data [i] = newValue;
						changed = true;
					}
				}
			}
			return changed;
		}



		/// <summary>
		/// Add a new entry to the list.
		/// 
		/// @webref floatlist:method
		/// @brief Add a new entry to the list
		/// </summary>
		public virtual void append (float value)
		{
			if (count == data.Length) {
				// TODO: uncomment when PApplet
//				data = PApplet.expand (data);
			}
			data [count++] = value;
		}

		public virtual void append (float[] values)
		{
			foreach (float v in values) {
				append (v);
			}
		}

		public virtual void append (FloatList list)
		{
			foreach (float v in list.values()) { // will concat the list...
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
		public virtual void insert (int index, int[] values)
		{
			if (index < 0) {
				throw new System.ArgumentException ("insert() index cannot be negative: it was " + index);
			}
			if (index >= data.Length) {
				throw new System.ArgumentException ("insert() index " + index + " is past the end of this list");
			}

			float[] temp = new float[count + values.Length];

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

		public virtual void insert (int index, IntList list)
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
		public virtual int index (float what)
		{
			/*
		if (indexCache != null) {
		  try {
		    return indexCache.get(what);
		  } catch (Exception e) {  // not there
		    return -1;
		  }
		}
		*/
			for (int i = 0; i < count; i++) {
				if (data [i] == what) {
					return i;
				}
			}
			return -1;
		}


		/// <summary>
		/// @webref floatlist:method
		/// @brief Check if a number is a part of the list
		/// </summary>
		public virtual bool hasValue (float value)
		{
			if (float.IsNaN (value)) {
				for (int i = 0; i < count; i++) {
					if (float.IsNaN (data [i])) {
						return true;
					}
				}
			} else {
				for (int i = 0; i < count; i++) {
					if (data [i] == value) {
						return true;
					}
				}
			}
			return false;
		}


		/// <summary>
		/// @webref floatlist:method
		/// @brief Add to a value
		/// </summary>
		public virtual void add (int index, float amount)
		{
			data [index] += amount;
		}


		/// <summary>
		/// @webref floatlist:method
		/// @brief Subtract from a value
		/// </summary>
		public virtual void sub (int index, float amount)
		{
			data [index] -= amount;
		}


		/// <summary>
		/// @webref floatlist:method
		/// @brief Multiply a value
		/// </summary>
		public virtual void mult (int index, float amount)
		{
			data [index] *= amount;
		}


		/// <summary>
		/// @webref floatlist:method
		/// @brief Divide a value
		/// </summary>
		public virtual void div (int index, float amount)
		{
			data [index] /= amount;
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
		public virtual float min ()
		{
			checkMinMax ("min");
			int index = minIndex ();
			return index == -1 ? float.NaN : data [index];
		}

		public virtual int minIndex ()
		{
			checkMinMax ("minIndex");
			float m = float.NaN;
			int mi = -1;
			for (int i = 0; i < count; i++) {
				// find one good value to start
				if (data [i] == data [i]) {
					m = data [i];
					mi = i;

					// calculate the rest
					for (int j = i + 1; j < count; j++) {
						float d = data [j];
						if (!float.IsNaN (d) && (d < m)) {
							m = data [j];
							mi = j;
						}
					}
					break;
				}
			}
			return mi;
		}


		/// <summary>
		/// @webref floatlist:method
		/// @brief Return the largest value
		/// </summary>
		public virtual float max ()
		{
			checkMinMax ("max");
			int index = maxIndex ();
			return index == -1 ? float.NaN : data [index];
		}

		public virtual int maxIndex ()
		{
			checkMinMax ("maxIndex");
			float m = float.NaN;
			int mi = -1;
			for (int i = 0; i < count; i++) {
				// find one good value to start
				if (data [i] == data [i]) {
					m = data [i];
					mi = i;

					// calculate the rest
					for (int j = i + 1; j < count; j++) {
						float d = data [j];
						if (!float.IsNaN (d) && (d > m)) {
							m = data [j];
							mi = j;
						}
					}
					break;
				}
			}
			return mi;
		}

		public virtual float sum ()
		{
			double outgoing = 0;
			for (int i = 0; i < count; i++) {
				outgoing += data [i];
			}
			return (float)outgoing;
		}


		/// <summary>
		/// Sorts the array in place.
		/// 
		/// @webref floatlist:method
		/// @brief Sorts an array, lowest to highest
		/// </summary>
		public virtual void sort ()
		{
			// TODO: Implement this
			//Arrays.sort (data, 0, count);
		}


		/// <summary>
		/// Reverse sort, orders values from highest to lowest
		/// 
		/// @webref floatlist:method
		/// @brief Reverse sort, orders values from highest to lowest
		/// </summary>
		public virtual void sortReverse ()
		{
			new SortAnonymousInnerClassHelper (this)
		.run ();
		}

		private class SortAnonymousInnerClassHelper : Sort
		{
			private readonly FloatList outerInstance;

			public SortAnonymousInnerClassHelper (FloatList outerInstance)
			{
				this.outerInstance = outerInstance;
			}

			public override int size ()
			{
				return outerInstance.count;
			}

			public override float compare (int a, int b)
			{
				return outerInstance.data [b] - outerInstance.data [a];
			}

			public override void swap (int a, int b)
			{
				float temp = outerInstance.data [a];
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


		//  public void subset(int start, int num) {
		//    for (int i = 0; i < num; i++) {
		//      data[i] = data[i+start];
		//    }
		//    count = num;
		//  }


		/// <summary>
		/// @webref floatlist:method
		/// @brief Reverse sort, orders values by first digit
		/// </summary>
		public virtual void reverse ()
		{
			int ii = count - 1;
			for (int i = 0; i < count / 2; i++) {
				float t = data [i];
				data [i] = data [ii];
				data [ii] = t;
				--ii;
			}
		}


		/// <summary>
		/// Randomize the order of the list elements. Note that this does not
		/// obey the randomSeed() function in PApplet.
		/// 
		/// @webref floatlist:method
		/// @brief Randomize the order of the list elements
		/// </summary>
		public virtual void shuffle ()
		{
			Random r = new Random ();
			int num = count;
			while (num > 1) {
				int value = r.Next (num);
				num--;
				float temp = data [num];
				data [num] = data [value];
				data [value] = temp;
			}
		}


		/// <summary>
		/// Randomize the list order using the random() function from the specified
		/// sketch, allowing shuffle() to use its current randomSeed() setting.
		/// </summary>
		/// 
		//TODO: Uncomment when PApplet available
//		public virtual void shuffle (PApplet sketch)
//		{
//			int num = count;
//			while (num > 1) {
//				int value = (int)sketch.random (num);
//				num--;
//				float temp = data [num];
//				data [num] = data [value];
//				data [value] = temp;
//			}
//		}

		public virtual FloatList copy ()
		{
			FloatList outgoing = new FloatList (data);
			outgoing.count = count;
			return outgoing;
		}


		/// <summary>
		/// Returns the actual array being used to store the data. For advanced users,
		/// this is the fastest way to access a large list. Suitable for iterating
		/// with a for() loop, but modifying the list will have terrible consequences.
		/// </summary>
		public virtual float[] values ()
		{
			crop ();
			return data;
		}


		/// <summary>
		/// Implemented this way so that we can use a FloatList in a for loop. </summary>
		public virtual System.Collections.IEnumerator GetEnumerator ()
		{
			//  }
			//
			//
			//  public Iterator<Float> valueIterator() {
			return new IteratorAnonymousInnerClassHelper (this);
		}

		private class IteratorAnonymousInnerClassHelper : System.Collections.IEnumerator
		{
			private readonly FloatList outerInstance;

			public IteratorAnonymousInnerClassHelper (FloatList outerInstance)
			{
				this.outerInstance = outerInstance;
				index = -1;
			}

			internal int index;

			public object Current {
				get {
					return outerInstance.data[index];
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

			public virtual float? next ()
			{
				return outerInstance.data [++index];
			}

			public virtual bool hasNext ()
			{
				return index + 1 < outerInstance.count;
			}
		}


		/// <summary>
		/// Create a new array with a copy of all the values. </summary>
		/// <returns> an array sized by the length of the list with each of the values.
		/// @webref floatlist:method
		/// @brief Create a new array with a copy of all the values </returns>
		public virtual float[] array ()
		{
			return array (null);
		}


		/// <summary>
		/// Copy as many values as possible into the specified array. </summary>
		/// <param name="array"> </param>
		public virtual float[] array (float[] array)
		{
			if (array == null || array.Length != count) {
				array = new float[count];
			}
			Array.Copy (data, 0, array, 0, count);
			return array;
		}


		/// <summary>
		/// Returns a normalized version of this array. Called getPercent() for
		/// consistency with the Dict classes. It's a getter method because it needs
		/// to returns a new list (because IntList/Dict can't do percentages or
		/// normalization in place on int values).
		/// </summary>
		public virtual FloatList Percent {
			get {
				double sum = 0;
				foreach (float value in array()) {
					sum += value;
				}
				FloatList outgoing = new FloatList (count);
				for (int i = 0; i < count; i++) {
					double percent = data [i] / sum;
					outgoing.set (i, (float)percent);
				}
				return outgoing;
			}
		}

		public virtual FloatList getSubset (int start)
		{
			return getSubset (start, count - start);
		}

		public virtual FloatList getSubset (int start, int num)
		{
			float[] subset = new float[num];
			Array.Copy (data, start, subset, 0, num);
			return new FloatList (subset);
		}

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

		public override string ToString ()
		{
			StringBuilder sb = new StringBuilder ();
			sb.Append (this.GetType ().Name + " size=" + size () + " [ ");
			for (int i = 0; i < size(); i++) {
				if (i != 0) {
					sb.Append (", ");
				}
				sb.Append (i + ": " + data [i]);
			}
			sb.Append (" ]");
			return sb.ToString ();
		}
	}

}