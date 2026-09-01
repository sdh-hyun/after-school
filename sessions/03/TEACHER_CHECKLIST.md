# 3회차 교사용 체크리스트

## 수업 전날

- [ ] 사용할 Unity LTS 정확한 버전 기록
- [ ] Project Settings→Player→Active Input Handling을 `Input Manager (Old)` 또는 `Both`로 통일
- [ ] 전 PC에서 기준 프로젝트가 열리는지 확인
- [ ] Console compile error가 없는 정상 장면 준비
- [ ] `session03-normal` 장면 백업
- [ ] `session03-broken` 장면 또는 학생별 고장 버전 준비
- [ ] Player, Coin, GameManager, CoinSpawner 구성 확인
- [ ] Coin Prefab과 Sprite 대체 자원 준비
- [ ] Unity용 `.gitignore` 적용 확인
- [ ] 기준 브랜치와 학생 브랜치 규칙 공지 준비
- [ ] 15명 평가 기록표 출력 또는 복사

## 정상 장면 검증

- [ ] Player가 WASD와 방향키로 이동
- [ ] 대각선 이동 속도 정규화
- [ ] Player에 Rigidbody2D와 Collider2D 존재
- [ ] Rigidbody2D의 Gravity Scale이 0
- [ ] Coin Collider2D의 Is Trigger 활성화
- [ ] Coin Prefab에 `Coin` Component 존재
- [ ] PlayerCollector의 ScoreManager 참조 연결
- [ ] CoinSpawner의 Coin Prefab 참조 연결
- [ ] Coin 획득 시 점수 1회 증가
- [ ] Coin 획득 후 인스턴스 제거
- [ ] Play를 여러 번 반복해도 Console 오류 없음

## 고장 장면 준비표

학생에게 모든 오류를 한꺼번에 주지 말고 2~3개만 배정한다.

| 오류 코드 | 고장 내용 | 준비 | 배정 학생 |
|---|---|---|---|
| B1 | PlayerMover 비활성화 | [ ] |  |
| B2 | speed 0 | [ ] |  |
| B3 | Rigidbody2D 제거 | [ ] |  |
| B4 | Coin Is Trigger 해제 | [ ] |  |
| B5 | ScoreManager 참조 제거 | [ ] |  |
| B6 | Coin Prefab 참조 제거 | [ ] |  |
| B7 | Coin Component 제거 | [ ] |  |

## 수업 시작 직전

- [ ] 출석과 예상 인원 갱신
- [ ] 1·2회차 미완료자 또는 기초 지원 학생 확인
- [ ] 프로젝터 Game 뷰와 Inspector 글자 크기 확인
- [ ] Console이 보이도록 창 배치
- [ ] GitHub 로그인과 원격 저장소 접근 확인
- [ ] 정상 프로젝트 복구 사본 위치 확인
- [ ] 42분, 60분, 85분, 105분 중간 점검 타이머 준비
- [ ] 60~105분 1인 3분 순회 평가 순서표 준비(빠른 완료자부터 시작)

## 수업 중 관찰

- [ ] 학생이 Console의 첫 오류부터 읽는가?
- [ ] 코드를 무작정 바꾸기 전에 증상을 말하는가?
- [ ] Hierarchy에서 객체를 고르고 Inspector Component를 찾는가?
- [ ] `None` 참조를 스스로 인식하는가?
- [ ] 한 번에 한 조건만 바꾸고 재실행하는가?
- [ ] 짝의 코드를 대신 작성하지 않고 질문으로 돕는가?
- [ ] AI 사용 부분을 밝히고 설명하는가?
- [ ] 빠른 학생이 확장 기능의 책임 Component를 설명하는가?
- [ ] 60분까지 최소 기능 미완료 학생을 표시했는가?
- [ ] 60분부터 개인 설명·현장 변경을 순회 확인했는가?
- [ ] 85분에 미평가 학생을 다시 표시했는가?

## 최소 기능이 늦어질 때 축소 순서

1. 새 Sprite 제작을 생략하고 기본 Square Sprite를 사용한다.
2. 학생이 직접 Prefab을 만드는 대신 교사 제공 Coin Prefab을 사용한다.
3. UI 확장 기능을 생략하고 Console 점수 출력만 확인한다.
4. 입력이 막히면 교사 정상 Player를 제공하되 충돌과 참조 연결은 학생이 수행한다.
5. Git 환경 문제 학생은 로컬 commit까지 완료하고 PR은 수업 후 보충한다.

## 60~105분 순회 평가 기록

| 순서 | 번호/아이디 | 시작 | 설명 질문 | 현장 변경 | 완료/보충 |
|---:|---|---|---|---|---|
| 1 |  |  |  |  |  |
| 2 |  |  |  |  |  |
| 3 |  |  |  |  |  |
| 4 |  |  |  |  |  |
| 5 |  |  |  |  |  |
| 6 |  |  |  |  |  |
| 7 |  |  |  |  |  |
| 8 |  |  |  |  |  |
| 9 |  |  |  |  |  |
| 10 |  |  |  |  |  |
| 11 |  |  |  |  |  |
| 12 |  |  |  |  |  |
| 13 |  |  |  |  |  |
| 14 |  |  |  |  |  |
| 15 |  |  |  |  |  |

## 종료 전

- [ ] 제출 PR 수 / 참석 인원 기록
- [ ] `Library`, `Temp`, `Logs`, `obj`가 PR에 포함되지 않았는지 확인
- [ ] 학생별 구두 설명 결과 기록
- [ ] 학생별 현장 변경 결과 기록
- [ ] 미완료 학생의 마지막 성공 단계 기록
- [ ] 반복된 Unity·Git 문제 기록
- [ ] 4회차에서 다룰 과도한 책임 또는 직접 참조 사례 수집
- [ ] 전체 정상 장면을 한 번 실행
- [ ] `RETROSPECTIVE.md` 작성 담당과 시점 확인
