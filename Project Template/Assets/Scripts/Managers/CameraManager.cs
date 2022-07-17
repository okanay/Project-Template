using UnityEngine;

    public class CameraManager : CostumBehaviour
    {
        public Camera mainCamera;
        private void Start()
        {
           mainCamera = Camera.main;
        }
        
    }

