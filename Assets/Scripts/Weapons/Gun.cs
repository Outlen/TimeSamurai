using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    //bullet
    public GameObject bullet;
    public float shootForce;

    //bools
    bool shooting, readyToShoot, reloading;
    public bool allowButtonHold;

    //Gun stats
    public float timeBetweenShooting, reloadTime, timeBetweenShots, spread;
    public int magSize, bulletsPerTap;
    int ammoLeft, ammoShot;




    // Start is called before the first frame update
    void Start()
    {
        ammoLeft = magSize;
        readyToShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        MyInput();
    }

    private void Shoot()
    {
        readyToShoot = false;   

        Vector3 shootDirection;
        shootDirection = Input.mousePosition;
        shootDirection.z = 0.0f;
        shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
        shootDirection = shootDirection-transform.position;

       //Spawn bullet at attack point
        GameObject currentBullet = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0,0,0)));

        //rotate the bullet to make it spread
        currentBullet.transform.Rotate(0f, 0f, spread);

        //launch the bullet
        Rigidbody2D rb = currentBullet.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(shootDirection.x * 5f, shootDirection.y * 5f);

        ammoLeft--;
        ammoShot--;

        //The gun can shoot again after some seconds
        Invoke("ResetShot", timeBetweenShooting);

        //the time between each projectile, i.e. having shotgun projectiles all fire at once
        if (ammoShot > 0 && ammoLeft > 0 && bulletsPerTap > 1)
        {
            Invoke("Shoot", timeBetweenShots);
        }
    }

    public void MyInput()
    {
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse1);
        else shooting = Input.GetKeyDown(KeyCode.Mouse1);

        //reload conditions
        if (Input.GetKey(KeyCode.R) && ammoLeft < magSize && !reloading)
        {
            Reload();
        } 
        
        //Shoot 
        if (readyToShoot && shooting && !reloading &&  ammoLeft > 0)
        {
            ammoShot = bulletsPerTap;
            Shoot();
        }
    }

    private void ResetShot()
    {
        readyToShoot = true;
    }

    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }

    private void ReloadFinished()
    {
        ammoLeft = magSize;
        reloading = false;
    }
}
