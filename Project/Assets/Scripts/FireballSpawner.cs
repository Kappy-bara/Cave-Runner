using System.Collections;
using UnityEngine;

public class FireballSpawner : MonoBehaviour
{
    public float interval = 5f;
    public int upDown01 = 1;
    public float destoryTime = 2f;
    public GameObject fireball;
    private bool trigger = true;
    private int direction = 1;
    void Start()
    {
        if (upDown01 == 0) direction = 1;
        else direction = -1;
    }
    void Update()
    {
        if (trigger)
        {
            StartCoroutine(SpawnFireball());
        }
    }
    private IEnumerator SpawnFireball()
    {
        trigger = false;
        yield return new WaitForSeconds(interval);
        GameObject temp = Instantiate(fireball, transform.position, Quaternion.Euler(180f * upDown01,0f,0f));
        temp.GetComponent<FireballMotion>().direction = direction;
        temp.GetComponent<FireballMotion>().destoryTime = destoryTime;
        trigger = true;
    }
}
