using SedolChecker.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SedolChecker.Domain.Services
{
    public interface ISedolValidator
    {
        ISedolValidationResult ValidateSedol(string input);
    }
}
