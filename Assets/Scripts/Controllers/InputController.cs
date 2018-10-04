using UnityEngine;
using Input = UnityEngine.Input;

namespace Assets.Scripts.Controllers
{
    /// <summary>
    /// Контроллер игрока, нажатие клавиш
    /// </summary>
    [System.Serializable]
    public class InputController : BaseController
    {
        [SerializeField] private int _weaponID = 2;
        private float _zoom;
        private bool _flashIsOn;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                _flashIsOn = !_flashIsOn;
                SelectFlashLight(_flashIsOn);
            }

            _zoom = Input.GetAxis("Mouse ScrollWheel");
            if (_zoom > 0 || _zoom < 0) SelectWeapon();

            if (Input.GetKeyDown(KeyCode.R))
            {
                
            }
        }

        private void SelectFlashLight(bool value)
        {
            if(Main.Instance.FlashLightController.FlashLight1.GetBattery.IsEmpty) return;
            if(value) Main.Instance.FlashLightController.On();
            if(!value) Main.Instance.FlashLightController.Off();
        }
        /// <summary>
        /// Метод "Выбор оружия"
        /// </summary>
        private void SelectWeapon()
        {
            Main.Instance.WeaponController.Off();
            CheckWeaponId();
            var tempWeapons = Main.Instance.ObjectManager.Weapons[_weaponID - 1];
            if (tempWeapons != null) Main.Instance.WeaponController.On(tempWeapons);
        }
        /// <summary>
        /// Вспомогательный метод
        /// </summary>
        private void CheckWeaponId()
        {
            _weaponID++;
            if (_weaponID > 2) _weaponID = 1;
            if (_weaponID < 1) _weaponID = 1;
        }
    }
}