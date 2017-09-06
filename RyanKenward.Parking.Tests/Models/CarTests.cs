using System;
using System.Collections.Generic;
using RyanKenward.Parking.Models;
using RyanKenward.Parking.Models.Interfaces;
using NUnit.Framework;

namespace RyanKenward.Parking.Tests.Models
{
	[TestFixture]
	public class CarTests
	{
		public CarTests()
		{
		}

		[Test]
		public void Car_ShouldBeHondaCivic()
		{
			Car sut = new Car("Honda", "Civic");
			Assert.That(sut.GetMake(), Is.EqualTo("Honda"));
			Assert.That(sut.GetModel(), Is.EqualTo("Civic"));
		}

		[Test]
		public void Enter_ShouldBeThrowsExceptionNullLot()
		{
			Car sut = new Car("Honda", "Civic");
			Assert.Throws<ArgumentException>(() => sut.Enter(null));
		}

		[Test]
		public void Enter_ShouldBeThrowsExceptionLotSet()
		{
			List<IParkingSpace> parkingSpaces = new List<IParkingSpace>();
			parkingSpaces.Add(new ParkingSpace());
			parkingSpaces.Add(new ParkingSpace());
			parkingSpaces.Add(new ParkingSpace());
			List<IParkingFee> parkingFees = new List<IParkingFee>();
			parkingFees.Add(new ParkingFee(0, 2, 5));
			parkingFees.Add(new ParkingFee(2, 10, 10));
			parkingFees.Add(new ParkingFee(10, Double.MaxValue, 15));
			IParkingLot parkingLot = new ParkingLot(parkingSpaces, parkingFees);

			Car sut = new Car("Honda", "Civic");
			sut.Enter(parkingLot);
			Assert.Throws<Exception>(() => sut.Enter(parkingLot));
		}

		[Test]
		public void Enter_ShouldBeParkingLotAndSlipSet()
		{
			List<IParkingSpace> parkingSpaces = new List<IParkingSpace>();
			parkingSpaces.Add(new ParkingSpace());
			parkingSpaces.Add(new ParkingSpace());
			parkingSpaces.Add(new ParkingSpace());
			List<IParkingFee> parkingFees = new List<IParkingFee>();
			parkingFees.Add(new ParkingFee(0, 2, 5));
			parkingFees.Add(new ParkingFee(2, 10, 10));
			parkingFees.Add(new ParkingFee(10, Double.MaxValue, 15));
			IParkingLot parkingLot = new ParkingLot(parkingSpaces, parkingFees);

			Car sut = new Car("Honda", "Civic");
			sut.Enter(parkingLot);
			Assert.That(sut.GetParkingLot(), Is.EqualTo(parkingLot));
			Assert.NotNull(sut.GetParkingSlip());
		}

		[Test]
		public void Park_ShouldBeThrowsExceptionNotInLot()
		{
			Car sut = new Car("Honda", "Civic");
			Assert.Throws<Exception>(() => sut.Park());
		}

		[Test]
		public void Park_ShouldBeParkingSpaceSet()
		{
			List<IParkingSpace> parkingSpaces = new List<IParkingSpace>();
			parkingSpaces.Add(new ParkingSpace());
			parkingSpaces.Add(new ParkingSpace());
			parkingSpaces.Add(new ParkingSpace());
			List<IParkingFee> parkingFees = new List<IParkingFee>();
			parkingFees.Add(new ParkingFee(0, 2, 5));
			parkingFees.Add(new ParkingFee(2, 10, 10));
			parkingFees.Add(new ParkingFee(10, Double.MaxValue, 15));
			IParkingLot parkingLot = new ParkingLot(parkingSpaces, parkingFees);

			Car sut = new Car("Honda", "Civic");
			sut.Enter(parkingLot);
			sut.Park();
			Assert.NotNull(sut.GetParkingSpace());
			Assert.That(parkingLot.GetAvailableParkingSpaces().Count, Is.EqualTo(2));
		}

		[Test]
		public void Park_ParkTwice_ShouldBeParkingSpaceSetBothTimes()
		{
			List<IParkingSpace> parkingSpaces = new List<IParkingSpace>();
			parkingSpaces.Add(new ParkingSpace());
			parkingSpaces.Add(new ParkingSpace());
			parkingSpaces.Add(new ParkingSpace());
			List<IParkingFee> parkingFees = new List<IParkingFee>();
			parkingFees.Add(new ParkingFee(0, 2, 5));
			parkingFees.Add(new ParkingFee(2, 10, 10));
			parkingFees.Add(new ParkingFee(10, Double.MaxValue, 15));
			IParkingLot parkingLot = new ParkingLot(parkingSpaces, parkingFees);

			Car sut = new Car("Honda", "Civic");
			sut.Enter(parkingLot);
			sut.Park();
			Assert.NotNull(sut.GetParkingSpace());
			Assert.That(parkingLot.GetAvailableParkingSpaces().Count, Is.EqualTo(2));

			sut.Unpark();
			Assert.IsNull(sut.GetParkingSpace());
			Assert.That(parkingLot.GetAvailableParkingSpaces().Count, Is.EqualTo(3));

			sut.Park();
			Assert.NotNull(sut.GetParkingSpace());
			Assert.That(parkingLot.GetAvailableParkingSpaces().Count, Is.EqualTo(2));
		}

