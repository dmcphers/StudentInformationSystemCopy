﻿using MVC_SIS_Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_SIS_UI.Models
{
    public class AddStateVM: IValidatableObject
    {
        public State currentState { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (currentState.StateAbbreviation == "" || currentState.StateAbbreviation == null)
            {
                errors.Add(new ValidationResult("Please enter a State Abbreviation",
                    new[] { "currentState.StateAbbreviation" }));
            }

            if (currentState == null || currentState.StateName == "" || currentState.StateName == null)
            {
                errors.Add(new ValidationResult("Please enter a State Name",
                    new[] { "currentState.StateName" }));
            }

            return errors;
        }
    }
}