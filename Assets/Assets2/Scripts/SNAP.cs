using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SNAP : MonoBehaviour
{
    public void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null && hit.collider.gameObject.tag == "Snap" && Input.GetMouseButtonDown(0) && hit.collider.gameObject == this.gameObject)
        {
            Camera.main.GetComponent<FM>().buttonclick();
        }
    }
}
