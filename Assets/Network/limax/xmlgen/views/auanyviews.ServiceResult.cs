using System;
using System.Collections.Generic;
using limax.codec;
using limax.util;
using limax.endpoint;
namespace limax.endpoint.auanyviews
{
	public sealed partial class ServiceResult : TemporaryView
	{
		private static int __pvid__;
		private readonly limax.util.BitSet __flags__ = new limax.util.BitSet(1);
		private ViewChangedType __type__ = ViewChangedType.TOUCH;
		private limax.auanyviews.Result result = new limax.auanyviews.Result();
		internal ServiceResult(ViewContext vc) : base(vc) { __pvid__ = vc.getProviderId(); }
		public void visitResult(ViewVisitor<limax.auanyviews.Result> v) { lock(this) { if(__flags__.get(0)) v(result); } }
		override public short getClassIndex()
		{
			return 1;
		}
		protected sealed override void detach(long sessionid, byte reason) {
			onDetach(sessionid, reason);
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
					limax.auanyviews.Result _n_ = new limax.auanyviews.Result();
					_n_.unmarshal(_os_);
					result = _n_;
					onViewChanged(sessionid, "result", _n_, _t_);
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
					onViewChanged(sessionid, "result", result, type);
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
		static private ISet<string> _fieldnames_ServiceResult = new HashSet<string>();
		static ServiceResult()
		{
			_fieldnames_ServiceResult.Add("result");
		}
		protected override ISet<string> getFieldNames()
		{
			return _fieldnames_ServiceResult;
		}
		public static ServiceResult getInstance(int instanceindex) {
			return getInstance(Endpoint.getDefaultEndpointManager(), instanceindex);
		}
		public static ServiceResult getInstance(EndpointManager manager, int instanceindex) {
			return getInstance(manager, __pvid__, instanceindex);
		}
		public static ServiceResult getInstance(EndpointManager manager, int pvid, int instanceindex) {
			ViewContext vc = manager.getViewContext(pvid, ViewContextKind.Static);
			return vc == null ? null : (ServiceResult)vc.findTemporaryView((short)1, instanceindex);
	}
	}
}
