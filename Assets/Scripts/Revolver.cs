using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolver : MonoBehaviour
{
    //make the gun simply shoot the prefab bullet
    //add a script to the bullet to control what happens after it leaves the gun
    //reloading with the object
    //add rotating the barrel after each shot
    //bulletSpawnPos
    //disable each bullet in the revolvers chamber after each shot

    [Header("Setup")]
    public GameObject bulletPrefab;
    public float bulletSpeed = 20f;
    public Transform bulletSpawnPos;

    public GameObject[] bulletsInChamber; //This is in the correct order so it goes clockwise
        
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //fire the bullet
            GameObject bulletClone = Instantiate(bulletPrefab, bulletSpawnPos.position, bulletSpawnPos.rotation) ;
            
            //disable the bullet

           //use the clip amount for this
           //then after firing every bullet, disable the bullet in the chamber and spin the barrel
           //once the clip reaches 0, reload and enable all the bullets in the chamber again

            //bulletsInChamber[0].SetActive(false);    
            
            //add force to the bullet
            bulletClone.GetComponent<Rigidbody>().AddForce(bulletClone.transform.forward * bulletSpeed,ForceMode.Impulse);
        }        
    }
}
