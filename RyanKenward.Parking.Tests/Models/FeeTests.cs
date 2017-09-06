using System;
using RyanKenward.Parking.Models;
using NUnit.Framework;

namespace RyanKenward.Parking.Tests.Models
{
	[TestFixture]
	public class FeeTests
	{
		public FeeTests()
		{
		}

		[Test]
		public void Fee_ShouldBeFive()
		{
			Fee sut = new Fee(5);
			Assert.That(sut.GetCost(), Is.EqualTo(5));
		}

		[Test]
		public void Fee_ShouldBeArgumentExceptionCost()
		{
			Assert.Throws<ArgumentException>(() => new Fee(-5));
		}
	}
}
