using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject monster;
    [SerializeField]
    private Transform startpos;
    [SerializeField]
    private Transform endpoint;
    [SerializeField]
    private float spawnTime = 5f;
    private GameObject newMonster;
    private bool los;
    private List<GameObject> InstancedMonster = new List<GameObject> ();
    // Use this for initialization
    void Start ()
    {
        BeginSpawn ();
    }
    IEnumerator Spawne ()
    {
        
      
        while (Lebensmanager.Instance.PlayerAlive)
        {
            newMonster = Instantiate (monster, startpos.position, Quaternion.identity);
            Monster monsterInstance = newMonster.GetComponent<Monster> ();
            monsterInstance.Initialize (this, endpoint.position);
            monsterInstance.StartMoving (true);
            InstancedMonster.Add (newMonster);
            yield return new WaitForSeconds (spawnTime);
        }
        
    }
    public void RemoveFromList (GameObject deadMonster)
    {
        if (InstancedMonster.Contains (deadMonster))
        {
        InstancedMonster.Remove (deadMonster);
        }
    }
    public void Reset ()
    {
        ListDestroyer ();
    }
    public void BeginSpawn ()
    {
        StartCoroutine (Spawne());
    }
    private void ListDestroyer ()
    {
        for (int a = InstancedMonster.Count - 1; a >= 0; --a)
        {
            Destroy (InstancedMonster[a]);
        }
        InstancedMonster.Clear ();
    }
}
