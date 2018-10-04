using UnityEngine;

namespace Assets.Scripts.Controllers
{
    /// <summary>
    /// Контроллер фонаря
    /// </summary>
    [System.Serializable]
    public class FlashLightController : BaseController
    {
        [SerializeField] private FlashLight _flashLight;

        public FlashLight FlashLight1
        {
            get { return _flashLight; }
            set { _flashLight = value; }
        }

        private void Awake()
        {
            _flashLight = FindObjectOfType<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().GetComponentInChildren<FlashLight>();
        }
        /// <summary>
        /// Метод ВКЛ.
        /// </summary>
        public void On()
        {
            if (IsActive) return;
            base.On();
            if (FlashLight1 != null) FlashLight1.Switch(true);
        }
        /// <summary>
        /// Метод ВЫКЛ.
        /// </summary>
        public void Off()
        {
            if (!IsActive) return;
            base.Off();
            if (FlashLight1 != null) FlashLight1.Switch(false);
        }
    }
}