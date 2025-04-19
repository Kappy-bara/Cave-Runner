using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] audioClip;
    public AudioClip specialClip;
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = false;
    }

    void Update()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = GetRandomClip();
            audioSource.Play();
        }
    }
    AudioClip GetRandomClip()
    {
        int temp = Random.Range(0,3);
        if(temp == 0 ) return specialClip;
        else return audioClip[Random.Range(0, audioClip.Length)];
    }
}
