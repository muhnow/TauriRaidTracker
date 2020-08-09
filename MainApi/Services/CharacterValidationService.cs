using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MainApi.Models;
using TauriApiWrapper.Objects.Responses.Character;

namespace MainApi.Services
{
    public class CharacterValidationService : ICharacterValidationService
    {
        public IEnumerable<Character> ValidateCharacters(IEnumerable<CharacterSheet> characterSheets)
        {
            throw new NotImplementedException();
        }
    }

    public interface ICharacterValidationService
    {
        public IEnumerable<Character> ValidateCharacters(IEnumerable<CharacterSheet> characterSheets);
    }
}