using System.Text.Json.Serialization;

namespace Tellurian.WagonCardApp.Shared;

public class Owner
{
    public static Owner Default => new() { OwnerName = "Anders Andersen", EmailAddress = "anders@andersen.eu", PhoneNumber = "+4512345678", ClubName = "MJ-klubben" };

    public string OwnerName { get; set; } = string.Empty;
    public string ClubName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string EmailAddress { get; set; } = string.Empty;

    public override bool Equals(object? obj) => obj is Owner owner && owner.OwnerName == OwnerName && owner.PhoneNumber == PhoneNumber && owner.EmailAddress == EmailAddress && owner.ClubName == ClubName;
    public override int GetHashCode() => HashCode.Combine(OwnerName, PhoneNumber, EmailAddress, ClubName);

    [JsonIgnore]
    public bool IsEmpty => OwnerName == string.Empty;
    [JsonIgnore]
    public bool IsEmptyOrDefault => IsEmpty || Equals(Default);
}
