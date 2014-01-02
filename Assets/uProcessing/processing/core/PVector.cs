using System;

/* -*- mode: java; c-basic-offset: 2; indent-tabs-mode: nil -*- */

/*
  Part of the Processing project - http://processing.org

  Copyright (c) 2008 Dan Shiffman
  Copyright (c) 2008-10 Ben Fry and Casey Reas

  This library is free software; you can redistribute it and/or
  modify it under the terms of the GNU Lesser General Public
  License version 2.1 as published by the Free Software Foundation.

  This library is distributed in the hope that it will be useful,
  but WITHOUT ANY WARRANTY; without even the implied warranty of
  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
  Lesser General Public License for more details.

  You should have received a copy of the GNU Lesser General
  Public License along with this library; if not, write to the
  Free Software Foundation, Inc., 59 Temple Place, Suite 330,
  Boston, MA  02111-1307  USA
 */

namespace processing.core
{


	/// <summary>
	/// ( begin auto-generated from PVector.xml )
	/// 
	/// A class to describe a two or three dimensional vector. This datatype
	/// stores two or three variables that are commonly used as a position,
	/// velocity, and/or acceleration. Technically, <em>position</em> is a point
	/// and <em>velocity</em> and <em>acceleration</em> are vectors, but this is
	/// often simplified to consider all three as vectors. For example, if you
	/// consider a rectangle moving across the screen, at any given instant it
	/// has a position (the object's location, expressed as a point.), a
	/// velocity (the rate at which the object's position changes per time unit,
	/// expressed as a vector), and acceleration (the rate at which the object's
	/// velocity changes per time unit, expressed as a vector). Since vectors
	/// represent groupings of values, we cannot simply use traditional
	/// addition/multiplication/etc. Instead, we'll need to do some "vector"
	/// math, which is made easy by the methods inside the <b>PVector</b>
	/// class.<br />
	/// <br />
	/// The methods for this class are extensive. For a complete list, visit the
	/// <a
	/// href="http://processing.googlecode.com/svn/trunk/processing/build/javadoc/core/">developer's reference.</a>
	/// 
	/// ( end auto-generated )
	/// 
	/// A class to describe a two or three dimensional vector.
	/// <para>
	/// The result of all functions are applied to the vector itself, with the
	/// exception of cross(), which returns a new PVector (or writes to a specified
	/// 'target' PVector). That is, add() will add the contents of one vector to
	/// this one. Using add() with additional parameters allows you to put the
	/// result into a new PVector. Functions that act on multiple vectors also
	/// include static versions. Because creating new objects can be computationally
	/// expensive, most functions include an optional 'target' PVector, so that a
	/// new PVector object is not created with each operation.
	/// </para>
	/// <para>
	/// Initially based on the Vector3D class by <a href="http://www.shiffman.net">Dan Shiffman</a>.
	/// 
	/// @webref math
	/// </para>
	/// </summary>
	[Serializable]
	public class PVector
	{

		/// <summary>
		/// Generated 2010-09-14 by jdf
		/// </summary>
		private const long serialVersionUID = -6717872085945400694L;

		/// <summary>
		/// ( begin auto-generated from PVector_x.xml )
		/// 
		/// The x component of the vector. This field (variable) can be used to both
		/// get and set the value (see above example.)
		/// 
		/// ( end auto-generated )
		/// 
		/// @webref pvector:field
		/// @usage web_application
		/// @brief The x component of the vector
		/// </summary>
		public float x;

		/// <summary>
		/// ( begin auto-generated from PVector_y.xml )
		/// 
		/// The y component of the vector. This field (variable) can be used to both
		/// get and set the value (see above example.)
		/// 
		/// ( end auto-generated )
		/// 
		/// @webref pvector:field
		/// @usage web_application
		/// @brief The y component of the vector
		/// </summary>
		public float y;

