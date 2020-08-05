using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TauriApiWrapper;
using TauriApiWrapper.Objects;
using TauriApiWrapper.Objects.Responses.Character;
using System.Configuration;

namespace TauriApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public ActionResult<CharacterSheet> GetCharacterClient()
        {
            var secretKey = apiKey;

            CharacterClient characterClient = new CharacterClient(apiKey, secretKey);

            var response = characterClient.GetCharacterSheet("Manao", TauriApiWrapper.Enums.Realm.Evermoon);

            return Ok(response.Response);
        }
    }
}
