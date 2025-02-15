
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] public CueStickHandler _cueStickHandler;
    [SerializeField] public InputHandler _inpuHandler;
    [SerializeField] public UIManager _uiManager;
    [SerializeField] public CueBall _cueBall;


    private void Start()
    {
        _inpuHandler.Init();
        _uiManager.Init();
        _cueBall.Init();
        _cueStickHandler.Init(_inpuHandler,_uiManager.GetHitSlider(), _cueBall);
    }
}
