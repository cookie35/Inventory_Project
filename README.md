# Unity UI 프로젝트 가이드

## 프로젝트 개요
본 프로젝트는 Unity의 UGUI 시스템을 활용하여 메인 메뉴, 상태(Status) 화면, 인벤토리(Inventory) 화면을 구성하고, UI 간 전환 기능을 구현하는 것을 목표로 합니다.

## 프로젝트 구조
```
- Scripts
    - GameManager.cs
    - UIManager.cs
    - UIMainMenu.cs
    - UIStatus.cs
    - UIInventory.cs
    - ItemSlot.cs
    - ItemData.cs
    - ItemButton.cs
    - Character.cs
- UI
    - UIMainMenu (Canvas)
    - UIStatus (Canvas)
    - UIInventory (Canvas)
    - UISlot (Prefab)
```

## STEP 1. UI 구성하기
### 목표: **UGUI를 활용해 UIMainMenu, UIStatus, UIInventory UI를 구성**
1. **UIMainMenu (Canvas)**
   - 아이디, 레벨, 골드 표시
   - Status 버튼 → Status 화면으로 이동
   - Inventory 버튼 → Inventory 화면으로 이동
2. **UIStatus (Canvas)**
   - 캐릭터 정보 표시
   - 뒤로가기 버튼 → 메인 화면으로 이동
3. **UIInventory (Canvas)**
   - 인벤토리 아이템 표시
   - 장착된 아이템 정보 표시
   - 뒤로가기 버튼 → 메인 화면으로 이동

## STEP 2. 스크립트 만들기
### 목표: **UIManager와 Character 클래스를 생성하고, 필요한 스크립트 작성**
1. **필요한 스크립트 생성**
   - `GameManager`
   - `UIManager`
   - `UIMainMenu`
   - `UIStatus`
   - `UIInventory`
   - `Character`
   - `Item`
2. **UIManager에 [SerializedField] 활용하여 UI 연결**
3. **Character 클래스에 캐릭터 데이터 작성 (필드 및 생성자 포함)**

## STEP 3. UI 간 전환 기능 만들기
### 목표: **UIManager를 통해 UI 간 전환 기능 구현**
1. `UIMainMenu`에서 `OpenMainMenu()`, `OpenStatus()`, `OpenInventory()` 메서드 추가
2. `UIManager` 싱글톤 패턴 적용 및 UI 접근 프로퍼티 생성
3. `UIMainMenu`에서 버튼 클릭 시 UI 전환 기능 구현
4. `Start()`에서 `AddListener()`를 활용하여 버튼 기능 추가

## STEP 4. 캐릭터 정보 세팅하기
### 목표: **캐릭터 정보가 UI에 표시되도록 구현**
1. `Character` 클래스 필드를 `{ get; private set; }`으로 설정
2. `UIMainMenu`, `UIStatus
