using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerExit2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }
}
