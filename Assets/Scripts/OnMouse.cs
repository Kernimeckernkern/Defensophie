using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnMouse : MonoBehaviour {
    [SerializeField]
    private GameObject updates;
    private int i = 0;

    void OnMouseDown ()
    {
        if (i == 0)
        {
            updates.SetActive (true);
            i += 1;
        }
        else
        {
            updates.SetActive (false);
            i -= 1;
        }
    }
}
