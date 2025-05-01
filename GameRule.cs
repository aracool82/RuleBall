using UnityEngine;

namespace _Progect12_13.Scripts
{
    public class GameRule:MonoBehaviour
    {
        [SerializeField] private TimeController _timeController;
        [SerializeField] private CoinStorage _coinStorage;
        [SerializeField] private Ball _ball;

        private int _allCoins;
        private bool _isRunning;
        
        private void Start()
        {
            _allCoins = _coinStorage.Count;
            _timeController.StartCounting();
            _isRunning = true;
        }

        private void Update()
        {
            if (_isRunning == false)
                return;
            
            if(_timeController.IsOverTime == false)
                if(IsCollectedAllCoins())
                    WinGame();
            
            if(_timeController.IsOverTime)
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
            _timeController.StopTimer();
            _ball.gameObject.SetActive(false);
            _isRunning = false;
        }
    }
}