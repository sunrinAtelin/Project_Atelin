using UnityEngine;

//ǥ�ÿ� ���� UI ��������
using UnityEngine.UI;

public class OccupyAreaScript : MonoBehaviour
{
    //ǥ�ÿ�--
    [SerializeField] Text showtheprogress;
    //--

    float ProgressSpeed = 7.0f, ProgressMinusSpeed=-3.0f;

    float progress = 0.0f;//���� ����
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
        UpdateProgress(); //���� ������ ��Ÿ���ִ� �Լ�
        NotOnTheFloor();
      
    }


    private void UpdateProgress() //���� ������ ��Ÿ���ִ� �Լ� 
    {
        showtheprogress.text = progress.ToString("#");

    }

    private void OnTriggerStay(Collider other)//�������� �ö� ������ ���� ������ �÷��ִ� �Լ�
    {
        if (progress < 100)//100����
        {
            if (other.CompareTag("Player"))
            {
                progress += Time.deltaTime*ProgressSpeed;//������ ���������մϴ�
                if(progress >= 100) //�Ϸ��
                { 
                done=true;//���� ��ó��
                    print(areadone);
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
