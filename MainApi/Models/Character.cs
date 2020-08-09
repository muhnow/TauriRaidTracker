using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TauriApiWrapper.Objects.Responses.Character;

namespace MainApi.Models
{
    public class Character
    {
        public CharacterSheet Sheet { get; set; }

        public IEnumerable<ValidationError> ValidationErrors { get; set; }
    }
}