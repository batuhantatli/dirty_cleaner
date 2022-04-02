using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garbage : MonoBehaviour
{
    [SerializeField] GameObject _dirty;
    public void Shoot(Vector3 force)
    {
        gameObject.transform.parent = null;
        GetComponent<Rigidbody>().AddForce(force, ForceMode.VelocityChange);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("GroundTag"))
        {
            Instantiate(_dirty, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
