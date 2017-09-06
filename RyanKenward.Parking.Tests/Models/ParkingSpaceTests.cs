using System;
using RyanKenward.Parking.Models;
using NUnit.Framework;

namespace RyanKenward.Parking.Tests.Models
{
	[TestFixture]
	public class ParkingSpaceTests
	{
		public ParkingSpaceTests()
		{
		}

		[Test]
		public void ParkingSpace_ShouldBeAvailable()
		{
			Assert.That(new ParkingSpace().GetIsAvailable(), Is.EqualTo(true));
		}

		[Test]
		public void Take_ShouldBeTrue()
		{
			ParkingSpace sut = new ParkingSpace();
			Assert.That(sut.Take(), Is.EqualTo(true));
		}

		[Test]
		public void Take_ShouldBeNotAvailable()
		{
			ParkingSpace sut = new ParkingSpace();
			sut.Take();
			Assert.That(sut.GetIsAvailable(), Is.EqualTo(false));
		}

		[Test]
		public void Take_ShouldBeFalse()
		{
			ParkingSpace sut = new ParkingSpace();
			sut.Take();
			Assert.That(sut.Take(), Is.EqualTo(false));
		}

		[Test]
		public void Vacate_ShouldBeTrue()
		{
			ParkingSpace sut = new ParkingSpace();
			sut.Vacate();
			Assert.That(sut.GetIsAvailable(), Is.EqualTo(true));
		}

		[Test]
		public void TakeVacate_ShouldBeTrue()
		{
			ParkingSpace sut = new ParkingSpace();
			sut.Take();
			sut.Vacate();
			Assert.That(sut.GetIsAvailable(), Is.EqualTo(true));
		}
	}
}
