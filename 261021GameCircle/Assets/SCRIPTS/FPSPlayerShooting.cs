using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSPlayerShooting : MonoBehaviour
{
    #region References

    public FPSPlayerMovement ReferenceFPSPlayerMovement;
    public FPSAimAssistant ReferenceFPSAimAssistant;
    public FPSDetectiveManager ReferenceFPSDetectiveManager;
    public FPSAnimator ReferenceFPSAnimator;
    ItemManager ReferenceItemManager;
    public FPSGameManager ReferenceFPSGameManager;

    #endregion

    #region FPSPlayerShooting

    public float fireRate = 1f;
    public float nextFire = 0f;
    public string weaponName;
    public bool canShoot = false;

    public int currentAmmo;
    public int ammo;
    public int parameter = 0;

    /*public GameObject bulletPrefab;
    public GameObject casingPrefab;
    

    public Transform bulletSpawnPoint;
    public Transform casingSpawnPoint;*/

    public ParticleSystem muzzleFlash;
    //public ParticleSystem casingBullet;

    public LayerMask layerMask;
    public GameObject raycastPoint;
    public bool action = false;

    #endregion

    private void Start()
    {
        ReferenceItemManager = GameObject.FindWithTag("Pumpkin").GetComponent<ItemManager>();
        currentAmmo = ammo;
    }

    private void Update()
    {
        /*if(Input.GetMouseButton(0) && canShoot && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            ReferenceFPSAnimator.FPSPlayerAnimationSetBool("Shoot", true);
            Shoot();
        }*/
        /*if (Input.GetMouseButtonUp(0))
            ReferenceFPSAnimator.FPSPlayerAnimationSetBool("Shoot", false);
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReferenceFPSAnimator.FPSPlayerAnimationSetTrigger("Reload");
            _Reload();
        }*/
    }
    public void Shoot()
    {
        nextFire = Time.time + fireRate;
        ReferenceFPSAnimator.FPSPlayerAnimationSetBool("Shoot", true);
        UICanvas.instance.RemoveBulletIcon(parameter);
        parameter += 1;
        muzzleFlash.Play();
        //casingBullet.Play();

        RaycastHit hit;
        
        if(Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward),out hit, 50000F, layerMask))
        {
            
            Debug.Log(hit.transform.name);
            Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;


            Debug.DrawRay(transform.position, forward, Color.red);
            if (hit.transform.CompareTag("Pumpkin"))
            {
                ReferenceItemManager.TakeDamageToPumpkin(30);

                if (ReferenceItemManager.pumpkinHealth <= 0)
                {
                    ReferenceFPSPlayerMovement.killCount += 1;
                    ReferenceFPSPlayerMovement.tmp_killCount.text = ReferenceFPSPlayerMovement.killCount.ToString();
                    ReferenceFPSGameManager.IsPumpkinBroke = true;
                    Destroy(hit.transform.gameObject);
                    ReferenceItemManager.pumpkinHealth = 80;
                    parameter = 0;
                    ReferenceFPSDetectiveManager.AimAssistant = false;
                    Time.timeScale = 1f;
                    ReferenceFPSAnimator.FPSPlayerAnimationSetBool("Continue", true);
                    ReferenceFPSAnimator.FPSPlayerAnimationSetBool("TakeGun", false);
                    ReferenceFPSAimAssistant.parameterTowerList += 1;
                    ReferenceFPSGameManager.TimePanel.SetActive(false);
                    ReferenceFPSGameManager.timeBroke = 3;
                    ReferenceFPSGameManager.IsPumpkinBroke = false;
                }
            }
        }
    }
    public void ONPointerFire()
    {
         ReferenceFPSAnimator.FPSPlayerAnimationSetBool("Shoot", false);
    }
    public void _Reload()
    {
        StartCoroutine(Reload());
    }
    IEnumerator Reload()
    {

        ReferenceFPSAnimator.FPSPlayerAnimationSetTrigger("Reload");
        yield return new WaitForSecondsRealtime(.5f);
        UICanvas.instance.RemakeBulletIcon();
    }
}
