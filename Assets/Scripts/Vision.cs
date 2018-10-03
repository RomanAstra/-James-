using UnityEngine;

namespace Assets.Scripts
{
    [System.Serializable]
    public class Vision
    {
        [SerializeField] private float _distanceOfView = 20;
        [SerializeField] private float _angleOfView = 30;
        /// <summary>
        /// Проверка дистанции от бота до игрока.
        /// </summary>
        /// <param name="bot"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        private bool _CheckDictanceOfView(Transform bot,Transform target)
        {
            var _distance = (bot.position - target.position).sqrMagnitude;
            return _distance <= _distanceOfView;
        }
        /// <summary>
        /// Проверка угла обзора бота.
        /// </summary>
        /// <param name="bot"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        private bool _CheckAngleOfView(Transform bot, Transform target)
        {
            var _angle= Vector3.Angle(bot.forward, bot.position - target.position);
            return _angle <= _angleOfView;
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
            return _CheckAngleOfView(bot, player) && CheckHearing(bot, player);
        }
    }
}