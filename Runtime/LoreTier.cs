using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pixygon.Skills {
    /// <summary>
    /// One unlockable lore level on a content asset (enemy / skill / item). Becomes readable once the
    /// player's count for that asset — kills / uses / finds — meets <see cref="_unlockThreshold"/>.
    ///
    /// Lives in the skills package, the lowest common dependency, so every content SO that wants Codex
    /// lore can share one type: SkillData here, plus InventoryItem (com.pixygon.inventory references
    /// skills) and the game's own ActorData. Authored directly on the asset — no separate string-keyed
    /// database to keep in sync.
    /// </summary>
    [Serializable]
    public class LoreTier {
        [Tooltip("Kills / uses / finds required to unlock this tier.")]
        public int _unlockThreshold = 1;

        [Tooltip("Short title for this tier, e.g. 'Common Knowledge', 'Folklore', 'Forbidden Records'.")]
        public string _tierTitle;

        [TextArea(3, 12)]
        [Tooltip("The lore text revealed at this tier.")]
        public string _text;
    }

    /// <summary>Helpers over a list of <see cref="LoreTier"/> as authored on a content asset.</summary>
    public static class LoreTierUtil {
        /// <summary>Index of the highest tier unlocked at <paramref name="count"/>, or -1 if none.</summary>
        public static int HighestUnlockedIndex(IReadOnlyList<LoreTier> tiers, int count) {
            if (tiers == null) return -1;
            var best = -1;
            var bestThreshold = -1;
            for (var i = 0; i < tiers.Count; i++) {
                if (tiers[i] == null) continue;
                if (count >= tiers[i]._unlockThreshold && tiers[i]._unlockThreshold > bestThreshold) {
                    best = i;
                    bestThreshold = tiers[i]._unlockThreshold;
                }
            }
            return best;
        }
    }
}
