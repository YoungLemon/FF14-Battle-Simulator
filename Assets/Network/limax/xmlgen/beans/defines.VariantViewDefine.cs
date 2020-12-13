using System;
using System.Collections.Generic;
using limax.codec;
using limax.util;
namespace limax.defines
{
	public sealed class VariantViewDefine : limax.codec.Marshal
	{
		public limax.defines.VariantNameIds name;
		public short clsindex;
		public bool istemp;
		public List<limax.defines.VariantViewVariableDefine> vars;
		public List<limax.defines.VariantViewVariableDefine> subs;
		public List<limax.defines.VariantViewControlDefine> ctrls;
		public VariantViewDefine()
		{
			name = new limax.defines.VariantNameIds();
			clsindex = 0;
			istemp = false;
			vars = new List<limax.defines.VariantViewVariableDefine>();
			subs = new List<limax.defines.VariantViewVariableDefine>();
			ctrls = new List<limax.defines.VariantViewControlDefine>();
		}
		public VariantViewDefine(limax.defines.VariantNameIds _name_, short _clsindex_, bool _istemp_, List<limax.defines.VariantViewVariableDefine> _vars_, List<limax.defines.VariantViewVariableDefine> _subs_, List<limax.defines.VariantViewControlDefine> _ctrls_)
		{
			this.name = _name_;
			this.clsindex = _clsindex_;
			this.istemp = _istemp_;
			this.vars = _vars_;
			this.subs = _subs_;
			this.ctrls = _ctrls_;
		}
		public OctetsStream marshal(OctetsStream _os_)
		{
			_os_.marshal(this.name);
			_os_.marshal(this.clsindex);
			_os_.marshal(this.istemp);
			_os_.marshal_size(this.vars.Count);
			foreach(var __v__ in this.vars)
				_os_.marshal(__v__);
			_os_.marshal_size(this.subs.Count);
			foreach(var __v__ in this.subs)
				_os_.marshal(__v__);
			_os_.marshal_size(this.ctrls.Count);
			foreach(var __v__ in this.ctrls)
				_os_.marshal(__v__);
			return _os_;
		}
		public OctetsStream unmarshal(OctetsStream _os_)
		{
			_os_.unmarshal(this.name);
			this.clsindex = _os_.unmarshal_short();
			this.istemp = _os_.unmarshal_bool();
			for(int _i_ = _os_.unmarshal_size(); _i_ > 0; --_i_)
			{
				limax.defines.VariantViewVariableDefine _v_ = new limax.defines.VariantViewVariableDefine();
				_v_.unmarshal(_os_);
				this.vars.Add(_v_);
			}
			for(int _i_ = _os_.unmarshal_size(); _i_ > 0; --_i_)
			{
				limax.defines.VariantViewVariableDefine _v_ = new limax.defines.VariantViewVariableDefine();
				_v_.unmarshal(_os_);
				this.subs.Add(_v_);
			}
			for(int _i_ = _os_.unmarshal_size(); _i_ > 0; --_i_)
			{
				limax.defines.VariantViewControlDefine _v_ = new limax.defines.VariantViewControlDefine();
				_v_.unmarshal(_os_);
				this.ctrls.Add(_v_);
			}
			return _os_;
		}
		public override bool Equals(object __o1__)
		{
			if(__o1__ == this)
				return true;
			if(__o1__.GetType() != this.GetType())
				return false;
			VariantViewDefine __o__ = (VariantViewDefine)__o1__;
			if (!Utils.equals(this.name, __o__.name))
				return false;
			if (!Utils.equals(this.clsindex, __o__.clsindex))
				return false;
			if (!Utils.equals(this.istemp, __o__.istemp))
				return false;
			if (!Utils.equals(this.vars, __o__.vars))
				return false;
			if (!Utils.equals(this.subs, __o__.subs))
				return false;
			if (!Utils.equals(this.ctrls, __o__.ctrls))
				return false;
			return true;
		}
		public override int GetHashCode()
		{
			int __h__ = 0;
			__h__ += __h__ * 31 + this.name.GetHashCode();
			__h__ += __h__ * 31 + this.clsindex.GetHashCode();
			__h__ += __h__ * 31 + this.istemp.GetHashCode();
			__h__ += __h__ * 31 + Utils.hashCode(this.vars);
			__h__ += __h__ * 31 + Utils.hashCode(this.subs);
			__h__ += __h__ * 31 + Utils.hashCode(this.ctrls);
			return __h__;
		}
	}
}
