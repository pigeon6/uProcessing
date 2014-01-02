using System;
using System.Collections.Generic;

/* -*- mode: java; c-basic-offset: 2; indent-tabs-mode: nil -*- */

/*
  Part of the Processing project - http://processing.org

  Copyright (c) 2006-10 Ben Fry and Casey Reas

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
	/// ( begin auto-generated from PShape.xml )
	///   
	/// Datatype for storing shapes. Processing can currently load and display
	/// SVG (Scalable Vector Graphics) shapes. Before a shape is used, it must
	/// be loaded with the <b>loadShape()</b> function. The <b>shape()</b>
	/// function is used to draw the shape to the display window. The
	/// <b>PShape</b> object contain a group of methods, linked below, that can
	/// operate on the shape data.
	/// <br /><br />
	/// The <b>loadShape()</b> function supports SVG files created with Inkscape
	/// and Adobe Illustrator. It is not a full SVG implementation, but offers
	/// some straightforward support for handling vector data.
	///   
	/// ( end auto-generated )
	/// <h3>Advanced</h3>
	/// 
	/// In-progress class to handle shape data, currently to be considered of
	/// alpha or beta quality. Major structural work may be performed on this class
	/// after the release of Processing 1.0. Such changes may include:
	/// 
	/// <ul>
	/// <li> addition of proper accessors to read shape vertex and coloring data
	/// (this is the second most important part of having a PShape class after all).
	/// <li> a means of creating PShape objects ala beginShape() and endShape().
	/// <li> load(), update(), and cache methods ala PImage, so that shapes can
	/// have renderer-specific optimizations, such as vertex arrays in OpenGL.
	/// <li> splitting this class into multiple classes to handle different
	/// varieties of shape data (primitives vs collections of vertices vs paths)
	/// <li> change of package declaration, for instance moving the code into
	/// package processing.shape (if the code grows too much).
	/// </ul>
	/// 
	/// <para>For the time being, this class and its shape() and loadShape() friends in
	/// PApplet exist as placeholders for more exciting things to come. If you'd
	/// like to work with this class, make a subclass (see how PShapeSVG works)
	/// and you can play with its internal methods all you like.</para>
	/// 
	/// <para>Library developers are encouraged to create PShape objects when loading
	/// shape data, so that they can eventually hook into the bounty that will be
	/// the PShape interface, and the ease of loadShape() and shape().</para>
	/// 
	/// @webref shape
	/// @usage Web &amp; Application </summary>
	/// <seealso cref= PApplet#loadShape(String) </seealso>
	/// <seealso cref= PApplet#createShape() </seealso>
	/// <seealso cref= PApplet#shapeMode(int)
	/// @instanceName sh any variable of type PShape </seealso>
	public class PShape : PConstants
	{
	  protected internal string name;
	  protected internal Dictionary<string, PShape> nameTable;

	//  /** Generic, only draws its child objects. */
	//  static public final int GROUP = 0;
	  // GROUP now inherited from PConstants
	  /// <summary>
	  /// A line, ellipse, arc, image, etc. </summary>
	  public const int PRIMITIVE = 1;
	  /// <summary>
	  /// A series of vertex, curveVertex, and bezierVertex calls. </summary>
	  //public const int PConstants_Fields = 0;
	  /// <summary>
	  /// Collections of vertices created with beginShape(). </summary>
	  public const int GEOMETRY = 3;
	  /// <summary>
	  /// The shape type, one of GROUP, PRIMITIVE, PATH, or GEOMETRY. </summary>
	  protected internal int family;

	  /// <summary>
	  /// ELLIPSE, LINE, QUAD; TRIANGLE_FAN, QUAD_STRIP; etc. </summary>
	  protected internal int kind;

	  protected internal PMatrix matrix;

	  protected internal int textureMode_Renamed;

	  /// <summary>
	  /// Texture or image data associated with this shape. </summary>
	  protected internal PImage image;

	  public const string OUTSIDE_BEGIN_END_ERROR = "%1$s can only be called between beginShape() and endShape()";

	  public const string INSIDE_BEGIN_END_ERROR = "%1$s can only be called outside beginShape() and endShape()";

	  // boundary box of this shape
	  //protected float x;
	  //protected float y;
	  //protected float width;
	  //protected float height;
	  /// <summary>
	  /// ( begin auto-generated from PShape_width.xml )
	  /// 
	  /// The width of the PShape document.
	  /// 
	  /// ( end auto-generated )
	  /// @webref pshape:field
	  /// @usage web_application
	  /// @brief     Shape document width </summary>
	  /// <seealso cref= PShape#height </seealso>
	  public float width;
	  /// <summary>
	  /// ( begin auto-generated from PShape_height.xml )
	  /// 
	  /// The height of the PShape document.
	  /// 
	  /// ( end auto-generated )
	  /// @webref pshape:field
	  /// @usage web_application
	  /// @brief     Shape document height </summary>
	  /// <seealso cref= PShape#width </seealso>
	  public float height;

	  public float depth;

	  // set to false if the object is hidden in the layers palette
	  protected internal bool visible = true;

		/// <summary>
		/// Retained shape being created with beginShape/endShape </summary>
	  protected internal bool openShape = false;

	  protected internal bool openContour = false;

	  protected internal bool stroke_Renamed;
	  protected internal int strokeColor;
	  protected internal float strokeWeight_Renamed; // default is 1
	  protected internal int strokeCap_Renamed;
	  protected internal int strokeJoin_Renamed;

	  protected internal bool fill_Renamed;
	  protected internal int fillColor;

	  protected internal bool tint_Renamed;
	  protected internal int tintColor;

	  protected internal int ambientColor;
	  protected internal bool setAmbient_Renamed;
	  protected internal int specularColor;
	  protected internal int emissiveColor;
	  protected internal float shininess_Renamed;

	  protected internal int sphereDetailU, sphereDetailV;
	  protected internal int rectMode;
	  protected internal int ellipseMode;

	  /// <summary>
	  /// Temporary toggle for whether styles should be honored. </summary>
	  protected internal bool style = true;

	  /// <summary>
	  /// For primitive shapes in particular, params like x/y/w/h or x1/y1/x2/y2. </summary>
	  protected internal float[] @params;

	  protected internal int vertexCount;
	  /// <summary>
	  /// When drawing POLYGON shapes, the second param is an array of length
	  /// VERTEX_FIELD_COUNT. When drawing PATH shapes, the second param has only
	  /// two variables.
	  /// </summary>
	  protected internal float[][] vertices;

	  protected internal PShape parent;
	  protected internal int childCount;
	  protected internal PShape[] children;


	  /// <summary>
	  /// Array of VERTEX, BEZIER_VERTEX, and CURVE_VERTEX calls. </summary>
	  protected internal int vertexCodeCount;
	  protected internal int[] vertexCodes;
	  /// <summary>
	  /// True if this is a closed path. </summary>
	  protected internal bool close;

	  // ........................................................

	  // internal color for setting/calculating
	  protected internal float calcR, calcG, calcB, calcA;
	  protected internal int calcRi, calcGi, calcBi, calcAi;
	  protected internal int calcColor;
	  protected internal bool calcAlpha;

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

	  /// <summary>
	  /// True if contains 3D data </summary>
	  protected internal bool is3D_Renamed = false;

	  // should this be called vertices (consistent with PGraphics internals)
	  // or does that hurt flexibility?


	  // POINTS, LINES, xLINE_STRIP, xLINE_LOOP
	  // TRIANGLES, TRIANGLE_STRIP, TRIANGLE_FAN
	  // QUADS, QUAD_STRIP
	  // xPOLYGON
	//  static final int PATH = 1;  // POLYGON, LINE_LOOP, LINE_STRIP
	//  static final int GROUP = 2;

	  // how to handle rectmode/ellipsemode?
	  // are they bitshifted into the constant?
	  // CORNER, CORNERS, CENTER, (CENTER_RADIUS?)
	//  static final int RECT = 3; // could just be QUAD, but would be x1/y1/x2/y2
	//  static final int ELLIPSE = 4;
	//
	//  static final int VERTEX = 7;
	//  static final int CURVE = 5;
	//  static final int BEZIER = 6;


	  // fill and stroke functions will need a pointer to the parent
	  // PGraphics object.. may need some kind of createShape() fxn
	  // or maybe the values are stored until draw() is called?

	  // attaching images is very tricky.. it's a different type of data

	  // material parameters will be thrown out,
	  // except those currently supported (kinds of lights)

	  // pivot point for transformations
	//  public float px;
	//  public float py;

	  public PShape()
	  {
		this.family = PConstants_Fields.GROUP;
	  }


	/// <summary>
	/// @nowebref
	/// </summary>
	  public PShape(int family)
	  {
		this.family = family;
	  }


	  public virtual int Kind
	  {
		  set
		  {
			this.kind = value;
		  }
		  get
		  {
			return kind;
		  }
	  }


	  public virtual string Name
	  {
		  set
		  {
			this.name = value;
		  }
		  get
		  {
			return name;
		  }
	  }



	  /// <summary>
	  /// ( begin auto-generated from PShape_isVisible.xml )
	  /// 
	  /// Returns a boolean value "true" if the image is set to be visible,
	  /// "false" if not. This is modified with the <b>setVisible()</b> parameter.
	  /// <br/> <br/>
	  /// The visibility of a shape is usually controlled by whatever program
	  /// created the SVG file. For instance, this parameter is controlled by
	  /// showing or hiding the shape in the layers palette in Adobe Illustrator.
	  /// 
	  /// ( end auto-generated )
	  /// @webref pshape:method
	  /// @usage web_application
	  /// @brief Returns a boolean value "true" if the image is set to be visible, "false" if not </summary>
	  /// <seealso cref= PShape#setVisible(boolean) </seealso>
	  public virtual bool Visible
	  {
		  get
		  {
			return visible;
		  }
		  set
		  {
			this.visible = value;
		  }
	  }




	  /// <summary>
	  /// ( begin auto-generated from PShape_disableStyle.xml )
	  /// 
	  /// Disables the shape's style data and uses Processing's current styles.
	  /// Styles include attributes such as colors, stroke weight, and stroke
	  /// joints.
	  /// 
	  /// ( end auto-generated )
	  ///  <h3>Advanced</h3>
	  /// Overrides this shape's style information and uses PGraphics styles and
	  /// colors. Identical to ignoreStyles(true). Also disables styles for all
	  /// child shapes.
	  /// @webref pshape:method
	  /// @usage web_application
	  /// @brief     Disables the shape's style data and uses Processing styles </summary>
	  /// <seealso cref= PShape#enableStyle() </seealso>
	  public virtual void disableStyle()
	  {
		style = false;

		for (int i = 0; i < childCount; i++)
		{
		  children[i].disableStyle();
		}
	  }


	  /// <summary>
	  /// ( begin auto-generated from PShape_enableStyle.xml )
	  /// 
	  /// Enables the shape's style data and ignores Processing's current styles.
	  /// Styles include attributes such as colors, stroke weight, and stroke
	  /// joints.
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref pshape:method
	  /// @usage web_application
	  /// @brief Enables the shape's style data and ignores the Processing styles </summary>
	  /// <seealso cref= PShape#disableStyle() </seealso>
	  public virtual void enableStyle()
	  {
		style = true;

		for (int i = 0; i < childCount; i++)
		{
		  children[i].enableStyle();
		}
	  }


	  // . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . .


	//  protected void checkBounds() {
	//    if (width == 0 || height == 0) {
	//      // calculate bounds here (also take kids into account)
	//      width = 1;
	//      height = 1;
	//    }
	//  }


	  /// <summary>
	  /// Get the width of the drawing area (not necessarily the shape boundary).
	  /// </summary>
	  public virtual float Width
	  {
		  get
		  {
			//checkBounds();
			return width;
		  }
	  }


	  /// <summary>
	  /// Get the height of the drawing area (not necessarily the shape boundary).
	  /// </summary>
	  public virtual float Height
	  {
		  get
		  {
			//checkBounds();
			return height;
		  }
	  }


	  /// <summary>
	  /// Get the depth of the shape area (not necessarily the shape boundary). Only makes sense for 3D PShape subclasses,
	  /// such as PShape3D.
	  /// </summary>
	  public virtual float Depth
	  {
		  get
		  {
			//checkBounds();
			return depth;
		  }
	  }



	  /*
	  // TODO unapproved
	  protected PVector getTop() {
	    return getTop(null);
	  }
	
	
	  protected PVector getTop(PVector top) {
	    if (top == null) {
	      top = new PVector();
	    }
	    return top;
	  }
	
	
	  protected PVector getBottom() {
	    return getBottom(null);
	  }
	
	
	  protected PVector getBottom(PVector bottom) {
	    if (bottom == null) {
	      bottom = new PVector();
	    }
	    return bottom;
	  }
	  */


	  /// <summary>
	  /// Return true if this shape is 2D. Defaults to true.
	  /// </summary>
	  public virtual bool is2D()
	  {
		return !is3D_Renamed;
	  }


	  /// <summary>
	  /// Return true if this shape is 3D. Defaults to false.
	  /// </summary>
	  public virtual bool is3D()
	  {
		return is3D_Renamed;
	  }


	  public virtual void is3D(bool val)
	  {
		is3D_Renamed = val;
	  }


	//  /**
	//   * Return true if this shape requires rendering through OpenGL. Defaults to false.
	//   */
	//  // TODO unapproved
	//  public boolean isGL() {
	//    return false;
	//  }


	  ///////////////////////////////////////////////////////////

	  //

	  // Drawing methods

	  public virtual void textureMode(int mode)
	  {
		if (!openShape)
		{
		  PGraphics.showWarning(OUTSIDE_BEGIN_END_ERROR, "textureMode()");
		  return;
		}

		textureMode_Renamed = mode;
	  }

	  public virtual void texture(PImage tex)
	  {
		if (!openShape)
		{
		  PGraphics.showWarning(OUTSIDE_BEGIN_END_ERROR, "texture()");
		  return;
		}

		image = tex;
	  }

	  public virtual void noTexture()
	  {
		if (!openShape)
		{
		  PGraphics.showWarning(OUTSIDE_BEGIN_END_ERROR, "noTexture()");
		  return;
		}

		image = null;
	  }


	  // TODO unapproved
	  protected internal virtual void solid(bool solid)
	  {
	  }


	  /// <summary>
	  /// @webref shape:vertex
	  /// @brief Starts a new contour </summary>
	  /// <seealso cref= PShape#endContour() </seealso>
	  public virtual void beginContour()
	  {
		if (!openShape)
		{
		  PGraphics.showWarning(OUTSIDE_BEGIN_END_ERROR, "beginContour()");
		  return;
		}

		if (family == PConstants_Fields.GROUP)
		{
		  PGraphics.showWarning("Cannot begin contour in GROUP shapes");
		  return;
		}

		if (openContour)
		{
		  PGraphics.showWarning("Already called beginContour().");
		  return;
		}
		openContour = true;
		beginContourImpl();
	  }


	  protected internal virtual void beginContourImpl()
	  {
		if (vertexCodes.Length == vertexCodeCount)
		{
				//TODO:PApplet
		  //vertexCodes = PApplet.expand(vertexCodes);
		}
		vertexCodes[vertexCodeCount++] = PConstants_Fields.BREAK;
	  }


	  /// <summary>
	  /// @webref shape:vertex
	  /// @brief Ends a contour </summary>
	  /// <seealso cref= PShape#beginContour() </seealso>
	  public virtual void endContour()
	  {
		if (!openShape)
		{
		  PGraphics.showWarning(OUTSIDE_BEGIN_END_ERROR, "endContour()");
		  return;
		}

		if (family == PConstants_Fields.GROUP)
		{
		  PGraphics.showWarning("Cannot end contour in GROUP shapes");
		  return;
		}

		if (!openContour)
		{
		  PGraphics.showWarning("Need to call beginContour() first.");
		  return;
		}
		endContourImpl();
		openContour = false;
	  }


	  protected internal virtual void endContourImpl()
	  {
	  }


	  public virtual void vertex(float x, float y)
	  {
		if (vertices == null)
		{
//JAVA TO C# CONVERTER NOTE: The following call to the 'RectangularArrays' helper class reproduces the rectangular array initialization that is automatic in Java:
//ORIGINAL LINE: vertices = new float[10][2];
		  vertices = RectangularArrays.ReturnRectangularFloatArray(10, 2);
		}
		else if (vertices.Length == vertexCount)
		{
				//TODO:PApplet
//				vertices = (float[][]) PApplet.expand(vertices);
		}
		vertices[vertexCount++] = new float[] {x, y};

		if (vertexCodes == null)
		{
		  vertexCodes = new int[10];
		}
		else if (vertexCodes.Length == vertexCodeCount)
		{
				//TODO:PApplet
//				vertexCodes = PApplet.expand(vertexCodes);
		}
		vertexCodes[vertexCodeCount++] = PConstants_Fields.VERTEX;

		if (x > width)
		{
		  width = x;
		}
		if (y > height)
		{
		  height = y;
		}
	  }


	  public virtual void vertex(float x, float y, float u, float v)
	  {
	  }


	  public virtual void vertex(float x, float y, float z)
	  {
	  }


	  public virtual void vertex(float x, float y, float z, float u, float v)
	  {
	  }


	  public virtual void normal(float nx, float ny, float nz)
	  {
	  }

	  /// <summary>
	  /// @webref pshape:method
	  /// @brief Starts the creation of a new PShape </summary>
	  /// <seealso cref= PApplet#endShape() </seealso>
	  public virtual void beginShape()
	  {
		beginShape(PConstants_Fields.POLYGON);
	  }


	  public virtual void beginShape(int kind)
	  {
		this.kind = kind;
		openShape = true;
	  }

	  /// <summary>
	  /// @webref pshape:method
	  /// @brief Finishes the creation of a new PShape </summary>
	  /// <seealso cref= PApplet#beginShape() </seealso>
	  public virtual void endShape()
	  {
		endShape(PConstants_Fields.OPEN);
	  }


	  public virtual void endShape(int mode)
	  {
		if (family == PConstants_Fields.GROUP)
		{
		  PGraphics.showWarning("Cannot end GROUP shape");
		  return;
		}

		if (!openShape)
		{
		  PGraphics.showWarning("Need to call beginShape() first");
		  return;
		}

		openShape = false;
	  }


	  //////////////////////////////////////////////////////////////

	  // STROKE CAP/JOIN/WEIGHT


	  public virtual void strokeWeight(float weight)
	  {
		if (!openShape)
		{
		  PGraphics.showWarning(OUTSIDE_BEGIN_END_ERROR, "strokeWeight()");
		  return;
		}

		strokeWeight_Renamed = weight;
	  }

	  public virtual void strokeJoin(int join)
	  {
		if (!openShape)
		{
		  PGraphics.showWarning(OUTSIDE_BEGIN_END_ERROR, "strokeJoin()");
		  return;
		}

		strokeJoin_Renamed = join;
	  }

	  public virtual void strokeCap(int cap)
	  {
		if (!openShape)
		{
		  PGraphics.showWarning(OUTSIDE_BEGIN_END_ERROR, "strokeCap()");
		  return;
		}

		strokeCap_Renamed = cap;
	  }


	  //////////////////////////////////////////////////////////////

	  // FILL COLOR


	  public virtual void noFill()
	  {
		if (!openShape)
		{
		  PGraphics.showWarning(OUTSIDE_BEGIN_END_ERROR, "noFill()");
		  return;
		}

		fill_Renamed = false;
		fillColor = 0x0;

		if (!setAmbient_Renamed)
		{
		  ambientColor = fillColor;
		}
	  }


	  public virtual void fill(int rgb)
	  {
		if (!openShape)
		{
		  PGraphics.showWarning(OUTSIDE_BEGIN_END_ERROR, "fill()");
		  return;
		}

		fill_Renamed = true;
		colorCalc(rgb);
		fillColor = calcColor;

		if (!setAmbient_Renamed)
		{
		  ambientColor = fillColor;
		}
	  }


	  public virtual void fill(int rgb, float alpha)
	  {
		if (!openShape)
		{
		  PGraphics.showWarning(OUTSIDE_BEGIN_END_ERROR, "fill()");
		  return;
		}

		fill_Renamed = true;
		colorCalc(rgb, alpha);
		fillColor = calcColor;

		if (!setAmbient_Renamed)
		{
		  ambientColor = fillColor;
		}
	  }


	  public virtual void fill(float gray)
	  {
		if (!openShape)
		{
		  PGraphics.showWarning(OUTSIDE_BEGIN_END_ERROR, "fill()");
		  return;
		}

		fill_Renamed = true;
		colorCalc(gray);
		fillColor = calcColor;

		if (!setAmbient_Renamed)
		{
		  ambientColor = fillColor;
		}
	  }


	  public virtual void fill(float gray, float alpha)
	  {
		if (!openShape)
		{
		  PGraphics.showWarning(OUTSIDE_BEGIN_END_ERROR, "fill()");
		  return;
		}

		fill_Renamed = true;
		colorCalc(gray, alpha);
		fillColor = calcColor;

		if (!setAmbient_Renamed)
		{
		  ambient(fillColor);
		  setAmbient_Renamed = false;
		}

		if (!setAmbient_Renamed)
		{
		  ambientColor = fillColor;
		}
	  }


	  public virtual void fill(float x, float y, float z)
	  {
		if (!openShape)
		{
		  PGraphics.showWarning(OUTSIDE_BEGIN_END_ERROR, "fill()");
		  return;
		}

		fill_Renamed = true;
		colorCalc(x, y, z);
		fillColor = calcColor;

		if (!setAmbient_Renamed)
		{
		  ambientColor = fillColor;
		}
	  }


	  public virtual void fill(float x, float y, float z, float a)
	  {
		if (!openShape)
		{
		  PGraphics.showWarning(OUTSIDE_BEGIN_END_ERROR, "fill()");
		  return;
		}

		fill_Renamed = true;
		colorCalc(x, y, z, a);
		fillColor = calcColor;

		if (!setAmbient_Renamed)
		{
		  ambientColor = fillColor;
		}
	  }


	  //////////////////////////////////////////////////////////////

	  // STROKE COLOR


	  public virtual void noStroke()
	  {
		if (!openShape)
		{
		  PGraphics.showWarning(OUTSIDE_BEGIN_END_ERROR, "noStroke()");
		  return;
		}

		stroke_Renamed = false;
	  }


	  public virtual void stroke(int rgb)
	  {
		if (!openShape)
		{
		  PGraphics.showWarning(OUTSIDE_BEGIN_END_ERROR, "stroke()");
		  return;
		}

		stroke_Renamed = true;
		colorCalc(rgb);
		strokeColor = calcColor;
	  }


	  public virtual void stroke(int rgb, float alpha)
	  {
		if (!openShape)
		{
		  PGraphics.showWarning(OUTSIDE_BEGIN_END_ERROR, "stroke()");
		  return;
		}

		stroke_Renamed = true;
		colorCalc(rgb, alpha);
		strokeColor = calcColor;
	  }


	  public virtual void stroke(float gray)
	  {
		if (!openShape)
		{
		  PGraphics.showWarning(OUTSIDE_BEGIN_END_ERROR, "stroke()");
		  return;
		}

		stroke_Renamed = true;
		colorCalc(gray);
		strokeColor = calcColor;
	  }


	  public virtual void stroke(float gray, float alpha)
	  {
		if (!openShape)
		{
		  PGraphics.showWarning(OUTSIDE_BEGIN_END_ERROR, "stroke()");
		  return;
		}

		stroke_Renamed = true;
		colorCalc(gray, alpha);
		strokeColor = calcColor;
	  }


	  public virtual void stroke(float x, float y, float z)
	  {
		if (!openShape)
		{
		  PGraphics.showWarning(OUTSIDE_BEGIN_END_ERROR, "stroke()");
		  return;
		}

		stroke_Renamed = true;
		colorCalc(x, y, z);
		strokeColor = calcColor;
	  }


	  public virtual void stroke(float x, float y, float z, float alpha)
	  {
		if (!openShape)
		{
		  PGraphics.showWarning(OUTSIDE_BEGIN_END_ERROR, "stroke()");
		  return;
		}

		stroke_Renamed = true;
		colorCalc(x, y, z, alpha);
		strokeColor = calcColor;
	  }


	  //////////////////////////////////////////////////////////////

	  // TINT COLOR


	  public virtual void noTint()
	  {
		if (!openShape)
		{
		  PGraphics.showWarning(OUTSIDE_BEGIN_END_ERROR, "noTint()");
		  return;
		}

		tint_Renamed = false;
	  }


	  public virtual void tint(int rgb)
	  {
		if (!openShape)
		{
		  PGraphics.showWarning(OUTSIDE_BEGIN_END_ERROR, "tint()");
		  return;
		}

		tint_Renamed = true;
		colorCalc(rgb);
		tintColor = calcColor;
	  }


	  public virtual void tint(int rgb, float alpha)
	  {
		if (!openShape)
		{
		  PGraphics.showWarning(OUTSIDE_BEGIN_END_ERROR, "tint()");
		  return;
		}

		tint_Renamed = true;
		colorCalc(rgb, alpha);
		tintColor = calcColor;
	  }


	  public virtual void tint(float gray)
	  {
		if (!openShape)
		{
		  PGraphics.showWarning(OUTSIDE_BEGIN_END_ERROR, "tint()");
		  return;
		}

		tint_Renamed = true;
		colorCalc(gray);
		tintColor = calcColor;
	  }


	  public virtual void tint(float gray, float alpha)
	  {
		if (!openShape)
		{
		  PGraphics.showWarning(OUTSIDE_BEGIN_END_ERROR, "tint()");
		  return;
		}

		tint_Renamed = true;
		colorCalc(gray, alpha);
		tintColor = calcColor;
	  }


	  public virtual void tint(float x, float y, float z)
	  {
		if (!openShape)
		{
		  PGraphics.showWarning(OUTSIDE_BEGIN_END_ERROR, "tint()");
		  return;
		}

		tint_Renamed = true;
		colorCalc(x, y, z);
		tintColor = calcColor;
	  }


	  public virtual void tint(float x, float y, float z, float alpha)
	  {
		if (!openShape)
		{
		  PGraphics.showWarning(OUTSIDE_BEGIN_END_ERROR, "tint()");
		  return;
		}

		tint_Renamed = true;
		colorCalc(x, y, z, alpha);
		tintColor = calcColor;
	  }


	  //////////////////////////////////////////////////////////////

	  // Ambient set/update

	  public virtual void ambient(int rgb)
	  {
		if (!openShape)
		{
		  PGraphics.showWarning(OUTSIDE_BEGIN_END_ERROR, "ambient()");
		  return;
		}

		setAmbient_Renamed = true;
		colorCalc(rgb);
		ambientColor = calcColor;
	  }


	  public virtual void ambient(float gray)
	  {
		if (!openShape)
		{
		  PGraphics.showWarning(OUTSIDE_BEGIN_END_ERROR, "ambient()");
		  return;
		}

		setAmbient_Renamed = true;
		colorCalc(gray);
		ambientColor = calcColor;
	  }


	  public virtual void ambient(float x, float y, float z)
	  {
		if (!openShape)
		{
		  PGraphics.showWarning(OUTSIDE_BEGIN_END_ERROR, "ambient()");
		  return;
		}

		setAmbient_Renamed = true;
		colorCalc(x, y, z);
		ambientColor = calcColor;
	  }


	  //////////////////////////////////////////////////////////////

	  // Specular set/update

	  public virtual void specular(int rgb)
	  {
		if (!openShape)
		{
		  PGraphics.showWarning(OUTSIDE_BEGIN_END_ERROR, "specular()");
		  return;
		}

		colorCalc(rgb);
		specularColor = calcColor;
	  }


	  public virtual void specular(float gray)
	  {
		if (!openShape)
		{
		  PGraphics.showWarning(OUTSIDE_BEGIN_END_ERROR, "specular()");
		  return;
		}

		colorCalc(gray);
		specularColor = calcColor;
	  }


	  public virtual void specular(float x, float y, float z)
	  {
		if (!openShape)
		{
		  PGraphics.showWarning(OUTSIDE_BEGIN_END_ERROR, "specular()");
		  return;
		}

		colorCalc(x, y, z);
		specularColor = calcColor;
	  }


	  //////////////////////////////////////////////////////////////

	  // Emissive set/update

	  public virtual void emissive(int rgb)
	  {
		if (!openShape)
		{
		  PGraphics.showWarning(OUTSIDE_BEGIN_END_ERROR, "emissive()");
		  return;
		}

		colorCalc(rgb);
		emissiveColor = calcColor;
	  }


	  public virtual void emissive(float gray)
	  {
		if (!openShape)
		{
		  PGraphics.showWarning(OUTSIDE_BEGIN_END_ERROR, "emissive()");
		  return;
		}

		colorCalc(gray);
		emissiveColor = calcColor;
	  }


	  public virtual void emissive(float x, float y, float z)
	  {
		if (!openShape)
		{
		  PGraphics.showWarning(OUTSIDE_BEGIN_END_ERROR, "emissive()");
		  return;
		}

		colorCalc(x, y, z);
		emissiveColor = calcColor;
	  }


	  //////////////////////////////////////////////////////////////

	  // Shininess set/update

	  public virtual void shininess(float shine)
	  {
		if (!openShape)
		{
		  PGraphics.showWarning(OUTSIDE_BEGIN_END_ERROR, "shininess()");
		  return;
		}

		shininess_Renamed = shine;
	  }

	  ///////////////////////////////////////////////////////////

	  //

	  // Bezier curves


	  public virtual void bezierDetail(int detail)
	  {
	  }


	  public virtual void bezierVertex(float x2, float y2, float x3, float y3, float x4, float y4)
	  {
		if (vertices == null)
		{
		  vertices = new float[10][];
		}
		else if (vertexCount + 2 >= vertices.Length)
		{
				//TODO:PApplet
				//vertices = (float[][]) PApplet.expand(vertices);
		}
		vertices[vertexCount++] = new float[] {x2, y2};
		vertices[vertexCount++] = new float[] {x3, y3};
		vertices[vertexCount++] = new float[] {x4, y4};

		// vertexCodes must be allocated because a vertex() call is required
		if (vertexCodes.Length == vertexCodeCount)
		{
				//TODO:PApplet
				//		  vertexCodes = PApplet.expand(vertexCodes);
		}
		vertexCodes[vertexCodeCount++] = PConstants_Fields.BEZIER_VERTEX;

		if (x4 > width)
		{
		  width = x4;
		}
		if (y4 > height)
		{
		  height = y4;
		}
	  }


	  public virtual void bezierVertex(float x2, float y2, float z2, float x3, float y3, float z3, float x4, float y4, float z4)
	  {
	  }


	  public virtual void quadraticVertex(float cx, float cy, float x3, float y3)
	  {
		if (vertices == null)
		{
		  vertices = new float[10][];
		}
		else if (vertexCount + 1 >= vertices.Length)
		{
										//TODO:PApplet
				//vertices = (float[][]) PApplet.expand(vertices);
		}
		vertices[vertexCount++] = new float[] {cx, cy};
		vertices[vertexCount++] = new float[] {x3, y3};

		// vertexCodes must be allocated because a vertex() call is required
		if (vertexCodes.Length == vertexCodeCount)
		{
				//TODO:PApplet
				//		  vertexCodes = PApplet.expand(vertexCodes);
		}
		vertexCodes[vertexCodeCount++] = PConstants_Fields.QUADRATIC_VERTEX;

		if (x3 > width)
		{
		  width = x3;
		}
		if (y3 > height)
		{
		  height = y3;
		}
	  }


	  public virtual void quadraticVertex(float cx, float cy, float cz, float x3, float y3, float z3)
	  {
	  }


	  ///////////////////////////////////////////////////////////

	  //

	  // Catmull-Rom curves

	  public virtual void curveDetail(int detail)
	  {
	  }

	  public virtual void curveTightness(float tightness)
	  {
	  }

	  public virtual void curveVertex(float x, float y)
	  {
	  }

	  public virtual void curveVertex(float x, float y, float z)
	  {
	  }



	  // . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . .


	  /*
	  boolean strokeSaved;
	  int strokeColorSaved;
	  float strokeWeightSaved;
	  int strokeCapSaved;
	  int strokeJoinSaved;
	
	  boolean fillSaved;
	  int fillColorSaved;
	
	  int rectModeSaved;
	  int ellipseModeSaved;
	  int shapeModeSaved;
	  */


	  protected internal virtual void pre(PGraphics g)
	  {
		if (matrix != null)
		{
		  g.pushMatrix();
		  g.applyMatrix(matrix);
		}

		/*
		strokeSaved = g.stroke;
		strokeColorSaved = g.strokeColor;
		strokeWeightSaved = g.strokeWeight;
		strokeCapSaved = g.strokeCap;
		strokeJoinSaved = g.strokeJoin;
	
		fillSaved = g.fill;
		fillColorSaved = g.fillColor;
	
		rectModeSaved = g.rectMode;
		ellipseModeSaved = g.ellipseMode;
		shapeModeSaved = g.shapeMode;
		*/
		if (style)
		{
		  g.pushStyle();
		  styles(g);
		}
	  }


	  protected internal virtual void styles(PGraphics g)
	  {
		// should not be necessary because using only the int version of color
		//parent.colorMode(PConstants.RGB, 255);

		if (stroke_Renamed)
		{
		  g.stroke(strokeColor);
		  g.strokeWeight(strokeWeight_Renamed);
		  g.strokeCap(strokeCap_Renamed);
		  g.strokeJoin(strokeJoin_Renamed);
		}
		else
		{
		  g.noStroke();
		}

		if (fill_Renamed)
		{
		  //System.out.println("filling " + PApplet.hex(fillColor));
		  g.fill(fillColor);
		}
		else
		{
		  g.noFill();
		}
	  }


	  protected internal virtual void post(PGraphics g)
	  {
	//    for (int i = 0; i < childCount; i++) {
	//      children[i].draw(g);
	//    }

		/*
		// TODO this is not sufficient, since not saving fillR et al.
		g.stroke = strokeSaved;
		g.strokeColor = strokeColorSaved;
		g.strokeWeight = strokeWeightSaved;
		g.strokeCap = strokeCapSaved;
		g.strokeJoin = strokeJoinSaved;
	
		g.fill = fillSaved;
		g.fillColor = fillColorSaved;
	
		g.ellipseMode = ellipseModeSaved;
		*/

		if (matrix != null)
		{
		  g.popMatrix();
		}

		if (style)
		{
		  g.popStyle();
		}
	  }


	  ////////////////////////////////////////////////////////////////////////
	  //
	  // Shape copy

		// TODO: after PApplet
	  // TODO unapproved
