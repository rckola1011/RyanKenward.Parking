using System;
namespace RyanKenward.Parking.Models.Interfaces
{
	public interface ICar
	{
		IParkingSlip GetParkingSlip();
		IParkingLot GetParkingLot();
		IParkingSpace GetParkingSpace();
		void Enter(IParkingLot parkingLot);
		bool Park();
		void Unpark();
		IParkingFee Exit();
	}
}
