using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingSceneController : MonoBehaviour
{
    //���� ����
    static string nextScene;


    //����ٷ� ���� �̹����� ���� ���� ����
    [SerializeField]
    Image progressBar;

    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName; //�Ű������� ����
        SceneManager.LoadScene("LoadingScene");//���Ŵ����� �ε��� �ҷ���

    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadSceneProcess());
    }

    //�ڷ�ƾ���� �ε�� ���μ��� �Լ� �����
    IEnumerator LoadSceneProcess()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);//�ε�� �Լ����� �޾Ƶ� nextScene�� �Ű������� 
                                                                   //SceneManager.LoadScene : ������ �� �ҷ����� - ���� �ҷ������� ���� �ٸ� �۾� ���� �Ұ�
                                                                   //SceneManager.LoadSceneAsync : �񵿱���

        //AsyncOperation Ŭ���� ��ü op�� ����  allowSceneActivation�� false�� ���� 
        //�񵿱� ��Ŀ��� ���� �ε��� ������ �ڵ����� �ҷ��� ������ �̵��� ������ ���� 
        //false : 90%���� �ε��� ���¿��� ���� ������ �Ѿ�� �ʰ� ��� (true�� �� �� ���� ���)
        //  1.�������� �ε� �ӵ��� ���� �� (�ӵ� ����:����ũ �ε�)
        //  2. �ε�ȭ�鿡�� �� �ܿ� �ٸ� ���� �ҷ��;��� �� (���ҽ� �ε� ���)
        op.allowSceneActivation = false;


        float timer = 0f;
        //�� �ε��� ������ �ʾҴٸ� ��� �ݺ�
        while (!op.isDone)
        {
            yield return null;//�ݺ��� �� ���� ����Ƽ�� ������� �Ѿ����
            //���� ������ �ݺ����� ������ ���� ȭ���� ���ŵ��� �ʾ� ����ٰ� �������� ����

            if (op.progress < 0.9f)
            {
                progressBar.fillAmount = op.progress;//�ε��� ��������
            }
            else
            {
                //����ũ�ε� ����
                timer += Time.unscaledDeltaTime;
                progressBar.fillAmount = Mathf.Lerp(0.9f, 1f, timer);
                if (progressBar.fillAmount >= 1f)//�ε� ������
                {
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }
}

