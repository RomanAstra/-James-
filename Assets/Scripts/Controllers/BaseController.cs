using UnityEngine;

namespace Assets.Scripts.Controllers
{
    /// <summary>
    /// Базовый контроллер
    /// </summary>
    [System.Serializable]
    public abstract class BaseController : MonoBehaviour
    {
        /// <summary>
        /// Проверка - активен ли объект
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Базовый ВКЛ
        /// </summary>
        public virtual void On()
        {
            IsActive = true;
        }
        /// <summary>
        /// Базовый ВЫКЛ
        /// </summary>
        public virtual void Off()
        {
            IsActive = false;
        }
    }
}