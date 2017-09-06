using System;
using System.Collections.Generic;
using System.Linq;
using RyanKenward.Parking.Models.Interfaces;

namespace RyanKenward.Parking.Models
{
	public class ParkingLot : IParkingLot
	{
		public Guid Id { get; private set; }
		private List<IParkingSpace> ParkingSpaces { get; set; }
		private List<IParkingFee> ParkingFees { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="T:RyanKenward.Parking.Models.ParkingLot"/> class.
		/// </summary>
		/// <param name="parkingSpaces">Parking spaces.</param>
		/// <param name="parkingFees">Parking fees.</param>
		public ParkingLot(List<IParkingSpace> parkingSpaces, List<IParkingFee> parkingFees)
		{
			if (parkingSpaces == null
					|| parkingSpaces.Count() == 0)
				throw new ArgumentException("Parking lot must have parking spaces.");

			this.Id = Guid.NewGuid();
			this.ParkingSpaces = parkingSpaces;
			this.ParkingFees = parkingFees;
		}

		/// <summary>
		/// Gets the parking spaces.
		/// </summary>
		/// <returns>The parking spaces.</returns>
		public List<IParkingSpace> GetParkingSpaces()
		{
			return this.ParkingSpaces;
		}

		/// <summary>
		/// Gets the parking fees.
		/// </summary>
		/// <returns>The parking fees.</returns>
		public List<IParkingFee> GetParkingFees()
		{
			return this.ParkingFees;
		}

		/// <summary>
		/// Gets the available parking spaces.
		/// </summary>
		/// <returns>The available parking spaces.</returns>
		public List<IParkingSpace> GetAvailableParkingSpaces()
		{
			// Use LINQ to return a list of all parking spaces that are available
			return this.ParkingSpaces.Where(space => space.GetIsAvailable()).ToList<IParkingSpace>();
		}

		/// <summary>
		/// Calculates the parking fee.
		/// </summary>
		/// <returns>The parking fee.</returns>
		/// <param name="parkingSlip">Parking slip.</param>
		public IParkingFee CalculateParkingFee(IParkingSlip parkingSlip)
		{
			if (this.ParkingFees != null)
			{
				// Calculate the number of hours the car was parked
				double hoursParked = parkingSlip.GetHoursParked();
				// Loop through the parking lots' fees
				foreach (ParkingFee parkingFee in this.ParkingFees)
				{
					// Does hours parked fall between the parking fee time range?
					if (parkingFee.GetMinTimeInHours() <= hoursParked
							&& parkingFee.GetMaxTimeInHours() > hoursParked)
						return parkingFee;
				}
			}
			// No fees in lot or no fee found
			return new ParkingFee(0, 0, 0);
		}
	}
}
