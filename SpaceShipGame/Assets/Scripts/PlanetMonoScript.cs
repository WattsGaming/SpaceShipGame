using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMonoScript : MonoBehaviour
{
    public float spawnRate = 5f;
    public GameObject enemyShip;
    private float _lastSpawned;
    private Vector3 _spawnPos;

    // Start is called before the first frame update
    void Start()
    {
        var planetPos = transform.position;
        _spawnPos = new Vector3(planetPos.x, 0, planetPos.z);
        _lastSpawned = Time.unscaledTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.unscaledTime - _lastSpawned >= spawnRate)
        {
            var rightBullet = Instantiate(enemyShip, _spawnPos, transform.rotation);
            _lastSpawned = Time.unscaledTime;
        }
    }
}
