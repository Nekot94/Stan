using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour, IVRInteractable 
{
    public void Act()
    {
        GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value);
    }

}
