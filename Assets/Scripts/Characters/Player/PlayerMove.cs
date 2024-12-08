using Services.Input;
using UnityEngine;

namespace Characters.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private float _speed;

        private IInputService _inputService;
        private Camera _camera;

        public void Construct(IInputService inputService)
        {
            _inputService = inputService;
            _camera = Camera.main;
        }
        
        private void Update() =>
            PlayerMovement();

        private void PlayerMovement()
        {
            Vector3 movementVector = Vector3.zero;

            if (_inputService.Axis.sqrMagnitude > 0.001f)
            {
                movementVector = _camera.transform.TransformDirection(_inputService.Axis);
                movementVector.y = 0;
                movementVector.Normalize();

                transform.forward = movementVector;
            }

            movementVector += Physics.gravity;

            _characterController.Move(movementVector * (_speed * Time.deltaTime));
        }
    }
}