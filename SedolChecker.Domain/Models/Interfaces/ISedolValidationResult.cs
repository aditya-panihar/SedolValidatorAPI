using System;
using System.Collections.Generic;
using System.Text;

namespace SedolChecker.Domain.Models
{
    public interface ISedolValidationResult
    {
        string? InputString { get; }
        bool IsValidSedol { get; }
        bool IsUserDefined { get; }
        string? ValidationDetails { get; }
    }
}
