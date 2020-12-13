using System;
using System.Collections.Generic;
using limax.codec;
using limax.util;
namespace xbean
{
	public sealed class Position2D : limax.codec.Marshal
	{
		public float x;
		public float y;
		public Position2D()
		{
			x = 0.0f;
			y = 0.0f;
		}
		public Position2D(float _x_, float _y_)
		{
			this.x = _x_;
			this.y = _y_;
		}
		public OctetsStream marshal(OctetsStream _os_)
		{
			_os_.marshal(this.x);
			_os_.marshal(this.y);
			return _os_;
		}
		public OctetsStream unmarshal(OctetsStream _os_)
		{
			this.x = _os_.unmarshal_float();
			this.y = _os_.unmarshal_float();
			return _os_;
		}
		public override bool Equals(object __o1__)
		{
			if(__o1__ == this)
				return true;
			if(__o1__.GetType() != this.GetType())
				return false;
			Position2D __o__ = (Position2D)__o1__;
			if (!Utils.equals(this.x, __o__.x))
				return false;
			if (!Utils.equals(this.y, __o__.y))
				return false;
			return true;
		}
		public override int GetHashCode()
		{
			int __h__ = 0;
			__h__ += __h__ * 31 + this.x.GetHashCode();
			__h__ += __h__ * 31 + this.y.GetHashCode();
			return __h__;
		}
	}
}
