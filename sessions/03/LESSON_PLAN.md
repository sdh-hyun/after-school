# 3회차 수업안 — Unity 객체와 컴포넌트 연결

## 수업 정보

- 회차: 3회차
- 날짜: 미정
- 수업시간: 120분
- 예상 인원: 15명
- 직전 회차 완료 내용: C# 변수, 조건문, 반복문, 메서드, 클래스와 객체를 사용한 콘솔 전투 예제
- 현재 학생 수준 및 특이사항: 1·2회차 실제 결과 기록이 없어 숙련도 미확정. 2회차 자료의 `Fighter` 클래스·메서드 호출 경험은 있다고 보되, 완료했다고 가정하지 않고 Unity Inspector와 실행 결과를 함께 읽게 한다.
- 다음 회차 연결: 4회차의 객체 책임 분리, 공개 메서드, 직접 참조와 이벤트 비교

## 학습 목표

수업 종료 시 학생은 다음을 할 수 있다.

1. GameObject와 Component의 관계를 장면 속 예로 설명한다.
2. `Awake`, `Start`, `Update`가 언제 실행되는지 구분한다.
3. 입력, 2D Trigger 충돌, Inspector 참조, Prefab 생성을 연결해 작은 기능을 완성한다.
4. Console과 Inspector를 확인해 작동하지 않는 Unity 장면의 원인을 찾고 수정한다.

## 완료 조건

- 필수 기능: 방향키 또는 WASD로 Player가 이동하고 Coin에 닿으면 점수가 증가하며 Coin이 사라진다.
- 객체 연결: `PlayerCollector`가 Inspector에 연결된 `ScoreManager`의 공개 메서드를 호출한다.
- 프리팹: `CoinSpawner`가 `Start`에서 Coin Prefab을 한 개 이상 생성한다.
- 설명: 학생이 GameObject/Component 관계, 생명주기 메서드 하나, Inspector 참조 하나를 자기 말로 설명한다.
- 현장 변경: 교사가 지정한 이동 속도, Coin 점수, 생성 위치 중 하나를 3분 안에 변경하고 다시 실행한다.
- 빠른 학생: Coin 여러 개 생성, 중복 획득 방지, 점수 임계치 이벤트 중 하나를 추가한다.

## 수업 전 교사 준비

1. 모든 PC의 Unity LTS 버전과 프로젝트 템플릿을 통일한다.
   - 본 자료의 `Input.GetKey` 예제를 쓰려면 **Active Input Handling**을 `Input Manager (Old)` 또는 `Both`로 맞춘다.
2. `session03-normal` 기준 장면과 `session03-broken` 고장 장면을 준비한다.
3. 고장 장면에는 학생마다 아래 오류 중 2~3개가 섞이도록 한다.
   - `PlayerMover` 비활성화
   - `speed` 값 0
   - Player의 `Rigidbody2D` 누락
   - Coin Collider의 `Is Trigger` 해제
   - `PlayerCollector.scoreManager`가 `None`
   - `CoinSpawner.coinPrefab`이 `None`
   - Coin Prefab에 `Coin` 컴포넌트 누락
4. 오류별 정답표와 정상 Prefab을 별도로 보관한다.
5. 개인 브랜치 이름은 `session03/<GitHub아이디>`로 통일한다.

## 120분 수업 흐름

| 시간 | 단계 | 교사 활동 | 학생 활동 | 확인 결과 |
|---:|---|---|---|---|
| 0~10분 | 시작·환경 확인 | Unity 버전, Console, 직전 Git 작업 확인 | 프로젝트 열기, Play 실행, Console 비우기 | 전원 기준 장면 실행 |
| 10~22분 | 객체와 컴포넌트 | 빈 GameObject와 여러 Component를 붙여 역할 시연 | Inspector에서 Transform, Script, Collider 찾기 | GameObject와 Component를 말로 구분 |
| 22~32분 | 생명주기 | `Awake → Start → Update` 로그 순서 시연 | 실행 전 호출 순서 예측 후 Console 확인 | 세 메서드 역할 구분 |
| 32~42분 | 연결 시범 | 입력→이동, Trigger→점수 호출, Prefab→복제 흐름 시연 | 어떤 객체가 누구를 참조하는지 그림에 표시 | 연결 구조 확인 |
| 42~60분 | 따라 만들기 | 단계별 멈춤 지점과 Inspector 설정 제시 | Player, GameManager, Coin Prefab 구성 및 스크립트 연결 | 이동 또는 획득 기능 1개 이상 |
| 60~85분 | 기본 기능 완성·순회 평가 1 | 준비된 학생부터 1인 3분 구두 설명·현장 변경 | 이동→충돌→점수→생성 완성, 평가 대기 중 자가 확인 | 기본 기능, 개인 평가 누적 |
| 85~105분 | 고장 장면·순회 평가 2 | 남은 학생 평가, 증상→가설→검증 순회 지도 | 고장 2개 이상을 찾고 원인·수정 기록 | 15명 평가 완료, 디버깅 기록 |
| 105~115분 | Git 제출 | diff와 불필요한 파일 확인, PR 지원 | commit, push, PR 작성 | 개인 PR 제출 |
| 115~120분 | 정리 | 4회차 책임 분리 예고 | 종료 티켓 작성 | 다음 회차 인계 자료 |

