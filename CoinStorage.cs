using System.Collections.Generic;
using UnityEngine;

namespace _Progect12_13.Scripts
{
    public class CoinStorage : MonoBehaviour
    {
        private List<Coin> _coins = new();

        public int Count => _coins.Count;

        private void Awake()
        {
            FindChidrens();
        }

        public void Remove(Coin coin)
        {
            if (coin == null)
            {
                Debug.LogError("Removing a null coin");
                return;
            }

            _coins.Remove(coin);
            Destroy(coin.gameObject);
        }

        private void FindChidrens()
        {
            int childs = transform.childCount;

            if (childs < 0)
                Debug.LogError("Not enough children");

            for (int i = 0; i < childs; i++)
                if (transform.GetChild(i).TryGetComponent(out Coin coin))
                    _coins.Add(coin);
        }
    }
}
