using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject monster;
    private List<GameObject> InstancedMonster = new List<GameObject>();
    // Use this for initialization
    void Start ()
    {
        StartCoroutine ("Spawne");
    }
    IEnumerator Spawne ()
    {
        while (true)
        {
            GameObject newMonster = Instantiate (monster, monster.GetComponent<Monster> ().startpos, Quaternion.identity);
            InstancedMonster.Add (newMonster);
            yield return null; //wait for a frame
            yield return new WaitForSeconds (3.14f);
        }
    }
}
