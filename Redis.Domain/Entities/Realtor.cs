using Redis.Infra.CrossCutting.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redis.Domain.Entities
{
    public class Realtor
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }

        protected Realtor()
        {
            this.Id = Guid.NewGuid();
        }

        public Realtor(string name, string phone)
        {
            AssertionConcern.AssertArgumentNotEmpty(name, $"Parameter {nameof(name)} cannot be null or empty");
            AssertionConcern.AssertArgumentNotEmpty(phone, $"Parameter {nameof(phone)} cannot be null or empty");

            this.Id = Guid.NewGuid();
            this.Name = name;
            this.Phone = phone;
        }
    }
}
