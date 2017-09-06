using System;
using RyanKenward.Parking.Models.Interfaces;

namespace RyanKenward.Parking.Models
{
	public class ParkingSpace : IParkingSpace
	{
		public Guid Id { get; private set; }
		private bool IsAvailable { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="T:RyanKenward.Parking.Models.ParkingSpace"/> class.
		/// </summary>
		public ParkingSpace()
		{
			this.Id = Guid.NewGuid();
			this.IsAvailable = true;
		}

		/// <summary>
		/// Gets the is available.
		/// </summary>
		/// <returns><c>true</c>, if is available was gotten, <c>false</c> otherwise.</returns>
		public bool GetIsAvailable()
		{
			return this.IsAvailable;
		}

		/// <summary>
		/// Take this space.
		/// </summary>
		/// <returns>Successful take.</returns>
		public bool Take()
		{
			if (!this.IsAvailable)
				return false;
			//    throw new Exception("Parking space is not available.");
			// Set this space to not available
			this.IsAvailable = false;
			return true;
		}

		/// <summary>
		/// Vacate this space.
		/// </summary>
		public void Vacate()
		{
			// Make this space available again
			this.IsAvailable = true;
		}
	}
}
