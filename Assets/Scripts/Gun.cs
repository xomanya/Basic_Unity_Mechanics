using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]    
public sealed class Gun : Weapon
    {
        [SerializeField] private int _countInClip;
        [SerializeField] private Bullet _bulletPrefab;
        
        private Transform _bulletRoot;
        private Queue<Bullet> _bullets;
        
        private AudioSource _audioSource;
        public AudioClip _shootClip;
        // UI
        public Text patronText;
        private int _patronCount;

        protected override void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            
            base.Start();
            _bullets = new Queue<Bullet>(_countInClip);
            _bulletRoot = new GameObject("BulletRoot").transform;
            Recharge();
            _patronCount = _countInClip;
            PatronCount();
        }

        public override void Fire()
        {
            if (CanShoot == false)
            {
                return;
            }
            
            if (_bullets.TryDequeue(out Bullet bullet))
            {
                _audioSource.PlayOneShot(_shootClip);
                bullet.Run(_barrel.forward * Force, _barrel.position);
                LastShootTime = 0.0f;
                _patronCount -= 1;
                //Debug.Log(_patronCount);
                PatronCount();

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

        private void PatronCount()
        {
            patronText.text = _patronCount.ToString() + " / " + _countInClip.ToString();
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
