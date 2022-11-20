using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter(Collider oter)
    {
        if (oter.gameObject.CompareTag("Cube"))
        {
            gameObject.SetActive(false);
        }
    }
}
