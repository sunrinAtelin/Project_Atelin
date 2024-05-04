using UnityEngine;

//표시용 숫자 UI 가져오기
using UnityEngine.UI;

public class OccupyAreaScript : MonoBehaviour
{
    //표시용--
    [SerializeField] Text showtheprogress;
    //--

    float ProgressSpeed = 7.0f, ProgressMinusSpeed=-3.0f;

    float progress = 0.0f;//점령 정도
    BoxCollider boxcolider;
    private bool done=false;
    public bool areadone { get=> done;}

    void Start()
    {
        boxcolider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateProgress(); //점령 정도를 나타내주는 함수
        NotOnTheFloor();
      
    }


    private void UpdateProgress() //점령 정도를 나타내주는 함수 
    {
        showtheprogress.text = progress.ToString("#");

    }

    private void OnTriggerStay(Collider other)//점령지에 올라가 있으면 점령 정도를 올려주는 함수
    {
        if (progress < 100)//100기준
        {
            if (other.CompareTag("Player"))
            {
                progress += Time.deltaTime*ProgressSpeed;//위에서 수정가능합니다
                if(progress >= 100) //완료시
                { 
                done=true;//끝남 참처리
                    print(areadone);
                }
            }
        }
    }

    private void NotOnTheFloor()//내려와있으면 점령 정도 감소
    {
       if(progress< 100&& progress>0)//0이거나 100다찼을떄 뺴고 실행됨 
        {
            progress += Time.deltaTime * ProgressMinusSpeed;//위에서 수정 가능함
        }
    }
}
