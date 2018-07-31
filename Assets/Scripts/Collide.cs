using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collide : MonoBehaviour
{
    public player playerscript;
    public Transform player;
    public float deley = 2f;
    public MakeOpo Makeopo;

    void Update()
    {
        if (player.position.y < 0)
        {
            playerscript.enabled = false;
            Makeopo.enabled = false;
            Invoke("gameover", deley);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Opponent")
        {
            playerscript.enabled = false;
            Makeopo.enabled = false;
            Invoke("gameover", deley);
        }
    }

    void gameover()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
