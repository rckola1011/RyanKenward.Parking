using System;
using RyanKenward.Parking.Models;
using NUnit.Framework;

namespace RyanKenward.Parking.Tests.Models
{
	[TestFixture]
	public class ParkingSlipTests
	{
		public ParkingSlipTests()
		{
		}

		[Test]
		public void ParkingSlip_ShouldBeEnterDateTimeSet()
		{
			DateTime now = DateTime.UtcNow;
			Assert.That(new ParkingSlip(now).GetEnterDateTime(), Is.EqualTo(now));
		}

		[Test]
		public void ParkingSlip_ShouldBeThrowsExceptionInvalidDate()
		{
			Assert.Throws<ArgumentException>(() => new ParkingSlip(DateTime.MinValue));
		}

		[Test]
		public void SetExitDateTime_ShouldBeExpirationDateSet()
		{
			DateTime now = DateTime.UtcNow;
			ParkingSlip sut = new ParkingSlip(now.AddHours(-1));
			sut.SetExitDateTime(now);
			Assert.That(sut.GetExitDateTime(), Is.EqualTo(now));
		}

		[Test]
		public void SetExitDateTime_ShouldBeThrowsExceptionInvalidDate()
		{
			ParkingSlip sut = new ParkingSlip(DateTime.UtcNow.AddHours(-1));
			Assert.Throws<ArgumentException>(() => sut.SetExitDateTime(DateTime.MinValue));
		}

		[Test]
		public void GetHoursParked_ShouldBeTwo()
		{
			DateTime now = DateTime.UtcNow;
			ParkingSlip sut = new ParkingSlip(now.AddHours(-2));
			sut.SetExitDateTime(now);
			Assert.That(sut.GetHoursParked(), Is.EqualTo(2));
		}

		[Test]
		public void GetHoursParked_ShouldBeThrowsExceptionInvalidDate()
		{
			ParkingSlip sut = new ParkingSlip(DateTime.UtcNow.AddHours(-2));
			Assert.Throws<Exception>(() => sut.GetHoursParked());
		}
	}
}