		/// <summary>
		/// ( begin auto-generated from PVector_z.xml )
		/// 
		/// The z component of the vector. This field (variable) can be used to both
		/// get and set the value (see above example.)
		/// 
		/// ( end auto-generated )
		/// 
		/// @webref pvector:field
		/// @usage web_application
		/// @brief The z component of the vector
		/// </summary>
		public float z;

		/// <summary>
		/// Array so that this can be temporarily used in an array context </summary>
		[NonSerialized]
		protected internal float[]
			array_Renamed;

		/// <summary>
		/// Constructor for an empty vector: x, y, and z are set to 0.
		/// </summary>
		public PVector ()
		{
		}


		/// <summary>
		/// Constructor for a 3D vector.
		/// </summary>
		/// <param name="x"> the x coordinate. </param>
		/// <param name="y"> the y coordinate. </param>
		/// <param name="z"> the z coordinate. </param>
		public PVector (float x, float y, float z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}


		/// <summary>
		/// Constructor for a 2D vector: z coordinate is set to 0.
		/// </summary>
		public PVector (float x, float y)
		{
			this.x = x;
			this.y = y;
			this.z = 0;
		}

		/// <summary>
		/// ( begin auto-generated from PVector_set.xml )
		/// 
		/// Sets the x, y, and z component of the vector using two or three separate
		/// variables, the data from a PVector, or the values from a float array.
		/// 
		/// ( end auto-generated )
		/// 
		/// @webref pvector:method </summary>
		/// <param name="x"> the x component of the vector </param>
		/// <param name="y"> the y component of the vector </param>
		/// <param name="z"> the z component of the vector
		/// @brief Set the x, y, and z component of the vector </param>
		public virtual void set (float x, float y, float z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}

		/// 
		/// <summary>
		/// @webref pvector:method </summary>
		/// <param name="x"> the x component of the vector </param>
		/// <param name="y"> the y component of the vector
		/// @brief Set the x, y components of the vector </param>
		public virtual void set (float x, float y)
		{
			this.x = x;
			this.y = y;
		}

		/// <param name="v"> any variable of type PVector </param>
		public virtual void set (PVector v)
		{
			x = v.x;
			y = v.y;
			z = v.z;
		}


		/// <summary>
		/// Set the x, y (and maybe z) coordinates using a float[] array as the source. </summary>
		/// <param name="source"> array to copy from </param>
		public virtual void set (float[] source)
		{
			if (source.Length >= 2) {
				x = source [0];
				y = source [1];
			}
			if (source.Length >= 3) {
				z = source [2];
			}
		}


		/// <summary>
		/// ( begin auto-generated from PVector_random2D.xml )
		/// 
		/// Make a new 2D unit vector with a random direction.  If you pass in "this"
		/// as an argument, it will use the PApplet's random number generator.  You can
		/// also pass in a target PVector to fill.
		/// 
		/// @webref pvector:method
		/// @usage web_application </summary>
		/// <returns> the random PVector
		/// @brief Make a new 2D unit vector with a random direction. </returns>
		/// <seealso cref= PVector#random3D() </seealso>
		public static PVector random2D ()
		{
			//TODO: back to 2 argument when PApplet
//			return random2D (null, null);
			return random2D (null);
		}

		/// <summary>
		/// Make a new 2D unit vector with a random direction
		/// using Processing's current random number generator </summary>
		/// <param name="parent"> current PApplet instance </param>
		/// <returns> the random PVector </returns>
		// TODO: after PApplet
//		public static PVector random2D (PApplet parent)
//		{
//			return random2D (null, parent);
//		}

		/// <summary>
		/// Set a 2D vector to a random unit vector with a random direction </summary>
		/// <param name="target"> the target vector (if null, a new vector will be created) </param>
		/// <returns> the random PVector </returns>
		public static PVector random2D (PVector target)
		{
			// tODO: PApplet
			//return random2D (target, null);
			return new PVector();
		}

