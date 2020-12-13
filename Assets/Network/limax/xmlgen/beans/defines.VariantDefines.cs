using System;
using System.Collections.Generic;
using limax.codec;
using limax.util;
namespace limax.defines
{
	public sealed class VariantDefines : limax.codec.Marshal
	{
		public const int BASE_TYPE_BINARY = 1;
		public const int BASE_TYPE_BOOLEAN = 2;
		public const int BASE_TYPE_BYTE = 3;
		public const int BASE_TYPE_DOUBLE = 4;
		public const int BASE_TYPE_FLOAT = 5;
		public const int BASE_TYPE_INT = 6;
		public const int BASE_TYPE_LIST = 7;
		public const int BASE_TYPE_LONG = 8;
		public const int BASE_TYPE_MAP = 9;
		public const int BASE_TYPE_SET = 10;
		public const int BASE_TYPE_SHORT = 11;
		public const int BASE_TYPE_STRING = 12;
		public const int BASE_TYPE_VECTOR = 13;
		public const int BASE_TYPE_MAX = 32;
		public Dictionary<int, string> namedict;
		public List<limax.defines.VariantBeanDefine> beans;
		public List<limax.defines.VariantViewDefine> views;
		public VariantDefines()
		{
			namedict = new Dictionary<int, string>();
			beans = new List<limax.defines.VariantBeanDefine>();
			views = new List<limax.defines.VariantViewDefine>();
		}
		public VariantDefines(Dictionary<int, string> _namedict_, List<limax.defines.VariantBeanDefine> _beans_, List<limax.defines.VariantViewDefine> _views_)
		{
			this.namedict = _namedict_;
			this.beans = _beans_;
			this.views = _views_;
		}
		public OctetsStream marshal(OctetsStream _os_)
		{
			_os_.marshal_size(this.namedict.Count);
			foreach(var __v__ in this.namedict)
			{
				_os_.marshal(__v__.Key);
				_os_.marshal(__v__.Value);
			}
			_os_.marshal_size(this.beans.Count);
			foreach(var __v__ in this.beans)
				_os_.marshal(__v__);
			_os_.marshal_size(this.views.Count);
			foreach(var __v__ in this.views)
				_os_.marshal(__v__);
			return _os_;
		}
		public OctetsStream unmarshal(OctetsStream _os_)
		{
			for(int _i_ = _os_.unmarshal_size(); _i_ > 0; --_i_)
			{
				int _k_ = _os_.unmarshal_int();
				string _v_ = _os_.unmarshal_string();
				this.namedict[_k_] = _v_;
			}
			for(int _i_ = _os_.unmarshal_size(); _i_ > 0; --_i_)
			{
				limax.defines.VariantBeanDefine _v_ = new limax.defines.VariantBeanDefine();
				_v_.unmarshal(_os_);
				this.beans.Add(_v_);
			}
			for(int _i_ = _os_.unmarshal_size(); _i_ > 0; --_i_)
			{
				limax.defines.VariantViewDefine _v_ = new limax.defines.VariantViewDefine();
				_v_.unmarshal(_os_);
				this.views.Add(_v_);
			}
			return _os_;
		}
		public override bool Equals(object __o1__)
		{
			if(__o1__ == this)
				return true;
			if(__o1__.GetType() != this.GetType())
				return false;
			VariantDefines __o__ = (VariantDefines)__o1__;
			if (!Utils.equals(this.namedict, __o__.namedict))
				return false;
			if (!Utils.equals(this.beans, __o__.beans))
				return false;
			if (!Utils.equals(this.views, __o__.views))
				return false;
			return true;
		}
		public override int GetHashCode()
		{
			int __h__ = 0;
			__h__ += __h__ * 31 + Utils.hashCode(this.namedict);
			__h__ += __h__ * 31 + Utils.hashCode(this.beans);
			__h__ += __h__ * 31 + Utils.hashCode(this.views);
			return __h__;
		}
	}
}
