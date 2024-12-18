using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Music.Scripts
{
    public class AudioManager : MonoBehaviour
    {
        public AudioClip[] music;
        private AudioSource _audioSource;
        private AudioClip _currentClip;

        void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            StartCoroutine(UpdateBackgroundMusic());
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                TryPauseSound();
            }
        }

        private void TryPauseSound()
        {
            if (_audioSource.isPlaying == true)
            {
                _audioSource.Pause();
            }
            else
            {
                _audioSource.Play();
            }
        }

        private IEnumerator UpdateBackgroundMusic()
        {
            if (_currentClip != null)
            {
                yield return new WaitForSeconds(_currentClip.length);
                GenerateRandomMusic();
                PlayRandomBackgroundMusic();
            }
            else
            {
                GenerateRandomMusic();
                PlayRandomBackgroundMusic();
                yield return new WaitForEndOfFrame();
            }
        }

        private void GenerateRandomMusic()
        {
            int randomIndex = Random.Range(0, music.Length);
            _currentClip = music[randomIndex];
        }

        private void PlayRandomBackgroundMusic()
        {
            //_audioSource.volume = 0.4f;
            //_audioSource.loop = true;
            if (_currentClip != null)
            {
                _audioSource.clip = _currentClip;
                _audioSource.Play();
                StartCoroutine(UpdateBackgroundMusic());
            }
        }
    }
}
