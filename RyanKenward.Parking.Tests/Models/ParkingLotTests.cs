using System;
using System.Collections.Generic;
using RyanKenward.Parking.Models;
using RyanKenward.Parking.Models.Interfaces;
using NUnit.Framework;

namespace RyanKenward.Parking.Tests.Models
{
	[TestFixture]
	public class ParkingLotTests
	{
		public ParkingLotTests()
		{
		}

		[Test]
		public void ParkingLot_ShouldBeThrowsExceptionParkingSpacesNull()
		{
			Assert.Throws<ArgumentException>(() => new ParkingLot(null, null));
		}

		[Test]
		public void ParkingLot_ShouldBeParkingSpacesAndFeesSet()
		{
			List<IParkingSpace> parkingSpaces = new List<IParkingSpace>();
			parkingSpaces.Add(new ParkingSpace());
			parkingSpaces.Add(new ParkingSpace());
			parkingSpaces.Add(new ParkingSpace());
			List<IParkingFee> parkingFees = new List<IParkingFee>();
			parkingFees.Add(new ParkingFee(0, 2, 5));
			parkingFees.Add(new ParkingFee(2, 10, 10));
			parkingFees.Add(new ParkingFee(10, Double.MaxValue, 15));
			IParkingLot sut = new ParkingLot(parkingSpaces, parkingFees);
			Assert.NotNull(sut.GetParkingSpaces());
			Assert.That(sut.GetParkingSpaces().Count, Is.EqualTo(3));
			Assert.NotNull(sut.GetParkingFees());
			Assert.That(sut.GetParkingFees().Count, Is.EqualTo(3));
		}

		[Test]
		public void GetAvailableParkingSpaces_ShouldBeThree()
		{
			List<IParkingSpace> parkingSpaces = new List<IParkingSpace>();
			parkingSpaces.Add(new ParkingSpace());
			parkingSpaces.Add(new ParkingSpace());
			parkingSpaces.Add(new ParkingSpace());
			List<IParkingFee> parkingFees = new List<IParkingFee>();
			parkingFees.Add(new ParkingFee(0, 2, 5));
			parkingFees.Add(new ParkingFee(2, 10, 10));
			parkingFees.Add(new ParkingFee(10, Double.MaxValue, 15));
			IParkingLot sut = new ParkingLot(parkingSpaces, parkingFees);
			Assert.That(sut.GetAvailableParkingSpaces().Count, Is.EqualTo(3));
		}

		[Test]
		public void GetAvailableParkingSpaces_ShouldBeTwo()
		{
			List<IParkingSpace> parkingSpaces = new List<IParkingSpace>();
			parkingSpaces.Add(new ParkingSpace());
			parkingSpaces.Add(new ParkingSpace());
			parkingSpaces.Add(new ParkingSpace());
			List<IParkingFee> parkingFees = new List<IParkingFee>();
			parkingFees.Add(new ParkingFee(0, 2, 5));
			parkingFees.Add(new ParkingFee(2, 10, 10));
			parkingFees.Add(new ParkingFee(10, Double.MaxValue, 15));
			IParkingLot sut = new ParkingLot(parkingSpaces, parkingFees);
			parkingSpaces[0].Take();
			Assert.That(sut.GetAvailableParkingSpaces().Count, Is.EqualTo(2));
		}

		[Test]
		public void GetAvailableParkingSpaces_ShouldBeDecrementedAndIncrementedDuringParking()
		{
			List<IParkingSpace> parkingSpaces = new List<IParkingSpace>();
			parkingSpaces.Add(new ParkingSpace());
			parkingSpaces.Add(new ParkingSpace());
			parkingSpaces.Add(new ParkingSpace());
			List<IParkingFee> parkingFees = new List<IParkingFee>();
			parkingFees.Add(new ParkingFee(0, 2, 5));
			parkingFees.Add(new ParkingFee(2, 10, 10));
			parkingFees.Add(new ParkingFee(10, Double.MaxValue, 15));
			IParkingLot sut = new ParkingLot(parkingSpaces, parkingFees);

			Car car = new Car("Honda", "Civic");
			car.Enter(sut);
			car.Park();

			Assert.That(sut.GetAvailableParkingSpaces().Count, Is.EqualTo(2));

			car.Unpark();

			Assert.That(sut.GetAvailableParkingSpaces().Count, Is.EqualTo(3));

			car.Park();

			Assert.That(sut.GetAvailableParkingSpaces().Count, Is.EqualTo(2));

			car.Unpark();

			Assert.That(sut.GetAvailableParkingSpaces().Count, Is.EqualTo(3));

			car.GetParkingSlip().SetExitDateTime(DateTime.UtcNow.AddHours(5));
			IParkingFee parkingFee = car.Exit();

			Assert.That(sut.GetAvailableParkingSpaces().Count, Is.EqualTo(3));
		}

