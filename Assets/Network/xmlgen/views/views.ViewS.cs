using System;
using System.Collections.Generic;
using limax.codec;
using limax.util;
using limax.endpoint;
namespace FFSimulator.client.views
{
	public sealed class ViewS : View
	{
		private static int __pvid__;
		private readonly limax.util.BitSet __flags__ = new limax.util.BitSet(3);
		private ViewChangedType __type__ = ViewChangedType.TOUCH;
		private ViewS.__nickname nickname = new ViewS.__nickname();
		private ViewS.__position position = new ViewS.__position();
		private ViewS.__hp hp = new ViewS.__hp();
		internal ViewS(ViewContext vc) : base(vc) { __pvid__ = vc.getProviderId(); }
		public void visitNickname(ViewVisitor<ViewS.__nickname> v) { lock(this) { if(__flags__.get(0)) v(nickname); } }
		public void visitPosition(ViewVisitor<ViewS.__position> v) { lock(this) { if(__flags__.get(1)) v(position); } }
		public void visitHp(ViewVisitor<ViewS.__hp> v) { lock(this) { if(__flags__.get(2)) v(hp); } }
		override public short getClassIndex()
		{
			return 0;
		}
		protected override void onData(long sessionid, byte index, byte field, Octets data, Octets dataremoved)
		{
			if ((index & 0x80) == 0x80)
				onRemoved(sessionid, (byte) (index & 0x7f));
			else if (data.size() == 0)
				onChanged(sessionid, index);
			else if ((field & 0x80) == 0x80)
				onChanged(sessionid, index, data);
			else
				onChanged(sessionid, index, field, data, dataremoved);
		}
		private void onChanged(long sessionid, byte index, byte field, Octets data, Octets dataremoved)
		{
			bool __o_flags__;
			__o_flags__ = __flags__.get(index);
			__flags__.set(index);
			ViewChangedType _t_ = __o_flags__ ? ViewChangedType.REPLACE : ViewChangedType.NEW;
			OctetsStream _os_ = OctetsStream.wrap(data);
			switch(index)
			{
				case 0:
				{
					__nickname _s_ = _t_ == ViewChangedType.REPLACE ? nickname : (nickname = new __nickname());
					switch(field)
					{
						case 0:
						{
							_s_.nickname = _os_.unmarshal_string();
							break;
						}
					}
					__type__ = _t_;
					break;
				}
				case 1:
				{
					__position _s_ = _t_ == ViewChangedType.REPLACE ? position : (position = new __position());
					switch(field)
					{
						case 0:
						{
							_os_.unmarshal(_s_.position);
							break;
						}
					}
					__type__ = _t_;
					break;
				}
				case 2:
				{
					__hp _s_ = _t_ == ViewChangedType.REPLACE ? hp : (hp = new __hp());
					switch(field)
					{
						case 0:
						{
							_s_.hp = _os_.unmarshal_int();
							break;
						}
					}
					__type__ = _t_;
					break;
				}
				default:
					throw new Exception( "view \"" + this + "\" mismatch bind index = \"" + index + "\"");
			}
		}
		private void onChanged(long sessionid, byte index, Octets data)
		{
			bool __o_flags__;
			__o_flags__ = __flags__.get(index);
			__flags__.set(index);
			ViewChangedType _t_ = __o_flags__ ? ViewChangedType.REPLACE : ViewChangedType.NEW;
			OctetsStream _os_ = OctetsStream.wrap(data);
			switch(index)
			{
				case 0:
				{
					__nickname _n_ = new __nickname();
					_n_.unmarshal(_os_);
					nickname = _n_;
					onViewChanged(sessionid, "nickname", _n_, _t_);
					break;
				}
				case 1:
				{
					__position _n_ = new __position();
					_n_.unmarshal(_os_);
					position = _n_;
					onViewChanged(sessionid, "position", _n_, _t_);
					break;
				}
				case 2:
				{
					__hp _n_ = new __hp();
					_n_.unmarshal(_os_);
					hp = _n_;
					onViewChanged(sessionid, "hp", _n_, _t_);
					break;
				}
				default:
					throw new Exception( "view \"" + this + "\" lost var index = \"" + index + "\"");
			}
		}
		private void onChanged(long sessionid, byte index, ViewChangedType type)
		{
			switch(index)
			{
				case 0:
					onViewChanged(sessionid, "nickname", nickname, type);
					break;
				case 1:
					onViewChanged(sessionid, "position", position, type);
					break;
				case 2:
					onViewChanged(sessionid, "hp", hp, type);
					break;
				default:
					throw new Exception( "view \"" + this + "\" lost var index = \"" + index + "\"");
			}
		}
		private void onChanged(long sessionid, byte index)
		{
			onChanged(sessionid, index, __type__);
			__type__ = ViewChangedType.TOUCH;
		}
		private void onRemoved(long sessionid, byte index) {
			__flags__.clear(index);
			onChanged(sessionid, index, ViewChangedType.DELETE);
		}
		static private ISet<string> _fieldnames_ViewS = new HashSet<string>();
		static ViewS()
		{
			_fieldnames_ViewS.Add("nickname");
			_fieldnames_ViewS.Add("position");
			_fieldnames_ViewS.Add("hp");
		}
		protected override ISet<string> getFieldNames()
		{
			return _fieldnames_ViewS;
		}
		public static ViewS getInstance() {
			return getInstance(Endpoint.getDefaultEndpointManager());
		}
		public static ViewS getInstance(EndpointManager manager) {
			return getInstance(manager, __pvid__);
		}
		public static ViewS getInstance(EndpointManager manager, int pvid) {
			ViewContext vc = manager.getViewContext(pvid, ViewContextKind.Static);
			return vc == null ? null : (ViewS)vc.getSessionOrGlobalView((short)0);
		}
		public sealed class __nickname
		{
			public string nickname;
			public __nickname()
			{
				nickname = "";
			}
			public OctetsStream marshal(OctetsStream _os_)
			{
				_os_.marshal(this.nickname);
				return _os_;
			}
			public OctetsStream unmarshal(OctetsStream _os_)
			{
				this.nickname = _os_.unmarshal_string();
				return _os_;
			}
			public override bool Equals(object __o1__)
			{
				if(__o1__ == this)
					return true;
				if(__o1__.GetType() != this.GetType())
					return false;
				__nickname __o__ = (__nickname)__o1__;
				if (!Utils.equals(this.nickname, __o__.nickname))
					return false;
				return true;
			}
			public override int GetHashCode()
			{
				int __h__ = 0;
				__h__ += __h__ * 31 + this.nickname.GetHashCode();
				return __h__;
			}
		}
		public sealed class __position
		{
			public xbean.Position2D position;
			public __position()
			{
				position = new xbean.Position2D();			}
			public OctetsStream marshal(OctetsStream _os_)
			{
				_os_.marshal(this.position);
				return _os_;
			}
			public OctetsStream unmarshal(OctetsStream _os_)
			{
				_os_.unmarshal(this.position);
				return _os_;
			}
			public override bool Equals(object __o1__)
			{
				if(__o1__ == this)
					return true;
				if(__o1__.GetType() != this.GetType())
					return false;
				__position __o__ = (__position)__o1__;
				if (!Utils.equals(this.position, __o__.position))
					return false;
				return true;
			}
			public override int GetHashCode()
			{
				int __h__ = 0;
				__h__ += __h__ * 31 + this.position.GetHashCode();
				return __h__;
			}
		}
		public sealed class __hp
		{
			public int hp;
			public __hp()
			{
				hp = 0;
			}
			public OctetsStream marshal(OctetsStream _os_)
			{
				_os_.marshal(this.hp);
				return _os_;
			}
			public OctetsStream unmarshal(OctetsStream _os_)
			{
				this.hp = _os_.unmarshal_int();
				return _os_;
			}
			public override bool Equals(object __o1__)
			{
				if(__o1__ == this)
					return true;
				if(__o1__.GetType() != this.GetType())
					return false;
				__hp __o__ = (__hp)__o1__;
				if (!Utils.equals(this.hp, __o__.hp))
					return false;
				return true;
			}
			public override int GetHashCode()
			{
				int __h__ = 0;
				__h__ += __h__ * 31 + this.hp.GetHashCode();
				return __h__;
			}
		}
		private sealed class __SetNickname : View.Control
		{
			public string nickname;
			public __SetNickname(View _view_, string _nickname_) : base(_view_)
			{
				this.nickname = _nickname_;
			}
			public override OctetsStream marshal(OctetsStream _os_)
			{
				_os_.marshal(this.nickname);
				return _os_;
			}
			public override OctetsStream unmarshal(OctetsStream _os_)
			{
				this.nickname = _os_.unmarshal_string();
				return _os_;
			}
			public override short getViewClassIndex()
			{
				return 0;
			}
			public override byte getControlIndex()
			{
				return 3;
			}
		};
		public void SetNickname(string _nickname_)
		{
			new __SetNickname(this,  _nickname_).send();
		}
		private sealed class __SetPosition : View.Control
		{
			public float x;
			public float y;
			public __SetPosition(View _view_, float _x_, float _y_) : base(_view_)
			{
				this.x = _x_;
				this.y = _y_;
			}
			public override OctetsStream marshal(OctetsStream _os_)
			{
				_os_.marshal(this.x);
				_os_.marshal(this.y);
				return _os_;
			}
			public override OctetsStream unmarshal(OctetsStream _os_)
			{
				this.x = _os_.unmarshal_float();
				this.y = _os_.unmarshal_float();
				return _os_;
			}
			public override short getViewClassIndex()
			{
				return 0;
			}
			public override byte getControlIndex()
			{
				return 4;
			}
		};
		public void SetPosition(float _x_, float _y_)
		{
			new __SetPosition(this,  _x_,  _y_).send();
		}
		private sealed class __SetHp : View.Control
		{
			public int new_hp;
			public __SetHp(View _view_, int _new_hp_) : base(_view_)
			{
				this.new_hp = _new_hp_;
			}
			public override OctetsStream marshal(OctetsStream _os_)
			{
				_os_.marshal(this.new_hp);
				return _os_;
			}
			public override OctetsStream unmarshal(OctetsStream _os_)
			{
				this.new_hp = _os_.unmarshal_int();
				return _os_;
			}
			public override short getViewClassIndex()
			{
				return 0;
			}
			public override byte getControlIndex()
			{
				return 5;
			}
		};
		public void SetHp(int _new_hp_)
		{
			new __SetHp(this,  _new_hp_).send();
		}
		private sealed class __JoinRoom : View.Control
		{
			public __JoinRoom(View _view_) : base(_view_)
			{
			}
			public override OctetsStream marshal(OctetsStream _os_)
			{
				return _os_;
			}
			public override OctetsStream unmarshal(OctetsStream _os_)
			{
				return _os_;
			}
			public override short getViewClassIndex()
			{
				return 0;
			}
			public override byte getControlIndex()
			{
				return 6;
			}
		};
		public void JoinRoom()
		{
			new __JoinRoom(this).send();
		}
		private sealed class __LeaveRoom : View.Control
		{
			public byte reason;
			public __LeaveRoom(View _view_, byte _reason_) : base(_view_)
			{
				this.reason = _reason_;
			}
			public override OctetsStream marshal(OctetsStream _os_)
			{
				_os_.marshal(this.reason);
				return _os_;
			}
			public override OctetsStream unmarshal(OctetsStream _os_)
			{
				this.reason = _os_.unmarshal_byte();
				return _os_;
			}
			public override short getViewClassIndex()
			{
				return 0;
			}
			public override byte getControlIndex()
			{
				return 7;
			}
		};
		public void LeaveRoom(byte _reason_)
		{
			new __LeaveRoom(this,  _reason_).send();
		}
	}
}
