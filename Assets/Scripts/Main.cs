using System;
using Assets.Scripts.Controllers;
using Assets.Scripts.Helpers;
using UnityEngine;
using FlashLightController = Assets.Scripts.Controllers.FlashLightController;

namespace Assets.Scripts
{
    public class Main : MonoBehaviour   
    {
        private GameObject _allControllers;

        public InputController InputController { get; private set; }
        public WeaponController WeaponController { get; private set; }
        public ObjectManager ObjectManager { get; private set; }
        public FlashLightController FlashLightController { get; private set; }
        
        public static Main Instance { get; private set; }

        private void Awake()
        {
            Instance = this;

            _allControllers = new GameObject("All_Controllers");
            InputController = _allControllers.AddComponent<InputController>();
            WeaponController = _allControllers.AddComponent<WeaponController>();
            ObjectManager = _allControllers.AddComponent<ObjectManager>();
            FlashLightController = _allControllers.AddComponent<FlashLightController>();
        }
    }
}