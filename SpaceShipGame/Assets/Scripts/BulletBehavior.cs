using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float travelDistance = 50f;
    public Vector3 travelDirection;

    public BulletManager bulletManager;

    private Rigidbody _rb; // Reference to bullet's Rigidbody.
    private Vector3 _startPos;
    private float _travelSpeed;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>(); // Access bullet's Rigidbody.
        var curPos = transform.position;
        _startPos = new Vector3(curPos.x, curPos.y, curPos.z);
        _travelSpeed = bulletManager.getBulletSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(_startPos, transform.position) >= travelDistance)
        {
            Destroy(gameObject);
        }
        else
        {
            Vector3 movement = transform.forward * _travelSpeed * Time.fixedDeltaTime;
            _rb.MovePosition(_rb.position + movement);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        _collisonLogic(other);
    }
    private void OnTriggerStay(Collider other)
    {
        _collisonLogic(other);
    }
    private void OnTriggerExit(Collider other)
    { 
        _collisonLogic(other);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided!");
        _collisonLogic(collision.collider);
    }

    private void _collisonLogic(Collider other)
    {
        if (gameObject.IsDestroyed()) return;
        var collidedGameObj = other.gameObject;
        var collidedLayer = collidedGameObj.layer;
        if (collidedLayer != 3) // layer 3 = Player Layer. Derive this programmatically
        {
            if (collidedLayer == 6) // layer 6 = Enemy Layer. Derive this programmatically
            {
                Destroy(collidedGameObj);
            }
            Destroy(gameObject);
        }
    }
}
