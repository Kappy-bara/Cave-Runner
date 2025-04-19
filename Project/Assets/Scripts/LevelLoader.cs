using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour
{
    private CoinCollector coinCollector;
    void Start()
    {
        coinCollector = GetComponent<CoinCollector>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Gate"))
        {
            LoadNextLevel();
        }
    }
    private void LoadNextLevel()
    {
        PlayerPrefs.SetInt("Coins", coinCollector.coins);
        PlayerPrefs.SetInt("Deaths", coinCollector.deaths);

        SceneManager.LoadScene(3);

    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        Debug.Log("PlayerPrefs have been reset.");
    }
}
