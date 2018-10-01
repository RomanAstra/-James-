using UnityEngine;

namespace Assets.Scripts
{
    public class Battery : MonoBehaviour
    {
        [SerializeField] public float Energy { get; set; }
        [SerializeField] public bool IsEmpty { get; set; }
        [SerializeField] public bool IsOn { get; set; }

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