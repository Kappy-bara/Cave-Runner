using UnityEngine;

public class AllSFX : MonoBehaviour
{
    public AudioClip coinCollect;
    public AudioClip jumpSound;
    public AudioClip deathSound;
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayCoinSound()
    {
        audioSource.clip = coinCollect;
        audioSource.Play();
    }
    public void PlayJumpSound()
    {
        audioSource.clip= jumpSound;
        audioSource.Play();
    }
    public void PlayDeathSound()
    {
        audioSource.clip= deathSound;
        audioSource.Play();
    }
}
