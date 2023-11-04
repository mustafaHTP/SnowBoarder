using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] private float loadSceneDelay = 0.5f;
    [SerializeField] private ParticleSystem vfxCrash; 
    [SerializeField] private AudioClip sfxCrash;

    private AudioSource _audioSource;
    private PlayerController _playerController;
    private DustTrail _dustTrail;

    private bool _hasCrashed;

    private void Awake()
    {
        _dustTrail = GetComponent<DustTrail>();
        _playerController = GetComponent<PlayerController>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !_hasCrashed)
        {
            _hasCrashed = true;
            vfxCrash.Play();
            _audioSource.PlayOneShot(sfxCrash);

            _dustTrail.enabled = false;
            _playerController.enabled = false;

            Invoke(nameof(ReloadScene), loadSceneDelay);
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
