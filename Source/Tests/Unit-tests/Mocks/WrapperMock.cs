namespace RegionOrebroLan.Abstractions.UnitTests.Mocks
{
	public class WrapperMock : Wrapper
	{
		#region Constructors

		public WrapperMock(object wrappedInstance, string wrappedInstanceParameterName) : base(wrappedInstance, wrappedInstanceParameterName) { }

		#endregion
	}

	public class WrapperMock<T> : Wrapper<T>
	{
		#region Constructors

		public WrapperMock(T wrappedInstance, string wrappedInstanceParameterName) : base(wrappedInstance, wrappedInstanceParameterName) { }

		#endregion
	}
}