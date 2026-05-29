using System;
using UnityEngine;

namespace Pixygon.Skills {
    [Serializable]
    public class StatMultiplier {
        public StatNames stat;
        public float multiplier;
        public bool negative;

        // We deliberately avoid the C# `:P` percent format specifier here.
        // `:P` uses CurrentCulture.NumberFormat.PercentSymbol, and on
        // IL2CPP / Mono player builds with stripped globalization data
        // (Unity's default for shipping builds) that symbol can resolve to
        // a non-ASCII codepoint that the project's static TMP font atlases
        // don't contain — rendering as a missing-glyph square in builds
        // while looking fine in the editor. Formatting the percentage as
        // an integer with a literal ASCII '%' avoids the culture lookup
        // entirely; '%' (U+0025) is in every font asset in the project.
        public string Description =>
            negative
                ? (multiplier <= 0
                    ? $"<color=red>{stat.ToString()}: {FormatPercent(multiplier)}\n</color>"
                    : $"<color=red>{stat.ToString()}: +{FormatPercent(multiplier)}\n</color>")
                : multiplier <= 0
                    ? $"{stat.ToString()}: {FormatPercent(multiplier)}\n"
                    : $"{stat.ToString()}: +{FormatPercent(multiplier)}\n";

        /// <summary>
        /// Format a 0..1 ratio as an integer-rounded percentage string with
        /// a literal ASCII '%'. Matches the visual output of {value:P0}
        /// (e.g. 0.2 → "20%") without depending on culture data.
        /// </summary>
        private static string FormatPercent(float value) {
            return Mathf.RoundToInt(value * 100f) + "%";
        }
    }
}
