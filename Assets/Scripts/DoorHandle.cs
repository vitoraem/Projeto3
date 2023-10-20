using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandle : MonoBehaviour
{
    public Animator doorAnim;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {           
                doorAnim.SetTrigger("Open");         
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            doorAnim.SetTrigger("Closed");
    }
}
