using Basement.BLFramework.Core.Context;
using Basement.OEPFramework.UnityEngine.Behaviour;
using Basement.OEPFramework.UnityEngine.Loop;
using fastJSON;
using Utils.Threads;


namespace BusinessLogic
{
    public class SaveStateManager : LoopBehaviour
    {
        private readonly PlayerContext _context;
        private readonly IExecutor _savingExecutor = new SingleThreadExecutor();
        private bool _savingEnabled;
        

        public SaveStateManager(PlayerContext context)
        {
            _context = context;
            LoopOn(Loops.UPDATE, OnUpdate);
        }
        
        public void Initialize()
        {
            
        }

        public override void Drop()
        {
            if (dropped)
            {
                return;
            }
            
            _savingExecutor.Shutdown();
            _savingExecutor.Join();
            
            base.Drop();
        }

        private void EnableSaving(bool enable)
        {
            _savingEnabled = enable;
        }
        
        private void OnUpdate()
        {
            if (!_savingEnabled) return;

            var serializedData = JSON.Instance.ToJSON(_context.Serialize());
            
            _savingEnabled = false;
            
            _savingExecutor.Execute(() => DataProvider.WritePlayerProgressData(serializedData)).Run();
        }
    }
}
