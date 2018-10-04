using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// Класс "Фонарь"
    /// </summary>
    [System.Serializable]
    public class FlashLight : BaseObjectScene
    {
        [SerializeField] private Light _light;
        [SerializeField] private Battery _battery;

        public Battery GetBattery
        {
            get { return _battery; }
        }

        protected override void Awake()
        {
            _light = GetComponent<Light>();
            base.Awake();
        }

        private void Update()
        {
            if (_battery.IsEmpty) Switch(false);
        }
        /// <summary>
        /// Метод - переключает фонарь ВКЛ\ВЫКЛ
        /// </summary>
        public void Switch(bool value)
        {
            if (!_battery) return;
            if (!_light) return;
            if (!_battery.IsEmpty) _light.enabled = !value;
            _light.enabled = value;
            _battery.IsOn = value;
        }
    }
}