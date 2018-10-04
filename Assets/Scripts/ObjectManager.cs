using Assets.Scripts.Helpers;
using GeekBrains.Helpers;
using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// Менеджеробъектов на сцене
    /// </summary>
    [System.Serializable]
    public class ObjectManager : MonoBehaviour
    {
        [SerializeField] private Weapon[] _weapons = new Weapon[2];
        
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