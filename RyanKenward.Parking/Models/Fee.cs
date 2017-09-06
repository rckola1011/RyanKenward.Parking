using System;
using RyanKenward.Parking.Models.Interfaces;

namespace RyanKenward.Parking.Models
{
	public class Fee : IFee
	{
		public Guid Id { get; private set; }
		private double Cost { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="T:RyanKenward.Parking.Models.Fee"/> class.
		/// </summary>
		/// <param name="cost">Cost.</param>
		public Fee(double cost)
		{
			if (cost < 0)
				throw new ArgumentException("Fee must be greater than zero.");

			this.Id = Guid.NewGuid();
			this.Cost = cost;
		}

		/// <summary>
		/// Gets the cost.
		/// </summary>
		/// <returns>The cost.</returns>
		public double GetCost()
		{
			return this.Cost;
		}
	}
}
