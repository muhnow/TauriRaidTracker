using MainApi;
using System;
using System.Collections.Generic;
using System.Linq;
using TauriApiWrapper;
using TauriApiWrapper.Objects.Responses.Character;

namespace MainApi.Services
{
    public class CharacterSheetService : ICharacterSheetService
    {
        public IEnumerable<CharacterSheet> GetCharacterSheets(IEnumerable<string> characterNames)
        {
            List<CharacterSheet> characterSheets = new List<CharacterSheet>();

            using (var characterClient = new CharacterClient(Credentials.ApiKey, Credentials.SecretKey))
            {
                characterNames.ToList().ForEach(name =>
                {
                    var apiResponse = characterClient.GetCharacterSheet(name, TauriApiWrapper.Enums.Realm.Crystalsong);

                    if (apiResponse.IsSuccess)
                    {
                        characterSheets.Add(apiResponse.Response);
                    }
                });
            }

            return characterSheets;
        }
    }

    public interface ICharacterSheetService
    {
        public IEnumerable<CharacterSheet> GetCharacterSheets(IEnumerable<string> characterNames);
    }
}