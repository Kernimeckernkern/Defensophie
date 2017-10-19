using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TowerScript : MonoBehaviour
{

    [SerializeField]
    private GameObject button;
    [SerializeField]
    private float regeneration = 2f;
    [SerializeField]
    private float range = 6f;
    [SerializeField]
    private int damage = 2;


    private BoxCollider box;
    private Monster currentMonster;
    private Queue<GameObject> monsterIn = new Queue<GameObject> ();
    // Use this for initialization
    void Start ()
    {
        box = GetComponent<BoxCollider>();
        box.size = new Vector3(range*2f,3f,range*2f + 4f);
        BeginAttack ();
    }
    IEnumerator Attack ()
    {
        while (Lebensmanager.Instance.PlayerAlive)
        {

            if (monsterIn.Count > 0)
            {
                if (monsterIn.Peek () == null)
                {
                    monsterIn.Dequeue ();
                    currentMonster = null;
                }

                if (currentMonster == null && monsterIn.Count > 0 && monsterIn.Peek () != null)
                {
                    currentMonster = monsterIn.Peek ().GetComponent<Monster> ();
                }
                if (currentMonster != null)
                {
                    currentMonster.DecreaseHp (damage);
                }
                yield return new WaitForSeconds (regeneration);
            }
            else
            {
                yield return null;
            }
        }
    }
    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer ("Monster"))
        {

            monsterIn.Enqueue (other.gameObject);

        }

    }
    private void OnTriggerExit (Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer ("Monster"))
        {
            if (monsterIn.Contains (other.gameObject))
            {
                monsterIn.Dequeue ();
            }

        }
    }
    public void BeginAttack ()
    {
        StartCoroutine (Attack());
    }
    public void Reset ()
    {
        monsterIn.Clear ();
        currentMonster = null;
        gameObject.SetActive (false);
        if (button.transform.position.y > 10)
        {
        button.transform.position -= new Vector3 (0f,130f,0f);
        }
    }


}