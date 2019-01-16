using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackButton : MonoBehaviour
{
    public IEnumerator blackout()
    {
        this.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        this.gameObject.SetActive(false);
    }
}
