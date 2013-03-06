REM Valid 2x2
MatrixSum.exe "[[2,4],[52,2]]"

REM Valid 3x3
MatrixSum.exe "[[2,31],[52,2],[24,12]]"

REM Valid 3x3 with a negative number
MatrixSum.exe "[[2,4,235],[52,24,74],[2353,26,-23]]"

REM Invalid 3x3 with invalid input
MatrixSum.exe "[[2,4,ABC],[52,24,74],[2353,26,-23]]"

REM 4x4 with a decimal
MatrixSum.exe "[[2,4,34,-235],[52.3,24,63,74],[234,2353,26,-23],[234,-2353,26,-23]]"

REM 3x3 with some invalid
MatrixSum.exe "[[2,4,1],[52,24],[2353,26,-23]]"


PAUSE