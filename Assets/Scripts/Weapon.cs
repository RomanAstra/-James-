using Assets.Scripts.Helpers;
using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Weapon : BaseObjectScene
    {
        [SerializeField] private Transform _bulletProjector;
        [SerializeField] protected Transform _barrelCamera;
        [SerializeField] protected float maxClip;
        [Space(20)]
        protected Quaternion _hitRotation;
        protected RaycastHit Hit;
        protected Timer timer = new Timer();
        protected InfoCollision _info;
        protected float _rechargeTime;
        protected float _holder;
        protected float _curHolder;
        protected float _standartHolder;
        protected float _maxDistance = 500;
        protected float _damage = 10;

        protected bool _IsReady = true;

        protected virtual void Awake()
        {
            _curHolder = _standartHolder;
            _holder = _curHolder;
        }

        protected virtual void Update()
        {
            timer.Update();
            if (timer.IsEvent())
            {
                _IsReady = true;
            }
        }
        /// <summary>
        /// "Выстрел"
        /// </summary>
        public virtual void Fire()
        {
            if (!_IsReady) return;
            if (_curHolder <= 0)
            {
                Reload();
            }

            if (_IsReady)
            {
                if (_barrelCamera != null && Physics.Raycast(_barrelCamera.position, _barrelCamera.forward, out Hit, _maxDistance))
                {
                    Debug.Log("Выстрел");
                    var tempObj = Hit.collider.GetComponent<ISetDamage>();
                    
                    if (tempObj!=null)
                    {
                        Debug.Log("Нашел ISetDamage");
                        tempObj.SetDamage(new InfoCollision(_damage, Hit, Hit.transform));

                        _IsReady = false;
                        timer.Start(_rechargeTime);
                        _curHolder--;
                        maxClip = _holder + _curHolder;
                    }
                }
                else
                {
                    Debug.Log("Мимо!");
                }
            }
        }
        /// <summary>
        /// Перезерядка
        /// </summary>
        protected virtual void Reload()
        {
            _IsReady = false;
            timer.Start(1);

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