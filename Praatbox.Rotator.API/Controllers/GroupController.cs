using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Praatbox.Rotator.API.Data;
using Praatbox.Rotator.API.DTOs;

namespace Praatbox.Rotator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        [HttpPost]
        public GroupDTO CreateGroup([FromBody] string name)
        {
            var group = Group.Create(name);

            return new GroupDTO()
            {
                Id = group.Id,
                Name = group.Name,
                Members = group.Members.Select(m => new GroupDTO.MemberDTO()
                {
                    Id = m.Id,
                    Name = m.Name
                }).ToList()
            };
        }
    }

    public class Member
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
    }
}
