using System.Collections.Generic;
using System.Linq;
using Pixygon.ID;
using UnityEngine;

namespace Pixygon.Skills {
    public class SkillManager : MonoBehaviour {
        [SerializeField] private IdGroup _skills;
        [SerializeField] private SkillData _emptySkill;
        private List<SkillData> _availableSkills;
        public SkillData[] AvailableSkills { get; private set; }
        public List<SkillData> LearnedSkills { get; set; }

        private SkillData[] _allLevelUpSkills;
        // Category group-ids eligible for the random LEVEL-UP roll. Category 7
        // (Weapons) is intentionally excluded — those are offered by the weaponsmith
        // instead. Serialized so the pool is tunable per game without a package edit.
        [SerializeField] private int[] _levelUpSkillCategories = { 0, 1, 2, 3, 4, 5, 6 };

        private void Awake() {
            var skillList = new List<SkillData>();
            foreach (var category in from category in _skills._categories
                     from id in _levelUpSkillCategories
                     where id == category._groupId
                     select category) {
                skillList.AddRange(category._list.Select(skill => skill as SkillData));
            }

            _allLevelUpSkills = skillList.ToArray();
            LearnedSkills = new List<SkillData>();
        }

        public static List<SkillData> DoSkillScramble(List<SkillData> availableSkills, List<SkillData> learnedSkills) {
            var unlearntSkills = new List<SkillData>();
            foreach (var skill in availableSkills) {
                var skillLearnt = false;
                var hasRequirement = false;
                if (skill._requiredSkills != null) {
                    if (skill._requiredSkills.Length != 0) {
                        foreach (var rSkill in skill._requiredSkills) {
                            if (learnedSkills == null) continue;
                            foreach (var learnedSkill in learnedSkills.Where(learnedSkill =>
                                         rSkill.GetFullID == learnedSkill.GetFullID)) {
                                hasRequirement = true;
                            }
                        }
                    }
                    else
                        hasRequirement = true;
                }
                else
                    hasRequirement = true;

                if (learnedSkills != null) {
                    foreach (var learnedSkill in learnedSkills.Where(learnedSkill =>
                                 skill.GetFullID == learnedSkill.GetFullID)) {
                        skillLearnt = true;
                    }
                }

                if (!skillLearnt && hasRequirement)
                    unlearntSkills.Add(skill);
            }

            return unlearntSkills;
        }

        public void ScrambleSkills() {
            var skills = new List<SkillData>();
            var unlearntSkills = DoSkillScramble(_allLevelUpSkills.ToList(), LearnedSkills);

            for (var i = 0; i < 5; i++) {
                if (unlearntSkills.Count == 0) {
                    skills.Add(_emptySkill);
                }
                else {
                    var x = Random.Range(0, unlearntSkills.Count);
                    skills.Add(unlearntSkills[x]);
                    unlearntSkills.RemoveAt(x);
                }
            }

            AvailableSkills = skills.ToArray();
        }
    }
}