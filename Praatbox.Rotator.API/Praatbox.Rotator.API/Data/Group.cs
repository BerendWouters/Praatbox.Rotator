using System;
using System.Collections.Generic;
using Praatbox.Rotator.API.Controllers;

namespace Praatbox.Rotator.API.Data
{
    public class Group
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public IReadOnlyList<Member> Members { get; private set; }

        private Group()
        {
            Members = new List<Member>();
        }
        public static Group Create(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(name);
            }
            return new Group()
            {
                Id = Guid.NewGuid(),
                Name = name
            };
        }
    }
}