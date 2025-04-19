using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScene : MonoBehaviour
{
    private int coins = 0;
    private int deaths = 0;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI deathText;
    public TextMeshProUGUI ScoreText;
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        coins = PlayerPrefs.GetInt("Coins", 0); 
        deaths = PlayerPrefs.GetInt("Deaths", 0);
        coinText.text = "" + coins;
        deathText.text = "" + deaths;
        ScoreText.text = "" + (100 + (2 * coins) - (5 * deaths));
    }
    public void QuitGame()
    {
        audioSource.Play();
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        Application.Quit();
    }
    public void GoToMainMenu()
    {
        audioSource.Play();
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        SceneManager.LoadScene(0);
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        Debug.Log("PlayerPrefs have been reset.");
    }
}
