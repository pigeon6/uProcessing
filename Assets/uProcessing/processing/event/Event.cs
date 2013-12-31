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
	public class Event
	{
		protected internal object nativeObject;
		protected internal long millis;
		protected internal int action;

		// These correspond to the java.awt.Event modifiers (not to be confused with
		// the newer getModifiersEx), though they're not guaranteed to in the future.
		public static readonly int SHIFT = 1 << 0;
		public static readonly int CTRL = 1 << 1;
		public static readonly int META = 1 << 2;
		public static readonly int ALT = 1 << 3;
		protected internal int modifiers;

		// Types of events. As with all constants in Processing, brevity's preferred.
		public const int KEY = 1;
		public const int MOUSE = 2;
		public const int TOUCH = 3;
		protected internal int flavor;

		public Event (object nativeObject, long millis, int action, int modifiers)
		{
			this.nativeObject = nativeObject;
			this.millis = millis;
			this.action = action;
			this.modifiers = modifiers;
		}

		public virtual int Flavor {
			get {
				return flavor;
			}
		}


		/// <summary>
		/// Get the platform-native event object. This might be the java.awt event
		/// on the desktop, though if you're using OpenGL on the desktop it'll be a
		/// NEWT event that JOGL uses. Android events are something else altogether.
		/// Bottom line, use this only if you know what you're doing, and don't make
		/// assumptions about the class type.
		/// </summary>
		public virtual object Native {
			get {
				return nativeObject;
			}
		}


		//  public void setNative(Object nativeObject) {
		//    this.nativeObject = nativeObject;
		//  }


		public virtual long Millis {
			get {
				return millis;
			}
		}


		//  public void setMillis(long millis) {
		//    this.millis = millis;
		//  }


		public virtual int Action {
			get {
				return action;
			}
		}


		//  public void setAction(int action) {
		//    this.action = action;
		//  }


		public virtual int Modifiers {
			get {
				return modifiers;
			}
		}


		//  public void setModifiers(int modifiers) {
		//    this.modifiers = modifiers;
		//  }


		public virtual bool ShiftDown {
			get {
				return (modifiers & SHIFT) != 0;
			}
		}

		public virtual bool ControlDown {
			get {
				return (modifiers & CTRL) != 0;
			}
		}

		public virtual bool MetaDown {
			get {
				return (modifiers & META) != 0;
			}
		}

		public virtual bool AltDown {
			get {
				return (modifiers & ALT) != 0;
			}
		}
	}
}