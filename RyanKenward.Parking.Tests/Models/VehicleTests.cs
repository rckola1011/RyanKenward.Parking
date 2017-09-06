using System;
using RyanKenward.Parking.Models;
using NUnit.Framework;

namespace RyanKenward.Parking.Tests.Models
{
	[TestFixture]
	public class VehicleTests
	{
		public VehicleTests()
		{
		}

		[Test]
		public void Vehicle_ShouldBeMakeModelSet()
		{
			Vehicle sut = new Vehicle("Honda", "Civic");
			Assert.That(sut.GetMake(), Is.EqualTo("Honda"));
			Assert.That(sut.GetModel(), Is.EqualTo("Civic"));
		}

		[Test]
		public void Vehicle_ShouldBeArgumentExceptionMake()
		{
			Assert.Throws<ArgumentException>(() => new Vehicle("", "Civic"));
		}

		[Test]
		public void Vehicle_ShouldBeArgumentExceptionMakeNull()
		{
			Assert.Throws<ArgumentException>(() => new Vehicle(null, "Civic"));
		}

		[Test]
		public void Vehicle_ShouldBeArgumentExceptionModel()
		{
			Assert.Throws<ArgumentException>(() => new Vehicle("Honda", ""));
		}

		[Test]
		public void Vehicle_ShouldBeArgumentExceptionModelWhitespace()
		{
			Assert.Throws<ArgumentException>(() => new Vehicle("Honda", "      "));
		}
	}
}
