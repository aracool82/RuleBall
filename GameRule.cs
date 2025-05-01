using UnityEngine;
using UnityEngine.Serialization;

namespace _Progect12_13.Scripts
{
    public class GameRule:MonoBehaviour
    {
        [FormerlySerializedAs("_timeController")] [SerializeField] private Timer timer;
        [SerializeField] private CoinStorage _coinStorage;
        [SerializeField] private Ball _ball;

        private int _allCoins;
        private bool _isRunning;
        
        private void Start()
        {
            _allCoins = _coinStorage.Count;
            timer.StartCounting();
            _isRunning = true;
        }

        private void Update()
        {
            if (_isRunning == false)
                return;
            
            if(timer.IsOverTime == false)
                if(IsCollectedAllCoins())
                    WinGame();
            
            if(timer.IsOverTime)
                if(IsCollectedAllCoins() == false)
                    LoseGame();
                else
                    WinGame();                
        }
        
        private bool IsCollectedAllCoins()
            => _ball.Coins == _allCoins;

        private void WinGame()
        {
            Debug.Log("Victory");
            StopGame();
        }

        private void LoseGame()
        {
            Debug.Log("Lose game");
            StopGame();
        }

        private void StopGame()
        {
            timer.StopTimer();
            _ball.gameObject.SetActive(false);
            _isRunning = false;
        }
    }
}