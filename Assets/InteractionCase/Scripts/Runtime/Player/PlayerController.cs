using UnityEngine;

namespace InteractionSystem.Player
{
    /// <summary>
    /// Basic first-person player controller.
    /// Handles WASD movement and mouse look using CharacterController.
    /// </summary>
    [RequireComponent(typeof(CharacterController))]
    public sealed class PlayerController : MonoBehaviour
    {
        #region Constants

        private const float k_MinPitch = -80f;
        private const float k_MaxPitch = 80f;

        #endregion

        #region Serialized Fields

        [Header("Movement")]
        [SerializeField]
        private float m_MoveSpeed = 5f;

        [Header("Mouse Look")]
        [SerializeField]
        private float m_MouseSensitivity = 2f;

        [SerializeField]
        private Transform m_CameraTransform;

        #endregion

        #region Private Fields

        private CharacterController m_CharacterController;
        private float m_Pitch;

        #endregion

        #region Unity Callbacks

        private void Awake()
        {
            m_CharacterController = GetComponent<CharacterController>();

            if (m_CameraTransform == null)
            {
                Debug.LogError(
                    $"{nameof(PlayerController)}: CameraTransform is not assigned.",
                    this);
            }
        }

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void Update()
        {
            HandleMovement();
            HandleMouseLook();
        }

        #endregion

        #region Private Methods

        private void HandleMovement()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 move =
                transform.right * horizontal +
                transform.forward * vertical;

            m_CharacterController.Move(move * m_MoveSpeed * Time.deltaTime);
        }

        private void HandleMouseLook()
        {
            if (m_CameraTransform == null)
            {
                return;
            }

            float mouseX = Input.GetAxis("Mouse X") * m_MouseSensitivity * 100f * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * m_MouseSensitivity * 100f * Time.deltaTime;

            m_Pitch -= mouseY;
            m_Pitch = Mathf.Clamp(m_Pitch, k_MinPitch, k_MaxPitch);

            m_CameraTransform.localRotation = Quaternion.Euler(m_Pitch, 0f, 0f);
            transform.Rotate(Vector3.up * mouseX);
        }

        #endregion
    }
}
