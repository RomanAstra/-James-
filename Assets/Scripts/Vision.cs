using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// Класс "Обзор" у бота. Содержит методы проверки на "видимость" и "слышимость"
    /// </summary>
    [System.Serializable]
    public class Vision
    {
        [SerializeField] public float DistanceOfView { get; private set; } = 20;
        [SerializeField] public float AngleOfView { get; private set; } = 30;
        /// <summary>
        /// Проверка дистанции от бота до игрока.
        /// </summary>
        /// <param name="bot"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        private bool _CheckDictanceOfView(Transform bot, Transform target)
        {
            var _distance = (bot.position - target.position).sqrMagnitude;
            return _distance <= DistanceOfView;
        }
        /// <summary>
        /// Проверка угла обзора бота.
        /// </summary>
        /// <param name="bot"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        private bool _CheckAngleOfView(Transform bot, Transform target)
        {
            var _angle = Vector3.Angle(-bot.forward, bot.position - target.position);
            return _angle <= AngleOfView;
        }
        /// <summary>
        /// Проверка - "слышит" БОТ игрока или нет.
        /// </summary>
        /// <param name="bot">позиция бота</param>
        /// <param name="player">позиция игрока</param>
        /// <returns></returns>
        public bool CheckHearing(Transform bot, Transform player)
        {
            return _CheckDictanceOfView(bot, player);
        }
        /// <summary>
        /// Проверка - "видит" БОТ игрока или нет.
        /// </summary>
        /// <param name="bot">позиция бота</param>
        /// <param name="player">позиция игрока</param>
        /// <returns></returns>
        public bool CheckVision(Transform bot, Transform player)
        {
            return CheckHearing(bot, player) && _CheckAngleOfView(bot, player);
        }
    }
}