using UnityEngine;

namespace Game.Creatures.Character
{
    public class CharacterCamera : ICharacterCommand
    {
        private const float RotationSpeed = 4f;
        
        private Vector3 _offset;
        private CharacterData _characterData;

        private float _cameraRotationX;
        private float _cameraRotationY;
        private float _delay;
        
        public CharacterCamera(CharacterData characterData)
        {
            _characterData = characterData;
            
            _offset = _characterData.CharacterCameraObject.transform.localPosition;
            _cameraRotationY = _characterData.CharacterCameraObject.transform.eulerAngles.y;
            _cameraRotationX = _characterData.CharacterCameraObject.transform.eulerAngles.x;
        }
    
        public void DoAction()
        {
            MoveOrbital();
        }

        private void MoveOrbital()
        {
            _cameraRotationY += Input.GetAxis("Mouse X") * RotationSpeed;
            _cameraRotationX -= Input.GetAxis("Mouse Y") * RotationSpeed;
            _cameraRotationX = Mathf.Clamp(_cameraRotationX, -25, 25);

            var characterTransform = _characterData.CharacterObject.transform;
            var characterTransformPosition = characterTransform.position;
            
            var trs = Matrix4x4.TRS(characterTransform.localPosition, Quaternion.Euler(_cameraRotationX, _cameraRotationY, 0), characterTransform.localScale);
            
            _characterData.CharacterCameraObject.transform.position = characterTransformPosition + trs.MultiplyVector(_offset);

            var lookPosition = new Vector3(characterTransformPosition.x, characterTransformPosition.y + 1, characterTransformPosition.z);
            
            _characterData.CharacterCameraObject.transform.LookAt(lookPosition);
        }
    }
}