		/// <summary>
		/// Make a new 2D unit vector with a random direction </summary>
		/// <returns> the random PVector </returns>
		// TODO: After PApplet
//		public static PVector random2D (PVector target, PApplet parent)
//		{
//			if (parent == null) {
//				return fromAngle ((float)(new Random (1).NextDouble () * Math.PI * 2), target);
//			} else {
//				return fromAngle (parent.random (processing.core.PConstants_Fields.TWO_PI), target);
//			}
//		}

		/// <summary>
		/// ( begin auto-generated from PVector_random3D.xml )
		/// 
		/// Make a new 3D unit vector with a random direction.  If you pass in "this"
		/// as an argument, it will use the PApplet's random number generator.  You can
		/// also pass in a target PVector to fill.
		/// 
		/// @webref pvector:method
		/// @usage web_application </summary>
		/// <returns> the random PVector
		/// @brief Make a new 3D unit vector with a random direction. </returns>
		/// <seealso cref= PVector#random2D() </seealso>
		public static PVector random3D ()
		{
			//TODO: PAPplet
			//return random3D (null, null);
			return random3D (null);
		}

		/// <summary>
		/// Make a new 3D unit vector with a random direction
		/// using Processing's current random number generator </summary>
		/// <param name="parent"> current PApplet instance </param>
		/// <returns> the random PVector </returns>
		// TODO: PApplet
//		public static PVector random3D (PApplet parent)
//		{
//			return random3D (null, parent);
//		}

		/// <summary>
		/// Set a 3D vector to a random unit vector with a random direction </summary>
		/// <param name="target"> the target vector (if null, a new vector will be created) </param>
		/// <returns> the random PVector </returns>
		public static PVector random3D (PVector target)
		{
			//TODO: when PApplet
			//return random3D (target, null);
			return new PVector();
		}

		/// <summary>
		/// Make a new 3D unit vector with a random direction </summary>
		/// <returns> the random PVector </returns>
		// TODO: PApplet
//		public static PVector random3D (PVector target, PApplet parent)
//		{
//			float angle;
//			float vz;
//			if (parent == null) {
//				angle = (float)(new Random (1).NextDouble () * Math.PI * 2);
//				vz = (float)(new Random (2).NextDouble () * 2 - 1);
//			} else {
//				angle = parent.random (processing.core.PConstants_Fields.TWO_PI);
//				vz = parent.random (-1, 1);
//			}
//			float vx = (float)(Math.Sqrt (1 - vz * vz) * Math.Cos (angle));
//			float vy = (float)(Math.Sqrt (1 - vz * vz) * Math.Sin (angle));
//			if (target == null) {
//				target = new PVector (vx, vy, vz);
//				//target.normalize(); // Should be unnecessary
//			} else {
//				target.set (vx, vy, vz);
//			}
//			return target;
//		}

		/// <summary>
		/// ( begin auto-generated from PVector_sub.xml )
		/// 
		/// Make a new 2D unit vector from an angle.
		/// 
		/// ( end auto-generated )
		/// 
		/// @webref pvector:method
		/// @usage web_application
		/// @brief Make a new 2D unit vector from an angle </summary>
		/// <param name="angle"> the angle </param>
		/// <returns> the new unit PVector </returns>
		public static PVector fromAngle (float angle)
		{
			return fromAngle (angle, null);
		}


		/// <summary>
		/// Make a new 2D unit vector from an angle
		/// </summary>
		/// <param name="target"> the target vector (if null, a new vector will be created) </param>
		/// <returns> the PVector </returns>
		public static PVector fromAngle (float angle, PVector target)
		{
			if (target == null) {
				target = new PVector ((float)Math.Cos (angle), (float)Math.Sin (angle), 0);
			} else {
				target.set ((float)Math.Cos (angle), (float)Math.Sin (angle), 0);
			}
			return target;
		}

		/// <summary>
		/// ( begin auto-generated from PVector_get.xml )
		/// 
		/// Gets a copy of the vector, returns a PVector object.
		/// 
		/// ( end auto-generated )
		/// 
		/// @webref pvector:method
		/// @usage web_application
		/// @brief Get a copy of the vector
		/// </summary>
		public virtual PVector get ()
		{
			return new PVector (x, y, z);
		}

