using System;

namespace Pixygon.Skills {
    [Serializable]
    public class StatAddition {
        public StatNames stat;
        public int addition;
        public bool negative;

        public string Description =>
            negative
                ? addition <= 0
                    ? $"<color=red>{stat.ToString()}: {addition}\n</color>"
                    : $"<color=red>{stat.ToString()}: +{addition}\n</color>"
                : addition <= 0
                    ? $"{stat.ToString()}: {addition}\n"
                    : $"{stat.ToString()}: +{addition}\n";
    }
}