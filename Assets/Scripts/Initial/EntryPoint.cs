using Basement.OEPFramework.UnityEngine;
using Basement.OEPFramework.UnityEngine.Loop;
using System;
using UnityEngine;


namespace Initial
{
   public class EntryPoint : MonoBehaviour
   {
      private AppStart _appStart;
      private bool _initialized;

      private void Awake()
      {
         if (!_initialized)
         {
            Loops.Init();
            _initialized = true;
         }

         _appStart = new AppStart();
      }

      private void FixedUpdate()
      {
         EngineLoopManager.Execute(Loops.FIXED_UPDATE);
      }
        
      private void Update()
      {
         var deltaTime = Time.deltaTime;
           
         Timer.Process(Loops.TIMER, deltaTime);
         EngineLoopManager.Execute(Loops.UPDATE);
      }

      private void LateUpdate()
      {
         EngineLoopManager.Execute(Loops.LATE_UPDATE);
      }


      private void OnApplicationQuit()
      {
         _appStart.Drop();
      }
   }
}
