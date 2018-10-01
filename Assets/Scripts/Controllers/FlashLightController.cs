using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class FlashLightController : BaseController
    {
        public FlashLight _FlashLight { get; set; }

        private void Awake()
        {
            _FlashLight = FindObjectOfType<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().GetComponentInChildren<FlashLight>();
        }
        
        public void On()
        {
            if (IsActive) return;
            base.On();
            _FlashLight.Switch(true);
        }

        public void Off()
        {
            if (!IsActive) return;
            base.Off();
            _FlashLight.Switch(false);
        }
    }
}