		/// <param name="target"> </param>
		public virtual float[] get (float[] target)
		{
			if (target == null) {
				return new float[] {x, y, z};
			}
			if (target.Length >= 2) {
				target [0] = x;
				target [1] = y;
			}
			if (target.Length >= 3) {
				target [2] = z;
			}
			return target;
		}


		/// <summary>
		/// ( begin auto-generated from PVector_mag.xml )
		/// 
		/// Calculates the magnitude (length) of the vector and returns the result
		/// as a float (this is simply the equation <em>sqrt(x*x + y*y + z*z)</em>.)
		/// 
		/// ( end auto-generated )
		/// 
		/// @webref pvector:method
		/// @usage web_application
		/// @brief Calculate the magnitude of the vector </summary>
		/// <returns> magnitude (length) of the vector </returns>
		/// <seealso cref= PVector#magSq() </seealso>
		public virtual float mag ()
		{
			return (float)Math.Sqrt (x * x + y * y + z * z);
		}

		/// <summary>
		/// ( begin auto-generated from PVector_mag.xml )
		/// 
		/// Calculates the squared magnitude of the vector and returns the result
		/// as a float (this is simply the equation <em>(x*x + y*y + z*z)</em>.)
		/// Faster if the real length is not required in the
		/// case of comparing vectors, etc.
		/// 
		/// ( end auto-generated )
		/// 
		/// @webref pvector:method
		/// @usage web_application
		/// @brief Calculate the magnitude of the vector, squared </summary>
		/// <returns> squared magnitude of the vector </returns>
		/// <seealso cref= PVector#mag() </seealso>
		public virtual float magSq ()
		{
			return (x * x + y * y + z * z);
		}

		/// <summary>
		/// ( begin auto-generated from PVector_add.xml )
		/// 
		/// Adds x, y, and z components to a vector, adds one vector to another, or
		/// adds two independent vectors together. The version of the method that
		/// adds two vectors together is a static method and returns a PVector, the
		/// others have no return value -- they act directly on the vector. See the
		/// examples for more context.
		/// 
		/// ( end auto-generated )
		/// 
		/// @webref pvector:method
		/// @usage web_application </summary>
		/// <param name="v"> the vector to be added
		/// @brief Adds x, y, and z components to a vector, one vector to another, or two independent vectors </param>
		public virtual void add (PVector v)
		{
			x += v.x;
			y += v.y;
			z += v.z;
		}

		/// <param name="x"> x component of the vector </param>
		/// <param name="y"> y component of the vector </param>
		/// <param name="z"> z component of the vector </param>
		public virtual void add (float x, float y, float z)
		{
			this.x += x;
			this.y += y;
			this.z += z;
		}


		/// <summary>
		/// Add two vectors </summary>
		/// <param name="v1"> a vector </param>
		/// <param name="v2"> another vector </param>
		public static PVector add (PVector v1, PVector v2)
		{
			return add (v1, v2, null);
		}