		[Test]
		public void GetAvailableParkingSpaces_MultiCar_ShouldBeDecrementedAndIncrementedDuringParking()
		{
			List<IParkingSpace> parkingSpaces = new List<IParkingSpace>();
			parkingSpaces.Add(new ParkingSpace());
			parkingSpaces.Add(new ParkingSpace());
			parkingSpaces.Add(new ParkingSpace());
			List<IParkingFee> parkingFees = new List<IParkingFee>();
			parkingFees.Add(new ParkingFee(0, 2, 5));
			parkingFees.Add(new ParkingFee(2, 10, 10));
			parkingFees.Add(new ParkingFee(10, Double.MaxValue, 15));
			IParkingLot sut = new ParkingLot(parkingSpaces, parkingFees);

			Car car1 = new Car("Honda", "Civic");
			Car car2 = new Car("Porsche", "911");

			car1.Enter(sut);
			car1.Park();

			Assert.That(sut.GetAvailableParkingSpaces().Count, Is.EqualTo(2));

			car2.Enter(sut);
			car2.Park();

			Assert.That(sut.GetAvailableParkingSpaces().Count, Is.EqualTo(1));

			car1.Unpark();

			Assert.That(sut.GetAvailableParkingSpaces().Count, Is.EqualTo(2));

			car2.Unpark();

			Assert.That(sut.GetAvailableParkingSpaces().Count, Is.EqualTo(3));
		}

		[Test]
		public void CalculateParkingFee_ShouldBeFive()
		{
			List<IParkingSpace> parkingSpaces = new List<IParkingSpace>();
			parkingSpaces.Add(new ParkingSpace());
			parkingSpaces.Add(new ParkingSpace());
			parkingSpaces.Add(new ParkingSpace());
			List<IParkingFee> parkingFees = new List<IParkingFee>();
			parkingFees.Add(new ParkingFee(0, 2, 5));
			parkingFees.Add(new ParkingFee(2, 10, 10));
			parkingFees.Add(new ParkingFee(10, Double.MaxValue, 15));
			IParkingLot sut = new ParkingLot(parkingSpaces, parkingFees);
			ParkingSlip parkingSlip = new ParkingSlip(DateTime.UtcNow.AddHours(-1));
			parkingSlip.SetExitDateTime(DateTime.UtcNow);
			Assert.That(sut.CalculateParkingFee(parkingSlip).GetCost(), Is.EqualTo(5));
		}

		[Test]
		public void CalculateParkingFee_ShouldBeTen()
		{
			List<IParkingSpace> parkingSpaces = new List<IParkingSpace>();
			parkingSpaces.Add(new ParkingSpace());
			parkingSpaces.Add(new ParkingSpace());
			parkingSpaces.Add(new ParkingSpace());
			List<IParkingFee> parkingFees = new List<IParkingFee>();
			parkingFees.Add(new ParkingFee(0, 2, 5));
			parkingFees.Add(new ParkingFee(2, 10, 10));
			parkingFees.Add(new ParkingFee(10, Double.MaxValue, 15));
			IParkingLot sut = new ParkingLot(parkingSpaces, parkingFees);
			ParkingSlip parkingSlip = new ParkingSlip(DateTime.UtcNow.AddHours(-5));
			parkingSlip.SetExitDateTime(DateTime.UtcNow);
			Assert.That(sut.CalculateParkingFee(parkingSlip).GetCost(), Is.EqualTo(10));
		}

		[Test]
		public void CalculateParkingFee_ShouldBeFifteen()
		{
			List<IParkingSpace> parkingSpaces = new List<IParkingSpace>();
			parkingSpaces.Add(new ParkingSpace());
			parkingSpaces.Add(new ParkingSpace());
			parkingSpaces.Add(new ParkingSpace());
			List<IParkingFee> parkingFees = new List<IParkingFee>();
			parkingFees.Add(new ParkingFee(0, 2, 5));
			parkingFees.Add(new ParkingFee(2, 10, 10));
			parkingFees.Add(new ParkingFee(10, Double.MaxValue, 15));
			IParkingLot sut = new ParkingLot(parkingSpaces, parkingFees);
			ParkingSlip parkingSlip = new ParkingSlip(DateTime.UtcNow.AddHours(-15));
			parkingSlip.SetExitDateTime(DateTime.UtcNow);
			Assert.That(sut.CalculateParkingFee(parkingSlip).GetCost(), Is.EqualTo(15));
		}

		[Test]
		public void CalculateParkingFee_ShouldBeZero()
		{
			List<IParkingSpace> parkingSpaces = new List<IParkingSpace>();
			parkingSpaces.Add(new ParkingSpace());
			parkingSpaces.Add(new ParkingSpace());
			parkingSpaces.Add(new ParkingSpace());
			List<IParkingFee> parkingFees = new List<IParkingFee>();
			parkingFees.Add(new ParkingFee(2, 4, 5));
			IParkingLot sut = new ParkingLot(parkingSpaces, parkingFees);
			ParkingSlip parkingSlip = new ParkingSlip(DateTime.UtcNow.AddHours(-1));
			parkingSlip.SetExitDateTime(DateTime.UtcNow);
			Assert.That(sut.CalculateParkingFee(parkingSlip).GetCost(), Is.EqualTo(0));
		}
	}
}
