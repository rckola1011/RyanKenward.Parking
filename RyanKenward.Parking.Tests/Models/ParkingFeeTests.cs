using System;
using RyanKenward.Parking.Models;
using NUnit.Framework;

namespace RyanKenward.Parking.Tests.Models
{
	[TestFixture]
	public class ParkingFeeTests
	{
		public ParkingFeeTests()
		{
		}

		[Test]
		public void ParkingFee_ShouldBeValidMinMaxHoursAndCost()
		{
			ParkingFee sut = new ParkingFee(0, 2, 5);
			Assert.That(sut.GetMinTimeInHours(), Is.EqualTo(0));
			Assert.That(sut.GetMaxTimeInHours(), Is.EqualTo(2));
			Assert.That(sut.GetCost(), Is.EqualTo(5));
		}

		[Test]
		public void ParkingFee_ShouldBeThrowsArgumentExceptionMinTime()
		{
			Assert.Throws<ArgumentException>(() => new ParkingFee(-1, 2, 5));
		}

		[Test]
		public void ParkingFee_ShouldBeThrowsArgumentExceptionMaxTime()
		{
			Assert.Throws<ArgumentException>(() => new ParkingFee(0, -2, 5));
		}

		[Test]
		public void ParkingFee_ShouldBeThrowsArgumentExceptionMinGreaterThanMax()
		{
			Assert.Throws<ArgumentException>(() => new ParkingFee(10, 2, 5));
		}
	}
}
