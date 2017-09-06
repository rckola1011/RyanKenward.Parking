using System;
namespace RyanKenward.Parking.Models.Interfaces
{
	public interface IParkingSlip
	{
		DateTime GetEnterDateTime();
		DateTime GetExitDateTime();
		void SetExitDateTime(DateTime exitDateTime);
		double GetHoursParked();
	}
}
