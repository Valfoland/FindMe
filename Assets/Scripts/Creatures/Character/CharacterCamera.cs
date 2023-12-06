using Game.Creatures.Character;
using UnityEngine;

namespace Creatures.Character
{
    public class CharacterCamera : ICharacterCommand
    {
        private const float CameraRotationLimitX = 25;
        private const float RotationSpeed = 4f;
        private const float CameraViewOffsetY = 1;
        
        private Vector3 _offset;
        private CharacterData _characterData;

        private float _cameraRotationX;
        private float _cameraRotationY;
        private float _delay;
        
        public CharacterCamera(CharacterData characterData)
        {
            _characterData = characterData;
            
            _offset = _characterData.CharacterCameraObject.transform.localPosition;

            var eulerAngles = _characterData.CharacterCameraObject.transform.eulerAngles;
            
            _cameraRotationY = eulerAngles.y;
            _cameraRotationX = eulerAngles.x;
        }
    
        public void DoAction()
        {
            MoveOrbital();
        }

        private void MoveOrbital()
        {
            _cameraRotationY += Input.GetAxis("Mouse X") * RotationSpeed;
            _cameraRotationX -= Input.GetAxis("Mouse Y") * RotationSpeed;
            _cameraRotationX = Mathf.Clamp(_cameraRotationX, -CameraRotationLimitX, CameraRotationLimitX);

            var characterTransform = _characterData.CharacterObject.transform;
            var characterTransformPosition = characterTransform.position;
            
            var trs = Matrix4x4.TRS(characterTransform.localPosition, Quaternion.Euler(_cameraRotationX, _cameraRotationY, 0), characterTransform.localScale);
            
            _characterData.CharacterCameraObject.transform.position = characterTransformPosition + trs.MultiplyVector(_offset);

            var lookPosition = new Vector3(characterTransformPosition.x, characterTransformPosition.y + CameraViewOffsetY, characterTransformPosition.z);
            
            _characterData.CharacterCameraObject.transform.LookAt(lookPosition);
        }
    }
}
