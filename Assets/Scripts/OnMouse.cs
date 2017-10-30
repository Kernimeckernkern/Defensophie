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
    private int a = 0;
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
/*#if UNITY_ANDROID
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
#endif*/
#if UNITY_EDITOR
    private void OnMouseEnter()
    {
        inspect.SetActive(true);
        inspect.GetComponent<Text>().text = "Damage: " + script.Damage.ToString() + "\nRegeneration Time: " + script.Regeneration.ToString() + "\nRange: " + script.Range.ToString();
    }
    private void OnMouseExit()
    {
        inspect.SetActive(false);
    }
#endif
#if UNITY_ANDROID
    void Update()
    {
       
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Vector2 tPos = Input.GetTouch(0).position;
            Ray ray = Camera.main.ScreenPointToRay(tPos);
            RaycastHit hit;
            if(Physics.Raycast(ray.origin,ray.direction,out hit))
            {
                if (hit.transform.position == gameObject.GetComponentInParent<Transform>().position)
                {
                    if(updates.activeSelf == false)
                    { 
                    updates.SetActive(true);
                        a = 1;
                    }
                    if (a == 0 && updates.activeSelf == true )
                    {
                        updates.SetActive(false);
                    }
                }
            }
        }
        a = 0;
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary)
        {
            Vector2 tPos = Input.GetTouch(0).position;
            Ray ray = Camera.main.ScreenPointToRay(tPos);
            RaycastHit hit;
            if (Physics.Raycast(ray.origin, ray.direction, out hit))
            {
                if (hit.transform.position == gameObject.GetComponentInParent<Transform>().position)
                {
                    inspect.SetActive(true);
                    inspect.GetComponent<Text>().text = "Damage: " + script.Damage.ToString() + "\nRegeneration Time: " + script.Regeneration.ToString() + "\nRange: " + script.Range.ToString();
                }
            }
        }
        else
        {
            inspect.SetActive(false);
        }
    }
#endif
}
