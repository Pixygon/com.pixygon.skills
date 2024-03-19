using UnityEngine;

namespace Pixygon.Skills {
    [CreateAssetMenu(menuName = "New GunData", fileName = "Pixygon/New Gun Data")]
    public class GunData : ScriptableObject {
        public int _baseDamage = 2;
        public int _baseBullets;
        public int _baseHits = 1;
        public float _reloadSpeed;
        public float _fireRate = 5f;
        public float _bulletSpeed = 5f;
        public float _bulletKillTime = 3f;
        public float _baseSpread = 10f;
        public float _baseKnockback = 0f;
        public int _baseProjectileNumber = 1;
        public float _baseProjectileSize = .2f;
        public BulletData _bulletData;
    }
}