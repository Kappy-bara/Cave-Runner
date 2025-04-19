using UnityEngine;
using TMPro;
using System.Collections;
public class CoinCollector : MonoBehaviour
{
    public Transform spawnPoint;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI deathText;
    public int coins = 0;
    public int deaths = 0;

    private PlayerMovement playerMovement;
    private bool trigger = true;

    private AllSFX allSFX;
    private void Start()
    {
        allSFX = GetComponent<AllSFX>();
        playerMovement = GetComponent<PlayerMovement>();
        transform.position = spawnPoint.position;

        coins = PlayerPrefs.GetInt("Coins", 0);  // Default to 0 if not found
        deaths = PlayerPrefs.GetInt("Deaths", 0);  // Default to 0 if not found

        coinText.text = "" + coins;
        deathText.text = "" + deaths;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            allSFX.PlayCoinSound();
            Destroy(collision.gameObject);
            coins++;
            coinText.text = "" + coins;
        }
        else if (collision.CompareTag("Enemy") && trigger)
        {
            allSFX.PlayDeathSound();
            StartCoroutine(HandleDeath());
        }
    }
    private IEnumerator HandleDeath()
    {
        playerMovement.animator.SetBool("Dying", true);
        playerMovement.enabled = false;
        trigger = false;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        playerMovement.animator.SetTrigger("Dying2");
        yield return new WaitForSeconds(0.5f);
        RestartLevel();
        yield return new WaitForSeconds(0.5f);
        trigger = true;
        playerMovement.enabled = true;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        playerMovement.animator.SetBool("Dying", false);
    }
    private void RestartLevel()
    {
        deaths++;
        deathText.text = "" + deaths;
        transform.position = spawnPoint.position;
    }
}
