using UnityEngine;

[CreateAssetMenu(fileName = "BulletManager", menuName = "ScriptableObj/BulletManager")]
public class BulletManager: ScriptableObject
{
    public GameObject bullet;
    public float fireRate;
    public float baseSpeed;
    public float shipSpeed;
    private float _lastFired;
    private void OnEnable()
    {
        _lastFired = Time.unscaledTime;
        if (fireRate <= 0f)
        {
            Debug.LogWarning("Invalid fire rate! " +  fireRate.ToString("0.00"));
            fireRate = 0.01f;
        }
    }

    public float getBulletSpeed()
    {
        return baseSpeed + shipSpeed;
    }
 
    public void shootBullet(Transform transform, float shipSpeed)
    {
        float timeFired = Time.unscaledTime;
        //Debug.Log(string.Format("Time Fired: {0}, Last Fired: {1}", timeFired, _lastFired));
        if(timeFired - _lastFired > 1f/fireRate)
        {
            Vector3 inputPos = transform.position;
            Vector3 rightSpawn = transform.position + transform.right * 5;
            Vector3 leftSpawn = transform.position + transform.right * -5;
            var rightBullet = Instantiate(bullet, rightSpawn, transform.rotation);
            var leftBullet = Instantiate(bullet, leftSpawn, transform.rotation);

            _lastFired = timeFired;
        }
    }
}