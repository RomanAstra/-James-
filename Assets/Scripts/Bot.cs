using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts
{
    /// <summary>
    /// Класс 'Bot'
    /// </summary>
    public class Bot : BaseObjectScene, ISetDamage
    {
        [SerializeField] private Transform _targetPlayer;
        [Space(10)]
        [SerializeField] private Transform _point1;
        [SerializeField] private Transform _point2;
        [SerializeField] private Transform _point3;
        [SerializeField] private Transform _point4;
        private Transform[] _targetPoints;

        [SerializeField] private Patrol _patrol;
        private float _hp;
        /// <summary>
        /// Проверка на "смерть".
        /// </summary>
        private bool _isDeath;
        
        #region Properties

        public float Hp
        {
            get { return _hp; }
            set { _hp = value; }
        }

        public bool IsDeath
        {
            get { return _isDeath; }
            set { _isDeath = value; }
        }

        #endregion

        private void Awake()
        {
            _targetPoints = new Transform[4] { _point1, _point2, _point3, _point4 };
            _patrol = new Patrol(_targetPoints, _targetPlayer, transform);
            Hp = 50;
            IsDeath = false;
        }
        private void Update()
        {
            _patrol.Update();
            StartCoroutine(_patrol.Patrolling());
            StartCoroutine(_patrol.Alert());
            StartCoroutine(_patrol.Attacking());
        }


        /// <summary>
        /// Метод "Получение урона".
        /// </summary>
        /// <param name="info">от "чьей" руки</param>
        public void SetDamage(InfoCollision info)
        {
            Hp -= info.Damage;
            if (Hp <= 0)
            {
                IsDeath = true;
                Death(info);
            }
        }
        /// <summary>
        /// Метод "Смерть".
        /// </summary>
        /// <param name="info">от "чьей" руки</param>
        private void Death(InfoCollision info)
        {
            foreach (Transform child in transform)
            {
                if (!Rigidbody)
                {
                    child.gameObject.AddComponent<Rigidbody>();
                }
                child.parent = null;
                Rigidbody.AddForceAtPosition(info.Dir * 10, info.Hit.point);
            }
        }
    }
}