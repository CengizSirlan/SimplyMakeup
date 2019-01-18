using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfileScript : MonoBehaviour
{
    public GameObject profiler;
    public bool onoroff;

    public void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        
        if (hit.collider != null && hit.collider.gameObject.tag == "ProfileButton" && Input.GetMouseButtonDown(0) && hit.collider.gameObject == this.gameObject)
        {
            if (onoroff)
            {
                profiler.GetComponent<Profile>().appear();
            }
            else
            {
                profiler.GetComponent<Profile>().disappear();
            }
        }
    }
}
