using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {
    [SerializeField]
    private Transform endpoint;
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private int monsterHp = 10;
    public Vector3 startpos;
    // Use this for initialization
    void Start () {
        startpos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards (transform.position,endpoint.position,speed * Time.deltaTime);
        if (Mathf.Round (transform.position.x) >= endpoint.position.x)
        {
            endpoint.GetComponent<Lebensmanager> ().SetPHp ();
            Die ();
        }
            
    }
    private void OnTriggerEnter (Collider other)
    {
      /*  if (other.gameObject.layer == LayerMask.NameToLayer("DeathZone"))
        {
            Die ();
        }*/
    }
    private void Die ()
    {
        Destroy (gameObject);
    }
   public void SetHp (int damage)
    {
        monsterHp -= damage;
        Debug.Log ("Monster hp"+monsterHp);
        if (monsterHp <= 0)
        {
            Die ();
        }
    }
}
