using UnityEngine;
using TMPro;
using Saves;
using System;
using Player;
using Weapons;
using Core;

namespace Utility
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI coordinatesUI;

        [SerializeField]
        private TextMeshProUGUI generalScore;

        [SerializeField]
        private TextMeshProUGUI finalScore;

        [SerializeField]
        private TextMeshProUGUI angle;

        [SerializeField]
        private TextMeshProUGUI currentSpeed;

        [SerializeField]
        private TextMeshProUGUI countOfLasers;
        [SerializeField]
        private TextMeshProUGUI laserFireRate;

        [SerializeField]
        private GameObject GameOverScreen;

        private GameObject player;

        private IPlayer playerStats;

        private LaserGun laserGun;

        private ScoreManager scoreManager;

        private void Start()
        {
            player = FindObjectOfType<PlayerMovement>().gameObject;
            playerStats = player.GetComponent<IPlayer>();

            laserGun = player.GetComponentInChildren<LaserGun>();

            scoreManager = FindObjectOfType<ScoreManager>();

            PlayerBehaviour.OnDead += PlayerBehaviour_OnDead;
        }

        private void OnDisable()
        {
            PlayerBehaviour.OnDead -= PlayerBehaviour_OnDead;
        }

        private void PlayerBehaviour_OnDead()
        {
            GameOverScreen.SetActive(true);
            finalScore.text = $"FINAL SCORE: {scoreManager.Score}";

            SavingSystem.Save(scoreManager.Score);
        }

        private void Update()
        {
            coordinatesUI.text = $"Coordinates: {playerStats.Coordinates}";
            generalScore.text = $"Score: {scoreManager.Score}";
            angle.text = $"Angle: {Convert.ToInt32(playerStats.Angle)}";
            currentSpeed.text = $"Speed: {Convert.ToInt32(playerStats.CurrentSpeed)}";

            var fireRate = Convert.ToInt32(laserGun.FireRate) <= 0 ? "Laser ready" : Convert.ToInt32(laserGun.FireRate).ToString();
            laserFireRate.text = $"Laser cooldown: {fireRate}";
            countOfLasers.text = $"Count of laser: {laserGun.CountOfFire}";
        }
    }
}

