using Assets.Scripts.Helpers;
using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Weapon : BaseObjectScene
    {
        [SerializeField] private Transform _bulletProjector;
        [SerializeField] protected Transform _barrelCamera;
        [SerializeField] protected float maxClip;
        /// <summary>
        /// 'Quaternion'-значение. Вращение луча выстрела
        /// </summary>
        [Space(20)]
        protected Quaternion _hitRotation;
        /// <summary>
        /// Луч "Выстрела"
        /// </summary>
        protected RaycastHit Hit;
        protected Timer timer = new Timer();
        /// <summary>
        /// Информация об оружии
        /// </summary>
        protected InfoCollision _info;
        /// <summary>
        /// Время, промежуток между выстрелами
        /// </summary>
        protected float _rechargeTime;
        /// <summary>
        /// Общая обоима
        /// </summary>
        protected float _holder;
        /// <summary>
        /// Текущая обоима
        /// </summary>
        protected float _curHolder;
        /// <summary>
        /// "Стандартная" для каждого класса оружия величина обоимы
        /// </summary>
        protected float _standartHolder;
        /// <summary>
        /// Дистанция луча "Выстрела"
        /// </summary>
        protected float _maxDistance = 500;
        /// <summary>
        /// Величина урона
        /// </summary>
        protected float _damage = 10;
        /// <summary>
        /// Проверка, готово ли оружие к "Выстрелу"
        /// </summary>
        protected bool _IsReady = true;

        protected virtual void Awake()
        {
            _curHolder = _standartHolder;
            _holder = _curHolder;

            _info = new InfoCollision(_damage, new RaycastHit(), _barrelCamera);
        }
        protected virtual void Update()
        {
            if (_curHolder > 0)
            {
                timer.Update();
                if (timer.IsEvent())
                {
                    _IsReady = true;
                }
            }
                
            if(_curHolder <= 0)
            {
                _IsReady = false;
            }
        }


        /// <summary>
        /// "Выстрел"(базовый)
        /// </summary>
        public virtual void Fire()
        {
            if (!_IsReady) return;

            if (_IsReady)
            {
                if (_barrelCamera != null && Physics.Raycast(_barrelCamera.position, _barrelCamera.forward, out Hit, _maxDistance))
                {
                    Debug.Log("Выстрел");
                    if (Hit.transform.GetComponentInChildren<Collider>())
                    {
                        Quaternion _hitRotation = Quaternion.FromToRotation(Hit.normal, -_barrelCamera.position);
                        Instantiate(_bulletProjector, Hit.point + Hit.normal * 0.2f, _hitRotation);
                    }
                    _IsReady = false;
                    timer.Start(_rechargeTime);
                    _curHolder--;
                    maxClip = _holder + _curHolder;
                }
                else
                {
                    Debug.Log("Мимо!");
                }
            }
        }
        /// <summary>
        /// Перезерядка(базовая)
        /// </summary>
        public virtual void Reload()
        {
            _holder -= _curHolder;
            if (_holder > _standartHolder)
            {
                _holder -= _standartHolder;
                _curHolder = _standartHolder;
                return;
            }
            _curHolder = _holder;
            _holder -= _curHolder;
        }

    }
}