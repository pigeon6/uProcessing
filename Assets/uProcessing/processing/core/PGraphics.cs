using System;
using System.Collections.Generic;

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

// TODO: PGL not available
//	using PGL = processing.opengl.PGL;
//	using PShader = processing.opengl.PShader;

	  /// <summary>
	  /// ( begin auto-generated from PGraphics.xml )
	  /// 
	  /// Main graphics and rendering context, as well as the base API
	  /// implementation for processing "core". Use this class if you need to draw
	  /// into an off-screen graphics buffer. A PGraphics object can be
	  /// constructed with the <b>createGraphics()</b> function. The
	  /// <b>beginDraw()</b> and <b>endDraw()</b> methods (see above example) are
	  /// necessary to set up the buffer and to finalize it. The fields and
	  /// methods for this class are extensive. For a complete list, visit the <a
	  /// href="http://processing.googlecode.com/svn/trunk/processing/build/javadoc/core/">developer's reference.</a>
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// <h3>Advanced</h3>
	  /// Main graphics and rendering context, as well as the base API implementation.
	  /// 
	  /// <h2>Subclassing and initializing PGraphics objects</h2>
	  /// Starting in release 0149, subclasses of PGraphics are handled differently.
	  /// The constructor for subclasses takes no parameters, instead a series of
	  /// functions are called by the hosting PApplet to specify its attributes.
	  /// <ul>
	  /// <li>setParent(PApplet) - is called to specify the parent PApplet.
	  /// <li>setPrimary(boolean) - called with true if this PGraphics will be the
	  /// primary drawing surface used by the sketch, or false if not.
	  /// <li>setPath(String) - called when the renderer needs a filename or output
	  /// path, such as with the PDF or DXF renderers.
	  /// <li>setSize(int, int) - this is called last, at which point it's safe for
	  /// the renderer to complete its initialization routine.
	  /// </ul>
	  /// The functions were broken out because of the growing number of parameters
	  /// such as these that might be used by a renderer, yet with the exception of
	  /// setSize(), it's not clear which will be necessary. So while the size could
	  /// be passed in to the constructor instead of a setSize() function, a function
	  /// would still be needed that would notify the renderer that it was time to
	  /// finish its initialization. Thus, setSize() simply does both.
	  /// 
	  /// <h2>Know your rights: public vs. private methods</h2>
	  /// Methods that are protected are often subclassed by other renderers, however
	  /// they are not set 'public' because they shouldn't be part of the user-facing
	  /// public API accessible from PApplet. That is, we don't want sketches calling
	  /// textModeCheck() or vertexTexture() directly.
	  /// 
	  /// <h2>Handling warnings and exceptions</h2>
	  /// Methods that are unavailable generally show a warning, unless their lack of
	  /// availability will soon cause another exception. For instance, if a method
	  /// like getMatrix() returns null because it is unavailable, an exception will
	  /// be thrown stating that the method is unavailable, rather than waiting for
	  /// the NullPointerException that will occur when the sketch tries to use that
	  /// method. As of release 0149, warnings will only be shown once, and exceptions
	  /// have been changed to warnings where possible.
	  /// 
	  /// <h2>Using xxxxImpl() for subclassing smoothness</h2>
	  /// The xxxImpl() methods are generally renderer-specific handling for some
	  /// subset if tasks for a particular function (vague enough for you?) For
	  /// instance, imageImpl() handles drawing an image whose x/y/w/h and u/v coords
	  /// have been specified, and screen placement (independent of imageMode) has
	  /// been determined. There's no point in all renderers implementing the
	  /// <tt>if (imageMode == BLAH)</tt> placement/sizing logic, so that's handled
	  /// by PGraphics, which then calls imageImpl() once all that is figured out.
	  /// 
	  /// <h2>His brother PImage</h2>
	  /// PGraphics subclasses PImage so that it can be drawn and manipulated in a
	  /// similar fashion. As such, many methods are inherited from PGraphics,
	  /// though many are unavailable: for instance, resize() is not likely to be
	  /// implemented; the same goes for mask(), depending on the situation.
	  /// 
	  /// <h2>What's in PGraphics, what ain't</h2>
	  /// For the benefit of subclasses, as much as possible has been placed inside
	  /// PGraphics. For instance, bezier interpolation code and implementations of
	  /// the strokeCap() method (that simply sets the strokeCap variable) are
	  /// handled here. Features that will vary widely between renderers are located
	  /// inside the subclasses themselves. For instance, all matrix handling code
	  /// is per-renderer: Java 2D uses its own AffineTransform, P2D uses a PMatrix2D,
	  /// and PGraphics3D needs to keep continually update forward and reverse
	  /// transformations. A proper (future) OpenGL implementation will have all its
	  /// matrix madness handled by the card. Lighting also falls under this
	  /// category, however the base material property settings (emissive, specular,
	  /// et al.) are handled in PGraphics because they use the standard colorMode()
	  /// logic. Subclasses should override methods like emissiveFromCalc(), which
	  /// is a point where a valid color has been defined internally, and can be
	  /// applied in some manner based on the calcXxxx values.
	  /// 
	  /// <h2>What's in the PGraphics documentation, what ain't</h2>
	  /// Some things are noted here, some things are not. For public API, always
	  /// refer to the <a href="http://processing.org/reference">reference</A>
	  /// on Processing.org for proper explanations. <b>No attempt has been made to
	  /// keep the javadoc up to date or complete.</b> It's an enormous task for
	  /// which we simply do not have the time. That is, it's not something that
	  /// to be done once&mdash;it's a matter of keeping the multiple references
	  /// synchronized (to say nothing of the translation issues), while targeting
	  /// them for their separate audiences. Ouch.
	  /// 
	  /// We're working right now on synchronizing the two references, so the website reference
	  /// is generated from the javadoc comments. Yay.
	  /// 
	  /// @webref rendering
	  /// @instanceName graphics any object of the type PGraphics
	  /// @usage Web &amp; Application </summary>
	  /// <seealso cref= PApplet#createGraphics(int, int, String) </seealso>
	public class PGraphics : PImage, PConstants
	{

	  /// Canvas object that covers rendering this graphics on screen.
	// TODO: rewrite
//	  public Canvas canvas;

	  // ........................................................

	  // width and height are already inherited from PImage


	//  /// width minus one (useful for many calculations)
	//  protected int width1;
	//
	//  /// height minus one (useful for many calculations)
	//  protected int height1;

	  /// width * height (useful for many calculations)
	  public int pixelCount;

	  /// true if smoothing is enabled (read-only)
	  public bool smooth_Renamed;

	  /// the anti-aliasing level for renderers that support it
	  public int quality;

	  // ........................................................

	  /// true if defaults() has been called a first time
	  protected internal bool settingsInited;

	  /// true if defaults() has been called a first time
	  protected internal bool reapplySettings_Renamed;

	  /// set to a PGraphics object being used inside a beginRaw/endRaw() block
	  protected internal PGraphics raw;

	  // ........................................................

	  /// <summary>
	  /// path to the file being saved for this renderer (if any) </summary>
	  protected internal string path;

	  /// <summary>
	  /// true if this is the main drawing surface for a particular sketch.
	  /// This would be set to false for an offscreen buffer or if it were
	  /// created any other way than size(). When this is set, the listeners
	  /// are also added to the sketch.
	  /// </summary>
	  protected internal bool primarySurface;

	  // ........................................................

	  /// <summary>
	  /// Array of hint[] items. These are hacks to get around various
	  /// temporary workarounds inside the environment.
	  /// <p/>
	  /// Note that this array cannot be static, as a hint() may result in a
	  /// runtime change specific to a renderer. For instance, calling
	  /// hint(DISABLE_DEPTH_TEST) has to call glDisable() right away on an
	  /// instance of PGraphicsOpenGL.
	  /// <p/>
	  /// The hints[] array is allocated early on because it might
	  /// be used inside beginDraw(), allocate(), etc.
	  /// </summary>
	  protected internal bool[] hints = new bool[PConstants_Fields.HINT_COUNT];

	  // ........................................................

	  /// <summary>
	  /// Storage for renderer-specific image data. In 1.x, renderers wrote cache
	  /// data into the image object. In 2.x, the renderer has a weak-referenced
	  /// map that points at any of the images it has worked on already. When the
	  /// images go out of scope, they will be properly garbage collected.
	  /// </summary>
//	  protected internal WeakHashMap<PImage, object> cacheMap = new WeakHashMap<PImage, object>();
	
		protected internal Dictionary<PImage, WeakReference > cacheMap = new Dictionary<PImage, WeakReference >();

	  ////////////////////////////////////////////////////////////

	  // Vertex fields, moved from PConstants (after 2.0a8) because they're too
	  // general to show up in all sketches as defined variables.

	  // X, Y and Z are still stored in PConstants because of their general
	  // usefulness, and that X we'll always want to be 0, etc.

	  public const int R = 3; // actual rgb, after lighting
	  public const int G = 4; // fill stored here, transform in place
	  public const int B = 5; // TODO don't do that anymore (?)
	  public const int A = 6;

	  public const int U = 7; // texture
	  public const int V = 8;

	  public const int NX = 9; // normal
	  public const int NY = 10;
	  public const int NZ = 11;

	  public const int EDGE = 12;

	  // stroke

	  /// <summary>
	  /// stroke argb values </summary>
	  public const int SR = 13;
	  public const int SG = 14;
	  public const int SB = 15;
	  public const int SA = 16;

	  /// <summary>
	  /// stroke weight </summary>
	  public const int SW = 17;

	  // transformations (2D and 3D)

	  public const int TX = 18; // transformed xyzw
	  public const int TY = 19;
	  public const int TZ = 20;

	  public const int VX = 21; // view space coords
	  public const int VY = 22;
	  public const int VZ = 23;
	  public const int VW = 24;


	  // material properties

	  // Ambient color (usually to be kept the same as diffuse)
	  // fill(_) sets both ambient and diffuse.
	  public const int AR = 25;
	  public const int AG = 26;
	  public const int AB = 27;

	  // Diffuse is shared with fill.
	  public const int DR = 3; // TODO needs to not be shared, this is a material property
	  public const int DG = 4;
	  public const int DB = 5;
	  public const int DA = 6;

	  // specular (by default kept white)
	  public const int SPR = 28;
	  public const int SPG = 29;
	  public const int SPB = 30;

	  public const int SHINE = 31;

	  // emissive (by default kept black)
	  public const int ER = 32;
	  public const int EG = 33;
	  public const int EB = 34;

	  // has this vertex been lit yet
	  public const int BEEN_LIT = 35;

	  // has this vertex been assigned a normal yet
	  public const int HAS_NORMAL = 36;

	  public const int VERTEX_FIELD_COUNT = 37;


	  ////////////////////////////////////////////////////////////

	  // STYLE PROPERTIES

	  // Also inherits imageMode() and smooth() (among others) from PImage.

	  /// <summary>
	  /// The current colorMode </summary>
	  public int colorMode_Renamed; // = RGB;

	  /// <summary>
	  /// Max value for red (or hue) set by colorMode </summary>
	  public float colorModeX; // = 255;

	  /// <summary>
	  /// Max value for green (or saturation) set by colorMode </summary>
	  public float colorModeY; // = 255;

	  /// <summary>
	  /// Max value for blue (or value) set by colorMode </summary>
	  public float colorModeZ; // = 255;

	  /// <summary>
	  /// Max value for alpha set by colorMode </summary>
	  public float colorModeA; // = 255;

	  /// <summary>
	  /// True if colors are not in the range 0..1 </summary>
	  internal bool colorModeScale; // = true;

	  /// <summary>
	  /// True if colorMode(RGB, 255) </summary>
	  internal bool colorModeDefault; // = true;

	  // ........................................................

	  // Tint color for images

	  /// <summary>
	  /// True if tint() is enabled (read-only).
	  /// 
	  /// Using tint/tintColor seems a better option for naming than
	  /// tintEnabled/tint because the latter seems ugly, even though
	  /// g.tint as the actual color seems a little more intuitive,
	  /// it's just that g.tintEnabled is even more unintuitive.
	  /// Same goes for fill and stroke, et al.
	  /// </summary>
	  public bool tint_Renamed;

	  /// <summary>
	  /// tint that was last set (read-only) </summary>
	  public int tintColor;

	  protected internal bool tintAlpha;
	  protected internal float tintR, tintG, tintB, tintA;
	  protected internal int tintRi, tintGi, tintBi, tintAi;

	  // ........................................................

	  // Fill color

	  /// <summary>
	  /// true if fill() is enabled, (read-only) </summary>
	  public bool fill_Renamed;

	  /// <summary>
	  /// fill that was last set (read-only) </summary>
	  public int fillColor = unchecked((int)0xffFFFFFF);

	  protected internal bool fillAlpha;
	  protected internal float fillR, fillG, fillB, fillA;
	  protected internal int fillRi, fillGi, fillBi, fillAi;

	  // ........................................................

	  // Stroke color

	  /// <summary>
	  /// true if stroke() is enabled, (read-only) </summary>
	  public bool stroke_Renamed;

	  /// <summary>
	  /// stroke that was last set (read-only) </summary>
	  public int strokeColor = unchecked((int)0xff000000);

	  protected internal bool strokeAlpha;
	  protected internal float strokeR, strokeG, strokeB, strokeA;
	  protected internal int strokeRi, strokeGi, strokeBi, strokeAi;

	  // ........................................................

	  // Additional stroke properties

	  protected internal const float DEFAULT_STROKE_WEIGHT = 1;
	  protected internal static readonly int DEFAULT_STROKE_JOIN = PConstants_Fields.MITER;
	  protected internal static readonly int DEFAULT_STROKE_CAP = PConstants_Fields.ROUND;

	  /// <summary>
	  /// Last value set by strokeWeight() (read-only). This has a default
	  /// setting, rather than fighting with renderers about whether that
	  /// renderer supports thick lines.
	  /// </summary>
	  public float strokeWeight_Renamed = DEFAULT_STROKE_WEIGHT;

	  /// <summary>
	  /// Set by strokeJoin() (read-only). This has a default setting
	  /// so that strokeJoin() need not be called by defaults,
	  /// because subclasses may not implement it (i.e. PGraphicsGL)
	  /// </summary>
	  public int strokeJoin_Renamed = DEFAULT_STROKE_JOIN;

	  /// <summary>
	  /// Set by strokeCap() (read-only). This has a default setting
	  /// so that strokeCap() need not be called by defaults,
	  /// because subclasses may not implement it (i.e. PGraphicsGL)
	  /// </summary>
	  public int strokeCap_Renamed = DEFAULT_STROKE_CAP;

	  // ........................................................

	  // Shape placement properties

	  // imageMode() is inherited from PImage

	  /// <summary>
	  /// The current rect mode (read-only) </summary>
	  public int rectMode_Renamed;

	  /// <summary>
	  /// The current ellipse mode (read-only) </summary>
	  public int ellipseMode_Renamed;

	  /// <summary>
	  /// The current shape alignment mode (read-only) </summary>
	  public int shapeMode_Renamed;

	  /// <summary>
	  /// The current image alignment (read-only) </summary>
	  public int imageMode_Renamed = PConstants_Fields.CORNER;

	  // ........................................................

	  // Text and font properties

	  /// <summary>
	  /// The current text font (read-only) </summary>
		// TODO: after PFont support
//	  public PFont textFont_Renamed;

	  /// <summary>
	  /// The current text align (read-only) </summary>
	  public int textAlign_Renamed = PConstants_Fields.LEFT;

	  /// <summary>
	  /// The current vertical text alignment (read-only) </summary>
	  public int textAlignY = PConstants_Fields.BASELINE;

	  /// <summary>
	  /// The current text mode (read-only) </summary>
	  public int textMode_Renamed = PConstants_Fields.MODEL;

	  /// <summary>
	  /// The current text size (read-only) </summary>
	  public float textSize_Renamed;

	  /// <summary>
	  /// The current text leading (read-only) </summary>
	  public float textLeading_Renamed;

	  // ........................................................

	  // Material properties

	//  PMaterial material;
	//  PMaterial[] materialStack;
	//  int materialStackPointer;

	  public int ambientColor;
	  public float ambientR, ambientG, ambientB;
	  public bool setAmbient;

	  public int specularColor;
	  public float specularR, specularG, specularB;

	  public int emissiveColor;
	  public float emissiveR, emissiveG, emissiveB;

	  public float shininess_Renamed;


	  // Style stack

	  internal const int STYLE_STACK_DEPTH = 64;
	  internal PStyle[] styleStack = new PStyle[STYLE_STACK_DEPTH];
	  internal int styleStackDepth;


	  ////////////////////////////////////////////////////////////


	  /// <summary>
	  /// Last background color that was set, zero if an image </summary>
	  public int backgroundColor = unchecked((int)0xffCCCCCC);

	  protected internal bool backgroundAlpha;
	  protected internal float backgroundR, backgroundG, backgroundB, backgroundA;
	  protected internal int backgroundRi, backgroundGi, backgroundBi, backgroundAi;


	  /// <summary>
	  /// The current blending mode. </summary>
	  protected internal int blendMode_Renamed;


	  // ........................................................

	  /// <summary>
	  /// Current model-view matrix transformation of the form m[row][column],
	  /// which is a "column vector" (as opposed to "row vector") matrix.
	  /// </summary>
	//  PMatrix matrix;
	//  public float m00, m01, m02, m03;
	//  public float m10, m11, m12, m13;
	//  public float m20, m21, m22, m23;
	//  public float m30, m31, m32, m33;

	//  static final int MATRIX_STACK_DEPTH = 32;
	//  float[][] matrixStack = new float[MATRIX_STACK_DEPTH][16];
	//  float[][] matrixInvStack = new float[MATRIX_STACK_DEPTH][16];
	//  int matrixStackDepth;

	  internal const int MATRIX_STACK_DEPTH = 32;

	  // ........................................................

	  /// <summary>
	  /// Java AWT Image object associated with this renderer. For the 1.0 version
	  /// of P2D and P3D, this was be associated with their MemoryImageSource.
	  /// For PGraphicsJava2D, it will be the offscreen drawing buffer.
	  /// </summary>
		// TODO: after Image support
//	  public Image image_Renamed;

	  // ........................................................

	  // internal color for setting/calculating
	  protected internal float calcR, calcG, calcB, calcA;
	  protected internal int calcRi, calcGi, calcBi, calcAi;
	  protected internal int calcColor;
	  protected internal bool calcAlpha;

	  /// <summary>
	  /// The last RGB value converted to HSB </summary>
	  internal int cacheHsbKey;
	  /// <summary>
	  /// Result of the last conversion to HSB </summary>
	  internal float[] cacheHsbValue = new float[3];

	  // ........................................................

	  /// <summary>
	  /// Type of shape passed to beginShape(),
	  /// zero if no shape is currently being drawn.
	  /// </summary>
	  protected internal int shape_Renamed;

	  // vertices
	  public const int DEFAULT_VERTICES = 512;
//JAVA TO C# CONVERTER NOTE: The following call to the 'RectangularArrays' helper class reproduces the rectangular array initialization that is automatic in Java:
//ORIGINAL LINE: protected internal float[][] vertices = new float[DEFAULT_VERTICES][VERTEX_FIELD_COUNT];
	  protected internal float[][] vertices = RectangularArrays.ReturnRectangularFloatArray(DEFAULT_VERTICES, VERTEX_FIELD_COUNT);
	  protected internal int vertexCount; // total number of vertices

	  // ........................................................

	  protected internal bool bezierInited = false;
	  public int bezierDetail_Renamed = 20;

	  // used by both curve and bezier, so just init here
	  protected internal PMatrix3D bezierBasisMatrix = new PMatrix3D(-1, 3, -3, 1, 3, -6, 3, 0, -3, 3, 0, 0, 1, 0, 0, 0);

	  //protected PMatrix3D bezierForwardMatrix;
	  protected internal PMatrix3D bezierDrawMatrix;

	  // ........................................................

	  protected internal bool curveInited = false;
	  public int curveDetail_Renamed = 20;
	  public float curveTightness_Renamed = 0;
	  // catmull-rom basis matrix, perhaps with optional s parameter
	  protected internal PMatrix3D curveBasisMatrix;
	  protected internal PMatrix3D curveDrawMatrix;

	  protected internal PMatrix3D bezierBasisInverse;
	  protected internal PMatrix3D curveToBezierMatrix;

	  // ........................................................

	  // spline vertices

	  protected internal float[][] curveVertices;
	  protected internal int curveVertexCount;

	  // ........................................................

	  // precalculate sin/cos lookup tables [toxi]
	  // circle resolution is determined from the actual used radii
	  // passed to ellipse() method. this will automatically take any
	  // scale transformations into account too

	  // [toxi 031031]
	  // changed table's precision to 0.5 degree steps
	  // introduced new vars for more flexible code
	  protected internal static readonly float[] sinLUT;
	  protected internal static readonly float[] cosLUT;
	  protected internal const float SINCOS_PRECISION = 0.5f;
	  protected internal static readonly int SINCOS_LENGTH = (int)(360f / SINCOS_PRECISION);
	  static PGraphics()
	  {
		sinLUT = new float[SINCOS_LENGTH];
		cosLUT = new float[SINCOS_LENGTH];
		for (int i = 0; i < SINCOS_LENGTH; i++)
		{
		  sinLUT[i] = (float) Math.Sin(i * PConstants_Fields.DEG_TO_RAD * SINCOS_PRECISION);
		  cosLUT[i] = (float) Math.Cos(i * PConstants_Fields.DEG_TO_RAD * SINCOS_PRECISION);
		}
	  }

	  // ........................................................

	  /// <summary>
	  /// The current font if a Java version of it is installed </summary>
	  //protected Font textFontNative;

	  /// <summary>
	  /// Metrics for the current native Java font </summary>
	  //protected FontMetrics textFontNativeMetrics;

	//  /** Last text position, because text often mixed on lines together */
	//  protected float textX, textY, textZ;

	  /// <summary>
	  /// Internal buffer used by the text() functions
	  /// because the String object is slow
	  /// </summary>
	  protected internal char[] textBuffer = new char[8 * 1024];
	  protected internal char[] textWidthBuffer = new char[8 * 1024];

	  protected internal int textBreakCount;
	  protected internal int[] textBreakStart;
	  protected internal int[] textBreakStop;

	  // ........................................................

	  public bool edge_Renamed = true;

	  // ........................................................

	  /// normal calculated per triangle
	  protected internal const int NORMAL_MODE_AUTO = 0;
	  /// one normal manually specified per shape
	  protected internal const int NORMAL_MODE_SHAPE = 1;
	  /// normals specified for each shape vertex
	  protected internal const int NORMAL_MODE_VERTEX = 2;

	  /// Current mode for normals, one of AUTO, SHAPE, or VERTEX
	  protected internal int normalMode;

	  /// Keep track of how many calls to normal, to determine the mode.
	  //protected int normalCount;

	  protected internal bool autoNormal;

	  /// <summary>
	  /// Current normal vector. </summary>
	  public float normalX, normalY, normalZ;

	  // ........................................................

	  /// <summary>
	  /// Sets whether texture coordinates passed to
	  /// vertex() calls will be based on coordinates that are
	  /// based on the IMAGE or NORMALIZED.
	  /// </summary>
	  public int textureMode_Renamed = PConstants_Fields.IMAGE;

	  /// <summary>
	  /// Current horizontal coordinate for texture, will always
	  /// be between 0 and 1, even if using textureMode(IMAGE).
	  /// </summary>
	  public float textureU;

	  /// <summary>
	  /// Current vertical coordinate for texture, see above. </summary>
	  public float textureV;

	  /// <summary>
	  /// Current image being used as a texture </summary>
	  public PImage textureImage;

	  // ........................................................

	  // [toxi031031] new & faster sphere code w/ support flexible resolutions
	  // will be set by sphereDetail() or 1st call to sphere()
	  protected internal float[] sphereX; protected internal float[] sphereY; protected internal float[] sphereZ;

	  /// Number of U steps (aka "theta") around longitudinally spanning 2*pi
	  public int sphereDetailU = 0;
	  /// Number of V steps (aka "phi") along latitudinally top-to-bottom spanning pi
	  public int sphereDetailV = 0;


	  //////////////////////////////////////////////////////////////

	  // INTERNAL


	  /// <summary>
	  /// Constructor for the PGraphics object. Use this to ensure that
	  /// the defaults get set properly. In a subclass, use this(w, h)
	  /// as the first line of a subclass' constructor to properly set
	  /// the internal fields and defaults.
	  /// 
	  /// </summary>
	  public PGraphics()
	  {
	  }

		// TODO: PApplet 
//	  public virtual PApplet Parent
//	  {
//		  set
//		  {
//			this.parent = value;
//			quality = value.sketchQuality();
//		  }
//	  }


	  /// <summary>
	  /// Set (or unset) this as the main drawing surface. Meaning that it can
	  /// safely be set to opaque (and given a default gray background), or anything
	  /// else that goes along with that.
	  /// </summary>
	  public virtual bool Primary
	  {
		  set
		  {
			this.primarySurface = value;
    
			// base images must be opaque (for performance and general
			// headache reasons.. argh, a semi-transparent opengl surface?)
			// use createGraphics() if you want a transparent surface.
			if (primarySurface)
			{
			  format = PConstants_Fields.RGB;
			}
		  }
	  }


	  public virtual string Path
	  {
		  set
		  {
			this.path = value;
		  }
	  }


	//  public void setQuality(int samples) {  // ignore
	//    this.quality = samples;
	//  }


	  public virtual float FrameRate
	  {
		  set
		  {
		  }
	  }


	  /// <summary>
	  /// The final step in setting up a renderer, set its size of this renderer.
	  /// This was formerly handled by the constructor, but instead it's been broken
	  /// out so that setParent/setPrimary/setPath can be handled differently.
	  /// 
	  /// Important that this is ignored by preproc.pl because otherwise it will
	  /// override setSize() in PApplet/Applet/Component, which will 1) not call
	  /// super.setSize(), and 2) will cause the renderer to be resized from the
	  /// event thread (EDT), causing a nasty crash as it collides with the
	  /// animation thread.
	  /// </summary>
	  public virtual void setSize(int w, int h) // ignore
	  {
		width = w;
		height = h;
	//    width1 = width - 1;
	//    height1 = height - 1;

		allocate();
		reapplySettings();
	  }


	  /// <summary>
	  /// Allocate memory for this renderer. Generally will need to be implemented
	  /// for all renderers.
	  /// </summary>
	  protected internal virtual void allocate()
	  {
	  }


	  /// <summary>
	  /// Handle any takedown for this graphics context.
	  /// <para>
	  /// This is called when a sketch is shut down and this renderer was
	  /// specified using the size() command, or inside endRecord() and
	  /// endRaw(), in order to shut things off.
	  /// </para>
	  /// </summary>
	  public virtual void dispose() // ignore
	  {
	  }



	  //////////////////////////////////////////////////////////////

	  // IMAGE METADATA FOR THIS RENDERER

	  /// <summary>
	  /// Store data of some kind for the renderer that requires extra metadata of
	  /// some kind. Usually this is a renderer-specific representation of the
	  /// image data, for instance a BufferedImage with tint() settings applied for
	  /// PGraphicsJava2D, or resized image data and OpenGL texture indices for
	  /// PGraphicsOpenGL. </summary>
	  /// <param name="renderer"> The PGraphics renderer associated to the image </param>
	  /// <param name="storage"> The metadata required by the renderer </param>
	  public virtual void setCache(PImage image, object storage)
	  {
		cacheMap.Add(image, new WeakReference(storage) );
	  }


		/// <summary>
		/// Get cache storage data for the specified renderer. Because each renderer
		/// will cache data in different formats, it's necessary to store cache data
		/// keyed by the renderer object. Otherwise, attempting to draw the same
		/// image to both a PGraphicsJava2D and a PGraphicsOpenGL will cause errors. </summary>
		/// <param name="renderer"> The PGraphics renderer associated to the image </param>
		/// <returns> metadata stored for the specified renderer </returns>
		public virtual object getCache (PImage image)
		{
			WeakReference wr = null;
			cacheMap.TryGetValue (image, out wr);
			if(wr != null ) {
				return wr.Target;
			}
			return null;
		}


	  /// <summary>
	  /// Remove information associated with this renderer from the cache, if any. </summary>
	  /// <param name="renderer"> The PGraphics renderer whose cache data should be removed </param>
	  public virtual void removeCache(PImage image)
	  {
		cacheMap.Remove(image);
	  }



	  //////////////////////////////////////////////////////////////

	  // FRAME


	  /// <summary>
	  /// Handle grabbing the focus from the parent applet. Other renderers can
	  /// override this if handling needs to be different.
	  /// </summary>
	  public virtual void requestFocus() // ignore
	  {
			//TODO: after PApplet
//		if (parent != null)
//		{
//		  parent.requestFocusInWindow();
//		}
	  }


	  /// <summary>
	  /// Some renderers have requirements re: when they are ready to draw.
	  /// </summary>
	  public virtual bool canDraw() // ignore
	  {
		return true;
	  }


	  /// <summary>
	  /// Try to draw, or put a draw request on the queue.
	  /// </summary>
	  public virtual void requestDraw() // ignore
	  {
			// TODO: After PApplet
//		parent.handleDraw();
	  }


	  /// <summary>
	  /// ( begin auto-generated from PGraphics_beginDraw.xml )
	  /// 
	  /// Sets the default properties for a PGraphics object. It should be called
	  /// before anything is drawn into the object.
	  /// 
	  /// ( end auto-generated )
	  /// <h3>Advanced</h3>
	  /// When creating your own PGraphics, you should call this before
	  /// drawing anything.
	  /// 
	  /// @webref pgraphics:method
	  /// @brief Sets the default properties for a PGraphics object
	  /// </summary>
	  public virtual void beginDraw() // ignore
	  {
	  }


	  /// <summary>
	  /// ( begin auto-generated from PGraphics_endDraw.xml )
	  /// 
	  /// Finalizes the rendering of a PGraphics object so that it can be shown on screen.
	  /// 
	  /// ( end auto-generated )
	  /// <h3>Advanced</h3>
	  /// <p/>
	  /// When creating your own PGraphics, you should call this when
	  /// you're finished drawing.
	  /// 
	  /// @webref pgraphics:method
	  /// @brief Finalizes the rendering of a PGraphics object
	  /// </summary>
	  public virtual void endDraw() // ignore
	  {
	  }

		// TODO: Not like that
//	  public virtual PGL beginPGL()
//	  {
//		showMethodWarning("beginGL");
//		return null;
//	  }
//
//
//	  public virtual void endPGL()
//	  {
//		showMethodWarning("endGL");
//	  }


	  public virtual void flush()
	  {
		// no-op, mostly for P3D to write sorted stuff
	  }


	  protected internal virtual void checkSettings()
	  {
		if (!settingsInited)
		{
			defaultSettings();
		}
		if (reapplySettings_Renamed)
		{
			reapplySettings();
		}
	  }


	  /// <summary>
	  /// Set engine's default values. This has to be called by PApplet,
	  /// somewhere inside setup() or draw() because it talks to the
	  /// graphics buffer, meaning that for subclasses like OpenGL, there
	  /// needs to be a valid graphics context to mess with otherwise
	  /// you'll get some good crashing action.
	  /// 
	  /// This is currently called by checkSettings(), during beginDraw().
	  /// </summary>
	  protected internal virtual void defaultSettings() // ignore
	  {
	//    System.out.println("PGraphics.defaultSettings() " + width + " " + height);

		//smooth();  // 2.0a5
		if (quality > 0) // 2.0a5
		{
		  smooth();
		}
		else
		{
		  noSmooth();
		}

		colorMode(PConstants_Fields.RGB, 255);
		fill(255);
		stroke(0);

		// as of 0178, no longer relying on local versions of the variables
		// being set, because subclasses may need to take extra action.
		strokeWeight(DEFAULT_STROKE_WEIGHT);
		strokeJoin(DEFAULT_STROKE_JOIN);
		strokeCap(DEFAULT_STROKE_CAP);

		// init shape stuff
		shape_Renamed = 0;

		rectMode(PConstants_Fields.CORNER);
		ellipseMode(PConstants_Fields.DIAMETER);

		autoNormal = true;

		// no current font
			// after PFont
//		textFont_Renamed = null;
		textSize_Renamed = 12;
		textLeading_Renamed = 14;
		textAlign_Renamed = PConstants_Fields.LEFT;
		textMode_Renamed = PConstants_Fields.MODEL;

		// if this fella is associated with an applet, then clear its background.
		// if it's been created by someone else through createGraphics,
		// they have to call background() themselves, otherwise everything gets
		// a gray background (when just a transparent surface or an empty pdf
		// is what's desired).
		// this background() call is for the Java 2D and OpenGL renderers.
		if (primarySurface)
		{
		  //System.out.println("main drawing surface bg " + getClass().getName());
		  background(backgroundColor);
		}

		blendMode(PConstants_Fields.BLEND);

		settingsInited = true;
		// defaultSettings() overlaps reapplySettings(), don't do both
		//reapplySettings = false;
	  }


	  /// <summary>
	  /// Re-apply current settings. Some methods, such as textFont(), require that
	  /// their methods be called (rather than simply setting the textFont variable)
	  /// because they affect the graphics context, or they require parameters from
	  /// the context (e.g. getting native fonts for text).
	  /// 
	  /// This will only be called from an allocate(), which is only called from
	  /// size(), which is safely called from inside beginDraw(). And it cannot be
	  /// called before defaultSettings(), so we should be safe.
	  /// </summary>
	  protected internal virtual void reapplySettings()
	  {
		// This might be called by allocate... So if beginDraw() has never run,
		// we don't want to reapply here, we actually just need to let
		// defaultSettings() get called a little from inside beginDraw().
		if (!settingsInited) // if this is the initial setup, no need to reapply
		{
			return;
		}

		colorMode(colorMode_Renamed, colorModeX, colorModeY, colorModeZ);
		if (fill_Renamed)
		{
	//      PApplet.println("  fill " + PApplet.hex(fillColor));
		  fill(fillColor);
		}
		else
		{
		  noFill();
		}
		if (stroke_Renamed)
		{
		  stroke(strokeColor);

		  // The if() statements should be handled inside the functions,
		  // otherwise an actual reset/revert won't work properly.
		  //if (strokeWeight != DEFAULT_STROKE_WEIGHT) {
		  strokeWeight(strokeWeight_Renamed);
		  //}
	//      if (strokeCap != DEFAULT_STROKE_CAP) {
		  strokeCap(strokeCap_Renamed);
	//      }
	//      if (strokeJoin != DEFAULT_STROKE_JOIN) {
		  strokeJoin(strokeJoin_Renamed);
	//      }
		}
		else
		{
		  noStroke();
		}
		if (tint_Renamed)
		{
		  tint(tintColor);
		}
		else
		{
		  noTint();
		}
		if (smooth_Renamed)
		{
		  smooth();
		}
		else
		{
		  // Don't bother setting this, cuz it'll anger P3D.
		  noSmooth();
		}
			// TODO: after pFont
//		if (textFont_Renamed != null)
//		{
//	//      System.out.println("  textFont in reapply is " + textFont);
//		  // textFont() resets the leading, so save it in case it's changed
//		  float saveLeading = textLeading_Renamed;
//		  textFont(textFont_Renamed, textSize_Renamed);
//		  textLeading(saveLeading);
//		}
		textMode(textMode_Renamed);
		textAlign(textAlign_Renamed, textAlignY);
		background(backgroundColor);

		blendMode(blendMode_Renamed);

		reapplySettings_Renamed = false;
	  }

	  // inherit from PImage
	  //public void resize(int wide, int high){ }

	  //////////////////////////////////////////////////////////////

	  // HINTS

	  /// <summary>
	  /// ( begin auto-generated from hint.xml )
	  /// 
	  /// Set various hints and hacks for the renderer. This is used to handle
	  /// obscure rendering features that cannot be implemented in a consistent
	  /// manner across renderers. Many options will often graduate to standard
	  /// features instead of hints over time.
	  /// <br/> <br/>
	  /// hint(ENABLE_OPENGL_4X_SMOOTH) - Enable 4x anti-aliasing for P3D. This
	  /// can help force anti-aliasing if it has not been enabled by the user. On
	  /// some graphics cards, this can also be set by the graphics driver's
	  /// control panel, however not all cards make this available. This hint must
	  /// be called immediately after the size() command because it resets the
	  /// renderer, obliterating any settings and anything drawn (and like size(),
	  /// re-running the code that came before it again).
	  /// <br/> <br/>
	  /// hint(DISABLE_OPENGL_2X_SMOOTH) - In Processing 1.0, Processing always
	  /// enables 2x smoothing when the P3D renderer is used. This hint disables
	  /// the default 2x smoothing and returns the smoothing behavior found in
	  /// earlier releases, where smooth() and noSmooth() could be used to enable
	  /// and disable smoothing, though the quality was inferior.
	  /// <br/> <br/>
	  /// hint(ENABLE_NATIVE_FONTS) - Use the native version fonts when they are
	  /// installed, rather than the bitmapped version from a .vlw file. This is
	  /// useful with the default (or JAVA2D) renderer setting, as it will improve
	  /// font rendering speed. This is not enabled by default, because it can be
	  /// misleading while testing because the type will look great on your
	  /// machine (because you have the font installed) but lousy on others'
	  /// machines if the identical font is unavailable. This option can only be
	  /// set per-sketch, and must be called before any use of textFont().
	  /// <br/> <br/>
	  /// hint(DISABLE_DEPTH_TEST) - Disable the zbuffer, allowing you to draw on
	  /// top of everything at will. When depth testing is disabled, items will be
	  /// drawn to the screen sequentially, like a painting. This hint is most
	  /// often used to draw in 3D, then draw in 2D on top of it (for instance, to
	  /// draw GUI controls in 2D on top of a 3D interface). Starting in release
	  /// 0149, this will also clear the depth buffer. Restore the default with
	  /// hint(ENABLE_DEPTH_TEST), but note that with the depth buffer cleared,
	  /// any 3D drawing that happens later in draw() will ignore existing shapes
	  /// on the screen.
	  /// <br/> <br/>
	  /// hint(ENABLE_DEPTH_SORT) - Enable primitive z-sorting of triangles and
	  /// lines in P3D and OPENGL. This can slow performance considerably, and the
	  /// algorithm is not yet perfect. Restore the default with hint(DISABLE_DEPTH_SORT).
	  /// <br/> <br/>
	  /// hint(DISABLE_OPENGL_ERROR_REPORT) - Speeds up the P3D renderer setting
	  /// by not checking for errors while running. Undo with hint(ENABLE_OPENGL_ERROR_REPORT).
	  /// <br/> <br/>
	  /// As of release 0149, unhint() has been removed in favor of adding
	  /// additional ENABLE/DISABLE constants to reset the default behavior. This
	  /// prevents the double negatives, and also reinforces which hints can be
	  /// enabled or disabled.
	  /// 
	  /// ( end auto-generated )
	  /// @webref rendering </summary>
	  /// <param name="which"> name of the hint to be enabled or disabled </param>
	  /// <seealso cref= PGraphics </seealso>
	  /// <seealso cref= PApplet#createGraphics(int, int, String, String) </seealso>
	  /// <seealso cref= PApplet#size(int, int) </seealso>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @SuppressWarnings("deprecation") public void hint(int which)
	  public virtual void hint(int which)
	  {
			// TODO: after PFont
//		if (which == PConstants_Fields.ENABLE_NATIVE_FONTS || which == PConstants_Fields.DISABLE_NATIVE_FONTS)
//		{
//		  showWarning("hint(ENABLE_NATIVE_FONTS) no longer supported. " + "Use createFont() instead.");
//		}
//		if (which > 0)
//		{
//		  hints[which] = true;
//		}
//		else
//		{
//		  hints[-which] = false;
//		}
	  }


	  //////////////////////////////////////////////////////////////

	  // VERTEX SHAPES

	  /// <summary>
	  /// Start a new shape of type POLYGON
	  /// </summary>
	  public virtual void beginShape()
	  {
		beginShape(PConstants_Fields.POLYGON);
	  }


	  /// <summary>
	  /// ( begin auto-generated from beginShape.xml )
	  /// 
	  /// Using the <b>beginShape()</b> and <b>endShape()</b> functions allow
	  /// creating more complex forms. <b>beginShape()</b> begins recording
	  /// vertices for a shape and <b>endShape()</b> stops recording. The value of
	  /// the <b>MODE</b> parameter tells it which types of shapes to create from
	  /// the provided vertices. With no mode specified, the shape can be any
	  /// irregular polygon. The parameters available for beginShape() are POINTS,
	  /// LINES, TRIANGLES, TRIANGLE_FAN, TRIANGLE_STRIP, QUADS, and QUAD_STRIP.
	  /// After calling the <b>beginShape()</b> function, a series of
	  /// <b>vertex()</b> commands must follow. To stop drawing the shape, call
	  /// <b>endShape()</b>. The <b>vertex()</b> function with two parameters
	  /// specifies a position in 2D and the <b>vertex()</b> function with three
	  /// parameters specifies a position in 3D. Each shape will be outlined with
	  /// the current stroke color and filled with the fill color.
	  /// <br/> <br/>
	  /// Transformations such as <b>translate()</b>, <b>rotate()</b>, and
	  /// <b>scale()</b> do not work within <b>beginShape()</b>. It is also not
	  /// possible to use other shapes, such as <b>ellipse()</b> or <b>rect()</b>
	  /// within <b>beginShape()</b>.
	  /// <br/> <br/>
	  /// The P3D renderer settings allow <b>stroke()</b> and <b>fill()</b>
	  /// settings to be altered per-vertex, however the default P2D renderer does
	  /// not. Settings such as <b>strokeWeight()</b>, <b>strokeCap()</b>, and
	  /// <b>strokeJoin()</b> cannot be changed while inside a
	  /// <b>beginShape()</b>/<b>endShape()</b> block with any renderer.
	  /// 
	  /// ( end auto-generated )
	  /// @webref shape:vertex </summary>
	  /// <param name="kind"> Either POINTS, LINES, TRIANGLES, TRIANGLE_FAN, TRIANGLE_STRIP, QUADS, or QUAD_STRIP </param>
	  /// <seealso cref= PShape </seealso>
	  /// <seealso cref= PGraphics#endShape() </seealso>
	  /// <seealso cref= PGraphics#vertex(float, float, float, float, float) </seealso>
	  /// <seealso cref= PGraphics#curveVertex(float, float, float) </seealso>
	  /// <seealso cref= PGraphics#bezierVertex(float, float, float, float, float, float, float, float, float) </seealso>
	  public virtual void beginShape(int kind)
	  {
		shape_Renamed = kind;
	  }


	  /// <summary>
	  /// Sets whether the upcoming vertex is part of an edge.
	  /// Equivalent to glEdgeFlag(), for people familiar with OpenGL.
	  /// </summary>
	  public virtual void edge(bool edge)
	  {
	   this.edge_Renamed = edge;
	  }


	  /// <summary>
	  /// ( begin auto-generated from normal.xml )
	  /// 
	  /// Sets the current normal vector. This is for drawing three dimensional
	  /// shapes and surfaces and specifies a vector perpendicular to the surface
	  /// of the shape which determines how lighting affects it. Processing
	  /// attempts to automatically assign normals to shapes, but since that's
	  /// imperfect, this is a better option when you want more control. This
	  /// function is identical to glNormal3f() in OpenGL.
	  /// 
	  /// ( end auto-generated )
	  /// @webref lights_camera:lights </summary>
	  /// <param name="nx"> x direction </param>
	  /// <param name="ny"> y direction </param>
	  /// <param name="nz"> z direction </param>
	  /// <seealso cref= PGraphics#beginShape(int) </seealso>
	  /// <seealso cref= PGraphics#endShape(int) </seealso>
	  /// <seealso cref= PGraphics#lights() </seealso>
	  public virtual void normal(float nx, float ny, float nz)
	  {
		normalX = nx;
		normalY = ny;
		normalZ = nz;

		// if drawing a shape and the normal hasn't been set yet,
		// then we need to set the normals for each vertex so far
		if (shape_Renamed != 0)
		{
		  if (normalMode == NORMAL_MODE_AUTO)
		  {
			// One normal per begin/end shape
			normalMode = NORMAL_MODE_SHAPE;
		  }
		  else if (normalMode == NORMAL_MODE_SHAPE)
		  {
			// a separate normal for each vertex
			normalMode = NORMAL_MODE_VERTEX;
		  }
		}
	  }

	  /// <summary>
	  /// ( begin auto-generated from textureMode.xml )
	  /// 
	  /// Sets the coordinate space for texture mapping. There are two options,
	  /// IMAGE, which refers to the actual coordinates of the image, and
	  /// NORMAL, which refers to a normalized space of values ranging from 0
	  /// to 1. The default mode is IMAGE. In IMAGE, if an image is 100 x 200
	  /// pixels, mapping the image onto the entire size of a quad would require
	  /// the points (0,0) (0,100) (100,200) (0,200). The same mapping in
	  /// NORMAL_SPACE is (0,0) (0,1) (1,1) (0,1).
	  /// 
	  /// ( end auto-generated )
	  /// @webref image:textures </summary>
	  /// <param name="mode"> either IMAGE or NORMAL </param>
	  /// <seealso cref= PGraphics#texture(PImage) </seealso>
	  /// <seealso cref= PGraphics#textureWrap(int) </seealso>
	  public virtual void textureMode(int mode)
	  {
		if (mode != PConstants_Fields.IMAGE && mode != PConstants_Fields.NORMAL)
		{
		  throw new Exception("textureMode() only supports IMAGE and NORMAL");
		}
		this.textureMode_Renamed = mode;
	  }

	  /// <summary>
	  /// ( begin auto-generated from textureWrap.xml )
	  /// 
	  /// Description to come...
	  /// 
	  /// ( end auto-generated from textureWrap.xml )
	  /// 
	  /// @webref image:textures </summary>
	  /// <param name="wrap"> Either CLAMP (default) or REPEAT </param>
	  /// <seealso cref= PGraphics#texture(PImage) </seealso>
	  /// <seealso cref= PGraphics#textureMode(int) </seealso>
	  public virtual void textureWrap(int wrap)
	  {
		showMissingWarning("textureWrap");
	  }


	  /// <summary>
	  /// ( begin auto-generated from texture.xml )
	  /// 
	  /// Sets a texture to be applied to vertex points. The <b>texture()</b>
	  /// function must be called between <b>beginShape()</b> and
	  /// <b>endShape()</b> and before any calls to <b>vertex()</b>.
	  /// <br/> <br/>
	  /// When textures are in use, the fill color is ignored. Instead, use tint()
	  /// to specify the color of the texture as it is applied to the shape.
	  /// 
	  /// ( end auto-generated )
	  /// @webref image:textures </summary>
	  /// <param name="image"> reference to a PImage object </param>
	  /// <seealso cref= PGraphics#textureMode(int) </seealso>
	  /// <seealso cref= PGraphics#textureWrap(int) </seealso>
	  /// <seealso cref= PGraphics#beginShape(int) </seealso>
	  /// <seealso cref= PGraphics#endShape(int) </seealso>
	  /// <seealso cref= PGraphics#vertex(float, float, float, float, float) </seealso>
	  public virtual void texture(PImage image)
	  {
		textureImage = image;
	  }


	  /// <summary>
	  /// Removes texture image for current shape.
	  /// Needs to be called between beginShape and endShape
	  /// 
	  /// </summary>
	  public virtual void noTexture()
	  {
		textureImage = null;
	  }


	  protected internal virtual void vertexCheck()
	  {
		if (vertexCount == vertices.Length)
		{
//JAVA TO C# CONVERTER NOTE: The following call to the 'RectangularArrays' helper class reproduces the rectangular array initialization that is automatic in Java:
//ORIGINAL LINE: float[][] temp = new float[vertexCount << 1][VERTEX_FIELD_COUNT];
		  float[][] temp = RectangularArrays.ReturnRectangularFloatArray(vertexCount << 1, VERTEX_FIELD_COUNT);
		  Array.Copy(vertices, 0, temp, 0, vertexCount);
		  vertices = temp;
		}
	  }


	  public virtual void vertex(float x, float y)
	  {
		vertexCheck();
		float[] vertex = vertices[vertexCount];

		curveVertexCount = 0;

		vertex[PConstants_Fields.X] = x;
		vertex[PConstants_Fields.Y] = y;
		vertex[PConstants_Fields.Z] = 0;

		vertex[EDGE] = edge_Renamed ? 1 : 0;

	//    if (fill) {
	//      vertex[R] = fillR;
	//      vertex[G] = fillG;
	//      vertex[B] = fillB;
	//      vertex[A] = fillA;
	//    }
		bool textured = textureImage != null;
		if (fill_Renamed || textured)
		{
		  if (!textured)
		  {
			vertex[R] = fillR;
			vertex[G] = fillG;
			vertex[B] = fillB;
			vertex[A] = fillA;
		  }
		  else
		  {
			if (tint_Renamed)
			{
			  vertex[R] = tintR;
			  vertex[G] = tintG;
			  vertex[B] = tintB;
			  vertex[A] = tintA;
			}
			else
			{
			  vertex[R] = 1;
			  vertex[G] = 1;
			  vertex[B] = 1;
			  vertex[A] = 1;
			}
		  }
		}

		if (stroke_Renamed)
		{
		  vertex[SR] = strokeR;
		  vertex[SG] = strokeG;
		  vertex[SB] = strokeB;
		  vertex[SA] = strokeA;
		  vertex[SW] = strokeWeight_Renamed;
		}

		if (textured)
		{
		  vertex[U] = textureU;
		  vertex[V] = textureV;
		}

		if (autoNormal)
		{
		  float norm2 = normalX * normalX + normalY * normalY + normalZ * normalZ;
		  if (norm2 < PConstants_Fields.EPSILON)
		  {
			vertex[HAS_NORMAL] = 0;
		  }
		  else
		  {
			if (Math.Abs(norm2 - 1) > PConstants_Fields.EPSILON)
			{
						// TODO: After PApplet
//			  // The normal vector is not normalized.
//			  float norm = PApplet.sqrt(norm2);
//			  normalX /= norm;
//			  normalY /= norm;
//			  normalZ /= norm;
			}
			vertex[HAS_NORMAL] = 1;
		  }
		}
		else
		{
		  vertex[HAS_NORMAL] = 1;
		}

		vertexCount++;
	  }


	  public virtual void vertex(float x, float y, float z)
	  {
		vertexCheck();
		float[] vertex = vertices[vertexCount];

		// only do this if we're using an irregular (POLYGON) shape that
		// will go through the triangulator. otherwise it'll do thinks like
		// disappear in mathematically odd ways
		// http://dev.processing.org/bugs/show_bug.cgi?id=444
		if (shape_Renamed == PConstants_Fields.POLYGON)
		{
		  if (vertexCount > 0)
		  {
			float[] pvertex = vertices[vertexCount - 1];
			if ((Math.Abs(pvertex[PConstants_Fields.X] - x) < PConstants_Fields.EPSILON) && (Math.Abs(pvertex[PConstants_Fields.Y] - y) < PConstants_Fields.EPSILON) && (Math.Abs(pvertex[PConstants_Fields.Z] - z) < PConstants_Fields.EPSILON))
			{
			  // this vertex is identical, don't add it,
			  // because it will anger the triangulator
			  return;
			}
		  }
		}

		// User called vertex(), so that invalidates anything queued up for curve
		// vertices. If this is internally called by curveVertexSegment,
		// then curveVertexCount will be saved and restored.
		curveVertexCount = 0;

		vertex[PConstants_Fields.X] = x;
		vertex[PConstants_Fields.Y] = y;
		vertex[PConstants_Fields.Z] = z;

		vertex[EDGE] = edge_Renamed ? 1 : 0;

		bool textured = textureImage != null;
		if (fill_Renamed || textured)
		{
		  if (!textured)
		  {
			vertex[R] = fillR;
			vertex[G] = fillG;
			vertex[B] = fillB;
			vertex[A] = fillA;
		  }
		  else
		  {
			if (tint_Renamed)
			{
			  vertex[R] = tintR;
			  vertex[G] = tintG;
			  vertex[B] = tintB;
			  vertex[A] = tintA;
			}
			else
			{
			  vertex[R] = 1;
			  vertex[G] = 1;
			  vertex[B] = 1;
			  vertex[A] = 1;
			}
		  }

		  vertex[AR] = ambientR;
		  vertex[AG] = ambientG;
		  vertex[AB] = ambientB;

		  vertex[SPR] = specularR;
		  vertex[SPG] = specularG;
		  vertex[SPB] = specularB;
		  //vertex[SPA] = specularA;

		  vertex[SHINE] = shininess_Renamed;

		  vertex[ER] = emissiveR;
		  vertex[EG] = emissiveG;
		  vertex[EB] = emissiveB;
		}

		if (stroke_Renamed)
		{
		  vertex[SR] = strokeR;
		  vertex[SG] = strokeG;
		  vertex[SB] = strokeB;
		  vertex[SA] = strokeA;
		  vertex[SW] = strokeWeight_Renamed;
		}

		if (textured)
		{
		  vertex[U] = textureU;
		  vertex[V] = textureV;
		}

		if (autoNormal)
		{
		  float norm2 = normalX * normalX + normalY * normalY + normalZ * normalZ;
		  if (norm2 < PConstants_Fields.EPSILON)
		  {
			vertex[HAS_NORMAL] = 0;
		  }
		  else
		  {
			if (Math.Abs(norm2 - 1) > PConstants_Fields.EPSILON)
			{
			  // The normal vector is not normalized.
						// TODO: after PApplet
//			  float norm = PApplet.sqrt(norm2);
//			  normalX /= norm;
//			  normalY /= norm;
//			  normalZ /= norm;
			}
			vertex[HAS_NORMAL] = 1;
		  }
		}
		else
		{
		  vertex[HAS_NORMAL] = 1;
		}

		vertex[NX] = normalX;
		vertex[NY] = normalY;
		vertex[NZ] = normalZ;

		vertex[BEEN_LIT] = 0;

		vertexCount++;
	  }

	  /// <summary>
	  /// Used by renderer subclasses or PShape to efficiently pass in already
	  /// formatted vertex information. </summary>
	  /// <param name="v"> vertex parameters, as a float array of length VERTEX_FIELD_COUNT </param>
	  public virtual void vertex(float[] v)
	  {
		vertexCheck();
		curveVertexCount = 0;
		float[] vertex = vertices[vertexCount];
		Array.Copy(v, 0, vertex, 0, VERTEX_FIELD_COUNT);
		vertexCount++;
	  }


	  public virtual void vertex(float x, float y, float u, float v)
	  {
		vertexTexture(u, v);
		vertex(x, y);
	  }

	/// <summary>
	/// ( begin auto-generated from vertex.xml )
	///   
	/// All shapes are constructed by connecting a series of vertices.
	/// <b>vertex()</b> is used to specify the vertex coordinates for points,
	/// lines, triangles, quads, and polygons and is used exclusively within the
	/// <b>beginShape()</b> and <b>endShape()</b> function.<br />
	/// <br />
	/// Drawing a vertex in 3D using the <b>z</b> parameter requires the P3D
	/// parameter in combination with size as shown in the above example.<br />
	/// <br />
	/// This function is also used to map a texture onto the geometry. The
	/// <b>texture()</b> function declares the texture to apply to the geometry
	/// and the <b>u</b> and <b>v</b> coordinates set define the mapping of this
	/// texture to the form. By default, the coordinates used for <b>u</b> and
	/// <b>v</b> are specified in relation to the image's size in pixels, but
	/// this relation can be changed with <b>textureMode()</b>.
	///   
	/// ( end auto-generated )
	/// @webref shape:vertex </summary>
	/// <param name="x"> x-coordinate of the vertex </param>
	/// <param name="y"> y-coordinate of the vertex </param>
	/// <param name="z"> z-coordinate of the vertex </param>
	/// <param name="u"> horizontal coordinate for the texture mapping </param>
	/// <param name="v"> vertical coordinate for the texture mapping </param>
	/// <seealso cref= PGraphics#beginShape(int) </seealso>
	/// <seealso cref= PGraphics#endShape(int) </seealso>
	/// <seealso cref= PGraphics#bezierVertex(float, float, float, float, float, float, float, float, float) </seealso>
	/// <seealso cref= PGraphics#quadraticVertex(float, float, float, float, float, float) </seealso>
	/// <seealso cref= PGraphics#curveVertex(float, float, float) </seealso>
	/// <seealso cref= PGraphics#texture(PImage) </seealso>
	  public virtual void vertex(float x, float y, float z, float u, float v)
	  {
		vertexTexture(u, v);
		vertex(x, y, z);
	  }


	  /// <summary>
	  /// Internal method to copy all style information for the given vertex.
	  /// Can be overridden by subclasses to handle only properties pertinent to
	  /// that renderer. (e.g. no need to copy the emissive color in P2D)
	  /// </summary>
	//  protected void vertexStyle() {
	//  }


	  /// <summary>
	  /// Set (U, V) coords for the next vertex in the current shape.
	  /// This is ugly as its own function, and will (almost?) always be
	  /// coincident with a call to vertex. As of beta, this was moved to
	  /// the protected method you see here, and called from an optional
	  /// param of and overloaded vertex().
	  /// <p/>
	  /// The parameters depend on the current textureMode. When using
	  /// textureMode(IMAGE), the coordinates will be relative to the size
	  /// of the image texture, when used with textureMode(NORMAL),
	  /// they'll be in the range 0..1.
	  /// <p/>
	  /// Used by both PGraphics2D (for images) and PGraphics3D.
	  /// </summary>
	  protected internal virtual void vertexTexture(float u, float v)
	  {
		if (textureImage == null)
		{
		  throw new Exception("You must first call texture() before " + "using u and v coordinates with vertex()");
		}
		if (textureMode_Renamed == PConstants_Fields.IMAGE)
		{
		  u /= textureImage.width;
		  v /= textureImage.height;
		}

		textureU = u;
		textureV = v;

		if (textureU < 0)
		{
			textureU = 0;
		}
		else if (textureU > 1)
		{
			textureU = 1;
		}

		if (textureV < 0)
		{
			textureV = 0;
		}
		else if (textureV > 1)
		{
			textureV = 1;
		}
	  }


	//  /** This feature is in testing, do not use or rely upon its implementation */
	//  public void breakShape() {
	//    showWarning("This renderer cannot currently handle concave shapes, " +
	//                "or shapes with holes.");
	//  }

	  /// <summary>
	  /// @webref shape:vertex
	  /// </summary>
	  public virtual void beginContour()
	  {
		showMissingWarning("beginContour");
	  }

	  /// <summary>
	  /// @webref shape:vertex
	  /// </summary>
	  public virtual void endContour()
	  {
		showMissingWarning("endContour");
	  }


	  public virtual void endShape()
	  {
		endShape(PConstants_Fields.OPEN);
	  }

	  /// <summary>
	  /// ( begin auto-generated from endShape.xml )
	  /// 
	  /// The <b>endShape()</b> function is the companion to <b>beginShape()</b>
	  /// and may only be called after <b>beginShape()</b>. When <b>endshape()</b>
	  /// is called, all of image data defined since the previous call to
	  /// <b>beginShape()</b> is written into the image buffer. The constant CLOSE
	  /// as the value for the MODE parameter to close the shape (to connect the
	  /// beginning and the end).
	  /// 
	  /// ( end auto-generated )
	  /// @webref shape:vertex </summary>
	  /// <param name="mode"> use CLOSE to close the shape </param>
	  /// <seealso cref= PShape </seealso>
	  /// <seealso cref= PGraphics#beginShape(int) </seealso>
	  public virtual void endShape(int mode)
	  {
	  }



	  //////////////////////////////////////////////////////////////

	  // SHAPE I/O

	  /// <summary>
	  /// @webref shape </summary>
	  /// <param name="filename"> name of file to load, can be .svg or .obj </param>
	  /// <seealso cref= PShape </seealso>
	  /// <seealso cref= PApplet#createShape() </seealso>
	  public virtual PShape loadShape(string filename)
	  {
		return loadShape(filename, null);
	  }


	  public virtual PShape loadShape(string filename, string options)
	  {
		showMissingWarning("loadShape");
		return null;
	  }



	  //////////////////////////////////////////////////////////////

	  // SHAPE CREATION

	  /// <summary>
	  /// @webref shape </summary>
	  /// <seealso cref= PShape </seealso>
	  /// <seealso cref= PShape#endShape() </seealso>
	  /// <seealso cref= PApplet#loadShape(String) </seealso>
	  public virtual PShape createShape()
	  {
		showMissingWarning("createShape");
		return null;
	  }


	  public virtual PShape createShape(PShape source)
	  {
		showMissingWarning("createShape");
		return null;
	  }


	  /// <param name="type"> either POINTS, LINES, TRIANGLES, TRIANGLE_FAN, TRIANGLE_STRIP, QUADS, QUAD_STRIP </param>
	  public virtual PShape createShape(int type)
	  {
		showMissingWarning("createShape");
		return null;
	  }


	  /// <param name="kind"> either LINE, TRIANGLE, RECT, ELLIPSE, ARC, SPHERE, BOX </param>
	  /// <param name="p"> parameters that match the kind of shape </param>
	  public virtual PShape createShape(int kind, params float[] p)
	  {
		showMissingWarning("createShape");
		return null;
	  }


	  //////////////////////////////////////////////////////////////

	  // SHADERS

	  /// <summary>
	  /// ( begin auto-generated from loadShader.xml )
	  /// 
	  /// This is a new reference entry for Processing 2.0. It will be updated shortly.
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref rendering:shaders </summary>
	  /// <param name="fragFilename"> name of fragment shader file </param>
		/// 
	
		// TODO: Shader is not like this
//	  public virtual PShader loadShader(string fragFilename)
//	  {
//		showMissingWarning("loadShader");
//		return null;
//	  }
//
//
//	  /// <param name="vertFilename"> name of vertex shader file </param>
//	  public virtual PShader loadShader(string fragFilename, string vertFilename)
//	  {
//		showMissingWarning("loadShader");
//		return null;
//	  }


	  /// <summary>
	  /// ( begin auto-generated from shader.xml )
	  /// 
	  /// This is a new reference entry for Processing 2.0. It will be updated shortly.
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref rendering:shaders </summary>
	  /// <param name="shader"> name of shader file </param>
		/// 

		// TODO: not like that
//	  public virtual void shader(PShader shader)
//	  {
//		showMissingWarning("shader");
//	  }
//
//	  /// <param name="kind"> type of shader, either POINTS, LINES, or TRIANGLES </param>
//	  public virtual void shader(PShader shader, int kind)
//	  {
//		showMissingWarning("shader");
//	  }


	  /// <summary>
	  /// ( begin auto-generated from resetShader.xml )
	  /// 
	  /// This is a new reference entry for Processing 2.0. It will be updated shortly.
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref rendering:shaders
	  /// </summary>
	  public virtual void resetShader()
	  {
		showMissingWarning("resetShader");
	  }


	  /// <param name="kind"> type of shader, either POINTS, LINES, or TRIANGLES </param>
	  public virtual void resetShader(int kind)
	  {
		showMissingWarning("resetShader");
	  }

		// TODO: not like that
	  /// <param name="shader"> the fragment shader to apply </param>
//	  public virtual void filter(PShader shader)
//	  {
//		showMissingWarning("filter");
//	  }



	  //////////////////////////////////////////////////////////////

	  // CLIPPING

	  /*
	   * @webref rendering:shaders
	   * @param a x-coordinate of the rectangle by default
	   * @param b y-coordinate of the rectangle by default
	   * @param c width of the rectangle by default
	   * @param d height of the rectangle by default
	   */
	  public virtual void clip(float a, float b, float c, float d)
	  {
		if (imageMode_Renamed == PConstants_Fields.CORNER)
		{
		  if (c < 0) // reset a negative width
		  {
			a += c;
			c = -c;
		  }
		  if (d < 0) // reset a negative height
		  {
			b += d;
			d = -d;
		  }

		  clipImpl(a, b, a + c, b + d);

		}
		else if (imageMode_Renamed == PConstants_Fields.CORNERS)
		{
		  if (c < a) // reverse because x2 < x1
		  {
			float temp = a;
			a = c;
			c = temp;
		  }
		  if (d < b) // reverse because y2 < y1
		  {
			float temp = b;
			b = d;
			d = temp;
		  }

		  clipImpl(a, b, c, d);

		}
		else if (imageMode_Renamed == PConstants_Fields.CENTER)
		{
		  // c and d are width/height
		  if (c < 0)
		  {
			  c = -c;
		  }
		  if (d < 0)
		  {
			  d = -d;
		  }
		  float x1 = a - c / 2;
		  float y1 = b - d / 2;

		  clipImpl(x1, y1, x1 + c, y1 + d);
		}
	  }


	  protected internal virtual void clipImpl(float x1, float y1, float x2, float y2)
	  {
		showMissingWarning("clip");
	  }

	  /*
	   * @webref rendering:shaders
	   */
	  public virtual void noClip()
	  {
		showMissingWarning("noClip");
	  }



	  //////////////////////////////////////////////////////////////

	  // BLEND

	  /// <summary>
	  /// ( begin auto-generated from blendMode.xml )
	  /// 
	  /// This is a new reference entry for Processing 2.0. It will be updated shortly.
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref Rendering </summary>
	  /// <param name="mode"> the blending mode to use </param>
	  public virtual void blendMode(int mode)
	  {
		this.blendMode_Renamed = mode;
		blendModeImpl();
	  }


	  protected internal virtual void blendModeImpl()
	  {
		if (blendMode_Renamed != PConstants_Fields.BLEND)
		{
		  showMissingWarning("blendMode");
		}
	  }



	  //////////////////////////////////////////////////////////////

	  // CURVE/BEZIER VERTEX HANDLING


	  protected internal virtual void bezierVertexCheck()
	  {
		bezierVertexCheck(shape_Renamed, vertexCount);
	  }


	  protected internal virtual void bezierVertexCheck(int shape, int vertexCount)
	  {
		if (shape == 0 || shape != PConstants_Fields.POLYGON)
		{
		  throw new Exception("beginShape() or beginShape(POLYGON) " + "must be used before bezierVertex() or quadraticVertex()");
		}
		if (vertexCount == 0)
		{
		  throw new Exception("vertex() must be used at least once" + "before bezierVertex() or quadraticVertex()");
		}
	  }


	  public virtual void bezierVertex(float x2, float y2, float x3, float y3, float x4, float y4)
	  {
		bezierInitCheck();
		bezierVertexCheck();
		PMatrix3D draw = bezierDrawMatrix;

		float[] prev = vertices[vertexCount - 1];
		float x1 = prev[PConstants_Fields.X];
		float y1 = prev[PConstants_Fields.Y];

		float xplot1 = draw.m10 * x1 + draw.m11 * x2 + draw.m12 * x3 + draw.m13 * x4;
		float xplot2 = draw.m20 * x1 + draw.m21 * x2 + draw.m22 * x3 + draw.m23 * x4;
		float xplot3 = draw.m30 * x1 + draw.m31 * x2 + draw.m32 * x3 + draw.m33 * x4;

		float yplot1 = draw.m10 * y1 + draw.m11 * y2 + draw.m12 * y3 + draw.m13 * y4;
		float yplot2 = draw.m20 * y1 + draw.m21 * y2 + draw.m22 * y3 + draw.m23 * y4;
		float yplot3 = draw.m30 * y1 + draw.m31 * y2 + draw.m32 * y3 + draw.m33 * y4;

		for (int j = 0; j < bezierDetail_Renamed; j++)
		{
		  x1 += xplot1;
		  xplot1 += xplot2;
		  xplot2 += xplot3;
		  y1 += yplot1;
		  yplot1 += yplot2;
		  yplot2 += yplot3;
		  vertex(x1, y1);
		}
	  }

	/// <summary>
	/// ( begin auto-generated from bezierVertex.xml )
	///   
	/// Specifies vertex coordinates for Bezier curves. Each call to
	/// <b>bezierVertex()</b> defines the position of two control points and one
	/// anchor point of a Bezier curve, adding a new segment to a line or shape.
	/// The first time <b>bezierVertex()</b> is used within a
	/// <b>beginShape()</b> call, it must be prefaced with a call to
	/// <b>vertex()</b> to set the first anchor point. This function must be
	/// used between <b>beginShape()</b> and <b>endShape()</b> and only when
	/// there is no MODE parameter specified to <b>beginShape()</b>. Using the
	/// 3D version requires rendering with P3D (see the Environment reference
	/// for more information).
	///   
	/// ( end auto-generated )
	/// @webref shape:vertex </summary>
	/// <param name="x2"> the x-coordinate of the 1st control point </param>
	/// <param name="y2"> the y-coordinate of the 1st control point </param>
	/// <param name="z2"> the z-coordinate of the 1st control point </param>
	/// <param name="x3"> the x-coordinate of the 2nd control point </param>
	/// <param name="y3"> the y-coordinate of the 2nd control point </param>
	/// <param name="z3"> the z-coordinate of the 2nd control point </param>
	/// <param name="x4"> the x-coordinate of the anchor point </param>
	/// <param name="y4"> the y-coordinate of the anchor point </param>
	/// <param name="z4"> the z-coordinate of the anchor point </param>
	/// <seealso cref= PGraphics#curveVertex(float, float, float) </seealso>
	/// <seealso cref= PGraphics#vertex(float, float, float, float, float) </seealso>
	/// <seealso cref= PGraphics#quadraticVertex(float, float, float, float, float, float) </seealso>
	/// <seealso cref= PGraphics#bezier(float, float, float, float, float, float, float, float, float, float, float, float) </seealso>
	  public virtual void bezierVertex(float x2, float y2, float z2, float x3, float y3, float z3, float x4, float y4, float z4)
	  {
		bezierInitCheck();
		bezierVertexCheck();
		PMatrix3D draw = bezierDrawMatrix;

		float[] prev = vertices[vertexCount - 1];
		float x1 = prev[PConstants_Fields.X];
		float y1 = prev[PConstants_Fields.Y];
		float z1 = prev[PConstants_Fields.Z];

		float xplot1 = draw.m10 * x1 + draw.m11 * x2 + draw.m12 * x3 + draw.m13 * x4;
		float xplot2 = draw.m20 * x1 + draw.m21 * x2 + draw.m22 * x3 + draw.m23 * x4;
		float xplot3 = draw.m30 * x1 + draw.m31 * x2 + draw.m32 * x3 + draw.m33 * x4;

		float yplot1 = draw.m10 * y1 + draw.m11 * y2 + draw.m12 * y3 + draw.m13 * y4;
		float yplot2 = draw.m20 * y1 + draw.m21 * y2 + draw.m22 * y3 + draw.m23 * y4;
		float yplot3 = draw.m30 * y1 + draw.m31 * y2 + draw.m32 * y3 + draw.m33 * y4;

		float zplot1 = draw.m10 * z1 + draw.m11 * z2 + draw.m12 * z3 + draw.m13 * z4;
		float zplot2 = draw.m20 * z1 + draw.m21 * z2 + draw.m22 * z3 + draw.m23 * z4;
		float zplot3 = draw.m30 * z1 + draw.m31 * z2 + draw.m32 * z3 + draw.m33 * z4;

		for (int j = 0; j < bezierDetail_Renamed; j++)
		{
		  x1 += xplot1;
		  xplot1 += xplot2;
		  xplot2 += xplot3;
		  y1 += yplot1;
		  yplot1 += yplot2;
		  yplot2 += yplot3;
		  z1 += zplot1;
		  zplot1 += zplot2;
		  zplot2 += zplot3;
		  vertex(x1, y1, z1);
		}
	  }

	  /// <summary>
	  /// @webref shape:vertex </summary>
	  /// <param name="cx"> the x-coordinate of the control point </param>
	  /// <param name="cy"> the y-coordinate of the control point </param>
	  /// <param name="x3"> the x-coordinate of the anchor point </param>
	  /// <param name="y3"> the y-coordinate of the anchor point </param>
	  /// <seealso cref= PGraphics#curveVertex(float, float, float) </seealso>
	  /// <seealso cref= PGraphics#vertex(float, float, float, float, float) </seealso>
	  /// <seealso cref= PGraphics#bezierVertex(float, float, float, float, float, float) </seealso>
	  /// <seealso cref= PGraphics#bezier(float, float, float, float, float, float, float, float, float, float, float, float) </seealso>
	  public virtual void quadraticVertex(float cx, float cy, float x3, float y3)
	  {
		float[] prev = vertices[vertexCount - 1];
		float x1 = prev[PConstants_Fields.X];
		float y1 = prev[PConstants_Fields.Y];

		bezierVertex(x1 + ((cx - x1) * 2 / 3.0f), y1 + ((cy - y1) * 2 / 3.0f), x3 + ((cx - x3) * 2 / 3.0f), y3 + ((cy - y3) * 2 / 3.0f), x3, y3);
	  }

	  /// <param name="cz"> the z-coordinate of the control point </param>
	  /// <param name="z3"> the z-coordinate of the anchor point </param>
	  public virtual void quadraticVertex(float cx, float cy, float cz, float x3, float y3, float z3)
	  {
		float[] prev = vertices[vertexCount - 1];
		float x1 = prev[PConstants_Fields.X];
		float y1 = prev[PConstants_Fields.Y];
		float z1 = prev[PConstants_Fields.Z];

		bezierVertex(x1 + ((cx - x1) * 2 / 3.0f), y1 + ((cy - y1) * 2 / 3.0f), z1 + ((cz - z1) * 2 / 3.0f), x3 + ((cx - x3) * 2 / 3.0f), y3 + ((cy - y3) * 2 / 3.0f), z3 + ((cz - z3) * 2 / 3.0f), x3, y3, z3);
	  }

	  protected internal virtual void curveVertexCheck()
	  {
		curveVertexCheck(shape_Renamed);
	  }

	  /// <summary>
	  /// Perform initialization specific to curveVertex(), and handle standard
	  /// error modes. Can be overridden by subclasses that need the flexibility.
	  /// </summary>
	  protected internal virtual void curveVertexCheck(int shape)
	  {
		if (shape != PConstants_Fields.POLYGON)
		{
		  throw new Exception("You must use beginShape() or " + "beginShape(POLYGON) before curveVertex()");
		}
		// to improve code init time, allocate on first use.
		if (curveVertices == null)
		{
//JAVA TO C# CONVERTER NOTE: The following call to the 'RectangularArrays' helper class reproduces the rectangular array initialization that is automatic in Java:
//ORIGINAL LINE: curveVertices = new float[128][3];
		  curveVertices = RectangularArrays.ReturnRectangularFloatArray(128, 3);
		}

		if (curveVertexCount == curveVertices.Length)
		{
		  // Can't use PApplet.expand() cuz it doesn't do the copy properly
//JAVA TO C# CONVERTER NOTE: The following call to the 'RectangularArrays' helper class reproduces the rectangular array initialization that is automatic in Java:
//ORIGINAL LINE: float[][] temp = new float[curveVertexCount << 1][3];
		  float[][] temp = RectangularArrays.ReturnRectangularFloatArray(curveVertexCount << 1, 3);
		  Array.Copy(curveVertices, 0, temp, 0, curveVertexCount);
		  curveVertices = temp;
		}
		curveInitCheck();
	  }

	 /// <summary>
	 /// ( begin auto-generated from curveVertex.xml )
	 ///  
	 /// Specifies vertex coordinates for curves. This function may only be used
	 /// between <b>beginShape()</b> and <b>endShape()</b> and only when there is
	 /// no MODE parameter specified to <b>beginShape()</b>. The first and last
	 /// points in a series of <b>curveVertex()</b> lines will be used to guide
	 /// the beginning and end of a the curve. A minimum of four points is
	 /// required to draw a tiny curve between the second and third points.
	 /// Adding a fifth point with <b>curveVertex()</b> will draw the curve
	 /// between the second, third, and fourth points. The <b>curveVertex()</b>
	 /// function is an implementation of Catmull-Rom splines. Using the 3D
	 /// version requires rendering with P3D (see the Environment reference for
	 /// more information).
	 ///  
	 /// ( end auto-generated )
	 /// 
	 /// @webref shape:vertex </summary>
	 /// <param name="x"> the x-coordinate of the vertex </param>
	 /// <param name="y"> the y-coordinate of the vertex </param>
	 /// <seealso cref= PGraphics#curve(float, float, float, float, float, float, float, float, float, float, float, float) </seealso>
	 /// <seealso cref= PGraphics#beginShape(int) </seealso>
	 /// <seealso cref= PGraphics#endShape(int) </seealso>
	 /// <seealso cref= PGraphics#vertex(float, float, float, float, float) </seealso>
	 /// <seealso cref= PGraphics#bezier(float, float, float, float, float, float, float, float, float, float, float, float) </seealso>
	 /// <seealso cref= PGraphics#quadraticVertex(float, float, float, float, float, float) </seealso>
	  public virtual void curveVertex(float x, float y)
	  {
		curveVertexCheck();
		float[] vertex = curveVertices[curveVertexCount];
		vertex[PConstants_Fields.X] = x;
		vertex[PConstants_Fields.Y] = y;
		curveVertexCount++;

		// draw a segment if there are enough points
		if (curveVertexCount > 3)
		{
		  curveVertexSegment(curveVertices[curveVertexCount - 4][PConstants_Fields.X], curveVertices[curveVertexCount - 4][PConstants_Fields.Y], curveVertices[curveVertexCount - 3][PConstants_Fields.X], curveVertices[curveVertexCount - 3][PConstants_Fields.Y], curveVertices[curveVertexCount - 2][PConstants_Fields.X], curveVertices[curveVertexCount - 2][PConstants_Fields.Y], curveVertices[curveVertexCount - 1][PConstants_Fields.X], curveVertices[curveVertexCount - 1][PConstants_Fields.Y]);
		}
	  }

	  /// <param name="z"> the z-coordinate of the vertex </param>
	  public virtual void curveVertex(float x, float y, float z)
	  {
		curveVertexCheck();
		float[] vertex = curveVertices[curveVertexCount];
		vertex[PConstants_Fields.X] = x;
		vertex[PConstants_Fields.Y] = y;
		vertex[PConstants_Fields.Z] = z;
		curveVertexCount++;

		// draw a segment if there are enough points
		if (curveVertexCount > 3)
		{
		  curveVertexSegment(curveVertices[curveVertexCount - 4][PConstants_Fields.X], curveVertices[curveVertexCount - 4][PConstants_Fields.Y], curveVertices[curveVertexCount - 4][PConstants_Fields.Z], curveVertices[curveVertexCount - 3][PConstants_Fields.X], curveVertices[curveVertexCount - 3][PConstants_Fields.Y], curveVertices[curveVertexCount - 3][PConstants_Fields.Z], curveVertices[curveVertexCount - 2][PConstants_Fields.X], curveVertices[curveVertexCount - 2][PConstants_Fields.Y], curveVertices[curveVertexCount - 2][PConstants_Fields.Z], curveVertices[curveVertexCount - 1][PConstants_Fields.X], curveVertices[curveVertexCount - 1][PConstants_Fields.Y], curveVertices[curveVertexCount - 1][PConstants_Fields.Z]);
		}
	  }


	  /// <summary>
	  /// Handle emitting a specific segment of Catmull-Rom curve. This can be
	  /// overridden by subclasses that need more efficient rendering options.
	  /// </summary>
	  protected internal virtual void curveVertexSegment(float x1, float y1, float x2, float y2, float x3, float y3, float x4, float y4)
	  {
		float x0 = x2;
		float y0 = y2;

		PMatrix3D draw = curveDrawMatrix;

		float xplot1 = draw.m10 * x1 + draw.m11 * x2 + draw.m12 * x3 + draw.m13 * x4;
		float xplot2 = draw.m20 * x1 + draw.m21 * x2 + draw.m22 * x3 + draw.m23 * x4;
		float xplot3 = draw.m30 * x1 + draw.m31 * x2 + draw.m32 * x3 + draw.m33 * x4;

		float yplot1 = draw.m10 * y1 + draw.m11 * y2 + draw.m12 * y3 + draw.m13 * y4;
		float yplot2 = draw.m20 * y1 + draw.m21 * y2 + draw.m22 * y3 + draw.m23 * y4;
		float yplot3 = draw.m30 * y1 + draw.m31 * y2 + draw.m32 * y3 + draw.m33 * y4;

		// vertex() will reset splineVertexCount, so save it
		int savedCount = curveVertexCount;

		vertex(x0, y0);
		for (int j = 0; j < curveDetail_Renamed; j++)
		{
		  x0 += xplot1;
		  xplot1 += xplot2;
		  xplot2 += xplot3;
		  y0 += yplot1;
		  yplot1 += yplot2;
		  yplot2 += yplot3;
		  vertex(x0, y0);
		}
		curveVertexCount = savedCount;
	  }


	  /// <summary>
	  /// Handle emitting a specific segment of Catmull-Rom curve. This can be
	  /// overridden by subclasses that need more efficient rendering options.
	  /// </summary>
	  protected internal virtual void curveVertexSegment(float x1, float y1, float z1, float x2, float y2, float z2, float x3, float y3, float z3, float x4, float y4, float z4)
	  {
		float x0 = x2;
		float y0 = y2;
		float z0 = z2;

		PMatrix3D draw = curveDrawMatrix;

		float xplot1 = draw.m10 * x1 + draw.m11 * x2 + draw.m12 * x3 + draw.m13 * x4;
		float xplot2 = draw.m20 * x1 + draw.m21 * x2 + draw.m22 * x3 + draw.m23 * x4;
		float xplot3 = draw.m30 * x1 + draw.m31 * x2 + draw.m32 * x3 + draw.m33 * x4;

		float yplot1 = draw.m10 * y1 + draw.m11 * y2 + draw.m12 * y3 + draw.m13 * y4;
		float yplot2 = draw.m20 * y1 + draw.m21 * y2 + draw.m22 * y3 + draw.m23 * y4;
		float yplot3 = draw.m30 * y1 + draw.m31 * y2 + draw.m32 * y3 + draw.m33 * y4;

		// vertex() will reset splineVertexCount, so save it
		int savedCount = curveVertexCount;

		float zplot1 = draw.m10 * z1 + draw.m11 * z2 + draw.m12 * z3 + draw.m13 * z4;
		float zplot2 = draw.m20 * z1 + draw.m21 * z2 + draw.m22 * z3 + draw.m23 * z4;
		float zplot3 = draw.m30 * z1 + draw.m31 * z2 + draw.m32 * z3 + draw.m33 * z4;

		vertex(x0, y0, z0);
		for (int j = 0; j < curveDetail_Renamed; j++)
		{
		  x0 += xplot1;
		  xplot1 += xplot2;
		  xplot2 += xplot3;
		  y0 += yplot1;
		  yplot1 += yplot2;
		  yplot2 += yplot3;
		  z0 += zplot1;
		  zplot1 += zplot2;
		  zplot2 += zplot3;
		  vertex(x0, y0, z0);
		}
		curveVertexCount = savedCount;
	  }



	  //////////////////////////////////////////////////////////////

	  // SIMPLE SHAPES WITH ANALOGUES IN beginShape()


	  /// <summary>
	  /// ( begin auto-generated from point.xml )
	  /// 
	  /// Draws a point, a coordinate in space at the dimension of one pixel. The
	  /// first parameter is the horizontal value for the point, the second value
	  /// is the vertical value for the point, and the optional third value is the
	  /// depth value. Drawing this shape in 3D with the <b>z</b> parameter
	  /// requires the P3D parameter in combination with <b>size()</b> as shown in
	  /// the above example.
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref shape:2d_primitives </summary>
	  /// <param name="x"> x-coordinate of the point </param>
	  /// <param name="y"> y-coordinate of the point </param>
	  public virtual void point(float x, float y)
	  {
		beginShape(PConstants_Fields.POINTS);
		vertex(x, y);
		endShape();
	  }

	  /// <param name="z"> z-coordinate of the point </param>
	  public virtual void point(float x, float y, float z)
	  {
		beginShape(PConstants_Fields.POINTS);
		vertex(x, y, z);
		endShape();
	  }

	  /// <summary>
	  /// ( begin auto-generated from line.xml )
	  /// 
	  /// Draws a line (a direct path between two points) to the screen. The
	  /// version of <b>line()</b> with four parameters draws the line in 2D.  To
	  /// color a line, use the <b>stroke()</b> function. A line cannot be filled,
	  /// therefore the <b>fill()</b> function will not affect the color of a
	  /// line. 2D lines are drawn with a width of one pixel by default, but this
	  /// can be changed with the <b>strokeWeight()</b> function. The version with
	  /// six parameters allows the line to be placed anywhere within XYZ space.
	  /// Drawing this shape in 3D with the <b>z</b> parameter requires the P3D
	  /// parameter in combination with <b>size()</b> as shown in the above example.
	  /// 
	  /// ( end auto-generated )
	  /// @webref shape:2d_primitives </summary>
	  /// <param name="x1"> x-coordinate of the first point </param>
	  /// <param name="y1"> y-coordinate of the first point </param>
	  /// <param name="x2"> x-coordinate of the second point </param>
	  /// <param name="y2"> y-coordinate of the second point </param>
	  /// <seealso cref= PGraphics#strokeWeight(float) </seealso>
	  /// <seealso cref= PGraphics#strokeJoin(int) </seealso>
	  /// <seealso cref= PGraphics#strokeCap(int) </seealso>
	  /// <seealso cref= PGraphics#beginShape() </seealso>
	  public virtual void line(float x1, float y1, float x2, float y2)
	  {
		beginShape(PConstants_Fields.LINES);
		vertex(x1, y1);
		vertex(x2, y2);
		endShape();
	  }

	  /// <param name="z1"> z-coordinate of the first point </param>
	  /// <param name="z2"> z-coordinate of the second point </param>
	  public virtual void line(float x1, float y1, float z1, float x2, float y2, float z2)
	  {
		beginShape(PConstants_Fields.LINES);
		vertex(x1, y1, z1);
		vertex(x2, y2, z2);
		endShape();
	  }

	  /// <summary>
	  /// ( begin auto-generated from triangle.xml )
	  /// 
	  /// A triangle is a plane created by connecting three points. The first two
	  /// arguments specify the first point, the middle two arguments specify the
	  /// second point, and the last two arguments specify the third point.
	  /// 
	  /// ( end auto-generated )
	  /// @webref shape:2d_primitives </summary>
	  /// <param name="x1"> x-coordinate of the first point </param>
	  /// <param name="y1"> y-coordinate of the first point </param>
	  /// <param name="x2"> x-coordinate of the second point </param>
	  /// <param name="y2"> y-coordinate of the second point </param>
	  /// <param name="x3"> x-coordinate of the third point </param>
	  /// <param name="y3"> y-coordinate of the third point </param>
	  /// <seealso cref= PApplet#beginShape() </seealso>
	  public virtual void triangle(float x1, float y1, float x2, float y2, float x3, float y3)
	  {
		beginShape(PConstants_Fields.TRIANGLES);
		vertex(x1, y1);
		vertex(x2, y2);
		vertex(x3, y3);
		endShape();
	  }


	  /// <summary>
	  /// ( begin auto-generated from quad.xml )
	  /// 
	  /// A quad is a quadrilateral, a four sided polygon. It is similar to a
	  /// rectangle, but the angles between its edges are not constrained to
	  /// ninety degrees. The first pair of parameters (x1,y1) sets the first
	  /// vertex and the subsequent pairs should proceed clockwise or
	  /// counter-clockwise around the defined shape.
	  /// 
	  /// ( end auto-generated )
	  /// @webref shape:2d_primitives </summary>
	  /// <param name="x1"> x-coordinate of the first corner </param>
	  /// <param name="y1"> y-coordinate of the first corner </param>
	  /// <param name="x2"> x-coordinate of the second corner </param>
	  /// <param name="y2"> y-coordinate of the second corner </param>
	  /// <param name="x3"> x-coordinate of the third corner </param>
	  /// <param name="y3"> y-coordinate of the third corner </param>
	  /// <param name="x4"> x-coordinate of the fourth corner </param>
	  /// <param name="y4"> y-coordinate of the fourth corner </param>
	  public virtual void quad(float x1, float y1, float x2, float y2, float x3, float y3, float x4, float y4)
	  {
		beginShape(PConstants_Fields.QUADS);
		vertex(x1, y1);
		vertex(x2, y2);
		vertex(x3, y3);
		vertex(x4, y4);
		endShape();
	  }



	  //////////////////////////////////////////////////////////////

	  // RECT

	  /// <summary>
	  /// ( begin auto-generated from rectMode.xml )
	  /// 
	  /// Modifies the location from which rectangles draw. The default mode is
	  /// <b>rectMode(CORNER)</b>, which specifies the location to be the upper
	  /// left corner of the shape and uses the third and fourth parameters of
	  /// <b>rect()</b> to specify the width and height. The syntax
	  /// <b>rectMode(CORNERS)</b> uses the first and second parameters of
	  /// <b>rect()</b> to set the location of one corner and uses the third and
	  /// fourth parameters to set the opposite corner. The syntax
	  /// <b>rectMode(CENTER)</b> draws the image from its center point and uses
	  /// the third and forth parameters of <b>rect()</b> to specify the image's
	  /// width and height. The syntax <b>rectMode(RADIUS)</b> draws the image
	  /// from its center point and uses the third and forth parameters of
	  /// <b>rect()</b> to specify half of the image's width and height. The
	  /// parameter must be written in ALL CAPS because Processing is a case
	  /// sensitive language. Note: In version 125, the mode named CENTER_RADIUS
	  /// was shortened to RADIUS.
	  /// 
	  /// ( end auto-generated )
	  /// @webref shape:attributes </summary>
	  /// <param name="mode"> either CORNER, CORNERS, CENTER, or RADIUS </param>
	  /// <seealso cref= PGraphics#rect(float, float, float, float) </seealso>
	  public virtual void rectMode(int mode)
	  {
		rectMode_Renamed = mode;
	  }


	  /// <summary>
	  /// ( begin auto-generated from rect.xml )
	  /// 
	  /// Draws a rectangle to the screen. A rectangle is a four-sided shape with
	  /// every angle at ninety degrees. By default, the first two parameters set
	  /// the location of the upper-left corner, the third sets the width, and the
	  /// fourth sets the height. These parameters may be changed with the
	  /// <b>rectMode()</b> function.
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref shape:2d_primitives </summary>
	  /// <param name="a"> x-coordinate of the rectangle by default </param>
	  /// <param name="b"> y-coordinate of the rectangle by default </param>
	  /// <param name="c"> width of the rectangle by default </param>
	  /// <param name="d"> height of the rectangle by default </param>
	  /// <seealso cref= PGraphics#rectMode(int) </seealso>
	  /// <seealso cref= PGraphics#quad(float, float, float, float, float, float, float, float) </seealso>
	  public virtual void rect(float a, float b, float c, float d)
	  {
		float hradius, vradius;
		switch (rectMode_Renamed)
		{
		case PConstants_Fields.CORNERS:
		  break;
		case PConstants_Fields.CORNER:
		  c += a;
		  d += b;
		  break;
		case PConstants_Fields.RADIUS:
		  hradius = c;
		  vradius = d;
		  c = a + hradius;
		  d = b + vradius;
		  a -= hradius;
		  b -= vradius;
		  break;
		case PConstants_Fields.CENTER:
		  hradius = c / 2.0f;
		  vradius = d / 2.0f;
		  c = a + hradius;
		  d = b + vradius;
		  a -= hradius;
		  b -= vradius;
	  break;
		}

		if (a > c)
		{
		  float temp = a;
		  a = c;
		  c = temp;
		}

		if (b > d)
		{
		  float temp = b;
		  b = d;
		  d = temp;
		}

		rectImpl(a, b, c, d);
	  }


	  protected internal virtual void rectImpl(float x1, float y1, float x2, float y2)
	  {
		quad(x1, y1, x2, y1, x2, y2, x1, y2);
	  }


	  // Still need to do a lot of work here to make it behave across renderers
	  // (e.g. not all renderers use the vertices array)
	  // Also seems to be some issues on quality here (too dense)
	  // http://code.google.com/p/processing/issues/detail?id=265
	//  private void quadraticVertex(float cpx, float cpy, float x, float y) {
	//    float[] prev = vertices[vertexCount - 1];
	//    float prevX = prev[X];
	//    float prevY = prev[Y];
	//    float cp1x = prevX + 2.0f/3.0f*(cpx - prevX);
	//    float cp1y = prevY + 2.0f/3.0f*(cpy - prevY);
	//    float cp2x = cp1x + (x - prevX)/3.0f;
	//    float cp2y = cp1y + (y - prevY)/3.0f;
	//    bezierVertex(cp1x, cp1y, cp2x, cp2y, x, y);
	//  }

	  /// <param name="r"> radii for all four corners </param>
	  public virtual void rect(float a, float b, float c, float d, float r)
	  {
		rect(a, b, c, d, r, r, r, r);
	  }

	  /// <param name="tl"> radius for top-left corner </param>
	  /// <param name="tr"> radius for top-right corner </param>
	  /// <param name="br"> radius for bottom-right corner </param>
	  /// <param name="bl"> radius for bottom-left corner </param>
	  public virtual void rect(float a, float b, float c, float d, float tl, float tr, float br, float bl)
	  {
		float hradius, vradius;
		switch (rectMode_Renamed)
		{
		case PConstants_Fields.CORNERS:
		  break;
		case PConstants_Fields.CORNER:
		  c += a;
		  d += b;
		  break;
		case PConstants_Fields.RADIUS:
		  hradius = c;
		  vradius = d;
		  c = a + hradius;
		  d = b + vradius;
		  a -= hradius;
		  b -= vradius;
		  break;
		case PConstants_Fields.CENTER:
		  hradius = c / 2.0f;
		  vradius = d / 2.0f;
		  c = a + hradius;
		  d = b + vradius;
		  a -= hradius;
		  b -= vradius;
	  break;
		}

		if (a > c)
		{
		  float temp = a;
		  a = c;
		  c = temp;
		}

		if (b > d)
		{
		  float temp = b;
		  b = d;
		  d = temp;
		}

			// TODO: after PApplet
//		float maxRounding = PApplet.min((c - a) / 2, (d - b) / 2);
//		if (tl > maxRounding)
//		{
//			tl = maxRounding;
//		}
//		if (tr > maxRounding)
//		{
//			tr = maxRounding;
//		}
//		if (br > maxRounding)
//		{
//			br = maxRounding;
//		}
//		if (bl > maxRounding)
//		{
//			bl = maxRounding;
//		}

		rectImpl(a, b, c, d, tl, tr, br, bl);
	  }


	  protected internal virtual void rectImpl(float x1, float y1, float x2, float y2, float tl, float tr, float br, float bl)
	  {
		beginShape();
	//    vertex(x1+tl, y1);
		if (tr != 0)
		{
		  vertex(x2 - tr, y1);
		  quadraticVertex(x2, y1, x2, y1 + tr);
		}
		else
		{
		  vertex(x2, y1);
		}
		if (br != 0)
		{
		  vertex(x2, y2 - br);
		  quadraticVertex(x2, y2, x2 - br, y2);
		}
		else
		{
		  vertex(x2, y2);
		}
		if (bl != 0)
		{
		  vertex(x1 + bl, y2);
		  quadraticVertex(x1, y2, x1, y2 - bl);
		}
		else
		{
		  vertex(x1, y2);
		}
		if (tl != 0)
		{
		  vertex(x1, y1 + tl);
		  quadraticVertex(x1, y1, x1 + tl, y1);
		}
		else
		{
		  vertex(x1, y1);
		}
	//    endShape();
		endShape(PConstants_Fields.CLOSE);
	  }



	  //////////////////////////////////////////////////////////////

	  // ELLIPSE AND ARC


	  /// <summary>
	  /// ( begin auto-generated from ellipseMode.xml )
	  /// 
	  /// The origin of the ellipse is modified by the <b>ellipseMode()</b>
	  /// function. The default configuration is <b>ellipseMode(CENTER)</b>, which
	  /// specifies the location of the ellipse as the center of the shape. The
	  /// <b>RADIUS</b> mode is the same, but the width and height parameters to
	  /// <b>ellipse()</b> specify the radius of the ellipse, rather than the
	  /// diameter. The <b>CORNER</b> mode draws the shape from the upper-left
	  /// corner of its bounding box. The <b>CORNERS</b> mode uses the four
	  /// parameters to <b>ellipse()</b> to set two opposing corners of the
	  /// ellipse's bounding box. The parameter must be written in ALL CAPS
	  /// because Processing is a case-sensitive language.
	  /// 
	  /// ( end auto-generated )
	  /// @webref shape:attributes </summary>
	  /// <param name="mode"> either CENTER, RADIUS, CORNER, or CORNERS </param>
	  /// <seealso cref= PApplet#ellipse(float, float, float, float) </seealso>
	  /// <seealso cref= PApplet#arc(float, float, float, float, float, float) </seealso>
	  public virtual void ellipseMode(int mode)
	  {
		ellipseMode_Renamed = mode;
	  }


	  /// <summary>
	  /// ( begin auto-generated from ellipse.xml )
	  /// 
	  /// Draws an ellipse (oval) in the display window. An ellipse with an equal
	  /// <b>width</b> and <b>height</b> is a circle. The first two parameters set
	  /// the location, the third sets the width, and the fourth sets the height.
	  /// The origin may be changed with the <b>ellipseMode()</b> function.
	  /// 
	  /// ( end auto-generated )
	  /// @webref shape:2d_primitives </summary>
	  /// <param name="a"> x-coordinate of the ellipse </param>
	  /// <param name="b"> y-coordinate of the ellipse </param>
	  /// <param name="c"> width of the ellipse by default </param>
	  /// <param name="d"> height of the ellipse by default </param>
	  /// <seealso cref= PApplet#ellipseMode(int) </seealso>
	  /// <seealso cref= PApplet#arc(float, float, float, float, float, float) </seealso>
	  public virtual void ellipse(float a, float b, float c, float d)
	  {
		float x = a;
		float y = b;
		float w = c;
		float h = d;

		if (ellipseMode_Renamed == PConstants_Fields.CORNERS)
		{
		  w = c - a;
		  h = d - b;

		}
		else if (ellipseMode_Renamed == PConstants_Fields.RADIUS)
		{
		  x = a - c;
		  y = b - d;
		  w = c * 2;
		  h = d * 2;

		}
		else if (ellipseMode_Renamed == PConstants_Fields.DIAMETER)
		{
		  x = a - c / 2f;
		  y = b - d / 2f;
		}

		if (w < 0) // undo negative width
		{
		  x += w;
		  w = -w;
		}

		if (h < 0) // undo negative height
		{
		  y += h;
		  h = -h;
		}

		ellipseImpl(x, y, w, h);
	  }


	  protected internal virtual void ellipseImpl(float x, float y, float w, float h)
	  {
	  }


	  /// <summary>
	  /// ( begin auto-generated from arc.xml )
	  /// 
	  /// Draws an arc in the display window. Arcs are drawn along the outer edge
	  /// of an ellipse defined by the <b>x</b>, <b>y</b>, <b>width</b> and
	  /// <b>height</b> parameters. The origin or the arc's ellipse may be changed
	  /// with the <b>ellipseMode()</b> function. The <b>start</b> and <b>stop</b>
	  /// parameters specify the angles at which to draw the arc.
	  /// 
	  /// ( end auto-generated )
	  /// @webref shape:2d_primitives </summary>
	  /// <param name="a"> x-coordinate of the arc's ellipse </param>
	  /// <param name="b"> y-coordinate of the arc's ellipse </param>
	  /// <param name="c"> width of the arc's ellipse by default </param>
	  /// <param name="d"> height of the arc's ellipse by default </param>
	  /// <param name="start"> angle to start the arc, specified in radians </param>
	  /// <param name="stop"> angle to stop the arc, specified in radians </param>
	  /// <seealso cref= PApplet#ellipse(float, float, float, float) </seealso>
	  /// <seealso cref= PApplet#ellipseMode(int) </seealso>
	  /// <seealso cref= PApplet#radians(float) </seealso>
	  /// <seealso cref= PApplet#degrees(float) </seealso>
	  public virtual void arc(float a, float b, float c, float d, float start, float stop)
	  {
		arc(a, b, c, d, start, stop, 0);
	  }

	  /*
	   * @param mode either OPEN, CHORD, or PIE
	   */
	  public virtual void arc(float a, float b, float c, float d, float start, float stop, int mode)
	  {
		float x = a;
		float y = b;
		float w = c;
		float h = d;

		if (ellipseMode_Renamed == PConstants_Fields.CORNERS)
		{
		  w = c - a;
		  h = d - b;

		}
		else if (ellipseMode_Renamed == PConstants_Fields.RADIUS)
		{
		  x = a - c;
		  y = b - d;
		  w = c * 2;
		  h = d * 2;

		}
		else if (ellipseMode_Renamed == PConstants_Fields.CENTER)
		{
		  x = a - c / 2f;
		  y = b - d / 2f;
		}

		// make sure the loop will exit before starting while
		if (!float.IsInfinity(start) && !float.IsInfinity(stop))
		{
		  // ignore equal and degenerate cases
		  if (stop > start)
		  {
			// make sure that we're starting at a useful point
			while (start < 0)
			{
			  start += PConstants_Fields.TWO_PI;
			  stop += PConstants_Fields.TWO_PI;
			}

			if (stop - start > PConstants_Fields.TWO_PI)
			{
			  start = 0;
			  stop = PConstants_Fields.TWO_PI;
			}
			arcImpl(x, y, w, h, start, stop, mode);
		  }
		}
	  }


	//  protected void arcImpl(float x, float y, float w, float h,
	//                         float start, float stop) {
	//  }


	  /// <summary>
	  /// Start and stop are in radians, converted by the parent function.
	  /// Note that the radians can be greater (or less) than TWO_PI.
	  /// This is so that an arc can be drawn that crosses zero mark,
	  /// and the user will still collect $200.
	  /// </summary>
	  protected internal virtual void arcImpl(float x, float y, float w, float h, float start, float stop, int mode)
	  {
		showMissingWarning("arc");
	  }


	  //////////////////////////////////////////////////////////////

	  // BOX

	  /// <summary>
	  /// ( begin auto-generated from box.xml )
	  /// 
	  /// A box is an extruded rectangle. A box with equal dimension on all sides
	  /// is a cube.
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref shape:3d_primitives </summary>
	  /// <param name="size"> dimension of the box in all dimensions (creates a cube) </param>
	  /// <seealso cref= PGraphics#sphere(float) </seealso>
	  public virtual void box(float size)
	  {
		box(size, size, size);
	  }


	  /// <param name="w"> dimension of the box in the x-dimension </param>
	  /// <param name="h"> dimension of the box in the y-dimension </param>
	  /// <param name="d"> dimension of the box in the z-dimension </param>
	  public virtual void box(float w, float h, float d)
	  {
		float x1 = -w / 2f;
		float x2 = w / 2f;
		float y1 = -h / 2f;
		float y2 = h / 2f;
		float z1 = -d / 2f;
		float z2 = d / 2f;

		// TODO not the least bit efficient, it even redraws lines
		// along the vertices. ugly ugly ugly!

		beginShape(PConstants_Fields.QUADS);

		// front
		normal(0, 0, 1);
		vertex(x1, y1, z1);
		vertex(x2, y1, z1);
		vertex(x2, y2, z1);
		vertex(x1, y2, z1);

		// right
		normal(1, 0, 0);
		vertex(x2, y1, z1);
		vertex(x2, y1, z2);
		vertex(x2, y2, z2);
		vertex(x2, y2, z1);

		// back
		normal(0, 0, -1);
		vertex(x2, y1, z2);
		vertex(x1, y1, z2);
		vertex(x1, y2, z2);
		vertex(x2, y2, z2);

		// left
		normal(-1, 0, 0);
		vertex(x1, y1, z2);
		vertex(x1, y1, z1);
		vertex(x1, y2, z1);
		vertex(x1, y2, z2);

		// top
		normal(0, 1, 0);
		vertex(x1, y1, z2);
		vertex(x2, y1, z2);
		vertex(x2, y1, z1);
		vertex(x1, y1, z1);

		// bottom
		normal(0, -1, 0);
		vertex(x1, y2, z1);
		vertex(x2, y2, z1);
		vertex(x2, y2, z2);
		vertex(x1, y2, z2);

		endShape();
	  }



	  //////////////////////////////////////////////////////////////

	  // SPHERE

	  /// <summary>
	  /// ( begin auto-generated from sphereDetail.xml )
	  /// 
	  /// Controls the detail used to render a sphere by adjusting the number of
	  /// vertices of the sphere mesh. The default resolution is 30, which creates
	  /// a fairly detailed sphere definition with vertices every 360/30 = 12
	  /// degrees. If you're going to render a great number of spheres per frame,
	  /// it is advised to reduce the level of detail using this function. The
	  /// setting stays active until <b>sphereDetail()</b> is called again with a
	  /// new parameter and so should <i>not</i> be called prior to every
	  /// <b>sphere()</b> statement, unless you wish to render spheres with
	  /// different settings, e.g. using less detail for smaller spheres or ones
	  /// further away from the camera. To control the detail of the horizontal
	  /// and vertical resolution independently, use the version of the functions
	  /// with two parameters.
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// <h3>Advanced</h3>
	  /// Code for sphereDetail() submitted by toxi [031031].
	  /// Code for enhanced u/v version from davbol [080801].
	  /// </summary>
	  /// <param name="res"> number of segments (minimum 3) used per full circle revolution
	  /// @webref shape:3d_primitives </param>
	  /// <seealso cref= PGraphics#sphere(float) </seealso>
	  public virtual void sphereDetail(int res)
	  {
		sphereDetail(res, res);
	  }


	  /// <param name="ures"> number of segments used longitudinally per full circle revolutoin </param>
	  /// <param name="vres"> number of segments used latitudinally from top to bottom </param>
	  public virtual void sphereDetail(int ures, int vres)
	  {
		if (ures < 3) // force a minimum res
		{
			ures = 3;
		}
		if (vres < 2) // force a minimum res
		{
			vres = 2;
		}
		if ((ures == sphereDetailU) && (vres == sphereDetailV))
		{
			return;
		}

		float delta = (float)SINCOS_LENGTH / ures;
		float[] cx = new float[ures];
		float[] cz = new float[ures];
		// calc unit circle in XZ plane
		for (int i = 0; i < ures; i++)
		{
		  cx[i] = cosLUT[(int)(i * delta) % SINCOS_LENGTH];
		  cz[i] = sinLUT[(int)(i * delta) % SINCOS_LENGTH];
		}
		// computing vertexlist
		// vertexlist starts at south pole
		int vertCount = ures * (vres - 1) + 2;
		int currVert = 0;

		// re-init arrays to store vertices
		sphereX = new float[vertCount];
		sphereY = new float[vertCount];
		sphereZ = new float[vertCount];

		float angle_step = (SINCOS_LENGTH * 0.5f) / vres;
		float angle = angle_step;

		// step along Y axis
		for (int i = 1; i < vres; i++)
		{
		  float curradius = sinLUT[(int) angle % SINCOS_LENGTH];
		  float currY = cosLUT[(int) angle % SINCOS_LENGTH];
		  for (int j = 0; j < ures; j++)
		  {
			sphereX[currVert] = cx[j] * curradius;
			sphereY[currVert] = currY;
			sphereZ[currVert++] = cz[j] * curradius;
		  }
		  angle += angle_step;
		}
		sphereDetailU = ures;
		sphereDetailV = vres;
	  }


	  /// <summary>
	  /// ( begin auto-generated from sphere.xml )
	  /// 
	  /// A sphere is a hollow ball made from tessellated triangles.
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// <h3>Advanced</h3>
	  /// <P>
	  /// Implementation notes:
	  /// <P>
	  /// cache all the points of the sphere in a static array
	  /// top and bottom are just a bunch of triangles that land
	  /// in the center point
	  /// <P>
	  /// sphere is a series of concentric circles who radii vary
	  /// along the shape, based on, er.. cos or something
	  /// <PRE>
	  /// [toxi 031031] new sphere code. removed all multiplies with
	  /// radius, as scale() will take care of that anyway
	  /// 
	  /// [toxi 031223] updated sphere code (removed modulos)
	  /// and introduced sphereAt(x,y,z,r)
	  /// to avoid additional translate()'s on the user/sketch side
	  /// 
	  /// [davbol 080801] now using separate sphereDetailU/V
	  /// </PRE>
	  /// 
	  /// @webref shape:3d_primitives </summary>
	  /// <param name="r"> the radius of the sphere </param>
	  /// <seealso cref= PGraphics#sphereDetail(int) </seealso>
	  public virtual void sphere(float r)
	  {
		if ((sphereDetailU < 3) || (sphereDetailV < 2))
		{
		  sphereDetail(30);
		}

		edge(false);


		// 1st ring from south pole
		beginShape(PConstants_Fields.TRIANGLE_STRIP);
		for (int i = 0; i < sphereDetailU; i++)
		{
		  normal(0, -1, 0);
		  vertex(0, -r, 0);
		  normal(sphereX[i], sphereY[i], sphereZ[i]);
		  vertex(r * sphereX[i], r * sphereY[i], r * sphereZ[i]);
		}
		normal(0, -r, 0);
		vertex(0, -r, 0);
		normal(sphereX[0], sphereY[0], sphereZ[0]);
		vertex(r * sphereX[0], r * sphereY[0], r * sphereZ[0]);
		endShape();

		int v1, v11, v2;

		// middle rings
		int voff = 0;
		for (int i = 2; i < sphereDetailV; i++)
		{
		  v1 = v11 = voff;
		  voff += sphereDetailU;
		  v2 = voff;
		  beginShape(PConstants_Fields.TRIANGLE_STRIP);
		  for (int j = 0; j < sphereDetailU; j++)
		  {
			normal(sphereX[v1], sphereY[v1], sphereZ[v1]);
			vertex(r * sphereX[v1], r * sphereY[v1], r * sphereZ[v1++]);
			normal(sphereX[v2], sphereY[v2], sphereZ[v2]);
			vertex(r * sphereX[v2], r * sphereY[v2], r * sphereZ[v2++]);
		  }
		  // close each ring
		  v1 = v11;
		  v2 = voff;
		  normal(sphereX[v1], sphereY[v1], sphereZ[v1]);
		  vertex(r * sphereX[v1], r * sphereY[v1], r * sphereZ[v1]);
		  normal(sphereX[v2], sphereY[v2], sphereZ[v2]);
		  vertex(r * sphereX[v2], r * sphereY[v2], r * sphereZ[v2]);
		  endShape();
		}

		// add the northern cap
		beginShape(PConstants_Fields.TRIANGLE_STRIP);
		for (int i = 0; i < sphereDetailU; i++)
		{
		  v2 = voff + i;
		  normal(sphereX[v2], sphereY[v2], sphereZ[v2]);
		  vertex(r * sphereX[v2], r * sphereY[v2], r * sphereZ[v2]);
		  normal(0, 1, 0);
		  vertex(0, r, 0);
		}
		normal(sphereX[voff], sphereY[voff], sphereZ[voff]);
		vertex(r * sphereX[voff], r * sphereY[voff], r * sphereZ[voff]);
		normal(0, 1, 0);
		vertex(0, r, 0);
		endShape();

		edge(true);
	  }



	  //////////////////////////////////////////////////////////////

	  // BEZIER

	  /// <summary>
	  /// ( begin auto-generated from bezierPoint.xml )
	  /// 
	  /// Evaluates the Bezier at point t for points a, b, c, d. The parameter t
	  /// varies between 0 and 1, a and d are points on the curve, and b and c are
	  /// the control points. This can be done once with the x coordinates and a
	  /// second time with the y coordinates to get the location of a bezier curve
	  /// at t.
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// <h3>Advanced</h3>
	  /// For instance, to convert the following example:<PRE>
	  /// stroke(255, 102, 0);
	  /// line(85, 20, 10, 10);
	  /// line(90, 90, 15, 80);
	  /// stroke(0, 0, 0);
	  /// bezier(85, 20, 10, 10, 90, 90, 15, 80);
	  /// 
	  /// // draw it in gray, using 10 steps instead of the default 20
	  /// // this is a slower way to do it, but useful if you need
	  /// // to do things with the coordinates at each step
	  /// stroke(128);
	  /// beginShape(LINE_STRIP);
	  /// for (int i = 0; i <= 10; i++) {
	  ///   float t = i / 10.0f;
	  ///   float x = bezierPoint(85, 10, 90, 15, t);
	  ///   float y = bezierPoint(20, 10, 90, 80, t);
	  ///   vertex(x, y);
	  /// }
	  /// endShape();</PRE>
	  /// 
	  /// @webref shape:curves </summary>
	  /// <param name="a"> coordinate of first point on the curve </param>
	  /// <param name="b"> coordinate of first control point </param>
	  /// <param name="c"> coordinate of second control point </param>
	  /// <param name="d"> coordinate of second point on the curve </param>
	  /// <param name="t"> value between 0 and 1 </param>
	  /// <seealso cref= PGraphics#bezier(float, float, float, float, float, float, float, float, float, float, float, float) </seealso>
	  /// <seealso cref= PGraphics#bezierVertex(float, float, float, float, float, float) </seealso>
	  /// <seealso cref= PGraphics#curvePoint(float, float, float, float, float) </seealso>
	  public virtual float bezierPoint(float a, float b, float c, float d, float t)
	  {
		float t1 = 1.0f - t;
		return a * t1 * t1 * t1 + 3 * b * t * t1 * t1 + 3 * c * t * t * t1 + d * t * t * t;
	  }


	  /// <summary>
	  /// ( begin auto-generated from bezierTangent.xml )
	  /// 
	  /// Calculates the tangent of a point on a Bezier curve. There is a good
	  /// definition of <a href="http://en.wikipedia.org/wiki/Tangent"
	  /// target="new"><em>tangent</em> on Wikipedia</a>.
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// <h3>Advanced</h3>
	  /// Code submitted by Dave Bollinger (davol) for release 0136.
	  /// 
	  /// @webref shape:curves </summary>
	  /// <param name="a"> coordinate of first point on the curve </param>
	  /// <param name="b"> coordinate of first control point </param>
	  /// <param name="c"> coordinate of second control point </param>
	  /// <param name="d"> coordinate of second point on the curve </param>
	  /// <param name="t"> value between 0 and 1 </param>
	  /// <seealso cref= PGraphics#bezier(float, float, float, float, float, float, float, float, float, float, float, float) </seealso>
	  /// <seealso cref= PGraphics#bezierVertex(float, float, float, float, float, float) </seealso>
	  /// <seealso cref= PGraphics#curvePoint(float, float, float, float, float) </seealso>
	  public virtual float bezierTangent(float a, float b, float c, float d, float t)
	  {
		return (3 * t * t * (-a + 3 * b - 3 * c + d) + 6 * t * (a - 2 * b + c) + 3 * (-a + b));
	  }


	  protected internal virtual void bezierInitCheck()
	  {
		if (!bezierInited)
		{
		  bezierInit();
		}
	  }


	  protected internal virtual void bezierInit()
	  {
		// overkill to be broken out, but better parity with the curve stuff below
		bezierDetail(bezierDetail_Renamed);
		bezierInited = true;
	  }


	  /// <summary>
	  /// ( begin auto-generated from bezierDetail.xml )
	  /// 
	  /// Sets the resolution at which Beziers display. The default value is 20.
	  /// This function is only useful when using the P3D renderer as the default
	  /// P2D renderer does not use this information.
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref shape:curves </summary>
	  /// <param name="detail"> resolution of the curves </param>
	  /// <seealso cref= PGraphics#curve(float, float, float, float, float, float, float, float, float, float, float, float) </seealso>
	  /// <seealso cref= PGraphics#curveVertex(float, float, float) </seealso>
	  /// <seealso cref= PGraphics#curveTightness(float) </seealso>
	  public virtual void bezierDetail(int detail)
	  {
		bezierDetail_Renamed = detail;

		if (bezierDrawMatrix == null)
		{
		  bezierDrawMatrix = new PMatrix3D();
		}

		// setup matrix for forward differencing to speed up drawing
		splineForward(detail, bezierDrawMatrix);

		// multiply the basis and forward diff matrices together
		// saves much time since this needn't be done for each curve
		//mult_spline_matrix(bezierForwardMatrix, bezier_basis, bezierDrawMatrix, 4);
		//bezierDrawMatrix.set(bezierForwardMatrix);
		bezierDrawMatrix.apply(bezierBasisMatrix);
	  }



	  public virtual void bezier(float x1, float y1, float x2, float y2, float x3, float y3, float x4, float y4)
	  {
		beginShape();
		vertex(x1, y1);
		bezierVertex(x2, y2, x3, y3, x4, y4);
		endShape();
	  }

	  /// <summary>
	  /// ( begin auto-generated from bezier.xml )
	  /// 
	  /// Draws a Bezier curve on the screen. These curves are defined by a series
	  /// of anchor and control points. The first two parameters specify the first
	  /// anchor point and the last two parameters specify the other anchor point.
	  /// The middle parameters specify the control points which define the shape
	  /// of the curve. Bezier curves were developed by French engineer Pierre
	  /// Bezier. Using the 3D version requires rendering with P3D (see the
	  /// Environment reference for more information).
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// <h3>Advanced</h3>
	  /// Draw a cubic bezier curve. The first and last points are
	  /// the on-curve points. The middle two are the 'control' points,
	  /// or 'handles' in an application like Illustrator.
	  /// <P>
	  /// Identical to typing:
	  /// <PRE>beginShape();
	  /// vertex(x1, y1);
	  /// bezierVertex(x2, y2, x3, y3, x4, y4);
	  /// endShape();
	  /// </PRE>
	  /// In Postscript-speak, this would be:
	  /// <PRE>moveto(x1, y1);
	  /// curveto(x2, y2, x3, y3, x4, y4);</PRE>
	  /// If you were to try and continue that curve like so:
	  /// <PRE>curveto(x5, y5, x6, y6, x7, y7);</PRE>
	  /// This would be done in processing by adding these statements:
	  /// <PRE>bezierVertex(x5, y5, x6, y6, x7, y7)
	  /// </PRE>
	  /// To draw a quadratic (instead of cubic) curve,
	  /// use the control point twice by doubling it:
	  /// <PRE>bezier(x1, y1, cx, cy, cx, cy, x2, y2);</PRE>
	  /// 
	  /// @webref shape:curves </summary>
	  /// <param name="x1"> coordinates for the first anchor point </param>
	  /// <param name="y1"> coordinates for the first anchor point </param>
	  /// <param name="z1"> coordinates for the first anchor point </param>
	  /// <param name="x2"> coordinates for the first control point </param>
	  /// <param name="y2"> coordinates for the first control point </param>
	  /// <param name="z2"> coordinates for the first control point </param>
	  /// <param name="x3"> coordinates for the second control point </param>
	  /// <param name="y3"> coordinates for the second control point </param>
	  /// <param name="z3"> coordinates for the second control point </param>
	  /// <param name="x4"> coordinates for the second anchor point </param>
	  /// <param name="y4"> coordinates for the second anchor point </param>
	  /// <param name="z4"> coordinates for the second anchor point
	  /// </param>
	  /// <seealso cref= PGraphics#bezierVertex(float, float, float, float, float, float) </seealso>
	  /// <seealso cref= PGraphics#curve(float, float, float, float, float, float, float, float, float, float, float, float) </seealso>
	  public virtual void bezier(float x1, float y1, float z1, float x2, float y2, float z2, float x3, float y3, float z3, float x4, float y4, float z4)
	  {
		beginShape();
		vertex(x1, y1, z1);
		bezierVertex(x2, y2, z2, x3, y3, z3, x4, y4, z4);
		endShape();
	  }



	  //////////////////////////////////////////////////////////////

	  // CATMULL-ROM CURVE

	  /// <summary>
	  /// ( begin auto-generated from curvePoint.xml )
	  /// 
	  /// Evalutes the curve at point t for points a, b, c, d. The parameter t
	  /// varies between 0 and 1, a and d are points on the curve, and b and c are
	  /// the control points. This can be done once with the x coordinates and a
	  /// second time with the y coordinates to get the location of a curve at t.
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref shape:curves </summary>
	  /// <param name="a"> coordinate of first point on the curve </param>
	  /// <param name="b"> coordinate of second point on the curve </param>
	  /// <param name="c"> coordinate of third point on the curve </param>
	  /// <param name="d"> coordinate of fourth point on the curve </param>
	  /// <param name="t"> value between 0 and 1 </param>
	  /// <seealso cref= PGraphics#curve(float, float, float, float, float, float, float, float, float, float, float, float) </seealso>
	  /// <seealso cref= PGraphics#curveVertex(float, float) </seealso>
	  /// <seealso cref= PGraphics#bezierPoint(float, float, float, float, float) </seealso>
	  public virtual float curvePoint(float a, float b, float c, float d, float t)
	  {
		curveInitCheck();

		float tt = t * t;
		float ttt = t * tt;
		PMatrix3D cb = curveBasisMatrix;

		// not optimized (and probably need not be)
		return (a * (ttt * cb.m00 + tt * cb.m10 + t * cb.m20 + cb.m30) + b * (ttt * cb.m01 + tt * cb.m11 + t * cb.m21 + cb.m31) + c * (ttt * cb.m02 + tt * cb.m12 + t * cb.m22 + cb.m32) + d * (ttt * cb.m03 + tt * cb.m13 + t * cb.m23 + cb.m33));
	  }


	  /// <summary>
	  /// ( begin auto-generated from curveTangent.xml )
	  /// 
	  /// Calculates the tangent of a point on a curve. There's a good definition
	  /// of <em><a href="http://en.wikipedia.org/wiki/Tangent"
	  /// target="new">tangent</em> on Wikipedia</a>.
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// <h3>Advanced</h3>
	  /// Code thanks to Dave Bollinger (Bug #715)
	  /// 
	  /// @webref shape:curves </summary>
	  /// <param name="a"> coordinate of first point on the curve </param>
	  /// <param name="b"> coordinate of first control point </param>
	  /// <param name="c"> coordinate of second control point </param>
	  /// <param name="d"> coordinate of second point on the curve </param>
	  /// <param name="t"> value between 0 and 1 </param>
	  /// <seealso cref= PGraphics#curve(float, float, float, float, float, float, float, float, float, float, float, float) </seealso>
	  /// <seealso cref= PGraphics#curveVertex(float, float) </seealso>
	  /// <seealso cref= PGraphics#curvePoint(float, float, float, float, float) </seealso>
	  /// <seealso cref= PGraphics#bezierTangent(float, float, float, float, float) </seealso>
	  public virtual float curveTangent(float a, float b, float c, float d, float t)
	  {
		curveInitCheck();

		float tt3 = t * t * 3;
		float t2 = t * 2;
		PMatrix3D cb = curveBasisMatrix;

		// not optimized (and probably need not be)
		return (a * (tt3 * cb.m00 + t2 * cb.m10 + cb.m20) + b * (tt3 * cb.m01 + t2 * cb.m11 + cb.m21) + c * (tt3 * cb.m02 + t2 * cb.m12 + cb.m22) + d * (tt3 * cb.m03 + t2 * cb.m13 + cb.m23));
	  }


	  /// <summary>
	  /// ( begin auto-generated from curveDetail.xml )
	  /// 
	  /// Sets the resolution at which curves display. The default value is 20.
	  /// This function is only useful when using the P3D renderer as the default
	  /// P2D renderer does not use this information.
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref shape:curves </summary>
	  /// <param name="detail"> resolution of the curves </param>
	  /// <seealso cref= PGraphics#curve(float, float, float, float, float, float, float, float, float, float, float, float) </seealso>
	  /// <seealso cref= PGraphics#curveVertex(float, float) </seealso>
	  /// <seealso cref= PGraphics#curveTightness(float) </seealso>
	  public virtual void curveDetail(int detail)
	  {
		curveDetail_Renamed = detail;
		curveInit();
	  }


	  /// <summary>
	  /// ( begin auto-generated from curveTightness.xml )
	  /// 
	  /// Modifies the quality of forms created with <b>curve()</b> and
	  /// <b>curveVertex()</b>. The parameter <b>squishy</b> determines how the
	  /// curve fits to the vertex points. The value 0.0 is the default value for
	  /// <b>squishy</b> (this value defines the curves to be Catmull-Rom splines)
	  /// and the value 1.0 connects all the points with straight lines. Values
	  /// within the range -5.0 and 5.0 will deform the curves but will leave them
	  /// recognizable and as values increase in magnitude, they will continue to deform.
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref shape:curves </summary>
	  /// <param name="tightness"> amount of deformation from the original vertices </param>
	  /// <seealso cref= PGraphics#curve(float, float, float, float, float, float, float, float, float, float, float, float) </seealso>
	  /// <seealso cref= PGraphics#curveVertex(float, float) </seealso>
	  public virtual void curveTightness(float tightness)
	  {
		curveTightness_Renamed = tightness;
		curveInit();
	  }


	  protected internal virtual void curveInitCheck()
	  {
		if (!curveInited)
		{
		  curveInit();
		}
	  }


	  /// <summary>
	  /// Set the number of segments to use when drawing a Catmull-Rom
	  /// curve, and setting the s parameter, which defines how tightly
	  /// the curve fits to each vertex. Catmull-Rom curves are actually
	  /// a subset of this curve type where the s is set to zero.
	  /// <P>
	  /// (This function is not optimized, since it's not expected to
	  /// be called all that often. there are many juicy and obvious
	  /// opimizations in here, but it's probably better to keep the
	  /// code more readable)
	  /// </summary>
	  protected internal virtual void curveInit()
	  {
		// allocate only if/when used to save startup time
		if (curveDrawMatrix == null)
		{
		  curveBasisMatrix = new PMatrix3D();
		  curveDrawMatrix = new PMatrix3D();
		  curveInited = true;
		}

		float s = curveTightness_Renamed;
		curveBasisMatrix.set((s - 1) / 2f, (s + 3) / 2f, (-3 - s) / 2f, (1 - s) / 2f, (1 - s), (-5 - s) / 2f, (s + 2), (s - 1) / 2f, (s - 1) / 2f, 0, (1 - s) / 2f, 0, 0, 1, 0, 0);

		//setup_spline_forward(segments, curveForwardMatrix);
		splineForward(curveDetail_Renamed, curveDrawMatrix);

		if (bezierBasisInverse == null)
		{
		  bezierBasisInverse = bezierBasisMatrix.get() as PMatrix3D;
		  bezierBasisInverse.invert();
		  curveToBezierMatrix = new PMatrix3D();
		}

		// TODO only needed for PGraphicsJava2D? if so, move it there
		// actually, it's generally useful for other renderers, so keep it
		// or hide the implementation elsewhere.
		curveToBezierMatrix.set(curveBasisMatrix);
		curveToBezierMatrix.preApply(bezierBasisInverse);

		// multiply the basis and forward diff matrices together
		// saves much time since this needn't be done for each curve
		curveDrawMatrix.apply(curveBasisMatrix);
	  }


	  /// <summary>
	  /// ( begin auto-generated from curve.xml )
	  /// 
	  /// Draws a curved line on the screen. The first and second parameters
	  /// specify the beginning control point and the last two parameters specify
	  /// the ending control point. The middle parameters specify the start and
	  /// stop of the curve. Longer curves can be created by putting a series of
	  /// <b>curve()</b> functions together or using <b>curveVertex()</b>. An
	  /// additional function called <b>curveTightness()</b> provides control for
	  /// the visual quality of the curve. The <b>curve()</b> function is an
	  /// implementation of Catmull-Rom splines. Using the 3D version requires
	  /// rendering with P3D (see the Environment reference for more information).
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// <h3>Advanced</h3>
	  /// As of revision 0070, this function no longer doubles the first
	  /// and last points. The curves are a bit more boring, but it's more
	  /// mathematically correct, and properly mirrored in curvePoint().
	  /// <P>
	  /// Identical to typing out:<PRE>
	  /// beginShape();
	  /// curveVertex(x1, y1);
	  /// curveVertex(x2, y2);
	  /// curveVertex(x3, y3);
	  /// curveVertex(x4, y4);
	  /// endShape();
	  /// </PRE>
	  /// 
	  /// @webref shape:curves </summary>
	  /// <param name="x1"> coordinates for the beginning control point </param>
	  /// <param name="y1"> coordinates for the beginning control point </param>
	  /// <param name="x2"> coordinates for the first point </param>
	  /// <param name="y2"> coordinates for the first point </param>
	  /// <param name="x3"> coordinates for the second point </param>
	  /// <param name="y3"> coordinates for the second point </param>
	  /// <param name="x4"> coordinates for the ending control point </param>
	  /// <param name="y4"> coordinates for the ending control point </param>
	  /// <seealso cref= PGraphics#curveVertex(float, float) </seealso>
	  /// <seealso cref= PGraphics#curveTightness(float) </seealso>
	  /// <seealso cref= PGraphics#bezier(float, float, float, float, float, float, float, float, float, float, float, float) </seealso>
	  public virtual void curve(float x1, float y1, float x2, float y2, float x3, float y3, float x4, float y4)
	  {
		beginShape();
		curveVertex(x1, y1);
		curveVertex(x2, y2);
		curveVertex(x3, y3);
		curveVertex(x4, y4);
		endShape();
	  }

	   /// <param name="z1"> coordinates for the beginning control point </param>
	   /// <param name="z2"> coordinates for the first point </param>
	   /// <param name="z3"> coordinates for the second point </param>
	   /// <param name="z4"> coordinates for the ending control point </param>
	  public virtual void curve(float x1, float y1, float z1, float x2, float y2, float z2, float x3, float y3, float z3, float x4, float y4, float z4)
	  {
		beginShape();
		curveVertex(x1, y1, z1);
		curveVertex(x2, y2, z2);
		curveVertex(x3, y3, z3);
		curveVertex(x4, y4, z4);
		endShape();
	  }



	  //////////////////////////////////////////////////////////////

	  // SPLINE UTILITY FUNCTIONS (used by both Bezier and Catmull-Rom)


	  /// <summary>
	  /// Setup forward-differencing matrix to be used for speedy
	  /// curve rendering. It's based on using a specific number
	  /// of curve segments and just doing incremental adds for each
	  /// vertex of the segment, rather than running the mathematically
	  /// expensive cubic equation. </summary>
	  /// <param name="segments"> number of curve segments to use when drawing </param>
	  /// <param name="matrix"> target object for the new matrix </param>
	  protected internal virtual void splineForward(int segments, PMatrix3D matrix)
	  {
		float f = 1.0f / segments;
		float ff = f * f;
		float fff = ff * f;

		matrix.set(0, 0, 0, 1, fff, ff, f, 0, 6 * fff, 2 * ff, 0, 0, 6 * fff, 0, 0, 0);
	  }



	  //////////////////////////////////////////////////////////////

	  // SMOOTHING


	  /// <summary>
	  /// If true in PImage, use bilinear interpolation for copy()
	  /// operations. When inherited by PGraphics, also controls shapes.
	  /// </summary>

	  /// <summary>
	  /// ( begin auto-generated from smooth.xml )
	  /// 
	  /// Draws all geometry with smooth (anti-aliased) edges. This will sometimes
	  /// slow down the frame rate of the application, but will enhance the visual
	  /// refinement. Note that <b>smooth()</b> will also improve image quality of
	  /// resized images, and <b>noSmooth()</b> will disable image (and font)
	  /// smoothing altogether.
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref shape:attributes </summary>
	  /// <seealso cref= PGraphics#noSmooth() </seealso>
	  /// <seealso cref= PGraphics#hint(int) </seealso>
	  /// <seealso cref= PApplet#size(int, int, String) </seealso>
	  public virtual void smooth()
	  {
		smooth_Renamed = true;
	  }

	  /// 
	  /// <param name="level"> either 2, 4, or 8 </param>
	  public virtual void smooth(int level)
	  {
		smooth_Renamed = true;
	  }

	  /// <summary>
	  /// ( begin auto-generated from noSmooth.xml )
	  /// 
	  /// Draws all geometry with jagged (aliased) edges.
	  /// 
	  /// ( end auto-generated )
	  /// @webref shape:attributes </summary>
	  /// <seealso cref= PGraphics#smooth() </seealso>
	  public virtual void noSmooth()
	  {
		smooth_Renamed = false;
	  }



	  //////////////////////////////////////////////////////////////

	  // IMAGE


	  /// <summary>
	  /// ( begin auto-generated from imageMode.xml )
	  /// 
	  /// Modifies the location from which images draw. The default mode is
	  /// <b>imageMode(CORNER)</b>, which specifies the location to be the upper
	  /// left corner and uses the fourth and fifth parameters of <b>image()</b>
	  /// to set the image's width and height. The syntax
	  /// <b>imageMode(CORNERS)</b> uses the second and third parameters of
	  /// <b>image()</b> to set the location of one corner of the image and uses
	  /// the fourth and fifth parameters to set the opposite corner. Use
	  /// <b>imageMode(CENTER)</b> to draw images centered at the given x and y
	  /// position.<br />
	  /// <br />
	  /// The parameter to <b>imageMode()</b> must be written in ALL CAPS because
	  /// Processing is a case-sensitive language.
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref image:loading_displaying </summary>
	  /// <param name="mode"> either CORNER, CORNERS, or CENTER </param>
	  /// <seealso cref= PApplet#loadImage(String, String) </seealso>
	  /// <seealso cref= PImage </seealso>
	  /// <seealso cref= PGraphics#image(PImage, float, float, float, float) </seealso>
	  /// <seealso cref= PGraphics#background(float, float, float, float) </seealso>
	  public virtual void imageMode(int mode)
	  {
		if ((mode == PConstants_Fields.CORNER) || (mode == PConstants_Fields.CORNERS) || (mode == PConstants_Fields.CENTER))
		{
		  imageMode_Renamed = mode;
		}
		else
		{
		  string msg = "imageMode() only works with CORNER, CORNERS, or CENTER";
		  throw new Exception(msg);
		}
	  }


	  /// <summary>
	  /// ( begin auto-generated from image.xml )
	  /// 
	  /// Displays images to the screen. The images must be in the sketch's "data"
	  /// directory to load correctly. Select "Add file..." from the "Sketch" menu
	  /// to add the image. Processing currently works with GIF, JPEG, and Targa
	  /// images. The <b>img</b> parameter specifies the image to display and the
	  /// <b>x</b> and <b>y</b> parameters define the location of the image from
	  /// its upper-left corner. The image is displayed at its original size
	  /// unless the <b>width</b> and <b>height</b> parameters specify a different
	  /// size.<br />
	  /// <br />
	  /// The <b>imageMode()</b> function changes the way the parameters work. For
	  /// example, a call to <b>imageMode(CORNERS)</b> will change the
	  /// <b>width</b> and <b>height</b> parameters to define the x and y values
	  /// of the opposite corner of the image.<br />
	  /// <br />
	  /// The color of an image may be modified with the <b>tint()</b> function.
	  /// This function will maintain transparency for GIF and PNG images.
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// <h3>Advanced</h3>
	  /// Starting with release 0124, when using the default (JAVA2D) renderer,
	  /// smooth() will also improve image quality of resized images.
	  /// 
	  /// @webref image:loading_displaying </summary>
	  /// <param name="img"> the image to display </param>
	  /// <param name="a"> x-coordinate of the image </param>
	  /// <param name="b"> y-coordinate of the image </param>
	  /// <seealso cref= PApplet#loadImage(String, String) </seealso>
	  /// <seealso cref= PImage </seealso>
	  /// <seealso cref= PGraphics#imageMode(int) </seealso>
	  /// <seealso cref= PGraphics#tint(float) </seealso>
	  /// <seealso cref= PGraphics#background(float, float, float, float) </seealso>
	  /// <seealso cref= PGraphics#alpha(int) </seealso>
	  public virtual void image(PImage img, float a, float b)
	  {
		// Starting in release 0144, image errors are simply ignored.
		// loadImageAsync() sets width and height to -1 when loading fails.
		if (img.width == -1 || img.height == -1)
		{
			return;
		}

		if (imageMode_Renamed == PConstants_Fields.CORNER || imageMode_Renamed == PConstants_Fields.CORNERS)
		{
		  imageImpl(img, a, b, a + img.width, b + img.height, 0, 0, img.width, img.height);

		}
		else if (imageMode_Renamed == PConstants_Fields.CENTER)
		{
		  float x1 = a - img.width / 2;
		  float y1 = b - img.height / 2;
		  imageImpl(img, x1, y1, x1 + img.width, y1 + img.height, 0, 0, img.width, img.height);
		}
	  }

	  /// <param name="c"> width to display the image </param>
	  /// <param name="d"> height to display the image </param>
	  public virtual void image(PImage img, float a, float b, float c, float d)
	  {
		image(img, a, b, c, d, 0, 0, img.width, img.height);
	  }


	  /// <summary>
	  /// Draw an image(), also specifying u/v coordinates.
	  /// In this method, the  u, v coordinates are always based on image space
	  /// location, regardless of the current textureMode().
	  /// 
	  /// @nowebref
	  /// </summary>
	  public virtual void image(PImage img, float a, float b, float c, float d, int u1, int v1, int u2, int v2)
	  {
		// Starting in release 0144, image errors are simply ignored.
		// loadImageAsync() sets width and height to -1 when loading fails.
		if (img.width == -1 || img.height == -1)
		{
			return;
		}

		if (imageMode_Renamed == PConstants_Fields.CORNER)
		{
		  if (c < 0) // reset a negative width
		  {
			a += c;
			c = -c;
		  }
		  if (d < 0) // reset a negative height
		  {
			b += d;
			d = -d;
		  }

		  imageImpl(img, a, b, a + c, b + d, u1, v1, u2, v2);

		}
		else if (imageMode_Renamed == PConstants_Fields.CORNERS)
		{
		  if (c < a) // reverse because x2 < x1
		  {
			float temp = a;
			a = c;
			c = temp;
		  }
		  if (d < b) // reverse because y2 < y1
		  {
			float temp = b;
			b = d;
			d = temp;
		  }

		  imageImpl(img, a, b, c, d, u1, v1, u2, v2);

		}
		else if (imageMode_Renamed == PConstants_Fields.CENTER)
		{
		  // c and d are width/height
		  if (c < 0)
		  {
			  c = -c;
		  }
		  if (d < 0)
		  {
			  d = -d;
		  }
		  float x1 = a - c / 2;
		  float y1 = b - d / 2;

		  imageImpl(img, x1, y1, x1 + c, y1 + d, u1, v1, u2, v2);
		}
	  }


	  /// <summary>
	  /// Expects x1, y1, x2, y2 coordinates where (x2 >= x1) and (y2 >= y1).
	  /// If tint() has been called, the image will be colored.
	  /// <p/>
	  /// The default implementation draws an image as a textured quad.
	  /// The (u, v) coordinates are in image space (they're ints, after all..)
	  /// </summary>
	  protected internal virtual void imageImpl(PImage img, float x1, float y1, float x2, float y2, int u1, int v1, int u2, int v2)
	  {
		bool savedStroke = stroke_Renamed;
	//    boolean savedFill = fill;
		int savedTextureMode = textureMode_Renamed;

		stroke_Renamed = false;
	//    fill = true;
		textureMode_Renamed = PConstants_Fields.IMAGE;

	//    float savedFillR = fillR;
	//    float savedFillG = fillG;
	//    float savedFillB = fillB;
	//    float savedFillA = fillA;
	//
	//    if (tint) {
	//      fillR = tintR;
	//      fillG = tintG;
	//      fillB = tintB;
	//      fillA = tintA;
	//
	//    } else {
	//      fillR = 1;
	//      fillG = 1;
	//      fillB = 1;
	//      fillA = 1;
	//    }

		beginShape(PConstants_Fields.QUADS);
		texture(img);
		vertex(x1, y1, u1, v1);
		vertex(x1, y2, u1, v2);
		vertex(x2, y2, u2, v2);
		vertex(x2, y1, u2, v1);
		endShape();

		stroke_Renamed = savedStroke;
	//    fill = savedFill;
		textureMode_Renamed = savedTextureMode;

	//    fillR = savedFillR;
	//    fillG = savedFillG;
	//    fillB = savedFillB;
	//    fillA = savedFillA;
	  }


	  //////////////////////////////////////////////////////////////

	  // SHAPE


	  /// <summary>
	  /// ( begin auto-generated from shapeMode.xml )
	  /// 
	  /// Modifies the location from which shapes draw. The default mode is
	  /// <b>shapeMode(CORNER)</b>, which specifies the location to be the upper
	  /// left corner of the shape and uses the third and fourth parameters of
	  /// <b>shape()</b> to specify the width and height. The syntax
	  /// <b>shapeMode(CORNERS)</b> uses the first and second parameters of
	  /// <b>shape()</b> to set the location of one corner and uses the third and
	  /// fourth parameters to set the opposite corner. The syntax
	  /// <b>shapeMode(CENTER)</b> draws the shape from its center point and uses
	  /// the third and forth parameters of <b>shape()</b> to specify the width
	  /// and height. The parameter must be written in "ALL CAPS" because
	  /// Processing is a case sensitive language.
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref shape:loading_displaying </summary>
	  /// <param name="mode"> either CORNER, CORNERS, CENTER </param>
	  /// <seealso cref= PShape </seealso>
	  /// <seealso cref= PGraphics#shape(PShape) </seealso>
	  /// <seealso cref= PGraphics#rectMode(int) </seealso>
	  public virtual void shapeMode(int mode)
	  {
		this.shapeMode_Renamed = mode;
	  }


	  public virtual void shape(PShape shape)
	  {
		if (shape.Visible) // don't do expensive matrix ops if invisible
		{
		  // Flushing any remaining geometry generated in the immediate mode
		  // to avoid depth-sorting issues.
		  flush();

		  if (shapeMode_Renamed == PConstants_Fields.CENTER)
		  {
			pushMatrix();
			translate(-shape.Width / 2, -shape.Height / 2);
		  }

		  shape.draw(this); // needs to handle recorder too

		  if (shapeMode_Renamed == PConstants_Fields.CENTER)
		  {
			popMatrix();
		  }
		}
	  }



	  /// <summary>
	  /// ( begin auto-generated from shape.xml )
	  /// 
	  /// Displays shapes to the screen. The shapes must be in the sketch's "data"
	  /// directory to load correctly. Select "Add file..." from the "Sketch" menu
	  /// to add the shape. Processing currently works with SVG shapes only. The
	  /// <b>sh</b> parameter specifies the shape to display and the <b>x</b> and
	  /// <b>y</b> parameters define the location of the shape from its upper-left
	  /// corner. The shape is displayed at its original size unless the
	  /// <b>width</b> and <b>height</b> parameters specify a different size. The
	  /// <b>shapeMode()</b> function changes the way the parameters work. A call
	  /// to <b>shapeMode(CORNERS)</b>, for example, will change the width and
	  /// height parameters to define the x and y values of the opposite corner of
	  /// the shape.
	  /// <br /><br />
	  /// Note complex shapes may draw awkwardly with P3D. This renderer does not
	  /// yet support shapes that have holes or complicated breaks.
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref shape:loading_displaying </summary>
	  /// <param name="shape"> the shape to display </param>
	  /// <param name="x"> x-coordinate of the shape </param>
	  /// <param name="y"> y-coordinate of the shape </param>
	  /// <seealso cref= PShape </seealso>
	  /// <seealso cref= PApplet#loadShape(String) </seealso>
	  /// <seealso cref= PGraphics#shapeMode(int)
	  /// 
	  /// Convenience method to draw at a particular location. </seealso>
	  public virtual void shape(PShape shape, float x, float y)
	  {
		if (shape.Visible) // don't do expensive matrix ops if invisible
		{
		  flush();

		  pushMatrix();

		  if (shapeMode_Renamed == PConstants_Fields.CENTER)
		  {
			translate(x - shape.Width / 2, y - shape.Height / 2);

		  }
		  else if ((shapeMode_Renamed == PConstants_Fields.CORNER) || (shapeMode_Renamed == PConstants_Fields.CORNERS))
		  {
			translate(x, y);
		  }
		  shape.draw(this);

		  popMatrix();
		}
	  }


	  // TODO unapproved
	  protected internal virtual void shape(PShape shape, float x, float y, float z)
	  {
		showMissingWarning("shape");
	  }


	  /// <param name="a"> x-coordinate of the shape </param>
	  /// <param name="b"> y-coordinate of the shape </param>
	  /// <param name="c"> width to display the shape </param>
	  /// <param name="d"> height to display the shape </param>
	  public virtual void shape(PShape shape, float a, float b, float c, float d)
	  {
		if (shape.Visible) // don't do expensive matrix ops if invisible
		{
		  flush();

		  pushMatrix();

		  if (shapeMode_Renamed == PConstants_Fields.CENTER)
		  {
			// x and y are center, c and d refer to a diameter
			translate(a - c / 2f, b - d / 2f);
			scale(c / shape.Width, d / shape.Height);

		  }
		  else if (shapeMode_Renamed == PConstants_Fields.CORNER)
		  {
			translate(a, b);
			scale(c / shape.Width, d / shape.Height);

		  }
		  else if (shapeMode_Renamed == PConstants_Fields.CORNERS)
		  {
			// c and d are x2/y2, make them into width/height
			c -= a;
			d -= b;
			// then same as above
			translate(a, b);
			scale(c / shape.Width, d / shape.Height);
		  }
		  shape.draw(this);

		  popMatrix();
		}
	  }


	  // TODO unapproved
	  protected internal virtual void shape(PShape shape, float x, float y, float z, float c, float d, float e)
	  {
		showMissingWarning("shape");
	  }


	  //////////////////////////////////////////////////////////////

	  // TEXT/FONTS


	  public virtual void textAlign(int alignX)
	  {
		textAlign(alignX, PConstants_Fields.BASELINE);
	  }


	  /// <summary>
	  /// ( begin auto-generated from textAlign.xml )
	  /// 
	  /// Sets the current alignment for drawing text. The parameters LEFT,
	  /// CENTER, and RIGHT set the display characteristics of the letters in
	  /// relation to the values for the <b>x</b> and <b>y</b> parameters of the
	  /// <b>text()</b> function.
	  /// <br/> <br/>
	  /// In Processing 0125 and later, an optional second parameter can be used
	  /// to vertically align the text. BASELINE is the default, and the vertical
	  /// alignment will be reset to BASELINE if the second parameter is not used.
	  /// The TOP and CENTER parameters are straightforward. The BOTTOM parameter
	  /// offsets the line based on the current <b>textDescent()</b>. For multiple
	  /// lines, the final line will be aligned to the bottom, with the previous
	  /// lines appearing above it.
	  /// <br/> <br/>
	  /// When using <b>text()</b> with width and height parameters, BASELINE is
	  /// ignored, and treated as TOP. (Otherwise, text would by default draw
	  /// outside the box, since BASELINE is the default setting. BASELINE is not
	  /// a useful drawing mode for text drawn in a rectangle.)
	  /// <br/> <br/>
	  /// The vertical alignment is based on the value of <b>textAscent()</b>,
	  /// which many fonts do not specify correctly. It may be necessary to use a
	  /// hack and offset by a few pixels by hand so that the offset looks
	  /// correct. To do this as less of a hack, use some percentage of
	  /// <b>textAscent()</b> or <b>textDescent()</b> so that the hack works even
	  /// if you change the size of the font.
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref typography:attributes </summary>
	  /// <param name="alignX"> horizontal alignment, either LEFT, CENTER, or RIGHT </param>
	  /// <param name="alignY"> vertical alignment, either TOP, BOTTOM, CENTER, or BASELINE </param>
	  /// <seealso cref= PApplet#loadFont(String) </seealso>
	  /// <seealso cref= PFont </seealso>
	  /// <seealso cref= PGraphics#text(String, float, float) </seealso>
	  public virtual void textAlign(int alignX, int alignY)
	  {
		textAlign_Renamed = alignX;
		textAlignY = alignY;
	  }


	  /// <summary>
	  /// ( begin auto-generated from textAscent.xml )
	  /// 
	  /// Returns ascent of the current font at its current size. This information
	  /// is useful for determining the height of the font above the baseline. For
	  /// example, adding the <b>textAscent()</b> and <b>textDescent()</b> values
	  /// will give you the total height of the line.
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref typography:metrics </summary>
	  /// <seealso cref= PGraphics#textDescent() </seealso>
	  public virtual float textAscent()
	  {
			//TODO: after PFont
//		if (textFont_Renamed == null)
//		{
//		  defaultFontOrDeath("textAscent");
//		}
//		return textFont_Renamed.ascent() * textSize_Renamed;
			return 0.0f;
	  }


	  /// <summary>
	  /// ( begin auto-generated from textDescent.xml )
	  /// 
	  /// Returns descent of the current font at its current size. This
	  /// information is useful for determining the height of the font below the
	  /// baseline. For example, adding the <b>textAscent()</b> and
	  /// <b>textDescent()</b> values will give you the total height of the line.
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref typography:metrics </summary>
	  /// <seealso cref= PGraphics#textAscent() </seealso>
	  public virtual float textDescent()
	  {
			// TODO: After PFont
//		if (textFont_Renamed == null)
//		{
//		  defaultFontOrDeath("textDescent");
//		}
//		return textFont_Renamed.descent() * textSize_Renamed;
			return 0.0f;
	  }


	  /// <summary>
	  /// ( begin auto-generated from textFont.xml )
	  /// 
	  /// Sets the current font that will be drawn with the <b>text()</b>
	  /// function. Fonts must be loaded with <b>loadFont()</b> before it can be
	  /// used. This font will be used in all subsequent calls to the
	  /// <b>text()</b> function. If no <b>size</b> parameter is input, the font
	  /// will appear at its original size (the size it was created at with the
	  /// "Create Font..." tool) until it is changed with <b>textSize()</b>. <br
	  /// /> <br /> Because fonts are usually bitmaped, you should create fonts at
	  /// the sizes that will be used most commonly. Using <b>textFont()</b>
	  /// without the size parameter will result in the cleanest-looking text. <br
	  /// /><br /> With the default (JAVA2D) and PDF renderers, it's also possible
	  /// to enable the use of native fonts via the command
	  /// <b>hint(ENABLE_NATIVE_FONTS)</b>. This will produce vector text in
	  /// JAVA2D sketches and PDF output in cases where the vector data is
	  /// available: when the font is still installed, or the font is created via
	  /// the <b>createFont()</b> function (rather than the Create Font tool).
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref typography:loading_displaying </summary>
	  /// <param name="which"> any variable of the type PFont </param>
	  /// <seealso cref= PApplet#createFont(String, float, boolean) </seealso>
	  /// <seealso cref= PApplet#loadFont(String) </seealso>
	  /// <seealso cref= PFont </seealso>
	  /// <seealso cref= PGraphics#text(String, float, float) </seealso>
		/// 
	// TODO: not like this
//	  public virtual void textFont(PFont which)
//	  {
//		if (which != null)
//		{
//		  textFont_Renamed = which;
//	//      if (hints[ENABLE_NATIVE_FONTS]) {
//	//        //if (which.font == null) {
//	//        which.findNative();
//	//        //}
//	//      }
//		  /*
//		  textFontNative = which.font;
//	
//		  //textFontNativeMetrics = null;
//		  // changed for rev 0104 for textMode(SHAPE) in opengl
//		  if (textFontNative != null) {
//		    // TODO need a better way to handle this. could use reflection to get
//		    // rid of the warning, but that'd be a little silly. supporting this is
//		    // an artifact of supporting java 1.1, otherwise we'd use getLineMetrics,
//		    // as recommended by the @deprecated flag.
//		    textFontNativeMetrics =
//		      Toolkit.getDefaultToolkit().getFontMetrics(textFontNative);
//		    // The following is what needs to be done, however we need to be able
//		    // to get the actual graphics context where the drawing is happening.
//		    // For instance, parent.getGraphics() doesn't work for OpenGL since
//		    // an OpenGL drawing surface is an embedded component.
//	//        if (parent != null) {
//	//          textFontNativeMetrics = parent.getGraphics().getFontMetrics(textFontNative);
//	//        }
//	
//		    // float w = font.getStringBounds(text, g2.getFontRenderContext()).getWidth();
//		  }
//		  */
//		  textSize(which.size);
//
//		}
//		else
//		{
//		  throw new Exception(PConstants_Fields.ERROR_TEXTFONT_NULL_PFONT);
//		}
//	  }
//
//
//	  /// <param name="size"> the size of the letters in units of pixels </param>
//	  public virtual void textFont(PFont which, float size)
//	  {
//		textFont(which);
//		textSize(size);
//	  }


	  /// <summary>
	  /// ( begin auto-generated from textLeading.xml )
	  /// 
	  /// Sets the spacing between lines of text in units of pixels. This setting
	  /// will be used in all subsequent calls to the <b>text()</b> function.
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref typography:attributes </summary>
	  /// <param name="leading"> the size in pixels for spacing between lines </param>
	  /// <seealso cref= PApplet#loadFont(String) </seealso>
	  /// <seealso cref= PFont#PFont </seealso>
	  /// <seealso cref= PGraphics#text(String, float, float) </seealso>
	  /// <seealso cref= PGraphics#textFont(PFont) </seealso>
	  public virtual void textLeading(float leading)
	  {
		textLeading_Renamed = leading;
	  }


	  /// <summary>
	  /// ( begin auto-generated from textMode.xml )
	  /// 
	  /// Sets the way text draws to the screen. In the default configuration, the
	  /// <b>MODEL</b> mode, it's possible to rotate, scale, and place letters in
	  /// two and three dimensional space.<br />
	  /// <br />
	  /// The <b>SHAPE</b> mode draws text using the the glyph outlines of
	  /// individual characters rather than as textures. This mode is only
	  /// supported with the <b>PDF</b> and <b>P3D</b> renderer settings. With the
	  /// <b>PDF</b> renderer, you must call <b>textMode(SHAPE)</b> before any
	  /// other drawing occurs. If the outlines are not available, then
	  /// <b>textMode(SHAPE)</b> will be ignored and <b>textMode(MODEL)</b> will
	  /// be used instead.<br />
	  /// <br />
	  /// The <b>textMode(SHAPE)</b> option in <b>P3D</b> can be combined with
	  /// <b>beginRaw()</b> to write vector-accurate text to 2D and 3D output
	  /// files, for instance <b>DXF</b> or <b>PDF</b>. The <b>SHAPE</b> mode is
	  /// not currently optimized for <b>P3D</b>, so if recording shape data, use
	  /// <b>textMode(MODEL)</b> until you're ready to capture the geometry with <b>beginRaw()</b>.
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref typography:attributes </summary>
	  /// <param name="mode"> either MODEL or SHAPE </param>
	  /// <seealso cref= PApplet#loadFont(String) </seealso>
	  /// <seealso cref= PFont#PFont </seealso>
	  /// <seealso cref= PGraphics#text(String, float, float) </seealso>
	  /// <seealso cref= PGraphics#textFont(PFont) </seealso>
	  /// <seealso cref= PGraphics#beginRaw(PGraphics) </seealso>
	  /// <seealso cref= PApplet#createFont(String, float, boolean) </seealso>
	  public virtual void textMode(int mode)
	  {
		// CENTER and MODEL overlap (they're both 3)
		if ((mode == PConstants_Fields.LEFT) || (mode == PConstants_Fields.RIGHT))
		{
		  showWarning("Since Processing 1.0 beta, textMode() is now textAlign().");
		  return;
		}
		if (mode == PConstants_Fields.SCREEN)
		{
		  showWarning("textMode(SCREEN) has been removed from Processing 2.0.");
		  return;
		}

		if (textModeCheck(mode))
		{
		  textMode_Renamed = mode;
		}
		else
		{
		  string modeStr = Convert.ToString(mode);
		  switch (mode)
		  {
			case PConstants_Fields.MODEL:
				modeStr = "MODEL";
				break;
			case PConstants_Fields.SHAPE:
				modeStr = "SHAPE";
				break;
		  }
		  showWarning("textMode(" + modeStr + ") is not supported by this renderer.");
		}
	  }


	  protected internal virtual bool textModeCheck(int mode)
	  {
		return true;
	  }


	  /// <summary>
	  /// ( begin auto-generated from textSize.xml )
	  /// 
	  /// Sets the current font size. This size will be used in all subsequent
	  /// calls to the <b>text()</b> function. Font size is measured in units of pixels.
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref typography:attributes </summary>
	  /// <param name="size"> the size of the letters in units of pixels </param>
	  /// <seealso cref= PApplet#loadFont(String) </seealso>
	  /// <seealso cref= PFont#PFont </seealso>
	  /// <seealso cref= PGraphics#text(String, float, float) </seealso>
	  /// <seealso cref= PGraphics#textFont(PFont) </seealso>
	  public virtual void textSize(float size)
	  {
			//TODO: after PFont
//		if (textFont_Renamed == null)
//		{
//		  defaultFontOrDeath("textSize", size);
//		}
//		textSize_Renamed = size;
//		textLeading_Renamed = (textAscent() + textDescent()) * 1.275f;
	  }


	  // ........................................................


	  /// <param name="c"> the character to measure </param>
	  public virtual float textWidth(char c)
	  {
		textWidthBuffer[0] = c;
		return textWidthImpl(textWidthBuffer, 0, 1);
	  }


	  /// <summary>
	  /// ( begin auto-generated from textWidth.xml )
	  /// 
	  /// Calculates and returns the width of any character or text string.
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref typography:attributes </summary>
	  /// <param name="str"> the String of characters to measure </param>
	  /// <seealso cref= PApplet#loadFont(String) </seealso>
	  /// <seealso cref= PFont#PFont </seealso>
	  /// <seealso cref= PGraphics#text(String, float, float) </seealso>
	  /// <seealso cref= PGraphics#textFont(PFont) </seealso>
	  public virtual float textWidth(string str)
	  {
			//TODO: after PFont
//			if (textFont_Renamed == null)
//		{
//		  defaultFontOrDeath("textWidth");
//		}
//
//		int length = str.Length;
//		if (length > textWidthBuffer.Length)
//		{
//		  textWidthBuffer = new char[length + 10];
//		}
//		str.CopyTo(0, textWidthBuffer, 0, length - 0);
//
//		float wide = 0;
//		int index = 0;
//		int start = 0;
//
//		while (index < length)
//		{
//		  if (textWidthBuffer[index] == '\n')
//		  {
//			wide = Math.Max(wide, textWidthImpl(textWidthBuffer, start, index));
//			start = index + 1;
//		  }
//		  index++;
//		}
//		if (start < length)
//		{
//		  wide = Math.Max(wide, textWidthImpl(textWidthBuffer, start, index));
//		}
//		return wide;
			return 0.0f;
	  }


	  /// <summary>
	  /// @nowebref
	  /// </summary>
	  public virtual float textWidth(char[] chars, int start, int length)
	  {
		return textWidthImpl(chars, start, start + length);
	  }


	  /// <summary>
	  /// Implementation of returning the text width of
	  /// the chars [start, stop) in the buffer.
	  /// Unlike the previous version that was inside PFont, this will
	  /// return the size not of a 1 pixel font, but the actual current size.
	  /// </summary>
	  protected internal virtual float textWidthImpl(char[] buffer, int start, int stop)
	  {
			//TODO: after PFont
			//		float wide = 0;
//		for (int i = start; i < stop; i++)
//		{
//		  // could add kerning here, but it just ain't implemented
//		  wide += textFont_Renamed.width(buffer[i]) * textSize_Renamed;
//		}
//		return wide;
			return 0.0f;
	  }


	  // ........................................................


	  /// <summary>
	  /// ( begin auto-generated from text.xml )
	  /// 
	  /// Draws text to the screen. Displays the information specified in the
	  /// <b>data</b> or <b>stringdata</b> parameters on the screen in the
	  /// position specified by the <b>x</b> and <b>y</b> parameters and the
	  /// optional <b>z</b> parameter. A default font will be used unless a font
	  /// is set with the <b>textFont()</b> function. Change the color of the text
	  /// with the <b>fill()</b> function. The text displays in relation to the
	  /// <b>textAlign()</b> function, which gives the option to draw to the left,
	  /// right, and center of the coordinates.
	  /// <br /><br />
	  /// The <b>x2</b> and <b>y2</b> parameters define a rectangular area to
	  /// display within and may only be used with string data. For text drawn
	  /// inside a rectangle, the coordinates are interpreted based on the current
	  /// <b>rectMode()</b> setting.
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref typography:loading_displaying </summary>
	  /// <param name="c"> the alphanumeric character to be displayed </param>
	  /// <param name="x"> x-coordinate of text </param>
	  /// <param name="y"> y-coordinate of text </param>
	  /// <seealso cref= PGraphics#textAlign(int, int) </seealso>
	  /// <seealso cref= PGraphics#textMode(int) </seealso>
	  /// <seealso cref= PApplet#loadFont(String) </seealso>
	  /// <seealso cref= PGraphics#textFont(PFont) </seealso>
	  /// <seealso cref= PGraphics#rectMode(int) </seealso>
	  /// <seealso cref= PGraphics#fill(int, float)
	  /// @see_external String </seealso>
	  public virtual void text(char c, float x, float y)
	  {
			//TODO: after PFont
//			if (textFont_Renamed == null)
//		{
//		  defaultFontOrDeath("text");
//		}
//
//		if (textAlignY == PConstants_Fields.CENTER)
//		{
//		  y += textAscent() / 2;
//		}
//		else if (textAlignY == PConstants_Fields.TOP)
//		{
//		  y += textAscent();
//		}
//		else if (textAlignY == PConstants_Fields.BOTTOM)
//		{
//		  y -= textDescent();
//		//} else if (textAlignY == BASELINE) {
//		  // do nothing
//		}
//
//		textBuffer[0] = c;
//		textLineAlignImpl(textBuffer, 0, 1, x, y);
	  }


	  /// <param name="z"> z-coordinate of text </param>
	  public virtual void text(char c, float x, float y, float z)
	  {
	//    if ((z != 0) && (textMode == SCREEN)) {
	//      String msg = "textMode(SCREEN) cannot have a z coordinate";
	//      throw new RuntimeException(msg);
	//    }

		if (z != 0) // slowness, badness
		{
			translate(0, 0, z);
		}

		text(c, x, y);
	//    textZ = z;

		if (z != 0)
		{
			translate(0, 0, -z);
		}
	  }


	  /// <param name="str"> the alphanumeric symbols to be displayed </param>
	//  public void text(String str) {
	//    text(str, textX, textY, textZ);
	//  }


	  /// <summary>
	  /// <h3>Advanced</h3>
	  /// Draw a chunk of text.
	  /// Newlines that are \n (Unix newline or linefeed char, ascii 10)
	  /// are honored, but \r (carriage return, Windows and Mac OS) are
	  /// ignored.
	  /// </summary>
	  public virtual void text(string str, float x, float y)
	  {
			//TODO: after PFont
//			if (textFont_Renamed == null)
//		{
//		  defaultFontOrDeath("text");
//		}
//
//		int length = str.Length;
//		if (length > textBuffer.Length)
//		{
//		  textBuffer = new char[length + 10];
//		}
//		str.CopyTo(0, textBuffer, 0, length - 0);
//		text(textBuffer, 0, length, x, y);
	  }


	  /// <summary>
	  /// <h3>Advanced</h3>
	  /// Method to draw text from an array of chars. This method will usually be
	  /// more efficient than drawing from a String object, because the String will
	  /// not be converted to a char array before drawing. </summary>
	  /// <param name="chars"> the alphanumberic symbols to be displayed </param>
	  /// <param name="start"> array index at which to start writing characters </param>
	  /// <param name="stop"> array index at which to stop writing characters </param>
	  public virtual void text(char[] chars, int start, int stop, float x, float y)
	  {
		// If multiple lines, sum the height of the additional lines
		float high = 0; //-textAscent();
		for (int i = start; i < stop; i++)
		{
		  if (chars[i] == '\n')
		  {
			high += textLeading_Renamed;
		  }
		}
		if (textAlignY == PConstants_Fields.CENTER)
		{
		  // for a single line, this adds half the textAscent to y
		  // for multiple lines, subtract half the additional height
		  //y += (textAscent() - textDescent() - high)/2;
		  y += (textAscent() - high) / 2;
		}
		else if (textAlignY == PConstants_Fields.TOP)
		{
		  // for a single line, need to add textAscent to y
		  // for multiple lines, no different
		  y += textAscent();
		}
		else if (textAlignY == PConstants_Fields.BOTTOM)
		{
		  // for a single line, this is just offset by the descent
		  // for multiple lines, subtract leading for each line
		  y -= textDescent() + high;
		//} else if (textAlignY == BASELINE) {
		  // do nothing
		}

	//    int start = 0;
		int index = 0;
		while (index < stop) //length) {
		{
		  if (chars[index] == '\n')
		  {
			textLineAlignImpl(chars, start, index, x, y);
			start = index + 1;
			y += textLeading_Renamed;
		  }
		  index++;
		}
		if (start < stop) //length) {
		{
		  textLineAlignImpl(chars, start, index, x, y);
		}
	  }


	  /// <summary>
	  /// Same as above but with a z coordinate.
	  /// </summary>
	  public virtual void text(string str, float x, float y, float z)
	  {
		if (z != 0) // slow!
		{
			translate(0, 0, z);
		}

		text(str, x, y);
	//    textZ = z;

		if (z != 0) // inaccurate!
		{
			translate(0, 0, -z);
		}
	  }


	  public virtual void text(char[] chars, int start, int stop, float x, float y, float z)
	  {
		if (z != 0) // slow!
		{
			translate(0, 0, z);
		}

		text(chars, start, stop, x, y);
	//    textZ = z;

		if (z != 0) // inaccurate!
		{
			translate(0, 0, -z);
		}
	  }


	  /// <summary>
	  /// <h3>Advanced</h3>
	  /// Draw text in a box that is constrained to a particular size.
	  /// The current rectMode() determines what the coordinates mean
	  /// (whether x1/y1/x2/y2 or x/y/w/h).
	  /// <P/>
	  /// Note that the x,y coords of the start of the box
	  /// will align with the *ascent* of the text, not the baseline,
	  /// as is the case for the other text() functions.
	  /// <P/>
	  /// Newlines that are \n (Unix newline or linefeed char, ascii 10)
	  /// are honored, and \r (carriage return, Windows and Mac OS) are
	  /// ignored.
	  /// </summary>
	  /// <param name="x1"> by default, the x-coordinate of text, see rectMode() for more info </param>
	  /// <param name="y1"> by default, the x-coordinate of text, see rectMode() for more info </param>
	  /// <param name="x2"> by default, the width of the text box, see rectMode() for more info </param>
	  /// <param name="y2"> by default, the height of the text box, see rectMode() for more info </param>
	  public virtual void text(string str, float x1, float y1, float x2, float y2)
	  {
			//TODO: after PFont
//			if (textFont_Renamed == null)
//		{
//		  defaultFontOrDeath("text");
//		}
//
//		float hradius, vradius;
//		switch (rectMode_Renamed)
//		{
//		case PConstants_Fields.CORNER:
//		  x2 += x1;
//		  y2 += y1;
//		  break;
//		case PConstants_Fields.RADIUS:
//		  hradius = x2;
//		  vradius = y2;
//		  x2 = x1 + hradius;
//		  y2 = y1 + vradius;
//		  x1 -= hradius;
//		  y1 -= vradius;
//		  break;
//		case PConstants_Fields.CENTER:
//		  hradius = x2 / 2.0f;
//		  vradius = y2 / 2.0f;
//		  x2 = x1 + hradius;
//		  y2 = y1 + vradius;
//		  x1 -= hradius;
//		  y1 -= vradius;
//	  break;
//		}
//		if (x2 < x1)
//		{
//		  float temp = x1;
//		  x1 = x2;
//		  x2 = temp;
//		}
//		if (y2 < y1)
//		{
//		  float temp = y1;
//		  y1 = y2;
//		  y2 = temp;
//		}
//
//	//    float currentY = y1;
//		float boxWidth = x2 - x1;
//
//	//    // ala illustrator, the text itself must fit inside the box
//	//    currentY += textAscent(); //ascent() * textSize;
//	//    // if the box is already too small, tell em to f off
//	//    if (currentY > y2) return;
//
//		float spaceWidth = textWidth(' ');
//
//		if (textBreakStart == null)
//		{
//		  textBreakStart = new int[20];
//		  textBreakStop = new int[20];
//		}
//		textBreakCount = 0;
//
//		int length = str.Length;
//		if (length + 1 > textBuffer.Length)
//		{
//		  textBuffer = new char[length + 1];
//		}
//		str.CopyTo(0, textBuffer, 0, length - 0);
//		// add a fake newline to simplify calculations
//		textBuffer[length++] = '\n';
//
//		int sentenceStart = 0;
//		for (int i = 0; i < length; i++)
//		{
//		  if (textBuffer[i] == '\n')
//		  {
//	//        currentY = textSentence(textBuffer, sentenceStart, i,
//	//                                lineX, boxWidth, currentY, y2, spaceWidth);
//			bool legit = textSentence(textBuffer, sentenceStart, i, boxWidth, spaceWidth);
//			if (!legit)
//			{
//				break;
//			}
//	//      if (Float.isNaN(currentY)) break;  // word too big (or error)
//	//      if (currentY > y2) break;  // past the box
//			sentenceStart = i + 1;
//		  }
//		}
//
//		// lineX is the position where the text starts, which is adjusted
//		// to left/center/right based on the current textAlign
//		float lineX = x1; //boxX1;
//		if (textAlign_Renamed == PConstants_Fields.CENTER)
//		{
//		  lineX = lineX + boxWidth / 2f;
//		}
//		else if (textAlign_Renamed == PConstants_Fields.RIGHT)
//		{
//		  lineX = x2; //boxX2;
//		}
//
//		float boxHeight = y2 - y1;
//		//int lineFitCount = 1 + PApplet.floor((boxHeight - textAscent()) / textLeading);
//		// incorporate textAscent() for the top (baseline will be y1 + ascent)
//		// and textDescent() for the bottom, so that lower parts of letters aren't
//		// outside the box. [0151]
//		float topAndBottom = textAscent() + textDescent();
//		int lineFitCount = 1 + PApplet.floor((boxHeight - topAndBottom) / textLeading_Renamed);
//		int lineCount = Math.Min(textBreakCount, lineFitCount);
//
//		if (textAlignY == PConstants_Fields.CENTER)
//		{
//		  float lineHigh = textAscent() + textLeading_Renamed * (lineCount - 1);
//		  float y = y1 + textAscent() + (boxHeight - lineHigh) / 2;
//		  for (int i = 0; i < lineCount; i++)
//		  {
//			textLineAlignImpl(textBuffer, textBreakStart[i], textBreakStop[i], lineX, y);
//			y += textLeading_Renamed;
//		  }
//
//		}
//		else if (textAlignY == PConstants_Fields.BOTTOM)
//		{
//		  float y = y2 - textDescent() - textLeading_Renamed * (lineCount - 1);
//		  for (int i = 0; i < lineCount; i++)
//		  {
//			textLineAlignImpl(textBuffer, textBreakStart[i], textBreakStop[i], lineX, y);
//			y += textLeading_Renamed;
//		  }
//
//		} // TOP or BASELINE just go to the default
//		else
//		{
//		  float y = y1 + textAscent();
//		  for (int i = 0; i < lineCount; i++)
//		  {
//			textLineAlignImpl(textBuffer, textBreakStart[i], textBreakStop[i], lineX, y);
//			y += textLeading_Renamed;
//		  }
//		}
	  }


	  /// <summary>
	  /// Emit a sentence of text, defined as a chunk of text without any newlines. </summary>
	  /// <param name="stop"> non-inclusive, the end of the text in question </param>
	  protected internal virtual bool textSentence(char[] buffer, int start, int stop, float boxWidth, float spaceWidth)
	  {
		float runningX = 0;

		// Keep track of this separately from index, since we'll need to back up
		// from index when breaking words that are too long to fit.
		int lineStart = start;
		int wordStart = start;
		int index = start;
		while (index <= stop)
		{
		  // boundary of a word or end of this sentence
		  if ((buffer[index] == ' ') || (index == stop))
		  {
			float wordWidth = textWidthImpl(buffer, wordStart, index);

			if (runningX + wordWidth > boxWidth)
			{
			  if (runningX != 0)
			  {
				// Next word is too big, output the current line and advance
				index = wordStart;
				textSentenceBreak(lineStart, index);
				// Eat whitespace because multiple spaces don't count for s*
				// when they're at the end of a line.
				while ((index < stop) && (buffer[index] == ' '))
				{
				  index++;
				}
			  } // (runningX == 0)
			  else
			  {
				// If this is the first word on the line, and its width is greater
				// than the width of the text box, then break the word where at the
				// max width, and send the rest of the word to the next line.
				do
				{
				  index--;
				  if (index == wordStart)
				  {
					// Not a single char will fit on this line. screw 'em.
					//System.out.println("screw you");
					return false; //Float.NaN;
				  }
				  wordWidth = textWidthImpl(buffer, wordStart, index);
				} while (wordWidth > boxWidth);

				//textLineImpl(buffer, lineStart, index, x, y);
				textSentenceBreak(lineStart, index);
			  }
			  lineStart = index;
			  wordStart = index;
			  runningX = 0;

			}
			else if (index == stop)
			{
			  // last line in the block, time to unload
			  //textLineImpl(buffer, lineStart, index, x, y);
			  textSentenceBreak(lineStart, index);
	//          y += textLeading;
			  index++;

			} // this word will fit, just add it to the line
			else
			{
			  runningX += wordWidth + spaceWidth;
			  wordStart = index + 1; // move on to the next word
			  index++;
			}
		  } // not a space or the last character
		  else
		  {
			index++; // this is just another letter
		  }
		}
	//    return y;
		return true;
	  }


	  protected internal virtual void textSentenceBreak(int start, int stop)
	  {
			//TODO: After PApplet
//		if (textBreakCount == textBreakStart.Length)
//		{
//		  textBreakStart = PApplet.expand(textBreakStart);
//		  textBreakStop = PApplet.expand(textBreakStop);
//		}
//		textBreakStart[textBreakCount] = start;
//		textBreakStop[textBreakCount] = stop;
//		textBreakCount++;
	  }


	//  public void text(String s, float a, float b, float c, float d, float z) {
	//    if (z != 0) translate(0, 0, z);  // slowness, badness
	//
	//    text(s, a, b, c, d);
	//    textZ = z;
	//
	//    if (z != 0) translate(0, 0, -z);  // TEMPORARY HACK! SLOW!
	//  }


	  public virtual void text(int num, float x, float y)
	  {
		text(Convert.ToString(num), x, y);
	  }


	  public virtual void text(int num, float x, float y, float z)
	  {
		text(Convert.ToString(num), x, y, z);
	  }


	  /// <summary>
	  /// This does a basic number formatting, to avoid the
	  /// generally ugly appearance of printing floats.
	  /// Users who want more control should use their own nf() cmmand,
	  /// or if they want the long, ugly version of float,
	  /// use String.valueOf() to convert the float to a String first.
	  /// </summary>
	  /// <param name="num"> the numeric value to be displayed </param>
	  public virtual void text(float num, float x, float y)
	  {
			//TODO: After PApplet
//			text(PApplet.nfs(num, 0, 3), x, y);
	  }


	  public virtual void text(float num, float x, float y, float z)
	  {
			//TODO: After PApplet
//			text(PApplet.nfs(num, 0, 3), x, y, z);
	  }


	  //////////////////////////////////////////////////////////////

	  // TEXT IMPL

	  // These are most likely to be overridden by subclasses, since the other
	  // (public) functions handle generic features like setting alignment.


	  /// <summary>
	  /// Handles placement of a text line, then calls textLineImpl
	  /// to actually render at the specific point.
	  /// </summary>
	  protected internal virtual void textLineAlignImpl(char[] buffer, int start, int stop, float x, float y)
	  {
		if (textAlign_Renamed == PConstants_Fields.CENTER)
		{
		  x -= textWidthImpl(buffer, start, stop) / 2f;

		}
		else if (textAlign_Renamed == PConstants_Fields.RIGHT)
		{
		  x -= textWidthImpl(buffer, start, stop);
		}

		textLineImpl(buffer, start, stop, x, y);
	  }


	  /// <summary>
	  /// Implementation of actual drawing for a line of text.
	  /// </summary>
	  protected internal virtual void textLineImpl(char[] buffer, int start, int stop, float x, float y)
	  {
		for (int index = start; index < stop; index++)
		{
		  textCharImpl(buffer[index], x, y);

		  // this doesn't account for kerning
		  x += textWidth(buffer[index]);
		}
	//    textX = x;
	//    textY = y;
	//    textZ = 0;  // this will get set by the caller if non-zero
	  }


	  protected internal virtual void textCharImpl(char ch, float x, float y) //, float z) {
	  {
			//TODO: After PFont
//
//		PFont.Glyph glyph = textFont_Renamed.getGlyph(ch);
//		if (glyph != null)
//		{
//		  if (textMode_Renamed == PConstants_Fields.MODEL)
//		  {
//			float high = glyph.height / (float) textFont_Renamed.size;
//			float bwidth = glyph.width / (float) textFont_Renamed.size;
//			float lextent = glyph.leftExtent / (float) textFont_Renamed.size;
//			float textent = glyph.topExtent / (float) textFont_Renamed.size;
//
//			float x1 = x + lextent * textSize_Renamed;
//			float y1 = y - textent * textSize_Renamed;
//			float x2 = x1 + bwidth * textSize_Renamed;
//			float y2 = y1 + high * textSize_Renamed;
//
//			textCharModelImpl(glyph.image, x1, y1, x2, y2, glyph.width, glyph.height);
//		  }
//		}
//		else if (ch != ' ' && ch != 127)
//		{
//		  showWarning("No glyph found for the " + ch + " (\\u" + PApplet.hex(ch, 4) + ") character");
//		}
	  }


	  protected internal virtual void textCharModelImpl(PImage glyph, float x1, float y1, float x2, float y2, int u2, int v2) //float z2, - float z1,
	  {
		bool savedTint = tint_Renamed;
		int savedTintColor = tintColor;
		float savedTintR = tintR;
		float savedTintG = tintG;
		float savedTintB = tintB;
		float savedTintA = tintA;
		bool savedTintAlpha = tintAlpha;

		tint_Renamed = true;
		tintColor = fillColor;
		tintR = fillR;
		tintG = fillG;
		tintB = fillB;
		tintA = fillA;
		tintAlpha = fillAlpha;

		imageImpl(glyph, x1, y1, x2, y2, 0, 0, u2, v2);

		tint_Renamed = savedTint;
		tintColor = savedTintColor;
		tintR = savedTintR;
		tintG = savedTintG;
		tintB = savedTintB;
		tintA = savedTintA;
		tintAlpha = savedTintAlpha;
	  }


	  protected internal virtual void textCharScreenImpl(PImage glyph, int xx, int yy, int w0, int h0)
	  {
		int x0 = 0;
		int y0 = 0;

		if ((xx >= width) || (yy >= height) || (xx + w0 < 0) || (yy + h0 < 0))
		{
			return;
		}

		if (xx < 0)
		{
		  x0 -= xx;
		  w0 += xx;
		  xx = 0;
		}
		if (yy < 0)
		{
		  y0 -= yy;
		  h0 += yy;
		  yy = 0;
		}
		if (xx + w0 > width)
		{
		  w0 -= ((xx + w0) - width);
		}
		if (yy + h0 > height)
		{
		  h0 -= ((yy + h0) - height);
		}

		int fr = fillRi;
		int fg = fillGi;
		int fb = fillBi;
		int fa = fillAi;

		int[] pixels1 = glyph.pixels; //images[glyph].pixels;

		// TODO this can be optimized a bit
		for (int row = y0; row < y0 + h0; row++)
		{
		  for (int col = x0; col < x0 + w0; col++)
		  {
			//int a1 = (fa * pixels1[row * textFont.twidth + col]) >> 8;
			int a1 = (fa * pixels1[row * glyph.width + col]) >> 8;
			int a2 = a1 ^ 0xff;
			//int p1 = pixels1[row * glyph.width + col];
			int p2 = pixels[(yy + row - y0) * width + (xx + col - x0)];

			pixels[(yy + row - y0) * width + xx + col - x0] = (unchecked((int)0xff000000) | (((a1 * fr + a2 * ((p2 >> 16) & 0xff)) & 0xff00) << 8) | ((a1 * fg + a2 * ((p2 >> 8) & 0xff)) & 0xff00) | ((a1 * fb + a2 * (p2 & 0xff)) >> 8));
		  }
		}
	  }



	  //////////////////////////////////////////////////////////////

	  // MATRIX STACK


	  /// <summary>
	  /// ( begin auto-generated from pushMatrix.xml )
	  /// 
	  /// Pushes the current transformation matrix onto the matrix stack.
	  /// Understanding <b>pushMatrix()</b> and <b>popMatrix()</b> requires
	  /// understanding the concept of a matrix stack. The <b>pushMatrix()</b>
	  /// function saves the current coordinate system to the stack and
	  /// <b>popMatrix()</b> restores the prior coordinate system.
	  /// <b>pushMatrix()</b> and <b>popMatrix()</b> are used in conjuction with
	  /// the other transformation functions and may be embedded to control the
	  /// scope of the transformations.
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref transform </summary>
	  /// <seealso cref= PGraphics#popMatrix() </seealso>
	  /// <seealso cref= PGraphics#translate(float, float, float) </seealso>
	  /// <seealso cref= PGraphics#rotate(float) </seealso>
	  /// <seealso cref= PGraphics#rotateX(float) </seealso>
	  /// <seealso cref= PGraphics#rotateY(float) </seealso>
	  /// <seealso cref= PGraphics#rotateZ(float) </seealso>
	  public virtual void pushMatrix()
	  {
		showMethodWarning("pushMatrix");
	  }


	  /// <summary>
	  /// ( begin auto-generated from popMatrix.xml )
	  /// 
	  /// Pops the current transformation matrix off the matrix stack.
	  /// Understanding pushing and popping requires understanding the concept of
	  /// a matrix stack. The <b>pushMatrix()</b> function saves the current
	  /// coordinate system to the stack and <b>popMatrix()</b> restores the prior
	  /// coordinate system. <b>pushMatrix()</b> and <b>popMatrix()</b> are used
	  /// in conjuction with the other transformation functions and may be
	  /// embedded to control the scope of the transformations.
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref transform </summary>
	  /// <seealso cref= PGraphics#pushMatrix() </seealso>
	  public virtual void popMatrix()
	  {
		showMethodWarning("popMatrix");
	  }



	  //////////////////////////////////////////////////////////////

	  // MATRIX TRANSFORMATIONS


	  /// <summary>
	  /// ( begin auto-generated from translate.xml )
	  /// 
	  /// Specifies an amount to displace objects within the display window. The
	  /// <b>x</b> parameter specifies left/right translation, the <b>y</b>
	  /// parameter specifies up/down translation, and the <b>z</b> parameter
	  /// specifies translations toward/away from the screen. Using this function
	  /// with the <b>z</b> parameter requires using P3D as a parameter in
	  /// combination with size as shown in the above example. Transformations
	  /// apply to everything that happens after and subsequent calls to the
	  /// function accumulates the effect. For example, calling <b>translate(50,
	  /// 0)</b> and then <b>translate(20, 0)</b> is the same as <b>translate(70,
	  /// 0)</b>. If <b>translate()</b> is called within <b>draw()</b>, the
	  /// transformation is reset when the loop begins again. This function can be
	  /// further controlled by the <b>pushMatrix()</b> and <b>popMatrix()</b>.
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref transform </summary>
	  /// <param name="x"> left/right translation </param>
	  /// <param name="y"> up/down translation </param>
	  /// <seealso cref= PGraphics#popMatrix() </seealso>
	  /// <seealso cref= PGraphics#pushMatrix() </seealso>
	  /// <seealso cref= PGraphics#rotate(float) </seealso>
	  /// <seealso cref= PGraphics#rotateX(float) </seealso>
	  /// <seealso cref= PGraphics#rotateY(float) </seealso>
	  /// <seealso cref= PGraphics#rotateZ(float) </seealso>
	  /// <seealso cref= PGraphics#scale(float, float, float) </seealso>
	  public virtual void translate(float x, float y)
	  {
		showMissingWarning("translate");
	  }


	  /// <param name="z"> forward/backward translation </param>
	  public virtual void translate(float x, float y, float z)
	  {
		showMissingWarning("translate");
	  }


	  /// <summary>
	  /// ( begin auto-generated from rotate.xml )
	  /// 
	  /// Rotates a shape the amount specified by the <b>angle</b> parameter.
	  /// Angles should be specified in radians (values from 0 to TWO_PI) or
	  /// converted to radians with the <b>radians()</b> function.
	  /// <br/> <br/>
	  /// Objects are always rotated around their relative position to the origin
	  /// and positive numbers rotate objects in a clockwise direction.
	  /// Transformations apply to everything that happens after and subsequent
	  /// calls to the function accumulates the effect. For example, calling
	  /// <b>rotate(HALF_PI)</b> and then <b>rotate(HALF_PI)</b> is the same as
	  /// <b>rotate(PI)</b>. All tranformations are reset when <b>draw()</b>
	  /// begins again.
	  /// <br/> <br/>
	  /// Technically, <b>rotate()</b> multiplies the current transformation
	  /// matrix by a rotation matrix. This function can be further controlled by
	  /// the <b>pushMatrix()</b> and <b>popMatrix()</b>.
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref transform </summary>
	  /// <param name="angle"> angle of rotation specified in radians </param>
	  /// <seealso cref= PGraphics#popMatrix() </seealso>
	  /// <seealso cref= PGraphics#pushMatrix() </seealso>
	  /// <seealso cref= PGraphics#rotateX(float) </seealso>
	  /// <seealso cref= PGraphics#rotateY(float) </seealso>
	  /// <seealso cref= PGraphics#rotateZ(float) </seealso>
	  /// <seealso cref= PGraphics#scale(float, float, float) </seealso>
	  /// <seealso cref= PApplet#radians(float) </seealso>
	  public virtual void rotate(float angle)
	  {
		showMissingWarning("rotate");
	  }


	  /// <summary>
	  /// ( begin auto-generated from rotateX.xml )
	  /// 
	  /// Rotates a shape around the x-axis the amount specified by the
	  /// <b>angle</b> parameter. Angles should be specified in radians (values
	  /// from 0 to PI*2) or converted to radians with the <b>radians()</b>
	  /// function. Objects are always rotated around their relative position to
	  /// the origin and positive numbers rotate objects in a counterclockwise
	  /// direction. Transformations apply to everything that happens after and
	  /// subsequent calls to the function accumulates the effect. For example,
	  /// calling <b>rotateX(PI/2)</b> and then <b>rotateX(PI/2)</b> is the same
	  /// as <b>rotateX(PI)</b>. If <b>rotateX()</b> is called within the
	  /// <b>draw()</b>, the transformation is reset when the loop begins again.
	  /// This function requires using P3D as a third parameter to <b>size()</b>
	  /// as shown in the example above.
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref transform </summary>
	  /// <param name="angle"> angle of rotation specified in radians </param>
	  /// <seealso cref= PGraphics#popMatrix() </seealso>
	  /// <seealso cref= PGraphics#pushMatrix() </seealso>
	  /// <seealso cref= PGraphics#rotate(float) </seealso>
	  /// <seealso cref= PGraphics#rotateY(float) </seealso>
	  /// <seealso cref= PGraphics#rotateZ(float) </seealso>
	  /// <seealso cref= PGraphics#scale(float, float, float) </seealso>
	  /// <seealso cref= PGraphics#translate(float, float, float) </seealso>
	  public virtual void rotateX(float angle)
	  {
		showMethodWarning("rotateX");
	  }


	  /// <summary>
	  /// ( begin auto-generated from rotateY.xml )
	  /// 
	  /// Rotates a shape around the y-axis the amount specified by the
	  /// <b>angle</b> parameter. Angles should be specified in radians (values
	  /// from 0 to PI*2) or converted to radians with the <b>radians()</b>
	  /// function. Objects are always rotated around their relative position to
	  /// the origin and positive numbers rotate objects in a counterclockwise
	  /// direction. Transformations apply to everything that happens after and
	  /// subsequent calls to the function accumulates the effect. For example,
	  /// calling <b>rotateY(PI/2)</b> and then <b>rotateY(PI/2)</b> is the same
	  /// as <b>rotateY(PI)</b>. If <b>rotateY()</b> is called within the
	  /// <b>draw()</b>, the transformation is reset when the loop begins again.
	  /// This function requires using P3D as a third parameter to <b>size()</b>
	  /// as shown in the examples above.
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref transform </summary>
	  /// <param name="angle"> angle of rotation specified in radians </param>
	  /// <seealso cref= PGraphics#popMatrix() </seealso>
	  /// <seealso cref= PGraphics#pushMatrix() </seealso>
	  /// <seealso cref= PGraphics#rotate(float) </seealso>
	  /// <seealso cref= PGraphics#rotateX(float) </seealso>
	  /// <seealso cref= PGraphics#rotateZ(float) </seealso>
	  /// <seealso cref= PGraphics#scale(float, float, float) </seealso>
	  /// <seealso cref= PGraphics#translate(float, float, float) </seealso>
	  public virtual void rotateY(float angle)
	  {
		showMethodWarning("rotateY");
	  }


	  /// <summary>
	  /// ( begin auto-generated from rotateZ.xml )
	  /// 
	  /// Rotates a shape around the z-axis the amount specified by the
	  /// <b>angle</b> parameter. Angles should be specified in radians (values
	  /// from 0 to PI*2) or converted to radians with the <b>radians()</b>
	  /// function. Objects are always rotated around their relative position to
	  /// the origin and positive numbers rotate objects in a counterclockwise
	  /// direction. Transformations apply to everything that happens after and
	  /// subsequent calls to the function accumulates the effect. For example,
	  /// calling <b>rotateZ(PI/2)</b> and then <b>rotateZ(PI/2)</b> is the same
	  /// as <b>rotateZ(PI)</b>. If <b>rotateZ()</b> is called within the
	  /// <b>draw()</b>, the transformation is reset when the loop begins again.
	  /// This function requires using P3D as a third parameter to <b>size()</b>
	  /// as shown in the examples above.
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref transform </summary>
	  /// <param name="angle"> angle of rotation specified in radians </param>
	  /// <seealso cref= PGraphics#popMatrix() </seealso>
	  /// <seealso cref= PGraphics#pushMatrix() </seealso>
	  /// <seealso cref= PGraphics#rotate(float) </seealso>
	  /// <seealso cref= PGraphics#rotateX(float) </seealso>
	  /// <seealso cref= PGraphics#rotateY(float) </seealso>
	  /// <seealso cref= PGraphics#scale(float, float, float) </seealso>
	  /// <seealso cref= PGraphics#translate(float, float, float) </seealso>
	  public virtual void rotateZ(float angle)
	  {
		showMethodWarning("rotateZ");
	  }


	  /// <summary>
	  /// <h3>Advanced</h3>
	  /// Rotate about a vector in space. Same as the glRotatef() function. </summary>
	  /// <param name="x"> </param>
	  /// <param name="y"> </param>
	  /// <param name="z"> </param>
	  public virtual void rotate(float angle, float x, float y, float z)
	  {
		showMissingWarning("rotate");
	  }


	  /// <summary>
	  /// ( begin auto-generated from scale.xml )
	  /// 
	  /// Increases or decreases the size of a shape by expanding and contracting
	  /// vertices. Objects always scale from their relative origin to the
	  /// coordinate system. Scale values are specified as decimal percentages.
	  /// For example, the function call <b>scale(2.0)</b> increases the dimension
	  /// of a shape by 200%. Transformations apply to everything that happens
	  /// after and subsequent calls to the function multiply the effect. For
	  /// example, calling <b>scale(2.0)</b> and then <b>scale(1.5)</b> is the
	  /// same as <b>scale(3.0)</b>. If <b>scale()</b> is called within
	  /// <b>draw()</b>, the transformation is reset when the loop begins again.
	  /// Using this fuction with the <b>z</b> parameter requires using P3D as a
	  /// parameter for <b>size()</b> as shown in the example above. This function
	  /// can be further controlled by <b>pushMatrix()</b> and <b>popMatrix()</b>.
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref transform </summary>
	  /// <param name="s"> percentage to scale the object </param>
	  /// <seealso cref= PGraphics#pushMatrix() </seealso>
	  /// <seealso cref= PGraphics#popMatrix() </seealso>
	  /// <seealso cref= PGraphics#translate(float, float, float) </seealso>
	  /// <seealso cref= PGraphics#rotate(float) </seealso>
	  /// <seealso cref= PGraphics#rotateX(float) </seealso>
	  /// <seealso cref= PGraphics#rotateY(float) </seealso>
	  /// <seealso cref= PGraphics#rotateZ(float) </seealso>
	  public virtual void scale(float s)
	  {
		showMissingWarning("scale");
	  }


	  /// <summary>
	  /// <h3>Advanced</h3>
	  /// Scale in X and Y. Equivalent to scale(sx, sy, 1).
	  /// 
	  /// Not recommended for use in 3D, because the z-dimension is just
	  /// scaled by 1, since there's no way to know what else to scale it by.
	  /// </summary>
	  /// <param name="x"> percentage to scale the object in the x-axis </param>
	  /// <param name="y"> percentage to scale the object in the y-axis </param>
	  public virtual void scale(float x, float y)
	  {
		showMissingWarning("scale");
	  }


	  /// <param name="z"> percentage to scale the object in the z-axis </param>
	  public virtual void scale(float x, float y, float z)
	  {
		showMissingWarning("scale");
	  }


	  /// <summary>
	  /// ( begin auto-generated from shearX.xml )
	  /// 
	  /// Shears a shape around the x-axis the amount specified by the
	  /// <b>angle</b> parameter. Angles should be specified in radians (values
	  /// from 0 to PI*2) or converted to radians with the <b>radians()</b>
	  /// function. Objects are always sheared around their relative position to
	  /// the origin and positive numbers shear objects in a clockwise direction.
	  /// Transformations apply to everything that happens after and subsequent
	  /// calls to the function accumulates the effect. For example, calling
	  /// <b>shearX(PI/2)</b> and then <b>shearX(PI/2)</b> is the same as
	  /// <b>shearX(PI)</b>. If <b>shearX()</b> is called within the
	  /// <b>draw()</b>, the transformation is reset when the loop begins again.
	  /// <br/> <br/>
	  /// Technically, <b>shearX()</b> multiplies the current transformation
	  /// matrix by a rotation matrix. This function can be further controlled by
	  /// the <b>pushMatrix()</b> and <b>popMatrix()</b> functions.
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref transform </summary>
	  /// <param name="angle"> angle of shear specified in radians </param>
	  /// <seealso cref= PGraphics#popMatrix() </seealso>
	  /// <seealso cref= PGraphics#pushMatrix() </seealso>
	  /// <seealso cref= PGraphics#shearY(float) </seealso>
	  /// <seealso cref= PGraphics#scale(float, float, float) </seealso>
	  /// <seealso cref= PGraphics#translate(float, float, float) </seealso>
	  /// <seealso cref= PApplet#radians(float) </seealso>
	  public virtual void shearX(float angle)
	  {
		showMissingWarning("shearX");
	  }


	  /// <summary>
	  /// ( begin auto-generated from shearY.xml )
	  /// 
	  /// Shears a shape around the y-axis the amount specified by the
	  /// <b>angle</b> parameter. Angles should be specified in radians (values
	  /// from 0 to PI*2) or converted to radians with the <b>radians()</b>
	  /// function. Objects are always sheared around their relative position to
	  /// the origin and positive numbers shear objects in a clockwise direction.
	  /// Transformations apply to everything that happens after and subsequent
	  /// calls to the function accumulates the effect. For example, calling
	  /// <b>shearY(PI/2)</b> and then <b>shearY(PI/2)</b> is the same as
	  /// <b>shearY(PI)</b>. If <b>shearY()</b> is called within the
	  /// <b>draw()</b>, the transformation is reset when the loop begins again.
	  /// <br/> <br/>
	  /// Technically, <b>shearY()</b> multiplies the current transformation
	  /// matrix by a rotation matrix. This function can be further controlled by
	  /// the <b>pushMatrix()</b> and <b>popMatrix()</b> functions.
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref transform </summary>
	  /// <param name="angle"> angle of shear specified in radians </param>
	  /// <seealso cref= PGraphics#popMatrix() </seealso>
	  /// <seealso cref= PGraphics#pushMatrix() </seealso>
	  /// <seealso cref= PGraphics#shearX(float) </seealso>
	  /// <seealso cref= PGraphics#scale(float, float, float) </seealso>
	  /// <seealso cref= PGraphics#translate(float, float, float) </seealso>
	  /// <seealso cref= PApplet#radians(float) </seealso>
	  public virtual void shearY(float angle)
	  {
		showMissingWarning("shearY");
	  }


	  //////////////////////////////////////////////////////////////

	  // MATRIX FULL MONTY


	  /// <summary>
	  /// ( begin auto-generated from resetMatrix.xml )
	  /// 
	  /// Replaces the current matrix with the identity matrix. The equivalent
	  /// function in OpenGL is glLoadIdentity().
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref transform </summary>
	  /// <seealso cref= PGraphics#pushMatrix() </seealso>
	  /// <seealso cref= PGraphics#popMatrix() </seealso>
	  /// <seealso cref= PGraphics#applyMatrix(PMatrix) </seealso>
	  /// <seealso cref= PGraphics#printMatrix() </seealso>
	  public virtual void resetMatrix()
	  {
		showMethodWarning("resetMatrix");
	  }

	  /// <summary>
	  /// ( begin auto-generated from applyMatrix.xml )
	  /// 
	  /// Multiplies the current matrix by the one specified through the
	  /// parameters. This is very slow because it will try to calculate the
	  /// inverse of the transform, so avoid it whenever possible. The equivalent
	  /// function in OpenGL is glMultMatrix().
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref transform
	  /// @source </summary>
	  /// <seealso cref= PGraphics#pushMatrix() </seealso>
	  /// <seealso cref= PGraphics#popMatrix() </seealso>
	  /// <seealso cref= PGraphics#resetMatrix() </seealso>
	  /// <seealso cref= PGraphics#printMatrix() </seealso>
	  public virtual void applyMatrix(PMatrix source)
	  {
		if (source is PMatrix2D)
		{
		  applyMatrix((PMatrix2D) source);
		}
		else if (source is PMatrix3D)
		{
		  applyMatrix((PMatrix3D) source);
		}
	  }


	  public virtual void applyMatrix(PMatrix2D source)
	  {
		applyMatrix(source.m00, source.m01, source.m02, source.m10, source.m11, source.m12);
	  }


	  /// <param name="n00"> numbers which define the 4x4 matrix to be multiplied </param>
	  /// <param name="n01"> numbers which define the 4x4 matrix to be multiplied </param>
	  /// <param name="n02"> numbers which define the 4x4 matrix to be multiplied </param>
	  /// <param name="n10"> numbers which define the 4x4 matrix to be multiplied </param>
	  /// <param name="n11"> numbers which define the 4x4 matrix to be multiplied </param>
	  /// <param name="n12"> numbers which define the 4x4 matrix to be multiplied </param>
	  public virtual void applyMatrix(float n00, float n01, float n02, float n10, float n11, float n12)
	  {
		showMissingWarning("applyMatrix");
	  }

	  public virtual void applyMatrix(PMatrix3D source)
	  {
		applyMatrix(source.m00, source.m01, source.m02, source.m03, source.m10, source.m11, source.m12, source.m13, source.m20, source.m21, source.m22, source.m23, source.m30, source.m31, source.m32, source.m33);
	  }


	  /// <param name="n03"> numbers which define the 4x4 matrix to be multiplied </param>
	  /// <param name="n13"> numbers which define the 4x4 matrix to be multiplied </param>
	  /// <param name="n20"> numbers which define the 4x4 matrix to be multiplied </param>
	  /// <param name="n21"> numbers which define the 4x4 matrix to be multiplied </param>
	  /// <param name="n22"> numbers which define the 4x4 matrix to be multiplied </param>
	  /// <param name="n23"> numbers which define the 4x4 matrix to be multiplied </param>
	  /// <param name="n30"> numbers which define the 4x4 matrix to be multiplied </param>
	  /// <param name="n31"> numbers which define the 4x4 matrix to be multiplied </param>
	  /// <param name="n32"> numbers which define the 4x4 matrix to be multiplied </param>
	  /// <param name="n33"> numbers which define the 4x4 matrix to be multiplied </param>
	  public virtual void applyMatrix(float n00, float n01, float n02, float n03, float n10, float n11, float n12, float n13, float n20, float n21, float n22, float n23, float n30, float n31, float n32, float n33)
	  {
		showMissingWarning("applyMatrix");
	  }



	  //////////////////////////////////////////////////////////////

	  // MATRIX GET/SET/PRINT


	  public virtual PMatrix getMatrix()
	  {
		showMissingWarning("getMatrix");
		return null;
	  }


	  /// <summary>
	  /// Copy the current transformation matrix into the specified target.
	  /// Pass in null to create a new matrix.
	  /// </summary>
	  public virtual PMatrix2D getMatrix(PMatrix2D target)
	  {
		showMissingWarning("getMatrix");
		return null;
	  }


	  /// <summary>
	  /// Copy the current transformation matrix into the specified target.
	  /// Pass in null to create a new matrix.
	  /// </summary>
	  public virtual PMatrix3D getMatrix(PMatrix3D target)
	  {
		showMissingWarning("getMatrix");
		return null;
	  }


	  /// <summary>
	  /// Set the current transformation matrix to the contents of another.
	  /// </summary>
	  public virtual void setMatrix(PMatrix source)
	  {
		if (source is PMatrix2D)
		{
		  setMatrix((PMatrix2D) source);
		}
		else if (source is PMatrix3D)
		{
		  setMatrix((PMatrix3D) source);
		}
	  }


	  /// <summary>
	  /// Set the current transformation to the contents of the specified source.
	  /// </summary>
	  public virtual void setMatrix(PMatrix2D source)
	  {
		showMissingWarning("setMatrix");
	  }


	  /// <summary>
	  /// Set the current transformation to the contents of the specified source.
	  /// </summary>
	  public virtual void setMatrix(PMatrix3D source)
	  {
		showMissingWarning("setMatrix");
	  }


	  /// <summary>
	  /// ( begin auto-generated from printMatrix.xml )
	  /// 
	  /// Prints the current matrix to the Console (the text window at the bottom
	  /// of Processing).
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref transform </summary>
	  /// <seealso cref= PGraphics#pushMatrix() </seealso>
	  /// <seealso cref= PGraphics#popMatrix() </seealso>
	  /// <seealso cref= PGraphics#resetMatrix() </seealso>
	  /// <seealso cref= PGraphics#applyMatrix(PMatrix) </seealso>
	  public virtual void printMatrix()
	  {
		showMethodWarning("printMatrix");
	  }


	  //////////////////////////////////////////////////////////////

	  // CAMERA

	  /// <summary>
	  /// ( begin auto-generated from beginCamera.xml )
	  /// 
	  /// The <b>beginCamera()</b> and <b>endCamera()</b> functions enable
	  /// advanced customization of the camera space. The functions are useful if
	  /// you want to more control over camera movement, however for most users,
	  /// the <b>camera()</b> function will be sufficient.<br /><br />The camera
	  /// functions will replace any transformations (such as <b>rotate()</b> or
	  /// <b>translate()</b>) that occur before them in <b>draw()</b>, but they
	  /// will not automatically replace the camera transform itself. For this
	  /// reason, camera functions should be placed at the beginning of
	  /// <b>draw()</b> (so that transformations happen afterwards), and the
	  /// <b>camera()</b> function can be used after <b>beginCamera()</b> if you
	  /// want to reset the camera before applying transformations.<br /><br
	  /// />This function sets the matrix mode to the camera matrix so calls such
	  /// as <b>translate()</b>, <b>rotate()</b>, applyMatrix() and resetMatrix()
	  /// affect the camera. <b>beginCamera()</b> should always be used with a
	  /// following <b>endCamera()</b> and pairs of <b>beginCamera()</b> and
	  /// <b>endCamera()</b> cannot be nested.
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref lights_camera:camera </summary>
	  /// <seealso cref= PGraphics#camera() </seealso>
	  /// <seealso cref= PGraphics#endCamera() </seealso>
	  /// <seealso cref= PGraphics#applyMatrix(PMatrix) </seealso>
	  /// <seealso cref= PGraphics#resetMatrix() </seealso>
	  /// <seealso cref= PGraphics#translate(float, float, float) </seealso>
	  /// <seealso cref= PGraphics#scale(float, float, float) </seealso>
	  public virtual void beginCamera()
	  {
		showMethodWarning("beginCamera");
	  }

	  /// <summary>
	  /// ( begin auto-generated from endCamera.xml )
	  /// 
	  /// The <b>beginCamera()</b> and <b>endCamera()</b> functions enable
	  /// advanced customization of the camera space. Please see the reference for
	  /// <b>beginCamera()</b> for a description of how the functions are used.
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref lights_camera:camera </summary>
	  /// <seealso cref= PGraphics#camera(float, float, float, float, float, float, float, float, float) </seealso>
	  public virtual void endCamera()
	  {
		showMethodWarning("endCamera");
	  }

	  /// <summary>
	  /// ( begin auto-generated from camera.xml )
	  /// 
	  /// Sets the position of the camera through setting the eye position, the
	  /// center of the scene, and which axis is facing upward. Moving the eye
	  /// position and the direction it is pointing (the center of the scene)
	  /// allows the images to be seen from different angles. The version without
	  /// any parameters sets the camera to the default position, pointing to the
	  /// center of the display window with the Y axis as up. The default values
	  /// are <b>camera(width/2.0, height/2.0, (height/2.0) / tan(PI*30.0 /
	  /// 180.0), width/2.0, height/2.0, 0, 0, 1, 0)</b>. This function is similar
	  /// to <b>gluLookAt()</b> in OpenGL, but it first clears the current camera settings.
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref lights_camera:camera </summary>
	  /// <seealso cref= PGraphics#endCamera() </seealso>
	  /// <seealso cref= PGraphics#frustum(float, float, float, float, float, float) </seealso>
	  public virtual void camera()
	  {
		showMissingWarning("camera");
	  }

	/// <param name="eyeX"> x-coordinate for the eye </param>
	/// <param name="eyeY"> y-coordinate for the eye </param>
	/// <param name="eyeZ"> z-coordinate for the eye </param>
	/// <param name="centerX"> x-coordinate for the center of the scene </param>
	/// <param name="centerY"> y-coordinate for the center of the scene </param>
	/// <param name="centerZ"> z-coordinate for the center of the scene </param>
	/// <param name="upX"> usually 0.0, 1.0, or -1.0 </param>
	/// <param name="upY"> usually 0.0, 1.0, or -1.0 </param>
	/// <param name="upZ"> usually 0.0, 1.0, or -1.0 </param>
	  public virtual void camera(float eyeX, float eyeY, float eyeZ, float centerX, float centerY, float centerZ, float upX, float upY, float upZ)
	  {
		showMissingWarning("camera");
	  }

	/// <summary>
	/// ( begin auto-generated from printCamera.xml )
	///   
	/// Prints the current camera matrix to the Console (the text window at the
	/// bottom of Processing).
	///   
	/// ( end auto-generated )
	/// @webref lights_camera:camera </summary>
	/// <seealso cref= PGraphics#camera(float, float, float, float, float, float, float, float, float) </seealso>
	  public virtual void printCamera()
	  {
		showMethodWarning("printCamera");
	  }



	  //////////////////////////////////////////////////////////////

	  // PROJECTION

	  /// <summary>
	  /// ( begin auto-generated from ortho.xml )
	  /// 
	  /// Sets an orthographic projection and defines a parallel clipping volume.
	  /// All objects with the same dimension appear the same size, regardless of
	  /// whether they are near or far from the camera. The parameters to this
	  /// function specify the clipping volume where left and right are the
	  /// minimum and maximum x values, top and bottom are the minimum and maximum
	  /// y values, and near and far are the minimum and maximum z values. If no
	  /// parameters are given, the default is used: ortho(0, width, 0, height,
	  /// -10, 10).
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref lights_camera:camera
	  /// </summary>
	  public virtual void ortho()
	  {
		showMissingWarning("ortho");
	  }

	  /// <param name="left"> left plane of the clipping volume </param>
	  /// <param name="right"> right plane of the clipping volume </param>
	  /// <param name="bottom"> bottom plane of the clipping volume </param>
	  /// <param name="top"> top plane of the clipping volume </param>
	  public virtual void ortho(float left, float right, float bottom, float top)
	  {
		showMissingWarning("ortho");
	  }

	  /// <param name="near"> maximum distance from the origin to the viewer </param>
	  /// <param name="far"> maximum distance from the origin away from the viewer </param>
	  public virtual void ortho(float left, float right, float bottom, float top, float near, float far)
	  {
		showMissingWarning("ortho");
	  }

	  /// <summary>
	  /// ( begin auto-generated from perspective.xml )
	  /// 
	  /// Sets a perspective projection applying foreshortening, making distant
	  /// objects appear smaller than closer ones. The parameters define a viewing
	  /// volume with the shape of truncated pyramid. Objects near to the front of
	  /// the volume appear their actual size, while farther objects appear
	  /// smaller. This projection simulates the perspective of the world more
	  /// accurately than orthographic projection. The version of perspective
	  /// without parameters sets the default perspective and the version with
	  /// four parameters allows the programmer to set the area precisely. The
	  /// default values are: perspective(PI/3.0, width/height, cameraZ/10.0,
	  /// cameraZ*10.0) where cameraZ is ((height/2.0) / tan(PI*60.0/360.0));
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref lights_camera:camera
	  /// </summary>
	  public virtual void perspective()
	  {
		showMissingWarning("perspective");
	  }

	  /// <param name="fovy"> field-of-view angle (in radians) for vertical direction </param>
	  /// <param name="aspect"> ratio of width to height </param>
	  /// <param name="zNear"> z-position of nearest clipping plane </param>
	  /// <param name="zFar"> z-position of farthest clipping plane </param>
	  public virtual void perspective(float fovy, float aspect, float zNear, float zFar)
	  {
		showMissingWarning("perspective");
	  }

	  /// <summary>
	  /// ( begin auto-generated from frustum.xml )
	  /// 
	  /// Sets a perspective matrix defined through the parameters. Works like
	  /// glFrustum, except it wipes out the current perspective matrix rather
	  /// than muliplying itself with it.
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref lights_camera:camera </summary>
	  /// <param name="left"> left coordinate of the clipping plane </param>
	  /// <param name="right"> right coordinate of the clipping plane </param>
	  /// <param name="bottom"> bottom coordinate of the clipping plane </param>
	  /// <param name="top"> top coordinate of the clipping plane </param>
	  /// <param name="near"> near component of the clipping plane; must be greater than zero </param>
	  /// <param name="far"> far component of the clipping plane; must be greater than the near value </param>
	  /// <seealso cref= PGraphics#camera(float, float, float, float, float, float, float, float, float) </seealso>
	  /// <seealso cref= PGraphics#endCamera() </seealso>
	  /// <seealso cref= PGraphics#perspective(float, float, float, float) </seealso>
	  public virtual void frustum(float left, float right, float bottom, float top, float near, float far)
	  {
		showMethodWarning("frustum");
	  }

	  /// <summary>
	  /// ( begin auto-generated from printProjection.xml )
	  /// 
	  /// Prints the current projection matrix to the Console (the text window at
	  /// the bottom of Processing).
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref lights_camera:camera </summary>
	  /// <seealso cref= PGraphics#camera(float, float, float, float, float, float, float, float, float) </seealso>
	  public virtual void printProjection()
	  {
		showMethodWarning("printProjection");
	  }



	  //////////////////////////////////////////////////////////////

	  // SCREEN TRANSFORMS


	  /// <summary>
	  /// ( begin auto-generated from screenX.xml )
	  /// 
	  /// Takes a three-dimensional X, Y, Z position and returns the X value for
	  /// where it will appear on a (two-dimensional) screen.
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref lights_camera:coordinates </summary>
	  /// <param name="x"> 3D x-coordinate to be mapped </param>
	  /// <param name="y"> 3D y-coordinate to be mapped </param>
	  /// <seealso cref= PGraphics#screenY(float, float, float) </seealso>
	  /// <seealso cref= PGraphics#screenZ(float, float, float) </seealso>
	  public virtual float screenX(float x, float y)
	  {
		showMissingWarning("screenX");
		return 0;
	  }


	  /// <summary>
	  /// ( begin auto-generated from screenY.xml )
	  /// 
	  /// Takes a three-dimensional X, Y, Z position and returns the Y value for
	  /// where it will appear on a (two-dimensional) screen.
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref lights_camera:coordinates </summary>
	  /// <param name="x"> 3D x-coordinate to be mapped </param>
	  /// <param name="y"> 3D y-coordinate to be mapped </param>
	  /// <seealso cref= PGraphics#screenX(float, float, float) </seealso>
	  /// <seealso cref= PGraphics#screenZ(float, float, float) </seealso>
	  public virtual float screenY(float x, float y)
	  {
		showMissingWarning("screenY");
		return 0;
	  }


	  /// <param name="z"> 3D z-coordinate to be mapped </param>
	  public virtual float screenX(float x, float y, float z)
	  {
		showMissingWarning("screenX");
		return 0;
	  }


	  /// <param name="z"> 3D z-coordinate to be mapped </param>
	  public virtual float screenY(float x, float y, float z)
	  {
		showMissingWarning("screenY");
		return 0;
	  }



	  /// <summary>
	  /// ( begin auto-generated from screenZ.xml )
	  /// 
	  /// Takes a three-dimensional X, Y, Z position and returns the Z value for
	  /// where it will appear on a (two-dimensional) screen.
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref lights_camera:coordinates </summary>
	  /// <param name="x"> 3D x-coordinate to be mapped </param>
	  /// <param name="y"> 3D y-coordinate to be mapped </param>
	  /// <param name="z"> 3D z-coordinate to be mapped </param>
	  /// <seealso cref= PGraphics#screenX(float, float, float) </seealso>
	  /// <seealso cref= PGraphics#screenY(float, float, float) </seealso>
	  public virtual float screenZ(float x, float y, float z)
	  {
		showMissingWarning("screenZ");
		return 0;
	  }


	  /// <summary>
	  /// ( begin auto-generated from modelX.xml )
	  /// 
	  /// Returns the three-dimensional X, Y, Z position in model space. This
	  /// returns the X value for a given coordinate based on the current set of
	  /// transformations (scale, rotate, translate, etc.) The X value can be used
	  /// to place an object in space relative to the location of the original
	  /// point once the transformations are no longer in use.
	  /// <br/> <br/>
	  /// In the example, the <b>modelX()</b>, <b>modelY()</b>, and
	  /// <b>modelZ()</b> functions record the location of a box in space after
	  /// being placed using a series of translate and rotate commands. After
	  /// popMatrix() is called, those transformations no longer apply, but the
	  /// (x, y, z) coordinate returned by the model functions is used to place
	  /// another box in the same location.
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref lights_camera:coordinates </summary>
	  /// <param name="x"> 3D x-coordinate to be mapped </param>
	  /// <param name="y"> 3D y-coordinate to be mapped </param>
	  /// <param name="z"> 3D z-coordinate to be mapped </param>
	  /// <seealso cref= PGraphics#modelY(float, float, float) </seealso>
	  /// <seealso cref= PGraphics#modelZ(float, float, float) </seealso>
	  public virtual float modelX(float x, float y, float z)
	  {
		showMissingWarning("modelX");
		return 0;
	  }


	  /// <summary>
	  /// ( begin auto-generated from modelY.xml )
	  /// 
	  /// Returns the three-dimensional X, Y, Z position in model space. This
	  /// returns the Y value for a given coordinate based on the current set of
	  /// transformations (scale, rotate, translate, etc.) The Y value can be used
	  /// to place an object in space relative to the location of the original
	  /// point once the transformations are no longer in use.<br />
	  /// <br />
	  /// In the example, the <b>modelX()</b>, <b>modelY()</b>, and
	  /// <b>modelZ()</b> functions record the location of a box in space after
	  /// being placed using a series of translate and rotate commands. After
	  /// popMatrix() is called, those transformations no longer apply, but the
	  /// (x, y, z) coordinate returned by the model functions is used to place
	  /// another box in the same location.
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref lights_camera:coordinates </summary>
	  /// <param name="x"> 3D x-coordinate to be mapped </param>
	  /// <param name="y"> 3D y-coordinate to be mapped </param>
	  /// <param name="z"> 3D z-coordinate to be mapped </param>
	  /// <seealso cref= PGraphics#modelX(float, float, float) </seealso>
	  /// <seealso cref= PGraphics#modelZ(float, float, float) </seealso>
	  public virtual float modelY(float x, float y, float z)
	  {
		showMissingWarning("modelY");
		return 0;
	  }


	  /// <summary>
	  /// ( begin auto-generated from modelZ.xml )
	  /// 
	  /// Returns the three-dimensional X, Y, Z position in model space. This
	  /// returns the Z value for a given coordinate based on the current set of
	  /// transformations (scale, rotate, translate, etc.) The Z value can be used
	  /// to place an object in space relative to the location of the original
	  /// point once the transformations are no longer in use.<br />
	  /// <br />
	  /// In the example, the <b>modelX()</b>, <b>modelY()</b>, and
	  /// <b>modelZ()</b> functions record the location of a box in space after
	  /// being placed using a series of translate and rotate commands. After
	  /// popMatrix() is called, those transformations no longer apply, but the
	  /// (x, y, z) coordinate returned by the model functions is used to place
	  /// another box in the same location.
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref lights_camera:coordinates </summary>
	  /// <param name="x"> 3D x-coordinate to be mapped </param>
	  /// <param name="y"> 3D y-coordinate to be mapped </param>
	  /// <param name="z"> 3D z-coordinate to be mapped </param>
	  /// <seealso cref= PGraphics#modelX(float, float, float) </seealso>
	  /// <seealso cref= PGraphics#modelY(float, float, float) </seealso>
	  public virtual float modelZ(float x, float y, float z)
	  {
		showMissingWarning("modelZ");
		return 0;
	  }



	  //////////////////////////////////////////////////////////////

	  // STYLE

	  /// <summary>
	  /// ( begin auto-generated from pushStyle.xml )
	  /// 
	  /// The <b>pushStyle()</b> function saves the current style settings and
	  /// <b>popStyle()</b> restores the prior settings. Note that these functions
	  /// are always used together. They allow you to change the style settings
	  /// and later return to what you had. When a new style is started with
	  /// <b>pushStyle()</b>, it builds on the current style information. The
	  /// <b>pushStyle()</b> and <b>popStyle()</b> functions can be embedded to
	  /// provide more control (see the second example above for a demonstration.)
	  /// <br /><br />
	  /// The style information controlled by the following functions are included
	  /// in the style:
	  /// fill(), stroke(), tint(), strokeWeight(), strokeCap(), strokeJoin(),
	  /// imageMode(), rectMode(), ellipseMode(), shapeMode(), colorMode(),
	  /// textAlign(), textFont(), textMode(), textSize(), textLeading(),
	  /// emissive(), specular(), shininess(), ambient()
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref structure </summary>
	  /// <seealso cref= PGraphics#popStyle() </seealso>
	  public virtual void pushStyle()
	  {
			//TODO: After PApplet
//			if (styleStackDepth == styleStack.Length)
//		{
//		  styleStack = (PStyle[]) PApplet.expand(styleStack);
//		}
//		if (styleStack[styleStackDepth] == null)
//		{
//		  styleStack[styleStackDepth] = new PStyle();
//		}
//		PStyle s = styleStack[styleStackDepth++];
//		getStyle(s);
	  }

	  /// <summary>
	  /// ( begin auto-generated from popStyle.xml )
	  /// 
	  /// The <b>pushStyle()</b> function saves the current style settings and
	  /// <b>popStyle()</b> restores the prior settings; these functions are
	  /// always used together. They allow you to change the style settings and
	  /// later return to what you had. When a new style is started with
	  /// <b>pushStyle()</b>, it builds on the current style information. The
	  /// <b>pushStyle()</b> and <b>popStyle()</b> functions can be embedded to
	  /// provide more control (see the second example above for a demonstration.)
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref structure </summary>
	  /// <seealso cref= PGraphics#pushStyle() </seealso>
	  public virtual void popStyle()
	  {
		if (styleStackDepth == 0)
		{
		  throw new Exception("Too many popStyle() without enough pushStyle()");
		}
		styleStackDepth--;
		style(styleStack[styleStackDepth]);
	  }


	  public virtual void style(PStyle s)
	  {
		//  if (s.smooth) {
		//    smooth();
		//  } else {
		//    noSmooth();
		//  }

		imageMode(s.imageMode);
		rectMode(s.rectMode);
		ellipseMode(s.ellipseMode);
		shapeMode(s.shapeMode);

		blendMode(s.blendMode);

		if (s.tint)
		{
		  tint(s.tintColor);
		}
		else
		{
		  noTint();
		}
		if (s.fill)
		{
		  fill(s.fillColor);
		}
		else
		{
		  noFill();
		}
		if (s.stroke)
		{
		  stroke(s.strokeColor);
		}
		else
		{
		  noStroke();
		}
		strokeWeight(s.strokeWeight);
		strokeCap(s.strokeCap);
		strokeJoin(s.strokeJoin);

		// Set the colorMode() for the material properties.
		// TODO this is really inefficient, need to just have a material() method,
		// but this has the least impact to the API.
		colorMode(PConstants_Fields.RGB, 1);
		ambient(s.ambientR, s.ambientG, s.ambientB);
		emissive(s.emissiveR, s.emissiveG, s.emissiveB);
		specular(s.specularR, s.specularG, s.specularB);
		shininess(s.shininess);

		/*
	  s.ambientR = ambientR;
	  s.ambientG = ambientG;
	  s.ambientB = ambientB;
	  s.specularR = specularR;
	  s.specularG = specularG;
	  s.specularB = specularB;
	  s.emissiveR = emissiveR;
	  s.emissiveG = emissiveG;
	  s.emissiveB = emissiveB;
	  s.shininess = shininess;
		 */
		//  material(s.ambientR, s.ambientG, s.ambientB,
		//           s.emissiveR, s.emissiveG, s.emissiveB,
		//           s.specularR, s.specularG, s.specularB,
		//           s.shininess);

		// Set this after the material properties.
		colorMode(s.colorMode, s.colorModeX, s.colorModeY, s.colorModeZ, s.colorModeA);

		// This is a bit asymmetric, since there's no way to do "noFont()",
		// and a null textFont will produce an error (since usually that means that
		// the font couldn't load properly). So in some cases, the font won't be
		// 'cleared' to null, even though that's technically correct.

		//TODO: After PFont
//		if (s.textFont != null)
//		{
//		  textFont(s.textFont, s.textSize);
//		  textLeading(s.textLeading);
//		}

			// These don't require a font to be set.
		textAlign(s.textAlign, s.textAlignY);
		textMode(s.textMode);
	  }


	  public virtual PStyle Style
	  {
		  get
		  {
			return getStyle(null);
		  }
	  }


	  public virtual PStyle getStyle(PStyle s) // ignore
	  {
		if (s == null)
		{
		  s = new PStyle();
		}

		s.imageMode = imageMode_Renamed;
		s.rectMode = rectMode_Renamed;
		s.ellipseMode = ellipseMode_Renamed;
		s.shapeMode = shapeMode_Renamed;

		s.blendMode = blendMode_Renamed;

		s.colorMode = colorMode_Renamed;
		s.colorModeX = colorModeX;
		s.colorModeY = colorModeY;
		s.colorModeZ = colorModeZ;
		s.colorModeA = colorModeA;

		s.tint = tint_Renamed;
		s.tintColor = tintColor;
		s.fill = fill_Renamed;
		s.fillColor = fillColor;
		s.stroke = stroke_Renamed;
		s.strokeColor = strokeColor;
		s.strokeWeight = strokeWeight_Renamed;
		s.strokeCap = strokeCap_Renamed;
		s.strokeJoin = strokeJoin_Renamed;

		s.ambientR = ambientR;
		s.ambientG = ambientG;
		s.ambientB = ambientB;
		s.specularR = specularR;
		s.specularG = specularG;
		s.specularB = specularB;
		s.emissiveR = emissiveR;
		s.emissiveG = emissiveG;
		s.emissiveB = emissiveB;
		s.shininess = shininess_Renamed;

			//TODO: After PFont
//		s.textFont = textFont_Renamed;
		s.textAlign = textAlign_Renamed;
		s.textAlignY = textAlignY;
		s.textMode = textMode_Renamed;
		s.textSize = textSize_Renamed;
		s.textLeading = textLeading_Renamed;

		return s;
	  }



	  //////////////////////////////////////////////////////////////

	  // STROKE CAP/JOIN/WEIGHT

	  /// <summary>
	  /// ( begin auto-generated from strokeWeight.xml )
	  /// 
	  /// Sets the width of the stroke used for lines, points, and the border
	  /// around shapes. All widths are set in units of pixels.
	  /// <br/> <br/>
	  /// When drawing with P3D, series of connected lines (such as the stroke
	  /// around a polygon, triangle, or ellipse) produce unattractive results
	  /// when a thick stroke weight is set (<a
	  /// href="http://code.google.com/p/processing/issues/detail?id=123">see
	  /// Issue 123</a>). With P3D, the minimum and maximum values for
	  /// <b>strokeWeight()</b> are controlled by the graphics card and the
	  /// operating system's OpenGL implementation. For instance, the thickness
	  /// may not go higher than 10 pixels.
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref shape:attributes </summary>
	  /// <param name="weight"> the weight (in pixels) of the stroke </param>
	  /// <seealso cref= PGraphics#stroke(int, float) </seealso>
	  /// <seealso cref= PGraphics#strokeJoin(int) </seealso>
	  /// <seealso cref= PGraphics#strokeCap(int) </seealso>
	  public virtual void strokeWeight(float weight)
	  {
		strokeWeight_Renamed = weight;
	  }

	  /// <summary>
	  /// ( begin auto-generated from strokeJoin.xml )
	  /// 
	  /// Sets the style of the joints which connect line segments. These joints
	  /// are either mitered, beveled, or rounded and specified with the
	  /// corresponding parameters MITER, BEVEL, and ROUND. The default joint is
	  /// MITER.
	  /// <br/> <br/>
	  /// This function is not available with the P3D renderer, (<a
	  /// href="http://code.google.com/p/processing/issues/detail?id=123">see
	  /// Issue 123</a>). More information about the renderers can be found in the
	  /// <b>size()</b> reference.
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref shape:attributes </summary>
	  /// <param name="join"> either MITER, BEVEL, ROUND </param>
	  /// <seealso cref= PGraphics#stroke(int, float) </seealso>
	  /// <seealso cref= PGraphics#strokeWeight(float) </seealso>
	  /// <seealso cref= PGraphics#strokeCap(int) </seealso>
	  public virtual void strokeJoin(int join)
	  {
		strokeJoin_Renamed = join;
	  }

	  /// <summary>
	  /// ( begin auto-generated from strokeCap.xml )
	  /// 
	  /// Sets the style for rendering line endings. These ends are either
	  /// squared, extended, or rounded and specified with the corresponding
	  /// parameters SQUARE, PROJECT, and ROUND. The default cap is ROUND.
	  /// <br/> <br/>
	  /// This function is not available with the P3D renderer (<a
	  /// href="http://code.google.com/p/processing/issues/detail?id=123">see
	  /// Issue 123</a>). More information about the renderers can be found in the
	  /// <b>size()</b> reference.
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref shape:attributes </summary>
	  /// <param name="cap"> either SQUARE, PROJECT, or ROUND </param>
	  /// <seealso cref= PGraphics#stroke(int, float) </seealso>
	  /// <seealso cref= PGraphics#strokeWeight(float) </seealso>
	  /// <seealso cref= PGraphics#strokeJoin(int) </seealso>
	  /// <seealso cref= PApplet#size(int, int, String, String) </seealso>
	  public virtual void strokeCap(int cap)
	  {
		strokeCap_Renamed = cap;
	  }



	  //////////////////////////////////////////////////////////////

	  // STROKE COLOR


	  /// <summary>
	  /// ( begin auto-generated from noStroke.xml )
	  /// 
	  /// Disables drawing the stroke (outline). If both <b>noStroke()</b> and
	  /// <b>noFill()</b> are called, nothing will be drawn to the screen.
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref color:setting </summary>
	  /// <seealso cref= PGraphics#stroke(int, float) </seealso>
	  /// <seealso cref= PGraphics#fill(float, float, float, float) </seealso>
	  /// <seealso cref= PGraphics#noFill() </seealso>
	  public virtual void noStroke()
	  {
		stroke_Renamed = false;
	  }


	  /// <summary>
	  /// ( begin auto-generated from stroke.xml )
	  /// 
	  /// Sets the color used to draw lines and borders around shapes. This color
	  /// is either specified in terms of the RGB or HSB color depending on the
	  /// current <b>colorMode()</b> (the default color space is RGB, with each
	  /// value in the range from 0 to 255).
	  /// <br/> <br/>
	  /// When using hexadecimal notation to specify a color, use "#" or "0x"
	  /// before the values (e.g. #CCFFAA, 0xFFCCFFAA). The # syntax uses six
	  /// digits to specify a color (the way colors are specified in HTML and
	  /// CSS). When using the hexadecimal notation starting with "0x", the
	  /// hexadecimal value must be specified with eight characters; the first two
	  /// characters define the alpha component and the remainder the red, green,
	  /// and blue components.
	  /// <br/> <br/>
	  /// The value for the parameter "gray" must be less than or equal to the
	  /// current maximum value as specified by <b>colorMode()</b>. The default
	  /// maximum value is 255.
	  /// 
	  /// ( end auto-generated )
	  /// </summary>
	  /// <param name="rgb"> color value in hexadecimal notation </param>
	  /// <seealso cref= PGraphics#noStroke() </seealso>
	  /// <seealso cref= PGraphics#fill(int, float) </seealso>
	  /// <seealso cref= PGraphics#noFill() </seealso>
	  /// <seealso cref= PGraphics#tint(int, float) </seealso>
	  /// <seealso cref= PGraphics#background(float, float, float, float) </seealso>
	  /// <seealso cref= PGraphics#colorMode(int, float, float, float, float) </seealso>
	  public virtual void stroke(int rgb)
	  {
		colorCalc(rgb);
		strokeFromCalc();
	  }


	  /// <param name="alpha"> opacity of the stroke </param>
	  public virtual void stroke(int rgb, float alpha)
	  {
		colorCalc(rgb, alpha);
		strokeFromCalc();
	  }


	  /// <param name="gray"> specifies a value between white and black </param>
	  public virtual void stroke(float gray)
	  {
		colorCalc(gray);
		strokeFromCalc();
	  }


	  public virtual void stroke(float gray, float alpha)
	  {
		colorCalc(gray, alpha);
		strokeFromCalc();
	  }


	  /// <param name="v1"> red or hue value (depending on current color mode) </param>
	  /// <param name="v2"> green or saturation value (depending on current color mode) </param>
	  /// <param name="v3"> blue or brightness value (depending on current color mode)
	  /// @webref color:setting </param>
	  public virtual void stroke(float v1, float v2, float v3)
	  {
		colorCalc(v1, v2, v3);
		strokeFromCalc();
	  }


	  public virtual void stroke(float v1, float v2, float v3, float alpha)
	  {
		colorCalc(v1, v2, v3, alpha);
		strokeFromCalc();
	  }


	  protected internal virtual void strokeFromCalc()
	  {
		stroke_Renamed = true;
		strokeR = calcR;
		strokeG = calcG;
		strokeB = calcB;
		strokeA = calcA;
		strokeRi = calcRi;
		strokeGi = calcGi;
		strokeBi = calcBi;
		strokeAi = calcAi;
		strokeColor = calcColor;
		strokeAlpha = calcAlpha;
	  }



	  //////////////////////////////////////////////////////////////

	  // TINT COLOR


	  /// <summary>
	  /// ( begin auto-generated from noTint.xml )
	  /// 
	  /// Removes the current fill value for displaying images and reverts to
	  /// displaying images with their original hues.
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref image:loading_displaying
	  /// @usage web_application </summary>
	  /// <seealso cref= PGraphics#tint(float, float, float, float) </seealso>
	  /// <seealso cref= PGraphics#image(PImage, float, float, float, float) </seealso>
	  public virtual void noTint()
	  {
		tint_Renamed = false;
	  }


	  /// <summary>
	  /// ( begin auto-generated from tint.xml )
	  /// 
	  /// Sets the fill value for displaying images. Images can be tinted to
	  /// specified colors or made transparent by setting the alpha.<br />
	  /// <br />
	  /// To make an image transparent, but not change it's color, use white as
	  /// the tint color and specify an alpha value. For instance, tint(255, 128)
	  /// will make an image 50% transparent (unless <b>colorMode()</b> has been
	  /// used).<br />
	  /// <br />
	  /// When using hexadecimal notation to specify a color, use "#" or "0x"
	  /// before the values (e.g. #CCFFAA, 0xFFCCFFAA). The # syntax uses six
	  /// digits to specify a color (the way colors are specified in HTML and
	  /// CSS). When using the hexadecimal notation starting with "0x", the
	  /// hexadecimal value must be specified with eight characters; the first two
	  /// characters define the alpha component and the remainder the red, green,
	  /// and blue components.<br />
	  /// <br />
	  /// The value for the parameter "gray" must be less than or equal to the
	  /// current maximum value as specified by <b>colorMode()</b>. The default
	  /// maximum value is 255.<br />
	  /// <br />
	  /// The <b>tint()</b> function is also used to control the coloring of
	  /// textures in 3D.
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref image:loading_displaying
	  /// @usage web_application </summary>
	  /// <param name="rgb"> color value in hexadecimal notation </param>
	  /// <seealso cref= PGraphics#noTint() </seealso>
	  /// <seealso cref= PGraphics#image(PImage, float, float, float, float) </seealso>
	  public virtual void tint(int rgb)
	  {
		colorCalc(rgb);
		tintFromCalc();
	  }


	  /// <param name="alpha"> opacity of the image </param>
	  public virtual void tint(int rgb, float alpha)
	  {
		colorCalc(rgb, alpha);
		tintFromCalc();
	  }


	  /// <param name="gray"> specifies a value between white and black </param>
	  public virtual void tint(float gray)
	  {
		colorCalc(gray);
		tintFromCalc();
	  }


	  public virtual void tint(float gray, float alpha)
	  {
		colorCalc(gray, alpha);
		tintFromCalc();
	  }

	/// <param name="v1"> red or hue value (depending on current color mode) </param>
	/// <param name="v2"> green or saturation value (depending on current color mode) </param>
	/// <param name="v3"> blue or brightness value (depending on current color mode) </param>
	  public virtual void tint(float v1, float v2, float v3)
	  {
		colorCalc(v1, v2, v3);
		tintFromCalc();
	  }


	  public virtual void tint(float v1, float v2, float v3, float alpha)
	  {
		colorCalc(v1, v2, v3, alpha);
		tintFromCalc();
	  }


	  protected internal virtual void tintFromCalc()
	  {
		tint_Renamed = true;
		tintR = calcR;
		tintG = calcG;
		tintB = calcB;
		tintA = calcA;
		tintRi = calcRi;
		tintGi = calcGi;
		tintBi = calcBi;
		tintAi = calcAi;
		tintColor = calcColor;
		tintAlpha = calcAlpha;
	  }



	  //////////////////////////////////////////////////////////////

	  // FILL COLOR


	  /// <summary>
	  /// ( begin auto-generated from noFill.xml )
	  /// 
	  /// Disables filling geometry. If both <b>noStroke()</b> and <b>noFill()</b>
	  /// are called, nothing will be drawn to the screen.
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref color:setting
	  /// @usage web_application </summary>
	  /// <seealso cref= PGraphics#fill(float, float, float, float) </seealso>
	  /// <seealso cref= PGraphics#stroke(int, float) </seealso>
	  /// <seealso cref= PGraphics#noStroke() </seealso>
	  public virtual void noFill()
	  {
		fill_Renamed = false;
	  }


	  /// <summary>
	  /// ( begin auto-generated from fill.xml )
	  /// 
	  /// Sets the color used to fill shapes. For example, if you run <b>fill(204,
	  /// 102, 0)</b>, all subsequent shapes will be filled with orange. This
	  /// color is either specified in terms of the RGB or HSB color depending on
	  /// the current <b>colorMode()</b> (the default color space is RGB, with
	  /// each value in the range from 0 to 255).
	  /// <br/> <br/>
	  /// When using hexadecimal notation to specify a color, use "#" or "0x"
	  /// before the values (e.g. #CCFFAA, 0xFFCCFFAA). The # syntax uses six
	  /// digits to specify a color (the way colors are specified in HTML and
	  /// CSS). When using the hexadecimal notation starting with "0x", the
	  /// hexadecimal value must be specified with eight characters; the first two
	  /// characters define the alpha component and the remainder the red, green,
	  /// and blue components.
	  /// <br/> <br/>
	  /// The value for the parameter "gray" must be less than or equal to the
	  /// current maximum value as specified by <b>colorMode()</b>. The default
	  /// maximum value is 255.
	  /// <br/> <br/>
	  /// To change the color of an image (or a texture), use tint().
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref color:setting
	  /// @usage web_application </summary>
	  /// <param name="rgb"> color variable or hex value </param>
	  /// <seealso cref= PGraphics#noFill() </seealso>
	  /// <seealso cref= PGraphics#stroke(int, float) </seealso>
	  /// <seealso cref= PGraphics#noStroke() </seealso>
	  /// <seealso cref= PGraphics#tint(int, float) </seealso>
	  /// <seealso cref= PGraphics#background(float, float, float, float) </seealso>
	  /// <seealso cref= PGraphics#colorMode(int, float, float, float, float) </seealso>
	  public virtual void fill(int rgb)
	  {
		colorCalc(rgb);
		fillFromCalc();
	  }

	  /// <param name="alpha"> opacity of the fill </param>
	  public virtual void fill(int rgb, float alpha)
	  {
		colorCalc(rgb, alpha);
		fillFromCalc();
	  }


	  /// <param name="gray"> number specifying value between white and black </param>
	  public virtual void fill(float gray)
	  {
		colorCalc(gray);
		fillFromCalc();
	  }


	  public virtual void fill(float gray, float alpha)
	  {
		colorCalc(gray, alpha);
		fillFromCalc();
	  }


	  /// <param name="v1"> red or hue value (depending on current color mode) </param>
	  /// <param name="v2"> green or saturation value (depending on current color mode) </param>
	  /// <param name="v3"> blue or brightness value (depending on current color mode) </param>
	  public virtual void fill(float v1, float v2, float v3)
	  {
		colorCalc(v1, v2, v3);
		fillFromCalc();
	  }


	  public virtual void fill(float v1, float v2, float v3, float alpha)
	  {
		colorCalc(v1, v2, v3, alpha);
		fillFromCalc();
	  }


	  protected internal virtual void fillFromCalc()
	  {
		fill_Renamed = true;
		fillR = calcR;
		fillG = calcG;
		fillB = calcB;
		fillA = calcA;
		fillRi = calcRi;
		fillGi = calcGi;
		fillBi = calcBi;
		fillAi = calcAi;
		fillColor = calcColor;
		fillAlpha = calcAlpha;
	  }



	  //////////////////////////////////////////////////////////////

	  // MATERIAL PROPERTIES

	  /// <summary>
	  /// ( begin auto-generated from ambient.xml )
	  /// 
	  /// Sets the ambient reflectance for shapes drawn to the screen. This is
	  /// combined with the ambient light component of environment. The color
	  /// components set through the parameters define the reflectance. For
	  /// example in the default color mode, setting v1=255, v2=126, v3=0, would
	  /// cause all the red light to reflect and half of the green light to
	  /// reflect. Used in combination with <b>emissive()</b>, <b>specular()</b>,
	  /// and <b>shininess()</b> in setting the material properties of shapes.
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref lights_camera:material_properties
	  /// @usage web_application </summary>
	  /// <param name="rgb"> any value of the color datatype </param>
	  /// <seealso cref= PGraphics#emissive(float, float, float) </seealso>
	  /// <seealso cref= PGraphics#specular(float, float, float) </seealso>
	  /// <seealso cref= PGraphics#shininess(float) </seealso>
	  public virtual void ambient(int rgb)
	  {
	//    if (((rgb & 0xff000000) == 0) && (rgb <= colorModeX)) {
	//      ambient((float) rgb);
	//
	//    } else {
	//      colorCalcARGB(rgb, colorModeA);
	//      ambientFromCalc();
	//    }
		colorCalc(rgb);
		ambientFromCalc();
	  }

	/// <param name="gray"> number specifying value between white and black </param>
	  public virtual void ambient(float gray)
	  {
		colorCalc(gray);
		ambientFromCalc();
	  }

	/// <param name="v1"> red or hue value (depending on current color mode) </param>
	/// <param name="v2"> green or saturation value (depending on current color mode) </param>
	/// <param name="v3"> blue or brightness value (depending on current color mode) </param>
	  public virtual void ambient(float v1, float v2, float v3)
	  {
		colorCalc(v1, v2, v3);
		ambientFromCalc();
	  }


	  protected internal virtual void ambientFromCalc()
	  {
		ambientColor = calcColor;
		ambientR = calcR;
		ambientG = calcG;
		ambientB = calcB;
		setAmbient = true;
	  }

	  /// <summary>
	  /// ( begin auto-generated from specular.xml )
	  /// 
	  /// Sets the specular color of the materials used for shapes drawn to the
	  /// screen, which sets the color of hightlights. Specular refers to light
	  /// which bounces off a surface in a perferred direction (rather than
	  /// bouncing in all directions like a diffuse light). Used in combination
	  /// with <b>emissive()</b>, <b>ambient()</b>, and <b>shininess()</b> in
	  /// setting the material properties of shapes.
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref lights_camera:material_properties
	  /// @usage web_application </summary>
	  /// <param name="rgb"> color to set </param>
	  /// <seealso cref= PGraphics#lightSpecular(float, float, float) </seealso>
	  /// <seealso cref= PGraphics#ambient(float, float, float) </seealso>
	  /// <seealso cref= PGraphics#emissive(float, float, float) </seealso>
	  /// <seealso cref= PGraphics#shininess(float) </seealso>
	  public virtual void specular(int rgb)
	  {
	//    if (((rgb & 0xff000000) == 0) && (rgb <= colorModeX)) {
	//      specular((float) rgb);
	//
	//    } else {
	//      colorCalcARGB(rgb, colorModeA);
	//      specularFromCalc();
	//    }
		colorCalc(rgb);
		specularFromCalc();
	  }


	/// <summary>
	/// gray number specifying value between white and black
	/// </summary>
	  public virtual void specular(float gray)
	  {
		colorCalc(gray);
		specularFromCalc();
	  }


	/// <param name="v1"> red or hue value (depending on current color mode) </param>
	/// <param name="v2"> green or saturation value (depending on current color mode) </param>
	/// <param name="v3"> blue or brightness value (depending on current color mode) </param>
	  public virtual void specular(float v1, float v2, float v3)
	  {
		colorCalc(v1, v2, v3);
		specularFromCalc();
	  }


	  protected internal virtual void specularFromCalc()
	  {
		specularColor = calcColor;
		specularR = calcR;
		specularG = calcG;
		specularB = calcB;
	  }


	  /// <summary>
	  /// ( begin auto-generated from shininess.xml )
	  /// 
	  /// Sets the amount of gloss in the surface of shapes. Used in combination
	  /// with <b>ambient()</b>, <b>specular()</b>, and <b>emissive()</b> in
	  /// setting the material properties of shapes.
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref lights_camera:material_properties
	  /// @usage web_application </summary>
	  /// <param name="shine"> degree of shininess </param>
	  /// <seealso cref= PGraphics#emissive(float, float, float) </seealso>
	  /// <seealso cref= PGraphics#ambient(float, float, float) </seealso>
	  /// <seealso cref= PGraphics#specular(float, float, float) </seealso>
	  public virtual void shininess(float shine)
	  {
		shininess_Renamed = shine;
	  }

	  /// <summary>
	  /// ( begin auto-generated from emissive.xml )
	  /// 
	  /// Sets the emissive color of the material used for drawing shapes drawn to
	  /// the screen. Used in combination with <b>ambient()</b>,
	  /// <b>specular()</b>, and <b>shininess()</b> in setting the material
	  /// properties of shapes.
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref lights_camera:material_properties
	  /// @usage web_application </summary>
	  /// <param name="rgb"> color to set </param>
	  /// <seealso cref= PGraphics#ambient(float, float, float) </seealso>
	  /// <seealso cref= PGraphics#specular(float, float, float) </seealso>
	  /// <seealso cref= PGraphics#shininess(float) </seealso>
	  public virtual void emissive(int rgb)
	  {
	//    if (((rgb & 0xff000000) == 0) && (rgb <= colorModeX)) {
	//      emissive((float) rgb);
	//
	//    } else {
	//      colorCalcARGB(rgb, colorModeA);
	//      emissiveFromCalc();
	//    }
		colorCalc(rgb);
		emissiveFromCalc();
	  }

	  /// <summary>
	  /// gray number specifying value between white and black
	  /// </summary>
	  public virtual void emissive(float gray)
	  {
		colorCalc(gray);
		emissiveFromCalc();
	  }

	  /// <param name="v1"> red or hue value (depending on current color mode) </param>
	  /// <param name="v2"> green or saturation value (depending on current color mode) </param>
	  /// <param name="v3"> blue or brightness value (depending on current color mode) </param>
	  public virtual void emissive(float v1, float v2, float v3)
	  {
		colorCalc(v1, v2, v3);
		emissiveFromCalc();
	  }


	  protected internal virtual void emissiveFromCalc()
	  {
		emissiveColor = calcColor;
		emissiveR = calcR;
		emissiveG = calcG;
		emissiveB = calcB;
	  }



	  //////////////////////////////////////////////////////////////

	  // LIGHTS

	  // The details of lighting are very implementation-specific, so this base
	  // class does not handle any details of settings lights. It does however
	  // display warning messages that the functions are not available.

	  /// <summary>
	  /// ( begin auto-generated from lights.xml )
	  /// 
	  /// Sets the default ambient light, directional light, falloff, and specular
	  /// values. The defaults are ambientLight(128, 128, 128) and
	  /// directionalLight(128, 128, 128, 0, 0, -1), lightFalloff(1, 0, 0), and
	  /// lightSpecular(0, 0, 0). Lights need to be included in the draw() to
	  /// remain persistent in a looping program. Placing them in the setup() of a
	  /// looping program will cause them to only have an effect the first time
	  /// through the loop.
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref lights_camera:lights
	  /// @usage web_application </summary>
	  /// <seealso cref= PGraphics#ambientLight(float, float, float, float, float, float) </seealso>
	  /// <seealso cref= PGraphics#directionalLight(float, float, float, float, float, float) </seealso>
	  /// <seealso cref= PGraphics#pointLight(float, float, float, float, float, float) </seealso>
	  /// <seealso cref= PGraphics#spotLight(float, float, float, float, float, float, float, float, float, float, float) </seealso>
	  /// <seealso cref= PGraphics#noLights() </seealso>
	  public virtual void lights()
	  {
		showMethodWarning("lights");
	  }

	  /// <summary>
	  /// ( begin auto-generated from noLights.xml )
	  /// 
	  /// Disable all lighting. Lighting is turned off by default and enabled with
	  /// the <b>lights()</b> function. This function can be used to disable
	  /// lighting so that 2D geometry (which does not require lighting) can be
	  /// drawn after a set of lighted 3D geometry.
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref lights_camera:lights
	  /// @usage web_application </summary>
	  /// <seealso cref= PGraphics#lights() </seealso>
	  public virtual void noLights()
	  {
		showMethodWarning("noLights");
	  }

	  /// <summary>
	  /// ( begin auto-generated from ambientLight.xml )
	  /// 
	  /// Adds an ambient light. Ambient light doesn't come from a specific
	  /// direction, the rays have light have bounced around so much that objects
	  /// are evenly lit from all sides. Ambient lights are almost always used in
	  /// combination with other types of lights. Lights need to be included in
	  /// the <b>draw()</b> to remain persistent in a looping program. Placing
	  /// them in the <b>setup()</b> of a looping program will cause them to only
	  /// have an effect the first time through the loop. The effect of the
	  /// parameters is determined by the current color mode.
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref lights_camera:lights
	  /// @usage web_application </summary>
	  /// <param name="v1"> red or hue value (depending on current color mode) </param>
	  /// <param name="v2"> green or saturation value (depending on current color mode) </param>
	  /// <param name="v3"> blue or brightness value (depending on current color mode) </param>
	  /// <seealso cref= PGraphics#lights() </seealso>
	  /// <seealso cref= PGraphics#directionalLight(float, float, float, float, float, float) </seealso>
	  /// <seealso cref= PGraphics#pointLight(float, float, float, float, float, float) </seealso>
	  /// <seealso cref= PGraphics#spotLight(float, float, float, float, float, float, float, float, float, float, float) </seealso>
	  public virtual void ambientLight(float v1, float v2, float v3)
	  {
		showMethodWarning("ambientLight");
	  }

	  /// <param name="x"> x-coordinate of the light </param>
	  /// <param name="y"> y-coordinate of the light </param>
	  /// <param name="z"> z-coordinate of the light </param>
	  public virtual void ambientLight(float v1, float v2, float v3, float x, float y, float z)
	  {
		showMethodWarning("ambientLight");
	  }

	  /// <summary>
	  /// ( begin auto-generated from directionalLight.xml )
	  /// 
	  /// Adds a directional light. Directional light comes from one direction and
	  /// is stronger when hitting a surface squarely and weaker if it hits at a a
	  /// gentle angle. After hitting a surface, a directional lights scatters in
	  /// all directions. Lights need to be included in the <b>draw()</b> to
	  /// remain persistent in a looping program. Placing them in the
	  /// <b>setup()</b> of a looping program will cause them to only have an
	  /// effect the first time through the loop. The affect of the <b>v1</b>,
	  /// <b>v2</b>, and <b>v3</b> parameters is determined by the current color
	  /// mode. The <b>nx</b>, <b>ny</b>, and <b>nz</b> parameters specify the
	  /// direction the light is facing. For example, setting <b>ny</b> to -1 will
	  /// cause the geometry to be lit from below (the light is facing directly upward).
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref lights_camera:lights
	  /// @usage web_application </summary>
	  /// <param name="v1"> red or hue value (depending on current color mode) </param>
	  /// <param name="v2"> green or saturation value (depending on current color mode) </param>
	  /// <param name="v3"> blue or brightness value (depending on current color mode) </param>
	  /// <param name="nx"> direction along the x-axis </param>
	  /// <param name="ny"> direction along the y-axis </param>
	  /// <param name="nz"> direction along the z-axis </param>
	  /// <seealso cref= PGraphics#lights() </seealso>
	  /// <seealso cref= PGraphics#ambientLight(float, float, float, float, float, float) </seealso>
	  /// <seealso cref= PGraphics#pointLight(float, float, float, float, float, float) </seealso>
	  /// <seealso cref= PGraphics#spotLight(float, float, float, float, float, float, float, float, float, float, float) </seealso>
	  public virtual void directionalLight(float v1, float v2, float v3, float nx, float ny, float nz)
	  {
		showMethodWarning("directionalLight");
	  }

	  /// <summary>
	  /// ( begin auto-generated from pointLight.xml )
	  /// 
	  /// Adds a point light. Lights need to be included in the <b>draw()</b> to
	  /// remain persistent in a looping program. Placing them in the
	  /// <b>setup()</b> of a looping program will cause them to only have an
	  /// effect the first time through the loop. The affect of the <b>v1</b>,
	  /// <b>v2</b>, and <b>v3</b> parameters is determined by the current color
	  /// mode. The <b>x</b>, <b>y</b>, and <b>z</b> parameters set the position
	  /// of the light.
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref lights_camera:lights
	  /// @usage web_application </summary>
	  /// <param name="v1"> red or hue value (depending on current color mode) </param>
	  /// <param name="v2"> green or saturation value (depending on current color mode) </param>
	  /// <param name="v3"> blue or brightness value (depending on current color mode) </param>
	  /// <param name="x"> x-coordinate of the light </param>
	  /// <param name="y"> y-coordinate of the light </param>
	  /// <param name="z"> z-coordinate of the light </param>
	  /// <seealso cref= PGraphics#lights() </seealso>
	  /// <seealso cref= PGraphics#directionalLight(float, float, float, float, float, float) </seealso>
	  /// <seealso cref= PGraphics#ambientLight(float, float, float, float, float, float) </seealso>
	  /// <seealso cref= PGraphics#spotLight(float, float, float, float, float, float, float, float, float, float, float) </seealso>
	  public virtual void pointLight(float v1, float v2, float v3, float x, float y, float z)
	  {
		showMethodWarning("pointLight");
	  }

	  /// <summary>
	  /// ( begin auto-generated from spotLight.xml )
	  /// 
	  /// Adds a spot light. Lights need to be included in the <b>draw()</b> to
	  /// remain persistent in a looping program. Placing them in the
	  /// <b>setup()</b> of a looping program will cause them to only have an
	  /// effect the first time through the loop. The affect of the <b>v1</b>,
	  /// <b>v2</b>, and <b>v3</b> parameters is determined by the current color
	  /// mode. The <b>x</b>, <b>y</b>, and <b>z</b> parameters specify the
	  /// position of the light and <b>nx</b>, <b>ny</b>, <b>nz</b> specify the
	  /// direction or light. The <b>angle</b> parameter affects angle of the
	  /// spotlight cone.
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref lights_camera:lights
	  /// @usage web_application </summary>
	  /// <param name="v1"> red or hue value (depending on current color mode) </param>
	  /// <param name="v2"> green or saturation value (depending on current color mode) </param>
	  /// <param name="v3"> blue or brightness value (depending on current color mode) </param>
	  /// <param name="x"> x-coordinate of the light </param>
	  /// <param name="y"> y-coordinate of the light </param>
	  /// <param name="z"> z-coordinate of the light </param>
	  /// <param name="nx"> direction along the x axis </param>
	  /// <param name="ny"> direction along the y axis </param>
	  /// <param name="nz"> direction along the z axis </param>
	  /// <param name="angle"> angle of the spotlight cone </param>
	  /// <param name="concentration"> exponent determining the center bias of the cone </param>
	  /// <seealso cref= PGraphics#lights() </seealso>
	  /// <seealso cref= PGraphics#directionalLight(float, float, float, float, float, float) </seealso>
	  /// <seealso cref= PGraphics#pointLight(float, float, float, float, float, float) </seealso>
	  /// <seealso cref= PGraphics#ambientLight(float, float, float, float, float, float) </seealso>
	  public virtual void spotLight(float v1, float v2, float v3, float x, float y, float z, float nx, float ny, float nz, float angle, float concentration)
	  {
		showMethodWarning("spotLight");
	  }

	  /// <summary>
	  /// ( begin auto-generated from lightFalloff.xml )
	  /// 
	  /// Sets the falloff rates for point lights, spot lights, and ambient
	  /// lights. The parameters are used to determine the falloff with the
	  /// following equation:<br /><br />d = distance from light position to
	  /// vertex position<br />falloff = 1 / (CONSTANT + d * LINEAR + (d*d) *
	  /// QUADRATIC)<br /><br />Like <b>fill()</b>, it affects only the elements
	  /// which are created after it in the code. The default value if
	  /// <b>LightFalloff(1.0, 0.0, 0.0)</b>. Thinking about an ambient light with
	  /// a falloff can be tricky. It is used, for example, if you wanted a region
	  /// of your scene to be lit ambiently one color and another region to be lit
	  /// ambiently by another color, you would use an ambient light with location
	  /// and falloff. You can think of it as a point light that doesn't care
	  /// which direction a surface is facing.
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref lights_camera:lights
	  /// @usage web_application </summary>
	  /// <param name="constant"> constant value or determining falloff </param>
	  /// <param name="linear"> linear value for determining falloff </param>
	  /// <param name="quadratic"> quadratic value for determining falloff </param>
	  /// <seealso cref= PGraphics#lights() </seealso>
	  /// <seealso cref= PGraphics#ambientLight(float, float, float, float, float, float) </seealso>
	  /// <seealso cref= PGraphics#pointLight(float, float, float, float, float, float) </seealso>
	  /// <seealso cref= PGraphics#spotLight(float, float, float, float, float, float, float, float, float, float, float) </seealso>
	  /// <seealso cref= PGraphics#lightSpecular(float, float, float) </seealso>
	  public virtual void lightFalloff(float constant, float linear, float quadratic)
	  {
		showMethodWarning("lightFalloff");
	  }

	  /// <summary>
	  /// ( begin auto-generated from lightSpecular.xml )
	  /// 
	  /// Sets the specular color for lights. Like <b>fill()</b>, it affects only
	  /// the elements which are created after it in the code. Specular refers to
	  /// light which bounces off a surface in a perferred direction (rather than
	  /// bouncing in all directions like a diffuse light) and is used for
	  /// creating highlights. The specular quality of a light interacts with the
	  /// specular material qualities set through the <b>specular()</b> and
	  /// <b>shininess()</b> functions.
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref lights_camera:lights
	  /// @usage web_application </summary>
	  /// <param name="v1"> red or hue value (depending on current color mode) </param>
	  /// <param name="v2"> green or saturation value (depending on current color mode) </param>
	  /// <param name="v3"> blue or brightness value (depending on current color mode) </param>
	  /// <seealso cref= PGraphics#specular(float, float, float) </seealso>
	  /// <seealso cref= PGraphics#lights() </seealso>
	  /// <seealso cref= PGraphics#ambientLight(float, float, float, float, float, float) </seealso>
	  /// <seealso cref= PGraphics#pointLight(float, float, float, float, float, float) </seealso>
	  /// <seealso cref= PGraphics#spotLight(float, float, float, float, float, float, float, float, float, float, float) </seealso>
	  public virtual void lightSpecular(float v1, float v2, float v3)
	  {
		showMethodWarning("lightSpecular");
	  }



	  //////////////////////////////////////////////////////////////

	  // BACKGROUND


	  /// <summary>
	  /// ( begin auto-generated from background.xml )
	  /// 
	  /// The <b>background()</b> function sets the color used for the background
	  /// of the Processing window. The default background is light gray. In the
	  /// <b>draw()</b> function, the background color is used to clear the
	  /// display window at the beginning of each frame.
	  /// <br/> <br/>
	  /// An image can also be used as the background for a sketch, however its
	  /// width and height must be the same size as the sketch window. To resize
	  /// an image 'b' to the size of the sketch window, use b.resize(width, height).
	  /// <br/> <br/>
	  /// Images used as background will ignore the current <b>tint()</b> setting.
	  /// <br/> <br/>
	  /// It is not possible to use transparency (alpha) in background colors with
	  /// the main drawing surface, however they will work properly with <b>createGraphics()</b>.
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// <h3>Advanced</h3>
	  /// <para>Clear the background with a color that includes an alpha value. This can
	  /// only be used with objects created by createGraphics(), because the main
	  /// drawing surface cannot be set transparent.</para>
	  /// <para>It might be tempting to use this function to partially clear the screen
	  /// on each frame, however that's not how this function works. When calling
	  /// background(), the pixels will be replaced with pixels that have that level
	  /// of transparency. To do a semi-transparent overlay, use fill() with alpha
	  /// and draw a rectangle.</para>
	  /// 
	  /// @webref color:setting
	  /// @usage web_application </summary>
	  /// <param name="rgb"> any value of the color datatype </param>
	  /// <seealso cref= PGraphics#stroke(float) </seealso>
	  /// <seealso cref= PGraphics#fill(float) </seealso>
	  /// <seealso cref= PGraphics#tint(float) </seealso>
	  /// <seealso cref= PGraphics#colorMode(int) </seealso>
	  public virtual void background(int rgb)
	  {
	//    if (((rgb & 0xff000000) == 0) && (rgb <= colorModeX)) {
	//      background((float) rgb);
	//
	//    } else {
	//      if (format == RGB) {
	//        rgb |= 0xff000000;  // ignore alpha for main drawing surface
	//      }
	//      colorCalcARGB(rgb, colorModeA);
	//      backgroundFromCalc();
	//      backgroundImpl();
	//    }
		colorCalc(rgb);
		backgroundFromCalc();
	  }


	  /// <param name="alpha"> opacity of the background </param>
	  public virtual void background(int rgb, float alpha)
	  {
	//    if (format == RGB) {
	//      background(rgb);  // ignore alpha for main drawing surface
	//
	//    } else {
	//      if (((rgb & 0xff000000) == 0) && (rgb <= colorModeX)) {
	//        background((float) rgb, alpha);
	//
	//      } else {
	//        colorCalcARGB(rgb, alpha);
	//        backgroundFromCalc();
	//        backgroundImpl();
	//      }
	//    }
		colorCalc(rgb, alpha);
		backgroundFromCalc();
	  }


	  /// <param name="gray"> specifies a value between white and black </param>
	  public virtual void background(float gray)
	  {
		colorCalc(gray);
		backgroundFromCalc();
	//    backgroundImpl();
	  }


	  public virtual void background(float gray, float alpha)
	  {
		if (format == PConstants_Fields.RGB)
		{
		  background(gray); // ignore alpha for main drawing surface

		}
		else
		{
		  colorCalc(gray, alpha);
		  backgroundFromCalc();
	//      backgroundImpl();
		}
	  }


	  /// <param name="v1"> red or hue value (depending on the current color mode) </param>
	  /// <param name="v2"> green or saturation value (depending on the current color mode) </param>
	  /// <param name="v3"> blue or brightness value (depending on the current color mode) </param>
	  public virtual void background(float v1, float v2, float v3)
	  {
		colorCalc(v1, v2, v3);
		backgroundFromCalc();
	//    backgroundImpl();
	  }


	  public virtual void background(float v1, float v2, float v3, float alpha)
	  {
		colorCalc(v1, v2, v3, alpha);
		backgroundFromCalc();
	  }

	  /// <summary>
	  /// @webref color:setting
	  /// </summary>
	  public virtual void clear()
	  {
		background(0, 0, 0, 0);
	  }


	  protected internal virtual void backgroundFromCalc()
	  {
		backgroundR = calcR;
		backgroundG = calcG;
		backgroundB = calcB;
		backgroundA = (format == PConstants_Fields.RGB) ? colorModeA : calcA;
		backgroundRi = calcRi;
		backgroundGi = calcGi;
		backgroundBi = calcBi;
		backgroundAi = (format == PConstants_Fields.RGB) ? 255 : calcAi;
		backgroundAlpha = (format == PConstants_Fields.RGB) ? false : calcAlpha;
		backgroundColor = calcColor;

		backgroundImpl();
	  }


	  /// <summary>
	  /// Takes an RGB or ARGB image and sets it as the background.
	  /// The width and height of the image must be the same size as the sketch.
	  /// Use image.resize(width, height) to make short work of such a task.<br/>
	  /// <br/>
	  /// Note that even if the image is set as RGB, the high 8 bits of each pixel
	  /// should be set opaque (0xFF000000) because the image data will be copied
	  /// directly to the screen, and non-opaque background images may have strange
	  /// behavior. Use image.filter(OPAQUE) to handle this easily.<br/>
	  /// <br/>
	  /// When using 3D, this will also clear the zbuffer (if it exists).
	  /// </summary>
	  /// <param name="image"> PImage to set as background (must be same size as the sketch window) </param>
	  public virtual void background(PImage image)
	  {
		if ((image.width != width) || (image.height != height))
		{
		  throw new Exception(PConstants_Fields.ERROR_BACKGROUND_IMAGE_SIZE);
		}
		if ((image.format != PConstants_Fields.RGB) && (image.format != PConstants_Fields.ARGB))
		{
		  throw new Exception(PConstants_Fields.ERROR_BACKGROUND_IMAGE_FORMAT);
		}
		backgroundColor = 0; // just zero it out for images
		backgroundImpl(image);
	  }


	  /// <summary>
	  /// Actually set the background image. This is separated from the error
	  /// handling and other semantic goofiness that is shared across renderers.
	  /// </summary>
	  protected internal virtual void backgroundImpl(PImage image)
	  {
		// blit image to the screen
		set(0, 0, image);
	  }


	  /// <summary>
	  /// Actual implementation of clearing the background, now that the
	  /// internal variables for background color have been set. Called by the
	  /// backgroundFromCalc() method, which is what all the other background()
	  /// methods call once the work is done.
	  /// </summary>
	  protected internal virtual void backgroundImpl()
	  {
		pushStyle();
		pushMatrix();
		resetMatrix();
		fill(backgroundColor);
		rect(0, 0, width, height);
		popMatrix();
		popStyle();
	  }


	  /// <summary>
	  /// Callback to handle clearing the background when begin/endRaw is in use.
	  /// Handled as separate function for OpenGL (or other) subclasses that
	  /// override backgroundImpl() but still needs this to work properly.
	  /// </summary>
	//  protected void backgroundRawImpl() {
	//    if (raw != null) {
	//      raw.colorMode(RGB, 1);
	//      raw.noStroke();
	//      raw.fill(backgroundR, backgroundG, backgroundB);
	//      raw.beginShape(TRIANGLES);
	//
	//      raw.vertex(0, 0);
	//      raw.vertex(width, 0);
	//      raw.vertex(0, height);
	//
	//      raw.vertex(width, 0);
	//      raw.vertex(width, height);
	//      raw.vertex(0, height);
	//
	//      raw.endShape();
	//    }
	//  }



	  //////////////////////////////////////////////////////////////

	  // COLOR MODE

	  /// <summary>
	  /// ( begin auto-generated from colorMode.xml )
	  /// 
	  /// Changes the way Processing interprets color data. By default, the
	  /// parameters for <b>fill()</b>, <b>stroke()</b>, <b>background()</b>, and
	  /// <b>color()</b> are defined by values between 0 and 255 using the RGB
	  /// color model. The <b>colorMode()</b> function is used to change the
	  /// numerical range used for specifying colors and to switch color systems.
	  /// For example, calling <b>colorMode(RGB, 1.0)</b> will specify that values
	  /// are specified between 0 and 1. The limits for defining colors are
	  /// altered by setting the parameters range1, range2, range3, and range 4.
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref color:setting
	  /// @usage web_application </summary>
	  /// <param name="mode"> Either RGB or HSB, corresponding to Red/Green/Blue and Hue/Saturation/Brightness </param>
	  /// <seealso cref= PGraphics#background(float) </seealso>
	  /// <seealso cref= PGraphics#fill(float) </seealso>
	  /// <seealso cref= PGraphics#stroke(float) </seealso>
	  public virtual void colorMode(int mode)
	  {
		colorMode(mode, colorModeX, colorModeY, colorModeZ, colorModeA);
	  }


	  /// <param name="max"> range for all color elements </param>
	  public virtual void colorMode(int mode, float max)
	  {
		colorMode(mode, max, max, max, max);
	  }


	  /// <param name="max1"> range for the red or hue depending on the current color mode </param>
	  /// <param name="max2"> range for the green or saturation depending on the current color mode </param>
	  /// <param name="max3"> range for the blue or brightness depending on the current color mode </param>
	  public virtual void colorMode(int mode, float max1, float max2, float max3)
	  {
		colorMode(mode, max1, max2, max3, colorModeA);
	  }


	  /// <param name="maxA"> range for the alpha </param>
	  public virtual void colorMode(int mode, float max1, float max2, float max3, float maxA)
	  {
		colorMode_Renamed = mode;

		colorModeX = max1; // still needs to be set for hsb
		colorModeY = max2;
		colorModeZ = max3;
		colorModeA = maxA;

		// if color max values are all 1, then no need to scale
		colorModeScale = ((maxA != 1) || (max1 != max2) || (max2 != max3) || (max3 != maxA));

		// if color is rgb/0..255 this will make it easier for the
		// red() green() etc functions
		colorModeDefault = (colorMode_Renamed == PConstants_Fields.RGB) && (colorModeA == 255) && (colorModeX == 255) && (colorModeY == 255) && (colorModeZ == 255);
	  }



	  //////////////////////////////////////////////////////////////

	  // COLOR CALCULATIONS

	  // Given input values for coloring, these functions will fill the calcXxxx
	  // variables with values that have been properly filtered through the
	  // current colorMode settings.

	  // Renderers that need to subclass any drawing properties such as fill or
	  // stroke will usally want to override methods like fillFromCalc (or the
	  // same for stroke, ambient, etc.) That way the color calcuations are
	  // covered by this based PGraphics class, leaving only a single function
	  // to override/implement in the subclass.


	  /// <summary>
	  /// Set the fill to either a grayscale value or an ARGB int.
	  /// <P>
	  /// The problem with this code is that it has to detect between these two
	  /// situations automatically. This is done by checking to see if the high bits
	  /// (the alpha for 0xAA000000) is set, and if not, whether the color value
	  /// that follows is less than colorModeX (first param passed to colorMode).
	  /// <P>
	  /// This auto-detect would break in the following situation:
	  /// <PRE>size(256, 256);
	  /// for (int i = 0; i < 256; i++) {
	  ///   color c = color(0, 0, 0, i);
	  ///   stroke(c);
	  ///   line(i, 0, i, 256);
	  /// }</PRE>
	  /// ...on the first time through the loop, where (i == 0), since the color
	  /// itself is zero (black) then it would appear indistinguishable from code
	  /// that reads "fill(0)". The solution is to use the four parameter versions
	  /// of stroke or fill to more directly specify the desired result.
	  /// </summary>
	  protected internal virtual void colorCalc(int rgb)
	  {
		if (((rgb & 0xff000000) == 0) && (rgb <= colorModeX))
		{
		  colorCalc((float) rgb);

		}
		else
		{
		  colorCalcARGB(rgb, colorModeA);
		}
	  }


	  protected internal virtual void colorCalc(int rgb, float alpha)
	  {
		if (((rgb & 0xff000000) == 0) && (rgb <= colorModeX)) // see above
		{
		  colorCalc((float) rgb, alpha);

		}
		else
		{
		  colorCalcARGB(rgb, alpha);
		}
	  }


	  protected internal virtual void colorCalc(float gray)
	  {
		colorCalc(gray, colorModeA);
	  }


	  protected internal virtual void colorCalc(float gray, float alpha)
	  {
		if (gray > colorModeX)
		{
			gray = colorModeX;
		}
		if (alpha > colorModeA)
		{
			alpha = colorModeA;
		}

		if (gray < 0)
		{
			gray = 0;
		}
		if (alpha < 0)
		{
			alpha = 0;
		}

		calcR = colorModeScale ? (gray / colorModeX) : gray;
		calcG = calcR;
		calcB = calcR;
		calcA = colorModeScale ? (alpha / colorModeA) : alpha;

		calcRi = (int)(calcR * 255);
		calcGi = (int)(calcG * 255);
		calcBi = (int)(calcB * 255);
		calcAi = (int)(calcA * 255);
		calcColor = (calcAi << 24) | (calcRi << 16) | (calcGi << 8) | calcBi;
		calcAlpha = (calcAi != 255);
	  }


	  protected internal virtual void colorCalc(float x, float y, float z)
	  {
		colorCalc(x, y, z, colorModeA);
	  }


	  protected internal virtual void colorCalc(float x, float y, float z, float a)
	  {
		if (x > colorModeX)
		{
			x = colorModeX;
		}
		if (y > colorModeY)
		{
			y = colorModeY;
		}
		if (z > colorModeZ)
		{
			z = colorModeZ;
		}
		if (a > colorModeA)
		{
			a = colorModeA;
		}

		if (x < 0)
		{
			x = 0;
		}
		if (y < 0)
		{
			y = 0;
		}
		if (z < 0)
		{
			z = 0;
		}
		if (a < 0)
		{
			a = 0;
		}

		switch (colorMode_Renamed)
		{
		case PConstants_Fields.RGB:
		  if (colorModeScale)
		  {
			calcR = x / colorModeX;
			calcG = y / colorModeY;
			calcB = z / colorModeZ;
			calcA = a / colorModeA;
		  }
		  else
		  {
			calcR = x;
			calcG = y;
			calcB = z;
			calcA = a;
		  }
		  break;

		case PConstants_Fields.HSB:
		  x /= colorModeX; // h
		  y /= colorModeY; // s
		  z /= colorModeZ; // b

		  calcA = colorModeScale ? (a / colorModeA) : a;

		  if (y == 0) // saturation == 0
		  {
			calcR = calcG = calcB = z;

		  }
		  else
		  {
			float which = (x - (int)x) * 6.0f;
			float f = which - (int)which;
			float p = z * (1.0f - y);
			float q = z * (1.0f - y * f);
			float t = z * (1.0f - (y * (1.0f - f)));

			switch ((int)which)
			{
			case 0:
				calcR = z;
				calcG = t;
				calcB = p;
				break;
			case 1:
				calcR = q;
				calcG = z;
				calcB = p;
				break;
			case 2:
				calcR = p;
				calcG = z;
				calcB = t;
				break;
			case 3:
				calcR = p;
				calcG = q;
				calcB = z;
				break;
			case 4:
				calcR = t;
				calcG = p;
				calcB = z;
				break;
			case 5:
				calcR = z;
				calcG = p;
				calcB = q;
				break;
			}
		  }
		  break;
		}
		calcRi = (int)(255 * calcR);
		calcGi = (int)(255 * calcG);
		calcBi = (int)(255 * calcB);
		calcAi = (int)(255 * calcA);
		calcColor = (calcAi << 24) | (calcRi << 16) | (calcGi << 8) | calcBi;
		calcAlpha = (calcAi != 255);
	  }


	  /// <summary>
	  /// Unpacks AARRGGBB color for direct use with colorCalc.
	  /// <P>
	  /// Handled here with its own function since this is indepenent
	  /// of the color mode.
	  /// <P>
	  /// Strangely the old version of this code ignored the alpha
	  /// value. not sure if that was a bug or what.
	  /// <P>
	  /// Note, no need for a bounds check since it's a 32 bit number.
	  /// </summary>
	  protected internal virtual void colorCalcARGB(int argb, float alpha)
	  {
		if (alpha == colorModeA)
		{
		  calcAi = (argb >> 24) & 0xff;
		  calcColor = argb;
		}
		else
		{
		  calcAi = (int)(((argb >> 24) & 0xff) * (alpha / colorModeA));
		  calcColor = (calcAi << 24) | (argb & 0xFFFFFF);
		}
		calcRi = (argb >> 16) & 0xff;
		calcGi = (argb >> 8) & 0xff;
		calcBi = argb & 0xff;
		calcA = calcAi / 255.0f;
		calcR = calcRi / 255.0f;
		calcG = calcGi / 255.0f;
		calcB = calcBi / 255.0f;
		calcAlpha = (calcAi != 255);
	  }



	  //////////////////////////////////////////////////////////////

	  // COLOR DATATYPE STUFFING

	  // The 'color' primitive type in Processing syntax is in fact a 32-bit int.
	  // These functions handle stuffing color values into a 32-bit cage based
	  // on the current colorMode settings.

	  // These functions are really slow (because they take the current colorMode
	  // into account), but they're easy to use. Advanced users can write their
	  // own bit shifting operations to setup 'color' data types.


	  public int color(int c) // ignore
	  {
	//    if (((c & 0xff000000) == 0) && (c <= colorModeX)) {
	//      if (colorModeDefault) {
	//        // bounds checking to make sure the numbers aren't to high or low
	//        if (c > 255) c = 255; else if (c < 0) c = 0;
	//        return 0xff000000 | (c << 16) | (c << 8) | c;
	//      } else {
	//        colorCalc(c);
	//      }
	//    } else {
	//      colorCalcARGB(c, colorModeA);
	//    }
		colorCalc(c);
		return calcColor;
	  }


	  public int color(float gray) // ignore
	  {
		colorCalc(gray);
		return calcColor;
	  }


	  /// <param name="c"> can be packed ARGB or a gray in this case </param>
	  public int color(int c, int alpha) // ignore
	  {
	//    if (colorModeDefault) {
	//      // bounds checking to make sure the numbers aren't to high or low
	//      if (c > 255) c = 255; else if (c < 0) c = 0;
	//      if (alpha > 255) alpha = 255; else if (alpha < 0) alpha = 0;
	//
	//      return ((alpha & 0xff) << 24) | (c << 16) | (c << 8) | c;
	//    }
		colorCalc(c, alpha);
		return calcColor;
	  }


	  /// <param name="c"> can be packed ARGB or a gray in this case </param>
	  public int color(int c, float alpha) // ignore
	  {
	//    if (((c & 0xff000000) == 0) && (c <= colorModeX)) {
		colorCalc(c, alpha);
	//  } else {
	//    colorCalcARGB(c, alpha);
	//  }
		return calcColor;
	  }


	  public int color(float gray, float alpha) // ignore
	  {
		colorCalc(gray, alpha);
		return calcColor;
	  }


	  public int color(int v1, int v2, int v3) // ignore
	  {
		colorCalc(v1, v2, v3);
		return calcColor;
	  }


	  public int color(float v1, float v2, float v3) // ignore
	  {
		colorCalc(v1, v2, v3);
		return calcColor;
	  }


	  public int color(int v1, int v2, int v3, int a) // ignore
	  {
		colorCalc(v1, v2, v3, a);
		return calcColor;
	  }


	  public int color(float v1, float v2, float v3, float a) // ignore
	  {
		colorCalc(v1, v2, v3, a);
		return calcColor;
	  }



	  //////////////////////////////////////////////////////////////

	  // COLOR DATATYPE EXTRACTION

	  // Vee have veys of making the colors talk.

	  /// <summary>
	  /// ( begin auto-generated from alpha.xml )
	  /// 
	  /// Extracts the alpha value from a color.
	  /// 
	  /// ( end auto-generated )
	  /// @webref color:creating_reading
	  /// @usage web_application </summary>
	  /// <param name="rgb"> any value of the color datatype </param>
	  /// <seealso cref= PGraphics#red(int) </seealso>
	  /// <seealso cref= PGraphics#green(int) </seealso>
	  /// <seealso cref= PGraphics#blue(int) </seealso>
	  /// <seealso cref= PGraphics#hue(int) </seealso>
	  /// <seealso cref= PGraphics#saturation(int) </seealso>
	  /// <seealso cref= PGraphics#brightness(int) </seealso>
	  public float alpha(int rgb)
	  {
		float outgoing = (rgb >> 24) & 0xff;
		if (colorModeA == 255)
		{
			return outgoing;
		}
		return (outgoing / 255.0f) * colorModeA;
	  }


	  /// <summary>
	  /// ( begin auto-generated from red.xml )
	  /// 
	  /// Extracts the red value from a color, scaled to match current
	  /// <b>colorMode()</b>. This value is always returned as a  float so be
	  /// careful not to assign it to an int value.<br /><br />The red() function
	  /// is easy to use and undestand, but is slower than another technique. To
	  /// achieve the same results when working in <b>colorMode(RGB, 255)</b>, but
	  /// with greater speed, use the &gt;&gt; (right shift) operator with a bit
	  /// mask. For example, the following two lines of code are equivalent:<br
	  /// /><pre>float r1 = red(myColor);<br />float r2 = myColor &gt;&gt; 16
	  /// &amp; 0xFF;</pre>
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref color:creating_reading
	  /// @usage web_application </summary>
	  /// <param name="rgb"> any value of the color datatype </param>
	  /// <seealso cref= PGraphics#green(int) </seealso>
	  /// <seealso cref= PGraphics#blue(int) </seealso>
	  /// <seealso cref= PGraphics#alpha(int) </seealso>
	  /// <seealso cref= PGraphics#hue(int) </seealso>
	  /// <seealso cref= PGraphics#saturation(int) </seealso>
	  /// <seealso cref= PGraphics#brightness(int)
	  /// @see_external rightshift </seealso>
	  public float red(int rgb)
	  {
		float c = (rgb >> 16) & 0xff;
		if (colorModeDefault)
		{
			return c;
		}
		return (c / 255.0f) * colorModeX;
	  }


	  /// <summary>
	  /// ( begin auto-generated from green.xml )
	  /// 
	  /// Extracts the green value from a color, scaled to match current
	  /// <b>colorMode()</b>. This value is always returned as a  float so be
	  /// careful not to assign it to an int value.<br /><br />The <b>green()</b>
	  /// function is easy to use and undestand, but is slower than another
	  /// technique. To achieve the same results when working in <b>colorMode(RGB,
	  /// 255)</b>, but with greater speed, use the &gt;&gt; (right shift)
	  /// operator with a bit mask. For example, the following two lines of code
	  /// are equivalent:<br /><pre>float r1 = green(myColor);<br />float r2 =
	  /// myColor &gt;&gt; 8 &amp; 0xFF;</pre>
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref color:creating_reading
	  /// @usage web_application </summary>
	  /// <param name="rgb"> any value of the color datatype </param>
	  /// <seealso cref= PGraphics#red(int) </seealso>
	  /// <seealso cref= PGraphics#blue(int) </seealso>
	  /// <seealso cref= PGraphics#alpha(int) </seealso>
	  /// <seealso cref= PGraphics#hue(int) </seealso>
	  /// <seealso cref= PGraphics#saturation(int) </seealso>
	  /// <seealso cref= PGraphics#brightness(int)
	  /// @see_external rightshift </seealso>
	  public float green(int rgb)
	  {
		float c = (rgb >> 8) & 0xff;
		if (colorModeDefault)
		{
			return c;
		}
		return (c / 255.0f) * colorModeY;
	  }


	  /// <summary>
	  /// ( begin auto-generated from blue.xml )
	  /// 
	  /// Extracts the blue value from a color, scaled to match current
	  /// <b>colorMode()</b>. This value is always returned as a  float so be
	  /// careful not to assign it to an int value.<br /><br />The <b>blue()</b>
	  /// function is easy to use and undestand, but is slower than another
	  /// technique. To achieve the same results when working in <b>colorMode(RGB,
	  /// 255)</b>, but with greater speed, use a bit mask to remove the other
	  /// color components. For example, the following two lines of code are
	  /// equivalent:<br /><pre>float r1 = blue(myColor);<br />float r2 = myColor
	  /// &amp; 0xFF;</pre>
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref color:creating_reading
	  /// @usage web_application </summary>
	  /// <param name="rgb"> any value of the color datatype </param>
	  /// <seealso cref= PGraphics#red(int) </seealso>
	  /// <seealso cref= PGraphics#green(int) </seealso>
	  /// <seealso cref= PGraphics#alpha(int) </seealso>
	  /// <seealso cref= PGraphics#hue(int) </seealso>
	  /// <seealso cref= PGraphics#saturation(int) </seealso>
	  /// <seealso cref= PGraphics#brightness(int)
	  /// @see_external rightshift </seealso>
	  public float blue(int rgb)
	  {
		float c = (rgb) & 0xff;
		if (colorModeDefault)
		{
			return c;
		}
		return (c / 255.0f) * colorModeZ;
	  }


	  /// <summary>
	  /// ( begin auto-generated from hue.xml )
	  /// 
	  /// Extracts the hue value from a color.
	  /// 
	  /// ( end auto-generated )
	  /// @webref color:creating_reading
	  /// @usage web_application </summary>
	  /// <param name="rgb"> any value of the color datatype </param>
	  /// <seealso cref= PGraphics#red(int) </seealso>
	  /// <seealso cref= PGraphics#green(int) </seealso>
	  /// <seealso cref= PGraphics#blue(int) </seealso>
	  /// <seealso cref= PGraphics#alpha(int) </seealso>
	  /// <seealso cref= PGraphics#saturation(int) </seealso>
	  /// <seealso cref= PGraphics#brightness(int) </seealso>
	  public float hue(int rgb)
	  {
		if (rgb != cacheHsbKey)
		{
				UnityEngine.ColorExtension.RGBtoHSB((rgb >> 16) & 0xff, (rgb >> 8) & 0xff, rgb & 0xff, ref cacheHsbValue);
		  cacheHsbKey = rgb;
		}
		return cacheHsbValue[0] * colorModeX;
	  }


	  /// <summary>
	  /// ( begin auto-generated from saturation.xml )
	  /// 
	  /// Extracts the saturation value from a color.
	  /// 
	  /// ( end auto-generated )
	  /// @webref color:creating_reading
	  /// @usage web_application </summary>
	  /// <param name="rgb"> any value of the color datatype </param>
	  /// <seealso cref= PGraphics#red(int) </seealso>
	  /// <seealso cref= PGraphics#green(int) </seealso>
	  /// <seealso cref= PGraphics#blue(int) </seealso>
	  /// <seealso cref= PGraphics#alpha(int) </seealso>
	  /// <seealso cref= PGraphics#hue(int) </seealso>
	  /// <seealso cref= PGraphics#brightness(int) </seealso>
	  public float saturation(int rgb)
	  {
		if (rgb != cacheHsbKey)
		{
				UnityEngine.ColorExtension.RGBtoHSB((rgb >> 16) & 0xff, (rgb >> 8) & 0xff, rgb & 0xff, ref cacheHsbValue);
		  cacheHsbKey = rgb; 
		}
		return cacheHsbValue[1] * colorModeY;
	  }


	  /// <summary>
	  /// ( begin auto-generated from brightness.xml )
	  /// 
	  /// Extracts the brightness value from a color.
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref color:creating_reading
	  /// @usage web_application </summary>
	  /// <param name="rgb"> any value of the color datatype </param>
	  /// <seealso cref= PGraphics#red(int) </seealso>
	  /// <seealso cref= PGraphics#green(int) </seealso>
	  /// <seealso cref= PGraphics#blue(int) </seealso>
	  /// <seealso cref= PGraphics#alpha(int) </seealso>
	  /// <seealso cref= PGraphics#hue(int) </seealso>
	  /// <seealso cref= PGraphics#saturation(int) </seealso>
	  public float brightness(int rgb)
	  {
		if (rgb != cacheHsbKey)
		{
				UnityEngine.ColorExtension.RGBtoHSB((rgb >> 16) & 0xff, (rgb >> 8) & 0xff, rgb & 0xff, ref cacheHsbValue);
		  cacheHsbKey = rgb;
		}
		return cacheHsbValue[2] * colorModeZ;
	  }



	  //////////////////////////////////////////////////////////////

	  // COLOR DATATYPE INTERPOLATION

	  // Against our better judgement.


	  /// <summary>
	  /// ( begin auto-generated from lerpColor.xml )
	  /// 
	  /// Calculates a color or colors between two color at a specific increment.
	  /// The <b>amt</b> parameter is the amount to interpolate between the two
	  /// values where 0.0 equal to the first point, 0.1 is very near the first
	  /// point, 0.5 is half-way in between, etc.
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref color:creating_reading
	  /// @usage web_application </summary>
	  /// <param name="c1"> interpolate from this color </param>
	  /// <param name="c2"> interpolate to this color </param>
	  /// <param name="amt"> between 0.0 and 1.0 </param>
	  /// <seealso cref= PImage#blendColor(int, int, int) </seealso>
	  /// <seealso cref= PGraphics#color(float, float, float, float) </seealso>
	  public virtual int lerpColor(int c1, int c2, float amt)
	  {
		return lerpColor(c1, c2, amt, colorMode_Renamed);
	  }

	  internal static float[] lerpColorHSB1;
	  internal static float[] lerpColorHSB2;

	  /// <summary>
	  /// @nowebref
	  /// Interpolate between two colors. Like lerp(), but for the
	  /// individual color components of a color supplied as an int value.
	  /// </summary>
	  public static int lerpColor(int c1, int c2, float amt, int mode)
	  {
		if (amt < 0)
		{
			amt = 0;
		}
		if (amt > 1)
		{
			amt = 1;
		}

		if (mode == PConstants_Fields.RGB)
		{
		  float a1 = ((c1 >> 24) & 0xff);
		  float r1 = (c1 >> 16) & 0xff;
		  float g1 = (c1 >> 8) & 0xff;
		  float b1 = c1 & 0xff;
		  float a2 = (c2 >> 24) & 0xff;
		  float r2 = (c2 >> 16) & 0xff;
		  float g2 = (c2 >> 8) & 0xff;
		  float b2 = c2 & 0xff;

		  return (((int)(a1 + (a2 - a1) * amt) << 24) | ((int)(r1 + (r2 - r1) * amt) << 16) | ((int)(g1 + (g2 - g1) * amt) << 8) | ((int)(b1 + (b2 - b1) * amt)));

		}
		else if (mode == PConstants_Fields.HSB)
		{
		  if (lerpColorHSB1 == null)
		  {
			lerpColorHSB1 = new float[3];
			lerpColorHSB2 = new float[3];
		  }

		  float a1 = (c1 >> 24) & 0xff;
		  float a2 = (c2 >> 24) & 0xff;
		  int alfa = ((int)(a1 + (a2 - a1) * amt)) << 24;

				UnityEngine.ColorExtension.RGBtoHSB((c1 >> 16) & 0xff, (c1 >> 8) & 0xff, c1 & 0xff, ref lerpColorHSB1);
				UnityEngine.ColorExtension.RGBtoHSB((c2 >> 16) & 0xff, (c2 >> 8) & 0xff, c2 & 0xff, ref lerpColorHSB2);

		  /* If mode is HSB, this will take the shortest path around the
		   * color wheel to find the new color. For instance, red to blue
		   * will go red violet blue (backwards in hue space) rather than
		   * cycling through ROYGBIV.
		   */
		  // Disabling rollover (wasn't working anyway) for 0126.
		  // Otherwise it makes full spectrum scale impossible for
		  // those who might want it...in spite of how despicable
		  // a full spectrum scale might be.
		  // roll around when 0.9 to 0.1
		  // more than 0.5 away means that it should roll in the other direction
		  /*
		  float h1 = lerpColorHSB1[0];
		  float h2 = lerpColorHSB2[0];
		  if (Math.abs(h1 - h2) > 0.5f) {
		    if (h1 > h2) {
		      // i.e. h1 is 0.7, h2 is 0.1
		      h2 += 1;
		    } else {
		      // i.e. h1 is 0.1, h2 is 0.7
		      h1 += 1;
		    }
		  }
		  float ho = (PApplet.lerp(lerpColorHSB1[0], lerpColorHSB2[0], amt)) % 1.0f;
		  */
				// TODO: after PApplet
//		  float ho = PApplet.lerp(lerpColorHSB1[0], lerpColorHSB2[0], amt);
//		  float so = PApplet.lerp(lerpColorHSB1[1], lerpColorHSB2[1], amt);
//		  float bo = PApplet.lerp(lerpColorHSB1[2], lerpColorHSB2[2], amt);
//
//		  return alfa | (Color.HSBtoRGB(ho, so, bo) & 0xFFFFFF);
		}
		return 0;
	  }


	  //////////////////////////////////////////////////////////////

	  // BEGINRAW/ENDRAW


	  /// <summary>
	  /// Record individual lines and triangles by echoing them to another renderer.
	  /// </summary>
	  public virtual void beginRaw(PGraphics rawGraphics) // ignore
	  {
		this.raw = rawGraphics;
		rawGraphics.beginDraw();
	  }


	  public virtual void endRaw() // ignore
	  {
		if (raw != null)
		{
		  // for 3D, need to flush any geometry that's been stored for sorting
		  // (particularly if the ENABLE_DEPTH_SORT hint is set)
		  flush();

		  // just like beginDraw, this will have to be called because
		  // endDraw() will be happening outside of draw()
		  raw.endDraw();
		  raw.dispose();
		  raw = null;
		}
	  }


	  public virtual bool haveRaw() // ignore
	  {
		return raw != null;
	  }


	  public virtual PGraphics Raw
	  {
		  get
		  {
			return raw;
		  }
	  }


	  //////////////////////////////////////////////////////////////

	  // WARNINGS and EXCEPTIONS


	  protected internal static Dictionary<string, object> warnings;


	  /// <summary>
	  /// Show a renderer error, and keep track of it so that it's only shown once. </summary>
	  /// <param name="msg"> the error message (which will be stored for later comparison) </param>
	  public static void showWarning(string msg) // ignore
	  {
		if (warnings == null)
		{
		  warnings = new Dictionary<string, object>();
		}
		if (!warnings.ContainsKey(msg))
		{
		  Console.Error.WriteLine(msg);
		  warnings[msg] = new object();
		}
	  }


	  /// <summary>
	  /// Version of showWarning() that takes a parsed String.
	  /// </summary>
	  public static void showWarning(string msg, params object[] args) // ignore
	  {
		showWarning(string.Format(msg, args));
	  }


	  /// <summary>
	  /// Display a warning that the specified method is only available with 3D. </summary>
	  /// <param name="method"> The method name (no parentheses) </param>
	  public static void showDepthWarning(string method)
	  {
		showWarning(method + "() can only be used with a renderer that " + "supports 3D, such as P3D or OPENGL.");
	  }


	  /// <summary>
	  /// Display a warning that the specified method that takes x, y, z parameters
	  /// can only be used with x and y parameters in this renderer. </summary>
	  /// <param name="method"> The method name (no parentheses) </param>
	  public static void showDepthWarningXYZ(string method)
	  {
		showWarning(method + "() with x, y, and z coordinates " + "can only be used with a renderer that " + "supports 3D, such as P3D or OPENGL. " + "Use a version without a z-coordinate instead.");
	  }


	  /// <summary>
	  /// Display a warning that the specified method is simply unavailable.
	  /// </summary>
	  public static void showMethodWarning(string method)
	  {
		showWarning(method + "() is not available with this renderer.");
	  }


	  /// <summary>
	  /// Error that a particular variation of a method is unavailable (even though
	  /// other variations are). For instance, if vertex(x, y, u, v) is not
	  /// available, but vertex(x, y) is just fine.
	  /// </summary>
	  public static void showVariationWarning(string str)
	  {
		showWarning(str + " is not available with this renderer.");
	  }


	  /// <summary>
	  /// Display a warning that the specified method is not implemented, meaning
	  /// that it could be either a completely missing function, although other
	  /// variations of it may still work properly.
	  /// </summary>
	  public static void showMissingWarning(string method)
	  {
		showWarning(method + "(), or this particular variation of it, " + "is not available with this renderer.");
	  }


	  /// <summary>
	  /// Show an renderer-related exception that halts the program. Currently just
	  /// wraps the message as a RuntimeException and throws it, but might do
	  /// something more specific might be used in the future.
	  /// </summary>
	  public static void showException(string msg) // ignore
	  {
		throw new Exception(msg);
	  }


	  /// <summary>
	  /// Same as below, but defaults to a 12 point font, just as MacWrite intended.
	  /// </summary>
	  protected internal virtual void defaultFontOrDeath(string method)
	  {
		defaultFontOrDeath(method, 12);
	  }


	  /// <summary>
	  /// First try to create a default font, but if that's not possible, throw
	  /// an exception that halts the program because textFont() has not been used
	  /// prior to the specified method.
	  /// </summary>
	  protected internal virtual void defaultFontOrDeath(string method, float size)
	  {
			// TODO: after PFont
//		if (parent != null)
//		{
//		  textFont_Renamed = parent.createDefaultFont(size);
//		}
//		else
//		{
//		  throw new Exception("Use textFont() before " + method + "()");
//		}
	  }



	  //////////////////////////////////////////////////////////////

	  // RENDERER SUPPORT QUERIES


	  /// <summary>
	  /// Return true if this renderer should be drawn to the screen. Defaults to
	  /// returning true, since nearly all renderers are on-screen beasts. But can
	  /// be overridden for subclasses like PDF so that a window doesn't open up.
	  /// <br/> <br/>
	  /// A better name? showFrame, displayable, isVisible, visible, shouldDisplay,
	  /// what to call this?
	  /// </summary>
	  public virtual bool displayable()
	  {
		return true;
	  }


	  /// <summary>
	  /// Return true if this renderer supports 2D drawing. Defaults to true.
	  /// </summary>
	  public virtual bool is2D()
	  {
		return true;
	  }


	  /// <summary>
	  /// Return true if this renderer supports 3D drawing. Defaults to false.
	  /// </summary>
	  public virtual bool is3D()
	  {
		return false;
	  }


	  /// <summary>
	  /// Return true if this renderer does rendering through OpenGL. Defaults to false.
	  /// </summary>
	  public virtual bool GL
	  {
		  get
		  {
			return false;
		  }
	  }
	}

}