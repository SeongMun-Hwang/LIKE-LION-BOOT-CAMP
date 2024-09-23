using System;
using static System.Console;

class HelloWorld {
	static void Main() {
		//#1
		int a=1;
		int b=2;
		for(int i=0; i<10; i++) {
			a*=b;
			Console.WriteLine(a);
		}
		WriteLine();

		//#3
		int[] c= {0,1,2,3,4,5,6,7,8,9};
		int[] d=new int[10];
		for(int i=0; i<10; i++) {
			d[10-i-1]=c[i];
		}
		for(int i=0; i<10; i++) {
			c[i]=d[i];
			Console.WriteLine(c[i]);
		}
		Console.WriteLine();

		//#4
		bool[,] e=new bool[5,5];
		for(int i=0; i<5; i++) {
			for(int j=0; j<5; j++) {
				if(i>j) {
					e[i,j]=true;
					Console.Write("true ");
				}
				else if(j>i) {
					e[i,j]=false;
					Console.Write("false ");
				}
				else Console.Write("Null ");
			}
			Console.WriteLine();
		}

		//#8
		int[,] f=new int[2,2];
		int[,] g=new int[2,2];

		//#9
		int[,] m = {
			{1, 2, 3},
			{4, 5, 6},
			{7, 8, 9}
		};

		int[,] n = {
			{9, 8, 7},
			{6, 5, 4},
			{3, 2, 1}
		};

		int[,] sumMatrix = new int[3, 3];
		int[,] productMatrix = new int[3, 3];

		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				sumMatrix[i, j] = m[i, j] + n[i, j];
			}
		}

		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				productMatrix[i, j] = 0;
				for (int k = 0; k < 3; k++)
				{
					productMatrix[i, j] += m[i, k] * n[k, j];
				}
			}
		}
		Console.WriteLine();
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				Console.Write(sumMatrix[i, j] + "\t");
			}
			Console.WriteLine();
		}
		Console.WriteLine();
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				Console.Write(productMatrix[i, j] + "\t");
			}
			Console.WriteLine();
		}
		Console.WriteLine();
		
		//#10
		int[] l={3,10,6,2,7,9,1,8,5,4};
		for(int i=0;i<9;i++){
		    for(int j=i+1;j<10;j++){
		        if(l[i]>l[j]){
		            int temp=l[i];
		            l[i]=l[j];
		            l[j]=temp;
		        }
		    }
		}
		for(int i=0;i<10;i++){
		    Console.Write(l[i]+" ");
		}
	}
}