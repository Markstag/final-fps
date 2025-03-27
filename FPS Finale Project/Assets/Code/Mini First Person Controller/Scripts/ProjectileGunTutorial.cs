using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProjectileGunTutorial : MonoBehaviour
{
  public GameObject bullet;

  public float shootForce, upwardForce;

  public float timeBetweenShooting, spread, relodeTime, timeBetweenShots;
  public int magazineSize, bulletPerTap;
  public bool allowButtonHold;

  int bulletsLeft, bulletsShot ;

   bool shooting, readyToShoot, reloading;

   public Camera fpsCam;
   public Transform attackPoint;

   public GameObject muzzleFlash;
   public TextMeshProUGUI ammunitionDisplay;

   public bool allowInvoke = true;

    private void Awake()
    {
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }

    private void Update()
    {
        MyInput();

        if (ammunitionDisplay != null);
            ammunitionDisplay.SetText(bulletsLeft / bulletPerTap + " / " + magazineSize / bulletPerTap);
    }

    private void MyInput()
    {
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading) Reload();

        if (readyToShoot && shooting && !reloading && bulletsLeft <=0) Reload();

        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            bulletsShot = 0;
            Shoot();
        } 

       
    }
  private void Shoot()
  {
    readyToShoot = false;

    Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
    RaycastHit hit;

    Vector3 targetPoint;
    if (Physics.Raycast(ray, out hit))
        targetPoint = hit.point;
    else
        targetPoint = ray.GetPoint(75); 

        Vector3 directionWithoutSpread = targetPoint - attackPoint.position;

        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread); 

        Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0);

        GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity);

        currentBullet.transform.forward = directionWithSpread.normalized;

        currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);
        currentBullet.GetComponent<Rigidbody>().AddForce(fpsCam.transform.up * upwardForce, ForceMode.Impulse);

        if(muzzleFlash !=null)
            Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);

    bulletsLeft--;
    bulletsShot++;

    if(allowInvoke)
    {
        Invoke("ResetShot" , timeBetweenShooting);
        allowInvoke = false;
    }
  }

    private void ResetShot()
    {
        readyToShoot = true;
        allowInvoke = true;
    }

    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", relodeTime);
    }

    private void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;
    }
}
