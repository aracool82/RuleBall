using UnityEngine;

namespace _Progect12_13.Scripts
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private GroundDetector _groundDetector;

        private int _coins;

        public int Coins => _coins;

        public void Move(Vector3 direction, float speed)
        {
            _rigidbody.AddForce(direction * speed, ForceMode.Force);
        }

        public void Jump(float force)
        {
            if (_groundDetector.IsGrounded == true)
                _rigidbody.AddForce(Vector3.up * force, ForceMode.Impulse);
        }

        public void AddCoin(int amount)
        {
            if (amount < 0)
                Debug.LogError("AddCoin Error : negative number");

            _coins += amount;
        }
    }
}