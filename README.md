# portfolio_puyopuyo

</br>

## 1. 플레이 방법
- 깃허브 내의 파일을 받아서 플레이 해보실 수 있습니다.

## 2. 제작 기간 & 참여 인원
- 2022년 3월 10일 ~ 7월 5일
- 개인 프로젝트

</br>

## 3. 사용 기술
  - c# Form

</br>

## 4. 트러블 슈팅
  - 블록이 천천히 내려가는 타이머를 사용함과 동시에 같은색 블록 4개 이상이 이어지면 사라지는 애니메이션을 출력합니다.
  
  - 블럭이 사라지는 도중에는 새로운 블럭이 내려오면 안되고, 사라진 후 블록이 떨어지게 된 후 같은색 4개 이상이 또 이루어지는지 확인해야 하기 때문에 처리 순서가 뒤틀리면 바로 오류가 생겼습니다.

  - 블록이 내려오는 타이머와 애니메이션을 출력하는 타이머를 따로 관리한 후 블록의 색을 체크하는 부분은 블록이 내려왔을때와 애니메이션이 끝났을 경우에만 체크하도록 제작하였습니다.

<details>
<summary><b>코드</b></summary>
<div markdown="1">

~~~java
/**
 * 게시물 필터 (Tag Name)
 */
private void timer2_Tick(object sender, EventArgs e){

            if (IsBlockDeletePaint && TimerCnt < 15)
                IsBlockDeletePaint = false;
            else if (!IsBlockDeletePaint && TimerCnt < 15)
                IsBlockDeletePaint = true;

            TimerCnt++;
            if (TimerCnt >= 15) {
                IsBlockDeletePaint = false;
                for (int y = 2; y < 14; y++)
                    for (int x = 0; x < 6; x++) {
                        if (CheckMap[y, x] != 0) {
                            if (Map[y, x] > 5 && Map[y, x] <= 21)
                                Map[y, x] = 21;
                            else if (Map[y, x] > 21 && Map[y, x] <= 37)
                                Map[y, x] = 37;
                            else if (Map[y, x] > 37 && Map[y, x] <= 53)
                                Map[y, x] = 53;
                            else if (Map[y, x] > 53 && Map[y, x] <= 69)
                                Map[y, x] = 69;
                            else if (Map[y, x] > 69 && Map[y, x] <= 84)
                                Map[y, x] = 85;
                        }
                    }
            }
            if (TimerCnt >= 24) {
                TimerCnt = 0;
                CheckStuckBlockDelete();
                score += (150 * DeleteCount) + (250 * (ScoreStack - 1)) * ScoreStack;
                ScoreStack++;
                DeleteCount = 0;
                for (int z = 0; z < 12; z++) {
                    for (int y = 13; y >= 2; y--) {
                        for (int x = 0; x < 6; x++) {
                            if (Map[y, x] == 0 && Map[y - 1, x] != 0) {
                                Map[y, x] = Map[y - 1, x];
                                Map[y - 1, x] = 0;
                                if (y != 13)
                                    y++;
                            }
                        }
                    }
                }
                BombBlockCnt = 0;
                BlockConnect();
                CheckStuckBlockCount();
                ChangeTimer = false;

                //블록 4개이상 확인
                for (int y = 2; y < 14; y++)
                    for (int x = 0; x < 6; x++) {
                        if (CheckMap[y, x] != 0) {
                            ChangeTimer = true;
                        }
                    }

                if (!ChangeTimer)
                    NextBlock();
            }

            panel1.Invalidate();
        }
~~~

</div>
</details>

## 5.그 외 오류들
  - 블록이 바닥에 닿았을 때 유예시간 없이 바로 블록을 놓는 문제
  - 창 크기를 최대화 했을 경우 맵이 늘어나는 문제
  
  
## 6.느낀점
- 뿌요뿌요의 중요하다고 생각하는 부분을 제작하였으며 게임의 어떠한 이벤트가 일어났을 시 우선순위와 차례대로 실행하는 법을 모작을 통해 몸소 배웠습니다.
