using System;
using System.Collections.Generic;
using System.Text;

namespace SedolChecker.Domain.Services
{
    public static class Constants
    {
        public const string INPUT_STRING_INVALID_LENGTH = "Input string was not 7-characters long.";
        public const string INPUT_STRING_INVALID_CHARACTERS = "SEDOL contains invalid characters.";
        public const string CHECKSUM_INVALID = "Checksum digit does not agree with the rest of the input.";
    }
}
