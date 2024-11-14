using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public UIManager MyUIManager;

    public GameObject Character;
    public GameObject CamObj;
    
    const float CharacterSpeed = 3f;

    public int NowScore = 0;

    void Awake()
    {
        MyUIManager.DisplayScore(NowScore);
        MyUIManager.DisplayMessage("", 0);
    }
    
    // Update is called once per frame
    void Update()
    {
        MoveCharacter();
        if (Character == null)
        {
            return;
        }
    }

    // For smooth cam moving, it's good to use LateUpdate.
    void LateUpdate()
    {
        if (Character == null)
        {
            return;
        }
        MoveCam();
    }

    void MoveCam()
    {
        // CamObj는 Character의 x, y position을 따라간다.
        // ---------- TODO ---------- 
        CamObj.transform.position = new Vector3(Character.transform.position.x, Character.transform.position.y, CamObj.transform.position.z);
        // -------------------- 
    }

    void MoveCharacter()
    {
        // Character는 초당 CharacterSpeed의 속도로 우측으로 움직인다.
        // ---------- TODO ---------- 
        Character.transform.position += Vector3.right * CharacterSpeed * Time.deltaTime;
        // -------------------- 
    }

    public void GameOver()
    {
        // Character를 삭제하고, "Game Over!"라는 메시지를 3초간 띄우고, RestartButton을 활성화한다.
        // ---------- TODO ---------- 
        Destroy(Character);
        Debug.Log("Game Over!");
        MyUIManager.DisplayMessage("Game Over!", 3);
        GameObject Restart = GameObject.Find("Button");
        Debug.Log($"{Restart}");
        GameObject canvas = GameObject.Find("Canvas");
        if (canvas != null)
        {
            Transform buttonTransform = canvas.transform.Find("Button");
            if (buttonTransform != null)
            {
                GameObject button = buttonTransform.gameObject;
                button.SetActive(true); 
                Debug.Log("Restart button activated.");
            }
            else
            {
                Debug.LogError("Restart button not found under Canvas.");
            }
        }
        else
        {
            Debug.LogError("Canvas not found. Ensure it exists and is named 'Canvas'.");
        }
 
        // -------------------- 
    }

    public void GetPoint(int point)
    {
        // point만큼 점수를 증가시키고 UI에 표시한다.
        // ---------- TODO ---------- 
        NowScore += point; // 점수 증가
        MyUIManager.DisplayScore(NowScore); // UI에 점수 표시
        // -------------------- 
    }

    // Restart the game
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
