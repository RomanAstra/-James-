﻿using UnityEngine;

namespace Assets.Scripts.Controllers
{
    [System.Serializable]
    public abstract class BaseController : MonoBehaviour
    {
        public bool IsActive { get; set; }

        public virtual void On()
        {
            IsActive = true;
        }

        public virtual void Off()
        {
            IsActive = false;
        }
    }
}