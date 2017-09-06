using System;
using RyanKenward.Parking.Models.Interfaces;

namespace RyanKenward.Parking.Models
{
	public class ParkingFee : Fee, IParkingFee
	{
		public new Guid Id { get; private set; }
		private double MinTimeInHours { get; set; }
		private double MaxTimeInHours { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="T:RyanKenward.Parking.Models.ParkingFee"/> class.
		/// </summary>
		/// <param name="minTimeInHours">Minimum time in hours.</param>
		/// <param name="maxTimeInHours">Max time in hours.</param>
		/// <param name="cost">Cost.</param>
		public ParkingFee(double minTimeInHours, double maxTimeInHours, double cost)
			: base(cost)
		{
			if (minTimeInHours < 0)
				throw new ArgumentException("Min time must be greater than zero.");

			if (maxTimeInHours < 0)
				throw new ArgumentException("Max time must be greater than zero.");

			if (minTimeInHours > maxTimeInHours)
				throw new ArgumentException("Min time cannot be greater than Max time.");

			this.Id = Guid.NewGuid();
			this.MinTimeInHours = minTimeInHours;
			this.MaxTimeInHours = maxTimeInHours;
		}

		/// <summary>
		/// Gets the minimum time in hours.
		/// </summary>
		/// <returns>The minimum time in hours.</returns>
		public double GetMinTimeInHours()
		{
			return this.MinTimeInHours;
		}

		/// <summary>
		/// Gets the max time in hours.
		/// </summary>
		/// <returns>The max time in hours.</returns>
		public double GetMaxTimeInHours()
		{
			return this.MaxTimeInHours;
		}

		/// <summary>
		/// Gets the cost.
		/// </summary>
		/// <returns>The cost.</returns>
		public new double GetCost()
		{
			return base.GetCost();
		}
	}
}
