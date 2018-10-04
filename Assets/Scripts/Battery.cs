using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// Класс "Батарейка"
    /// </summary>
    public class Battery : MonoBehaviour
    {
        public float Energy { get; set; }
        public bool IsEmpty { get; set; }
        public bool IsOn { get; set; }

        private void Awake()
        {
            Energy = 1f;
            IsEmpty = false;
            IsOn = false;
        }
        private void Update()
        {
            if (IsOn) Energy += Time.deltaTime;
            if (Energy <= 0)
            {
                IsEmpty = true;
                IsOn = false;
            }
        }
    }
}