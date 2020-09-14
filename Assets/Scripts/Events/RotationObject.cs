using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationObject : MonoBehaviour
{
    public Vector3 speed;

    void Update()
    {
        this.transform.Rotate(speed * Time.deltaTime);
    }
}
