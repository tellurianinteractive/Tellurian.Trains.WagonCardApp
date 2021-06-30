namespace WagonCardApp.Contract
{
    public class Owner
    {
        public string OwnerName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;

        public static Owner Default => new() { OwnerName = "Anders Andersen", EmailAddress = "anders@andersen.eu", PhoneNumber = "+4512345678" };
    }
}
