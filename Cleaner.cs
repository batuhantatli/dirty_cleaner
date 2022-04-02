using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaner : MonoBehaviour
{
    [SerializeField] private string specialTag = "";
    [SerializeField] Animator _animator;
    public bool isCleaning;
    private void OnTriggerStay(Collider other)
    {
        isCleaning = false;
        _animator.SetBool("Cleaning", false);
        if(other.CompareTag(specialTag))
        {
            isCleaning = true;
            _animator.SetBool("Cleaning", true);
            Dirty dirty = other.GetComponent<Dirty>();
            dirty.Clean();
        }
    }
}
