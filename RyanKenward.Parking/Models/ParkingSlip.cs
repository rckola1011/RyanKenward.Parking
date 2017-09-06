using System;
using RyanKenward.Parking.Models.Interfaces;

namespace RyanKenward.Parking.Models
{
	public class ParkingSlip : IParkingSlip
	{
		public Guid Id { get; private set; }
		private DateTime EnterDateTime { get; set; }
		private DateTime ExitDateTime { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="T:RyanKenward.Parking.Models.ParkingSlip"/> class.
		/// </summary>
		/// <param name="enterDateTime">Enter date time.</param>
		public ParkingSlip(DateTime enterDateTime)
		{
			if (enterDateTime == DateTime.MinValue)
				throw new ArgumentException("Enter date time is not valid.");

			this.Id = Guid.NewGuid();
			this.EnterDateTime = enterDateTime;
			this.ExitDateTime = DateTime.MinValue;
		}

		/// <summary>
		/// Gets the enter date time.
		/// </summary>
		/// <returns>The enter date time.</returns>
		public DateTime GetEnterDateTime()
		{
			return this.EnterDateTime;
		}

		/// <summary>
		/// Gets the exit date time.
		/// </summary>
		/// <returns>The exit date time.</returns>
		public DateTime GetExitDateTime()
		{
			return this.ExitDateTime;
		}

		/// <summary>
		/// Sets the exit date time.
		/// </summary>
		/// <param name="exitDateTime">Exit date time.</param>
		public void SetExitDateTime(DateTime exitDateTime)
		{
			if (exitDateTime == DateTime.MinValue)
				throw new ArgumentException("Exit date time is not valid.");
			// Only set the exit time if it has not already been set
			if (this.ExitDateTime == DateTime.MinValue)
				this.ExitDateTime = exitDateTime;
		}

		/// <summary>
		/// Gets the hours parked.
		/// </summary>
		/// <returns>The hours parked.</returns>
		public double GetHoursParked()
		{
			if (this.ExitDateTime == DateTime.MinValue)
				throw new Exception("Exit date time not yet set.");

			// Subtract the dates to get the difference in hours
			double hoursParked = (this.ExitDateTime - this.EnterDateTime).TotalHours;
			return hoursParked;
		}
	}
}