### 15명 순회 평가 운영

- 60분부터 준비된 학생 순으로 시작하고, 학생 1명당 최대 3분을 사용한다.
- 1분: GameObject/Component·참조·호출 흐름 중 하나를 설명한다.
- 2분: 교사가 지정한 숫자 또는 Inspector 조건을 변경하고 실행한다.
- 평가를 마친 학생은 고장 장면을 해결하고, 대기 학생은 기본 기능과 디버깅 기록을 완성한다.
- 85분까지 준비되지 않은 학생은 교사 정상 Prefab으로 기능 범위를 축소하되, 연결 설명과 현장 변경은 본인이 수행한다.

## 핵심 설명 내용

### 한 장 구조도

```text
Scene
├─ GameManager
│  └─ ScoreManager              점수 상태와 AddScore 책임
├─ Player
│  ├─ Transform
│  ├─ Rigidbody2D
│  ├─ Collider2D
│  ├─ PlayerMover               입력을 읽고 이동
│  └─ PlayerCollector ───────┐  충돌을 감지
├─ Coin Prefab              │
│  ├─ Collider2D (Trigger)  │
│  └─ Coin (points)         │
└─ CoinSpawner              │
   └─ coinPrefab 참조       │
                              ▼
                      ScoreManager.AddScore()
```

### 반드시 설명할 개념

- GameObject는 장면에 존재하는 그릇이고 Component는 그 객체의 데이터와 기능이다.
- Script도 Component이며 파일을 만들기만 해서는 동작하지 않고 GameObject에 붙어 있어야 한다.
- `Awake`: 이 Component가 준비될 때 내부 참조를 확보하는 곳
- `Start`: 첫 프레임 전에 다른 객체를 포함한 초기 상태를 시작하는 곳
- `Update`: 활성화된 동안 프레임마다 실행되므로 입력 확인에 적합하지만, 매번 불필요한 검색을 하면 안 된다.
- Inspector 참조는 코드의 필드와 장면의 실제 객체를 연결하는 작업이다.
- Prefab은 장면 밖에 저장한 재사용 가능한 객체 원본이며 `Instantiate`는 그 복사본을 만든다.
- Trigger 충돌에는 양쪽 Collider2D와 최소 한쪽 Rigidbody2D가 필요하다.

### 사용할 비유

- GameObject: 빈 스마트폰 본체
- Component: 카메라, GPS, 앱처럼 붙여서 능력을 추가하는 부품
- Inspector 참조: 연락처 이름만 적는 것이 아니라 실제 전화번호를 연결하는 작업
- Prefab: 쿠키 틀, Instantiate: 그 틀로 실제 쿠키를 하나 만드는 것

### 학생에게 던질 질문

- 스크립트 파일은 있는데 왜 장면에서 동작하지 않을 수 있는가?
- `Update` 안의 코드는 1초에 정확히 한 번 실행되는가?
- `scoreManager`가 `None`이면 코드는 어느 순간 실패하는가?
- Coin에 Collider가 있는데도 Trigger가 호출되지 않는 이유는 무엇일 수 있는가?
- Prefab 원본을 수정하면 이미 장면에 놓인 인스턴스와 어떤 관계가 생기는가?

### 흔한 오해

