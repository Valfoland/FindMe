using UnityEngine;

namespace Game.Creatures.Character
{
    public class CharacterTransform : ICharacterCommand
    {
        private const float TurnSmoothTime = 0.05f;
        
        private CharacterData _characterData;
        private float velocity;
        
        
        public CharacterTransform(CharacterData characterData)
        {
            _characterData = characterData;
        }

        public void DoAction()
        {
            var direction = new Vector3(Input.GetAxis("Horizontal"), 0,  Input.GetAxis("Vertical"));

            var angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + _characterData.CharacterCameraObject.transform.eulerAngles.y;
            var smoothAngle = Mathf.SmoothDampAngle(_characterData.transform.eulerAngles.y, angle, ref velocity, TurnSmoothTime);
            
            _characterData.transform.rotation = 
                Quaternion.Euler(0, smoothAngle, 0);

            var magnitude = Vector3.Magnitude(new Vector3(Input.GetAxis("Horizontal"), 0,  Input.GetAxis("Vertical")));

#if UNITY_EDITOR
            _characterData.Animator.SetFloat("BlendKoeff", magnitude);
#endif
        }
    }
}
