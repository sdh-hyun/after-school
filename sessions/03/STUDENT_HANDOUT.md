# 3회차 학생용 실습지 — Unity 부품을 연결해 동작 만들기

## 오늘의 미션

Player가 움직여 Coin을 먹으면 점수가 올라가고 Coin이 사라지는 장면을 만든다. 마지막에는 일부러 고장 난 장면에서 원인을 찾아 고친다.

## 완료 체크

- [ ] WASD 또는 방향키로 Player가 움직인다.
- [ ] Coin에 닿으면 점수가 증가한다.
- [ ] 획득한 Coin이 사라진다.
- [ ] `CoinSpawner`가 Coin Prefab을 생성한다.
- [ ] 고장 난 장면에서 오류를 2개 이상 찾아 원인과 수정 내용을 적었다.
- [ ] 개인 브랜치에 commit하고 PR을 제출했다.

## 핵심 개념

```text
GameObject = 장면에 존재하는 그릇
Component  = 그 그릇에 붙이는 데이터와 기능
Prefab     = 재사용할 GameObject 원본
Reference  = 한 Component가 장면의 다른 객체를 가리키는 연결
```

- `Awake`: 자기 Component의 초기 준비와 내부 참조 확보
- `Start`: 첫 프레임 전에 실행할 시작 작업
- `Update`: 활성화된 동안 프레임마다 반복되는 작업

## 1. 장면 구성

```text
GameManager [ScoreManager]
Player [Rigidbody2D, Collider2D, PlayerMover, PlayerCollector]
CoinSpawner [CoinSpawner]
Coin Prefab [Collider2D(Is Trigger), Coin]
```

Player의 `Rigidbody2D`는 수업용 2D 장면에서 중력의 영향을 받지 않도록 `Gravity Scale`을 0으로 설정한다. Coin의 Collider2D는 `Is Trigger`를 켠다.

> 실행 즉시 입력 관련 `InvalidOperationException`이 나오면 코드를 바꾸지 말고 교사에게 알린다. 프로젝트의 Active Input Handling 설정 문제일 수 있다.

## 2. 스크립트 작성

### PlayerMover.cs

```csharp
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private void Update()
    {
        float x = 0f;
        float y = 0f;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) x -= 1f;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) x += 1f;
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) y -= 1f;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) y += 1f;

        Vector3 direction = new Vector3(x, y, 0f).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }
}
```

### Coin.cs

```csharp
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int points = 10;

    public int Points => points;
}
```

### ScoreManager.cs

```csharp
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int score;

    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log($"Score: {score}");
    }
}
```

### PlayerCollector.cs

```csharp
using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    [SerializeField] private ScoreManager scoreManager;

    private void Awake()
    {
        Debug.Log("PlayerCollector 준비");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Coin coin = other.GetComponent<Coin>();
        if (coin == null) return;

        scoreManager.AddScore(coin.Points);
        Destroy(other.gameObject);
    }
}
```

### CoinSpawner.cs

```csharp
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private Vector3 spawnPosition = new Vector3(2f, 0f, 0f);

    private void Start()
    {
        Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
    }
}
```

## 3. Inspector 연결

코드를 작성했더라도 아래 연결을 하지 않으면 완성되지 않는다.

1. GameManager에 `ScoreManager`를 붙인다.
2. Player에 `PlayerMover`와 `PlayerCollector`를 붙인다.
3. PlayerCollector의 `Score Manager` 슬롯에 장면의 GameManager를 드래그한다.
4. Coin을 Prefab으로 만들고 `CoinSpawner`의 `Coin Prefab` 슬롯에 드래그한다.
5. Play 후 이동→충돌→Console 점수 출력 순서로 확인한다.

## 4. 작동하지 않을 때 확인 순서

무작정 코드를 바꾸지 말고 아래 순서로 확인한다.

1. 증상을 한 문장으로 적는다.
2. Console의 가장 위 compile error 또는 exception을 읽는다.
3. 문제가 코드인지 Inspector 설정인지 가설을 세운다.
4. 한 번에 한 가지만 바꾸고 다시 실행한다.
5. 무엇을 바꿨고 결과가 어떻게 달라졌는지 기록한다.

### 빠른 체크리스트

- Script가 올바른 GameObject에 붙어 있고 활성화되어 있는가?
- `speed`가 0은 아닌가?
- Player와 Coin 양쪽에 Collider2D가 있는가?
- Coin의 `Is Trigger`가 켜져 있는가?
- 최소 한쪽에 Rigidbody2D가 있는가?
- Inspector의 참조 슬롯이 `None`은 아닌가?
- Prefab에 필요한 Component가 붙어 있는가?

## 5. 디버깅 기록

| 번호 | 증상 | 내 가설 | 확인한 것 | 실제 원인 | 수정 결과 |
|---:|---|---|---|---|---|
| 1 |  |  |  |  |  |
| 2 |  |  |  |  |  |
| 3 |  |  |  |  |  |

## 개인 확인 대기 중 할 일

60분부터 교사가 한 명씩 부른다. 내 순서가 아닐 때는 다음을 계속한다.

1. 이동→Coin 충돌→점수 출력→Coin 제거를 두 번 실행한다.
2. 설명할 연결 흐름을 30초로 연습한다.
3. 고장 장면의 증상·가설·확인 내용을 기록한다.
4. 평가가 끝나면 확장 과제 또는 Git 변경 파일 확인을 시작한다.

## 6. 확장 과제

아래에서 하나를 선택한다.

- Coin 여러 개를 서로 다른 위치에 생성한다.
- 점수가 30 이상이면 `Clear!`를 출력한다.
- Coin이 중복 처리되지 않게 획득 여부를 추가한다.
- Console 대신 Canvas의 Text에 점수를 표시한다.

추가한 기능은 “어떤 Component가 책임지는가”를 PR 본문에 적는다.

## 7. 제출

- 브랜치: `session03/<GitHub아이디>`
- commit 예시: `feat: connect player coin and score components`
- PR 본문에 반드시 적을 내용
  - 완성한 기능
  - 찾은 오류와 원인
  - 교사 요청으로 현장에서 변경한 내용
  - AI 사용 여부와 사용한 부분

AI 사용은 허용된다. 다만 제출한 코드를 설명하고 수업 중 조건이 바뀌었을 때 직접 수정할 수 있어야 완료로 인정된다.
