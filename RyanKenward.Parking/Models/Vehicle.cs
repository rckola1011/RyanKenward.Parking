using System;
using RyanKenward.Parking.Models.Interfaces;

namespace RyanKenward.Parking.Models
{
	public class Vehicle : IVehicle
	{
		public Guid Id { get; private set; }
		private String Make { get; set; }
		private String Model { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="T:RyanKenward.Parking.Models.Vehicle"/> class.
		/// </summary>
		/// <param name="make">Make.</param>
		/// <param name="model">Model.</param>
		public Vehicle(String make, String model)
		{
			if (String.IsNullOrWhiteSpace(make))
				throw new ArgumentException("Make cannot be null or empty.");

			if (String.IsNullOrWhiteSpace(model))
				throw new ArgumentException("Model cannot be null or empty.");

			this.Id = new Guid();
			this.Make = make;
			this.Model = model;
		}

		/// <summary>
		/// Gets the make.
		/// </summary>
		/// <returns>The make.</returns>
		public String GetMake()
		{
			return this.Make;
		}

		/// <summary>
		/// Gets the model.
		/// </summary>
		/// <returns>The model.</returns>
		public String GetModel()
		{
			return this.Model;
		}
	}
}
