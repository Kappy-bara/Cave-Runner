using System.Collections;
using UnityEngine;

public class FireballMotion : MonoBehaviour
{
    public float speed;
    public int direction = 1;
    public float destoryTime = 2f;
    private bool trigger = true;
    void Update()
    {
        transform.position += new Vector3(0f, speed * Time.deltaTime * direction, 0f);
        if(trigger) StartCoroutine(Deconstruct());
    }
    private IEnumerator Deconstruct()
    {
        trigger  = false;
        yield return new WaitForSeconds(destoryTime);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
