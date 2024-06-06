using Unity.VisualScripting;
using UnityEngine;

//표시용 숫자 UI 가져오기
/// <summary>
/// using UnityEngine.UI;
/// </summary>

public class OccupyAreaScript : ObservedObjectBase
{
    //표시용--
   // [SerializeField] Text showtheprogress;
    //--




    

    // Update is called once per frame
    void Update()
    {
      //  UpdateProgress(); //점령 정도를 나타내주는 함수-얘만 없애면 됨
        NotOnTheFloor();
      
    }


   // private void UpdateProgress() //점령 정도를 나타내주는 함수 - 얘만 없애면 됨 
   // {
    //    showtheprogress.text = progress.ToString("#");

   // }

    private void OnTriggerStay(Collider other)//점령지에 올라가 있으면 점령 정도를 올려주는 함수
    {
        if (progress < 100)//100기준
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("player"))
            {
                progress += Time.deltaTime*ProgressSpeed;//위에서 수정가능합니다
                if(progress >= 100) //완료시
                { 
                done=true;//끝남 참처리
                    print(areadone);
                    observe.IsAllOccupied(); //전체 다 점령했는지 확인
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
