using UnityEngine;

public class PlayerHandleWeapon : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GunScript[] GunScripts;//All gun scripts, terrible way to implement multiple weapons. Gotta find a better way.
    [SerializeField] SO_weaponData[] weaponSO;//All weapons scritptable objects.

    [HideInInspector] private SO_weaponData currentWeaponSO;
    [HideInInspector] public GunScript CurrentGunScript;
    //DropWeapon _WeaponDrop;
    private WeaponSwitching _weaponSwitch;
    AudioSource m_AudioSource;
    //InputManager _inputManager;
   
    private void Awake()
    {
        //_inputManager = FindObjectOfType<InputManager>();
        _weaponSwitch = FindObjectOfType<WeaponSwitching>();
        m_AudioSource = FindObjectOfType<AudioSource>();
        //_WeaponDrop = FindObjectOfType<DropWeapon>();
       
    }
    private void Update()
    {
        determineCurrentWeapon();
        CurrentGunScript.determineWeaponType();
        //MyInput();
    }
    //private bool hasAmmo => currentWeaponSO.currentAmmo > 0;
    private bool notReloading => !CurrentGunScript.reloading;//Change this to enum.
    private bool readyToShoot => CurrentGunScript.readyToShoot;
    private bool shooting => CurrentGunScript.shooting;//Change this to enum.
    private bool shotgunMode => CurrentGunScript.allowPelletFire;//Unfortunately I had to add this as a function in PlayerShoot instead of GunScript. Find a way to implement this into gunscript. 
    private bool weaponIsEmpty => currentWeaponSO.currentAmmo == 0;
    private bool weaponHasBeenShot => currentWeaponSO.currentAmmo != currentWeaponSO.magSize;

    /*private void MyInput()
    {
        CurrentGunScript.shooting = Input.GetKey(_inputManager.fireKey);

        if (readyToShoot && shooting && notReloading && hasAmmo && !shotgunMode)
        {
            CurrentGunScript.bulletsShot = currentWeaponSO.bulletsPerTap;
            OnShoot();
        }
        /*if (shotgunMode && shooting && hasAmmo && readyToShoot)
        {
            shotgunShoot();
            Debug.Log("Weapon is a shotgun!");
        }
        if (Input.GetKeyDown(_inputManager.dropKey) && this._WeaponDrop.equipped) _WeaponDrop.dropWeapon();
        //if (Input.GetKeyDown(_inputManager.dropKey) && weaponEquipped) _WeaponDrop.dropWeapon();
        //if (!weaponEquipped && _WeaponDrop.weaponInRange && !_WeaponDrop.slotFull) _WeaponDrop.PickUp();
        if (Input.GetKeyDown(_inputManager.Reload) &&  weaponHasBeenShot || weaponIsEmpty  && notReloading) DoReload();
    }*/

    private void OnShoot()
    {
        Shoot();
        WeaponShotsSound();
        CurrentGunScript.readyToShoot = false;
        --currentWeaponSO.currentAmmo;
        --CurrentGunScript.bulletsShot;

        Invoke("ResetShot", currentWeaponSO.timeBetweenShooting);//Added later,you can comment or delete it out.

        if (CurrentGunScript.bulletsShot > 0 && currentWeaponSO.bulletsPerTap > 0)
        {
            Invoke("OnShoot", currentWeaponSO.timeBetweenShots);//New Variant.
        }
    }

    /*private void shotgunShoot()
    {
        //Shoot();
        WeaponShotsSound();
        CurrentGunScript.readyToShoot = false;
        --currentWeaponSO.currentAmmo;
        --CurrentGunScript.bulletsShot;

        Invoke("ResetShot", currentWeaponSO.timeBetweenShooting);
    }*/
    private void Shoot()//Local shoot method.
    {
        CurrentGunScript.Shoot();
    }

    private void ResetShot()
    {
        CurrentGunScript.readyToShoot = true;
    }

    private void DoReload()
    {
        if (!CurrentGunScript.reloading)
        {
            StartCoroutine(CurrentGunScript.Reload());
            ReloadSounds();
        }
        CurrentGunScript.readyToShoot = true;
    }
    private void WeaponShotsSound()
    {
        if (currentWeaponSO.currentAmmo < currentWeaponSO.lowAmmo)
        {
            m_AudioSource.PlayOneShot(currentWeaponSO.lowAmmoShotSounds[Random.Range(0, currentWeaponSO.lowAmmoShotSounds.Length - 1)]);
        }
        m_AudioSource.PlayOneShot(currentWeaponSO.ShotSounds[Random.Range(0, currentWeaponSO.ShotSounds.Length - 1)]);
    }
    private void ReloadSounds()
    {
        m_AudioSource.clip = currentWeaponSO.reloadSounds;
        m_AudioSource.Play();
    }
    private void determineCurrentWeapon()
    {
        switch (_weaponSwitch.selectedWeapon)
        {
            case 0:
                currentWeaponSO = weaponSO[0];
                CurrentGunScript = GunScripts[0];
                break;
            case 1:
                currentWeaponSO = weaponSO[1];
                CurrentGunScript = GunScripts[1];
                break;
            default:
                currentWeaponSO = weaponSO[2];
                CurrentGunScript = GunScripts[2];
                break;
        }
    }
}
