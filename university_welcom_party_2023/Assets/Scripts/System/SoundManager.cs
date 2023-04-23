using UnityEngine;

namespace System
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager SoundManagerInstance { get; private set; }
        [SerializeField] private AudioClip attackSE;
        [SerializeField] private AudioClip buttonSE;
        [SerializeField] private AudioClip gameStartSE;
        [SerializeField] private AudioClip battleBGM;
        [SerializeField] private AudioClip openingBGM;
        [SerializeField] private AudioClip resultBGM;
        private AudioSource _audioSource;

        private void Awake()
        {
            if (SoundManagerInstance == null)
            {
                SoundManagerInstance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }

            Initiazelize();
        }

        private void Initiazelize()
        {
            _audioSource = gameObject.GetComponent<AudioSource>();
            SetOpeningBGM();
        }

        public void SetAttackSE()
        {
            _audioSource.PlayOneShot(attackSE);
        }

        public void SetButtonSE()
        {
            _audioSource.PlayOneShot(buttonSE);
        }

        public void SetGameStartSE()
        {
            _audioSource.PlayOneShot(gameStartSE);
        }

        public void SetBattleBGM()
        {
            _audioSource.clip = battleBGM;
            _audioSource.Play();
        }

        public void SetOpeningBGM()
        {
            _audioSource.clip = openingBGM;
            _audioSource.Play();
        }

        public void SetResultBGM()
        {
            _audioSource.clip = resultBGM;
            _audioSource.Play();
        }

        public void StopSound()
        {
            _audioSource.Stop();
        }
    }
}