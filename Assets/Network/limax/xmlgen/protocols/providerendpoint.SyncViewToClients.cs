using System;
using System.Collections.Generic;
using limax.codec;
using limax.util;
namespace limax.endpoint.providerendpoint
{
	public sealed partial class SyncViewToClients : limax.net.Protocol
	{
		public static int TYPE;
		override public int getType()
		{
			return TYPE;
		}
		public const int DT_VIEW_DATA = 0;
		public const int DT_TEMPORARY_INIT_DATA = 1;
		public const int DT_TEMPORARY_DATA = 2;
		public const int DT_TEMPORARY_ATTACH = 3;
		public const int DT_TEMPORARY_DETACH = 4;
		public const int DT_TEMPORARY_CLOSE = 5;
		public int providerid;
		public List<long> sessionids;
		public short classindex;
		public int instanceindex;
		public byte synctype;
		public List<limax.providerendpoint.ViewVariableData> vardatas;
		public List<limax.providerendpoint.ViewMemberData> members;
		public string stringdata;
		public SyncViewToClients()
		{
			providerid = 0;
			sessionids = new List<long>();
			classindex = 0;
			instanceindex = 0;
			synctype = 0;
			vardatas = new List<limax.providerendpoint.ViewVariableData>();
			members = new List<limax.providerendpoint.ViewMemberData>();
			stringdata = "";
		}
		public SyncViewToClients(int _providerid_, List<long> _sessionids_, short _classindex_, int _instanceindex_, byte _synctype_, List<limax.providerendpoint.ViewVariableData> _vardatas_, List<limax.providerendpoint.ViewMemberData> _members_, string _stringdata_)
		{
			this.providerid = _providerid_;
			this.sessionids = _sessionids_;
			this.classindex = _classindex_;
			this.instanceindex = _instanceindex_;
			this.synctype = _synctype_;
			this.vardatas = _vardatas_;
			this.members = _members_;
			this.stringdata = _stringdata_;
		}
		public override OctetsStream marshal(OctetsStream _os_)
		{
			_os_.marshal(this.providerid);
			_os_.marshal_size(this.sessionids.Count);
			foreach(var __v__ in this.sessionids)
				_os_.marshal(__v__);
			_os_.marshal(this.classindex);
			_os_.marshal(this.instanceindex);
			_os_.marshal(this.synctype);
			_os_.marshal_size(this.vardatas.Count);
			foreach(var __v__ in this.vardatas)
				_os_.marshal(__v__);
			_os_.marshal_size(this.members.Count);
			foreach(var __v__ in this.members)
				_os_.marshal(__v__);
			_os_.marshal(this.stringdata);
			return _os_;
		}
		public override OctetsStream unmarshal(OctetsStream _os_)
		{
			this.providerid = _os_.unmarshal_int();
			for(int _i_ = _os_.unmarshal_size(); _i_ > 0; --_i_)
			{
				long _v_ = _os_.unmarshal_long();
				this.sessionids.Add(_v_);
			}
			this.classindex = _os_.unmarshal_short();
			this.instanceindex = _os_.unmarshal_int();
			this.synctype = _os_.unmarshal_byte();
			for(int _i_ = _os_.unmarshal_size(); _i_ > 0; --_i_)
			{
				limax.providerendpoint.ViewVariableData _v_ = new limax.providerendpoint.ViewVariableData();
				_v_.unmarshal(_os_);
				this.vardatas.Add(_v_);
			}
			for(int _i_ = _os_.unmarshal_size(); _i_ > 0; --_i_)
			{
				limax.providerendpoint.ViewMemberData _v_ = new limax.providerendpoint.ViewMemberData();
				_v_.unmarshal(_os_);
				this.members.Add(_v_);
			}
			this.stringdata = _os_.unmarshal_string();
			return _os_;
		}
	}
}
