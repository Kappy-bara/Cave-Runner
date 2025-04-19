using UnityEngine;

public class BGM : MonoBehaviour
{
    public static BGM instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            instance.GetComponent<AudioSource>().enabled = true;
            instance.GetComponent<AudioManager>().enabled = true;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
