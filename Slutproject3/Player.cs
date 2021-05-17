using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Slutproject3
{
    class Player
    {
        public int pieceOneTotalPosition;
        private Rectangle pieceOne;
        public Rectangle PieceOne
        {
            get { return pieceOne; }
            set { pieceOne = value; }
        }

        public int pieceTwoTotalPosition;
        private Rectangle pieceTwo;
        public Rectangle PieceTwo
        {
            get { return pieceTwo; }
            set { pieceTwo = value; }
        }

        public int pieceThreeTotalPosition;
        private Rectangle pieceThree;
        public Rectangle PieceThree
        {
            get { return pieceThree; }
            set { pieceThree = value; }
        }

        public int pieceFourTotalPosition;
        private Rectangle pieceFour;
        public Rectangle PieceFour
        {
            get { return pieceFour; }
            set { pieceFour = value; }
        }
    }
}
