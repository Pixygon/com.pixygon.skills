using System;
using System.Linq;
using Pixygon.ID;
using UnityEngine;


namespace Pixygon.Skills {
    [CreateAssetMenu(menuName = "New SkillData", fileName = "New SkillData")]
    public class SkillData : IdObject {
        [SerializeField] private string _description;

        public string Title;
        public SpecialSkills _specialSkill;
        public StatMultiplier[] _multipliers;
        public StatAddition[] _additions;
        public Sprite _icon;
        public SkillData[] _requiredSkills;
        public int _rank;
        public bool _hideSkillRank;
        public bool _inYdrast;

        public string Description =>
            $"{_description}\n" + (_hideSkillRank
                ? ""
                : $"{_multipliers.Aggregate("", (current, s) => current + s.Description)}" +
                  $"{_additions.Aggregate("", (current, s) => current + s.Description)}");

    }
}