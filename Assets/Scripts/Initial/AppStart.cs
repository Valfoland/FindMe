using System;
using UnityEngine;
using Zenject;


namespace Initial
{
    public class AppStart : MonoBehaviour
    {
        private void Start()
        {
            
        }


        [Inject]
        public void Construct(DiContainer container)
        {
            Debug.LogError(container);
        }
    }
}
