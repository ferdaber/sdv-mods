using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackToMapChests
{
    class SortableChest : IComparable<SortableChest>
    {
        public ManagedChest ManagedChest { get; set; }
        public int StackableWithScore { get; set; }
        public int SameCategoryScore { get; set; }
        public int SameIdScore { get; set; }
        public int ExistingAmountScore { get; set; }

        public string Score
        {
            get
            {
                return $"Stackable with: {StackableWithScore}, Same ID: {SameIdScore}, Existing amount: {ExistingAmountScore}, Same category: {SameCategoryScore}";
            }
        }

        public int CompareTo(SortableChest other)
        {
            var stackableWithScore = other.StackableWithScore - StackableWithScore;
            var sameCategoryScore = other.SameCategoryScore - SameCategoryScore;
            var sameIdScore = other.SameIdScore - SameIdScore;
            var existingAmountScore = other.ExistingAmountScore - ExistingAmountScore;
            return stackableWithScore != 0
                ? stackableWithScore
                : sameIdScore != 0
                ? sameIdScore
                : existingAmountScore != 0
                ? existingAmountScore
                : sameCategoryScore;
        }
    }
}
