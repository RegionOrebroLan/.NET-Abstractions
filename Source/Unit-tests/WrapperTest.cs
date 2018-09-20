using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RegionOrebroLan.Abstractions.UnitTests.Mocks;

namespace RegionOrebroLan.Abstractions.UnitTests
{
	[TestClass]
	public class WrapperTest
	{
		#region Methods

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		[SuppressMessage("Usage", "CA1806:Do not ignore method results")]
		public void Constructor_IfTheWrappedInstanceParameterIsNull_ShouldThrowAnArgumentNullException()
		{
			var argumentNullExceptions = new List<ArgumentNullException>();

			// ReSharper disable ObjectCreationAsStatement

			try
			{
				new WrapperMock(null, null);
			}
			catch(ArgumentNullException argumentNullException)
			{
				if(string.Equals(argumentNullException.ParamName, "wrappedInstance", StringComparison.Ordinal))
					argumentNullExceptions.Add(argumentNullException);
			}

			try
			{
				new WrapperMock<object>(null, null);
			}
			catch(ArgumentNullException argumentNullException)
			{
				if(string.Equals(argumentNullException.ParamName, "wrappedInstance", StringComparison.Ordinal))
					argumentNullExceptions.Add(argumentNullException);
			}

			try
			{
				new WrapperMock(null, string.Empty);
			}
			catch(ArgumentNullException argumentNullException)
			{
				if(argumentNullException.ParamName.Length == 0)
					argumentNullExceptions.Add(argumentNullException);
			}

			try
			{
				new WrapperMock<object>(null, string.Empty);
			}
			catch(ArgumentNullException argumentNullException)
			{
				if(argumentNullException.ParamName.Length == 0)
					argumentNullExceptions.Add(argumentNullException);
			}

			try
			{
				new WrapperMock(null, "test");
			}
			catch(ArgumentNullException argumentNullException)
			{
				if(string.Equals(argumentNullException.ParamName, "test", StringComparison.Ordinal))
					argumentNullExceptions.Add(argumentNullException);
			}

			try
			{
				new WrapperMock<object>(null, "test");
			}
			catch(ArgumentNullException argumentNullException)
			{
				if(string.Equals(argumentNullException.ParamName, "test", StringComparison.Ordinal))
					argumentNullExceptions.Add(argumentNullException);
			}

			// ReSharper restore ObjectCreationAsStatement

			if(argumentNullExceptions.Count == 6)
				throw argumentNullExceptions.First();
		}

		[TestMethod]
		public void Constructor_ShouldSetTheWrappedInstanceProperty()
		{
			var wrappedInstance = new object();

			Assert.IsTrue(ReferenceEquals(wrappedInstance, new WrapperMock(wrappedInstance, nameof(wrappedInstance)).WrappedInstance));
			Assert.IsTrue(ReferenceEquals(wrappedInstance, new WrapperMock<object>(wrappedInstance, nameof(wrappedInstance)).WrappedInstance));
		}

		[TestMethod]
		public void Equals_IfTheObjectParameterIsAWrapperAndTheWrappedInstanceEqualsTheWrappedInstanceOfTheObjectParameter_ShouldReturnTrue()
		{
			var wrappedInstance = 10;

			var firstWrapper = new WrapperMock(wrappedInstance, nameof(wrappedInstance));
			var secondWrapper = new WrapperMock(wrappedInstance, nameof(wrappedInstance));
			Assert.IsTrue(firstWrapper.Equals(secondWrapper));

			var firstGenericWrapper = new WrapperMock<int>(wrappedInstance, nameof(wrappedInstance));
			var secondGenericWrapper = new WrapperMock<int>(wrappedInstance, nameof(wrappedInstance));
			Assert.IsTrue(firstGenericWrapper.Equals(secondGenericWrapper));
		}

		[TestMethod]
		public void GetHashCode_ShouldReturnTheHashCodeOfTheWrappedInstance()
		{
			var wrappedInstance = new object();

			Assert.AreEqual(wrappedInstance.GetHashCode(), new WrapperMock(wrappedInstance, nameof(wrappedInstance)).GetHashCode());
			Assert.AreEqual(wrappedInstance.GetHashCode(), new WrapperMock<object>(wrappedInstance, nameof(wrappedInstance)).GetHashCode());

			const int wrappedInteger = 20;

			Assert.AreEqual(wrappedInteger.GetHashCode(), new WrapperMock(wrappedInteger, nameof(wrappedInteger)).GetHashCode());
			Assert.AreEqual(wrappedInteger.GetHashCode(), new WrapperMock<int>(wrappedInteger, nameof(wrappedInteger)).GetHashCode());
		}

		[TestMethod]
		public void ToString_ShouldCallToStringOfTheWrappedInstance()
		{
			const string value = "Test";

			var wrappedInstanceMock = new Mock<object>();
			wrappedInstanceMock.Setup(instance => instance.ToString()).Returns(value);
			var wrappedInstance = wrappedInstanceMock.Object;

			Assert.AreEqual(value, new WrapperMock(wrappedInstance, nameof(wrappedInstance)).ToString());
			Assert.AreEqual(value, new WrapperMock<object>(wrappedInstance, nameof(wrappedInstance)).ToString());
		}

		#endregion
	}
}