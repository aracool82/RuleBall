using UnityEngine;

namespace _Progect12_13.Scripts
{
    public class UserInput : MonoBehaviour
    {
        private const string AxisHorizontal = "Horizontal";
        private const string AxisVertical = "Vertical";
        private float _jumpForce = 10f;
        private float _moveSpeed = 5;

        [SerializeField] private Ball _ball;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                _ball.Jump(_jumpForce);

            float horisontal = Input.GetAxisRaw(AxisHorizontal);
            float vertical = Input.GetAxisRaw(AxisVertical);

            Vector3 direction = new Vector3(horisontal, 0, vertical);
            _ball.Move(direction, _moveSpeed);
        }
    }
}