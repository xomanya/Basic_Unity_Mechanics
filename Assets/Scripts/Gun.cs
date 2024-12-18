using System.Collections.Generic;
using UnityEngine;

    public sealed class Gun : Weapon
    {
        [SerializeField] private int _countInClip;
        [SerializeField] private Bullet _bulletPrefab;
        
        private Transform _bulletRoot;
        private Queue<Bullet> _bullets;

        protected override void Start()
        {
            base.Start();
            _bullets = new Queue<Bullet>(_countInClip);
            _bulletRoot = new GameObject("BulletRoot").transform;
            Recharge();
        }

        public override void Fire()
        {
            if (CanShoot == false)
            {
                return;
            }
            
            if (_bullets.TryDequeue(out Bullet bullet))
            {
                bullet.Run(_barrel.forward * Force, _barrel.position);
                LastShootTime = 0.0f;
            }
        }

        public override void Recharge()
        {
            for (int i = 0; i < _countInClip; i++)
            {
                Bullet bullet = Instantiate(_bulletPrefab, _bulletRoot);
                bullet.Sleep();
                _bullets.Enqueue(bullet);
            }
        }

        // private bool TryGetBullet(out Bullet bullet)
        // {
        //     int candidate = -1;
        //     if (_bullets == null)
        //     {
        //         bullet = default;
        //         return false;
        //     }
        //
        //     for (var i = 0; i < _bullets.Length; i++)
        //     {
        //         if (_bullets[i] == null)
        //         {
        //             continue;
        //         }
        //         
        //         if (_bullets[i].IsActive)
        //         {
        //             continue;
        //         }
        //
        //         candidate = i;
        //         break;
        //     }
        //
        //     if (candidate == -1)
        //     {
        //         bullet = default;
        //         return false;
        //     }
        //
        //     bullet = _bullets[candidate];
        //     return true;
        // }
    }
