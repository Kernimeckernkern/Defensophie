using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Updates : MonoBehaviour {
    [SerializeField]
    private GameObject button;
    public void DeleteObj ()
    {
        gameObject.SetActive (false);
        button.transform.position -= new Vector3 (0f,130f,0f);
    }
}
