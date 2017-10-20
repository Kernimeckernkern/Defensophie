using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private int monsterHp = 10;
    [SerializeField]
    private Canvas slid;

    public Vector3 movement;
    public Vector3 dir;

    private CharacterController controller;
    private Material material;
    private bool loslaufen;
    private Spawner spawner;
    private Vector3 endpoint;

    public int MonsterHp
    {
        get
        {
            return monsterHp;
        }

        set
        {
            monsterHp = value;
        }
    }

    // Use this for initialization
    void Start ()
    {
        controller = GetComponent<CharacterController> ();
        material = GetComponent<MeshRenderer> ().material;
       // Canvas newSlider = Instantiate(slid);
        //slid.transform.SetParent(transform);
    }

    // Update is called once per frame
    void Update ()
    {
        if (Lebensmanager.Instance.PlayerAlive)
        {
            if (loslaufen)
            {
                // find the target position relative to the player:
                dir = endpoint - transform.position;
                // calculate movement at the desired speed:
                movement = dir.normalized * speed * Time.deltaTime;
                // limit movement to never pass the target position:
                if (movement.magnitude > dir.magnitude)
                    movement = dir;
                // move the character:
                controller.Move (movement);
            }

        }
    }
    public void Initialize (Spawner spawner, Vector3 endposition)
    {
        this.spawner = spawner;
        endpoint = endposition;
    }
    public void StartMoving (bool los)
    {
        loslaufen = los;
    }

    private IEnumerator Blink ()
    {
        material.color = Color.red;
        yield return new WaitForSeconds (0.1f);
        material.color = Color.grey;
    }

    private void Die ()
    {
        spawner.RemoveFromList (gameObject);
        Destroy (gameObject);

    }
    public void SetHp (int hp)
    {
        monsterHp += hp ;
    }
    public void SetSpeed ()
    {
        speed += 1f;
    }
    public void DecreaseHp (int damage)
    {
        monsterHp -= damage;
        Debug.Log ("Monster hp"+monsterHp);
        if (monsterHp <= 0)
        {
            Die ();
        }
        else
        {
            StartCoroutine (Blink ());
        }
    }
    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer ("DeathZone"))
        {
            Lebensmanager.Instance.DecreaseLife ();
            Die ();
        }
    }

}
