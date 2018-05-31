using System.Collections;//대,소문자를 구분함
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //UI 오브젝트를 스크립트에서 사용하려면 필요함

public class GameDirector : MonoBehaviour
{
    GameObject car;
    GameObject flag;
    GameObject distance;
	// Use this for initialization
	void Start () {
		this.car = GameObject.Find("car"); //오브젝트명을 인수로 전달하고 인수명이 게임 씬 안에 있으면 해당 오브젝트를 반환
		this.flag = GameObject.Find("flag");
		this.distance = GameObject.Find("Distance");
	}
	
	// Update is called once per frame
	void Update ()
	{
	    float length = this.flag.transform.position.x - this.car.transform.position.x; //게임오브젝트명.transform.position
	    if (length >= 0)
	    {
	        this.distance.GetComponent<Text>().text = "목표 지점까지" + length.ToString("F2") + "m";
	    }
	    else
	    {
	        this.distance.GetComponent<Text>().text = "게임 오버";
        }
    }
}
/*
 유니티 오브젝트는 GameObject라는 빈 상자에 설정자료(컴포넌트)를 추가(적용)해서 기능을
 추가할 수 있다.
 오브젝트를 물리적으로 움직이게 하려면 Rigidbody 컴포넌트를 수가하고
 소리를 내게 하려면 AudioSource 컴포넌트를 추가한다.
 자체기능을 늘리고 싶다면 스크립트 컴포넌트를 추가한다.
 또한 오브젝트의 좌표와 회전을 관리하는 Transform 컴포넌트는
 핸들처럼 좌표,회전,이동 같은 오브젝트의 움직임과 관련된 기능을 제공한다.
 즉 자동차 오브젝트(car)에 적용한 Transform 컴포넌트에 있는 좌표(position)정보로 접근한다.
 <<게임 오브젝트라는 상자안에 transform 안에 position안에 있는 x,y,z등으로 접근>>
  
  하지만 transform을 제외한 나머지 컴포넌트를 이렇게 쓰지 않는다.
  다른 컴포넌트는 GetComponent메서드를 사용하여 해당되는 컴포넌트를 돌려주는 메서드이고
  GetComponent<AudioSource>(), GetComponent<Text>()처럼 사용한다.

  좌표를 구할때마다 매번 GetComponent<Transform>()을 사용하는 건 번거롭기 때문에
  간단한 서식인 transform 변수를 이용한다.

  또한 직접 만든 스크립트도 컴포넌트의 일종이므로 GetComponent 메서드를 써서 구할 수 있다.
  CarController 스크립트에 Run 메서드를 구현했다면
  car.Getcomponent<CarController>.Run()로 자동차오브제트에 적용한
  CarController 스크립트의 Run메서드를 호출할 수 있다.
  */