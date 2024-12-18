using System.Collections;
using UnityEngine;

    public class HealthController : MonoBehaviour
    {
        [SerializeField] private int _health;
        [SerializeField] private int _lifeTime;

        private AudioSource _audioSource;
        [SerializeField] private AudioClip _damageClip;
        [SerializeField] private AudioClip _deathClip;
        
        private bool _isAlive = true;
        private int _maxHp;

        public int MaxHp
        {
            get
            {
                return _maxHp;
            }
        }

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            _maxHp = _health;
        }

        public bool CanTakeDamage(int damage)
        {
            if (_isAlive == false)
            {
                return false;
            }

            _audioSource.PlayOneShot(_damageClip);
            
            _health -= damage;
            if (_health <= 0)
            {
                _audioSource.PlayOneShot(_deathClip);
                StartCoroutine(Die());
                _isAlive = false;
                return false;
            }

            return true;
        }

        public bool CanAddHealth(int health)
        {
            if (_isAlive == false)
            {
                return false;
            }

            if (_health >= _maxHp)
            {
                return false;
            }

            _health += health;
            return true;
        }

        private IEnumerator Die()
        {
            while (_lifeTime >= 0)
            {
                _lifeTime -= 1;
                yield return new WaitForSeconds(1.0f);
            }
            
            StartCoroutine(Fade());
        }

        private IEnumerator Fade()
        {
            if (TryGetComponent(out Renderer renderer))
            {
                Color color = renderer.material.color;
                for (float alpha = 1.0f; alpha >= 0; alpha -= 0.1f)
                {
                    color.a = alpha;
                    renderer.material.color = color;
                    yield return new WaitForSeconds(0.1f);
                }
            }
            
            Destroy(gameObject);
        }
    }
