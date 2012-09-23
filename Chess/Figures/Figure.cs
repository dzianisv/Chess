using System;
using System.Collections.Generic;
using System.Drawing;

namespace Chess
{
	namespace Figures
	{
		public class Figure: Object
		{

			//figure color
            protected FigureColor color;

            public FigureColor Color
            {
				get {
					return color;
				}
			}

			//file splite
			public const char SPLITER='/';
			public const string PREFIX="images/figures";

			//public static const string PREFIX="images/figures";

			//figure is moved
			protected bool moved;
			public bool IsMoved { get; set;	}


			//atack and move has differents directions
			protected bool diff;
			public bool HasDifferentDirections {
				get{ 
					return diff;
				} 
			}

			//figure image
			protected Bitmap img = null;
			public Bitmap image { 
				get {
					return img;
				}
			}

            public Figure(FigureColor acolor)
			{
				this.color = acolor;
				this.moved = false;
				this.diff = true;
			}

			protected bool IsInField (int x, int y)
			{
				if (x < 8 && y < 8 && y > -1 && x > -1)
					return true;
				else 
					return false;
			}

			public virtual List<Position> GetAvailableMovePossitons(Position currentPos)
			{
				List<Position> available = new List<Position>();
				available.Add (currentPos );
				return available;
			}

            public virtual List<Position> GetAvailableAtackPositons(Position currentPos, CoreMatrix matrix)
			{
				return GetAvailableMovePossitons(currentPos);
			}

			public virtual void ConsolePrintPosition (Position currentPos)
			{

				List<Position> available = GetAvailableMovePossitons (currentPos);

				System.Console.WriteLine ( ToString() +' ' +currentPos.X + ' ' +currentPos.Y );

				System.Console.Write ("\t");

				for (int i=0; i<8; i++) {
					System.Console.Write (i);
					System.Console.Write ('\t');
				}

				System.Console.Write ('\n');

				for (int i=0; i<8; i++) {
						System.Console.Write( i );
						System.Console.Write ('\t');

					for (int j=0; j<8; j++) {
	

						if( available.Contains(new Position(j, i)) )
						   System.Console.Write ('+');
						else if( new Position(i, j) == currentPos )
							System.Console.Write ('^');
						else
							System.Console.Write('0');

						System.Console.Write ('\t');
					}
					System.Console.Write("\n");
				}
			}
			//load image from file
			protected virtual void LoadBitmap( string name ) {
				System.String scolor;

                if (color == Chess.Figures.FigureColor.WHITE) 
					scolor = "white";
				else 
					scolor = "black";
					 
				String path = PREFIX + SPLITER 
							+ scolor
							+ '_'
							+ name 
							+".png";
				// images/figures/white_pawn.png
                try
                {
                    img = new Bitmap(path);
                }
                catch (System.Exception)
                {
                    img = null;
                    System.Windows.Forms.MessageBox.Show("File " + path.ToUpper() + " not found. Please, put it to the directory of executable file.", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }
				
			}
		}
	}
}
