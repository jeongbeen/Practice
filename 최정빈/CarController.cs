using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    float speed = 0;

    private Vector2 startPos;

    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //스와이프 길이를 구함
	    if (Input.GetMouseButtonDown(0))
	    {//마우스 단추를 클릭한 좌표
	        this.startPos = Input.mousePosition;
	    }
        else if (Input.GetMouseButtonUp(0))
	    {//마우스 버튼에서 손가락을 떼었을 때 좌표
	        Vector2 endPos = Input.mousePosition;
	        float swipelength = (endPos.x - this.startPos.x);

	        if (swipelength < 0.0f)
	            swipelength = 0;
	        this.speed = swipelength / 500.0f;

            //마우스를 누르고 떼었을 때 까지의 x좌표의 차를 계산하여 그 길이를 이용하여 컨트롤러가 
            //업데이트 되는 속도를 결정한다.

            GetComponent<AudioSource>().Play();
            Debug.Log(swipelength+","+endPos+","+startPos.x);
	    }

	    transform.Translate(this.speed,0,0);//y,z좌표로는 움직이지 않으므로 x좌표로만 값이 바뀐다.
	    this.speed *= 0.98f; //자동차컨트롤러의 속도를 조금씩 줄이기 위해 0.98을 매 업데이트때 마다 곱해줌

        /*
         월드 좌표계란 오브젝트가 게임판 어디에 있는지를 나타내는 좌표계이며
         (Inspector에서 설정한 좌표는 월드 좌표계)
         로컬 좌표계는 게임 오브젝트가 개별적으로 갖는 좌표계이다.

        translate 메서드를 사용하면 이동 방향은 월드 좌표계가 아닌 로컬 좌표계로 계산되어
        오브젝트가 회전하면 방향이 회전한 좌표계로 계산된다.

         */
	}
}
