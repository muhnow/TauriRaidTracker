using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;
using System.Text;
using MainApi.Services;
using MainApi.Models;
using TauriApiWrapper;

namespace MainApi.Controllers
{
    [Route("api/character")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;
        private readonly ICharacterValidationService _characterValidationService;

        public CharacterController(ICharacterService characterService,
            ICharacterValidationService characterValidationService)
        {
            this._characterService = characterService;
            this._characterValidationService = characterValidationService;
        }

        [HttpPost]
        [Route("")]
        public ActionResult<IEnumerable<Character>> GetCharacters([FromBody] IEnumerable<string> characterNames)
        {
            var characters = this._characterService.GetCharacters(characterNames);

            if (characters.Count() > 0)
            {
                return this.Ok(characters);

                //var characters = this._characterValidationService.ValidateCharacters(characterSheets);

                //return this.Ok(characters);
            }

            return this.Ok();
        }

        [HttpGet]
        [Route("{characterName}")]
        public ActionResult<Character> GetCharacter(string characterName)
        {
            var character = this._characterService.GetCharacter(characterName);

            return this.Ok(character);
        }
    }
}