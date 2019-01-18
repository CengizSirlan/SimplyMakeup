using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButton : MonoBehaviour
{
    public float vectorx;
    public GameObject blackButton;

    public void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        
        if (hit.collider != null && hit.collider.gameObject.tag == "Button" && Input.GetMouseButtonDown(0) && hit.collider.gameObject == this.gameObject)
        {
            Camera.main.GetComponent<CameraMove>().target = new Vector3(vectorx, 0f, -10);
            StartCoroutine(Camera.main.GetComponent<CameraMove>().MoveToTarget());
            if(blackButton != null)
            {
                StartCoroutine(blackButton.GetComponent<BlackButton>().blackout());
            }
        }
    }
}
