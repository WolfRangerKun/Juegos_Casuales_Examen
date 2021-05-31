using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    up,
    down,
    left,
    right
}
public class PlayerMovement : MonoBehaviour
{
    Animator anim;
    Vector3 targetPosition;
    Direction direction;


    public LayerMask obstacles;
    public float speed = 5;
    void Start()
    {
        anim = GetComponent<Animator>();
        targetPosition = transform.position;
        direction = Direction.down;
    }

    void Update()
    {
        Vector2 axisDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if(axisDirection != Vector2.zero && targetPosition == transform.position)
        {
            if (Mathf.Abs(axisDirection.x) > Mathf.Abs(axisDirection.y))
            {
                if(axisDirection.x > 0)
                {
                    direction = Direction.right;
                    if (!CheckCollision)
                        targetPosition += Vector3.right;
                }
                else
                {
                    direction = Direction.left;
                    if (!CheckCollision)
                        targetPosition -= Vector3.right;
                }
            }
            else
            {
                if (axisDirection.y > 0)
                {
                    direction = Direction.up;
                    if (!CheckCollision)
                        targetPosition += Vector3.up;
                }
                else
                {
                    direction = Direction.down;
                    if (!CheckCollision)
                        targetPosition -= Vector3.up;
                }
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }
    
    bool CheckCollision
    {
        get
        {
            bool col = true;
            RaycastHit2D rh;

            Vector2 dir = Vector2.zero;
            if (direction == Direction.down)
                dir = Vector2.down;
            if (direction == Direction.up)
                dir = Vector2.up;
            if (direction == Direction.left)
                dir = Vector2.left;
            if (direction == Direction.right)
                dir = Vector2.right;

            rh = Physics2D.Raycast(transform.position, dir, 1, obstacles);
            Debug.DrawRay(transform.position, dir, Color.red, 1);

            return rh.collider != null;
        }
    }
}
