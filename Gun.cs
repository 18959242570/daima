using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform muzzle;
    public ProjectTiel projectile;
    public float msBetweenShots = 100;
    public float muzzleVelocity = 35;
    float nextShotTime;
    public void Shoot()
    {
        if (Time.time > nextShotTime)
        {
            nextShotTime = Time.time + msBetweenShots / 1000;
            ProjectTiel newProjectile = Instantiate(projectile, muzzle.position, muzzle.rotation) as ProjectTiel;
            newProjectile.SetSpeed(muzzleVelocity);
        }
        
    }
}
