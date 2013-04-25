using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using StructureMap;

namespace HansKindberg.Web.Mvc.InversionOfControl.StructureMap
{
	[CLSCompliant(false)]
	public class StructureMapDependencyResolver : IDependencyResolver
	{
		#region Fields

		private readonly IContainer _container;

		#endregion

		#region Constructors

		public StructureMapDependencyResolver(IContainer container)
		{
			if(container == null)
				throw new ArgumentNullException("container");

			this._container = container;
		}

		#endregion

		#region Properties

		public virtual bool ThrowExceptionIfConcreteServiceNotFound { get; set; }

		#endregion

		#region Methods

		protected internal virtual object GetConcreteService(Type serviceType)
		{
			try
			{
				// Can't use TryGetInstance here because it won’t create concrete types
				return this._container.GetInstance(serviceType);
			}
			catch(StructureMapException)
			{
				if(this.ThrowExceptionIfConcreteServiceNotFound)
					throw;

				return null;
			}
		}

		protected internal virtual object GetInterfaceService(Type serviceType)
		{
			return this._container.TryGetInstance(serviceType);
		}

		public virtual object GetService(Type serviceType)
		{
			if(serviceType == null)
				throw new ArgumentNullException("serviceType");

			if(serviceType.IsInterface || serviceType.IsAbstract)
				return this.GetInterfaceService(serviceType);

			return this.GetConcreteService(serviceType);
		}

		public virtual IEnumerable<object> GetServices(Type serviceType)
		{
			return this._container.GetAllInstances(serviceType).Cast<object>();
		}

		#endregion
	}
}