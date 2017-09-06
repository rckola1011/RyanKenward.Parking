using System;
namespace RyanKenward.Parking.Models.Interfaces
{
	public interface IParkingSpace
	{
		bool GetIsAvailable();
		bool Take();
		void Vacate();
	}
}