		[Test]
		public void Unpark_ShouldBeThrowsExceptionNotInLot()
		{
			Car sut = new Car("Honda", "Civic");
			Assert.Throws<Exception>(() => sut.Unpark());
		}

		[Test]
		public void Unpark_ShouldBeThrowsExceptionNotParked()
		{
			List<IParkingSpace> parkingSpaces = new List<IParkingSpace>();
			parkingSpaces.Add(new ParkingSpace());
			parkingSpaces.Add(new ParkingSpace());
			parkingSpaces.Add(new ParkingSpace());
			List<IParkingFee> parkingFees = new List<IParkingFee>();
			parkingFees.Add(new ParkingFee(0, 2, 5));
			parkingFees.Add(new ParkingFee(2, 10, 10));
			parkingFees.Add(new ParkingFee(10, Double.MaxValue, 15));
			IParkingLot parkingLot = new ParkingLot(parkingSpaces, parkingFees);

			Car sut = new Car("Honda", "Civic");
			sut.Enter(parkingLot);
			Assert.Throws<Exception>(() => sut.Unpark());
		}

		[Test]
		public void Unpark_ShouldBeParkingSpaceNull()
		{
			List<IParkingSpace> parkingSpaces = new List<IParkingSpace>();
			parkingSpaces.Add(new ParkingSpace());
			parkingSpaces.Add(new ParkingSpace());
			parkingSpaces.Add(new ParkingSpace());
			List<IParkingFee> parkingFees = new List<IParkingFee>();
			parkingFees.Add(new ParkingFee(0, 2, 5));
			parkingFees.Add(new ParkingFee(2, 10, 10));
			parkingFees.Add(new ParkingFee(10, Double.MaxValue, 15));
			IParkingLot parkingLot = new ParkingLot(parkingSpaces, parkingFees);

			Car sut = new Car("Honda", "Civic");
			sut.Enter(parkingLot);
			sut.Park();
			sut.Unpark();
			Assert.IsNull(sut.GetParkingSpace());
		}

		[Test]
		public void Exit_ShouldBeSlipAndFeeSetAndLotNull()
		{
			List<IParkingSpace> parkingSpaces = new List<IParkingSpace>();
			parkingSpaces.Add(new ParkingSpace());
			parkingSpaces.Add(new ParkingSpace());
			parkingSpaces.Add(new ParkingSpace());
			List<IParkingFee> parkingFees = new List<IParkingFee>();
			parkingFees.Add(new ParkingFee(0, 2, 5));
			parkingFees.Add(new ParkingFee(2, 10, 10));
			parkingFees.Add(new ParkingFee(10, Double.MaxValue, 15));
			IParkingLot parkingLot = new ParkingLot(parkingSpaces, parkingFees);

			Car sut = new Car("Honda", "Civic");
			sut.Enter(parkingLot);
			sut.Park();
			sut.Unpark();
			sut.GetParkingSlip().SetExitDateTime(DateTime.UtcNow.AddHours(5));
			IParkingFee parkingFee = sut.Exit();
			Assert.IsNull(sut.GetParkingLot());
			Assert.IsNull(sut.GetParkingSpace());
			Assert.That(sut.GetParkingSlip().GetExitDateTime(), Is.GreaterThan(DateTime.MinValue));
			Assert.That(parkingFee.GetCost(), Is.EqualTo(10));
		}

		[Test]
		public void Exit_ShouldBeThrowsExceptionNoLot()
		{
			List<IParkingSpace> parkingSpaces = new List<IParkingSpace>();
			parkingSpaces.Add(new ParkingSpace());
			parkingSpaces.Add(new ParkingSpace());
			parkingSpaces.Add(new ParkingSpace());
			List<IParkingFee> parkingFees = new List<IParkingFee>();
			parkingFees.Add(new ParkingFee(0, 2, 5));
			parkingFees.Add(new ParkingFee(2, 10, 10));
			parkingFees.Add(new ParkingFee(10, Double.MaxValue, 15));
			IParkingLot parkingLot = new ParkingLot(parkingSpaces, parkingFees);

			Car sut = new Car("Honda", "Civic");
			Assert.Throws<Exception>(() => sut.Exit());
		}
	}
}
