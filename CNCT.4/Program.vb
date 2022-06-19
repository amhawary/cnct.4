Imports System

Module Program
    Sub setUpScreen()
        Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight)
    End Sub

    Sub runGame(ByRef score1 As Integer, ByRef score2 As Integer, ByRef flag(,) As Boolean)
        Dim grid(6, 7) As String
        Dim tos(7) As Integer
        Dim current As Integer

        initialiseGame(grid, tos)
        randomStart(current)
        SwitchTurns(current)
        While gameEnds(grid, current, flag) = False And checkDraw(grid) = False
            SwitchTurns(current)
            updateGrid(grid, current, score1, score2)
            inputNum(current, grid, tos, score1, score2)
        End While
        announceWinner(grid, current, score1, score2, flag)
    End Sub
    Sub Main(args As String())
        Dim score1 As Integer
        Dim score2 As Integer
        Dim maxRounds As Integer
        Dim flag(6, 7) As Boolean
        Dim choice As Integer
        score1 = 0
        score2 = 0

        setUpScreen()
        titleScreen()
        choice = rounds()
        If choice = 6 Then
            Do
                runGame(score1, score2, flag)
            Loop
        Else
            Select Case choice
                Case 1 : maxRounds = 1
                Case 2 : maxRounds = 3
                Case 3 : maxRounds = 5
                Case 4 : maxRounds = 7
                Case 5 : maxRounds = 9
            End Select

            For i = 1 To maxRounds
                runGame(score1, score2, flag)
            Next
            tieWinner(score1, score2)
        End If

        Console.ReadKey()
    End Sub
    Sub initialiseGame(board(,) As String, tosArray() As Integer)

        For i = 1 To 7
            tosArray(i) = 6
        Next
        For i = 1 To 6
            For j = 1 To 7
                board(i, j) = "__"
            Next
        Next
    End Sub
    Sub randomStart(ByRef currentTurn As Integer)
        Dim r As New Random
        Console.ForegroundColor = ConsoleColor.White
        Console.Clear()
        Console.Write(<![CDATA[____________________________________________________________________________________________________________________________________________________________________
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                               FIRST TURN WILL NOW                                 |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                     BE CHOSEN                                     |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|_______________________________________|___________________________________________________________________________________|________________________________________|)

]]>.Value)

        currentTurn = r.Next(1, 3)
        Threading.Thread.Sleep(3000)
    End Sub
    Sub titleScreen()
        Console.ForegroundColor = ConsoleColor.White
        Console.WriteLine(<![CDATA[
                          


             ________________________    _______        ______   _________________________    _________________________           ______       ______
            |                        |  |       \      |      |  |                        |  |                         |         |      |     |      |
            |                        |  |        \     |      |  |                        |  |                         |         |      |     |      |
            |       _________________|  |         \    |      |  |       _________________|  |_________        ________|         |      |     |      |
            |      |                    |          \   |      |  |      |                              |      |                  |      |     |      |
            |      |                    |           \  |      |  |      |                              |      |                  |      |_____|      |
            |      |                    |            \ |      |  |      |                              |      |                  |                   |
            |      |                    |      |\     \|      |  |      |                              |      |                  |                   |
            |      |                    |      | \            |  |      |                              |      |                  |____________       |
            |      |                    |      |  \           |  |      |                              |      |                               |      |
            |      |_________________   |      |   \          |  |      |_________________             |      |        _____                  |      |
            |                        |  |      |    \         |  |                        |            |      |       |     |                 |      |
            |                        |  |      |     \        |  |                        |            |      |       |     |                 |      |                  
            |________________________|  |______|      \_______|  |________________________|            |______|       |_____|                 |______|                               








                                                                  ( CONNECT FOUR BUT COOLER )
                                                                 _____________________________
                                                      
                                                                    PRESS ANY KEY TO START.



                                                                                                            BY SEIF FT AMIN FT YOUSSOF FT MOHAMMAD. 2020
________________________________________________________________________________________________________________________________________________________________________







]]>.Value)
        Console.ReadKey()
    End Sub
    Sub updateGrid(array As String(,), currentTurn As Integer, ByRef score1 As Integer, ByRef score2 As Integer)
        Console.Clear()
        If currentTurn = 1 Then
            Console.ForegroundColor = ConsoleColor.Red
        Else
            Console.ForegroundColor = ConsoleColor.Blue
        End If
        Console.Write(<![CDATA[ ____________________________________________________________________________________________________________________________________________________________________
|              Player 1                 |                                                                                   |               Player 2                 |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|             SCORE: ]]>.Value)
        Console.Write(score1 & "                  |                                                                                   |              SCORE: " & score2)
        Console.Write(<![CDATA[                  |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                               ]]>.Value)
        If currentTurn = 1 Then
            Console.Write("It's Player 1's turn!")
        Else
            Console.Write("It's Player 2's turn!")
        End If
        Console.Write(<![CDATA[                               |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                  ]]>.Value)
        For i = 1 To 6
            For j = 1 To 7
                If array(i, j) = "p1" Then
                    Console.ForegroundColor = ConsoleColor.Red
                    Console.Write("[---]  ")
                ElseIf array(i, j) = "p2" Then
                    Console.ForegroundColor = ConsoleColor.Blue
                    Console.Write("[---]  ")
                Else
                    Console.ForegroundColor = ConsoleColor.White
                    Console.Write("[   ]  ")
                End If

            Next
            If currentTurn = 1 Then
                Console.ForegroundColor = ConsoleColor.Red
            Else
                Console.ForegroundColor = ConsoleColor.Blue
            End If
            Console.Write(<![CDATA[                |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                  ]]>.Value)
        Next
        Console.Write(<![CDATA[  1      2      3      4      5      6      7                    |                                        |
|_______________________________________|___________________________________________________________________________________|________________________________________|

]]>.Value)
    End Sub
    Sub errorMessage(array As String(,), currentTurn As Integer, ByRef score1 As Integer, ByRef score2 As Integer)
        Console.Clear()
        Console.ForegroundColor = ConsoleColor.Yellow
        Console.Write(<![CDATA[ ____________________________________________________________________________________________________________________________________________________________________
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                             ___________________________                           |                                        |
|                                       |                            |                           |                          |                                        |
|                                       |                            |    ERROR: INVALID MOVE!   |                          |                                        |
|                                       |                            |___________________________|                          |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                  ]]>.Value)

        For i = 1 To 6
            For j = 1 To 7
                If array(i, j) = "p1" Or array(i, j) = "p2" Then
                    Console.Write("[---]  ")

                Else
                    Console.Write("[   ]  ")
                End If

            Next
            Console.Write(<![CDATA[                |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                  ]]>.Value)
        Next
        Console.Write(<![CDATA[                                                                 |                                        |
|_______________________________________|___________________________________________________________________________________|________________________________________|]]>.Value)

        Threading.Thread.Sleep(2000)
        updateGrid(array, currentTurn, score1, score2)
    End Sub
    Function validnum(ByVal column As Integer) As Boolean
        Dim valid As Boolean
        If column <= 7 And column >= 1 Then
            valid = True
        Else
            valid = False
        End If
        Return valid
    End Function
    Function TOScheck(ByVal TOS As Integer, tosarray() As Integer) As Boolean
        Dim valid As Boolean
        If TOS > 7 Or TOS < 1 Then
            valid = False

        Else
            If tosarray(TOS) > 0 Then
                valid = True
            Else
                valid = False
            End If
        End If
        Return valid
    End Function
    Sub inputNum(ByRef currentTurn As Integer, ByRef array(,) As String, ByRef tosarray() As Integer, ByRef score1 As Integer, ByRef score2 As Integer)
        Dim column As Integer
        Do
            Try
                Console.WriteLine("Enter column number:")
                column = Console.ReadLine()

                While validnum(column) = False Or TOScheck(column, tosarray) = False
                    errorMessage(array, currentTurn, score1, score2)
                    Console.WriteLine("Enter column number:")
                    column = Console.ReadLine()
                End While
            Catch
                errorMessage(array, currentTurn, score1, score2)
            End Try
        Loop Until validnum(column) = True And TOScheck(column, tosarray) = True
        Console.Clear()

        If currentTurn = 1 Then
            array(tosarray(column), column) = "p1"
        Else
            array(tosarray(column), column) = "p2"
        End If
        tosarray(column) = tosarray(column) - 1
    End Sub
    Sub SwitchTurns(ByRef current As Integer)
        If current = 1 Then
            current = 2
        Else
            current = 1
        End If
    End Sub
    Function gameEnds(ByVal board(,) As String, ByVal x As String, ByRef flag(,) As Boolean) As Boolean
        Dim result As Boolean = False
        If x = 1 Then
            x = "p1"
        Else
            x = "p2"
        End If
        flagAllFalse(flag)
        For i = 1 To 7
            For j = 1 To 3
                If board(j, i) = x And board(j + 1, i) = x And board(j + 2, i) = x And board(j + 3, i) = x Then
                    result = True
                    flag(j, i) = True
                    flag(j + 1, i) = True
                    flag(j + 2, i) = True
                    flag(j + 3, i) = True
                End If
            Next
        Next i
        For i = 1 To 6
            For j = 1 To 4
                If board(i, j) = x And board(i, j + 1) = x And board(i, j + 2) = x And board(i, j + 3) = x Then
                    result = True
                    flag(i, j) = True
                    flag(i, j + 1) = True
                    flag(i, j + 2) = True
                    flag(i, j + 3) = True
                End If
            Next
        Next i
        If board(4, 1) = x And board(3, 2) = x And board(2, 3) = x And board(1, 4) = x Then
            result = True
            flag(4, 1) = True
            flag(3, 2) = True
            flag(2, 3) = True
            flag(1, 4) = True
        End If
        If board(6, 4) = x And board(5, 5) = x And board(4, 6) = x And board(3, 7) = x Then
            result = True
            flag(6, 4) = True
            flag(5, 5) = True
            flag(4, 6) = True
            flag(3, 7) = True
        End If
        Dim k As Integer = 1
        For i = 5 To 4 Step -1

            If board(i, k) = x And board(i - 1, k + 1) = x And board(i - 2, k + 2) = x And board(i - 3, k + 3) = x Then
                result = True
                flag(i, k) = True
                flag(i - 1, k + 1) = True
                flag(i - 2, k + 2) = True
                flag(i - 3, k + 3) = True
            End If
            k = k + 1
        Next i
        k = 1
        For i = 6 To 4 Step -1
            For j = k To k + 1
                If board(i, j) = x And board(i - 1, j + 1) = x And board(i - 2, j + 2) = x And board(i - 3, j + 3) = x Then
                    result = True
                    flag(i, j) = True
                    flag(i - 1, j + 1) = True
                    flag(i - 2, j + 2) = True
                    flag(i - 3, j + 3) = True
                End If
            Next
            k = k + 1
        Next
        k = 3
        For i = 6 To 5 Step -1
            If board(i, k) = x And board(i - 1, k + 1) = x And board(i - 2, k + 2) = x And board(i - 3, k + 3) = x Then
                result = True
                flag(i, k) = True
                flag(i - 1, k + 1) = True
                flag(i - 2, k + 2) = True
                flag(i - 3, k + 3) = True
            End If
            k = k + 1
        Next
        If board(3, 1) = x And board(4, 2) = x And board(5, 3) = x And board(6, 4) = x Then
            result = True
            flag(3, 1) = True
            flag(4, 2) = True
            flag(5, 3) = True
            flag(6, 4) = True

        End If
        If board(1, 4) = x And board(2, 5) = x And board(3, 6) = x And board(4, 7) = x Then
            result = True
            flag(1, 4) = True
            flag(2, 5) = True
            flag(3, 6) = True
            flag(4, 7) = True
        End If
        k = 1
        For i = 2 To 3
            If board(i, k) = x And board(i + 1, k + 1) = x And board(i + 2, k + 2) = x And board(i + 3, k + 3) = x Then
                result = True
                flag(i, k) = True
                flag(i + 1, k + 1) = True
                flag(i + 2, k + 2) = True
                flag(i + 3, k + 3) = True
            End If
            k = k + 1
        Next
        k = 3
        For i = 1 To 2
            If board(i, k) = x And board(i + 1, k + 1) = x And board(i + 2, k + 2) = x And board(i + 3, k + 3) = x Then
                result = True
                flag(i, k) = True
                flag(i + 1, k + 1) = True
                flag(i + 2, k + 2) = True
                flag(i + 3, k + 3) = True
            End If
            k = k + 1
        Next
        k = 1
        For i = 1 To 3
            For j = k To k + 1
                If board(i, k) = x And board(i + 1, k + 1) = x And board(i + 2, k + 2) = x And board(i + 3, k + 3) = x Then
                    result = True
                    flag(i, k) = True
                    flag(i + 1, k + 1) = True
                    flag(i + 2, k + 2) = True
                    flag(i + 3, k + 3) = True
                End If
            Next
            k = k + 1
        Next
        Return result
    End Function

    Sub flagAllFalse(ByRef flag(,) As Boolean)
        For i = 1 To 6
            For z = 1 To 7
                flag(i, z) = False
            Next
        Next
    End Sub
    Function checkDraw(ByVal thearray(,) As String) As Boolean
        Dim valid As Boolean = True
        For i = 1 To 6
            For z = 1 To 7
                If thearray(i, z) = "__" Then
                    valid = False
                End If
            Next
        Next
        Return valid
    End Function
    Sub announceWinner(ByVal array(,) As String, current As Integer, ByRef score1 As Integer, ByRef score2 As Integer, ByRef flag(,) As Boolean)
        If checkDraw(array) = True Then
            Console.ForegroundColor = ConsoleColor.White
            Console.Write(<![CDATA[____________________________________________________________________________________________________________________________________________________________________
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                             ___________________________                           |                                        |
|                                       |                            |                           |                          |                                        |
|                                       |                            |    GAME ENDED AS A DRAW!  |                          |                                        |
|                                       |                            |___________________________|                          |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                  [   ]  [   ]  [   ]  [   ]  [   ]  [   ]  [   ]                  |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                  [   ]  [   ]  [   ]  [   ]  [   ]  [   ]  [   ]                  |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                  [   ]  [   ]  [   ]  [   ]  [   ]  [   ]  [   ]                  |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                  [   ]  [   ]  [   ]  [   ]  [   ]  [   ]  [   ]                  |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                  [   ]  [   ]  [   ]  [   ]  [   ]  [   ]  [   ]                  |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                  [   ]  [   ]  [   ]  [   ]  [   ]  [   ]  [   ]                  |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|_______________________________________|___________________________________________________________________________________|________________________________________|]]>.Value)
        Else
            If current = 1 Then
                score1 = score1 + 1
                Console.ForegroundColor = ConsoleColor.Red
                Console.Write(<![CDATA[ ____________________________________________________________________________________________________________________________________________________________________
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                             ___________________________                           |                                        |
|                                       |                            |                           |                          |                                        |
|                                       |                            | PLAYER 1 HAS WON THE GAME!|                          |                                        |
|                                       |                            |___________________________|                          |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                  ]]>.Value)
                For i = 1 To 6
                    For j = 1 To 7
                        If flag(i, j) = True Then
                            Console.ForegroundColor = ConsoleColor.Yellow
                            Console.Write("[---]  ")
                        ElseIf array(i, j) <> "__" Then
                            Console.ForegroundColor = ConsoleColor.Red
                            Console.Write("[---]  ")
                        Else
                            Console.ForegroundColor = ConsoleColor.Red
                            Console.Write("[   ]  ")
                        End If

                    Next
                    Console.ForegroundColor = ConsoleColor.Red
                    Console.Write(<![CDATA[                |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                  ]]>.Value)
                Next
                Console.Write(<![CDATA[                                                                 |                                        |
|_______________________________________|___________________________________________________________________________________|________________________________________|

]]>.Value)

            Else
                score2 = score2 + 1
                Console.ForegroundColor = ConsoleColor.Blue
                Console.Write(<![CDATA[ ____________________________________________________________________________________________________________________________________________________________________
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                             ___________________________                           |                                        |
|                                       |                            |                           |                          |                                        |
|                                       |                            | PLAYER 2 HAS WON THE GAME!|                          |                                        |
|                                       |                            |___________________________|                          |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                  ]]>.Value)
                For i = 1 To 6
                    For j = 1 To 7
                        If flag(i, j) = True Then
                            Console.ForegroundColor = ConsoleColor.Yellow
                            Console.Write("[---]  ")
                        ElseIf array(i, j) <> "__" Then
                            Console.ForegroundColor = ConsoleColor.Blue
                            Console.Write("[---]  ")
                        Else
                            Console.ForegroundColor = ConsoleColor.Blue
                            Console.Write("[   ]  ")
                        End If

                    Next
                    Console.ForegroundColor = ConsoleColor.Blue
                    Console.Write(<![CDATA[                |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                  ]]>.Value)
                Next
                Console.Write(<![CDATA[                                                                 |                                        |
|_______________________________________|___________________________________________________________________________________|________________________________________|

]]>.Value)

            End If
        End If

        Threading.Thread.Sleep(2000)
        Console.WriteLine("Press any key to continue")
        Console.ReadKey()
    End Sub
    Function rounds() As Integer
        Dim choice As Integer
        Console.Clear()
        Console.ForegroundColor = ConsoleColor.White
        Console.Write(<![CDATA[ ____________________________________________________________________________________________________________________________________________________________________
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                             ___________________________                           |                                        |
|                                       |                            |                           |                          |                                        |
|                                       |                            |     NUMBER OF ROUNDS      |                          |                                        |
|                                       |                            |___________________________|                          |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                  ENTER 1 : BEST OF 1        (FIRST TO 1 POINT)                    |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                  ENTER 2 : BEST OF 3        (FIRST TO 2 POINTS)                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                  ENTER 3 : BEST OF 5        (FIRST TO 3 POINTS)                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                  ENTER 4 : BEST OF 7        (FIRST TO 4 POINTS)                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                  ENTER 5 : BEST OF 9        (FIRST TO 5 POINTS)                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|                                       |                  ENTER 6 : INFINITE ROUNDS  (UNTIL ONE OF YOU GETS BORED)         |                                        |
|                                       |                                                                                   |                                        |
|                                       |                                                                                   |                                        |
|_______________________________________|___________________________________________________________________________________|________________________________________|


Enter your choice:

]]>.Value)
        Do
            Try
                choice = Console.ReadLine()
                While choice > 6 Or choice < 1
                    Console.WriteLine("Invalid, choose a number between 1 and 6:")
                    choice = Console.ReadLine()
                End While
            Catch
                Console.WriteLine("Invalid, choose a number between 1 and 6:")

            End Try
        Loop Until choice >= 1 And choice <= 6
        Console.Clear()
        Return choice
    End Function
    Sub tieWinner(ByRef score1 As Integer, ByRef score2 As Integer)
        Console.Clear()
        If score1 > score2 Then
            Console.ForegroundColor = ConsoleColor.Red
            Console.Write(<![CDATA[ ____________________________________________________________________________________________________________________________________________________________________
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|                                                                     ___________________________                                                                    |
|                                                                    |                           |                                                                   |
|                                                                    |  PLAYER 1 HAS WON THE TIE |                                                                   |
|                                                                    |        SCORE:]]>.Value)
            Console.Write(score1 & "-" & score2)
            Console.Write(<![CDATA[          |                                                                   |
|                                                                    |___________________________|                                                                   |
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|____________________________________________________________________________________________________________________________________________________________________|


]]>.Value)
        ElseIf score2 > score1 Then
            Console.ForegroundColor = ConsoleColor.Blue
            Console.Write(<![CDATA[ ____________________________________________________________________________________________________________________________________________________________________
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|                                                                     ___________________________                                                                    |
|                                                                    |                           |                                                                   |
|                                                                    |  PLAYER 2 HAS WON THE TIE |                                                                   |
|                                                                    |        SCORE:]]>.Value)
            Console.Write(score2 & "-" & score1)
            Console.Write(<![CDATA[          |                                                                   |
|                                                                    |___________________________|                                                                   |
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|____________________________________________________________________________________________________________________________________________________________________|







]]>.Value)
        Else
            Console.ForegroundColor = ConsoleColor.White
            Console.Write(<![CDATA[ ____________________________________________________________________________________________________________________________________________________________________
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|                                                                     ___________________________                                                                    |
|                                                                    |                           |                                                                   |
|                                                                    |THE TIE HAS ENDED IN A DRAW|                                                                   |
|                                                                    |        SCORE:]]>.Value)
            Console.Write(score1 & "-" & score2)
            Console.Write(<![CDATA[          |                                                                   |
|                                                                    |___________________________|                                                                   |
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|                                                                                                                                                                    |
|____________________________________________________________________________________________________________________________________________________________________|







]]>.Value)
        End If
    End Sub

    'CNCT.4 CREDITS


    '- AMIN MOHAMMAD AL HAWARY
    'GREEN HEIGHTS INTERNATIONAL SCHOOL EG147
    'YEAR 11

    '- MOHAMED TAREK MOHAMED MOHAMED SAAFAN
    'NEFERTARI INTERNATIONAL SCHOOL EG037
    'YEAR 11

    '-SEIF AMR AHMED ALY ELFAYOUMY
    'NEFERTARI INTERNATIONAL SCHOOL EG037
    'YEAR 12

    '- YOUSSOF MOHAMED MASOUD MOHAMED
    'MANARET AL FAROUK ISLAMIC LANGUAGE SCHOOL EG062
    'YEAR 12 
End Module
