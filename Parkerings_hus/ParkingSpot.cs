using Parkeringhus;

public class ParkingSpot
{
    public int SpotNumber { get; set; }
    public bool IsOccupied { get; set; }
    public DateTime? OccupiedTime { get; set; }
    public Vehicle OccupyingVehicle { get; set; } 

    public ParkingSpot(int spotNumber)
    {
        SpotNumber = spotNumber;
        IsOccupied = false;
        OccupiedTime = null;
        OccupyingVehicle = null;
    }

    
    public void ParkVehicle(Vehicle vehicle)
    {
        IsOccupied = true;
        OccupyingVehicle = vehicle;
        OccupiedTime = DateTime.Now;
    }

    
    public void VacateSpot()
    {
        IsOccupied = false;
        OccupyingVehicle = null;
        OccupiedTime = null;
    }
}

