using System;

namespace Pixygon.Skills {
    [Serializable]
    public class BulletData {
        public float _bulletKillTime = 3f;
        public int _hits = 1;
        public int _damage;
        public float _knockback;
        public float _speed;
        public bool _fire;
        public bool _earth;
        public bool _water;
        public bool _air;
        public int _bulletRipple;
        public float _projectileSize = .2f;
        public float _explosionChance;

        public BulletData(float bulletKillTime, int damage, int hits, float knockback, float speed, bool fire,
            bool earth, bool water, bool air, int bulletRipple, float projectileSize, float explosionChance) {
            _bulletKillTime = bulletKillTime;
            _damage = damage;
            _hits = hits;
            _knockback = knockback;
            _speed = speed;
            _fire = fire;
            _earth = earth;
            _water = water;
            _air = air;
            _bulletRipple = bulletRipple;
            _projectileSize = projectileSize;
            _explosionChance = explosionChance;
        }

        public BulletData(BulletData bullet) {
            _bulletKillTime = bullet._bulletKillTime;
            _damage = bullet._damage;
            _hits = bullet._hits;
            _knockback = bullet._knockback;
            _speed = bullet._speed;
            _fire = bullet._fire;
            _earth = bullet._earth;
            _water = bullet._water;
            _air = bullet._air;
            _bulletRipple = bullet._bulletRipple;
            _projectileSize = bullet._projectileSize;
            _explosionChance = bullet._explosionChance;
        }
    }
}