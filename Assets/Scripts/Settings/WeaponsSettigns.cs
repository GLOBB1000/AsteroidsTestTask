using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "WeaponsSettings", order = 1)]
public class WeaponsSettigns : ScriptableObject
{
    [SerializeField]
    private List<WeaponSetting> weaponSettings;

    public List<WeaponSetting> WeaponSettings => weaponSettings;

    [System.Serializable]
    public struct WeaponSetting
    {
        public string Id;
        public float Damage;
        public float FireRate;

        public float Duration;

        public int CountOfFire;
    }
}
