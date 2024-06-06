using UnityEngine;

public class Chapter1 : Chapter
{
    Chapter1 instance;
    public override Chapter Instance => instance;

    void Start() {
        instance = this;

        Invoke("Game", 1);
    }

    void Game() {
        PlayerManager.Main.Idle(true);
        Cam.Instance.stopTrace = true;
        
        InteractSystem.Instance.Interact("구속장치 파괴하기", ()=>{
            PlayerManager.Main.Idle(false);
            Cam.Instance.stopTrace = false;
        });
    }
}