using Assets.Scripts.Helpers;
using GeekBrains.Helpers;
using UnityEngine;

namespace Assets.Scripts
{
    public class ObjectManager : MonoBehaviour
    {
        [SerializeField] private Weapon[] _weapons = new Weapon[2];
        [SerializeField] private ObjectPool<BulletProjector> _objectPool;
        
        public Weapon[] Weapons
        {
            get { return _weapons; }
        }

        private void Awake()
        {
            _weapons = FindObjectOfType<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>()
                .GetComponentsInChildren<Weapon>();
            if (_weapons != null)
            {
                foreach (var weapon in _weapons)
                {
                    weapon.SetActive(false);
                }
            }
        }
    }
}