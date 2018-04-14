using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacMan : MonoBehaviour
{
    public float speed = 1f;
    private Vector2 dest = Vector2.zero;
    Rigidbody2D rb2D;
    public int point=29;
    private int score;


    void Start()
    {
        dest = Vector2.right;
    }

    void FixedUpdate()
    {

        Vector2 pos = transform.position;
        transform.Translate(dest*speed*Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.UpArrow))
            dest = Vector2.up;
        if (Input.GetKeyDown(KeyCode.RightArrow))
            dest = Vector2.right;
        if (Input.GetKeyDown(KeyCode.DownArrow))
            dest = -Vector2.up;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            dest = -Vector2.right;

        GetComponent<Animator>().SetFloat("DirX", dest.x);
        GetComponent<Animator>().SetFloat("DirY", dest.y);

        if (pos.x >= 14f)
            transform.position = new Vector2(pos.x - 28f, pos.y);
        if (pos.x <= -14f)
            transform.position = new Vector2(pos.x + 28f, pos.y);

        GameObject son = GameObject.Find("pacmanx");

        if (pos.x >= 10f || pos.x <= -10f || pos.y >= 11f || pos.y <= -11f)
            son.transform.position = pos - 4 * dest;
        else
            son.transform.position = pos + 4 * dest;
    }
 
    bool Check(Vector2 dir)
    {
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos+dir , pos);
        return (hit.collider == GetComponent<Collider2D>());
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.name == "point")
        {
            Destroy(other.gameObject);
            score = score + 10;
            point = point + 1;
        }
        else if(other.name=="big")
        {
            Destroy(other.gameObject);
            Debug.Log("big");
            score = score + 50;
        }

    }

    }

