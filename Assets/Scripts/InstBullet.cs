using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstBullet : MonoBehaviour
{
    public GameObject bullet;
    public GameObject efectsFire;
    public GameObject tank;
    public Transform firePlase;
    public float gunReload = 1.5f;
    public float forceRecoil = 10000f;

    private bool isFire = false;
    private Rigidbody RbTank;

    void Start()
    {
         RbTank = tank.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && !isFire)
        {
            Instantiate(bullet, firePlase.position, firePlase.rotation);
            GameObject PSFire = Instantiate(efectsFire, firePlase.position, Quaternion.identity);
            RbTank.AddRelativeForce(Vector3.back * forceRecoil);
            isFire = true;
            Invoke("GunReload", gunReload);
            Destroy(PSFire, 5f);
        } 
    }

    private void GunReload()
    {
        isFire = false;
    }
}
