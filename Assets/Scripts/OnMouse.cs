using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnMouse : MonoBehaviour {
    [SerializeField]
    private GameObject updates;
    [SerializeField]
    private GameObject inspect;
    [SerializeField]
    private TowerScript script;
    private int i = 0;
    bool eMode;
#if UNITY_EDITOR
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
#endif
#if UNITY_ANDROID
        void OnTouch()

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
#endif
    private void OnMouseEnter()
    {
        inspect.SetActive(true);
        inspect.GetComponent<Text>().text = "Damage: " + script.Damage.ToString() + "\nRegeneration Time: " + script.Regeneration.ToString() + "\nRange: " + script.Range.ToString();
    }
    private void OnMouseExit()
    {
        inspect.SetActive(false);
    }
}
