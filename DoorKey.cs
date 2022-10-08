using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKey : MonoBehaviour
{
    [SerializeField] Animator doorAnim;
    bool isOpen = false;
    Animator keyAnim;
    private void Start()
    {
        keyAnim = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (isOpen)
            {
                doorAnim.SetBool("isOpen", false);
                keyAnim.SetBool("isOpen", false);
                isOpen = false;
            }
            else
            {
                doorAnim.SetBool("isOpen", true);
                keyAnim.SetBool("isOpen", true);
                isOpen = true;
            }
        }
    }
}
