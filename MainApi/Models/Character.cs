using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TauriApiWrapper.Enums;
using TauriApiWrapper.Objects.Responses.Character;

namespace MainApi.Models
{
    public class Character
    {
        public Character() { }

        public Character(CharacterSheet sheet)
        {
            this.Name = sheet.Name;
            this.ActiveSpec = sheet.ActiveSpec;
            this.Class = sheet.Class;
            this.FirstTalentTree = sheet.TreeName0;
            this.SecondTalentTree = sheet.TreeName1;
            this.Items = sheet.CharacterItems.Select(c => new Item(c));
        }

        public string Name { get; set; }

        public Class Class { get; set; }

        public int ActiveSpec { get; set; }

        public string ActiveSpecName
        {
            get
            {
                return ActiveSpec == 0 ? this.FirstTalentTree : this.SecondTalentTree;
            }
        }

        public string FirstTalentTree { get; set; }

        public string SecondTalentTree { get; set; }

        public IEnumerable<Item> Items { get; set; }

        public IEnumerable<ValidationError> ValidationErrors { get; set; }
    }
}