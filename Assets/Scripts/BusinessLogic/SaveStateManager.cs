using Utils.Threads;


namespace BusinessLogic
{
    public class SaveStateManager
    {
        private readonly IExecutor _savingExecutor = new SingleThreadExecutor();

        private bool _savingEnabled;
        

        public SaveStateManager()
        {
            _savingExecutor.Execute(SaveData).Run();
        }
        
        private void Attach()
        {
            
        }

        private void EnableSaving(bool enable)
        {
            _savingEnabled = enable;
        }
        
        private void SaveData()
        {
            if (!_savingEnabled) return;
            
            
        }
    }
}
