using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using SedolChecker.Domain.Services;
using SedolChecker.Domain.Models;

namespace Domain.UnitTests
{
    public class SedolValidatorTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("12")]
        [InlineData("123456789")]
        public void SedolValidator_ValidateSedol_Should_Return_Invalid_Length_When_String_Is_Null_Empty_Or_Other_Than_7Characters_Long(string inputString)
        {
            var actual = new SedolValidator().ValidateSedol(inputString);
            var expected = new SedolValidationResult(inputString, false, false, Constants.INPUT_STRING_INVALID_LENGTH);

            AssertValidationResult(expected, actual);
        }

        [Theory]
        [InlineData("1234567")]
        public void SedolValidator_ValidateSedol_Should_Return_Invalid_Checksum_When_String_Checksum_Is_Invalid_And_Is_Not_UserDefined(string inputString)
        {
            var actual = new SedolValidator().ValidateSedol(inputString);
            var expected = new SedolValidationResult(inputString, false, false, Constants.CHECKSUM_INVALID);

            AssertValidationResult(expected, actual);
        }

        [Theory]
        [InlineData("0709954")]
        [InlineData("B0YBKJ7")]
        public void SedolValidator_ValidateSedol_Should_Return_Null_ValidationDetails_When_String_Checksum_Is_Valid_And_Is_Not_UserDefined(string inputString)
        {
            var actual = new SedolValidator().ValidateSedol(inputString);
            var expected = new SedolValidationResult(inputString, true, false, null);

            AssertValidationResult(expected, actual);
        }

        [Theory]
        [InlineData("9123451")]
        [InlineData("9ABCDE8")]
        public void SedolValidator_ValidateSedol_Should_Return_Invalid_Checksum_When_String_Checksum_Is_Invalid_And_Is_UserDefined(string inputString)
        {
            var actual = new SedolValidator().ValidateSedol(inputString);
            var expected = new SedolValidationResult(inputString, false, true, Constants.CHECKSUM_INVALID);

            AssertValidationResult(expected, actual);
        }

        [Theory]
        [InlineData("9123_51")]
        [InlineData("VA.CDE8")]
        public void SedolValidator_ValidateSedol_Should_Return_Invalid_Characters_When_String_Contains_Other_Than_AlphaNumeric_Characters(string inputString)
        {
            var actual = new SedolValidator().ValidateSedol(inputString);
            var expected = new SedolValidationResult(inputString, false, false, Constants.INPUT_STRING_INVALID_CHARACTERS);

            AssertValidationResult(expected, actual);
        }

        [Theory]
        [InlineData("9123458")]
        [InlineData("9ABCDE1")]
        public void SedolValidator_ValidateSedol_Should_Return_Null_ValidationDetails_When_String_Checksum_Is_Valid_And_Is_UserDefined(string inputString)
        {
            var actual = new SedolValidator().ValidateSedol(inputString);
            var expected = new SedolValidationResult(inputString, true, true, null);

            AssertValidationResult(expected, actual);
        }

        private static void AssertValidationResult(ISedolValidationResult expected, ISedolValidationResult actual)
        {
            Assert.Equal(expected.InputString, actual.InputString);
            Assert.Equal(expected.IsValidSedol, actual.IsValidSedol);
            Assert.Equal(expected.IsUserDefined, actual.IsUserDefined);
            Assert.Equal(expected.ValidationDetails, actual.ValidationDetails);
        }
    }
}
