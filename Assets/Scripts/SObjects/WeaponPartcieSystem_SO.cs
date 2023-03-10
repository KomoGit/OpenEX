using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This object should be created just once, until i find a better way to implement this it will stay like this.
//Purpose of this scriptable object is to contain particles that mostly stay the same between weapons.
[CreateAssetMenu(fileName = "WeaponParticleSystem", menuName = "Weapon/WeaponParticleSystem")]
public class WeaponPartcieSystem_SO : ScriptableObject
{
    public ParticleSystem[] impactParticles = default;
    public TrailRenderer bulletTrail = default;
}
