using System;
namespace RyanKenward.Parking.Models.Interfaces
{
	public interface IParkingFee
	{
		double GetMinTimeInHours();
		double GetMaxTimeInHours();
		double GetCost();
	}
}
