using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TauriApiWrapper.Objects.Responses.Character;

namespace MainApi.Models
{
    public class Item
    {
        public Item(CharacterItem item)
        {
            this.Name = item.OriginalName;
            this.Ilevel = item.Ilevel;
            this.GemCount = item.Gems.Length;
            this.IsEnchanted = item.ItemEnchant.EnchantID != null;
        }

        public string Name { get; set; }

        public int Ilevel { get; set; }

        public int GemCount { get; set; }

        public bool IsEnchanted { get; set; }
    }
}
