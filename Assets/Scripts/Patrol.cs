using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts
{
    [System.Serializable]
    public class Patrol
    {
        /// <summary>
        /// Подсчет дистанции до игрока.
        /// </summary>
        [SerializeField] private float _distance;

        private Transform _bot;
        private Transform _player;
        private NavMeshAgent _agent;
        /// <summary>
        /// дистанция "остановки" бота.
        /// </summary>
        private float _stoppingDist = 2;
        /// <summary>
        /// Массив точек для патруля.
        /// </summary>
        private Transform[] _points;

        /// <summary>
        /// Проверка - патрулирует территорию или нет.
        /// </summary>
        public bool IsPatrol { get; private set; } = true;
        /// <summary>
        /// Проверка - "ВИЖУ" игрока или нет.
        /// </summary>
        public bool IsSawThePlayer { get; private set; }
        /// <summary>
        /// Проверка - "Слышу" игрока или нет.
        /// </summary>
        public bool IsHearingThePlayer { get; private set; }
        /// <summary>
        /// Порядковый номер "цели" патруля.
        /// </summary>
        private int _numberOfTarget;
        [SerializeField] private Vision _vision;

        /// <summary>
        /// Класс "Патруль"
        /// </summary>
        /// <param name="points">массив точек патруля</param>
        /// <param name="player">'Transform' игрока</param>
        /// <param name="bot">'Transform' бота</param>
        public Patrol(Transform[] points, Transform player, Transform bot)
        {
            _numberOfTarget = 0;
            _vision = new Vision();
            _points = points;
            _player = player;
            _bot = bot;
            _agent = _bot.GetComponent<NavMeshAgent>();
            _agent.stoppingDistance = _stoppingDist;
        }
        public void Update()
        {
            CheckTheStates();
        }


        /// <summary>
        /// Метод проверки дистанции между двумя 'Transform'
        /// </summary>
        /// <param name="one">первый 'Transform'</param>
        /// <param name="two">второй 'Transform'</param>
        /// <returns></returns>
        private float CheckDistance(Transform one, Transform two)
        {
            return (one.position - two.position).sqrMagnitude;
        }
        /// <summary>
        /// Метод "Патруль".
        /// </summary>
        public IEnumerator Patrolling()
        {
            if (_numberOfTarget >= _points.Length)
            {
                _numberOfTarget = 0;
            }

            if (CheckDistance(_bot, _points[_numberOfTarget]) <= _stoppingDist)
            {
                _numberOfTarget++;
                IsPatrol = true;
            }

            if (IsPatrol)
            {
                for (int i = _numberOfTarget; i < _points.Length;)
                {
                    if (i >= _points.Length) i = 0;

                    _agent.SetDestination(_points[_numberOfTarget].position);
                    Debug.Log("Бот - Иду до точки" + _points[_numberOfTarget].name);
                    IsPatrol = false;
                    yield break;
                }
            }
        }

        public IEnumerator Alert()
        {
            if (IsHearingThePlayer)
            {
                Debug.Log("Бот - Слышу Игрока");
                IsPatrol = false;
                _bot.transform.Rotate(_bot.rotation.x, -3f, _bot.transform.rotation.z);
                yield break;
            }
            if (!IsHearingThePlayer && !IsPatrol)
            {
                Debug.Log("Бот - Потерял Игрока");
                IsPatrol = true;
                IsSawThePlayer = false;
                yield break;
            }
        }

        public IEnumerator Attacking()
        {
            if (IsSawThePlayer)
            {
                Debug.Log("Бот - Вижу Игрока");
                _agent.SetDestination(_player.position);
                yield break;
            }
        }
        /// <summary>
        /// Проверка состояний патрулирования.
        /// </summary>
        private void CheckTheStates()
        {
            IsHearingThePlayer = _vision.CheckHearing(_bot, _player);
            if (IsHearingThePlayer)
            {
                IsSawThePlayer = _vision.CheckVision(_bot, _player);
            }

            _distance = CheckDistance(_bot, _player);
        }
    }
}