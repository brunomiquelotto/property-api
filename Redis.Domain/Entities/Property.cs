using Redis.Infra.CrossCutting.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redis.Domain.Entities
{
    public class Property
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public int Number { get; set; }
        public IEnumerable<PropertyUnity> Unities { get; protected set; }

        protected Property ()
        {
            this.Id = Guid.NewGuid();
        }
        public Property(string description, string address, int number, IEnumerable<PropertyUnity> unities)
        {
            AssertionConcern.AssertArgumentNotEmpty(description, $"Parameter {nameof(description)} cannot be empty or null");
            AssertionConcern.AssertArgumentNotEmpty(address, $"Parameter {nameof(address)} cannot be empty or null");
            AssertionConcern.AssertArgumentRange(number, 0, int.MaxValue, $"Parameter {nameof(number)} is out of range {0}, {int.MaxValue}");
            EnumerableConcern.AssertMinimumLength(unities, 1, $"Parameter {nameof(unities)} need at least 1 item");

            this.Id = Guid.NewGuid();
            this.Description = description;
            this.Address = address;
            this.Number = number;
            this.Unities = unities;
        }

        public void SetUnities(IEnumerable<PropertyUnity> unities)
        {
            EnumerableConcern.AssertMinimumLength(unities, 1, $"Parameter {nameof(unities)} need at least 1 item"); 
            this.Unities = unities;
        }
    }
}
