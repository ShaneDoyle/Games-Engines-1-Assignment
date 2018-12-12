using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBall : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0, 10, 0);
    }
}
