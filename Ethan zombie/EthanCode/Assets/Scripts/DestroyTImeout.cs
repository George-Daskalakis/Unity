using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTImeout : MonoBehaviour
{
	public float timer = 15.0f;
    // Start is called before the first frame update
    void Start()
    {
       Destroy (gameObject, timer);
    }
}