//	  protected internal static PShape createShape(PApplet parent, PShape src)
//	  {
//		PShape dest = null;
//		if (src.family == PConstants_Fields.GROUP)
//		{
//		  dest = parent.createShape(PConstants_Fields.GROUP);
//		  PShape.copyGroup(parent, src, dest);
//		}
//		else if (src.family == PRIMITIVE)
//		{
//		  dest = parent.createShape(src.kind, src.@params);
//		  PShape.copyPrimitive(src, dest);
//		}
//		else if (src.family == GEOMETRY)
//		{
//		  dest = parent.createShape(src.kind);
//		  PShape.copyGeometry(src, dest);
//		}
//		else if (src.family == PConstants_Fields.PATH)
//		{
//		  dest = parent.createShape(PConstants_Fields.PATH);
//		  PShape.copyPath(src, dest);
//		}
//		dest.Name = src.name;
//		return dest;
//	  }

		// TODO: After PApplet
	  // TODO unapproved
//	  protected internal static void copyGroup(PApplet parent, PShape src, PShape dest)
//	  {
//		copyMatrix(src, dest);
//		copyStyles(src, dest);
//		copyImage(src, dest);
//		for (int i = 0; i < src.childCount; i++)
//		{
//		  PShape c = PShape.createShape(parent, src.children[i]);
//		  dest.addChild(c);
//		}
//	  }


	  // TODO unapproved
	  protected internal static void copyPrimitive(PShape src, PShape dest)
	  {
		copyMatrix(src, dest);
		copyStyles(src, dest);
		copyImage(src, dest);
	  }


	  // TODO unapproved
	  protected internal static void copyGeometry(PShape src, PShape dest)
	  {
		dest.beginShape(src.Kind);

		copyMatrix(src, dest);
		copyStyles(src, dest);
		copyImage(src, dest);

		if (src.style)
		{
		  for (int i = 0; i < src.vertexCount; i++)
		  {
			float[] vert = src.vertices[i];

			dest.fill((int)(vert[PGraphics.A] * 255) << 24 | (int)(vert[PGraphics.R] * 255) << 16 | (int)(vert[PGraphics.G] * 255) << 8 | (int)(vert[PGraphics.B] * 255));

		 // Do we need to copy these as well?
	//        dest.ambient(vert[PGraphics.AR] * 255, vert[PGraphics.AG] * 255, vert[PGraphics.AB] * 255);
	//        dest.specular(vert[PGraphics.SPR] * 255, vert[PGraphics.SPG] * 255, vert[PGraphics.SPB] * 255);
	//        dest.emissive(vert[PGraphics.ER] * 255, vert[PGraphics.EG] * 255, vert[PGraphics.EB] * 255);
	//        dest.shininess(vert[PGraphics.SHINE]);

					//TODO:PApplet
					//			if (0 < PApplet.dist(vert[PGraphics.NX], vert[PGraphics.NY], vert[PGraphics.NZ], 0, 0, 0))
//			{
//			  dest.normal(vert[PGraphics.NX], vert[PGraphics.NY], vert[PGraphics.NZ]);
//			}
			dest.vertex(vert[PConstants_Fields.X], vert[PConstants_Fields.Y], vert[PConstants_Fields.Z], vert[PGraphics.U], vert[PGraphics.V]);
		  }
		}
		else
		{
		  for (int i = 0; i < src.vertexCount; i++)
		  {
			float[] vert = src.vertices[i];
			if (vert[PConstants_Fields.Z] == 0)
			{
			  dest.vertex(vert[PConstants_Fields.X], vert[PConstants_Fields.Y]);
			}
			else
			{
			  dest.vertex(vert[PConstants_Fields.X], vert[PConstants_Fields.Y], vert[PConstants_Fields.Z]);
			}
		  }
		}

		dest.endShape();
	  }


	  // TODO unapproved
	  protected internal static void copyPath(PShape src, PShape dest)
	  {
		copyMatrix(src, dest);
		copyStyles(src, dest);
		copyImage(src, dest);
		dest.close = src.close;
		dest.setPath(src.vertexCount, src.vertices, src.vertexCodeCount, src.vertexCodes);
	  }


	  // TODO unapproved
	  protected internal static void copyMatrix(PShape src, PShape dest)
	  {
		if (src.matrix != null)
		{
		  dest.applyMatrix(src.matrix);
		}
	  }


	  // TODO unapproved
	  protected internal static void copyStyles(PShape src, PShape dest)
	  {
		if (src.stroke_Renamed)
		{
		  dest.stroke_Renamed = true;
		  dest.strokeColor = src.strokeColor;
		  dest.strokeWeight_Renamed = src.strokeWeight_Renamed;
		  dest.strokeCap_Renamed = src.strokeCap_Renamed;
		  dest.strokeJoin_Renamed = src.strokeJoin_Renamed;
		}
		else
		{
		  dest.stroke_Renamed = false;
		}

		if (src.fill_Renamed)
		{
		  dest.fill_Renamed = true;
		  dest.fillColor = src.fillColor;
		}
		else
		{
		  dest.fill_Renamed = false;
		}
	  }


	  // TODO unapproved
	  protected internal static void copyImage(PShape src, PShape dest)
	  {
		if (src.image != null)
		{
		  dest.texture(src.image);
		}
	  }



	  ////////////////////////////////////////////////////////////////////////


	  /// <summary>
	  /// Called by the following (the shape() command adds the g)
	  /// PShape s = loadShape("blah.svg");
	  /// shape(s);
	  /// </summary>
	  public virtual void draw(PGraphics g)
	  {
		if (visible)
		{
		  pre(g);
		  drawImpl(g);
		  post(g);
		}
	  }


	  /// <summary>
	  /// Draws the SVG document.
	  /// </summary>
	  public virtual void drawImpl(PGraphics g)
	  {
		//System.out.println("drawing " + family);
		if (family == PConstants_Fields.GROUP)
		{
		  drawGroup(g);
		}
		else if (family == PRIMITIVE)
		{
		  drawPrimitive(g);
		}
		else if (family == GEOMETRY)
		{
		  drawGeometry(g);
		}
		else if (family == PConstants_Fields.PATH)
		{
		  drawPath(g);
		}
	  }


	  protected internal virtual void drawGroup(PGraphics g)
	  {
		for (int i = 0; i < childCount; i++)
		{
		  children[i].draw(g);
		}
	  }


	  protected internal virtual void drawPrimitive(PGraphics g)
	  {
		if (kind == PConstants_Fields.POINT)
		{
		  g.point(@params[0], @params[1]);

		}
		else if (kind == PConstants_Fields.LINE)
		{
		  if (@params.Length == 4) // 2D
		  {
			g.line(@params[0], @params[1], @params[2], @params[3]);
		  } // 3D
		  else
		  {
			g.line(@params[0], @params[1], @params[2], @params[3], @params[4], @params[5]);
		  }

		}
		else if (kind == PConstants_Fields.TRIANGLE)
		{
		  g.triangle(@params[0], @params[1], @params[2], @params[3], @params[4], @params[5]);

		}
		else if (kind == PConstants_Fields.QUAD)
		{
		  g.quad(@params[0], @params[1], @params[2], @params[3], @params[4], @params[5], @params[6], @params[7]);

		}
		else if (kind == PConstants_Fields.RECT)
		{
		  if (image != null)
		  {
			g.imageMode(PConstants_Fields.CORNER);
			g.image(image, @params[0], @params[1], @params[2], @params[3]);
		  }
		  else
		  {
			g.rectMode(PConstants_Fields.CORNER);
			g.rect(@params[0], @params[1], @params[2], @params[3]);
		  }

		}
		else if (kind == PConstants_Fields.ELLIPSE)
		{
		  g.ellipseMode(PConstants_Fields.CORNER);
		  g.ellipse(@params[0], @params[1], @params[2], @params[3]);

		}
		else if (kind == PConstants_Fields.ARC)
		{
		  g.ellipseMode(PConstants_Fields.CORNER);
		  g.arc(@params[0], @params[1], @params[2], @params[3], @params[4], @params[5]);

		}
		else if (kind == PConstants_Fields.BOX)
		{
		  if (@params.Length == 1)
		  {
			g.box(@params[0]);
		  }
		  else
		  {
			g.box(@params[0], @params[1], @params[2]);
		  }

		}
		else if (kind == PConstants_Fields.SPHERE)
		{
		  g.sphere(@params[0]);
		}
	  }


	  protected internal virtual void drawGeometry(PGraphics g)
	  {
		// get cache object using g.
		g.beginShape(kind);
		if (style)
		{
		  for (int i = 0; i < vertexCount; i++)
		  {
			g.vertex(vertices[i]);
		  }
		}
		else
		{
		  for (int i = 0; i < vertexCount; i++)
		  {
			float[] vert = vertices[i];
			if (vert[PConstants_Fields.Z] == 0)
			{
			  g.vertex(vert[PConstants_Fields.X], vert[PConstants_Fields.Y]);
			}
			else
			{
			  g.vertex(vert[PConstants_Fields.X], vert[PConstants_Fields.Y], vert[PConstants_Fields.Z]);
			}
		  }
		}
		g.endShape();
	  }


	  /*
	  protected void drawPath(PGraphics g) {
	    g.beginShape();
	    for (int j = 0; j < childCount; j++) {
	      if (j > 0) g.breakShape();
	      int count = children[j].vertexCount;
	      float[][] vert = children[j].vertices;
	      int[] code = children[j].vertexCodes;
	
	      for (int i = 0; i < count; i++) {
	        if (style) {
	          if (children[j].fill) {
	            g.fill(vert[i][R], vert[i][G], vert[i][B]);
	          } else {
	            g.noFill();
	          }
	          if (children[j].stroke) {
	            g.stroke(vert[i][R], vert[i][G], vert[i][B]);
	          } else {
	            g.noStroke();
	          }
	        }
	        g.edge(vert[i][EDGE] == 1);
	
	        if (code[i] == VERTEX) {
	          g.vertex(vert[i]);
	
	        } else if (code[i] == BEZIER_VERTEX) {
	          float z0 = vert[i+0][Z];
	          float z1 = vert[i+1][Z];
	          float z2 = vert[i+2][Z];
	          if (z0 == 0 && z1 == 0 && z2 == 0) {
	            g.bezierVertex(vert[i+0][X], vert[i+0][Y], z0,
	                           vert[i+1][X], vert[i+1][Y], z1,
	                           vert[i+2][X], vert[i+2][Y], z2);
	          } else {
	            g.bezierVertex(vert[i+0][X], vert[i+0][Y],
	                           vert[i+1][X], vert[i+1][Y],
	                           vert[i+2][X], vert[i+2][Y]);
	          }
	        } else if (code[i] == CURVE_VERTEX) {
	          float z = vert[i][Z];
	          if (z == 0) {
	            g.curveVertex(vert[i][X], vert[i][Y]);
	          } else {
	            g.curveVertex(vert[i][X], vert[i][Y], z);
	          }
	        }
	      }
	    }
	    g.endShape();
	  }
	  */


	  protected internal virtual void drawPath(PGraphics g)
	  {
		// Paths might be empty (go figure)
		// http://dev.processing.org/bugs/show_bug.cgi?id=982
		if (vertices == null)
		{
			return;
		}

		bool insideContour = false;
		g.beginShape();

		if (vertexCodeCount == 0) // each point is a simple vertex
		{
		  if (vertices[0].Length == 2) // drawing 2D vertices
		  {
			for (int i = 0; i < vertexCount; i++)
			{
			  g.vertex(vertices[i][PConstants_Fields.X], vertices[i][PConstants_Fields.Y]);
			}
		  } // drawing 3D vertices
		  else
		  {
			for (int i = 0; i < vertexCount; i++)
			{
			  g.vertex(vertices[i][PConstants_Fields.X], vertices[i][PConstants_Fields.Y], vertices[i][PConstants_Fields.Z]);
			}
		  }

		} // coded set of vertices
		else
		{
		  int index = 0;

		  if (vertices[0].Length == 2) // drawing a 2D path
		  {
			for (int j = 0; j < vertexCodeCount; j++)
			{
			  switch (vertexCodes[j])
			  {

			  case PConstants_Fields.VERTEX:
				g.vertex(vertices[index][PConstants_Fields.X], vertices[index][PConstants_Fields.Y]);
				index++;
				break;

			  case PConstants_Fields.QUADRATIC_VERTEX:
				g.quadraticVertex(vertices[index + 0][PConstants_Fields.X], vertices[index + 0][PConstants_Fields.Y], vertices[index + 1][PConstants_Fields.X], vertices[index + 1][PConstants_Fields.Y]);
				index += 2;
				break;

			  case PConstants_Fields.BEZIER_VERTEX:
				g.bezierVertex(vertices[index + 0][PConstants_Fields.X], vertices[index + 0][PConstants_Fields.Y], vertices[index + 1][PConstants_Fields.X], vertices[index + 1][PConstants_Fields.Y], vertices[index + 2][PConstants_Fields.X], vertices[index + 2][PConstants_Fields.Y]);
				index += 3;
				break;

			  case PConstants_Fields.CURVE_VERTEX:
				g.curveVertex(vertices[index][PConstants_Fields.X], vertices[index][PConstants_Fields.Y]);
				index++;
				break;

			  case PConstants_Fields.BREAK:
				if (insideContour)
				{
				  g.endContour();
				}
				g.beginContour();
				insideContour = true;
			break;
			  }
			}
		  } // drawing a 3D path
		  else
		  {
			for (int j = 0; j < vertexCodeCount; j++)
			{
			  switch (vertexCodes[j])
			  {

			  case PConstants_Fields.VERTEX:
				g.vertex(vertices[index][PConstants_Fields.X], vertices[index][PConstants_Fields.Y], vertices[index][PConstants_Fields.Z]);
				index++;
				break;

			  case PConstants_Fields.QUADRATIC_VERTEX:
				g.quadraticVertex(vertices[index + 0][PConstants_Fields.X], vertices[index + 0][PConstants_Fields.Y], vertices[index + 0][PConstants_Fields.Z], vertices[index + 1][PConstants_Fields.X], vertices[index + 1][PConstants_Fields.Y], vertices[index + 0][PConstants_Fields.Z]);
				index += 2;
				break;


			  case PConstants_Fields.BEZIER_VERTEX:
				g.bezierVertex(vertices[index + 0][PConstants_Fields.X], vertices[index + 0][PConstants_Fields.Y], vertices[index + 0][PConstants_Fields.Z], vertices[index + 1][PConstants_Fields.X], vertices[index + 1][PConstants_Fields.Y], vertices[index + 1][PConstants_Fields.Z], vertices[index + 2][PConstants_Fields.X], vertices[index + 2][PConstants_Fields.Y], vertices[index + 2][PConstants_Fields.Z]);
				index += 3;
				break;

			  case PConstants_Fields.CURVE_VERTEX:
				g.curveVertex(vertices[index][PConstants_Fields.X], vertices[index][PConstants_Fields.Y], vertices[index][PConstants_Fields.Z]);
				index++;
				break;

			  case PConstants_Fields.BREAK:
				if (insideContour)
				{
				  g.endContour();
				}
				g.beginContour();
				insideContour = true;
			break;
			  }
			}
		  }
		}
		if (insideContour)
		{
		  g.endContour();
		}
		g.endShape(close ? PConstants_Fields.CLOSE : PConstants_Fields.OPEN);
	  }


	  // . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . .


	  public virtual PShape Parent
	  {
		  get
		  {
			return parent;
		  }
	  }

	  /// <summary>
	  /// @webref
	  /// @brief Returns the number of children
	  /// </summary>
	  public virtual int ChildCount
	  {
		  get
		  {
			return childCount;
		  }
	  }


	  public virtual PShape[] Children
	  {
		  get
		  {
			return children;
		  }
	  }

	  /// <summary>
	  /// ( begin auto-generated from PShape_getChild.xml )
	  /// 
	  /// Extracts a child shape from a parent shape. Specify the name of the
	  /// shape with the <b>target</b> parameter. The shape is returned as a
	  /// <b>PShape</b> object, or <b>null</b> is returned if there is an error.
	  /// 
	  /// ( end auto-generated )
	  /// @webref pshape:method
	  /// @usage web_application
	  /// @brief Returns a child element of a shape as a PShape object </summary>
	  /// <param name="index"> the layer position of the shape to get </param>
	  /// <seealso cref= PShape#addChild(PShape) </seealso>
	  public virtual PShape getChild(int index)
	  {
		return children[index];
	  }

	 /// <param name="target"> the name of the shape to get </param>
	  public virtual PShape getChild(string target)
	  {
		if (name != null && name.Equals(target))
		{
		  return this;
		}
		if (nameTable != null)
		{
		  PShape found = nameTable[target];
		  if (found != null)
		  {
			  return found;
		  }
		}
		for (int i = 0; i < childCount; i++)
		{
		  PShape found = children[i].getChild(target);
		  if (found != null)
		  {
			  return found;
		  }
		}
		return null;
	  }


	  /// <summary>
	  /// Same as getChild(name), except that it first walks all the way up the
	  /// hierarchy to the eldest grandparent, so that children can be found anywhere.
	  /// </summary>
	  public virtual PShape findChild(string target)
	  {
		if (parent == null)
		{
		  return getChild(target);

		}
		else
		{
		  return parent.findChild(target);
		}
	  }


	  // can't be just 'add' because that suggests additive geometry
	  /// <summary>
	  /// @webref pshape:method
	  /// @brief Adds a new child </summary>
	  /// <param name="who"> any variable of type PShape </param>
	  /// <seealso cref= PShape#getChild(int) </seealso>
	  public virtual void addChild(PShape who)
	  {
		if (children == null)
		{
		  children = new PShape[1];
		}
		if (childCount == children.Length)
		{
				//TODO:PApplet
				//		  children = (PShape[]) PApplet.expand(children);
		}
		children[childCount++] = who;
		who.parent = this;

		if (who.Name != null)
		{
		  addName(who.Name, who);
		}
	  }


	  // adds child who exactly at position idx in the array of children.
	  /// <param name="idx"> the layer position in which to insert the new child </param>
	  public virtual void addChild(PShape who, int idx)
	  {
		if (idx < childCount)
		{
		  if (childCount == children.Length)
		  {
					//TODO:PApplet
					//			children = (PShape[]) PApplet.expand(children);
		  }

		  // Copy [idx, childCount - 1] to [idx + 1, childCount]
		  for (int i = childCount - 1; i >= idx; i--)
		  {
			children[i + 1] = children[i];
		  }
		  childCount++;

		  children[idx] = who;

		  who.parent = this;

		  if (who.Name != null)
		  {
			addName(who.Name, who);
		  }
		}
	  }


	  /// <summary>
	  /// Remove the child shape with index idx.
	  /// </summary>
	  public virtual void removeChild(int idx)
	  {
		if (idx < childCount)
		{
		  PShape child = children[idx];

		  // Copy [idx + 1, childCount - 1] to [idx, childCount - 2]
		  for (int i = idx; i < childCount - 1; i++)
		  {
			children[i] = children[i + 1];
		  }
		  childCount--;

		  if (child.Name != null && nameTable != null)
		  {
			nameTable.Remove(child.Name);
		  }
		}
	  }


	  /// <summary>
	  /// Add a shape to the name lookup table.
	  /// </summary>
	  public virtual void addName(string nom, PShape shape)
	  {
		if (parent != null)
		{
		  parent.addName(nom, shape);
		}
		else
		{
		  if (nameTable == null)
		  {
			nameTable = new Dictionary<string, PShape>();
		  }
		  nameTable[nom] = shape;
		}
	  }


	  /// <summary>
	  /// Returns the index of child who.
	  /// </summary>
	  public virtual int getChildIndex(PShape who)
	  {
		for (int i = 0; i < childCount; i++)
		{
		  if (children[i] == who)
		  {
			return i;
		  }
		}
		return -1;
	  }


	  public virtual PShape Tessellation
	  {
		  get
		  {
			return null;
		  }
	  }


	  // . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . .


	  /// <summary>
	  /// The shape type, one of GROUP, PRIMITIVE, PATH, or GEOMETRY. </summary>
	  public virtual int Family
	  {
		  get
		  {
			return family;
		  }
	  }




	  public virtual float[] Params
	  {
		  get
		  {
			return getParams(null);
		  }
		  set
		  {
			if (@params == null)
			{
			  @params = new float[value.Length];
			}
			if (value.Length != @params.Length)
			{
			  PGraphics.showWarning("Wrong number of parameters");
			  return;
			}
				// TODO: After PApplet
			//PApplet.arrayCopy(value, @params);
		  }
	  }


	  public virtual float[] getParams(float[] target)
	  {
		if (target == null || target.Length != @params.Length)
		{
		  target = new float[@params.Length];
		}
			//TODO:PApplet
			//		PApplet.arrayCopy(@params, target);
		return target;
	  }


	  public virtual float getParam(int index)
	  {
		return @params[index];
	  }




	  public virtual void setPath(int vcount, float[][] verts)
	  {
		setPath(vcount, verts, 0, null);
	  }


	  protected internal virtual void setPath(int vcount, float[][] verts, int ccount, int[] codes)
	  {
		if (verts == null || verts.Length < vcount)
		{
			return;
		}
		if (0 < ccount && (codes == null || codes.Length < ccount))
		{
			return;
		}

		int ndim = verts[0].Length;
		vertexCount = vcount;
//JAVA TO C# CONVERTER NOTE: The following call to the 'RectangularArrays' helper class reproduces the rectangular array initialization that is automatic in Java:
//ORIGINAL LINE: vertices = new float[vertexCount][ndim];
		vertices = RectangularArrays.ReturnRectangularFloatArray(vertexCount, ndim);
		for (int i = 0; i < vertexCount; i++)
		{

				//TODO:PApplet
				//		  PApplet.arrayCopy(verts[i], vertices[i]);
		}

		vertexCodeCount = ccount;
		if (0 < vertexCodeCount)
		{
		  vertexCodes = new int[vertexCodeCount];
				//TODO:PApplet
//		  PApplet.arrayCopy(codes, vertexCodes, vertexCodeCount);
		}
	  }

	  /// <summary>
	  /// @webref pshape:method
	  /// @brief Returns the total number of vertices as an int </summary>
	  /// <seealso cref= PShape#getVertex(int) </seealso>
	  /// <seealso cref= PShape#setVertex(int, float, float) </seealso>
	  public virtual int VertexCount
	  {
		  get
		  {
			return vertexCount;
		  }
	  }


	  /// <summary>
	  /// @webref pshape:method
	  /// @brief Returns the vertex at the index position </summary>
	  /// <param name="index"> the location of the vertex </param>
	  /// <seealso cref= PShape#setVertex(int, float, float) </seealso>
	  /// <seealso cref= PShape#getVertexCount() </seealso>
	  public virtual PVector getVertex(int index)
	  {
		return getVertex(index, null);
	  }


	  /// <param name="vec"> PVector to assign the data to </param>
	  public virtual PVector getVertex(int index, PVector vec)
	  {
		if (vec == null)
		{
		  vec = new PVector();
		}
		float[] vert = vertices[index];
		vec.x = vert[PConstants_Fields.X];
		vec.y = vert[PConstants_Fields.Y];
		if (vert.Length > 2)
		{
		  vec.z = vert[PConstants_Fields.Z];
		}
		else
		{
		  vec.z = 0; // in case this isn't a new vector
		}
		return vec;
	  }


	  public virtual float getVertexX(int index)
	  {
		return vertices[index][PConstants_Fields.X];
	  }


	  public virtual float getVertexY(int index)
	  {
		return vertices[index][PConstants_Fields.Y];
	  }


	  public virtual float getVertexZ(int index)
	  {
		return vertices[index][PConstants_Fields.Z];
	  }

	  /// <summary>
	  /// @webref pshape:method
	  /// @brief Sets the vertex at the index position </summary>
	  /// <param name="index"> the location of the vertex </param>
	  /// <param name="x"> the x value for the vertex </param>
	  /// <param name="y"> the y value for the vertex </param>
	  /// <seealso cref= PShape#getVertex(int) </seealso>
	  /// <seealso cref= PShape#getVertexCount() </seealso>
	  public virtual void setVertex(int index, float x, float y)
	  {
		if (openShape)
		{
		  PGraphics.showWarning(INSIDE_BEGIN_END_ERROR, "setVertex()");
		  return;
		}

		vertices[index][PConstants_Fields.X] = x;
		vertices[index][PConstants_Fields.Y] = y;
	  }

	  /// <param name="z"> the z value for the vertex </param>
	  public virtual void setVertex(int index, float x, float y, float z)
	  {
		if (openShape)
		{
		  PGraphics.showWarning(INSIDE_BEGIN_END_ERROR, "setVertex()");
		  return;
		}

		vertices[index][PConstants_Fields.X] = x;
		vertices[index][PConstants_Fields.Y] = y;
		vertices[index][PConstants_Fields.Z] = z;
	  }

	  /// <param name="vec"> the PVector to define the x, y, z coordinates </param>
	  public virtual void setVertex(int index, PVector vec)
	  {
		if (openShape)
		{
		  PGraphics.showWarning(INSIDE_BEGIN_END_ERROR, "setVertex()");
		  return;
		}

		vertices[index][PConstants_Fields.X] = vec.x;
		vertices[index][PConstants_Fields.Y] = vec.y;
		vertices[index][PConstants_Fields.Z] = vec.z;
	  }


	  public virtual PVector getNormal(int index)
	  {
		return getNormal(index, null);
	  }


	  public virtual PVector getNormal(int index, PVector vec)
	  {
		if (vec == null)
		{
		  vec = new PVector();
		}
		vec.x = vertices[index][PGraphics.NX];
		vec.y = vertices[index][PGraphics.NY];
		vec.z = vertices[index][PGraphics.NZ];
		return vec;
	  }


	  public virtual float getNormalX(int index)
	  {
		return vertices[index][PGraphics.NX];
	  }


	  public virtual float getNormalY(int index)
	  {
		return vertices[index][PGraphics.NY];
	  }


	  public virtual float getNormalZ(int index)
	  {
		return vertices[index][PGraphics.NZ];
	  }


	  public virtual void setNormal(int index, float nx, float ny, float nz)
	  {
		if (openShape)
		{
		  PGraphics.showWarning(INSIDE_BEGIN_END_ERROR, "setNormal()");
		  return;
		}

		vertices[index][PGraphics.NX] = nx;
		vertices[index][PGraphics.NY] = ny;
		vertices[index][PGraphics.NZ] = nz;
	  }


	  public virtual float getTextureU(int index)
	  {
		return vertices[index][PGraphics.U];
	  }


	  public virtual float getTextureV(int index)
	  {
		return vertices[index][PGraphics.V];
	  }


	  public virtual void setTextureUV(int index, float u, float v)
	  {
		if (openShape)
		{
		  PGraphics.showWarning(INSIDE_BEGIN_END_ERROR, "setTextureUV()");
		  return;
		}

		vertices[index][PGraphics.U] = u;
		vertices[index][PGraphics.V] = v;
	  }


	  public virtual int TextureMode
	  {
		  set
		  {
			if (openShape)
			{
			  PGraphics.showWarning(INSIDE_BEGIN_END_ERROR, "setTextureMode()");
			  return;
			}
    
			textureMode_Renamed = value;
		  }
	  }


	  public virtual PImage Texture
	  {
		  set
		  {
			if (openShape)
			{
			  PGraphics.showWarning(INSIDE_BEGIN_END_ERROR, "setTexture()");
			  return;
			}
    
			image = value;
		  }
	  }


	  public virtual int getFill(int index)
	  {
		if (image == null)
		{
		  int a = (int)(vertices[index][PGraphics.A] * 255);
		  int r = (int)(vertices[index][PGraphics.R] * 255);
		  int g = (int)(vertices[index][PGraphics.G] * 255);
		  int b = (int)(vertices[index][PGraphics.B] * 255);
		  return (a << 24) | (r << 16) | (g << 8) | b;
		}
		else
		{
		  return 0;
		}
	  }

	
		// TODO: Fill keyword ovewrapped
		// rename to Fill-> IsFill
	  public virtual bool IsFill
	  {
		  set
		  {
			if (openShape)
			{
				PGraphics.showWarning(INSIDE_BEGIN_END_ERROR, "setFill()");
				return;
			}

			this.fill_Renamed = value;
		  }
	  }


		public virtual int Fill
		{
			set
			{
				if (openShape)
				{
					PGraphics.showWarning(INSIDE_BEGIN_END_ERROR, "setFill()");
					return;
				}

				for (int i = 0; i < vertices.Length; i++)
				{
					setFill(i, value);
				}
			}
		}


	  public virtual void setFill(int index, int fill)
	  {
		if (openShape)
		{
		  PGraphics.showWarning(INSIDE_BEGIN_END_ERROR, "setFill()");
		  return;
		}

		if (image == null)
		{
		  vertices[index][PGraphics.A] = ((fill >> 24) & 0xFF) / 255.0f;
		  vertices[index][PGraphics.R] = ((fill >> 16) & 0xFF) / 255.0f;
		  vertices[index][PGraphics.G] = ((fill >> 8) & 0xFF) / 255.0f;
		  vertices[index][PGraphics.B] = ((fill >> 0) & 0xFF) / 255.0f;
		}
	  }


	  public virtual int getTint(int index)
	  {
		if (image != null)
		{
		  int a = (int)(vertices[index][PGraphics.A] * 255);
		  int r = (int)(vertices[index][PGraphics.R] * 255);
		  int g = (int)(vertices[index][PGraphics.G] * 255);
		  int b = (int)(vertices[index][PGraphics.B] * 255);
		  return (a << 24) | (r << 16) | (g << 8) | b;
		}
		else
		{
		  return 0;
		}
	  }


		// TODO: Property name overwrap
		// Tint -> IsTint
	  public virtual bool IsTint
	  {
		  set
		  {
			if (openShape)
			{
			  PGraphics.showWarning(INSIDE_BEGIN_END_ERROR, "setTint()");
			  return;
			}
    
			this.tint_Renamed = value;
		  }
	  }


	  public virtual int Tint
	  {
		  set
		  {
			if (openShape)
			{
			  PGraphics.showWarning(INSIDE_BEGIN_END_ERROR, "setTint()");
			  return;
			}
    
			for (int i = 0; i < vertices.Length; i++)
			{
			  setFill(i, value);
			}
		  }
	  }


	  public virtual void setTint(int index, int tint)
	  {
		if (openShape)
		{
		  PGraphics.showWarning(INSIDE_BEGIN_END_ERROR, "setTint()");
		  return;
		}

		if (image != null)
		{
		  vertices[index][PGraphics.A] = ((tint >> 24) & 0xFF) / 255.0f;
		  vertices[index][PGraphics.R] = ((tint >> 16) & 0xFF) / 255.0f;
		  vertices[index][PGraphics.G] = ((tint >> 8) & 0xFF) / 255.0f;
		  vertices[index][PGraphics.B] = ((tint >> 0) & 0xFF) / 255.0f;
		}
	  }


	  public virtual int getStroke(int index)
	  {
		int a = (int)(vertices[index][PGraphics.SA] * 255);
		int r = (int)(vertices[index][PGraphics.SR] * 255);
		int g = (int)(vertices[index][PGraphics.SG] * 255);
		int b = (int)(vertices[index][PGraphics.SB] * 255);
		return (a << 24) | (r << 16) | (g << 8) | b;
	  }


		// TODO: prop name overwrap
		// Stroke->IsStroke
	  public virtual bool IsStroke
	  {
		  set
		  {
			if (openShape)
			{
			  PGraphics.showWarning(INSIDE_BEGIN_END_ERROR, "setStroke()");
			  return;
			}
    
			this.stroke_Renamed = value;
		  }
	  }


	  public virtual int Stroke
	  {
		  set
		  {
			if (openShape)
			{
			  PGraphics.showWarning(INSIDE_BEGIN_END_ERROR, "setStroke()");
			  return;
			}
    
			for (int i = 0; i < vertices.Length; i++)
			{
			  setStroke(i, value);
			}
		  }
	  }


	  public virtual void setStroke(int index, int stroke)
	  {
		if (openShape)
		{
		  PGraphics.showWarning(INSIDE_BEGIN_END_ERROR, "setStroke()");
		  return;
		}

		vertices[index][PGraphics.SA] = ((stroke >> 24) & 0xFF) / 255.0f;
		vertices[index][PGraphics.SR] = ((stroke >> 16) & 0xFF) / 255.0f;
		vertices[index][PGraphics.SG] = ((stroke >> 8) & 0xFF) / 255.0f;
		vertices[index][PGraphics.SB] = ((stroke >> 0) & 0xFF) / 255.0f;
	  }


	  public virtual float getStrokeWeight(int index)
	  {
		return vertices[index][PGraphics.SW];
	  }


	  public virtual float StrokeWeight
	  {
		  set
		  {
			if (openShape)
			{
			  PGraphics.showWarning(INSIDE_BEGIN_END_ERROR, "setStrokeWeight()");
			  return;
			}
    
			for (int i = 0; i < vertices.Length; i++)
			{
			  setStrokeWeight(i, value);
			}
		  }
	  }


	  public virtual void setStrokeWeight(int index, float weight)
	  {
		if (openShape)
		{
		  PGraphics.showWarning(INSIDE_BEGIN_END_ERROR, "setStrokeWeight()");
		  return;
		}

		vertices[index][PGraphics.SW] = weight;
	  }


	  public virtual int StrokeJoin
	  {
		  set
		  {
			if (openShape)
			{
			  PGraphics.showWarning(INSIDE_BEGIN_END_ERROR, "setStrokeJoin()");
			  return;
			}
    
			strokeJoin_Renamed = value;
		  }
	  }


	  public virtual int StrokeCap
	  {
		  set
		  {
			if (openShape)
			{
			  PGraphics.showWarning(INSIDE_BEGIN_END_ERROR, "setStrokeCap()");
			  return;
			}
    
			strokeCap_Renamed = value;
		  }
	  }


	  public virtual int getAmbient(int index)
	  {
		int r = (int)(vertices[index][PGraphics.AR] * 255);
		int g = (int)(vertices[index][PGraphics.AG] * 255);
		int b = (int)(vertices[index][PGraphics.AB] * 255);
		return unchecked((int)0xff000000) | (r << 16) | (g << 8) | b;
	  }


	  public virtual int Ambient
	  {
		  set
		  {
			if (openShape)
			{
			  PGraphics.showWarning(INSIDE_BEGIN_END_ERROR, "setAmbient()");
			  return;
			}
    
			for (int i = 0; i < vertices.Length; i++)
			{
			  setAmbient(i, value);
			}
		  }
	  }


	  public virtual void setAmbient(int index, int ambient)
	  {
		if (openShape)
		{
		  PGraphics.showWarning(INSIDE_BEGIN_END_ERROR, "setAmbient()");
		  return;
		}

		vertices[index][PGraphics.AR] = ((ambient >> 16) & 0xFF) / 255.0f;
		vertices[index][PGraphics.AG] = ((ambient >> 8) & 0xFF) / 255.0f;
		vertices[index][PGraphics.AB] = ((ambient >> 0) & 0xFF) / 255.0f;
	  }


	  public virtual int getSpecular(int index)
	  {
		int r = (int)(vertices[index][PGraphics.SPR] * 255);
		int g = (int)(vertices[index][PGraphics.SPG] * 255);
		int b = (int)(vertices[index][PGraphics.SPB] * 255);
		return unchecked((int)0xff000000) | (r << 16) | (g << 8) | b;
	  }


	  public virtual int Specular
	  {
		  set
		  {
			if (openShape)
			{
			  PGraphics.showWarning(INSIDE_BEGIN_END_ERROR, "setSpecular()");
			  return;
			}
    
			for (int i = 0; i < vertices.Length; i++)
			{
			  setSpecular(i, value);
			}
		  }
	  }


	  public virtual void setSpecular(int index, int specular)
	  {
		if (openShape)
		{
		  PGraphics.showWarning(INSIDE_BEGIN_END_ERROR, "setSpecular()");
		  return;
		}

		vertices[index][PGraphics.SPR] = ((specular >> 16) & 0xFF) / 255.0f;
		vertices[index][PGraphics.SPG] = ((specular >> 8) & 0xFF) / 255.0f;
		vertices[index][PGraphics.SPB] = ((specular >> 0) & 0xFF) / 255.0f;
	  }


	  public virtual int getEmissive(int index)
	  {
		int r = (int)(vertices[index][PGraphics.ER] * 255);
		int g = (int)(vertices[index][PGraphics.EG] * 255);
		int b = (int)(vertices[index][PGraphics.EB] * 255);
		return unchecked((int)0xff000000) | (r << 16) | (g << 8) | b;
	  }


	  public virtual int Emissive
	  {
		  set
		  {
			if (openShape)
			{
			  PGraphics.showWarning(INSIDE_BEGIN_END_ERROR, "setEmissive()");
			  return;
			}
    
			for (int i = 0; i < vertices.Length; i++)
			{
			  setEmissive(i, value);
			}
		  }
	  }


	  public virtual void setEmissive(int index, int emissive)
	  {
		if (openShape)
		{
		  PGraphics.showWarning(INSIDE_BEGIN_END_ERROR, "setEmissive()");
		  return;
		}

		vertices[index][PGraphics.ER] = ((emissive >> 16) & 0xFF) / 255.0f;
		vertices[index][PGraphics.EG] = ((emissive >> 8) & 0xFF) / 255.0f;
		vertices[index][PGraphics.EB] = ((emissive >> 0) & 0xFF) / 255.0f;
	  }


	  public virtual float getShininess(int index)
	  {
		return vertices[index][PGraphics.SHINE];
	  }


	  public virtual float Shininess
	  {
		  set
		  {
			if (openShape)
			{
			  PGraphics.showWarning(INSIDE_BEGIN_END_ERROR, "setShininess()");
			  return;
			}
    
			for (int i = 0; i < vertices.Length; i++)
			{
			  setShininess(i, value);
			}
		  }
	  }


	  public virtual void setShininess(int index, float shine)
	  {
		if (openShape)
		{
		  PGraphics.showWarning(INSIDE_BEGIN_END_ERROR, "setShininess()");
		  return;
		}

		vertices[index][PGraphics.SHINE] = shine;
	  }


	  public virtual int[] VertexCodes
	  {
		  get
		  {
			if (vertexCodes == null)
			{
			  return null;
			}
			if (vertexCodes.Length != vertexCodeCount)
			{
					// TODO: after PApplet
			  //vertexCodes = PApplet.subset(vertexCodes, 0, vertexCodeCount);
			}
			return vertexCodes;
		  }
	  }


	  public virtual int VertexCodeCount
	  {
		  get
		  {
			return vertexCodeCount;
		  }
	  }


	  /// <summary>
	  /// One of VERTEX, BEZIER_VERTEX, CURVE_VERTEX, or BREAK.
	  /// </summary>
	  public virtual int getVertexCode(int index)
	  {
		return vertexCodes[index];
	  }


	  public virtual bool Closed
	  {
		  get
		  {
			return close;
		  }
	  }


	  // . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . .


	  // http://www.ecse.rpi.edu/Homepages/wrf/Research/Short_Notes/pnpoly.html
	  public virtual bool contains(float x, float y)
	  {
		if (family == PConstants_Fields.PATH)
		{
		  bool c = false;
		  for (int i = 0, j = vertexCount - 1; i < vertexCount; j = i++)
		  {
			if (((vertices[i][PConstants_Fields.Y] > y) != (vertices[j][PConstants_Fields.Y] > y)) && (x < (vertices[j][PConstants_Fields.X] - vertices[i][PConstants_Fields.X]) * (y - vertices[i][PConstants_Fields.Y]) / (vertices[j][1] - vertices[i][PConstants_Fields.Y]) + vertices[i][PConstants_Fields.X]))
			{
			  c = !c;
			}
		  }
		  return c;
		}
		else
		{
		  throw new System.ArgumentException("The contains() method is only implemented for paths.");
		}
	  }


	  // . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . .


	  // translate, rotate, scale, apply (no push/pop)
	  //   these each call matrix.translate, etc
	  // if matrix is null when one is called,
	  //   it is created and set to identity


	/// <summary>
	/// ( begin auto-generated from PShape_translate.xml )
	///   
	/// Specifies an amount to displace the shape. The <b>x</b> parameter
	/// specifies left/right translation, the <b>y</b> parameter specifies
	/// up/down translation, and the <b>z</b> parameter specifies translations
	/// toward/away from the screen. Subsequent calls to the method accumulates
	/// the effect. For example, calling <b>translate(50, 0)</b> and then
	/// <b>translate(20, 0)</b> is the same as <b>translate(70, 0)</b>. This
	/// transformation is applied directly to the shape, it's not refreshed each
	/// time <b>draw()</b> is run.
	/// <br /><br />
	/// Using this method with the <b>z</b> parameter requires using the P3D
	/// parameter in combination with size.
	///   
	/// ( end auto-generated )
	/// @webref pshape:method
	/// @usage web_application
	/// @brief Displaces the shape </summary>
	/// <param name="tx"> left/right translation </param>
	/// <param name="ty"> up/down translation </param>
	/// <seealso cref= PShape#rotate(float) </seealso>
	/// <seealso cref= PShape#scale(float) </seealso>
	/// <seealso cref= PShape#resetMatrix() </seealso>
	  public virtual void translate(float x, float y)
	  {
		checkMatrix(2);
		matrix.translate(x, y);
	  }

	  /// <param name="tz"> forward/back translation </param>
	  public virtual void translate(float x, float y, float z)
	  {
		checkMatrix(3);
		matrix.translate(x, y, z);
	  }

	  /// <summary>
	  /// ( begin auto-generated from PShape_rotateX.xml )
	  /// 
	  /// Rotates a shape around the x-axis the amount specified by the
	  /// <b>angle</b> parameter. Angles should be specified in radians (values
	  /// from 0 to TWO_PI) or converted to radians with the <b>radians()</b> method.
	  /// <br /><br />
	  /// Shapes are always rotated around the upper-left corner of their bounding
	  /// box. Positive numbers rotate objects in a clockwise direction.
	  /// Subsequent calls to the method accumulates the effect. For example,
	  /// calling <b>rotateX(HALF_PI)</b> and then <b>rotateX(HALF_PI)</b> is the
	  /// same as <b>rotateX(PI)</b>. This transformation is applied directly to
	  /// the shape, it's not refreshed each time <b>draw()</b> is run.
	  /// <br /><br />
	  /// This method requires a 3D renderer. You need to use P3D as a third
	  /// parameter for the <b>size()</b> function as shown in the example above.
	  /// 
	  /// ( end auto-generated )
	  /// @webref pshape:method
	  /// @usage web_application
	  /// @brief Rotates the shape around the x-axis </summary>
	  /// <param name="angle"> angle of rotation specified in radians </param>
	  /// <seealso cref= PShape#rotate(float) </seealso>
	  /// <seealso cref= PShape#rotateY(float) </seealso>
	  /// <seealso cref= PShape#rotateZ(float) </seealso>
	  /// <seealso cref= PShape#scale(float) </seealso>
	  /// <seealso cref= PShape#translate(float, float) </seealso>
	  /// <seealso cref= PShape#resetMatrix() </seealso>
	  public virtual void rotateX(float angle)
	  {
		rotate(angle, 1, 0, 0);
	  }

	  /// <summary>
	  /// ( begin auto-generated from PShape_rotateY.xml )
	  /// 
	  /// Rotates a shape around the y-axis the amount specified by the
	  /// <b>angle</b> parameter. Angles should be specified in radians (values
	  /// from 0 to TWO_PI) or converted to radians with the <b>radians()</b> method.
	  /// <br /><br />
	  /// Shapes are always rotated around the upper-left corner of their bounding
	  /// box. Positive numbers rotate objects in a clockwise direction.
	  /// Subsequent calls to the method accumulates the effect. For example,
	  /// calling <b>rotateY(HALF_PI)</b> and then <b>rotateY(HALF_PI)</b> is the
	  /// same as <b>rotateY(PI)</b>. This transformation is applied directly to
	  /// the shape, it's not refreshed each time <b>draw()</b> is run.
	  /// <br /><br />
	  /// This method requires a 3D renderer. You need to use P3D as a third
	  /// parameter for the <b>size()</b> function as shown in the example above.
	  /// 
	  /// ( end auto-generated )
	  /// 
	  /// @webref pshape:method
	  /// @usage web_application
	  /// @brief Rotates the shape around the y-axis </summary>
	  /// <param name="angle"> angle of rotation specified in radians </param>
	  /// <seealso cref= PShape#rotate(float) </seealso>
	  /// <seealso cref= PShape#rotateX(float) </seealso>
	  /// <seealso cref= PShape#rotateZ(float) </seealso>
	  /// <seealso cref= PShape#scale(float) </seealso>
	  /// <seealso cref= PShape#translate(float, float) </seealso>
	  /// <seealso cref= PShape#resetMatrix() </seealso>
	  public virtual void rotateY(float angle)
	  {
		rotate(angle, 0, 1, 0);
	  }


	  /// <summary>
	  /// ( begin auto-generated from PShape_rotateZ.xml )
	  /// 
	  /// Rotates a shape around the z-axis the amount specified by the
	  /// <b>angle</b> parameter. Angles should be specified in radians (values
	  /// from 0 to TWO_PI) or converted to radians with the <b>radians()</b> method.
	  /// <br /><br />
	  /// Shapes are always rotated around the upper-left corner of their bounding
	  /// box. Positive numbers rotate objects in a clockwise direction.
	  /// Subsequent calls to the method accumulates the effect. For example,
	  /// calling <b>rotateZ(HALF_PI)</b> and then <b>rotateZ(HALF_PI)</b> is the
	  /// same as <b>rotateZ(PI)</b>. This transformation is applied directly to
	  /// the shape, it's not refreshed each time <b>draw()</b> is run.
	  /// <br /><br />
	  /// This method requires a 3D renderer. You need to use P3D as a third
	  /// parameter for the <b>size()</b> function as shown in the example above.
	  /// 
	  /// ( end auto-generated )
	  /// @webref pshape:method
	  /// @usage web_application
	  /// @brief Rotates the shape around the z-axis </summary>
	  /// <param name="angle"> angle of rotation specified in radians </param>
	  /// <seealso cref= PShape#rotate(float) </seealso>
	  /// <seealso cref= PShape#rotateX(float) </seealso>
	  /// <seealso cref= PShape#rotateY(float) </seealso>
	  /// <seealso cref= PShape#scale(float) </seealso>
	  /// <seealso cref= PShape#translate(float, float) </seealso>
	  /// <seealso cref= PShape#resetMatrix() </seealso>
	  public virtual void rotateZ(float angle)
	  {
		rotate(angle, 0, 0, 1);
	  }

	  /// <summary>
	  /// ( begin auto-generated from PShape_rotate.xml )
	  /// 
	  /// Rotates a shape the amount specified by the <b>angle</b> parameter.
	  /// Angles should be specified in radians (values from 0 to TWO_PI) or
	  /// converted to radians with the <b>radians()</b> method.
	  /// <br /><br />
	  /// Shapes are always rotated around the upper-left corner of their bounding
	  /// box. Positive numbers rotate objects in a clockwise direction.
	  /// Transformations apply to everything that happens after and subsequent
	  /// calls to the method accumulates the effect. For example, calling
	  /// <b>rotate(HALF_PI)</b> and then <b>rotate(HALF_PI)</b> is the same as
	  /// <b>rotate(PI)</b>. This transformation is applied directly to the shape,
	  /// it's not refreshed each time <b>draw()</b> is run.
	  /// 
	  /// ( end auto-generated )
	  /// @webref pshape:method
	  /// @usage web_application
	  /// @brief Rotates the shape </summary>
	  /// <param name="angle"> angle of rotation specified in radians </param>
	  /// <seealso cref= PShape#rotateX(float) </seealso>
	  /// <seealso cref= PShape#rotateY(float) </seealso>
	  /// <seealso cref= PShape#rotateZ(float) </seealso>
	  /// <seealso cref= PShape#scale(float) </seealso>
	  /// <seealso cref= PShape#translate(float, float) </seealso>
	  /// <seealso cref= PShape#resetMatrix() </seealso>
	  public virtual void rotate(float angle)
	  {
		checkMatrix(2); // at least 2...
		matrix.rotate(angle);
	  }

	/// <summary>
	/// @nowebref
	/// </summary>
	  public virtual void rotate(float angle, float v0, float v1, float v2)
	  {
		checkMatrix(3);
		float norm2 = v0 * v0 + v1 * v1 + v2 * v2;
		if (Math.Abs(norm2 - 1) > PConstants_Fields.EPSILON)
		{
		  // The rotation vector is not normalized.
				//TODO:PApplet
				//		  float norm = PApplet.sqrt(norm2);
//		  v0 /= norm;
//		  v1 /= norm;
//		  v2 /= norm;
		}
		matrix.rotate(angle, v0, v1, v2);
	  }


	  //

	  /// <summary>
	  /// ( begin auto-generated from PShape_scale.xml )
	  /// 
	  /// Increases or decreases the size of a shape by expanding and contracting
	  /// vertices. Shapes always scale from the relative origin of their bounding
	  /// box. Scale values are specified as decimal percentages. For example, the
	  /// method call <b>scale(2.0)</b> increases the dimension of a shape by
	  /// 200%. Subsequent calls to the method multiply the effect. For example,
	  /// calling <b>scale(2.0)</b> and then <b>scale(1.5)</b> is the same as
	  /// <b>scale(3.0)</b>. This transformation is applied directly to the shape,
	  /// it's not refreshed each time <b>draw()</b> is run.
	  /// <br /><br />
	  /// Using this method with the <b>z</b> parameter requires using the P3D
	  /// parameter in combination with size.
	  /// 
	  /// ( end auto-generated )
	  /// @webref pshape:method
	  /// @usage web_application
	  /// @brief Increases and decreases the size of a shape </summary>
	  /// <param name="s"> percentate to scale the object </param>
	  /// <seealso cref= PShape#rotate(float) </seealso>
	  /// <seealso cref= PShape#translate(float, float) </seealso>
	  /// <seealso cref= PShape#resetMatrix() </seealso>
	  public virtual void scale(float s)
	  {
		checkMatrix(2); // at least 2...
		matrix.scale(s);
	  }


	  public virtual void scale(float x, float y)
	  {
		checkMatrix(2);
		matrix.scale(x, y);
	  }

	/// <param name="x"> percentage to scale the object in the x-axis </param>
	/// <param name="y"> percentage to scale the object in the y-axis </param>
	/// <param name="z"> percentage to scale the object in the z-axis </param>
	  public virtual void scale(float x, float y, float z)
	  {
		checkMatrix(3);
		matrix.scale(x, y, z);
	  }


	  //

	/// <summary>
	/// ( begin auto-generated from PShape_resetMatrix.xml )
	///   
	/// Replaces the current matrix of a shape with the identity matrix. The
	/// equivalent function in OpenGL is glLoadIdentity().
	///   
	/// ( end auto-generated )
	/// @webref pshape:method
	/// @brief Replaces the current matrix of a shape with the identity matrix
	/// @usage web_application </summary>
	/// <seealso cref= PShape#rotate(float) </seealso>
	/// <seealso cref= PShape#scale(float) </seealso>
	/// <seealso cref= PShape#translate(float, float) </seealso>
	  public virtual void resetMatrix()
	  {
		checkMatrix(2);
		matrix.reset();
	  }


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
		applyMatrix(source.m00, source.m01, 0, source.m02, source.m10, source.m11, 0, source.m12, 0, 0, 1, 0, 0, 0, 0, 1);
	  }


	  public virtual void applyMatrix(float n00, float n01, float n02, float n10, float n11, float n12)
	  {
		checkMatrix(2);
		matrix.apply(n00, n01, n02, n10, n11, n12);
	  }


	  public virtual void applyMatrix(PMatrix3D source)
	  {
		applyMatrix(source.m00, source.m01, source.m02, source.m03, source.m10, source.m11, source.m12, source.m13, source.m20, source.m21, source.m22, source.m23, source.m30, source.m31, source.m32, source.m33);
	  }


	  public virtual void applyMatrix(float n00, float n01, float n02, float n03, float n10, float n11, float n12, float n13, float n20, float n21, float n22, float n23, float n30, float n31, float n32, float n33)
	  {
		checkMatrix(3);
		matrix.apply(n00, n01, n02, n03, n10, n11, n12, n13, n20, n21, n22, n23, n30, n31, n32, n33);
	  }


	  //


	  /// <summary>
	  /// Make sure that the shape's matrix is 1) not null, and 2) has a matrix
	  /// that can handle <em>at least</em> the specified number of dimensions.
	  /// </summary>
	  protected internal virtual void checkMatrix(int dimensions)
	  {
		if (matrix == null)
		{
		  if (dimensions == 2)
		  {
			matrix = new PMatrix2D();
		  }
		  else
		  {
			matrix = new PMatrix3D();
		  }
		}
		else if (dimensions == 3 && (matrix is PMatrix2D))
		{
		  // time for an upgrayedd for a double dose of my pimpin'
		  matrix = new PMatrix3D(matrix);
		}
	  }


	  // . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . .


	  /// <summary>
	  /// Center the shape based on its bounding box. Can't assume
	  /// that the bounding box is 0, 0, width, height. Common case will be
	  /// opening a letter size document in Illustrator, and drawing something
	  /// in the middle, then reading it in as an svg file.
	  /// This will also need to flip the y axis (scale(1, -1)) in cases
	  /// like Adobe Illustrator where the coordinates start at the bottom.
	  /// </summary>
	//  public void center() {
	//  }


	  /// <summary>
	  /// Set the pivot point for all transformations.
	  /// </summary>
	//  public void pivot(float x, float y) {
	//    px = x;
	//    py = y;
	//  }


	  // . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . .


	  public virtual void colorMode(int mode)
	  {
		colorMode(mode, colorModeX, colorModeY, colorModeZ, colorModeA);
	  }

	  /// <param name="max"> range for all color elements </param>
	  public virtual void colorMode(int mode, float max)
	  {
		colorMode(mode, max, max, max, max);
	  }


	  /// <param name="maxX"> range for the red or hue depending on the current color mode </param>
	  /// <param name="maxY"> range for the green or saturation depending on the current color mode </param>
	  /// <param name="maxZ"> range for the blue or brightness depending on the current color mode </param>
	  public virtual void colorMode(int mode, float maxX, float maxY, float maxZ)
	  {
		colorMode(mode, maxX, maxY, maxZ, colorModeA);
	  }

	/// <param name="maxA"> range for the alpha </param>
	  public virtual void colorMode(int mode, float maxX, float maxY, float maxZ, float maxA)
	  {
		colorMode_Renamed = mode;

		colorModeX = maxX; // still needs to be set for hsb
		colorModeY = maxY;
		colorModeZ = maxZ;
		colorModeA = maxA;

		// if color max values are all 1, then no need to scale
		colorModeScale = ((maxA != 1) || (maxX != maxY) || (maxY != maxZ) || (maxZ != maxA));

		// if color is rgb/0..255 this will make it easier for the
		// red() green() etc functions
		colorModeDefault = (colorMode_Renamed == PConstants_Fields.RGB) && (colorModeA == 255) && (colorModeX == 255) && (colorModeY == 255) && (colorModeZ == 255);
	  }


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

	}
}