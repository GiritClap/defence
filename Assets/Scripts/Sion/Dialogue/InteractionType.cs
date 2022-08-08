using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionType : MonoBehaviour
{
    public bool isDoor;
    public bool isObject;

    [SerializeField] string InteractionName;

    public string GetName()
    {
        return InteractionName;

    }

}
