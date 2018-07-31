using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeOpo : MonoBehaviour
{
    public Transform plane;
    public GameObject pref;
    public List<GameObject> clone = new List<GameObject>();
    public List<bool> alredy = new List<bool>();
    public Transform player;
    public Vector3 pos;
    public int score = 0;
    public Text display_text;
    public float distance_between = 25; 

    // Use this for initialization
    void Start()
    {

        for (int i = 0; i < 10; i++)
        {
            pos.x = Random.Range(-7, 7);
            pos.y = 1;
            pos.z = 30 + distance_between * i;

            clone.Add(Instantiate(pref, pos, Quaternion.Euler(0, 0, 0)) as GameObject);
            alredy.Add(true);
        }

    }

    void Update()
    {

        float player_pos = player.position.z;

        menage_score();

        if (clone[0].transform.position.z + 40 < player_pos)
        {

            if (distance_between > 10)
                distance_between *= 0.999f;
            else
                distance_between *= 0.9999f;


            Debug.Log(distance_between);
            remove();
            addopo();
            planefix();
        }

    }

    void remove()
    {
        Destroy(clone[0]);
        clone.RemoveAt(0);
        alredy.RemoveAt(0);
    }

    void addopo()
    {
        pos.x = Random.Range(-7, 7);
        pos.z += distance_between;
        clone.Add(Instantiate(pref, pos, Quaternion.Euler(0, 0, 0)) as GameObject);
        alredy.Add(true);
    }

    void planefix()
    {
        Vector3 planepos = plane.position;
        planepos.z += distance_between;
        plane.position = planepos;
    }

    void menage_score()
    {
        float player_pos = player.position.z;

        if (clone[0].transform.position.z + 0.5 < player_pos && alredy[0])
        {
            alredy[0] = false;
            score++;
        }

        if (clone[1].transform.position.z + 0.5 < player_pos && alredy[1])
        {
            alredy[1] = false;
            score++;
        }

        display_text.text = score.ToString();
    }
}
