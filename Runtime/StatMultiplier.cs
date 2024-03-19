using System;

namespace Pixygon.Skills {
    [Serializable]
    public class StatMultiplier {
        public StatNames stat;
        public float multiplier;
        public bool negative;

        public string Description =>
            negative
                ? (multiplier <= 0
                    ? $"<color=red>{stat.ToString()}: {multiplier:P}\n</color>"
                    : $"<color=red>{stat.ToString()}: +{multiplier:P}\n</color>")
                : multiplier <= 0
                    ? $"{stat.ToString()}: {multiplier:P}\n"
                    : $"{stat.ToString()}: +{multiplier:P}\n";

    }
}