using Unity.VisualScripting;
using UnityEngine;

//ǥ�ÿ� ���� UI ��������
/// <summary>
/// using UnityEngine.UI;
/// </summary>

public class OccupyAreaScript : ObservedObjectBase
{
    //ǥ�ÿ�--
   // [SerializeField] Text showtheprogress;
    //--




    

    // Update is called once per frame
    void Update()
    {
      //  UpdateProgress(); //���� ������ ��Ÿ���ִ� �Լ�-�길 ���ָ� ��
        NotOnTheFloor();
      
    }


   // private void UpdateProgress() //���� ������ ��Ÿ���ִ� �Լ� - �길 ���ָ� �� 
   // {
    //    showtheprogress.text = progress.ToString("#");

   // }

    private void OnTriggerStay(Collider other)//�������� �ö� ������ ���� ������ �÷��ִ� �Լ�
    {
        if (progress < 100)//100����
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("player"))
            {
                progress += Time.deltaTime*ProgressSpeed;//������ ���������մϴ�
                if(progress >= 100) //�Ϸ��
                { 
                done=true;//���� ��ó��
                    print(areadone);
                    observe.IsAllOccupied(); //��ü �� �����ߴ��� Ȯ��
                }
            }
        }
    }

    private void NotOnTheFloor()//������������ ���� ���� ����
    {
       if(progress< 100&& progress>0)//0�̰ų� 100��á���� ���� ����� 
        {
            progress += Time.deltaTime * ProgressMinusSpeed;//������ ���� ������
        }
    }

   

}
