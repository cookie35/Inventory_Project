# Unity 인벤토리 만들기 과제
내일배움캠프 심화과제 개인프로젝트

## 프로젝트 개요
> Unity 2D로 개발한 인벤토리
> 메인 메뉴, 상태(Status) 화면, 인벤토리(Inventory) 화면, UI 간 전환 기능 등을 구현

## 주요 기능
메인 화면  
![image](https://github.com/user-attachments/assets/0c2d9780-1c6d-4aa1-9887-104402625ecb)
초기 세팅값(id, level, gold)과 함께, 상태(status) 버튼과 인벤토리(Inventory) 버튼이 구현되어 있다.  

상태 화면
![image](https://github.com/user-attachments/assets/5854b35b-7847-498a-b737-18e5650b8f28)
공격력, 방어력, 체력, 치명타 각각의 수치의 기본값이 표시되어 있다.
뒤로 가기 버튼을 누르면 메인 화면으로 돌아간다.

인벤토리 화면
![image](https://github.com/user-attachments/assets/29c67206-daef-459f-b0e9-44ebf163d1b2)
인벤토리에 슬롯이 20개 초기 생성되며 아이템이 추가되면 동적 생성되도록 구현하였다.
위와 같이 칼/방패/먹을 것으로 장착 및 해제가능하다. 

![image](https://github.com/user-attachments/assets/6aa2d1a5-0836-48d3-b48b-39d337e3b4a9)
장착한 장비에 따라 스테이터스 창 역시 변화한다.
장비에 따른 스탯 수치(공격력, 방어력, 치명타 등)를 변화시키고 싶을 경우, ScriptableObject로 관리하면 된다.

## 라이선스
| 에셋 이름     |출처| 라이선스        |
|:-----------:|:---:|:-------------:|
|Sprout Lands - UI Pack by Cup Nooble|https://cupnooble.itch.io/sprout-lands-ui-pack|Free|
|Pixel Art Icon Pack - RPG|https://assetstore.unity.com/packages/2d/gui/icons/pixel-art-icon-pack-rpg-158343|Free|
