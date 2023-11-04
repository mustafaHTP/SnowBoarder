using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private float loadSceneDelay = 0.5f;
    [SerializeField] private ParticleSystem vfxFinish;
    [SerializeField] private AudioClip sfxFinish;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.SetActive(false);

            vfxFinish.Play();
            _audioSource.PlayOneShot(sfxFinish);

            Invoke(nameof(ReloadScene), loadSceneDelay);
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
