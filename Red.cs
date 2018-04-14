using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red : MonoBehaviour
{
    public Transform[] waypoints;
    int cur = 0;
    public float speed = 0.3f;

    void FixedUpdate()
    {
        GameObject player = GameObject.Find("pacman");
        int point= player.GetComponent<PacMan>().point;
        Vector2 dest = transform.position;

        Vector2 pos = player.transform.position - transform.position;

        if (dest.x >= 14f)
            transform.position = new Vector2(dest.x - 28f, dest.y);
        else if (dest.x <= -14f)
            transform.position = new Vector2(dest.x + 28f, dest.y);

        GetComponent<Animator>().SetFloat("DirX", pos.x);
        GetComponent<Animator>().SetFloat("DirY", pos.y);

        if (point < 30)
        {
            if (transform.position != waypoints[cur].position)
            {
                Vector2 p = Vector2.MoveTowards(transform.position,
                                                waypoints[cur].position,
                                                speed);
                GetComponent<Rigidbody2D>().MovePosition(p);
            }
            // Waypoint reached, select next one
            else cur = (cur + 1) % waypoints.Length;
        }
        else
            GetComponent<AILerp>().canSearch=true;
    }

}
