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

    private int startDam = 2;
    private float startReg = 2, startRan = 6;
    private BoxCollider box;
    private Monster currentMonster;
    private Queue<GameObject> monsterIn = new Queue<GameObject> ();

    public float Regeneration
    {
        get
        {
            return regeneration;
        }

        private set
        {
            regeneration = value;
        }
    }

    public float Range
    {
        get
        {
            return range;
        }

        private set
        {
            range = value;
        }
    }

    public int Damage
    {
        get
        {
            return damage;
        }

       private set
        {
            damage = value;
        }
    }

    // Use this for initialization
    void Start ()
    {
        box = GetComponent<BoxCollider>();
        box.size = new Vector3(range*2f,3f,range*2f + 4f);
        BeginAttack ();
        startDam = damage;
        startReg = regeneration;
        startRan = range;
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
                yield return new WaitForSeconds (Regeneration);
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
    public void SetRange(float newRange)
    {
        range += newRange;
        box.size = new Vector3(range * 2f, 3f, range * 2f + 4f);
    }
    public int SetDamage(int newDamage)
    {
        damage += newDamage;
        return damage;
    }
    public float SetRegeneration(float newRegeneration)
    {
        regeneration -= newRegeneration;
        return regeneration;
    }
    public void BeginAttack ()
    {
        StartCoroutine (Attack());
    }
    public void Reset ()
    {
        ResetTower();
        monsterIn.Clear ();
        currentMonster = null;
        gameObject.SetActive (false);
        if (button.transform.position.y > 10)
        {
        button.transform.position -= new Vector3 (0f,130f,0f);
        }
    }
    public void ResetTower()
    {
        damage = startDam;
        regeneration = startReg;
        range = startRan;
    }


}