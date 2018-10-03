using Assets.Scripts.Helpers;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts
{
    [System.Serializable]
    public class Patrol
    {
        private Transform _bot;
        private Transform _player;
        private NavMeshAgent _agent;
        private Timer _timer;
        /// <summary>
        /// дистанция "остановки" бота.
        /// </summary>
        [SerializeField] private float _stoppingDist = 2;
        /// <summary>
        /// Массив точек для патруля.
        /// </summary>
        private Transform[] _points;
        /// <summary>
        /// Проверка - патрулирует территорию или нет.
        /// </summary>
        public bool IsPatrol { get; private set; }
        /// <summary>
        /// Проверка - преследует игрока или нет.
        /// </summary>
        public bool IsAngry { get; private set; }
        /// <summary>
        /// Порядковый номер "цели" патруля.
        /// </summary>
        private int _numberOfTarget;
        private Vision _vision;

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
            _timer = new Timer();

            IsAngry = false;
            IsPatrol = true;
        }

        public void Update()
        {
            Patrolling();
            CheckTheStates();
        }
        /// <summary>
        /// Проверка состояний патрулирования.
        /// </summary>
        private void CheckTheStates()
        {
            if (IsPatrol && !_agent.hasPath)
            {
                Debug.Log("Таймер - время пошло");
                _timer.Start(1);
                IsPatrol = false;
            }
            if (_timer.IsEvent())
            {
                Debug.Log("Таймер - время вышло");
                _numberOfTarget++;
                IsPatrol = true;
            }

            if (_numberOfTarget >= 4) _numberOfTarget = 0;

            IsAngry = _vision.CheckVision(_bot, _player);
            if (IsAngry)
            {
                IsPatrol = false;
            }
        }
        /// <summary>
        /// Метод "Патруль".
        /// </summary>
        private void Patrolling()
        {
            _agent.stoppingDistance = _stoppingDist;
            if (IsPatrol && _points != null)
            {
                Debug.Log("Бот - Иду до точки" + _points[_numberOfTarget].name);
                _agent.SetDestination(_points[_numberOfTarget].position);
            }
            if (IsAngry)
            {
                Debug.Log("Нашел Игрока!");
                _agent.SetDestination(_player.position);
            }
        }
        private float CheckDistance(Transform one, Transform two)
        {
            return (one.position - two.position).sqrMagnitude;
        }
    }
}