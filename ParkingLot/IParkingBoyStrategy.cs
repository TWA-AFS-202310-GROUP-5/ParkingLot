namespace ParkingBoy
{
    public interface IParkingBoyStrategy
    {
        string Park(string car);

        string Fetch(string ticket);
    }
}