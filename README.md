# SpartaMetaverse
파일 구조는 다음과 같습니다.

![{0F9D0E3D-8F8A-466B-A4A2-1AAADCBEFC0D}](https://github.com/user-attachments/assets/02ceb3d6-00af-44ce-ad3e-080c8ef9475a)

먼저 큰 분류로 Scene을 기준으로 폴더를 나누었습니다.

매니저는 미니게임씬에서만 사용하지만 다른 곳의 사용도 고려하여 메인씬에 두었습니다.

저는 기초구현 부분정도만 진행한 상태이고 그 이후 추가기능 점프정도를 구현해두었습니다.

문제 순서대로 어디에 구현해두었는지 전달드리겠습니다.

필수
1. 캐릭터 이동 및 맵 탐색 : BaseController, PlayerController 파일
2. 맵 설계 및 상호작용 영역 : MainScene의 TileMap, NPC 오브젝트
3. 미니 게임 실행 : MiniGameScene
4. 점수 시스템 : GameManager에서 PlayerPrefs 값 저장
5. 게임 종료 및 복귀 : 미니게임 오버시 다시 할것인지 또는 나갈것인지 체크
6. 카메라 추적 기능 : CameraFollow 파일

도전
캐릭터 점프, NPC 리더보드..? 구현

냉정한 코드 평가 부탁드립니다.
