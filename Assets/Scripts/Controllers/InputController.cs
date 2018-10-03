using UnityEngine;
using Input = UnityEngine.Input;

namespace Assets.Scripts.Controllers
{
    public class InputController : BaseController
    {
        [SerializeField] private float _zoom;
        [SerializeField] private int _weaponID = 2;
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
        }

        private void SelectFlashLight(bool value)
        {
            if(Main.Instance.FlashLightController._FlashLight.GetBattery.IsEmpty) return;
            if(value) Main.Instance.FlashLightController.On();
            if(!value) Main.Instance.FlashLightController.Off();
        }

        private void SelectWeapon()
        {
            Main.Instance.WeaponController.Off();
            CheckWeaponId();
            var tempWeapons = Main.Instance.ObjectManager.Weapons[_weaponID - 1];
            if (tempWeapons != null) Main.Instance.WeaponController.On(tempWeapons);
        }
        private void CheckWeaponId()
        {
            _weaponID++;
            if (_weaponID > 2) _weaponID = 1;
            if (_weaponID < 1) _weaponID = 1;
        }
    }
}