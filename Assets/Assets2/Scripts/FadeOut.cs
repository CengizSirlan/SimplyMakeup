using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    private SpriteRenderer sp;
    public void Start()
    {
        sp = this.GetComponent<SpriteRenderer>();
        StartCoroutine("fadeOut");
    }

    public IEnumerator fadeOut()
    {
        float i = 0.02f;
        while(sp.color.a != 0){
            sp.color = new Color(sp.color.r, sp.color.g, sp.color.b, sp.color.a - i);
            yield return null;
        }

        Destroy(this.gameObject);
    }
}
