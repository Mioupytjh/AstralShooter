using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life = 1f;

    private void Awake()
    {
        Destroy(gameObject, life);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Enemy")
            {
                DestroyObject(other.gameObject);
                Destroy(gameObject);
            }
        }
        */
    }
}