- 파일명과 클래스명이 달라도 괜찮다 → `MonoBehaviour` 스크립트는 일반적으로 일치시켜야 Unity에서 정상 연결된다.
- Collider만 있으면 `OnTriggerEnter2D`가 항상 호출된다 → 2D 물리 조건과 Trigger 설정을 모두 확인해야 한다.
- `public`으로 만들면 자동 연결된다 → Inspector 슬롯에 실제 객체를 넣어야 한다.
- `Update`는 한 번만 실행된다 → 프레임마다 반복된다.
- Prefab은 장면의 객체와 같다 → Prefab은 재사용 원본이고 장면에는 인스턴스가 놓인다.

## 실습 운영

### 기본 과제

1. `GameManager`를 만들고 `ScoreManager`를 붙인다.
2. `Player`에 `PlayerMover`, `PlayerCollector`, `Rigidbody2D`, `Collider2D`를 구성한다.
3. `Coin`에 Trigger Collider와 `Coin` 스크립트를 붙여 Prefab으로 만든다.
4. `PlayerCollector`의 `scoreManager` 슬롯에 GameManager를 연결한다.
5. `CoinSpawner`에 Coin Prefab을 연결하고 실행한다.
6. 이동, 충돌, 점수 증가, Coin 제거를 확인한다.
7. 고장 장면에서 최소 2개 오류를 찾아 디버깅 기록을 남긴다.

### 확장 과제 선택지

- Coin 생성 위치 배열을 만들고 여러 개 생성한다.
- 같은 Coin이 두 번 처리되지 않도록 획득 상태를 추가한다.
- 점수가 30점 이상일 때 문을 활성화한다.
- `Debug.Log` 대신 화면 UI에 점수를 표시한다.

## Git 제출 규칙

- 브랜치: `session03/<GitHub아이디>`
- commit 예시: `feat: connect player coin and score components`
- PR 본문: `완성 기능`, `찾은 오류와 원인`, `현장 변경 내용`, `AI 사용 여부`
- `Library`, `Temp`, `Logs`, `obj` 폴더는 commit하지 않는다.
- 교사가 지정한 기준 브랜치로 PR을 만들고 `main`에 직접 push하지 않는다.

## 예상 문제와 대응

| 문제 | 확인 방법 | 수업 중 대응 | 그래도 실패할 때 |
|---|---|---|---|
| 스크립트가 Inspector에 안 붙음 | Console의 첫 compile error, 파일명·클래스명 확인 | 가장 위 오류부터 수정 후 재컴파일 | 정상 스크립트와 diff 비교 |
| Player가 움직이지 않음 | Component 활성화, `speed`, Game 창 포커스 확인 | 입력 로그를 넣어 입력과 이동을 분리 확인 | 키 입력 대신 자동 방향 값으로 이동만 검증 |
| `InvalidOperationException` 입력 오류 | Console에 New Input System 사용 메시지 확인 | Active Input Handling을 `Both`로 변경하고 Editor 재시작 | 교사 기준 프로젝트로 교체 |
| Trigger가 호출되지 않음 | Collider2D, Is Trigger, Rigidbody2D 확인 | 체크리스트 순서대로 하나씩 검증 | 정상 Player Prefab으로 교체해 원인 범위 축소 |
| `NullReferenceException` | Console stack trace의 파일·줄 확인 | Inspector의 `None` 슬롯을 찾고 연결 | 교사 정상 장면과 Inspector 비교 |
| Prefab이 생성되지 않음 | Prefab 슬롯과 Console 확인 | `Start` 로그, 참조, 활성 상태 순으로 확인 | 장면에 직접 배치해 Coin 기능부터 검증 |
| 학생별 속도 차이 | 60분 시점 기본 기능 수 확인 | 빠른 학생부터 순회 평가·확장 과제, 미완료자는 이동→충돌→점수 순 최소선 집중 | 교사 제공 정상 Prefab을 사용하고 연결 설명을 평가 |
| Git에 대용량 파일이 잡힘 | commit 전 변경 파일 확인 | Unity `.gitignore` 적용, 필요한 Assets/ProjectSettings만 선택 | commit 중단 후 교사와 파일 목록 정리 |

## 종료 티켓

학생은 아래 네 문장을 작성한다.

1. 오늘 내가 연결한 두 Component는 무엇인가?
2. 내가 찾은 오류의 증상, 원인, 수정은 무엇인가?
3. `Awake`, `Start`, `Update` 중 아직 헷갈리는 것은 무엇인가?
4. 다른 사람에게 맡겨도 될 만큼 책임을 나누기 어려웠던 코드는 무엇인가?
