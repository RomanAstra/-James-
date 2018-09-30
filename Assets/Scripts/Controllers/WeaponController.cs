using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class WeaponController : BaseController
    {
        private Weapon _weapon;
        
        private void Update()
        {
            if (!IsActive)
            {
                return;
            }
            if ((Input.GetMouseButton(0)))
            {
                _weapon.Fire();
            }
        }

        public void On(Weapon weapon)
        {
            if(IsActive) return;
            base.On();
            _weapon = weapon;
            _weapon.SetActive(true);

        }
        public void Off()
        {
            if (!IsActive) return;
            base.Off();
            _weapon.SetActive(false);
            _weapon = null;
        }
    }
}