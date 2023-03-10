using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SO_weaponData _WeaponDataSO;
    //[SerializeField] private GameObject weaponModel;
    [SerializeField] private Camera _cam;
    [SerializeField] private Transform BulletSpawnPoint;
    //public Animator _animator; Stil haven't figured out how animation works in unity engine.
    [Header("Particle System")]
    [SerializeField] private WeaponPartcieSystem_SO weaponParticleSystem;
    [SerializeField] private ParticleSystem bulletCasing;
    [SerializeField] private ParticleSystem MuzzleFlashParticle;
    //These values are automatically changed down in determineShootingType();
    [HideInInspector] public bool allowAimDownScope = false;//For Snipers and perhaps other types.
    [HideInInspector] public bool allowPelletFire = false;//For shotguns.
    //Logic bools.
    [HideInInspector] public bool reloading = false;
    [HideInInspector] public bool readyToShoot;
    [HideInInspector] public bool shooting = false;
    [HideInInspector] public int bulletsShot;
    private float LastShootTime;

    private void Awake()
    {
        readyToShoot = true;
        _WeaponDataSO.currentAmmo = _WeaponDataSO.magSize;
    }
    public void Shoot()
    {
        if(LastShootTime + _WeaponDataSO.ShootDelay < Time.time)
        {
            //Watch the tutorial on object pooling.
            //Animator.SetBool("IsShooting", true);
            MuzzleFlashParticle.Play();
            Vector3 direction = GetDirection();

            if (Physics.Raycast(_cam.transform.position, direction, out RaycastHit hit, float.MaxValue, _WeaponDataSO.Mask))
            {
                IDamagable damagable = hit.transform.GetComponent<IDamagable>();
                damagable?.Damage(_WeaponDataSO.damage);
                TrailRenderer trail = Instantiate(weaponParticleSystem.bulletTrail, BulletSpawnPoint.position, Quaternion.identity);
                StartCoroutine(SpawnTrail(trail, hit));
                LastShootTime = Time.time;
                if(hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * 30);
                }
            }
        }
        //SpawnBulletCasing();
    }
    public IEnumerator Reload()
    {   
        reloading = true;
        yield return new WaitForSeconds(_WeaponDataSO.reloadTime);
        _WeaponDataSO.currentAmmo = _WeaponDataSO.magSize;
        reloading = false;
    }
    private Vector3 GetDirection()
    {
        Vector3 direction = _cam.transform.forward;
        if (_WeaponDataSO.AddBulletSpread)
        {
            direction += new Vector3(
                Random.Range(-_WeaponDataSO.BulletSpread.x, _WeaponDataSO.BulletSpread.x),
                Random.Range(-_WeaponDataSO.BulletSpread.y, _WeaponDataSO.BulletSpread.y),
                Random.Range(-_WeaponDataSO.BulletSpread.z, _WeaponDataSO.BulletSpread.z));
            direction.Normalize();
        }
        return direction;
    }
    private IEnumerator SpawnTrail(TrailRenderer Trail, RaycastHit Hit)
    {
        float time = 0;
        Vector3 startPosition = Trail.transform.position;

        while (time < 1)
        {
            Trail.transform.position = Vector3.Lerp(startPosition, Hit.point, time);
            time += Time.deltaTime / Trail.time;
            yield return null;
        }
        //_animator.Play("Default");
        Trail.transform.position = Hit.point;
        SpawnImpact(Hit);

        Destroy(Trail.gameObject, Trail.time);
    }
    private void SpawnImpact(RaycastHit hit)
    {
        switch (hit.collider.tag)//One terrible backfire of this method is that I have to add 
        {                        //Each partciles by order every single time. Which is tedious.
            case "Footsteps/Metal":
                Instantiate(weaponParticleSystem.impactParticles[0],hit.point, Quaternion.LookRotation(hit.normal));
                break;
            case "Footsteps/Stone":
                Instantiate(weaponParticleSystem.impactParticles[1], hit.point, Quaternion.LookRotation(hit.normal));
                break;
            case "Footsteps/Wood":
                Instantiate(weaponParticleSystem.impactParticles[2], hit.point, Quaternion.LookRotation(hit.normal));
                break;
            case "Footsteps/Sand":
                Instantiate(weaponParticleSystem.impactParticles[3], hit.point, Quaternion.LookRotation(hit.normal));
                break;
            default:
                Debug.Log("Object you have hit doesn't have tags!");
                break;
        }
    }
    public void determineWeaponType()
    {
        switch (_WeaponDataSO.weaponType)
        {
            case SO_weaponData.weaponTypes.SniperRifle:
                allowAimDownScope = true;
                break;
            case SO_weaponData.weaponTypes.Shotgun:
                allowPelletFire = true;
                break;
            case SO_weaponData.weaponTypes.Pistol:
                break;
            default:
                Debug.Log("No property found, assigning Knife.");
                break;
        }
    }

    /*private void SpawnBulletCasing()
    {
        bulletCasing.Emit(1);
        //Instantiate(bulletCasing,BulletCasingSpawnPoint);
    }*/
}