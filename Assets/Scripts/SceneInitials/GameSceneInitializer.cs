using Game.Creatures.Character;



namespace SceneInitials
{
    public class GameSceneInitializer : SceneInitializer
    {
        private CharacterCreator _characterCreator;

        
        private void OnDestroy()
        {
            _characterCreator.Drop();
        }


        protected override void InitializeServices()
        {
            
        }


        protected override void Initialize()
        {
            //_characterCreator = new CharacterCreator();
            //_characterCreator.Create();
        }
    }
}