using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WagonCardApp.Contract
{
    public record Settings
    {
        public string OwnerName { get; init; } = string.Empty;
        public string PhoneNumber { get; init; } = string.Empty;
        public string EmailAddress { get; init; } = string.Empty;
    }
}
