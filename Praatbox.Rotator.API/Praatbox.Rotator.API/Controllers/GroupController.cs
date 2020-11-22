using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Praatbox.Rotator.API.Data;
using Praatbox.Rotator.API.DTOs;

namespace Praatbox.Rotator.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly ILogger<GroupController> _logger;

        public GroupController(ILogger<GroupController> logger)
        {
            _logger = logger;
        }
        [HttpPost]
        public GroupDTO CreateGroup([FromBody] CreateGroupDTO createGroup)
        {
            var group = Group.Create(createGroup.Name, createGroup.AmountOfMembers);

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

    public class CreateGroupDTO
    {
        public string Name { get; set; }
        public int AmountOfMembers { get; set; }
    }
}
