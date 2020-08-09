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
        private readonly ICharacterSheetService _characterSheetService;
        private readonly ICharacterValidationService _characterValidationService;

        public CharacterController(ICharacterSheetService characterSheetService,
            ICharacterValidationService characterValidationService)
        {
            this._characterSheetService = characterSheetService;
            this._characterValidationService = characterValidationService;
        }

        [HttpPost]
        [Route("sheets")]
        public ActionResult<IEnumerable<Character>> GetCharacterSheets([FromBody] IEnumerable<string> characterNames)
        {
            var characterSheets = this._characterSheetService.GetCharacterSheets(characterNames);

            if (characterSheets.Count() > 0)
            {
                var characters = this._characterValidationService.ValidateCharacters(characterSheets);

                return this.Ok(characters);
            }

            return this.Ok();
        }

        [HttpGet]
        [Route("ping")]
        public ActionResult Ping()
        {
            return this.Ok();
        }
    }
}