# 3회차 Unity 기준 프로젝트 준비

## 권장 환경

- 학교 PC에 설치된 동일한 Unity LTS 버전을 사용한다.
- 2D Core 템플릿으로 시작한다.
- `Edit → Project Settings → Player → Active Input Handling`을 `Input Manager (Old)` 또는 `Both`로 설정한다.
- `Assets/Scripts` 폴더에 이 폴더의 `unity-scripts` 파일 5개를 복사한다.

## 정상 장면 `session03-normal`

1. `GameManager`를 만들고 `ScoreManager`를 붙인다.
2. Square Sprite로 `Player`를 만든다.
   - `Rigidbody2D`: Gravity Scale 0, Freeze Rotation Z
   - `BoxCollider2D`
   - `PlayerMover`, `PlayerCollector`
3. Circle Sprite로 `Coin`을 만든다.
   - `CircleCollider2D`: Is Trigger 켜기
   - `Coin`
   - `Assets/Prefabs/Coin.prefab`으로 만든 뒤 장면의 원본은 제거
4. `CoinSpawner`를 만들고 `CoinSpawner` 스크립트를 붙인다.
5. `PlayerCollector.scoreManager`에 장면의 `GameManager`를 연결한다.
6. `CoinSpawner.coinPrefab`에 `Coin.prefab`을 연결한다.
7. Play하여 이동, Coin 생성, Trigger, 10점 출력, Coin 제거를 두 번 검증한다.

## 고장 장면 `session03-broken`

`session03-normal`을 복제한 뒤 학생 한 명에게 2개의 오류만 배정한다. 한 장면에 모든 오류를 넣지 않는다.

| 코드 | 변경 | 예상 증상 | 복구 위치 |
|---|---|---|---|
| B1 | PlayerMover 비활성화 | 입력해도 이동 안 함 | Player Inspector |
| B2 | speed 0 | 입력해도 이동 안 함 | PlayerMover |
| B3 | Rigidbody2D 제거 | Trigger 콜백 안 옴 | Player Inspector |
| B4 | Coin Is Trigger 끄기 | 닿아도 획득 안 됨 | Coin Prefab Collider2D |
| B5 | ScoreManager 참조 해제 | 충돌 시 NullReference | PlayerCollector |
| B6 | Coin Prefab 참조 해제 | 시작 시 NullReference | CoinSpawner |
| B7 | Coin Component 제거 | 충돌해도 점수 변화 없음 | Coin Prefab |

## 배포 전 최종 확인

- Console의 compile error 0개
- `Library`, `Temp`, `Logs`, `obj` 제외
- 스크립트와 `.meta`, Prefab과 `.meta`, Scene과 `.meta` 포함
- 정상 장면 복구본은 학생 작업 폴더 밖에 별도 보관
- 학생 배포본을 새 폴더에서 clone한 뒤 한 번 열어 검증
