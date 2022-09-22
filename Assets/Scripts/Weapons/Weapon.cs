using Core;
using UnityEngine;

namespace Weapons
{
    public abstract class Weapon : MonoBehaviour, IWeapon
    {
        [SerializeField]
        private WeaponsSettigns weaponsSettigns;

        [SerializeField]
        private string id;

        protected float cooldown;

        public WeaponsSettigns.WeaponSetting currentWeapon;

        public string Id { get => id; set => Id = value; }

        protected abstract void Shoot();

        protected void Initialize()
        {
            currentWeapon = weaponsSettigns.WeaponSettings.Find(x => x.Id == Id);
        }

        // Start is called before the first frame update
        protected virtual void Start()
        {
            Initialize();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
