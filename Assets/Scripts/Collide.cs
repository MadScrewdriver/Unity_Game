using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Collide : MonoBehaviour
{
    public player playerscript;
    public Transform player;
    public Rigidbody movment;
    public float deley = 2f;
    public MakeOpo makeopo;
    public DeathMenu deathMenu;
    public double t;
    public bool end = true;

    void Update()
    {
        if (player.position.y < 0)
        {
            if (end)
            {
                t = Time.time;
                end = false;
                playerscript.enabled = false;
                makeopo.enabled = false;
            }
        }

        if (!(end) && Time.time - t >= deley)
        {
            gameover();
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Opponent")
        {
            if (end)
            {
                t = Time.time;
                end = false;
                playerscript.enabled = false;
                makeopo.enabled = false;
            }
        }
    }

    void gameover()
    {
        deathMenu.dead(makeopo.score);
    }
}
