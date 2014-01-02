using System;

using UnityEngine;

/* -*- mode: java; c-basic-offset: 2; indent-tabs-mode: nil -*- */

/*
  Part of the Processing project - http://processing.org

  Copyright (c) 2004-11 Ben Fry and Casey Reas
  Copyright (c) 2001-04 Massachusetts Institute of Technology

  This library is free software; you can redistribute it and/or
  modify it under the terms of the GNU Lesser General Public
  License as published by the Free Software Foundation; either
  version 2.1 of the License, or (at your option) any later version.

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
	/// Numbers shared throughout processing.core.
	/// <P>
	/// An attempt is made to keep the constants as short/non-verbose
	/// as possible. For instance, the constant is TIFF instead of
	/// FILE_TYPE_TIFF. We'll do this as long as we can get away with it.
	/// 
	/// @usage Web &amp; Application
	/// </summary>
	public interface PConstants
	{


		// renderers known to processing.core

		// platform IDs for PApplet.platform



		// max/min values for numbers

		/// <summary>
		/// Same as Float.MAX_VALUE, but included for parity with MIN_VALUE,
		/// and to avoid teaching static methods on the first day.
		/// </summary>
		/// <summary>
		/// Note that Float.MIN_VALUE is the smallest <EM>positive</EM> value
		/// for a floating point number, not actually the minimum (negative) value
		/// for a float. This constant equals 0xFF7FFFFF, the smallest (farthest
		/// negative) value a float can have before it hits NaN.
		/// </summary>
		/// <summary>
		/// Largest possible (positive) integer value </summary>
		/// <summary>
		/// Smallest possible (negative) integer value </summary>

		// shapes

		// useful goodness

		/// <summary>
		/// ( begin auto-generated from PI.xml )
		/// 
		/// PI is a mathematical constant with the value 3.14159265358979323846. It
		/// is the ratio of the circumference of a circle to its diameter. It is
		/// useful in combination with the trigonometric functions <b>sin()</b> and
		/// <b>cos()</b>.
		/// 
		/// ( end auto-generated )
		/// @webref constants </summary>
		/// <seealso cref= PConstants#TWO_PI </seealso>
		/// <seealso cref= PConstants#TAU </seealso>
		/// <seealso cref= PConstants#HALF_PI </seealso>
		/// <seealso cref= PConstants#QUARTER_PI
		///  </seealso>
		/// <summary>
		/// ( begin auto-generated from HALF_PI.xml )
		/// 
		/// HALF_PI is a mathematical constant with the value
		/// 1.57079632679489661923. It is half the ratio of the circumference of a
		/// circle to its diameter. It is useful in combination with the
		/// trigonometric functions <b>sin()</b> and <b>cos()</b>.
		/// 
		/// ( end auto-generated )
		/// @webref constants </summary>
		/// <seealso cref= PConstants#PI </seealso>
		/// <seealso cref= PConstants#TWO_PI </seealso>
		/// <seealso cref= PConstants#TAU </seealso>
		/// <seealso cref= PConstants#QUARTER_PI </seealso>
		/// <summary>
		/// ( begin auto-generated from QUARTER_PI.xml )
		/// 
		/// QUARTER_PI is a mathematical constant with the value 0.7853982. It is
		/// one quarter the ratio of the circumference of a circle to its diameter.
		/// It is useful in combination with the trigonometric functions
		/// <b>sin()</b> and <b>cos()</b>.
		/// 
		/// ( end auto-generated )
		/// @webref constants </summary>
		/// <seealso cref= PConstants#PI </seealso>
		/// <seealso cref= PConstants#TWO_PI </seealso>
		/// <seealso cref= PConstants#TAU </seealso>
		/// <seealso cref= PConstants#HALF_PI </seealso>
		/// <summary>
		/// ( begin auto-generated from TWO_PI.xml )
		/// 
		/// TWO_PI is a mathematical constant with the value 6.28318530717958647693.
		/// It is twice the ratio of the circumference of a circle to its diameter.
		/// It is useful in combination with the trigonometric functions
		/// <b>sin()</b> and <b>cos()</b>.
		/// 
		/// ( end auto-generated )
		/// @webref constants </summary>
		/// <seealso cref= PConstants#PI </seealso>
		/// <seealso cref= PConstants#TAU </seealso>
		/// <seealso cref= PConstants#HALF_PI </seealso>
		/// <seealso cref= PConstants#QUARTER_PI </seealso>
		/// <summary>
		/// ( begin auto-generated from TAU.xml )
		/// 
		/// TAU is an alias for TWO_PI, a mathematical constant with the value
		/// 6.28318530717958647693. It is twice the ratio of the circumference
		/// of a circle to its diameter. It is useful in combination with the
		/// trigonometric functions <b>sin()</b> and <b>cos()</b>.
		/// 
		/// ( end auto-generated )
		/// @webref constants </summary>
		/// <seealso cref= PConstants#PI </seealso>
		/// <seealso cref= PConstants#TWO_PI </seealso>
		/// <seealso cref= PConstants#HALF_PI </seealso>
		/// <seealso cref= PConstants#QUARTER_PI </seealso>


		// angle modes

		//static final int RADIANS = 0;
		//static final int DEGREES = 1;


		// used by split, all the standard whitespace chars
		// (also includes unicode nbsp, that little bostage)


		// for colors and/or images
		//  static final int CMYK  = 5;  // image & color (someday)


		// image file types


		// filter/convert types


		// blend mode keyword definitions
		// @see processing.core.PImage#blendColor(int,int,int)

		// for messages


		// types of transformation matrices

		// types of projection matrices


		// shapes

		// the low four bits set the variety,
		// higher bits set the specific shape type

		//  static public final int POINT_SPRITES = 52;
		//  static public final int NON_STROKED_SHAPE = 60;
		//  static public final int STROKED_SHAPE     = 61;


		// shape closing modes


		// shape drawing modes

		/// <summary>
		/// Draw mode convention to use (x, y) to (width, height) </summary>
		/// <summary>
		/// Draw mode convention to use (x1, y1) to (x2, y2) coordinates </summary>
		/// <summary>
		/// Draw mode from the center, and using the radius </summary>
		/// <summary>
		/// Draw from the center, using second pair of values as the diameter.
		/// Formerly called CENTER_DIAMETER in alpha releases.
		/// </summary>
		/// <summary>
		/// Synonym for the CENTER constant. Draw from the center,
		/// using second pair of values as the diameter.
		/// </summary>


		// arc drawing modes

		//static final int OPEN = 1;  // shared


		// vertically alignment modes for text

		/// <summary>
		/// Default vertical alignment for text placement </summary>
		/// <summary>
		/// Align text to the top </summary>
		/// <summary>
		/// Align text from the bottom, using the baseline. </summary>


		// uv texture orientation modes

		/// <summary>
		/// texture coordinates in 0..1 range </summary>
		/// <summary>
		/// texture coordinates based on image width/height </summary>


		// texture wrapping modes

		/// <summary>
		/// textures are clamped to their edges </summary>
		/// <summary>
		/// textures wrap around when uv values go outside 0..1 range </summary>


		// text placement modes

		/// <summary>
		/// textMode(MODEL) is the default, meaning that characters
		/// will be affected by transformations like any other shapes.
		/// <p/>
		/// Changed value in 0093 to not interfere with LEFT, CENTER, and RIGHT.
		/// </summary>

		/// <summary>
		/// textMode(SHAPE) draws text using the the glyph outlines of
		/// individual characters rather than as textures. If the outlines are
		/// not available, then textMode(SHAPE) will be ignored and textMode(MODEL)
		/// will be used instead. For this reason, be sure to call textMode()
		/// <EM>after</EM> calling textFont().
		/// <p/>
		/// Currently, textMode(SHAPE) is only supported by OPENGL mode.
		/// It also requires Java 1.2 or higher (OPENGL requires 1.4 anyway)
		/// </summary>


		// text alignment modes
		// are inherited from LEFT, CENTER, RIGHT

		// stroke modes


		// lighting
		//static final int POINT  = 2;  // shared with shape feature


		// key constants

		// only including the most-used of these guys
		// if people need more esoteric keys, they can learn about
		// the esoteric java KeyEvent api and of virtual keys

		// both key and keyCode will equal these values
		// for 0125, these were changed to 'char' values, because they
		// can be upgraded to ints automatically by Java, but having them
		// as ints prevented split(blah, TAB) from working

		// i.e. if ((key == CODED) && (keyCode == UP))

		// key will be CODED and keyCode will be this value

		// key will be CODED and keyCode will be this value


		// orientations (only used on Android, ignored on desktop)

		/// <summary>
		/// Screen orientation constant for portrait (the hamburger way). </summary>
		/// <summary>
		/// Screen orientation constant for landscape (the hot dog way). </summary>


		// cursor types


		// hints - hint values are positive for the alternate version,
		// negative of the same value returns to the normal/default state

		// error messages
	}

	public static class PConstants_Fields
	{
		public const int X = 0;
		public const int Y = 1;
		public const int Z = 2;
		public const string JAVA2D = "processing.core.PGraphicsJava2D";
		public const string P2D = "processing.opengl.PGraphics2D";
		public const string P3D = "processing.opengl.PGraphics3D";
		public const string OPENGL = P3D;
		public const string PDF = "processing.pdf.PGraphicsPDF";
		public const string DXF = "processing.dxf.RawDXF";
		public const int OTHER = 0;
		public const int WINDOWS = 1;
		public const int MACOSX = 2;
		public const int LINUX = 3;
		public static readonly string[] platformNames = new string[] {
			"other",
			"windows",
			"macosx",
			"linux"
		};
		public const float EPSILON = 0.0001f;
		public static readonly float MAX_FLOAT = float.MaxValue;
		public static readonly float MIN_FLOAT = -float.MaxValue;
		public static readonly int MAX_INT = int.MaxValue;
		public static readonly int MIN_INT = int.MinValue;
		public const int VERTEX = 0;
		public const int BEZIER_VERTEX = 1;
		public const int QUADRATIC_VERTEX = 2;
		public const int CURVE_VERTEX = 3;
		public const int BREAK = 4;
		[Obsolete]
		public const int
			QUAD_BEZIER_VERTEX = 2;
		public static readonly float PI = (float)Math.PI;
		public static readonly float HALF_PI = (float)(Math.PI / 2.0);
		public static readonly float THIRD_PI = (float)(Math.PI / 3.0);
		public static readonly float QUARTER_PI = (float)(Math.PI / 4.0);
		public static readonly float TWO_PI = (float)(2.0 * Math.PI);
		public static readonly float TAU = (float)(2.0 * Math.PI);
		public static readonly float DEG_TO_RAD = PI / 180.0f;
		public static readonly float RAD_TO_DEG = 180.0f / PI;
		public const string WHITESPACE = " \t\n\r\f\u00A0";
		public const int RGB = 1;
		public const int ARGB = 2;
		public const int HSB = 3;
		public const int ALPHA = 4;
		public const int TIFF = 0;
		public const int TARGA = 1;
		public const int JPEG = 2;
		public const int GIF = 3;
		public const int BLUR = 11;
		public const int GRAY = 12;
		public const int INVERT = 13;
		public const int OPAQUE = 14;
		public const int POSTERIZE = 15;
		public const int THRESHOLD = 16;
		public const int ERODE = 17;
		public const int DILATE = 18;
		public const int REPLACE = 0;
		public const int BLEND = 1 << 0;
		public const int ADD = 1 << 1;
		public const int SUBTRACT = 1 << 2;
		public const int LIGHTEST = 1 << 3;
		public const int DARKEST = 1 << 4;
		public const int DIFFERENCE = 1 << 5;
		public const int EXCLUSION = 1 << 6;
		public const int MULTIPLY = 1 << 7;
		public const int SCREEN = 1 << 8;
		public const int OVERLAY = 1 << 9;
		public const int HARD_LIGHT = 1 << 10;
		public const int SOFT_LIGHT = 1 << 11;
		public const int DODGE = 1 << 12;
		public const int BURN = 1 << 13;
		public const int CHATTER = 0;
		public const int COMPLAINT = 1;
		public const int PROBLEM = 2;
		public const int PROJECTION = 0;
		public const int MODELVIEW = 1;
		public const int CUSTOM = 0;
		public const int ORTHOGRAPHIC = 2;
		public const int PERSPECTIVE = 3;
		public const int GROUP = 0;
		public const int POINT = 2;
		public const int POINTS = 3;
		public const int LINE = 4;
		public const int LINES = 5;
		public const int LINE_STRIP = 50;
		public const int LINE_LOOP = 51;
		public const int TRIANGLE = 8;
		public const int TRIANGLES = 9;
		public const int TRIANGLE_STRIP = 10;
		public const int TRIANGLE_FAN = 11;
		public const int QUAD = 16;
		public const int QUADS = 17;
		public const int QUAD_STRIP = 18;
		public const int POLYGON = 20;
		public const int PATH = 21;
		public const int RECT = 30;
		public const int ELLIPSE = 31;
		public const int ARC = 32;
		public const int SPHERE = 40;
		public const int BOX = 41;
		public const int OPEN = 1;
		public const int CLOSE = 2;
		public const int CORNER = 0;
		public const int CORNERS = 1;
		public const int RADIUS = 2;
		public const int CENTER = 3;
		public const int DIAMETER = 3;
		public const int CHORD = 2;
		public const int PIE = 3;
		public const int BASELINE = 0;
		public const int TOP = 101;
		public const int BOTTOM = 102;
		public const int NORMAL = 1;
		public const int IMAGE = 2;
		public const int CLAMP = 0;
		public const int REPEAT = 1;
		public const int MODEL = 4;
		public const int SHAPE = 5;
		public static readonly int SQUARE = 1 << 0;
		public static readonly int ROUND = 1 << 1;
		public static readonly int PROJECT = 1 << 2;
		public static readonly int MITER = 1 << 3;
		public static readonly int BEVEL = 1 << 5;
		public const int AMBIENT = 0;
		public const int DIRECTIONAL = 1;
		public const int SPOT = 3;
		public const char BACKSPACE = (char)8;
		public const char TAB = (char)9;
		public const char ENTER = (char)10;
		public const char RETURN = (char)13;
		public const char ESC = (char)27;
		public const char DELETE = (char)127;
		public const int CODED = 0xffff;
		public static readonly int UP = (int)UnityEngine.KeyCode.UpArrow;
		public static readonly int DOWN = (int)UnityEngine.KeyCode.DownArrow;
		public static readonly int LEFT = (int)UnityEngine.KeyCode.LeftArrow;
		public static readonly int RIGHT = (int)UnityEngine.KeyCode.RightArrow;
		public static readonly int ALT = (int)UnityEngine.KeyCode.LeftAlt;
		public static readonly int CONTROL = (int)UnityEngine.KeyCode.LeftControl;
		public static readonly int SHIFT = (int)UnityEngine.KeyCode.LeftShift;
		public const int PORTRAIT = 1;
		public const int LANDSCAPE = 2;
		// TODO:
		public static readonly int ARROW = 0;//Cursor.DEFAULT_CURSOR;
		public static readonly int CROSS = 1;//Cursor.CROSSHAIR_CURSOR;
		public static readonly int HAND = 2;//Cursor.HAND_CURSOR;
		public static readonly int MOVE = 3;//Cursor.MOVE_CURSOR;
		public static readonly int TEXT = 4;//Cursor.TEXT_CURSOR;
		public static readonly int WAIT = 5;//Cursor.WAIT_CURSOR;
//	  public  Deprecated;
//	  public  Deprecated;
		public const int DISABLE_DEPTH_TEST = 2;
		public const int ENABLE_DEPTH_TEST = -2;
		public const int ENABLE_DEPTH_SORT = 3;
		public const int DISABLE_DEPTH_SORT = -3;
		public const int DISABLE_OPENGL_ERRORS = 4;
		public const int ENABLE_OPENGL_ERRORS = -4;
		public const int DISABLE_DEPTH_MASK = 5;
		public const int ENABLE_DEPTH_MASK = -5;
		public const int DISABLE_OPTIMIZED_STROKE = 6;
		public const int ENABLE_OPTIMIZED_STROKE = -6;
		public const int ENABLE_STROKE_PERSPECTIVE = 7;
		public const int DISABLE_STROKE_PERSPECTIVE = -7;
		public const int DISABLE_TEXTURE_MIPMAPS = 8;
		public const int ENABLE_TEXTURE_MIPMAPS = -8;
		public const int ENABLE_STROKE_PURE = 9;
		public const int DISABLE_STROKE_PURE = -9;
		public const int ENABLE_RETINA_PIXELS = 10;
		public const int DISABLE_RETINA_PIXELS = -10;
		public const int HINT_COUNT = 11;
		public const string ERROR_BACKGROUND_IMAGE_SIZE = "background image must be the same size as your application";
		public const string ERROR_BACKGROUND_IMAGE_FORMAT = "background images should be RGB or ARGB";
		public const string ERROR_TEXTFONT_NULL_PFONT = "A null PFont was passed to textFont()";
		public const string ERROR_PUSHMATRIX_OVERFLOW = "Too many calls to pushMatrix().";
		public const string ERROR_PUSHMATRIX_UNDERFLOW = "Too many calls to popMatrix(), and not enough to pushMatrix().";
	}

}