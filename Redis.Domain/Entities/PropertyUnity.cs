﻿using Redis.Infra.CrossCutting.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redis.Domain.Entities
{
    public class PropertyUnity
    {
        public Guid Id { get; set; }
        public int PropertyId { get; set; }
        public Property Property { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }

        protected PropertyUnity()
        {
            this.Id = Guid.NewGuid();
        }

        public PropertyUnity(string description, int value)
        {
            AssertionConcern.AssertArgumentNotEmpty(description, $"Parameter {nameof(description)} cannot be empty or null");
            AssertionConcern.AssertArgumentRange(value, 0, double.MaxValue, $"Parameter {nameof(value)} is not in range 0, {double.MaxValue}");
            this.Id = Guid.NewGuid();
            this.Description = description;
            this.Value = value;
        }
    }
}
