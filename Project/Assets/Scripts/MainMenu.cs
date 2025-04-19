using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject menuScreen;
    public GameObject aboutScreen;
    public GameObject levelSelectScreen;
    private AudioSource audioSource;
    void Start()
    {
        if (BGM.instance != null)
        {
            BGM.instance.GetComponent<AudioSource>().clip = null;
            BGM.instance.GetComponent<AudioSource>().enabled = false;
            BGM.instance.GetComponent<AudioManager>().enabled = false;
        }
        audioSource = GetComponent<AudioSource>();
        menuScreen.SetActive(true);
        aboutScreen.SetActive(false);
    }

    public void QuitGame()
    {
        audioSource.Play();
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        Application.Quit();
    }
    public void LoadLev1()
    {
        audioSource.Play();
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        SceneManager.LoadScene(1);
    }
    public void LoadLev2()
    {
        audioSource.Play();
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        SceneManager.LoadScene(2);
    }
    public void About()
    {
        audioSource.Play();
        menuScreen.SetActive(false);
        aboutScreen.SetActive(true);
        levelSelectScreen.SetActive(false);
    }
    public void MainScene()
    {
        audioSource.Play();
        menuScreen.SetActive(true);
        aboutScreen.SetActive(false);
        levelSelectScreen.SetActive(false);
    }
    public void SelectLevel()
    {
        audioSource.Play();
        menuScreen.SetActive(false);
        aboutScreen.SetActive(false);
        levelSelectScreen.SetActive(true);
    }
}
