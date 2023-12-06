using Basement.OEPFramework.UnityEngine;
using Basement.OEPFramework.UnityEngine.Loop;
using UnityEngine;

namespace Initial
{
   public class LoopsInitializer : MonoBehaviour
   {
      public void Initialize()
      {
         Loops.Init();
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
}
