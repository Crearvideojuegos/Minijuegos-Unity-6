using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
        private IA_PlayerController _IA_PlayerController; //Input System
        private CharacterController _characterController;

        private Vector2 _moveInput; //WASD Movement
        private Vector3 movementDirection;
        [SerializeField] private Animator _anim;


        private void Awake() 
        {
            _IA_PlayerController = new IA_PlayerController();
            _IA_PlayerController.PlayerController.Falling.performed += ctx => Falling(); //Key Space
            _characterController = GetComponent<CharacterController>();

            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Start() 
        {
            _IA_PlayerController.Enable();
        }

        private void Update() 
        {
            CaptureInput();
        }

        private void FixedUpdate() 
        {
            if(GameManager.Instance.GameActive)
            {
                MoveCharacter();
            }
        }

        private void MoveCharacter()
        {
            movementDirection = new Vector3(_moveInput.x, 0, _moveInput.y);
            movementDirection.y = -1f;
            _characterController.Move(movementDirection * Time.deltaTime * 10f);
        }

        private IEnumerator MoveAlone()
        {

            yield return new WaitForSeconds(.1f);
            movementDirection = new Vector3(_moveInput.x, 0, _moveInput.y);

            int randomNumber = Random.Range(0, 2);
            if(randomNumber == 1) 
            {
                movementDirection.x = 10f;
            } else {
                movementDirection.x = -10f;
            }

            if(GameManager.Instance.GameActive)
            {
                _characterController.Move(movementDirection * Time.deltaTime * 10f);
                StartCoroutine(MoveAlone());
            }
        }


        private void CaptureInput()
        {
            _moveInput = _IA_PlayerController.PlayerController.Movement.ReadValue<Vector2>();
        }

        private void Falling()
        {
            GameManager.Instance.GameActive = true;
            _anim.SetBool("ZombiFalling", true);
            StartCoroutine(MoveAlone());
        }

}
