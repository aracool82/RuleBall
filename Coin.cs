using UnityEngine;

namespace _Progect12_13.Scripts
{
    public class Coin : MonoBehaviour
    {
        [SerializeField] private CoinStorage _coinStorage;

        private int _value = 1;

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.TryGetComponent(out Ball ball))
            {
                ball.AddCoin(_value);
                _coinStorage.Remove(this);
                //Destroy(gameObject);
            }
        }
    }
}