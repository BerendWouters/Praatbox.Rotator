using System;
using System.Collections.Generic;
using System.Linq;
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
        public static Group Create(string name, int amountOfMembers)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(name);
            }

            if (amountOfMembers < 2)
            {
                throw new ArgumentException("Expecting at least 2 members");
            }

            var members = new List<Member>();
            for (var i = 0; i < amountOfMembers; i++)
            {
                members.Add(Member.Create());
            }
            return new Group()
            {
                Id = Guid.NewGuid(),
                Name = name,
                Members = members
            };
        }
    }
}