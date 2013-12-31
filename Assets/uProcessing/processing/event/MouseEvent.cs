using System;

/* -*- mode: java; c-basic-offset: 2; indent-tabs-mode: nil -*- */

/*
  Part of the Processing project - http://processing.org

  Copyright (c) 2012 The Processing Foundation

  This library is free software; you can redistribute it and/or
  modify it under the terms of the GNU Lesser General Public
  License as published by the Free Software Foundation, version 2.1.

  This library is distributed in the hope that it will be useful,
  but WITHOUT ANY WARRANTY; without even the implied warranty of
  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
  Lesser General Public License for more details.

  You should have received a copy of the GNU Lesser General
  Public License along with this library; if not, write to the
  Free Software Foundation, Inc., 59 Temple Place, Suite 330,
  Boston, MA  02111-1307  USA
*/

namespace processing.@event
{

	//import processing.core.PConstants;
	public class MouseEvent : Event
	{
		public const int PRESS = 1;
		public const int RELEASE = 2;
		public const int CLICK = 3;
		public const int DRAG = 4;
		public const int MOVE = 5;
		public const int ENTER = 6;
		public const int EXIT = 7;
		public const int WHEEL = 8;
		protected internal int x, y;
		protected internal int button;
		//  protected int clickCount;
		//  protected float amount;
		protected internal int count;


		//  public MouseEvent(int x, int y) {
		//    this(null,
		//         System.currentTimeMillis(), PRESSED, 0,
		//         x, y, PConstants.LEFT, 1);
		//  }


		public MouseEvent (object nativeObject, long millis, int action, int modifiers, int x, int y, int button, int count) : base(nativeObject, millis, action, modifiers) //float amount) {  //int clickCount) {
		{
			this.flavor = MOUSE;
			this.x = x;
			this.y = y;
			this.button = button;
			//this.clickCount = clickCount;
			//this.amount = amount;
			this.count = count;
		}

		public virtual int X {
			get {
				return x;
			}
		}

		public virtual int Y {
			get {
				return y;
			}
		}


		/// <summary>
		/// Which button was pressed, either LEFT, CENTER, or RIGHT. </summary>
		public virtual int Button {
			get {
				return button;
			}
		}


		//  public void setButton(int button) {
		//    this.button = button;
		//  }


		/// <summary>
		/// Do not use, getCount() is the correct method. </summary>
		[Obsolete]
		public virtual int ClickCount {
			get {
				//return (int) amount; //clickCount;
				return count;
			}
		}


		/// <summary>
		/// Do not use, getCount() is the correct method. </summary>
		[Obsolete]
		public virtual float Amount {
			get {
				//return amount;
				return count;
			}
		}


		/// <summary>
		/// Number of clicks for mouse button events, or the number of steps (positive
		/// or negative depending on direction) for a mouse wheel event.
		/// Wheel events follow Java (see <a href="http://docs.oracle.com/javase/6/docs/api/java/awt/event/MouseWheelEvent.html#getWheelRotation()">here</a>), so
		/// getAmount() will return "negative values if the mouse wheel was rotated
		/// up or away from the user" and positive values in the other direction.
		/// On Mac OS X, this will be reversed when "natural" scrolling is enabled
		/// in System Preferences &rarr Mouse.
		/// </summary>
		public virtual int Count {
			get {
				return count;
			}
		}


		//  public void setClickCount(int clickCount) {
		//    this.clickCount = clickCount;
		//  }
	}

}