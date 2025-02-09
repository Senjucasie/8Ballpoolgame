
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] public CueStickHandler _cueStickHandler;
    [SerializeField] public InputHandler _inpuHandler;
    [SerializeField] public UIManager _uiManager;


    private void Start()
    {
        _cueStickHandler.Init(_inpuHandler);
        _uiManager.Init();
        _inpuHandler.Init();
    }
}
