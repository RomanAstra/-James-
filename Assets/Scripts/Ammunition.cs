using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Ammunition : BaseObjectScene
    {
        public bool _IsCollision = false;
        protected float _timeToDestroy = 10;
        /// <summary>
        /// Базовый урон
        /// </summary>
        protected float _baseDamage = 10;
        /// <summary>
        /// Текущий урон
        /// </summary>
        protected float _curDamage;

        /// <summary>
        /// Текущий урон
        /// </summary>
        public float CurDamage
        {
            get { return _curDamage; }
            set { _curDamage = value; }
        }


        protected override void Awake()
        {
            base.Awake();
            _curDamage = _baseDamage;
        }
        private void Start()
        {
            
        }

        public void AddForce(Vector3 dir)
        {
            if(!Rigidbody) return;
            Rigidbody.AddForce(dir);
        }
    }
}