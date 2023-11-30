using UnityEngine;
using System.Collections;

public class FaustineMazeGenerator : BasicMazeGenerator{
	public FaustineMazeGenerator(int row, int column):base(row, column) {
	}
	
	public override void GenerateMaze()
	{
		for (int i=0 ; i<RowCount ; i++)
		{
			GetMazeCell(i, 0).WallLeft = true;
			GetMazeCell(i, ColumnCount-1).WallRight = true;
		}

		for (int i=0 ; i<ColumnCount ; i++)
		{
			GetMazeCell(0, i).WallBack = true;
			GetMazeCell(RowCount-1, i).WallFront = true;
		}

		//Line one
		GetMazeCell(0, 1).WallRight = true;
		GetMazeCell(0, 4).WallFront = true;
		GetMazeCell(0, 5).WallFront = true;
		GetMazeCell(0, 7).WallFront = true;

		//Line two
		GetMazeCell(1, 0).WallRight = true;
		GetMazeCell(1, 1).WallRight = true;
		GetMazeCell(1, 2).WallFront = true;
		GetMazeCell(1, 3).WallFront = true;
		GetMazeCell(1, 4).WallFront = true;
		GetMazeCell(1, 5).WallRight = true;
		GetMazeCell(1, 6).WallRight = true;
		GetMazeCell(1, 7).WallRight = true;
		GetMazeCell(1, 8).WallRight = true;
		GetMazeCell(1, 9).WallFront = true;

		//Line three
		GetMazeCell(2, 0).WallBack = true;
		GetMazeCell(2, 1).WallLeft = true;
		GetMazeCell(2, 2).WallFront = true;
		GetMazeCell(2, 3).WallFront = true;
		GetMazeCell(2, 4).WallFront = true;
		GetMazeCell(2, 5).WallFront = true;
		GetMazeCell(2, 6).WallLeft = true;
		GetMazeCell(2, 8).WallLeft = true;
		GetMazeCell(2, 9).WallLeft = true;

		//Line four
		GetMazeCell(3, 0).WallRight = true;
		GetMazeCell(3, 1).WallFront = true;
		GetMazeCell(3, 2).WallLeft = true;
		GetMazeCell(3, 3).WallFront = true;
		GetMazeCell(3, 4).WallFront = true;
		GetMazeCell(3, 5).WallFront = true;
		GetMazeCell(3, 6).WallFront = true;
		GetMazeCell(3, 7).WallRight = true;
		GetMazeCell(3, 8).WallFront = true;
		GetMazeCell(3, 9).WallLeft = true;

		//Line five
		GetMazeCell(4, 1).WallFront = true;
		GetMazeCell(4, 2).WallFront = true;
		GetMazeCell(4, 3).WallRight = true;
		GetMazeCell(4, 6).WallBack = true;
		GetMazeCell(4, 7).WallLeft = true;
		GetMazeCell(4, 8).WallLeft = true;

		//Line six
		GetMazeCell(5, 0).WallRight = true;
		GetMazeCell(5, 1).WallFront = true;
		GetMazeCell(5, 2).WallFront = true;
		GetMazeCell(5, 3).WallFront = true;
		GetMazeCell(5, 4).WallLeft = true;
		GetMazeCell(5, 4).WallFront = true;
		GetMazeCell(5, 5).WallRight = true;
		GetMazeCell(5, 5).WallFront = true;
		GetMazeCell(5, 6).WallRight = true;
		GetMazeCell(5, 7).WallRight = true;
		GetMazeCell(5, 8).WallRight = true;

		//Line seven
		GetMazeCell(6, 1).WallFront = true;
		GetMazeCell(6, 2).WallFront = true;
		GetMazeCell(6, 3).WallFront = true;
		GetMazeCell(6, 4).WallFront = true;
		GetMazeCell(6, 5).WallFront = true;
		GetMazeCell(6, 5).WallLeft = true;
		GetMazeCell(6, 6).WallRight = true;
		GetMazeCell(6, 7).WallRight = true;
		GetMazeCell(6, 8).WallRight = true;

		//Line eight
		GetMazeCell(7, 0).WallRight = true;
		GetMazeCell(7, 2).WallFront = true;
		GetMazeCell(7, 3).WallFront = true;
		GetMazeCell(7, 4).WallFront = true;
		GetMazeCell(7, 5).WallFront = true;
		GetMazeCell(7, 6).WallFront = true;
		GetMazeCell(7, 7).WallLeft = true;
		GetMazeCell(7, 8).WallLeft = true;
		GetMazeCell(7, 9).WallLeft = true;

		//Line nine
		GetMazeCell(8, 0).WallRight = true;
		GetMazeCell(8, 1).WallFront = true;
		GetMazeCell(8, 2).WallFront = true;
		GetMazeCell(8, 3).WallFront = true;
		GetMazeCell(8, 4).WallFront = true;
		GetMazeCell(8, 5).WallFront = true;
		GetMazeCell(8, 6).WallRight = true;
		GetMazeCell(8, 7).WallFront = true;
		GetMazeCell(8, 8).WallFront = true;
		GetMazeCell(8, 9).WallLeft = true;

		//To avoid pillar without wall
		GetMazeCell(0, 3).WallFront = true;
		GetMazeCell(2, 6).WallRight = true;
		GetMazeCell(4, 5).WallFront = true;

		//Coin
		GetMazeCell(5, 5).IsGoal = true;
	}
}
