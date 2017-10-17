using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject monster;
    private List<GameObject> InstancedMonster = new List<GameObject>();
    // Use this for initialization
    void Update ()
    {
        StartCoroutine ("Spawne");
    }
    IEnumerator Spawne ()
    {
        StartCoroutine ("DoSomething");
        yield return new WaitForSeconds (4f);
        StopCoroutine ("DoSomething");
    }
    IEnumerator DoSomething ()
    {
        while (true)
        {
            GameObject newMonster =Instantiate (monster,monster.GetComponent<Monster>().startpos,Quaternion.identity);
            InstancedMonster.Add (newMonster);
            Debug.Log (InstancedMonster.Count);
            yield return null;
        }

    }
}
