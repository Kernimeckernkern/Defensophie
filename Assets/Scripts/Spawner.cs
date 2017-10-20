using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    private Monster monsterScript;
    private GameObject newMonster;
    private int monsterCount;
    private bool los;
    private List<GameObject> InstancedMonster = new List<GameObject> ();
    // Use this for initialization
    void Start ()
    {
        monsterScript = monster.GetComponent<Monster> ();
        monsterScript.MonsterHp = 10;
        BeginSpawn ();
        BeginSpawnTime ();
    }
    private IEnumerator SpawnTime ()
    {
        while (Lebensmanager.Instance.PlayerAlive)
        {
        DecreaseSpawnTime ();
        yield return new WaitForSeconds (30);
        }
    }
    IEnumerator Spawne ()
    {
        
      
        while (Lebensmanager.Instance.PlayerAlive)
        {
            if (monsterCount % 5==0)
            {
                monsterScript.SetHp (5);
            }
            newMonster = Instantiate(monster,startpos.position,Quaternion.identity);
            Monster monsterInstance = newMonster.GetComponent<Monster> ();
            monsterInstance.Initialize (this, endpoint.position);
            monsterInstance.StartMoving (true);
            InstancedMonster.Add (newMonster);
            monsterCount += 1;
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
    private void DecreaseSpawnTime ()
    {
        if(spawnTime > 0.2f)
        spawnTime -= 0.2f;
    }
    public void Reset ()

    {
        monsterScript.MonsterHp = 10;
        monsterCount = 0;
        spawnTime = 5f;
        ListDestroyer ();
    }
    public void BeginSpawn ()
    {
        StartCoroutine (Spawne());
    }
    public void BeginSpawnTime ()
    {
        StartCoroutine (SpawnTime ());
    }
    private void ListDestroyer ()
    {
        for (int a = InstancedMonster.Count - 1; a >= 0; --a)
        {
            Destroy(InstancedMonster[a]);
        }
        InstancedMonster.Clear ();
    }
}
