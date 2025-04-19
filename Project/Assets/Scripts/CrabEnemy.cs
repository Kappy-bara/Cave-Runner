using UnityEngine;

public class CrabEnemy : MonoBehaviour
{
    public Transform waypoint1;
    public Transform waypoint2;
    public float moveSpeed = 2f;

    private Transform targetWaypoint;
    private bool movingRight = true; 

    private SpriteRenderer spriteRenderer; 

    void Start()
    {
        targetWaypoint = waypoint1;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        MoveBetweenWaypoints();
    }

    void MoveBetweenWaypoints()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetWaypoint.position, moveSpeed * Time.deltaTime);
        if (Vector2.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            
            if (targetWaypoint == waypoint1)
            {
                targetWaypoint = waypoint2;
                movingRight = true;
            }
            else
            {
                targetWaypoint = waypoint1;
                movingRight = false;
            }
            FlipSprite();
        }
    }

    void FlipSprite()
    {
        if (movingRight) spriteRenderer.flipX = true;  
        else spriteRenderer.flipX = false; 
    }
}