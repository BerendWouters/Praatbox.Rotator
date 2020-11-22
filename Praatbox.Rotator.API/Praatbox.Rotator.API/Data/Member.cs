using System;

namespace Praatbox.Rotator.API.Data
{
    public class Member
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public static Member Create()
        {
            return new Member()
            {
                Id = Guid.NewGuid()
            };
        }
    }
}