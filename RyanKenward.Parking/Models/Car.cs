using System;
using System.Collections.Generic;
using RyanKenward.Parking.Models.Interfaces;

namespace RyanKenward.Parking.Models
{
	public class Car : Vehicle, ICar
	{
		public new Guid Id { get; private set; }
		private IParkingSlip ParkingSlip { get; set; }
		private IParkingLot ParkingLot { get; set; }
		private IParkingSpace ParkingSpace { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="T:RyanKenward.Parking.Models.Car"/> class.
		/// </summary>
		/// <param name="make">Make.</param>
		/// <param name="model">Model.</param>
		public Car(String make, String model)
			: base(make, model)
		{
			this.Id = Guid.NewGuid();
		}

		/// <summary>
		/// Gets the parking slip.
		/// </summary>
		/// <returns>The parking slip.</returns>
		public IParkingSlip GetParkingSlip()
		{
			return this.ParkingSlip;
		}

		/// <summary>
		/// Gets the parking lot.
		/// </summary>
		/// <returns>The parking lot.</returns>
		public IParkingLot GetParkingLot()
		{
			return this.ParkingLot;
		}

		/// <summary>
		/// Gets the parking space.
		/// </summary>
		/// <returns>The parking space.</returns>
		public IParkingSpace GetParkingSpace()
		{
			return this.ParkingSpace;
		}

		/// <summary>
		/// Enter the specified parkingLot.
		/// </summary>
		/// <param name="parkingLot">Parking lot.</param>
		public void Enter(IParkingLot parkingLot)
		{
			if (parkingLot == null)
				throw new ArgumentException("Car must enter a valid parking lot.");

			if (this.ParkingLot != null)
				throw new Exception("This car is already in a parking lot.");

			this.ParkingLot = parkingLot;
			// Initialize parking slip with an enter time
			this.ParkingSlip = new ParkingSlip(DateTime.UtcNow);
		}

		/// <summary>
		/// Park this Car.
		/// </summary>
		/// <returns>Successful park.</returns>
		public bool Park()
		{
			if (this.ParkingLot == null)
				throw new Exception("This car needs to enter a parking lot before it can park.");

			List<IParkingSpace> availableParkingSpaces = ParkingLot.GetAvailableParkingSpaces();
			if (availableParkingSpaces.Count == 0)  // Are spaces available?
				return false;
			this.ParkingSpace = availableParkingSpaces[0];  // Take the first available spot
			return this.ParkingSpace.Take();
		}

		/// <summary>
		/// Unpark this Car.
		/// </summary>
		public void Unpark()
		{
			if (this.ParkingLot == null)
				throw new Exception("This car needs to park in a parking lot before it can unpark.");

			if (this.ParkingSpace == null)
				throw new Exception("This car needs to be parked before it can unpark.");

			// Leave the parking space
			this.ParkingSpace.Vacate();
			this.ParkingSpace = null;
		}

		/// <summary>
		/// Exit this parkingLot.
		/// </summary>
		public IParkingFee Exit()
		{
			if (this.ParkingLot == null)
				throw new Exception("This car needs to be in a parking lot before it can exit.");

			// Mark the exit time on the existing parking slip
			this.ParkingSlip.SetExitDateTime(DateTime.UtcNow);
			// See how much this car owes based on time in the lot and the lot's fee structure
			IParkingFee parkingFee = CalculateParkingFee();
			this.ParkingLot = null;
			return parkingFee;
		}

		/// <summary>
		/// Calculates the parking fee.
		/// </summary>
		/// <returns>The parking fee.</returns>
		private IParkingFee CalculateParkingFee()
		{
			IParkingFee parkingFee = this.ParkingLot.CalculateParkingFee(this.ParkingSlip);
			return parkingFee;
		}
	}
}
