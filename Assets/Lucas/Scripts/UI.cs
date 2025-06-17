using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _ammo;
    [SerializeField] private TextMeshProUGUI _timer;
    private float _time = 0f;
    private PlayerManager _playerManager;

    void Start()
    {
        _playerManager = FindFirstObjectByType<PlayerManager>();
        _playerManager.firedBullet.AddListener(AmmoChanged);
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;
        _timer.text = "Time survived: "+Mathf.Round(_time).ToString();
    }

    public void AmmoChanged(int current, int max)
    {
        _ammo.text = "Ammo: "+current.ToString()+"/"+max.ToString();
    }

}
