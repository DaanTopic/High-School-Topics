using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sentryGun : MonoBehaviour
{
    // Start is called before the first frame update
    public float attackRange = 30.0f;
    public float shootAngleDistance = 10.0f;
    public GameObject target;
    [SerializeField] private Transform pfBulletProjectile;
    [SerializeField] private Transform spawnBulletPosition;
    private float reloadTime, currentTime;

    private void Start()
    {
        reloadTime = Time.time;
    }
    void Update()
    {
        currentTime = Time.time;
        if (target == null || !target.activeSelf)
        {
            target = GameObject.FindWithTag("Zombie");
        }
        if (target == null) return;
        //if (!CanSeeTarget()) return;

        var targetPoint = target.transform.position;
        var targetRotation = Quaternion.LookRotation(targetPoint - transform.position, Vector3.up);
        targetPoint = new Vector3(0, 15f, 0) + targetPoint;
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 2.0f);

        Vector3 aimDir = (transform.position - target.transform.position).normalized;
        aimDir *= -1;
        if(currentTime > reloadTime + 0.3f) 
        {
            reloadTime = currentTime;
            Instantiate(pfBulletProjectile, spawnBulletPosition.position, Quaternion.LookRotation(aimDir, Vector3.up));
        }
    }
    bool CanSeeTarget()
    {
        if (Vector3.Distance(transform.position, target.transform.position) > attackRange)
            return false;

        RaycastHit hit;
        if (Physics.Linecast(transform.position, target.transform.position, out hit))
            return hit.transform == target;

        return false;
    }
}