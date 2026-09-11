# 위치 동기화·맵 DLL v1.2.0

DLL과 XML을 Unity `Assets/Plugins`에 넣는다. 네임스페이스는 `School.PositionSync`다. 학생 기준 버전은 **Unity 6000.3.23f1**이다. DLL 대상은 .NET Standard 2.1 데스크톱용이며 WebGL은 지원하지 않는다. Player Settings의 API Compatibility Level은 .NET Standard 2.1을 사용한다.

## 기본 사용은 세 가지

```csharp
using School.PositionSync;

// 시작 시 한 번. 같은 PC의 서버에 자동 접속
Server server = new Server();
// 다른 PC라면 new Server("교사 PC의 LAN IPv4 주소");

// 매 프레임 내 캐릭터 이동 후
server.SetPos(new Info(myPosition.x, myPosition.y, 0));

// 매 프레임 최신 상대 위치
Info[] players = server.GetPos();
```

`Server`는 학생이 서버와 소통하는 객체다. 이 객체를 만든다고 중계 서버 프로그램이 실행되는 것은 아니다. 교사 PC에서 서버를 먼저 실행해야 한다. 기본 주소는 127.0.0.1, 포트는 7777이며 생성자에서 변경할 수 있다. 자동 서버 탐색은 없다.

| 호출 | 동작 |
|---|---|
| `new Server()` 또는 `new Server(host, port)` | 자동 비동기 접속 시작. await 불필요 |
| `server.SetPos(new Info(x, y, z))` | 내 최신 위치 저장. 50ms마다 자동 전송. z 생략 시 0 |
| `Info[] players = server.GetPos()` | 나를 제외한 상대 위치의 최신 배열 |

Info의 읽기 전용 속성은 `Id`, `X`, `Y`, `Z`다. 전송할 때 ID를 지정하지 않으며 서버가 연결별로 부여한다. 재접속 시 ID가 바뀐다. 배열의 순서 대신 ID로 상대 캐릭터를 구분한다. 생성 직후 접속 중이거나 상대가 없으면 빈 배열이다. 빈 배열만으로 접속 완료를 판단하지 않는다.

접속 실패·연결 단절은 이후 SetPos/GetPos에서 InvalidOperationException으로 알려준다. Unity 코드에서 try/catch로 오류를 표시하고, 해당 연결을 Dispose한 뒤 반복 호출을 중단한다. 재접속은 새 Server 객체를 만든다. 잘못된 주소 인수·포트·NaN 좌표도 예외다.

게임 종료·장면 전환 시 `OnDestroy`에서 `server?.Dispose()`를 한 번 호출한다. Dispose는 종료 정리용이며 여러 번 호출해도 안전하다. 서버 객체는 프레임마다 만들지 않는다.

## 학생이 작성할 부분

1. 자신의 이동·점프·충돌을 구현한 뒤 결과 좌표를 SetPos에 전달한다.
2. GetPos 결과에 처음 나타난 Id는 상대 프리팹을 생성한다.
3. 기존 Id는 해당 캐릭터 위치를 X/Y/Z로 바꾼다.
4. 이전 목록에는 있고 새 목록에는 없는 Id는 캐릭터를 제거한다.
5. 상대 프리팹에는 로컬 입력·이동·중력을 실행하지 않는다.

Unity Update/LateUpdate에서 호출하면 된다. 접속·전송 루프·스레드 관리는 DLL이 담당한다. 배열과 좌표는 데이터이므로 GameObject 생성·제거·위치 적용은 학생이 작성한다. 각 팀에서 연결 소유자는 한 명으로 정한다.

동기화는 ID와 위치뿐이며 회전·속도·점프 상태는 전송하지 않는다. 예측·보정·보간도 없다. X=오른쪽, Y=위, Z=0 기준으로 팀 간 좌표와 이동 규칙을 맞춘다.

기존 SyncClient API는 호환성을 위해 남겨 두지만 이번 학생 과제는 Server API로 진행한다.

## v1.1 추가: 맵 그리드 조회

`MapCatalog.Default`는 접속 없이 읽을 수 있는 **64×16 공통 연습 맵**이다. 정확한 마리오 1-1 복제 좌표가 아니다. 맵 ID는 `classroom-platformer-01`, 배치 버전은 `1`이다. 모든 팀은 같은 맵 버전을 사용한다. 서버는 맵 버전을 검사하거나 맵을 전송하지 않는다.

```csharp
GridMap map = MapCatalog.Default;
foreach (GridCell cell in map.Cells)
{
    PlayerPosition center = map.GetCellCenter(cell.X, cell.Y);
    // 학생 코드: cell.Kind에 맞는 프리팹 생성
    // 중심 위치 = (center.X, center.Y, center.Z), 크기 = map.CellSize
    // cell.IsSolid를 보고 Collider 설정
}
PlayerPosition startFeet = map.SpawnFeet;
```

| API | 의미 |
|---|---|
| `Width`, `Height` | 열·행 수 |
| `CellSize` | 한 칸 = 1 월드 단위 |
| `OriginX`, `OriginY` | 맵 왼쪽 아래 = (0, 0) |
| `Cells` | 빈 칸을 제외한 읽기 전용 셀 목록 |
| `GetTile(x, y)` | Empty/Ground/Brick/Question/Pipe/Stair. 범위 밖은 예외 |
| `GetCellCenter(x, y)` | 셀 중앙의 월드 XYZ, Z=0 |
| `Spawn`, `Goal` | 시작·도착 마커의 그리드 좌표. 해당 칸 자체는 빈 칸 |
| `SpawnFeet` | 캐릭터 발 기준 시작 월드 좌표 (2.5, 2, 0) |
| `FallBoundaryY` | 권장 추락 기준 -4. 판정·부활은 직접 구현 |

X는 오른쪽, Y는 위로 증가한다. 셀 (0,0)은 [0,1]×[0,1]이고 중심은 (0.5,0.5)이다. 중심 피벗의 플레이어는 SpawnFeet의 Y에 캐릭터 반높이를 더해 배치한다. 도착 표시도 Goal 좌표를 월드 좌표로 바꿔 직접 만든다.

Cell의 `Id`는 `Y * Width + X`이며 `IsSolid`는 데이터일 뿐이다. DLL이 Collider를 생성하거나 착지를 판정하지 않는다. 파이프와 계단도 한 칸씩 제공하므로 그대로 생성하거나 같은 종류의 인접 셀을 묶어서 표현한다. 외형을 묶더라도 충돌 영역은 공통 그리드와 같아야 한다. Question은 표시 종류만 제공하며 아이템 생성이나 블록 파괴는 포함하지 않는다.
