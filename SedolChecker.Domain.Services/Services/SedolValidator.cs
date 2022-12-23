using SedolChecker.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SedolChecker.Domain.Services
{
    public class SedolValidator : ISedolValidator
    {
        public ISedolValidationResult ValidateSedol(string input)
        {
            var sedol = new Sedol(input);

            var result = new SedolValidationResult
            {
                InputString = input,
                IsUserDefined = false,
                IsValidSedol = false,
                ValidationDetails = null
            };

            if (!sedol.IsValidLength)
            {
                result.ValidationDetails = Constants.INPUT_STRING_INVALID_LENGTH;
                return result;
            }
            if (!sedol.IsAlphaNumeric)
            {
                result.ValidationDetails = Constants.INPUT_STRING_INVALID_CHARACTERS;
                return result;
            }
            if (sedol.IsUserDefined)
            {
                result.IsUserDefined = true;
                if (sedol.HasValidCheckDigit)
                {
                    result.IsValidSedol = true;
                    return result;
                }
                result.ValidationDetails = Constants.CHECKSUM_INVALID;
                return result;
            }

            if (sedol.HasValidCheckDigit)
                result.IsValidSedol = true;
            else
                result.ValidationDetails = Constants.CHECKSUM_INVALID;

            return result;
        }
    }
}
