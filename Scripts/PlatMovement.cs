using UnityEngine;
using System.Collections;

public class PlatMovement : MonoBehaviour
{
    bool isRight = true;
    bool isUp = true;
    float x;
    float y;
    public float moveRangeX = 5f;
    public float moveRangeY = 5f;
    public float Xspeed = 0.05f;
    public float Yspeed = 0;

    void Start()
    {
        x = transform.position.x;
        y = transform.position.y;

    }

    void FixedUpdate()
    {
        Invoke("MoveX", 0f);
        Invoke("MoveY", 0f);
    }

    void MoveX()
    {
        if (isRight == true && transform.position.x >= x + moveRangeX)
        {
            Invoke("MoveLeft", 0f);
        }
        else if (isRight == true && transform.position.x < x + moveRangeX)
        {
            Invoke("MoveRight", 0f);
        }
        else if (isRight == false && transform.position.x > x)
        {
            Invoke("MoveLeft", 0f);
        }
        else if (isRight == false && transform.position.x <= x)
        {
            Invoke("MoveRight", 0f);
        }
    }

    void MoveY()
    {
        if (isUp == true && transform.position.y >= y + moveRangeY)
        {
            Invoke("MoveDown", 0f);
        }
        else if (isUp == true && transform.position.y < y + moveRangeY)
        {
            Invoke("MoveUp", 0f);
        }
        else if (isUp == false && transform.position.y > y)
        {
            Invoke("MoveDown", 0f);
        }
        else if (isUp == false && transform.position.y <= y)
        {
            Invoke("MoveUp", 0f);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        Transform onPlat = other.gameObject.transform;
        if (isRight == true)
        {
            onPlat.Translate(Xspeed/3, 0, 0);
        }
        if (isRight == false)
        {
            onPlat.Translate(-1 * Xspeed/3, 0, 0);
        }
        if (isUp == false)
        {
            onPlat.Translate(0, -1 * Yspeed/3, 0);
        }
    }
    void MoveRight()
    {
        transform.Translate(Xspeed, 0, 0);
        isRight = true;
    }

    void MoveLeft()
    {
        transform.Translate(-1 * Xspeed, 0, 0);
        isRight = false;
    }

    void MoveUp()
    {
        transform.Translate(0, Yspeed, 0);
        isUp = true;
    }

    void MoveDown()
    {
        transform.Translate(0, -1*Yspeed, 0);
        isUp = false;
    }
}
