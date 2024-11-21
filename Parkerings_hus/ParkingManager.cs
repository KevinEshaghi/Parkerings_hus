using Parkeringhus;

public class ParkingManager
{
    private ParkingHouse _parkingHouse;

    public ParkingManager(ParkingHouse parkingHouse)
    {
        _parkingHouse = parkingHouse;
    }   
    public bool AssignSpotToVehicle(Vehicle vehicle)
    {
        int requiredSpots = vehicle switch
        {
            Car => 1,        
            Bus => 2,        
            Motorcycle => 1, 
            _ => 0
        };

        
        int consecutiveFreeSpots = 0;
        for (int i = 0; i < _parkingHouse.ParkingSpots.Count; i++)
        {
            if (!_parkingHouse.ParkingSpots[i].IsOccupied)
            {
                consecutiveFreeSpots++;
                if (consecutiveFreeSpots == requiredSpots)
                {
                    
                    for (int j = i - consecutiveFreeSpots + 1; j <= i; j++)
                    {
                        _parkingHouse.ParkingSpots[j].ParkVehicle(vehicle);
                    }
                    Console.WriteLine($"{vehicle.GetType().Name} parkerade på platser {i - consecutiveFreeSpots + 2} till {i + 1}.");
                    return true;
                }
            }
            else
            {
                consecutiveFreeSpots = 0;
            }
        }
        Console.WriteLine("Det finns inte tillräckligt med lediga parkeringsplatser.");
        return false;
    }   
    public void ShowParkingHouseStatus()
    {
        foreach (var spot in _parkingHouse.ParkingSpots)
        {
            if (spot.IsOccupied)
            {
                var vehicle = spot.OccupyingVehicle;
                Console.WriteLine($"Parkeringsplats {spot.SpotNumber} är upptagen av {vehicle.GetType().Name} ({vehicle.LicensePlate}), parkerad sedan {spot.OccupiedTime.Value.ToShortTimeString()}.");
            }
            else
            {
                Console.WriteLine($"Parkeringsplats {spot.SpotNumber} är ledig.");
            }
        }
    } 
    public void EndParking(int spotNumber)
    {
        var spot = _parkingHouse.ParkingSpots.FirstOrDefault(s => s.SpotNumber == spotNumber);
        if (spot != null && spot.IsOccupied)
        {
            spot.VacateSpot();
            Console.WriteLine($"Parkeringsplats {spotNumber} har nu blivit ledig.");
        }
        else
        {
            Console.WriteLine("Platsen är redan ledig.");
        }
    }
}