using System;
using System.Collections.Generic;

namespace RyanKenward.Parking.Models.Interfaces
{
	public interface IParkingLot
	{
		List<IParkingSpace> GetParkingSpaces();
		List<IParkingFee> GetParkingFees();
		List<IParkingSpace> GetAvailableParkingSpaces();
		IParkingFee CalculateParkingFee(IParkingSlip parkingSlip);
	}
}
