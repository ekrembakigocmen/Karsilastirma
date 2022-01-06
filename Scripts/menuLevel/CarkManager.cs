using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarkManager : MonoBehaviour
{
    
public int hiz=30;
    
    void Update()
    {
       transform.Rotate(Vector3.forward*hiz*Time.deltaTime);
    }
}

