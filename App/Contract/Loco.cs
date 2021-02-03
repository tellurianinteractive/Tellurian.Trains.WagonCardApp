using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WagonCardApp.Contract
{
    public record Loco
    {
        public string OperantorSignature { get; init; } = string.Empty;
        public string VehicleClass { get; init; } = string.Empty;
        public string VehicleNumber { get; init; } = string.Empty;
    }
}
