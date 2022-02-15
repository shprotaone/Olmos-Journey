using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    private void Update()
    {
        this.transform.Rotate(0, 0, 90 * Time.deltaTime, Space.Self);
    }
}
