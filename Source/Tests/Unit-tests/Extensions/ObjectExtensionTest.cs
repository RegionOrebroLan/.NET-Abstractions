using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegionOrebroLan.Abstractions.Extensions;
using RegionOrebroLan.Abstractions.UnitTests.Mocks;

namespace RegionOrebroLan.Abstractions.UnitTests.Extensions
{
	[TestClass]
	public class ObjectExtensionTest
	{
		#region Methods

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void Unwrap_Generic_IfTheInstanceDoesNotImplementIWrapperT_ShouldThrowAnArgumentException()
		{
			try
			{
				new object().Unwrap<string>();
			}
			catch(ArgumentException argumentException)
			{
				if(string.Equals(argumentException.ParamName, "instance", StringComparison.OrdinalIgnoreCase) && argumentException.Message.StartsWith($"Can not unwrap instance of type \"{typeof(object)}\" to \"{typeof(string)}\". The instance does not implement \"{typeof(IWrapper<string>)}\".", StringComparison.OrdinalIgnoreCase))
					throw;
			}
		}

		[TestMethod]
		public void Unwrap_Generic_IfTheInstanceImplementsIWrapperT_ShouldReturnTheWrappedInstance()
		{
			const string wrappedInstance = "Wrapped instance";

			Assert.AreEqual(wrappedInstance, new WrapperMock<string>(wrappedInstance, nameof(wrappedInstance)).Unwrap());
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void Unwrap_Generic_IfTheInstanceIsNull_ShouldThrowAnArgumentNullException()
		{
			try
			{
				((object) null).Unwrap<string>();
			}
			catch(ArgumentNullException argumentNullException)
			{
				if(string.Equals(argumentNullException.ParamName, "instance", StringComparison.OrdinalIgnoreCase))
					throw;
			}
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void Unwrap_IfTheInstanceDoesNotImplementIWrapper_ShouldThrowAnArgumentException()
		{
			try
			{
				new object().Unwrap();
			}
			catch(ArgumentException argumentException)
			{
				if(string.Equals(argumentException.ParamName, "instance", StringComparison.OrdinalIgnoreCase) && argumentException.Message.StartsWith($"Can not unwrap instance of type \"{typeof(object)}\" to \"{typeof(object)}\". The instance does not implement \"{typeof(IWrapper)}\".", StringComparison.OrdinalIgnoreCase))
					throw;
			}
		}

		[TestMethod]
		public void Unwrap_IfTheInstanceImplementsIWrapper_ShouldReturnTheWrappedInstance()
		{
			const string wrappedInstance = "Wrapped instance";

			Assert.AreEqual(wrappedInstance, new WrapperMock(wrappedInstance, nameof(wrappedInstance)).Unwrap());
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void Unwrap_IfTheInstanceIsNull_ShouldThrowAnArgumentNullException()
		{
			try
			{
				((object) null).Unwrap();
			}
			catch(ArgumentNullException argumentNullException)
			{
				if(string.Equals(argumentNullException.ParamName, "instance", StringComparison.OrdinalIgnoreCase))
					throw;
			}
		}

		#endregion
	}
}