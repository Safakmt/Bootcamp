using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSelfDestroy : MonoBehaviour
{
    void OnEnable()
    {
        SelfDestroy();
    }
    IEnumerator SelfDestroy()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
