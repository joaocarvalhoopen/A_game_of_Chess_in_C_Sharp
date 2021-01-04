/*
 * Author: João Nuno Carvalho
 * Date:   2021.01.03
 * Description: A simple game of Chess in C# programming language.
 * License: MIT Open Source License.
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace Chess_in_C_Sharp
{
    public class Board
    {
        private Player white;
        private Player black;
        private Piece[,] board = { { new PieceTour(Color.Black), new PieceHorse(Color.Black), new PieceBishop(Color.Black), new PieceKing(Color.Black),
                             new PieceQueen(Color.Black), new PieceBishop(Color.Black), new PieceHorse(Color.Black), new PieceTour(Color.Black)},
                           { new PiecePawn(Color.Black), new PiecePawn(Color.Black), new PiecePawn(Color.Black), new PiecePawn(Color.Black),
                             new PiecePawn(Color.Black), new PiecePawn(Color.Black), new PiecePawn(Color.Black), new PiecePawn(Color.Black)},
                           { null, null, null, null, null, null, null, null },
                           { null, null, null, null, null, null, null, null },
                           { null, null, null, null, null, null, null, null },
                           { null, null, null, null, null, null, null, null },
                           { new PiecePawn(Color.White), new PiecePawn(Color.White), new PiecePawn(Color.White), new PiecePawn(Color.White),
                             new PiecePawn(Color.White), new PiecePawn(Color.White), new PiecePawn(Color.White), new PiecePawn(Color.White)},
                           { new PieceTour(Color.White), new PieceHorse(Color.White), new PieceBishop(Color.White), new PieceKing(Color.White),
                             new PieceQueen(Color.White), new PieceBishop(Color.White), new PieceHorse(Color.White), new PieceTour(Color.White)}
        };
        private Dictionary<string, int> posMapStr;

        public Board(Player playerA, Player playerB)
        {
            white = playerA.IsFirstPlayer() ? playerA : playerB;
            black = playerA.IsFirstPlayer() ? playerB : playerA;
            posMapStr = new Dictionary<string, int>() 
            {
                {"A8",  0}, {"B8",  1}, {"C8",  2}, {"D8",  3}, {"E8",  4}, {"F8",  5}, {"G8",  6}, {"H8",  7},
                {"A7",  8}, {"B7",  9}, {"C7", 10}, {"D7", 11}, {"E7", 12}, {"F7", 13}, {"G7", 14}, {"H7", 15},
                {"A6", 16}, {"B6", 17}, {"C6", 18}, {"D6", 19}, {"E6", 20}, {"F6", 21}, {"G6", 22}, {"H6", 23},
                {"A5", 24}, {"B5", 25}, {"C5", 26}, {"D5", 27}, {"E5", 28}, {"F5", 29}, {"G5", 30}, {"H5", 31},
                {"A4", 32}, {"B4", 33}, {"C4", 34}, {"D4", 35}, {"E4", 36}, {"F4", 37}, {"G4", 38}, {"H4", 39},
                {"A3", 40}, {"B3", 41}, {"C3", 42}, {"D3", 43}, {"E3", 44}, {"F3", 45}, {"G3", 46}, {"H3", 47},
                {"A2", 48}, {"B2", 49}, {"C2", 50}, {"D2", 50}, {"E2", 52}, {"F2", 53}, {"G2", 54}, {"H2", 55},
                {"A1", 56}, {"B1", 57}, {"C1", 58}, {"D1", 59}, {"E1", 60}, {"F1", 61}, {"G1", 62}, {"H1", 63},
            };
            // Initialize de Pieces Board reference.
            foreach(Piece piece in board)
            {
                if (piece != null)
                {
                    piece.SetBoard(this);
                }
            }
        }

        public Piece[,] GetBoard()
        {
            return board;
        }

        public void startGame()
        {
            Player winner;
            
            DisplayState();
            while (true)
            {
                bool res;
                string pos;
                int errorInPosString = -1;

                do
                {
                    Console.WriteLine("");
                    Console.WriteLine(white.AskMovePlayer());
                    pos = Console.ReadLine();
                    res = AddMove(white, pos, out errorInPosString);
                    if (!res)
                    {
                        switch (errorInPosString)
                        {
                            case -1:
                                Console.WriteLine("Invalid WHITE move!");
                                break;
                            case 1:
                                Console.WriteLine("Invalid WHITE move in FROM position!");
                                break;
                            case 2:
                                Console.WriteLine("Invalid WHITE move in TO position!");
                                break;
                        }
                    }
                } while (!res);
                DisplayState();
                if (HasFinished(white, out winner))
                    break;

                do
                {
                    Console.WriteLine("");
                    Console.WriteLine(black.AskMovePlayer());
                    pos = Console.ReadLine();
                    res = AddMove(black, pos, out errorInPosString);
                    if (!res)
                    {
                        switch (errorInPosString)
                        {
                            case -1:
                                Console.WriteLine("Invalid BLACK move!");
                                break;
                            case 1:
                                Console.WriteLine("Invalid BLACK move in FROM position!");
                                break;
                            case 2:
                                Console.WriteLine("Invalid BLACK in TO position!");
                                break;
                        }
                    }
                } while (!res);
                DisplayState();
                if (HasFinished(black, out winner))
                    break;

            }

            Console.WriteLine("");
            if (winner != null)
            {
                Console.WriteLine("Congratulations the winner is {0}.", winner.GetName());
            }
        }

        private void DisplayState()
        {
            string strOut = String.Format(
@"w_X - White Piece
b_X - Black Piece
x_K - King,   x_Q - Queen,  x_B - Bishop
x_H - Horse,  x_T - Tour,   x_P - Pawn

  Chess Board
  -------------------------------------------------
  |     |/   \|     |/   \|     |/   \|     |/   \|
8 | {0} |*{1}*| {2} |*{3}*| {4} |*{5}*| {6} |*{7}*|
  |     |\   /|     |\   /|     |\   /|     |\   /|
  -------------------------------------------------
  |/   \|     |/   \|     |/   \|     |/   \|     |
7 |*{8}*| {9} |*{10}*| {11} |*{12}*| {13} |*{14}*| {15} |
  |\   /|     |\   /|     |\   /|     |\   /|     |
  -------------------------------------------------
  |     |/   \|     |/   \|     |/   \|     |/   \|
6 | {16} |*{17}*| {18} |*{19}*| {20} |*{21}*| {22} |*{23}*|
  |     |\   /|     |\   /|     |\   /|     |\   /|
  -------------------------------------------------
  |/   \|     |/   \|     |/   \|     |/   \|     |
5 |*{24}*| {25} |*{26}*| {27} |*{28}*| {29} |*{30}*| {31} |
  |\   /|     |\   /|     |\   /|     |\   /|     |
  -------------------------------------------------
  |     |/   \|     |/   \|     |/   \|     |/   \|
4 | {32} |*{33}*| {34} |*{35}*| {36} |*{37}*| {38} |*{39}*|
  |     |\   /|     |\   /|     |\   /|     |\   /|
  -------------------------------------------------
  |/   \|     |/   \|     |/   \|     |/   \|     |
3 |*{40}*| {41} |*{42}*| {43} |*{44}*| {45} |*{46}*| {47} |
  |\   /|     |\   /|     |\   /|     |\   /|     |
  -------------------------------------------------
  |     |/   \|     |/   \|     |/   \|     |/   \|
2 | {48} |*{49}*| {50} |*{51}*| {52} |*{53}*| {54} |*{55}*|
  |     |\   /|     |\   /|     |\   /|     |\   /|
  -------------------------------------------------
  |/   \|     |/   \|     |/   \|     |/   \|     |
1 |*{56}*| {57} |*{58}*| {59} |*{60}*| {61} |*{62}*| {63} |
  |\   /|     |\   /|     |\   /|     |\   /|     |
  -------------------------------------------------
     A     B     C     D     E     F     G     H",
                cellStr(0),
                cellStr(1),
                cellStr(2),
                cellStr(3),
                cellStr(4),
                cellStr(5),
                cellStr(6),
                cellStr(7),
                cellStr(8),
                cellStr(9),
                cellStr(10),
                cellStr(11),
                cellStr(12),
                cellStr(13),
                cellStr(14),
                cellStr(15),
                cellStr(16),
                cellStr(17),
                cellStr(18),
                cellStr(19),
                cellStr(20),
                cellStr(21),
                cellStr(22),
                cellStr(23),
                cellStr(24),
                cellStr(25),
                cellStr(26),
                cellStr(27),
                cellStr(28),
                cellStr(29),
                cellStr(30),
                cellStr(31),
                cellStr(32),
                cellStr(33),
                cellStr(34),
                cellStr(35),
                cellStr(36),
                cellStr(37),
                cellStr(38),
                cellStr(39),
                cellStr(40),
                cellStr(41),
                cellStr(42),
                cellStr(43),
                cellStr(44),
                cellStr(45),
                cellStr(46),
                cellStr(47),
                cellStr(48),
                cellStr(49),
                cellStr(50),
                cellStr(51),
                cellStr(52),
                cellStr(53),
                cellStr(54),
                cellStr(55),
                cellStr(56),
                cellStr(57),
                cellStr(58),
                cellStr(59),
                cellStr(60),
                cellStr(61),
                cellStr(62),
                cellStr(63)
                );
            Console.WriteLine(strOut);
        }

        private string cellStr(int pos)
        {
            Piece piece = cellPiece(pos);
            return piece == null ? "   " : piece.ToString();
        }

        private Piece cellPiece(int pos)
        {
            var tuple = PosFrom1DTo2D(pos);
            Piece piece = board[tuple.Item1, tuple.Item2];
            return piece;
        }

        private Tuple<int, int> PosFrom1DTo2D(int pos)
        {
            return new Tuple<int, int>((pos / 8) % 8, pos % 8);
        }

        private bool HasFinished(Player afterPlayersMove, out Player winner)
        {
            // If King White is stil in the board.
            // If King Black is stil in the board.
            bool flagHasWhiteKing = false;
            int whiteKingPosX = -1;
            int whiteKingPosY = -1;
            Piece whiteKing = null;
            bool flagHasBlackKing = false;
            int blackKingPosX = -1;
            int blackKingPosY = -1;
            Piece blackKing = null;
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    Piece p = board[x, y];
                    if (p != null)
                    {
                        if (p.GetColor() == Color.White
                             && p.GetPieceType() == PieceType.King)
                        {
                            flagHasWhiteKing = true;
                            whiteKingPosX = x;
                            whiteKingPosY = y;
                            whiteKing = p;
                        }
                        else if (p.GetColor() == Color.Black
                                 && p.GetPieceType() == PieceType.King)
                        {
                            flagHasBlackKing = true;
                            blackKingPosX = x;
                            blackKingPosY = y;
                            blackKing = p;
                        }
                    }
                }
            }
            if (afterPlayersMove.GetColorEmum() == Color.White)
            {
                if (!flagHasBlackKing)
                {
                    winner = white;
                    return true;
                }
                if (whiteKing != null && ThereIsNoMoveOutOfCheckmate(whiteKing, whiteKingPosX, whiteKingPosY))
                {
                    // Has to account for it to stay in the same position.
                    winner = black;
                    return true;
                }
                if (blackKing != null && ThereIsNoMoveOutOfCheckmate(blackKing, blackKingPosX, blackKingPosY))
                {
                    // Has to account for it to stay in the same position.
                    winner = white;
                    return true;
                }
            }
            else if (afterPlayersMove.GetColorEmum() == Color.Black)
            {
                if (!flagHasWhiteKing)
                {
                    winner = black;
                    return true;
                }
                if (blackKing != null && ThereIsNoMoveOutOfCheckmate(blackKing, blackKingPosX, blackKingPosY))
                {
                    // Has to account for it to stay in the same position.
                    winner = white;
                    return true;
                }
                if (whiteKing != null && ThereIsNoMoveOutOfCheckmate(whiteKing, whiteKingPosX, whiteKingPosY))
                {
                    // Has to account for it to stay in the same position.
                    winner = black;
                    return true;
                }
            }

            winner = null;
            return false;
        }

        private bool AddMove(Player player, string pos, out int errorInPosString)
        {
            Color curPlayerColor = player.GetColorEmum();
            string from;
            string to;
            string[] subStr = pos.Split(" ");
            if (subStr.Length != 2)
            {
                errorInPosString = -1;
                return false;
            }
            from = subStr[0].Trim().ToUpper();
            to   = subStr[1].Trim().ToUpper();
            if (!posMapStr.ContainsKey(from))
            {
                errorInPosString = 1;
                return false;
            }
            if (!posMapStr.ContainsKey(to))
            {
                errorInPosString = 2;
                return false;
            }
            int posFrom = posMapStr[from];
            Piece pieceFrom = cellPiece(posFrom);
            if (pieceFrom == null || (pieceFrom != null && pieceFrom.GetColor() != curPlayerColor))
            {
                errorInPosString = 1;
                return false;
            }
            int posTo = posMapStr[to];
            Piece pieceTo = cellPiece(posTo);
            if (pieceTo != null && pieceTo.GetColor() == curPlayerColor)
            {
                errorInPosString = 2;
                return false;
            }
            var tupleFrom = PosFrom1DTo2D(posFrom);
            var tupleTo = PosFrom1DTo2D(posTo);
            if (pieceFrom.IsPossibleMove(tupleFrom.Item1, tupleFrom.Item2, tupleTo.Item1, tupleTo.Item2))
            {

                if (pieceFrom.GetPieceType() == PieceType.King && IsInCheckmate(pieceFrom.GetOtherColor(), tupleTo.Item1, tupleTo.Item2))
                {
                    Console.WriteLine("Invalid move it will be CheckMate!");
                    errorInPosString = 2;
                    return false;
                }

                // Makes a copy of the board.
                var boardTmp = board.Clone();

                // Make Move;
                board[tupleTo.Item1, tupleTo.Item2] = pieceFrom;
                board[tupleFrom.Item1, tupleFrom.Item2] = null;
                
                // Update All references in the peaces to the board. 
                foreach (Piece p in board)
                {
                    if (p != null)
                        p.SetBoard(this);
                }

                // Get my king position.
                int kingRow = -1;
                int kingCol = -1;
                for (int row = 0; row < 8; row++)
                {
                    for (int col = 0; col < 8; col++)
                    {
                        Piece piece = board[row, col];
                        if ( piece != null && piece.GetColor() == curPlayerColor && piece.GetPieceType() == PieceType.King)
                        {
                            kingRow = row;
                            kingCol = col;
                        }
                    }
                }

                if (IsInCheckmate(pieceFrom.GetOtherColor(), kingRow, kingCol))
                {
                    // Reverts the play.
                    board = (Piece[,])boardTmp;

                    // Update All references in the peaces to the board.
                    foreach (Piece p in board)
                    {
                        if (p != null)
                            p.SetBoard(this);
                    }

                    Console.WriteLine("Invalid move it will be CheckMate!");
                    errorInPosString = 1;
                    return false;
                }

                errorInPosString = -1;
                return true;
            }
            errorInPosString = 2;
            return false;
        }

        private HashSet<Tuple<int, int>> GetAllpossiblePosOfCheckmate(Color otherColor)
        {
            HashSet<Tuple<int, int>> hashSetOfPos = new HashSet<Tuple<int, int>>();
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    Piece piece = board[row, col];
                    if (piece != null && piece.GetColor() == otherColor)
                    {
                        var tuplePosAr = piece.PossibleMoves(MoveOrAtack.Atack, row, col);

                        // Debug.
                        // Console.WriteLine("PieceType: {0}", PieceTypeExt.AsText(piece.GetPieceType()));
                        // printAllPossibleMoves(tuplePosAr);

                        hashSetOfPos.UnionWith(tuplePosAr);
                    }
                }
            }

            return hashSetOfPos;
        }

        private bool IsInCheckmate(Color otherColor, int posToRow, int posToCol)
        {
            HashSet<Tuple<int, int>> hashSetOfPos = GetAllpossiblePosOfCheckmate(otherColor);
            //printAllPossibleMoves((new List<Tuple<int, int>>(hashSetOfPos)).ToArray());

            Tuple<int, int> tupleToPos = new Tuple<int, int>(posToRow, posToCol);
            if (hashSetOfPos.Contains(tupleToPos))
            {
                return true;
            }
            return false;
        }

        private bool ThereIsNoMoveOutOfCheckmate(Piece king, int posFromRow, int posFromCol)
        {
            Color otherColor = king.GetOtherColor();
            HashSet<Tuple<int, int>> hashSetOfPos = GetAllpossiblePosOfCheckmate(otherColor);
            // King
            Tuple<int, int>[] tuplePossibleMoves = king.PossibleMoves(MoveOrAtack.Move, posFromRow, posFromCol);
            var listPosKing = new List<Tuple<int, int>>(tuplePossibleMoves);
            // Test
            listPosKing.Add(new Tuple<int, int>(posFromRow, posFromCol));
            foreach (Tuple<int, int> tuplePosKing in listPosKing)
            {
                if (!hashSetOfPos.Contains(tuplePosKing))
                {
                    return false;
                }
            }
            return true;
        }
    
        public void printAllPossibleMoves(Tuple<int,int>[] allPossibleMoves)
        {
            // TODO: Add an HasSet.
            Console.WriteLine("All possible moves from other color.");
            foreach (Tuple<int, int> tupleMove in allPossibleMoves)
            {
                int row = tupleMove.Item1;
                int col = tupleMove.Item2;
                Console.Write("({0}, {1})", row, col);
            }
            Console.WriteLine("");
        }
    }
}
