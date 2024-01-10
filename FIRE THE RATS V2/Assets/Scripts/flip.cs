using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flip : MonoBehaviour
{
    public void Trigger()
    {
        Vector3 scale = transform.localScale;
        scale.y *= -1f;
        transform.localScale = new Vector3(scale.x, scale.y, scale.z);
    }
}
