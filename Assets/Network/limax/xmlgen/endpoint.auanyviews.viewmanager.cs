using System;
using System.Collections.Generic;
using limax.codec;
using limax.util;
using limax.endpoint;
namespace limax.endpoint.auanyviews
{
	public sealed class ViewManager : View.StaticManager
	{
		private readonly int pvid;
		private readonly IDictionary<short, Type> classes;
		private ViewManager(int pvid) {
			this.pvid = pvid;
			IDictionary<short, Type> map = new Dictionary<short,Type>();
			map.Add(0, typeof(limax.endpoint.auanyviews.Service));
			map.Add(1, typeof(limax.endpoint.auanyviews.ServiceResult));
			classes = map;
		}
		public static ViewManager createInstance(int pvid)
		{
			return new ViewManager(pvid);
		}
		public int getProviderId()
		{
			return pvid;
		}
		public IDictionary<short, Type> getClasses()
		{
			return classes;
		}
	}
}
