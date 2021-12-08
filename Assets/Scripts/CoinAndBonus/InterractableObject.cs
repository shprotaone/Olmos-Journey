using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InterractableObject : MonoBehaviour
{
    public virtual IEnumerator Action(Collider collider)
    {
        yield break;
    }
}
