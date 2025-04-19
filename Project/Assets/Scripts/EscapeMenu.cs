using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeMenu : MonoBehaviour
{
    public GameObject menuUI;
    void Start()
    {
        menuUI.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMenu();
        }
    }
    private void ToggleMenu()
    {
        bool isActive = menuUI.activeSelf;
        menuUI.SetActive(!isActive);
    }
    public void GoToMainMenu()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        SceneManager.LoadScene(0);
    }
}
