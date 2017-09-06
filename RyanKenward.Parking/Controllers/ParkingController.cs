using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using RyanKenward.Parking.Models;
using RyanKenward.Parking.Models.Interfaces;

namespace RyanKenward.Parking.Controllers
{
	[RoutePrefix("api/parking")]
	public class ParkingController : ApiController
	{
		/// <summary>
		/// Gets the available parking spaces.
		/// </summary>
		/// <returns>The available parking spaces.</returns>
		/// <param name="parkingLotId">Parking lot identifier.</param>
		[HttpGet, ActionName("spaces")]
		public HttpResponseMessage GetAvailableParkingSpaces(string parkingLotId)
		{
			/*
             * Normally we would query a database for the parkingLotId and call GetAvailableParkingSpaces() on it.
             * But in the interest of time, I set up some test data showing the JSON output of available spaces in a lot as cars park in it.
             */

			// Get available parking spaces
			// Build parking spaces list
			List<IParkingSpace> parkingSpaces = new List<IParkingSpace>();
			parkingSpaces.Add(new ParkingSpace());
			parkingSpaces.Add(new ParkingSpace());
			parkingSpaces.Add(new ParkingSpace());
			// Build parking fee structure
			List<IParkingFee> parkingFees = new List<IParkingFee>();
			parkingFees.Add(new ParkingFee(0, 2, 5));
			parkingFees.Add(new ParkingFee(2, 10, 10));
			parkingFees.Add(new ParkingFee(10, Double.MaxValue, 15));
			// Create parking lot
			IParkingLot parkingLot = new ParkingLot(parkingSpaces, parkingFees);
			// Build a list of parking spaces
			List<int> myAvailableSpaces = new List<int>();
			// Set various parking spaces as taken and add to the list
			List<IParkingSpace> availableSpaces = parkingLot.GetAvailableParkingSpaces();
			myAvailableSpaces.Add(availableSpaces.Count);
			parkingLot.GetParkingSpaces()[0].Take();
			availableSpaces = parkingLot.GetAvailableParkingSpaces();
			myAvailableSpaces.Add(availableSpaces.Count);
			parkingLot.GetParkingSpaces()[1].Take();
			availableSpaces = parkingLot.GetAvailableParkingSpaces();
			myAvailableSpaces.Add(availableSpaces.Count);
			parkingLot.GetParkingSpaces()[0].Vacate();
			availableSpaces = parkingLot.GetAvailableParkingSpaces();
			myAvailableSpaces.Add(availableSpaces.Count);
			parkingLot.GetParkingSpaces()[2].Take();
			availableSpaces = parkingLot.GetAvailableParkingSpaces();
			myAvailableSpaces.Add(availableSpaces.Count);
			parkingLot.GetParkingSpaces()[2].Vacate();
			availableSpaces = parkingLot.GetAvailableParkingSpaces();
			myAvailableSpaces.Add(availableSpaces.Count);
			parkingLot.GetParkingSpaces()[1].Vacate();
			availableSpaces = parkingLot.GetAvailableParkingSpaces();
			myAvailableSpaces.Add(availableSpaces.Count);

			// Create http response (application/json)
			HttpResponseMessage response = Request.CreateResponse<Object>(System.Net.HttpStatusCode.OK, myAvailableSpaces, "application/json");

			// Return http response
			return response;
		}

		/// <summary>
		/// Gets the parking fee.
		/// </summary>
		/// <returns>The parking fee.</returns>
		/// <param name="parkingLotId">Parking lot identifier.</param>
		/// <param name="parkingSlipId">Parking slip identifier.</param>
		[HttpGet, ActionName("fee")]
		public HttpResponseMessage GetParkingFee(string parkingLotId, string parkingSlipId)
		{
			/*
             * Normally we would query a database for the parkingLotId and parkingSlipId then call CalculateParkingFee() on them.
             * But in the interest of time, I set up some test data showing the JSON output of various parking slips with different lengths of time.
             */

			// Get parking fee
			// Build parking spaces list
			List<IParkingSpace> parkingSpaces = new List<IParkingSpace>();
			parkingSpaces.Add(new ParkingSpace());
			parkingSpaces.Add(new ParkingSpace());
			parkingSpaces.Add(new ParkingSpace());
			// Build parking fee structure
			List<IParkingFee> parkingFees = new List<IParkingFee>();
			parkingFees.Add(new ParkingFee(0, 2, 5));
			parkingFees.Add(new ParkingFee(2, 10, 10));
			parkingFees.Add(new ParkingFee(10, Double.MaxValue, 15));
			// Create parking lot
			ParkingLot parkingLot = new ParkingLot(parkingSpaces, parkingFees);
			// Build a list of fees
			List<double> myParkingFees = new List<double>();
			DateTime now = DateTime.UtcNow;
			// Create parking slips with various start times and add to the list
			IParkingSlip parkingSlip = new ParkingSlip(now.AddHours(-1));
			parkingSlip.SetExitDateTime(now);
			myParkingFees.Add(parkingLot.CalculateParkingFee(parkingSlip).GetCost());
			parkingSlip = new ParkingSlip(now.AddHours(-5));
			parkingSlip.SetExitDateTime(now);
			myParkingFees.Add(parkingLot.CalculateParkingFee(parkingSlip).GetCost());
			parkingSlip = new ParkingSlip(now.AddHours(-25));
			parkingSlip.SetExitDateTime(now);
			myParkingFees.Add(parkingLot.CalculateParkingFee(parkingSlip).GetCost());

			// Create http response (application/json)
			HttpResponseMessage response = Request.CreateResponse<Object>(System.Net.HttpStatusCode.OK, myParkingFees, "application/json");

			// Return http response
			return response;
		}
    }
}
