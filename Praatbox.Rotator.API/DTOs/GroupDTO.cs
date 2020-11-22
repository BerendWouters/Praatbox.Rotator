using System;
using System.Collections.Generic;

namespace Praatbox.Rotator.API.DTOs
{
    public class GroupDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IReadOnlyList<MemberDTO> Members { get; set; }

        public class MemberDTO
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
        }
    }
}