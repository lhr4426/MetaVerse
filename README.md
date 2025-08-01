# 스파르타 내일배움캠프 유니티 11기 4주차 Metaverse


<p align="center">
<br>
  <img src="./images/playing.gif">
  <br>
</p>

  
  

## 프로젝트 소개

이번 유니티 11기에서 알게 된 몇몇 분들과 함께할 자리를 마련하고 싶어서  
메타버스 내에 NPC로 추가하게 되었음.  
(미니게임에도 출현하심!)

## 기술 스택

| C# | .Net |
| :--------: | :--------: |
|   ![csharp]    |   ![dotnet]    |

<br>

## 시스템 구성도

```mermaid
---
config:
  class:
    hideEmptyMembersBox: true
  layout: elk
---
classDiagram
direction LR
	namespace CodeShooter {
        class Entity_2["Entity"] {
        }
        class Manager_2["Manager"] {
        }
        class UI {
        }
        class Bullet {
        }
        class Enemy {
        }
        class PlayerController_2["PlayerController"] {
        }
        class Wall {
        }
        class BaseUI {
        }
        class UIs {
        }
        class GameManager_3["GameManager"] {
        }
        class SpawnManager {
        }
        class UIManager_2["UIManager"] {
        }
	}
	namespace FlappyPlane {
        class Entity_3["Entity"] {
        }
        class Manager_3["Manager"] {
        }
        class UI_2["UI"] {
        }
        class BgLooper {
        }
        class FollowCamera_2["FollowCamera"] {
        }
        class Obstacle {
        }
        class Player {
        }
        class GameManager_4["GameManager"] {
        }
        class UIManager_3["UIManager"] {
        }
        class BaseUI_2["BaseUI"] {
        }
        class UIs_2["UIs"] {
        }
	}
	namespace Global {
        class GlobalManager {
        }
        class GameManager {
        }
        class GameDatas {
        }
        class GameData {
        }
	}
	namespace Metaverse {
        class Entity {
        }
        class Interactive {
        }
        class Manager {
        }
        class Room {
        }
        class BaseRoom {
        }
        class Rooms {
        }
        class GameManager_2["GameManager"] {
        }
        class UIManager {
        }
        class FollowCamera {
        }
        class PlayerController {
        }
        class LeaderBoard {
        }
        class LeaderBoardData {
        }
        class BaseNPC {
        }
        class BaseInterative {
	        +interact()
        }
        class Buttons {
        }
        class NPCs {
        }
        class Weapon {
        }
	}

    GlobalManager -- GameDatas
    GameDatas o-- GameData
    Manager -- GameManager_2
    Manager -- UIManager
    Entity -- FollowCamera
    Entity -- PlayerController
    Entity -- LeaderBoard
    LeaderBoard o-- LeaderBoardData
    Interactive -- BaseInterative
    BaseInterative -- BaseNPC
    BaseInterative -- Buttons
    BaseNPC <|-- NPCs
    BaseInterative -- Weapon
    Entity_2 -- Bullet
    Entity_2 -- Enemy
    Entity_2 -- PlayerController_2
    Entity_2 -- Wall
    UI -- BaseUI
    BaseUI <|-- UIs
    Manager_2 -- UIManager_2
    Manager_2 -- SpawnManager
    Manager_2 -- GameManager_3
    Entity_3 -- FollowCamera_2
    Entity_3 -- BgLooper
    Entity_3 -- Obstacle
    Entity_3 -- Player
    Manager_3 -- UIManager_3
    Manager_3 -- GameManager_4
    UI_2 -- BaseUI_2
    BaseUI_2 <|-- UIs_2
    Room -- BaseRoom
    BaseRoom <|-- Rooms
```


## 구현 기능

### 필수 기능
- [x] 캐릭터 이동 및 맵 탐색
- [x] 맵 설계 및 상호작용 영역
- [x] 미니 게임 실행
- [x] 점수 시스템
- [x] 게임 종료 및 복귀
- [x] 카메라 추적 기능

### 도전 기능
- [x] 추가 미니 게임
- [x] 커스텀 캐릭터
- [x] 리더보드 시스템
- [x] 탑승물 제작
- [x] NPC와 대화 시스템

<br>

## 배운 점 & 아쉬운 점

이번에 개인 프로젝트로 2D 게임을 만들면서, TileMap 사용법을 많이 익히게 되었습니다.  
또한 JSON 직렬/역직렬화에 대해서도 익숙해질 수 있는 시간이 되었습니다.  
다만 중복 코드 제거에 너무 집착한 점이 좀 있었던 것 같습니다.  
미니게임의 GameManager를 모두 Global.GameManager를 상속하게 만든 방식이 과연 최선이었을지... 생각이 많아졌습니다.



<br>

## 개발 일지

### 소요 기간 : 4일

[1일차](https://lhr4426.pages.dev/2025-%EC%8A%A4%ED%8C%8C%EB%A5%B4%ED%83%80-%EB%82%B4%EB%B0%B0%EC%BA%A0-%EC%9C%A0%EB%8B%88%ED%8B%B0-11%EA%B8%B0/%EB%B3%B8%EC%BA%A0%ED%94%84/%EB%82%B4%EC%9D%BC%EB%B0%B0%EC%9B%80%EC%BA%A0%ED%94%84-%EB%B3%B8%EC%BA%A0%ED%94%84---250724)  
[2일차](https://lhr4426.pages.dev/2025-%EC%8A%A4%ED%8C%8C%EB%A5%B4%ED%83%80-%EB%82%B4%EB%B0%B0%EC%BA%A0-%EC%9C%A0%EB%8B%88%ED%8B%B0-11%EA%B8%B0/%EB%B3%B8%EC%BA%A0%ED%94%84/%EB%82%B4%EC%9D%BC%EB%B0%B0%EC%9B%80%EC%BA%A0%ED%94%84-%EB%B3%B8%EC%BA%A0%ED%94%84---250725)  
[3일차](https://lhr4426.pages.dev/2025-%EC%8A%A4%ED%8C%8C%EB%A5%B4%ED%83%80-%EB%82%B4%EB%B0%B0%EC%BA%A0-%EC%9C%A0%EB%8B%88%ED%8B%B0-11%EA%B8%B0/%EB%B3%B8%EC%BA%A0%ED%94%84/%EB%82%B4%EC%9D%BC%EB%B0%B0%EC%9B%80%EC%BA%A0%ED%94%84-%EB%B3%B8%EC%BA%A0%ED%94%84---250726)  
[4일차](https://lhr4426.pages.dev/2025-%EC%8A%A4%ED%8C%8C%EB%A5%B4%ED%83%80-%EB%82%B4%EB%B0%B0%EC%BA%A0-%EC%9C%A0%EB%8B%88%ED%8B%B0-11%EA%B8%B0/%EB%B3%B8%EC%BA%A0%ED%94%84/%EB%82%B4%EC%9D%BC%EB%B0%B0%EC%9B%80%EC%BA%A0%ED%94%84-%EB%B3%B8%EC%BA%A0%ED%94%84---250727)


## 라이센스

MIT &copy; [NoHack](mailto:lbjp114@gmail.com)

<!-- Stack Icon Refernces -->

[csharp]: /images/Csharp.png
[dotnet]: /images/Dotnet.png