		/// <summary>
		/// Add two vectors into a target vector </summary>
		/// <param name="target"> the target vector (if null, a new vector will be created) </param>
		public static PVector add (PVector v1, PVector v2, PVector target)
		{
			if (target == null) {
				target = new PVector (v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
			} else {
				target.set (v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
			}
			return target;
		}


		/// <summary>
		/// ( begin auto-generated from PVector_sub.xml )
		/// 
		/// Subtracts x, y, and z components from a vector, subtracts one vector
		/// from another, or subtracts two independent vectors. The version of the
		/// method that subtracts two vectors is a static method and returns a
		/// PVector, the others have no return value -- they act directly on the
		/// vector. See the examples for more context.
		/// 
		/// ( end auto-generated )
		/// 
		/// @webref pvector:method
		/// @usage web_application </summary>
		/// <param name="v"> any variable of type PVector
		/// @brief Subtract x, y, and z components from a vector, one vector from another, or two independent vectors </param>
		public virtual void sub (PVector v)
		{
			x -= v.x;
			y -= v.y;
			z -= v.z;
		}

		/// <param name="x"> the x component of the vector </param>
		/// <param name="y"> the y component of the vector </param>
		/// <param name="z"> the z component of the vector </param>
		public virtual void sub (float x, float y, float z)
		{
			this.x -= x;
			this.y -= y;
			this.z -= z;
		}


		/// <summary>
		/// Subtract one vector from another </summary>
		/// <param name="v1"> the x, y, and z components of a PVector object </param>
		/// <param name="v2"> the x, y, and z components of a PVector object </param>
		public static PVector sub (PVector v1, PVector v2)
		{
			return sub (v1, v2, null);
		}

		/// <summary>
		/// Subtract one vector from another and store in another vector </summary>
		/// <param name="v1"> the x, y, and z components of a PVector object </param>
		/// <param name="v2"> the x, y, and z components of a PVector object </param>
		/// <param name="target"> PVector in which to store the result </param>
		public static PVector sub (PVector v1, PVector v2, PVector target)
		{
			if (target == null) {
				target = new PVector (v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
			} else {
				target.set (v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
			}
			return target;
		}


		/// <summary>
		/// ( begin auto-generated from PVector_mult.xml )
		/// 
		/// Multiplies a vector by a scalar or multiplies one vector by another.
		/// 
		/// ( end auto-generated )
		/// 
		/// @webref pvector:method
		/// @usage web_application
		/// @brief Multiply a vector by a scalar </summary>
		/// <param name="n"> the number to multiply with the vector </param>
		public virtual void mult (float n)
		{
			x *= n;
			y *= n;
			z *= n;
		}


		/// <param name="v"> the vector to multiply by the scalar </param>
		public static PVector mult (PVector v, float n)
		{
			return mult (v, n, null);
		}


		/// <summary>
		/// Multiply a vector by a scalar, and write the result into a target PVector. </summary>
		/// <param name="target"> PVector in which to store the result </param>
		public static PVector mult (PVector v, float n, PVector target)
		{
			if (target == null) {
				target = new PVector (v.x * n, v.y * n, v.z * n);
			} else {
				target.set (v.x * n, v.y * n, v.z * n);
			}
			return target;
		}



		/// <summary>
		/// ( begin auto-generated from PVector_div.xml )
		/// 
		/// Divides a vector by a scalar or divides one vector by another.
		/// 
		/// ( end auto-generated )
		/// 
		/// @webref pvector:method
		/// @usage web_application
		/// @brief Divide a vector by a scalar </summary>
		/// <param name="n"> the number by which to divide the vector </param>
		public virtual void div (float n)
		{
			x /= n;
			y /= n;
			z /= n;
		}


		/// <summary>
		/// Divide a vector by a scalar and return the result in a new vector. </summary>
		/// <param name="v"> the vector to divide by the scalar </param>
		/// <returns> a new vector that is v1 / n </returns>
		public static PVector div (PVector v, float n)
		{
			return div (v, n, null);
		}

		/// <summary>
		/// Divide a vector by a scalar and store the result in another vector. </summary>
		/// <param name="target"> PVector in which to store the result </param>
		public static PVector div (PVector v, float n, PVector target)
		{
			if (target == null) {
				target = new PVector (v.x / n, v.y / n, v.z / n);
			} else {
				target.set (v.x / n, v.y / n, v.z / n);
			}
			return target;
		}


		/// <summary>
		/// ( begin auto-generated from PVector_dist.xml )
		/// 
		/// Calculates the Euclidean distance between two points (considering a
		/// point as a vector object).
		/// 
		/// ( end auto-generated )
		/// 
		/// @webref pvector:method
		/// @usage web_application </summary>
		/// <param name="v"> the x, y, and z coordinates of a PVector
		/// @brief Calculate the distance between two points </param>
		public virtual float dist (PVector v)
		{
			float dx = x - v.x;
			float dy = y - v.y;
			float dz = z - v.z;
			return (float)Math.Sqrt (dx * dx + dy * dy + dz * dz);
		}


		/// <param name="v1"> any variable of type PVector </param>
		/// <param name="v2"> any variable of type PVector </param>
		/// <returns> the Euclidean distance between v1 and v2 </returns>
		public static float dist (PVector v1, PVector v2)
		{
			float dx = v1.x - v2.x;
			float dy = v1.y - v2.y;
			float dz = v1.z - v2.z;
			return (float)Math.Sqrt (dx * dx + dy * dy + dz * dz);
		}


		/// <summary>
		/// ( begin auto-generated from PVector_dot.xml )
		/// 
		/// Calculates the dot product of two vectors.
		/// 
		/// ( end auto-generated )
		/// 
		/// @webref pvector:method
		/// @usage web_application </summary>
		/// <param name="v"> any variable of type PVector </param>
		/// <returns> the dot product
		/// @brief Calculate the dot product of two vectors </returns>
		public virtual float dot (PVector v)
		{
			return x * v.x + y * v.y + z * v.z;
		}

		/// <param name="x"> x component of the vector </param>
		/// <param name="y"> y component of the vector </param>
		/// <param name="z"> z component of the vector </param>
		public virtual float dot (float x, float y, float z)
		{
			return this.x * x + this.y * y + this.z * z;
		}

		/// <param name="v1"> any variable of type PVector </param>
		/// <param name="v2"> any variable of type PVector </param>
		public static float dot (PVector v1, PVector v2)
		{
			return v1.x * v2.x + v1.y * v2.y + v1.z * v2.z;
		}


		/// <summary>
		/// ( begin auto-generated from PVector_cross.xml )
		/// 
		/// Calculates and returns a vector composed of the cross product between
		/// two vectors.
		/// 
		/// ( end auto-generated )
		/// 
		/// @webref pvector:method </summary>
		/// <param name="v"> the vector to calculate the cross product
		/// @brief Calculate and return the cross product </param>
		public virtual PVector cross (PVector v)
		{
			return cross (v, null);
		}


		/// <param name="v"> any variable of type PVector </param>
		/// <param name="target"> PVector to store the result </param>
		public virtual PVector cross (PVector v, PVector target)
		{
			float crossX = y * v.z - v.y * z;
			float crossY = z * v.x - v.z * x;
			float crossZ = x * v.y - v.x * y;

			if (target == null) {
				target = new PVector (crossX, crossY, crossZ);
			} else {
				target.set (crossX, crossY, crossZ);
			}
			return target;
		}

		/// <param name="v1"> any variable of type PVector </param>
		/// <param name="v2"> any variable of type PVector </param>
		/// <param name="target"> PVector to store the result </param>
		public static PVector cross (PVector v1, PVector v2, PVector target)
		{
			float crossX = v1.y * v2.z - v2.y * v1.z;
			float crossY = v1.z * v2.x - v2.z * v1.x;
			float crossZ = v1.x * v2.y - v2.x * v1.y;

			if (target == null) {
				target = new PVector (crossX, crossY, crossZ);
			} else {
				target.set (crossX, crossY, crossZ);
			}
			return target;
		}


		/// <summary>
		/// ( begin auto-generated from PVector_normalize.xml )
		/// 
		/// Normalize the vector to length 1 (make it a unit vector).
		/// 
		/// ( end auto-generated )
		/// 
		/// @webref pvector:method
		/// @usage web_application
		/// @brief Normalize the vector to a length of 1
		/// </summary>
		public virtual void normalize ()
		{
			float m = mag ();
			if (m != 0 && m != 1) {
				div (m);
			}
		}


		/// <param name="target"> Set to null to create a new vector </param>
		/// <returns> a new vector (if target was null), or target </returns>
		public virtual PVector normalize (PVector target)
		{
			if (target == null) {
				target = new PVector ();
			}
			float m = mag ();
			if (m > 0) {
				target.set (x / m, y / m, z / m);
			} else {
				target.set (x, y, z);
			}
			return target;
		}


		/// <summary>
		/// ( begin auto-generated from PVector_limit.xml )
		/// 
		/// Limit the magnitude of this vector to the value used for the <b>max</b> parameter.
		/// 
		/// ( end auto-generated )
		/// 
		/// @webref pvector:method
		/// @usage web_application </summary>
		/// <param name="max"> the maximum magnitude for the vector
		/// @brief Limit the magnitude of the vector </param>
		public virtual void limit (float max)
		{
			if (magSq () > max * max) {
				normalize ();
				mult (max);
			}
		}

		/// <summary>
		/// ( begin auto-generated from PVector_setMag.xml )
		/// 
		/// Set the magnitude of this vector to the value used for the <b>len</b> parameter.
		/// 
		/// ( end auto-generated )
		/// 
		/// @webref pvector:method
		/// @usage web_application </summary>
		/// <param name="len"> the new length for this vector
		/// @brief Set the magnitude of the vector </param>
		public virtual float Mag {
			set {
				normalize ();
				mult (value);
			}
		}

		/// <summary>
		/// Sets the magnitude of this vector, storing the result in another vector. </summary>
		/// <param name="target"> Set to null to create a new vector </param>
		/// <param name="len"> the new length for the new vector </param>
		/// <returns> a new vector (if target was null), or target </returns>
		public virtual PVector setMag (PVector target, float len)
		{
			target = normalize (target);
			target.mult (len);
			return target;
		}

		/// <summary>
		/// ( begin auto-generated from PVector_setMag.xml )
		/// 
		/// Calculate the angle of rotation for this vector (only 2D vectors)
		/// 
		/// ( end auto-generated )
		/// 
		/// @webref pvector:method
		/// @usage web_application </summary>
		/// <returns> the angle of rotation
		/// @brief Calculate the angle of rotation for this vector </returns>
		public virtual float heading ()
		{
			float angle = (float)Math.Atan2 (-y, x);
			return -1 * angle;
		}

		[Obsolete]
		public virtual float heading2D ()
		{
			return heading ();
		}


		/// <summary>
		/// ( begin auto-generated from PVector_rotate.xml )
		/// 
		/// Rotate the vector by an angle (only 2D vectors), magnitude remains the same
		/// 
		/// ( end auto-generated )
		/// 
		/// @webref pvector:method
		/// @usage web_application
		/// @brief Rotate the vector by an angle (2D only) </summary>
		/// <param name="theta"> the angle of rotation </param>
		public virtual void rotate (float theta)
		{
			float xTemp = x;
			// Might need to check for rounding errors like with angleBetween function?
		//TODO: PApplet
//			x = x * PApplet.cos (theta) - y * PApplet.sin (theta);
//			y = xTemp * PApplet.sin (theta) + y * PApplet.cos (theta);
		}


		/// <summary>
		/// ( begin auto-generated from PVector_rotate.xml )
		/// 
		/// Linear interpolate the vector to another vector
		/// 
		/// ( end auto-generated )
		/// 
		/// @webref pvector:method
		/// @usage web_application
		/// @brief Linear interpolate the vector to another vector </summary>
		/// <param name="v"> the vector to lerp to </param>
		/// <param name="amt">  The amount of interpolation; some value between 0.0 (old vector) and 1.0 (new vector). 0.1 is very near the new vector. 0.5 is halfway in between. </param>
		public virtual void lerp (PVector v, float amt)
		{
			//TODO: PApplet
//			x = PApplet.lerp (x, v.x, amt);
//			y = PApplet.lerp (y, v.y, amt);
//			z = PApplet.lerp (z, v.z, amt);
		}

		/// <summary>
		/// Linear interpolate between two vectors (returns a new PVector object) </summary>
		/// <param name="v1"> the vector to start from </param>
		/// <param name="v2"> the vector to lerp to </param>
		public static PVector lerp (PVector v1, PVector v2, float amt)
		{
			PVector v = v1.get ();
			v.lerp (v2, amt);
			return v;
		}

		/// <summary>
		/// Linear interpolate the vector to x,y,z values </summary>
		/// <param name="x"> the x component to lerp to </param>
		/// <param name="y"> the y component to lerp to </param>
		/// <param name="z"> the z component to lerp to </param>
		public virtual void lerp (float x, float y, float z, float amt)
		{
			//TODO: PApplet
			//			this.x = PApplet.lerp (this.x, x, amt);
//			this.y = PApplet.lerp (this.y, y, amt);
//			this.z = PApplet.lerp (this.z, z, amt);
		}

		/// <summary>
		/// ( begin auto-generated from PVector_angleBetween.xml )
		/// 
		/// Calculates and returns the angle (in radians) between two vectors.
		/// 
		/// ( end auto-generated )
		/// 
		/// @webref pvector:method
		/// @usage web_application </summary>
		/// <param name="v1"> the x, y, and z components of a PVector </param>
		/// <param name="v2"> the x, y, and z components of a PVector
		/// @brief Calculate and return the angle between two vectors </param>
		public static float angleBetween (PVector v1, PVector v2)
		{

			// We get NaN if we pass in a zero vector which can cause problems
			// Zero seems like a reasonable angle between a (0,0,0) vector and something else
			if (v1.x == 0 && v1.y == 0 && v1.z == 0) {
				return 0.0f;
			}
			if (v2.x == 0 && v2.y == 0 && v2.z == 0) {
				return 0.0f;
			}

			double dot = v1.x * v2.x + v1.y * v2.y + v1.z * v2.z;
			double v1mag = Math.Sqrt (v1.x * v1.x + v1.y * v1.y + v1.z * v1.z);
			double v2mag = Math.Sqrt (v2.x * v2.x + v2.y * v2.y + v2.z * v2.z);
			// This should be a number between -1 and 1, since it's "normalized"
			double amt = dot / (v1mag * v2mag);
			// But if it's not due to rounding error, then we need to fix it
			// http://code.google.com/p/processing/issues/detail?id=340
			// Otherwise if outside the range, acos() will return NaN
			// http://www.cppreference.com/wiki/c/math/acos
			if (amt <= -1) {
				return processing.core.PConstants_Fields.PI;
			} else if (amt >= 1) {
				// http://code.google.com/p/processing/issues/detail?id=435
				return 0;
			}
			return (float)Math.Acos (amt);
		}

		public override string ToString ()
		{
			return "[ " + x + ", " + y + ", " + z + " ]";
		}


		/// <summary>
		/// ( begin auto-generated from PVector_array.xml )
		/// 
		/// Return a representation of this vector as a float array. This is only
		/// for temporary use. If used in any other fashion, the contents should be
		/// copied by using the <b>PVector.get()</b> method to copy into your own array.
		/// 
		/// ( end auto-generated )
		/// 
		/// @webref pvector:method
		/// @usage: web_application
		/// @brief Return a representation of the vector as a float array
		/// </summary>
		public virtual float[] array ()
		{
			if (array_Renamed == null) {
				array_Renamed = new float[3];
			}
			array_Renamed [0] = x;
			array_Renamed [1] = y;
			array_Renamed [2] = z;
			return array_Renamed;
		}

		public override bool Equals (object obj)
		{
			if (!(obj is PVector)) {
				return false;
			}
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final PVector p = (PVector) obj;
			PVector p = (PVector)obj;
			return x == p.x && y == p.y && z == p.z;
		}

		public override int GetHashCode ()
		{
			int result = 1;
			//TODO: PApplet
//			result = 31 * result + float.floatToIntBits (x);
//			result = 31 * result + float.floatToIntBits (y);
//			result = 31 * result + float.floatToIntBits (z);
			return result;
		}
	}

}