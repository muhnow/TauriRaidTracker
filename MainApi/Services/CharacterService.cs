using MainApi;
using MainApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using TauriApiWrapper;
using TauriApiWrapper.Objects.Responses.Character;

namespace MainApi.Services
{
    public class CharacterService : ICharacterService
    {
        public Character GetCharacter(string characterName)
        {
            Character characterSheet = new Character();

            using (var characterClient = new CharacterClient(Credentials.ApiKey, Credentials.SecretKey))
            {
                var apiResponse = characterClient.GetCharacterSheet(characterName, TauriApiWrapper.Enums.Realm.Crystalsong);

                if (apiResponse.IsSuccess)
                {
                    characterSheet = new Character(apiResponse.Response);
                }
            }

            return characterSheet;
        }

        public IEnumerable<Character> GetCharacters(IEnumerable<string> characterNames)
        {
            List<Character> characterSheets = new List<Character>();

            using (var characterClient = new CharacterClient(Credentials.ApiKey, Credentials.SecretKey))
            {
                characterNames.ToList().ForEach(name =>
                {
                    var apiResponse = characterClient.GetCharacterSheet(name, TauriApiWrapper.Enums.Realm.Crystalsong);

                    if (apiResponse.IsSuccess)
                    {
                        characterSheets.Add(new Character(apiResponse.Response));
                    }
                });
            }

            return characterSheets;
        }
    }

    public interface ICharacterService
    {
        public IEnumerable<Character> GetCharacters(IEnumerable<string> characterNames);

        public Character GetCharacter(string characterName);
    }
}