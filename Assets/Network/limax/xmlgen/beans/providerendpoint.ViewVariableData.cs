using System;
using System.Collections.Generic;
using limax.codec;
using limax.util;
namespace limax.providerendpoint
{
	public sealed class ViewVariableData : limax.codec.Marshal
	{
		public byte index;
		public byte field;
		public limax.codec.Octets data;
		public limax.codec.Octets dataremoved;
		public ViewVariableData()
		{
			index = 0;
			field = 0;
			data = new limax.codec.Octets();
			dataremoved = new limax.codec.Octets();
		}
		public ViewVariableData(byte _index_, byte _field_, limax.codec.Octets _data_, limax.codec.Octets _dataremoved_)
		{
			this.index = _index_;
			this.field = _field_;
			this.data = _data_;
			this.dataremoved = _dataremoved_;
		}
		public OctetsStream marshal(OctetsStream _os_)
		{
			_os_.marshal(this.index);
			_os_.marshal(this.field);
			_os_.marshal(this.data);
			_os_.marshal(this.dataremoved);
			return _os_;
		}
		public OctetsStream unmarshal(OctetsStream _os_)
		{
			this.index = _os_.unmarshal_byte();
			this.field = _os_.unmarshal_byte();
			this.data = _os_.unmarshal_Octets();
			this.dataremoved = _os_.unmarshal_Octets();
			return _os_;
		}
		public override bool Equals(object __o1__)
		{
			if(__o1__ == this)
				return true;
			if(__o1__.GetType() != this.GetType())
				return false;
			ViewVariableData __o__ = (ViewVariableData)__o1__;
			if (!Utils.equals(this.index, __o__.index))
				return false;
			if (!Utils.equals(this.field, __o__.field))
				return false;
			if (!Utils.equals(this.data, __o__.data))
				return false;
			if (!Utils.equals(this.dataremoved, __o__.dataremoved))
				return false;
			return true;
		}
		public override int GetHashCode()
		{
			int __h__ = 0;
			__h__ += __h__ * 31 + this.index.GetHashCode();
			__h__ += __h__ * 31 + this.field.GetHashCode();
			__h__ += __h__ * 31 + this.data.GetHashCode();
			__h__ += __h__ * 31 + this.dataremoved.GetHashCode();
			return __h__;
		}
	}
}
