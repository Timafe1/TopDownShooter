using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;
    public Transform Firepoint;

    public float fireForce;

   
    // Start is called before the first frame update

    public void Fire()
    {
        GameObject projectile = Instantiate(bullet, Firepoint.position, Firepoint.rotation);
        projectile.GetComponent<Rigidbody2D>().AddForce(Firepoint.up * fireForce, ForceMode2D.Impulse);
            
    }

    
 
}
