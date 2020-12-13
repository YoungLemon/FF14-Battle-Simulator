using System;
using System.Collections.Generic;
using limax.codec;
using limax.util;
using limax.endpoint;
namespace FFSimulator.client.views
{
	public sealed partial class ViewT : TemporaryView
	{
		private static int __pvid__;
		private readonly limax.util.BitSet __flags__ = new limax.util.BitSet(2);
		private readonly limax.util.MapBitSet<long> __subsFlags__ = new limax.util.MapBitSet<long>(3);
		private ViewChangedType __type__ = ViewChangedType.TOUCH;
		private bool isPlaying = false;
		private string lastMessage = "";
		private Dictionary<long, FFSimulator.client.views.ViewS.__nickname> nickname = new Dictionary<long, FFSimulator.client.views.ViewS.__nickname>();
		private Dictionary<long, FFSimulator.client.views.ViewS.__position> position = new Dictionary<long, FFSimulator.client.views.ViewS.__position>();
		private Dictionary<long, FFSimulator.client.views.ViewS.__hp> hp = new Dictionary<long, FFSimulator.client.views.ViewS.__hp>();
		internal ViewT(ViewContext vc) : base(vc) { __pvid__ = vc.getProviderId(); }
		public void visitIsPlaying(ViewVisitor<bool> v) { lock(this) { if(__flags__.get(0)) v(isPlaying); } }
		public void visitLastMessage(ViewVisitor<string> v) { lock(this) { if(__flags__.get(1)) v(lastMessage); } }
		public void visitNickname(ViewVisitor<IDictionary<long, FFSimulator.client.views.ViewS.__nickname>> v) { lock(this) { v(nickname); } }
		public void visitPosition(ViewVisitor<IDictionary<long, FFSimulator.client.views.ViewS.__position>> v) { lock(this) { v(position); } }
		public void visitHp(ViewVisitor<IDictionary<long, FFSimulator.client.views.ViewS.__hp>> v) { lock(this) { v(hp); } }
		override public short getClassIndex()
		{
			return 1;
		}
		protected sealed override void detach(long sessionid, byte reason) {
			onDetach(sessionid, reason);
			this.nickname.Remove(sessionid);
			this.position.Remove(sessionid);
			this.hp.Remove(sessionid);
			this.__subsFlags__.remove(sessionid);
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
			if (index < 2)
			{
				__o_flags__ = __flags__.get(index);
				__flags__.set(index);
			}
			else
			{
				__o_flags__ = __subsFlags__.get(sessionid, index - 2);
				__subsFlags__.set(sessionid, index - 2);
			}
			ViewChangedType _t_ = __o_flags__ ? ViewChangedType.REPLACE : ViewChangedType.NEW;
			OctetsStream _os_ = OctetsStream.wrap(data);
			switch(index)
			{
				case 2:
				{
					FFSimulator.client.views.ViewS.__nickname _s_;
					if (_t_ == ViewChangedType.REPLACE)
						nickname.TryGetValue(sessionid, out _s_);
					else
						nickname.Add(sessionid, _s_ = new FFSimulator.client.views.ViewS.__nickname());
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
				case 3:
				{
					FFSimulator.client.views.ViewS.__position _s_;
					if (_t_ == ViewChangedType.REPLACE)
						position.TryGetValue(sessionid, out _s_);
					else
						position.Add(sessionid, _s_ = new FFSimulator.client.views.ViewS.__position());
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
				case 4:
				{
					FFSimulator.client.views.ViewS.__hp _s_;
					if (_t_ == ViewChangedType.REPLACE)
						hp.TryGetValue(sessionid, out _s_);
					else
						hp.Add(sessionid, _s_ = new FFSimulator.client.views.ViewS.__hp());
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
			if (index < 2)
			{
				__o_flags__ = __flags__.get(index);
				__flags__.set(index);
			}
			else
			{
				__o_flags__ = __subsFlags__.get(sessionid, index - 2);
				__subsFlags__.set(sessionid, index - 2);
			}
			ViewChangedType _t_ = __o_flags__ ? ViewChangedType.REPLACE : ViewChangedType.NEW;
			OctetsStream _os_ = OctetsStream.wrap(data);
			switch(index)
			{
				case 0:
				{
					bool _n_ = _os_.unmarshal_bool();
					isPlaying = _n_;
					onViewChanged(sessionid, "isPlaying", _n_, _t_);
					break;
				}
				case 1:
				{
					string _n_ = _os_.unmarshal_string();
					lastMessage = _n_;
					onViewChanged(sessionid, "lastMessage", _n_, _t_);
					break;
				}
				case 2:
				{
					FFSimulator.client.views.ViewS.__nickname _n_ = new FFSimulator.client.views.ViewS.__nickname();
					_n_.unmarshal(_os_);
					nickname.Remove(sessionid);
					nickname.Add(sessionid, _n_);
					onViewChanged(sessionid, "nickname", _n_, _t_);
					break;
				}
				case 3:
				{
					FFSimulator.client.views.ViewS.__position _n_ = new FFSimulator.client.views.ViewS.__position();
					_n_.unmarshal(_os_);
					position.Remove(sessionid);
					position.Add(sessionid, _n_);
					onViewChanged(sessionid, "position", _n_, _t_);
					break;
				}
				case 4:
				{
					FFSimulator.client.views.ViewS.__hp _n_ = new FFSimulator.client.views.ViewS.__hp();
					_n_.unmarshal(_os_);
					hp.Remove(sessionid);
					hp.Add(sessionid, _n_);
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
					onViewChanged(sessionid, "isPlaying", isPlaying, type);
					break;
				case 1:
					onViewChanged(sessionid, "lastMessage", lastMessage, type);
					break;
				case 2: {
					FFSimulator.client.views.ViewS.__nickname _o_;
					nickname.TryGetValue(sessionid, out _o_);
					onViewChanged(sessionid, "nickname", _o_, type);
					break;
				}
				case 3: {
					FFSimulator.client.views.ViewS.__position _o_;
					position.TryGetValue(sessionid, out _o_);
					onViewChanged(sessionid, "position", _o_, type);
					break;
				}
				case 4: {
					FFSimulator.client.views.ViewS.__hp _o_;
					hp.TryGetValue(sessionid, out _o_);
					onViewChanged(sessionid, "hp", _o_, type);
					break;
				}
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
			if (index < 2)
				__flags__.clear(index);
			else
				__subsFlags__.clear(sessionid, index - 2);
			onChanged(sessionid, index, ViewChangedType.DELETE);
		}
		static private ISet<string> _fieldnames_ViewT = new HashSet<string>();
		static ViewT()
		{
			_fieldnames_ViewT.Add("isPlaying");
			_fieldnames_ViewT.Add("lastMessage");
			_fieldnames_ViewT.Add("nickname");
			_fieldnames_ViewT.Add("position");
			_fieldnames_ViewT.Add("hp");
		}
		protected override ISet<string> getFieldNames()
		{
			return _fieldnames_ViewT;
		}
		public static ViewT getInstance(int instanceindex) {
			return getInstance(Endpoint.getDefaultEndpointManager(), instanceindex);
		}
		public static ViewT getInstance(EndpointManager manager, int instanceindex) {
			return getInstance(manager, __pvid__, instanceindex);
		}
		public static ViewT getInstance(EndpointManager manager, int pvid, int instanceindex) {
			ViewContext vc = manager.getViewContext(pvid, ViewContextKind.Static);
			return vc == null ? null : (ViewT)vc.findTemporaryView((short)1, instanceindex);
	}
		private sealed class __StartPlaying : View.Control
		{
			public __StartPlaying(View _view_) : base(_view_)
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
				return 1;
			}
			public override byte getControlIndex()
			{
				return 5;
			}
		};
		public void StartPlaying()
		{
			new __StartPlaying(this).send();
		}
		private sealed class __EndPlaying : View.Control
		{
			public __EndPlaying(View _view_) : base(_view_)
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
				return 1;
			}
			public override byte getControlIndex()
			{
				return 6;
			}
		};
		public void EndPlaying()
		{
			new __EndPlaying(this).send();
		}
		private sealed class __SendMessage : View.Control
		{
			public string message;
			public __SendMessage(View _view_, string _message_) : base(_view_)
			{
				this.message = _message_;
			}
			public override OctetsStream marshal(OctetsStream _os_)
			{
				_os_.marshal(this.message);
				return _os_;
			}
			public override OctetsStream unmarshal(OctetsStream _os_)
			{
				this.message = _os_.unmarshal_string();
				return _os_;
			}
			public override short getViewClassIndex()
			{
				return 1;
			}
			public override byte getControlIndex()
			{
				return 7;
			}
		};
		public void SendMessage(string _message_)
		{
			new __SendMessage(this,  _message_).send();
		}
	}
}
