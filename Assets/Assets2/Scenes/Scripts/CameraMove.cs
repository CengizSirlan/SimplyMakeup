using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float maxspeed = 4f;
    private float speed;
    public Vector3 target = new Vector3(10, 5, -10);

    public IEnumerator MoveToTarget()
    {
        speed = 0;
        float i = 0.001f;
        while (transform.position != target)
        {
            speed = Mathf.Clamp(speed + i, 0, maxspeed);
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(this.transform.position, target, step);
            i = i * 2;
            yield return null;
        }
    }
}
