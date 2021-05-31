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
    public LayerMask move;
    public float speed = 5;
    public Transform rayCast, rayCast2, rayCast3, rayCast4;
    public float distanceRay;
    void Start()
    {
        anim = GetComponent<Animator>();
        targetPosition = transform.position;
        direction = Direction.down;
    }

    void Update()
    {
        Debug.DrawRay(rayCast2.position, rayCast.right * distanceRay);
        Debug.DrawRay(rayCast.position, -rayCast.right * distanceRay);
        Debug.DrawRay(rayCast3.position, rayCast.up * distanceRay);
        Debug.DrawRay(rayCast4.position, -rayCast.up * distanceRay);
        RaycastHit2D hit = Physics2D.Raycast(rayCast.position, -rayCast.right, distanceRay, move);
        RaycastHit2D hit2 = Physics2D.Raycast(rayCast2.position, rayCast.right, distanceRay, move);
        RaycastHit2D hit3 = Physics2D.Raycast(rayCast3.position, rayCast.up, distanceRay, move);
        RaycastHit2D hit4 = Physics2D.Raycast(rayCast4.position, -rayCast.up, distanceRay, move);
        Vector2 axisDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if(axisDirection != Vector2.zero && targetPosition == transform.position)
        {
            if (Mathf.Abs(axisDirection.x) > Mathf.Abs(axisDirection.y))
            {
                if(axisDirection.x > 0)
                {
                    direction = Direction.right;
                    //transform.eulerAngles = new Vector2(0f, 180f);
                    if (hit2.collider && direction == Direction.right)
                    {
                        hit2.transform.position = new Vector2(hit2.transform.position.x + 1, hit2.transform.position.y);
                    }
                    if (!CheckCollision)
                        targetPosition += Vector3.right;
                }
                else
                {
                    direction = Direction.left;
                    //transform.eulerAngles = new Vector2(0f, 0f);
                    if (hit.collider && direction == Direction.left)
                    {
                        hit.transform.position = new Vector2(hit.transform.position.x - 1, hit.transform.position.y);
                    }
                    if (!CheckCollision)
                        targetPosition -= Vector3.right;
                }
            }
            else
            {
                if (axisDirection.y > 0)
                {
                    direction = Direction.up;
                    //transform.eulerAngles = new Vector3(0f, 0f, -90f);
                    if (hit3.collider && direction == Direction.up)
                    {
                        hit3.transform.position = new Vector2(hit3.transform.position.x, hit3.transform.position.y + 1);
                    }
                    if (!CheckCollision)
                        targetPosition += Vector3.up;
                }
                else
                {
                    direction = Direction.down;
                    //transform.eulerAngles = new Vector3(0f, 0f, 90f);
                    if (hit4.collider && direction == Direction.down)
                    {
                        hit4.transform.position = new Vector2(hit4.transform.position.x, hit4.transform.position.y - 1);
                    }
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
            //bool col = true;
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
