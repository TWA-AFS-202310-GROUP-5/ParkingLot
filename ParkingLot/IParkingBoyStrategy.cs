namespace ParkingBoy
{
    public interface IParkingBoyStrategy
    {
        string Park(string car);
        int ReturnIndexOfCarParkedLotOrDefaultZero(string ticket);
        string Fetch(string ticket);
    }
}