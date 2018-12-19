using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStartingPlane : MonoBehaviour {

    //Initialisation. Move plane slightly right for a small correction.
    void Start ()
    {
        transform.Translate(0.1f, 0, 0);
    }

}
