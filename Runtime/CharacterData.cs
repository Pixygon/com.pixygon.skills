using UnityEngine;

namespace Pixygon.Skills {
    [CreateAssetMenu(menuName = "New CharacterData", fileName = "Pixygon/New Character Data")]
    public class CharacterData : ScriptableObject {
        public string _name;
        public int _baseHp;
        public float _baseSpeed;
        public int _baseDamage;
        public int _baseMagic;
        public float _baseMagnetPower = 3f;
        public float _baseXpGain = 1f;
        public float _baseShieldRespawn = 3f;
        public float _baseKnockbackActivationRate = 10f;
        public float _baseBurnFieldActivationRate = 10f;
    }
}