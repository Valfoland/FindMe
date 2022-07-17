using System;
using Frameworks.OEPFramework.UnityEngine;
using Frameworks.OEPFramework.UnityEngine.Loop;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntryPoint : MonoBehaviour
{
   private bool _initialized;

   private void Awake()
   {
      if (!_initialized)
      {
         Loops.Init();
         _initialized = true;
      }

      SceneManager.LoadScene("Game");
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
}
