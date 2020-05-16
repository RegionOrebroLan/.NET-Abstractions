using System;

namespace RegionOrebroLan.Abstractions.Extensions
{
	public static class ObjectExtension
	{
		#region Methods

		public static object Unwrap(this object instance)
		{
			return instance.Unwrap<object, IWrapper>();
		}

		public static T Unwrap<T>(this object instance)
		{
			return instance.Unwrap<T, IWrapper<T>>();
		}

		private static TWrappedInstance Unwrap<TWrappedInstance, TWrapper>(this object instance) where TWrapper : IWrapper
		{
			if(instance == null)
				throw new ArgumentNullException(nameof(instance));

			if(!(instance is TWrapper wrapper))
				throw new ArgumentException($"Can not unwrap instance of type \"{instance.GetType()}\" to \"{typeof(TWrappedInstance)}\". The instance does not implement \"{typeof(TWrapper)}\".", nameof(instance));

			return (TWrappedInstance) wrapper.WrappedInstance;
		}

		#endregion
	}
}